
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
			flotta[7]= autoFelvetel();
			flotta[8] = autoFelvetel();
			flotta[9] = autoFelvetel();

            for (int i = 0; i < 10; i++)
            {
				flotta[i].kategoriaBeallitas();
            }

			for (int i = 0; i <= 9; i++)
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

		public static KolcsonozhetoAuto autoFelvetel()
        {
			string rszam = "";
			string gyarto = "";
			int gyartev = 0;
			int utasokszama = 0;
			int tartalym = 0;
			double lpkm = 0.0;
			char kat;
			bool rsz=false, gyart = false, ev = false, utas = false, tartaly = false, fogy = false, cat = false;
			Console.WriteLine("Autó felvétel");
			do
			{
				Console.WriteLine("Adja meg az autó rendszámát(ABC-123):");
				rszam = Console.ReadLine().ToUpper();
				if(rszam.Length<7 || rszam.Length>7)
                {
					rsz = false;
					Console.WriteLine("Helytelen rendszám!");
                }
				else if((rszam[0] >='A' &&  rszam[0] <='Z') && (rszam[1] >= 'A' && rszam[1] <= 'Z') && (rszam[2] >= 'A' && rszam[2] <= 'Z') && rszam[3]=='-' && (rszam[4] >= '0' && rszam[4] <= '9') && (rszam[5] >= '0' && rszam[5] <= '9') && (rszam[6] >= '0' && rszam[6] <= '9'))
                {
					rsz = true;
					Console.WriteLine("Rendszám elfogadva.");
                }
				else
                {
					rsz = false;
					Console.WriteLine("Helytelen rendszám!");
                }
			}
			while (!rsz);
			do
			{
				Console.WriteLine("Adja meg az autó gyártóját:");
				gyarto = Console.ReadLine();
				if(gyarto.Length!=0 && gyarto.Length>=2)
                {
					gyart = true;
					Console.WriteLine("Gyártó elfogadva.");
                }
				else
                {
					gyart = false;
					Console.WriteLine("Helytelen gyártó!");
                }
			}
			while (!gyart);
			do
			{
				Console.WriteLine("Adja meg az autó gyártási évét:");
				gyartev =Convert.ToInt32(Console.ReadLine());
				int mostev = DateTime.Now.Year;
				if (gyartev>=1908 && gyartev<=mostev)
                {
					ev = true;
					Console.WriteLine("Gyártási év elfogadva.");
                }
				else
                {
					ev = false;
					Console.WriteLine("Nem megfelelő gyártási év!");
                }
			}
			while (!ev);
			do
			{
				Console.WriteLine("Adja meg a férőhelyek számát:");
				utasokszama = Convert.ToInt32(Console.ReadLine());
				if(utasokszama>=1 && utasokszama<=9)
                {
					utas = true;
					Console.WriteLine("Lehetséges utasok száma elfogadva.");
                }
				else
                {
					utas = false;
					Console.WriteLine("Férőhelyek száma nem megfelelő!");
                }
			}
			while (!utas);
			do
			{
				Console.WriteLine("Adja meg az autó tartály méretét:");
				tartalym = Convert.ToInt32(Console.ReadLine());
				if(tartalym>=20 && tartalym<=100)
                {
					tartaly = true;
					Console.WriteLine("Tartály méret elfogadva.");
                }
				else
                {
					tartaly = false;
					Console.WriteLine("Tartály méret nem megfelelő!");
                }
			}
			while (!tartaly);
			do
			{
				Console.WriteLine("Adja meg az autó fogyasztását(l/100km):");
				lpkm = Double.Parse(Console.ReadLine());
				if (lpkm >= 4.0 && lpkm <= 60.0)
				{
					fogy = true;
					Console.WriteLine("Fogyasztás elfogadva.");
				}
				else
				{
					fogy = false;
					Console.WriteLine("Fogyasztás nem megfelelő!");
				}
			}
			while (!fogy);
			//kikommenteltem h teszteljem a kategoriabeallitas metodust
			/*do 
			{
				Console.WriteLine("Adja meg az autó kategoriáját(A: 1-3 év; B: 3-10 év; C: 10 év és felett):");
				kat = Convert.ToChar(Console.ReadLine().ToUpper());
				int mostev = DateTime.Now.Year;
				switch (kat)
				{
					case 'A':
						if ((mostev-gyartev) >= 0 && (mostev - gyartev) < 3)
						{
							cat = true;
							Console.WriteLine("Megfelelő kategória.");
						}
						else
						{
							cat = false;
							Console.WriteLine("Nem megfelelő kategória beosztás!");
						}
						break;
					case 'B':
						if ((mostev - gyartev) >= 3 && (mostev - gyartev) < 10)
						{
							cat = true;
							Console.WriteLine("Megfelelő kategória.");
						}
						else
						{
							cat = false;
							Console.WriteLine("Nem megfelelő kategória beosztás!");
						}
						break;
					case 'C':
						if ((mostev - gyartev) >= 10)
						{
							cat = true;
							Console.WriteLine("Megfelelő kategória.");
						}
						else
						{
							cat = false;
							Console.WriteLine("Nem megfelelő kategória beosztás!");
						}
						break;
					default:
						Console.WriteLine("Nem megfelelő kategória!");
						cat = false;
						break;
				}
			}
			while (!cat);*/
			Console.WriteLine("Adja meg az autó kategóriáját:");
			kat = char.Parse((Console.ReadLine().ToUpper()));
			Console.WriteLine("Autó felvétel megtörtént!");
			Console.WriteLine();
			gyarto=char.ToUpper(gyarto[0]) + gyarto.Substring(1);
			KolcsonozhetoAuto auto = new KolcsonozhetoAuto(rszam,gyarto,gyartev,utasokszama,tartalym,lpkm,kat);
			return auto;
        }
	}
}