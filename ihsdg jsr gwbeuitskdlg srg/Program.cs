using System.ComponentModel.DataAnnotations;

namespace ihsdg_jsr_gwbeuitskdlg_srg
{
	internal class Program
	{


		static void Main(string[] args)
		{
			List<Karakter> karakterek = [];

			Beolvasas("karakterek.txt", karakterek);

			//2. feladat
			(string, int, int) a = LegmagasabbEletEro(karakterek);
            Console.WriteLine($"Legmagasabb életerővel rendelkező karakter neve: {a.Item1}, szintje: {a.Item2}, ereje: {a.Item3}");

			//3.feladat
			OsszAtlag(karakterek);

            //4. feladat
            Legerosebb(karakterek);

            //5. feladat
            Console.WriteLine($"Az első karakter ({karakterek[0].Nev}) ereje ({karakterek[0].Ero}) nagyobb-e, mint 50: ");
            Console.WriteLine(Erosebbe(karakterek[0], 50));
        }

		static (string, int, int) LegmagasabbEletEro(List<Karakter> karakterek)
		{
			Karakter returnkar = karakterek[0];

			foreach (Karakter kar in karakterek)
			{
				if (kar.EletEro > returnkar.EletEro)
				{
					returnkar = kar;
				}
			}

			return (returnkar.Nev, returnkar.Szint, returnkar.Ero);
		}

		static void OsszAtlag(List<Karakter> karakterek)
		{
			int atlag = 0;
			foreach (Karakter kar in karakterek)
			{
				atlag += kar.Szint;
			}

			Console.WriteLine($"Átlag szint: {atlag / karakterek.Count}");
		}

		static void Legerosebb(List<Karakter> karakterek)
		{
			List<Karakter> rendezett = karakterek.OrderBy(k => k.Ero).ToList();
			rendezett.Reverse();

			Console.WriteLine("\nLegerősebb sorrendben");
			for (int i = 0; i < rendezett.Count; i++)
			{
				Console.WriteLine($"{i+1}. {rendezett[i]}\n");
			}
		}

		static bool Erosebbe(Karakter kar, int ero)
		{
			return (kar.Ero > ero);
		}



		static void Beolvasas(string file, List<Karakter> karakterek)
		{
			StreamReader sr = new(file);
			sr.ReadLine();

            foreach (string line in sr.ReadToEnd().Split("\n"))
            {
				string[] adatok = line.Split(';');
				karakterek.Add(new Karakter(adatok[0], Convert.ToInt32(adatok[1]), Convert.ToInt32(adatok[2]), Convert.ToInt32(adatok[3])));
            }
        }
	}
}
