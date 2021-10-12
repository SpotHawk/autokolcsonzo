
using System;

namespace Autokolcsonzo
{
	class Program
	{
		public static void Main(string[] args)
		{

			double egyenleg = 500000.0;

			double uzemanyagAr = 437.0; // Ft/liter

			KolcsonozhetoAuto[] flotta = new KolcsonozhetoAuto[10];

			KolcsonozhetoAuto elsoAuto = new KolcsonozhetoAuto("ABC-123", "Suzuki", 2020, 4, 40, 5.7, 'A');

			KolcsonozhetoAuto kettoAuto = new KolcsonozhetoAuto("BCD-234", "BMW", 2018, 2, 30, 3.7, 'A');

			KolcsonozhetoAuto haromAuto = new KolcsonozhetoAuto("CDE-345", "Toyota", 2021, 5, 36, 4.1, 'A');

			flotta[0] = elsoAuto;
			flotta[1] = kettoAuto;
			flotta[2] = haromAuto;
			flotta[3] = randomUjAuto(3);
			flotta[4] = randomUjAuto(4);
			flotta[5] = randomHasznaltAuto(5);
			flotta[6] = randomHasznaltAuto(6);

			for (int i = 0; i <= 6; i++)
			{
				Console.Write(flotta[i].getRendszam() + " ; ");
				Console.Write(flotta[i].getGyarto() + " ; ");
				Console.Write(flotta[i].getGyartasEve() + " ; ");
				Console.Write(flotta[i].getUtasSzam() + " ; ");
				Console.Write(flotta[i].getuzemanyagMennyiseg() + " ; ");
				Console.Write(flotta[i].getFogyasztas() + " ; ");
				Console.Write(flotta[i].getMegtettKm() + " ; ");
				Console.Write(flotta[i].getBerelheto() + " ; ");
				Console.WriteLine(flotta[i].getKategoria());
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}

		public static KolcsonozhetoAuto randomUjAuto(int seed)
		{

			Random gen = new Random(seed);

			string[] gyartok = {
				"Maserati",
				"Jeep",
				"Ferrari",
				"Suzuki",
				"Volvo",
				"Lada"
			};

			char[] abc = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
							'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W',
							'X', 'Y', 'Z'};

			string abcS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			string rszam = "";

			for (int i = 0; i < 3; i++)
			{

				rszam += abcS[gen.Next(0, abcS.Length)];
			}

			rszam = rszam + "-";

			for (int i = 0; i < 3; i++)
			{

				rszam += gen.Next(0, 10).ToString();
			}
			string marka = gyartok[gen.Next(0, gyartok.Length)];
			int ev = gen.Next(1995, 2022);
			int utasok = gen.Next(2, 10);
			int tartaly = gen.Next(20, 71);
			double lpkm = 5.5 + (11 * gen.NextDouble());
			char kat = abc[gen.Next(0, 3)];

			KolcsonozhetoAuto auto = new KolcsonozhetoAuto(rszam, marka, ev, utasok, tartaly, lpkm, kat);
			return auto;
		}

		public static KolcsonozhetoAuto randomHasznaltAuto(int seed)
        {
			KolcsonozhetoAuto auto = randomUjAuto(seed);
			
			if(auto.getGyartasEve()==2021)
            {
				auto.setGyartasiIdo(auto.getGyartasEve() - 4);
            }
			auto.setMegtettKm(362000);
			return auto;
        }

		/*public static KolcsonozhetoAuto autoBekeres()
        {
			KolcsonozhetoAuto auto = new KolcsonozhetoAuto();
			string rszam = "";
			string gyarto = "";
			int gyartev = 0;
			int utasokszama = 0;
			int tartalym = 0;
			double lpkm = 0.0;
			char kat;
			Console.WriteLine("Adja meg az autó rendszámát('-'-el elválasztva)");
			rszam = Console.ReadLine();
        }*/
	}
}