namespace ConsoleExercise
{
    internal class Program
    {

        public class Ogrenci
        {

            //
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
                Ad = "Ömer",
                Soyad = "Köse",
                DogumYili=1999,
                CalisiyorMu=true,

                
            });
        }
        static void OgrenciEkleme()
        {
            Console.Clear();
            Console.WriteLine("----Öğrenci Ekleme Alanı----");

            Ogrenci ogrenci = new Ogrenci();

            Console.Write("Adınız: ");
            ogrenci.Ad= Console.ReadLine();
            Console.Write("Soyadınız: ");
            ogrenci.Soyad= Console.ReadLine();
            Console.Write("Doğum Yılınız: ");
            ogrenci.DogumYili = Convert.ToInt32(Console.ReadLine());
            Console.Write("Çalışıyor musunuz? Evet/Hayır ");
            ogrenci.CalisiyorMu = Console.ReadLine(); // tıkandım

            
           

            
            

            
            ogrenci.Cinsiyet = Console.ReadLine();
            Console.Write("Telefon Numaranız: ");
            ogrenci.TelefonNumarasi= Console.ReadLine();

            ogrenciler.Add(ogrenci);

            MenuyuGoster();
        }
        static void MenuyuGoster(bool selamlamaMesajGoster = false)
        {
            Console.Clear();

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
                    return;
                   

               
            }


        }
        static void OgrencileriListele()
        {
            Console.Clear();

            foreach (var ogrenci in ogrenciler)
            {
                Console.WriteLine("Öğrenci Adı: " + ogrenci.Ad);
                Console.WriteLine("Öğrenci Soyadı: " + ogrenci.Soyad);
                Console.WriteLine("Öğrenci Yaşı: "+ogrenci.DogumYili);
                Console.WriteLine("Çalışma Durumu" + ogrenci.CalisiyorMu);
                Console.WriteLine("Cinsiyet: " + ogrenci.Cinsiyet);
                Console.WriteLine("Telefon Numaranız: "+ ogrenci.TelefonNumarasi);
                
                // daha güzel yazdırabilirim. aklımda bulunsun


                Console.WriteLine("");
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("");
            Console.WriteLine("-------------------------------");

            Console.ReadKey();

            MenuyuGoster();

        }

       
    }
}