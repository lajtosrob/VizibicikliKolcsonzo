using System.Linq.Expressions;

namespace VizibicikliKolcsonzo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Kolcsonzes> kolcsonzesek = new List<Kolcsonzes>();

            //4.

            string[] sorok = File.ReadAllLines("DATAS\\kolcsonzesek.txt");
            for (int i = 1; i < sorok.Length; i++)
            {
                string[] adatok = sorok[i].Split(';');

                string nev = adatok[0];
                string jazon = adatok[1];
                int eora = int.Parse(adatok[2]);
                int eperc = int.Parse(adatok[3]);
                int vora = int.Parse(adatok[4]);
                int vperc = int.Parse(adatok[5]);

                Kolcsonzes kolcsonzes = new Kolcsonzes(nev, jazon, eora, eperc, vora, vperc);
                kolcsonzesek.Add(kolcsonzes);
            }

            /* foreach (var s in sorok)
            {
                
                var mezok = s.Split(';');
                kolcsonzesek.Add(new Kolcsonzes(mezok[0], mezok[1], int.Parse(mezok[2]), int.Parse(mezok[3]), int.Parse(mezok[4]), int.Parse(mezok[5])));
            } */

            Console.WriteLine("Beolvasás készen van.");

            //5.

            Console.WriteLine("5. feladat: Napi köcsönzések száma: " + kolcsonzesek.Count());

            //6.

            Console.Write("6. feladat: Kérek egy nevet! ");
            string megadottNev = Console.ReadLine();

            if (kolcsonzesek.All(x => x.Nev != megadottNev))
            {
                Console.WriteLine("Nincs ilyen nevű kölcsönző!");
            }
            else
            {
                foreach (var item in kolcsonzesek)
                {
                    if (item.Nev == megadottNev)
                    {
                        Console.WriteLine($"{megadottNev} kölcsönzései: {item.Eora}:{item.Eperc}:{item.Vora}:{item.Vperc}");
                    }
                }
            }

            //7.

            Console.Write("Adjon meg egy időpontot óra:perc alakban: ");
            string idopont = Console.ReadLine();

            string[] idopontList = idopont.Split(':');
            int ora = int.Parse(idopontList[0]);
            int perc = int.Parse(idopontList[1]);

            Console.WriteLine("A vizen levő járművek: ");
            foreach (var kolcsonzes in kolcsonzesek) 
            {
                if (ora > kolcsonzes.Eora || ora == kolcsonzes.Eora && perc >= kolcsonzes.Eperc)
                {
                    if (ora < kolcsonzes.Vora || ora == kolcsonzes.Vora && perc <= kolcsonzes.Vperc)
                    {
                        Console.WriteLine($"{kolcsonzes.Eora}:{kolcsonzes.Eperc}-{kolcsonzes.Vora}:{kolcsonzes.Vperc}");
                    }
                }
            }

            //8.

            int kolcsonzesiIdo = 0;
            int sumKolcsonzesiIdo = 0;

            foreach (var item in kolcsonzesek)
            {
                if (item.Vperc - item.Eperc  <= 30 && item.Vperc - item.Eperc > 0)
                {
                    kolcsonzesiIdo += 30;
                }
                else if (item.Vperc - item.Eperc <= 59 && item.Vperc - item.Eperc > 30)
                {
                    kolcsonzesiIdo += 60;
                }
                else if (item.Vperc - item.Eperc <= -30 && item.Vperc - item.Eperc >= -59)
                {
                    kolcsonzesiIdo -= 30;
                }

                kolcsonzesiIdo += (item.Vora - item.Eora) * 60;
                //Console.WriteLine($"{item.Eora}:{item.Eperc}-{item.Vora}:{item.Vperc} = {kolcsonzesiIdo}");
                sumKolcsonzesiIdo += kolcsonzesiIdo;
                kolcsonzesiIdo = 0;

            }

            Console.WriteLine("8. feladat: A napi bevétel: " + sumKolcsonzesiIdo / 30 * 2400 + "Ft");

            //9.

            Console.WriteLine("9.feladat: F.txt");
            string sor = "";
            StreamWriter sr = new StreamWriter("F.txt");
            foreach (var kolcsonzes in kolcsonzesek)
            {
                if (kolcsonzes.Jazon == "F")
                {
                    sor = $"{kolcsonzes.Nev};{kolcsonzes.Jazon};{kolcsonzes.Eora};{kolcsonzes.Eperc};{kolcsonzes.Vora};{kolcsonzes.Vperc}";
                    sr.WriteLine(sor);
                }
            }
            sr.Close();
            Console.WriteLine("A fájlbaírás sikeresen megtörtént!");

            //10.

            var statisztika = kolcsonzesek
        .GroupBy(k => k.Jazon)
        .OrderBy(g => g.Key)
        .Select(g => new { JarmuAzonosito = g.Key, KolcsonzesekSzama = g.Count() });

            Console.WriteLine("10. feladat: Statisztika");

            foreach (var item in statisztika)
            {
                Console.WriteLine($"\t{item.JarmuAzonosito} - {item.KolcsonzesekSzama}");
            }

        }
    }
}