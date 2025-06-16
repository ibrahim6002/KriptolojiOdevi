Kriptoloji Web Uygulaması

Bu proje, ASP.NET Core tabanlı statik bir web uygulamasıdır ve yalnızca grafik arayüz (GUI) içermektedir.
Kullanıcıların AES şifreleme / deşifreleme ve SHA hash oluşturma işlemlerini kolayca gerçekleştirmelerini sağlar.

📌 Özellikler

 UI/UX Tasarımı
- Beyaz / Aydınlık Tema (Koyu renkler kullanılmamıştır)
- Tailwind CSS ile modern ve kullanıcı dostu tasarım
- Responsive arayüz (Mobil ve masaüstü uyumluluğu)
- Yardımcı açıklamalar için tooltip ve info iconlar
  
Ana Sayfa
![kripto görsel 1](https://github.com/user-attachments/assets/feb6a82f-c5ae-4a7a-8b53-38c29fb824fb)
Bu ekran, uygulamanın ana giriş sayfasını göstermektedir. Kullanıcılar burada AES şifreleme / deşifreleme ve SHA hash hesaplama işlemlerini gerçekleştirebilirler. Arayüz, sade ve okunabilir bir tasarıma sahiptir. Sağ üst köşede algoritma seçenekleri, orta bölümde işlem kartları, alt kısımda ise bilgilendirici açıklamalar ve yönlendirmeler bulunmaktadır. Kullanıcılar, bu bölümden şifreleme veya hash hesaplama modüllerine kolayca erişebilir.

🔑 Şifreleme / Deşifreleme
Kullanıcı, aşağıdaki AES algoritmalarını kullanarak metin şifreleyebilir ve çözebilir:
AES (AES-128, AES-256)
- Şifreleme Modları: CBC (varsayılan), ECB (uyarı ile birlikte)
- Padding Modları: PKCS7 (varsayılan), None
- Anahtar Boyutları: 128-bit veya 256-bit seçilebilir
- IV (Initialization Vector): Otomatik oluşturulur ve kopyalanabilir
Anahtar Üretme Aracı:
- Kullanıcı AES anahtarları ve IV oluşturabilir.
- Kopyalama ve export seçenekleri bulunur.
  
![kripto görsel 2](https://github.com/user-attachments/assets/b70f2e04-bd0e-476e-af9a-7a0a07feff8c)

Bu ekran görüntüsünde AES Şifreleme ve Deşifreleme arayüzü görülüyor. Kullanıcı, şifreleme modunu (CBC, ECB), anahtar boyutunu (128-bit, 256-bit) ve dolgu modunu (PKCS7, None) seçebiliyor. Ayrıca anahtar (key) ve IV (Initialization Vector) değerlerini girebiliyor ve şifreleme/deşifre işlemlerini gerçekleştirebiliyor.

![kripto görsel 3](https://github.com/user-attachments/assets/71b4b821-5226-47e2-a3f6-1a347786f22b)
![kripto görsel 4](https://github.com/user-attachments/assets/7ddc427e-cee8-4135-a239-68682dd07bdf)

Kullanıcı CBC şifreleme modunu, 128-bit anahtar boyutunu, PKCS7 dolgu modunu seçmiş ve bir metni şifreleyip çözmüş. Şifrelenmiş metin ve çözülmüş sonuç GUI üzerinde gösteriliyor. Ayrıca, kullanıcı anahtar ve IV değerlerini girerek işlemi gerçekleştirmiş. Sonuç kısmında "merhaba" ifadesi görülüyor, yani şifreleme ve deşifreleme başarıyla çalışıyor.

![kripto görsel 5](https://github.com/user-attachments/assets/b287276d-af8c-4a0d-821d-44da681a224b)
![kripto görsel 6](https://github.com/user-attachments/assets/af8087f2-3a9c-4a83-960f-9d169f663340)

ECB şifreleme modu kullanılarak gerçekleştirilmiş. ECB modunun güvensiz olduğu vurgulanıyor ve test amaçlı kullanım öneriliyor. Kullanıcı 256-bit anahtar ve PKCS7 dolgu yöntemi kullanarak şifreleme işlemi yapmış. Şifrelenmiş metin ve deşifre sonucu GUI’de gösteriliyor.
Ekranın önemli detayları:
- Şifreleme Modu: ECB (Elektronik Kod Kitabı)
- Anahtar Boyutu: 256-bit
- Padding Modu: PKCS7
- Anahtar ve IV Kullanımı: ECB modunda IV kullanılmaz
- Sonuç: Başarıyla deşifre edilen metin: SEKLAMLAR
- Kopyalama ve İndirme: Kullanıcı şifrelenmiş veya çözümlenmiş metni kaydedebilir


🧾 SHA Hash Fonksiyonu
Kullanıcı aşağıdaki SHA algoritmaları ile metin veya dosya için hash değeri oluşturabilir:
- SHA-1 (160-bit) ⚠️ Güvenlik açısından zayıf
- SHA-256 (256-bit) Modern uygulamalar için önerilir
- SHA-384 ve SHA-512 Daha yüksek güvenlik gerektiren sistemler için
  
![kripto görsel 7](https://github.com/user-attachments/assets/97cd06be-dd00-4267-9053-05c15945648e)

Bu ekran görüntüsünde Hash İşlemleri bölümü yer alıyor. Kullanıcı SHA-1 (160-bit) algoritmasını seçerek bir metnin hash değerini hesaplamış. "KRİPTOLOJİ" metni için oluşturulan hash değeri 268a1af9e431244c886346a0eade8cfc3c11c8bb olarak görüntülenmiş. Kullanıcı ayrıca hexadecimal veya Base64 formatında çıktı alabiliyor, 

![kripto görsel 8](https://github.com/user-attachments/assets/4cbb51ff-b666-4118-a825-318f18c1ed83)

SHA-256 (256-bit) hash işlemi gösteriliyor. Kullanıcı "TEST YAZI" metnini girerek SHA-256 algoritmasını seçmiş ve hexadecimal formatta hash değerini üretmiş. Sonuç 339741b89f11bfabf3ed7a95b4c89acaf4e4ebd54a4482d8d6e7d12f88d99d olarak görüntülenmiş.


Hash sonuçları Hexadecimal veya Base64 formatında sunulabilir ve kopyalanabilir veya indirilebilir.

📂 Dosya Hash Hesaplama
- Kullanıcı PNG, JPG, PDF, TXT vb. dosyalarını yükleyerek hash değeri oluşturabilir.
- Sürükleyip bırakma (Drag & Drop) desteği bulunmaktadır.
![kripto görsel 9](https://github.com/user-attachments/assets/7d1f98ac-b5f3-4958-a93c-ccaffeae58f3)

dosya tabanlı hash hesaplama işlemi gösteriliyor. Kullanıcı PNG, JPG, PDF, TXT formatındaki dosyaları sürükleyerek veya yükleyerek hash değerini hesaplayabiliyor. Hash hesaplama butonu ile işlem başlatılıyor ve sonuç hexadecimal veya Base64 formatında ekrana geliyor.



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
