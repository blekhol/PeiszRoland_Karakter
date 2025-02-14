using System.ComponentModel.DataAnnotations;

namespace ihsdg_jsr_gwbeuitskdlg_srg
{
	internal class Program
	{


		static void Main(string[] args)
		{
			List<Karakter> karakterek = [];

			Beolvasas("karakterek.txt", karakterek);

			Legerosebb(karakterek);
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
				Console.WriteLine($"{i}. {rendezett[i]}\n");
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
