using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AukcioProjekt
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Festmeny> festmenyek = new List<Festmeny> () {
				new Festmeny ("Mona Lisa","Leonardo Da Vinci","Reneszánsz"),
				new Festmeny ("Salvator Mundi","Leonardo Da Vinci","Reneszánsz")
			};
			Console.Write("Kérem adja meg hány festményt szeretne hozzáadni a listához: ");
			int uj_festmenyek = int.Parse(Console.ReadLine()??"0"); 
			for (int i = 0; uj_festmenyek > i; i++)
			{
				Console.Write("Kérem adja meg a festmény cimét: ");
				string festmeny_cim = Console.ReadLine();
				Console.Write("Kérem adja meg a festőt: ");
				string festmeny_festoje = Console.ReadLine();
				Console.Write("Kérem adja meg a festmény stilusát: ");
				string festmeny_stilusa = Console.ReadLine();
				festmenyek.Add(new Festmeny(festmeny_cim, festmeny_festoje, festmeny_stilusa));
			}
			Random rnd = new Random();
			for (int i = 0; 20 > i; i++)
			{
				festmenyek[rnd.Next(0, festmenyek.Count)].Licit();
			}
			while(true)
			{
				Console.Write($"Kérem adja meg a kivánt festmény sorszámát (1-{festmenyek.Count}) - kilépéshez (0): ");
				int sorszam = int.Parse(Console.ReadLine())-1;
				if (sorszam == -1)
				{
					break;
				}
				else if (sorszam > festmenyek.Count)
				{
					Console.Write("Ön nem egy létező sorszámot adott meg.");
					sorszam = int.Parse(Console.ReadLine()) - 1;
				}
				Console.Write("Kérem adja meg milyen mértékkel szeretne licitálni a festményre %-ban: ");
				int mertek;
				string tempmertek = Console.ReadLine();
				try
				{
					if (tempmertek == "")
					{
						festmenyek[sorszam].Licit();
						break;
					}
					mertek = int.Parse(tempmertek);
				}
				catch
				{
					Console.WriteLine("Ön nem számot adott meg!");
					break;
				}

				if (festmenyek[sorszam].Elkelt == true)
				{
					Console.WriteLine("Sajnos az ön által választott festmény már elkelt.");
					sorszam = int.Parse(Console.ReadLine()) - 1;
				}
				if (DateTime.Now > festmenyek[sorszam].LegutolsoLicitIdeje.AddMinutes(2) )
				{
					festmenyek[sorszam].Elkelt = true;
					Console.WriteLine("A festmény elkelt!");
					sorszam = int.Parse(Console.ReadLine()) - 1;
				}
			}
			foreach (Festmeny festmeny in festmenyek)
			{
				if (festmeny.LegmagasabbLicit > 0)
				{
					festmeny.Elkelt = true;
				}
			}
			foreach (Festmeny festmeny in festmenyek)
			{
				Console.WriteLine(festmeny);
			}

			Festmeny temp_festmeny = festmenyek[0];
			foreach (Festmeny festmeny in festmenyek)
			{
				if (festmeny.LegmagasabbLicit > temp_festmeny.LegmagasabbLicit)
				{
					temp_festmeny = festmeny;
				}
			}
			Console.WriteLine($"Legnagyobb árral rendelkező festmény:\n{temp_festmeny}");
			bool valami = false;
			foreach (Festmeny festmeny in festmenyek)
			{
				if (festmeny.LicitekSzama > 10)
				{
					Console.WriteLine("Volt olyan festmény amire 10-nél többször licitáltak.");
					valami = true;
					break;
				}
			}
			if (valami == false)
			{
				Console.WriteLine("Nem volt olyan festmény amire 10-nél többször licitáltak.");
			}

			int temp = 0;
			foreach (Festmeny festmeny in festmenyek)
			{
				if (festmeny.Elkelt == true)
				{
					temp++;
				}
			}
			Console.WriteLine($"{festmenyek.Count - temp}db festmény volt ami nem kelt el!");

			Console.WriteLine("\nFestmények listája rendezve a licitek nagysága alapján:");
			List<Festmeny> csokkenoFestmenyek = new List<Festmeny>(festmenyek.OrderByDescending(festmeny => festmeny.LegmagasabbLicit));
			foreach (Festmeny festmeny in csokkenoFestmenyek)
			{
				Console.WriteLine(festmeny);
			}


		}
	}
}
