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

            Console.WriteLine();

            //3.feladat
            OsszAtlag(karakterek);

            //4. feladat
            Legerosebb(karakterek);

            Console.WriteLine();

            //5. feladat
            Console.WriteLine($"Az első karakter ({karakterek[0].Nev}) ereje ({karakterek[0].Ero}) nagyobb-e, mint 50: ");
            Console.WriteLine(Erosebbe(karakterek[0], 50));

			Console.WriteLine();

            //6.feladat
            Console.WriteLine($"Karakterek akiknek a szintje nagyobb, mint 7");
            foreach (Karakter kar in Nagyobbszintu(karakterek,7))
            {
                Console.WriteLine($"{kar.Nev}: {kar.Szint}");
            }

			//7.feladat
			csvIras(karakterek);
            Console.WriteLine("CSV lett a debug mappában");

			Console.WriteLine();

			//8.feladat
			Legjobb3(karakterek);

			Console.WriteLine();

			//9. feladat
			KarakterRangsorolas(karakterek);

			Console.WriteLine();

			//10.feladat
			Csata(karakterek[26], karakterek[0]);
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

		//6.feladat
		static List<Karakter> Nagyobbszintu(List<Karakter> karakterek, int szint)
		{
			List<Karakter> okKar = [];

            foreach (Karakter kar in karakterek)
            {
                if (kar.Szint > szint)
				{
					okKar.Add(kar);
				}
            }

            return okKar;
		}

		//7. feladat
		static void csvIras(List<Karakter> karakterek)
		{
			string formatted = "Név;Szint;Életerő;Erő\n";
            foreach (Karakter kar in karakterek)
            {
				formatted += kar.Nev + ";" + kar.Szint + ";" + kar.EletEro + ";" + kar.Ero + "\n";
            }

            File.WriteAllText("karakterek.csv", formatted);
        }

		//8.feladat
		static void Legjobb3(List<Karakter> karakterek)
		{
			List<int[]> szintMegEro = [];

            foreach (Karakter kar in karakterek)
            {
				szintMegEro.Add([kar.Szint + kar.Ero, karakterek.IndexOf(kar)]);
            }

			List<int[]> rendezett = szintMegEro.OrderBy(a => a[0]).ToList();
			rendezett.Reverse();

            Console.WriteLine($"3 Legerősebb karakter (szint+erő szerint):\n");
            for (int i = 0; i < 3; i++)
            {
				Console.WriteLine($"Név: {karakterek[rendezett[i][1]].Nev}, szintje: {karakterek[rendezett[i][1]].Szint}, ereje: {karakterek[rendezett[i][1]].Ero}, szint+erő: {rendezett[i][0]}");
            }
        }

		//9.feladat
		static void KarakterRangsorolas(List<Karakter> karakterek)
		{
			List<int[]> eletEroMegEro = [];

			foreach (Karakter kar in karakterek)
			{
				eletEroMegEro.Add([kar.EletEro + kar.Ero, karakterek.IndexOf(kar)]);
			}

			List<int[]> rendezett = eletEroMegEro.OrderBy(a => a[0]).ToList();
			rendezett.Reverse();

			Console.WriteLine($"Ranglista(életerő+erő szerint):\n");
			for (int i = 0; i < rendezett.Count; i++)
			{
				Console.WriteLine($"Név: {karakterek[rendezett[i][1]].Nev}, életereje: {karakterek[rendezett[i][1]].EletEro}, ereje: {karakterek[rendezett[i][1]].Ero}, életerő+erő: {rendezett[i][0]}");
			}
		}

		//10.feladat
		static void Csata(Karakter kar1, Karakter kar2)
		{
			Console.WriteLine($"{kar1.Nev} és {kar2.Nev} harcolnak");
			Console.WriteLine($"{kar1.Nev} statjai: {kar1}");
			Console.WriteLine("==============================\n\t\tVS\n==============================\n");
			Console.WriteLine($"{kar2.Nev} statjai: {kar2}");

			if(kar1.Szint + kar1.Ero > kar2.Szint + kar2.Ero)
			{
				Console.WriteLine($"\nA nyertes: {kar1.Nev}!");
			}
			else if (kar1.Szint + kar1.Ero < kar2.Szint + kar2.Ero)
			{
				Console.WriteLine($"\nA nyertes: {kar2.Nev}!");
			}
			else
			{
				Console.WriteLine("Döntetlen!");
			}
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
