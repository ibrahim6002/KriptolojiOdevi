using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;

namespace KriptolojiProje.Pages
{
    public class EncryptionModel : PageModel
    {
        [BindProperty]
        public string? Result { get; set; }
        [BindProperty]
        public string? Key { get; set; }
        [BindProperty]
        public string? IV { get; set; }
        [BindProperty]
        public string EncryptionMode { get; set; } = "CBC";
        [BindProperty]
        public string KeySize { get; set; } = "128";
        [BindProperty]
        public string PaddingMode { get; set; } = "PKCS7";
        [BindProperty]
        public string? InputText { get; set; }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(Key))
                Key = GenerateRandomBase64(32); // 256 bit
            if (string.IsNullOrEmpty(IV))
                IV = GenerateRandomBase64(16); // 128 bit
        }

        public IActionResult OnPost(string action)
        {
            // Key ve IV boşsa otomatik üret
            if (string.IsNullOrEmpty(Key))
                Key = GenerateRandomBase64(int.Parse(KeySize) / 8);
            if (string.IsNullOrEmpty(IV))
                IV = GenerateRandomBase64(16); // AES için 128 bit IV

            if (string.IsNullOrEmpty(InputText))
            {
                ModelState.AddModelError("inputText", "Lütfen bir metin girin.");
                return Page();
            }

            // PaddingMode.None seçiliyse, metin uzunluğu 16'nın katı olmalı
            if (PaddingMode == "None")
            {
                var inputBytes = Encoding.UTF8.GetBytes(InputText);
                if (inputBytes.Length % 16 != 0)
                {
                    ModelState.AddModelError("inputText", "Padding 'None' seçildiğinde metin uzunluğu 16'nın katı olmalıdır.");
                    return Page();
                }
            }

            try
            {
                if (action == "encrypt")
                {
                    Result = EncryptText(InputText, EncryptionMode, int.Parse(KeySize), PaddingMode, Key, IV);
                }
                else if (action == "decrypt")
                {
                    Result = DecryptText(InputText, EncryptionMode, int.Parse(KeySize), PaddingMode, Key, IV);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"İşlem sırasında bir hata oluştu: {ex.Message}");
            }

            return Page();
        }

        private string EncryptText(string plainText, string encryptionMode, int keySize, string paddingMode, string key, string iv)
        {
            using var aes = Aes.Create();
            aes.KeySize = keySize;
            aes.Mode = GetCipherMode(encryptionMode);
            aes.Padding = GetPaddingMode(paddingMode);

            aes.Key = Convert.FromBase64String(key);
            aes.IV = Convert.FromBase64String(iv);

            using var encryptor = aes.CreateEncryptor();
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

            return Convert.ToBase64String(cipherBytes);
        }

        private string DecryptText(string cipherText, string encryptionMode, int keySize, string paddingMode, string key, string iv)
        {
            using var aes = Aes.Create();
            aes.KeySize = keySize;
            aes.Mode = GetCipherMode(encryptionMode);
            aes.Padding = GetPaddingMode(paddingMode);

            aes.Key = Convert.FromBase64String(key);
            aes.IV = Convert.FromBase64String(iv);

            using var decryptor = aes.CreateDecryptor();
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] plainBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);

            return Encoding.UTF8.GetString(plainBytes);
        }

        private CipherMode GetCipherMode(string mode)
        {
            return mode switch
            {
                "CBC" => CipherMode.CBC,
                "ECB" => CipherMode.ECB,
                _ => CipherMode.CBC
            };
        }

        private PaddingMode GetPaddingMode(string mode)
        {
            switch (mode)
            {
                case "PKCS7":
                    return System.Security.Cryptography.PaddingMode.PKCS7;
                case "None":
                    return System.Security.Cryptography.PaddingMode.None;
                default:
                    return System.Security.Cryptography.PaddingMode.PKCS7;
            }
        }

        private string GenerateRandomBase64(int byteLength)
        {
            var bytes = new byte[byteLength];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
} 