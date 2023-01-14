using System.Security.Cryptography.X509Certificates;
using static ConsoleExercise.Program;

namespace ConsoleExercise
{
    internal class Program
    {

        public class Ogrenci
        {

            //
            public int OgrenciNo { get; set; }
            public string? Ad { get; set; }
            public string? Soyad { get; set; }
            public int DogumYili { get; set; }
            public bool CalisiyorMu { get; set; }
            public string? Cinsiyet { get; set; }
            public string? TelefonNumarasi { get; set; }
            
        }

        static List<Ogrenci> ogrenciler = new List<Ogrenci>();
        static void Main(string[] args)
        {

           
            KayitliOgrencileriGetir();
           
            MenuyuGoster(true);
        }




        static void KayitliOgrencileriGetir()
        {
            ogrenciler.Add(new Ogrenci
            {
                OgrenciNo=22,
                Ad = "Ömer",
                Soyad = "Köse",
                DogumYili=1999,
                Cinsiyet="erkek",
                CalisiyorMu=true,

                
            });
        }

        static bool OgrenciKayitliMi(int ogrenciNo)
        {
            foreach (var ogrenci in ogrenciler)
            {
                if (ogrenciNo == ogrenci.OgrenciNo)
                {
                  
                    return true;
                }
            }
            return false;
        }
       public static void OgrenciEkleme()
        {
            Ogrenci ogrenci = new Ogrenci();
            Console.Clear();

            Console.WriteLine("Öğrenci Numaranızı Giriniz:");
            int inputOgrenciNo = Convert.ToInt32(Console.ReadLine());

            bool ogrenciKayitliMi = OgrenciKayitliMi(inputOgrenciNo);
             
            if (ogrenciKayitliMi)
            {
                
                  
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Öğrenci Numarası Kayıtlı");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Tekrar denemek için bir tuşa basın");

                Console.ReadKey();
                OgrenciEkleme();
            }
            

            Console.Write("Öğrenci adını giriniz: ");
            string? inputOgrenciAdi = Console.ReadLine();

            Console.Write("Öğrenci soyadını giriniz: ");
            string? inputOgrenciSoyadi = Console.ReadLine();

            Console.Write("Öğrenci doğum yılını giriniz: ");
            string? inputOgrenciDogumYili = Console.ReadLine();

            Console.Write("Öğrenci cinsiyetini giriniz: (erkek/kadın)");
            string? inputOgrenciCinsiyet = Console.ReadLine();

            Console.Write("Öğrenci çalışıyor mu? (E/h) : ");
            string? inputOgrenciCalisiyorMu = Console.ReadLine();

            // ogrenci class'ından bir instance aldik. yeni bir ogrenci olusturuyoruz.
            Ogrenci yeniOgrenci = new Ogrenci();

            yeniOgrenci.Ad = inputOgrenciAdi;
            yeniOgrenci.Soyad = inputOgrenciSoyadi;
            yeniOgrenci.OgrenciNo = inputOgrenciNo;

            int ogrenciDogumYili;
            
            bool ogrenciDogumYiliUygunMu = int.TryParse(inputOgrenciDogumYili, out ogrenciDogumYili);

            // if(ogrenciDogumYiliUygunMu) yazmamiz da yeterli
            if (ogrenciDogumYiliUygunMu == true)
            {
                yeniOgrenci.DogumYili = ogrenciDogumYili;
            }

            if (inputOgrenciCinsiyet == "erkek" || inputOgrenciCinsiyet == "kadin")
            {
                yeniOgrenci.Cinsiyet = inputOgrenciCinsiyet;
            }

            // 'h' haric her kosulda evet kabul ediyoruz.
            if (inputOgrenciCalisiyorMu != "h")
                
            {
                yeniOgrenci.CalisiyorMu = true;
            }
            else
            {
                yeniOgrenci.CalisiyorMu = false;
            }



          
            // en disarida tanimladigimiz static ogrenci icine ekliyoruz.
            ogrenciler.Add(yeniOgrenci);

            // eklendigine dair mesaj
            Console.Clear();
            Console.WriteLine("Yeni öğrenci kaydı yapıldı. Toplam " + ogrenciler.Count + " adet öğrenci kayıtlı.");

            // ekranda biraz bosluk yapalim
            Console.WriteLine("");
            Console.WriteLine("-------------------------");

            Console.WriteLine("Ana menüye dönmek için bir tuşa basın.");

            // kullanici tusa bassin diye bekliyoruz. hangi tus oldugu onemli degil o yuzden kontrol etmiyoruz.
            Console.ReadKey();

            MenuyuGoster();


        }
        static void MenuyuGoster(bool selamlamaMesajGoster = false)
        {
            

            if(selamlamaMesajGoster == true)
            {
                Console.WriteLine("Hoşgeldiniz.");
            }

            Console.WriteLine("Yapmak istediğiniz işlemi seçin: ");
            Console.WriteLine("1: Öğrencileri Listele");
            Console.WriteLine("2: Yeni Öğrenci ekleme");
            Console.WriteLine("3: Çıkış Yap:");

            ConsoleKey basilanKarakter = Console.ReadKey().Key;
           
            
                switch (basilanKarakter)
                {

                    case ConsoleKey.D1:

                        OgrencileriListele();
                        break;

                    case ConsoleKey.D2:
                        OgrenciEkleme();
                        break;

                    case ConsoleKey.D3:

                        Console.Clear();
                        Console.WriteLine("Hoşçakalın.");
                        break;

                    default:
                    Clr();
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Hatalı Tuşlama Yaptınız.");

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine("Lütfen Tekrar deneyiniz.");

                    Console.ForegroundColor = ConsoleColor.White;
                    MenuyuGoster();
                    break;
                
                }
                    

        }
        public static void OgrencileriListele()
        {
            Console.Clear();

            for (int i = 0; i < ogrenciler.Count; i++)
            {
                int sira = 1 + i;
                //degiskeni cachelemek -- bu bir best practicetir.
                Console.WriteLine(sira + "." + "Öğrencinin bilgileri aşağıdaki gibidir;");
                Ogrenci ogrenci = ogrenciler[i];
                if (int.IsEvenInteger(i))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
              
                Console.WriteLine("-"+"Öğrenci Numarası: {0}",ogrenci.OgrenciNo);
                Console.WriteLine("-" +"Öğrenci Adı ve Soyadı: {0} {1} ", ogrenci.Ad,ogrenci.Soyad);
                Console.WriteLine("-" +"Öğrenci Yaşı: {0}",ogrenci.DogumYili + " Yaşı: " + (DateTime.Today.Year - ogrenci.DogumYili));
                Console.WriteLine("-" +"Öğrenci Cinsiyeti: {0}",ogrenci.Cinsiyet);
                Console.WriteLine("-" +"Öğrenci Çalışıyor mu?:{0} ",ogrenci.CalisiyorMu ? "Evet" : "Hayır");


                Console.WriteLine("");
                Console.WriteLine("-------------------------------");

            }
            Console.ForegroundColor= ConsoleColor.White; 

        
            Console.WriteLine("");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Öğrenci No ile arama yapmak için 'F3'e basın.");
            Console.WriteLine("Öğrenci No ile arama yapmak için 'F4'e basın.");
            Console.ReadKey();
            Search();

        }

        static  void Search()
        {

            ConsoleKey basilanKarakter = Console.ReadKey().Key;


            switch (basilanKarakter)
            {

                case ConsoleKey.F3:
                   StudentSearchId();
                    break;

                case ConsoleKey.F4:
                    StudentSearchNameSurname();
                    break;

                case ConsoleKey.F5:
                    Clr();
                    MenuyuGoster();
                    break;

                    case ConsoleKey.F6:

                    break;


            }
        }

        public static void StudentSearchId()
        {
            Console.WriteLine("Öğrenci no ile  aramak için  F3'e bastın.");

                Console.Write("Öğrenci numarasını girin:");

                int ogrenciNo = Convert.ToInt32(Console.ReadLine());
                Ogrenci SearchResult = ogrenciler.FirstOrDefault(x => x.OgrenciNo == ogrenciNo);

                    Console.WriteLine("");
                    Console.WriteLine("---------------------");

            if (SearchResult != null)
                {
                     Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine("Öğrenci Adı ve Soyadı: {0} {1}", SearchResult.Ad, SearchResult.Soyad);
                    Console.WriteLine("Öğrenci Numarası: {0}", SearchResult.OgrenciNo);
                    Console.WriteLine("Öğrenci Yaşı: {0}", SearchResult.DogumYili);
                    Console.WriteLine("Öğrenci Cinsiyeti: {0}", SearchResult.Cinsiyet);
                    Console.WriteLine("Öğrenci Çalışıyor mu: {0}", SearchResult.CalisiyorMu ? "Evet" : "Hayır");

                Console.WriteLine("");
                Console.WriteLine("---------------------");
            }
                else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Aradığın öğrenci bulunmuyor.");
                }

            Console.ForegroundColor = ConsoleColor.White;



        }

        public static void StudentSearchNameSurname()
        {
            Console.WriteLine("Öğrenci adı ile  aramak için  F4'e bastın.");

            Console.Write("Öğrenci Adını girin:");

            string ogrenciAd = Console.ReadLine();
            Ogrenci SearchResult = ogrenciler.Find(x => x.Ad == ogrenciAd);

            Console.WriteLine("");
            Console.WriteLine("---------------------");

            if (SearchResult != null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("Öğrenci Adı ve Soyadı: {0} {1}", SearchResult.Ad, SearchResult.Soyad);
                Console.WriteLine("Öğrenci Numarası: {0}", SearchResult.OgrenciNo);
                Console.WriteLine("Öğrenci Yaşı: {0}", SearchResult.DogumYili);
                Console.WriteLine("Öğrenci Cinsiyeti: {0}", SearchResult.Cinsiyet);
                Console.WriteLine("Öğrenci Çalışıyor mu: {0}", SearchResult.CalisiyorMu ? "Evet" : "Hayır");

                Console.WriteLine("");
                Console.WriteLine("---------------------");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Aradığın öğrenci bulunmuyor.");
            }

            Console.ForegroundColor = ConsoleColor.White;


        }
        public static void FindName()
           
        {

        }
        public static void Clr()
        {
            Console.Clear();
        }

       
    }
}
