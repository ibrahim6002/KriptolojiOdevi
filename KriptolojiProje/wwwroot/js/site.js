// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Anahtar ve IV üretimi
function generateKey(size) {
    const array = new Uint8Array(size / 8);
    window.crypto.getRandomValues(array);
    return btoa(String.fromCharCode.apply(null, array));
}

// Kopyalama işlemi
function copyToClipboard(text) {
    navigator.clipboard.writeText(text).then(() => {
        showToast('Kopyalandı!');
    }).catch(err => {
        console.error('Kopyalama hatası:', err);
        showToast('Kopyalama başarısız!', true);
    });
}

// Toast bildirimi
function showToast(message, isError = false) {
    const toast = document.createElement('div');
    toast.className = `fixed bottom-4 right-4 px-4 py-2 rounded-md text-white ${
        isError ? 'bg-red-600' : 'bg-green-600'
    } transition-opacity duration-300`;
    toast.textContent = message;
    document.body.appendChild(toast);

    setTimeout(() => {
        toast.style.opacity = '0';
        setTimeout(() => toast.remove(), 300);
    }, 2000);
}

// Dosya sürükle-bırak
function setupDragAndDrop() {
    const dropZone = document.querySelector('.border-dashed');
    if (!dropZone) return;

    ['dragenter', 'dragover', 'dragleave', 'drop'].forEach(eventName => {
        dropZone.addEventListener(eventName, preventDefaults, false);
    });

    function preventDefaults(e) {
        e.preventDefault();
        e.stopPropagation();
    }

    ['dragenter', 'dragover'].forEach(eventName => {
        dropZone.addEventListener(eventName, highlight, false);
    });

    ['dragleave', 'drop'].forEach(eventName => {
        dropZone.addEventListener(eventName, unhighlight, false);
    });

    function highlight(e) {
        dropZone.classList.add('border-green-500');
    }

    function unhighlight(e) {
        dropZone.classList.remove('border-green-500');
    }

    dropZone.addEventListener('drop', handleDrop, false);

    function handleDrop(e) {
        const dt = e.dataTransfer;
        const files = dt.files;
        const fileInput = document.querySelector('input[type="file"]');
        if (fileInput) {
            fileInput.files = files;
        }
    }
}

function bindCopyAndGenerateButtons() {
    // Sonuç kutusundaki kopyala butonu
    document.querySelectorAll('button').forEach(button => {
        if (button.textContent.trim() === 'Kopyala') {
            button.onclick = () => {
                const result = button.closest('.bg-gray-50, .bg-white')?.querySelector('pre');
                if (result) copyToClipboard(result.textContent);
            };
        }
    });
    // Sonuç kutusundaki indir butonu
    document.querySelectorAll('button').forEach(button => {
        if (button.textContent.trim() === 'İndir') {
            button.onclick = () => {
                const result = button.closest('.bg-gray-50, .bg-white')?.querySelector('pre');
                if (result) {
                    const blob = new Blob([result.textContent], { type: 'text/plain' });
                    const url = window.URL.createObjectURL(blob);
                    const a = document.createElement('a');
                    a.href = url;
                    a.download = 'sonuc.txt';
                    document.body.appendChild(a);
                    a.click();
                    window.URL.revokeObjectURL(url);
                    a.remove();
                }
            };
        }
    });
    // Anahtar ve IV yeni üretme butonları
    document.querySelectorAll('button').forEach(button => {
        if (button.textContent.trim() === 'Yeni') {
            button.onclick = () => {
                const input = button.parentElement.querySelector('input');
                if (!input) return;
                if (input.name === 'key') {
                    const keySizeSelect = document.querySelector('select[name="keySize"]');
                    let size = 256;
                    if (keySizeSelect) size = parseInt(keySizeSelect.value);
                    input.value = generateKey(size);
                } else if (input.name === 'iv') {
                    input.value = generateKey(128);
                }
            };
        }
    });
    // Anahtar ve IV kopyalama simgesi
    document.querySelectorAll('button[data-copy]').forEach(button => {
        button.onclick = () => {
            const type = button.getAttribute('data-copy');
            let input = null;
            if (type === 'key') input = document.querySelector('input[name="key"]');
            if (type === 'iv') input = document.querySelector('input[name="iv"]');
            if (input) copyToClipboard(input.value);
        };
    });
}

// Sayfa yüklendiğinde
document.addEventListener('DOMContentLoaded', () => {
    setupDragAndDrop();
    bindCopyAndGenerateButtons();
    // Şifreleme modu değiştiğinde IV inputunu disable et
    const modeSelect = document.getElementById('encryptionMode');
    const ivInput = document.getElementById('iv');
    modeSelect && modeSelect.addEventListener('change', function () {
        if (modeSelect.value === 'ECB') {
            ivInput.disabled = true;
            if (!document.getElementById('iv-hidden')) {
                const hidden = document.createElement('input');
                hidden.type = 'hidden';
                hidden.name = 'iv';
                hidden.id = 'iv-hidden';
                hidden.value = ivInput.value;
                ivInput.parentNode.appendChild(hidden);
            }
        } else {
            ivInput.disabled = false;
            const hidden = document.getElementById('iv-hidden');
            if (hidden) hidden.remove();
        }
    });
});

// Form submit sonrası tekrar butonları bağla
if (window.MutationObserver) {
    const observer = new MutationObserver(() => {
        bindCopyAndGenerateButtons();
    });
    observer.observe(document.body, { childList: true, subtree: true });
}
