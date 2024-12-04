using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama_Agacı
{
    internal class Program
    {

        // Ağaç düğümünü temsil eden sınıf
        public class AgacDugumu
        {
            public int Deger;    // Düğümün değeri
            public AgacDugumu Sol;  // Sol alt düğüm
            public AgacDugumu Sag; // Sağ alt düğüm

            // Yapıcı metot, düğüm oluştururken değeri alır
            public AgacDugumu(int deger)
            {
                Deger = deger;
                Sol = null;
                Sag = null;
            }
        }

        // Ağaç sınıfı, ağaçla ilgili işlemleri burada yapacağız
        public class KodlamaAgaci
        {
            public AgacDugumu Kok; // Ağaçtaki kök düğüm

            // Yapıcı metot, başlangıçta ağaç boş olur
            public KodlamaAgaci()
            {
                Kok = null;
            }

            // Ağaçta yeni bir değer ekleme işlemi
            public void Ekle(int deger)
            {
                Kok = EkleRec(Kok, deger);
            }

            // Rekürsif yöntemle yeni değeri ağaca ekleriz
            private AgacDugumu EkleRec(AgacDugumu kok, int deger)
            {
                // Eğer kök boşsa, yeni düğümü burada oluştururuz
                if (kok == null)
                {
                    kok = new AgacDugumu(deger);
                    return kok;
                }

                // Eğer değer küçükse, sol alt ağaca ekleriz
                if (deger < kok.Deger)
                {
                    kok.Sol = EkleRec(kok.Sol, deger);
                }
                // Eğer değer büyükse, sağ alt ağaca ekleriz
                else if (deger > kok.Deger)
                {
                    kok.Sag = EkleRec(kok.Sag, deger);
                }

                // Kökü geri döndürüyoruz
                return kok;
            }

            // Ağaçta sıralı gezinerek değerleri yazdırma işlemi
            public void SiraliGezinti()
            {
                SiraliGezintiRec(Kok);
            }

            // Rekürsif sıralı gezinti fonksiyonu
            private void SiraliGezintiRec(AgacDugumu kok)
            {
                if (kok != null)
                {
                    SiraliGezintiRec(kok.Sol); // Sol alt ağaç
                    Console.WriteLine(kok.Deger); // Kök düğüm
                    SiraliGezintiRec(kok.Sag); // Sağ alt ağaç
                }
            }
        }

        static void Main(string[] args)
        {
            // Kullanıcıdan değerler alacağımız KodlamaAgaci nesnesi
            KodlamaAgaci agac = new KodlamaAgaci();

            bool devamEt = true;

            while (devamEt)
            {
                // Kullanıcıya seçenekler sunuyoruz
                Console.WriteLine("\nLütfen bir işlem seçin:");
                Console.WriteLine("1 - Ağaçta bir değer ekle");
                Console.WriteLine("2 - Ağaçtaki değerleri sıralı olarak göster");
                Console.WriteLine("3 - Çık");

                // Kullanıcıdan seçim alıyoruz
                string secim = Console.ReadLine();

                // Kullanıcı seçimine göre işlem yapıyoruz
                switch (secim)
                {
                    case "1":
                        // Kullanıcıdan bir değer alıyoruz ve ağaca ekliyoruz
                        Console.Write("Ağaca eklemek için bir sayı girin: ");
                        string degerInput = Console.ReadLine();
                        int deger;

                        // Girilen değeri integer'a çeviriyoruz
                        if (int.TryParse(degerInput, out deger))
                        {
                            agac.Ekle(deger);
                            Console.WriteLine($"{deger} değeri ağaca eklendi.");
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz bir değer girdiniz, lütfen geçerli bir sayı girin.");
                        }
                        break;

                    case "2":
                        // Ağacın sıralı gezintisini yapıyoruz ve sonuçları yazdırıyoruz
                        Console.WriteLine("\nAğaçtaki sıralı değerler:");
                        agac.SiraliGezinti();
                        break;

                    case "3":
                        // Programdan çıkmak için seçilen seçenek
                        Console.WriteLine("Çıkılıyor...");
                        devamEt = false;  // Döngüyü sonlandırıyoruz
                        break;

                    default:
                        // Geçersiz seçim yapıldığında kullanıcıyı uyarıyoruz
                        Console.WriteLine("Geçersiz bir seçim yaptınız, lütfen geçerli bir seçenek girin.");
                        break;
                }
            }
            Console.Read();
        }
    }
}

