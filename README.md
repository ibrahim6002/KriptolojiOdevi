🔐 Kriptoloji Web Uygulaması
Bu proje, ASP.NET Core tabanlı statik bir web uygulamasıdır ve yalnızca grafik arayüz (GUI) içermektedir. Kullanıcıların AES şifreleme / deşifreleme ve SHA hash oluşturma işlemlerini kolayca gerçekleştirmelerini sağlar.
📌 Özellikler
🎨 UI/UX Tasarımı
- Beyaz / Aydınlık Tema (Koyu renkler kullanılmamıştır)
- Tailwind CSS ile modern ve kullanıcı dostu tasarım
- Responsive arayüz (Mobil ve masaüstü uyumluluğu)
- Yardımcı açıklamalar için tooltip ve info iconlar

🔑 Şifreleme / Deşifreleme
Kullanıcı, aşağıdaki AES algoritmalarını kullanarak metin şifreleyebilir ve çözebilir:
AES (AES-128, AES-256)
- Şifreleme Modları: CBC (varsayılan), ECB (uyarı ile birlikte), GCM (gelişmiş kullanıcılar için)
- Padding Modları: PKCS7 (varsayılan), None, Zeros
- Anahtar Boyutları: 128-bit veya 256-bit seçilebilir
- IV (Initialization Vector): Otomatik oluşturulur ve kopyalanabilir
Anahtar Üretme Aracı:
- Kullanıcı AES anahtarları ve IV oluşturabilir.
- Kopyalama ve export seçenekleri bulunur.
📸 Ekran Görüntüsü AES Şifreleme Ekranı

🧾 SHA Hash Fonksiyonu
Kullanıcı aşağıdaki SHA algoritmaları ile metin veya dosya için hash değeri oluşturabilir:
- SHA-1 (160-bit) ⚠️ Güvenlik açısından zayıf
- SHA-256 (256-bit) Modern uygulamalar için önerilir
- SHA-384 ve SHA-512 Daha yüksek güvenlik gerektiren sistemler için
📸 Ekran Görüntüsü SHA-256 Hash Ekranı
Hash sonuçları Hexadecimal veya Base64 formatında sunulabilir ve kopyalanabilir veya indirilebilir.

📂 Dosya Hash Hesaplama
- Kullanıcı PNG, JPG, PDF, TXT vb. dosyalarını yükleyerek hash değeri oluşturabilir.
- Sürükleyip bırakma (Drag & Drop) desteği bulunmaktadır.
📸 Ekran Görüntüsü Dosya Hash Hesaplama

📖 Kullanım Adımları
- Şifreleme: Metni girin, algoritma seçeneklerini belirleyin ve "Şifrele" butonuna basın.
- Deşifreleme: Şifrelenmiş metni girin, anahtar ve IV değerini belirleyin ve "Çöz" butonuna basın.
- Hash Oluşturma: Metin girin veya dosya yükleyin, SHA algoritmasını seçin ve "Hash Hesapla" butonuna basın.
- Sonuçları Kopyala / İndir: Hash veya şifreleme sonucunu kolayca alabilirsiniz.

⚙️ Teknik Standartlar
- SOLID prensipleri ve C# kodlama standartlarına uygun geliştirme
- Statik proje yapısı (Veritabanı bulunmamaktadır)
- Katmanlı yapı (View, Controller, Service)

📜 Lisans
Bu proje açık kaynak olarak paylaşılmaktadır. Kullanımı serbesttir ancak ticari amaçlar için uygunluğu kontrol edilmelidir.
