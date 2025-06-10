using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;

namespace KriptolojiProje.Pages
{
    public class HashModel : PageModel
    {
        [BindProperty]
        public string? Result { get; set; }
        [BindProperty]
        public string HashAlgorithm { get; set; } = "SHA1";
        [BindProperty]
        public string OutputFormat { get; set; } = "hex";
        [BindProperty]
        public string? InputText { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var file = Request.Form.Files.FirstOrDefault();
            if (string.IsNullOrEmpty(InputText) && file == null)
            {
                ModelState.AddModelError("", "Lütfen bir metin girin veya dosya yükleyin.");
                return Page();
            }

            try
            {
                byte[] data;
                if (file != null)
                {
                    using var stream = file.OpenReadStream();
                    using var ms = new MemoryStream();
                    await stream.CopyToAsync(ms);
                    data = ms.ToArray();
                }
                else
                {
                    data = Encoding.UTF8.GetBytes(InputText!);
                }

                byte[] hashBytes = CalculateHash(data, HashAlgorithm);
                Result = FormatHash(hashBytes, OutputFormat);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"İşlem sırasında bir hata oluştu: {ex.Message}");
            }

            return Page();
        }

        private byte[] CalculateHash(byte[] data, string algorithm)
        {
            HashAlgorithm? hashAlg = null;
            switch (algorithm)
            {
                case "SHA1":
                    hashAlg = SHA1.Create();
                    break;
                case "SHA256":
                    hashAlg = SHA256.Create();
                    break;
                case "SHA384":
                    hashAlg = SHA384.Create();
                    break;
                case "SHA512":
                    hashAlg = SHA512.Create();
                    break;
                default:
                    throw new ArgumentException("Geçersiz hash algoritması.");
            }
            using (hashAlg)
            {
                return hashAlg.ComputeHash(data);
            }
        }

        private string FormatHash(byte[] hashBytes, string format)
        {
            return format switch
            {
                "hex" => BitConverter.ToString(hashBytes).Replace("-", "").ToLower(),
                "base64" => Convert.ToBase64String(hashBytes),
                _ => throw new ArgumentException("Geçersiz çıktı formatı.")
            };
        }
    }
} 