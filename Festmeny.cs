using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AukcioProjekt
{
	class Festmeny
	{
		string cim;
		string festo;
		string stilus;
		int licitekSzama;
		int legmagasabbLicit;
		DateTime legutolsoLicitIdeje;
		bool elkelt;

		public Festmeny(string cim, string festo, string stilus)
		{
			this.cim = cim;
			this.festo = festo;
			this.stilus = stilus;
			licitekSzama = 0;
			legmagasabbLicit = 0;
			elkelt = false;
		}

		public string Cim { get => this.cim; }
		public string Festo { get => this.festo; }
		public string Stilus{ get => this.stilus; }
		public int LicitekSzama { get => this.licitekSzama; }
		public int LegmagasabbLicit{ get => this.legmagasabbLicit; }
		public DateTime LegutolsoLicitIdeje { get => this.legutolsoLicitIdeje; }
		public bool Elkelt { get => this.elkelt; set => this.elkelt = value; } 
		public void Licit()
		{
			if (elkelt)
			{
				Console.WriteLine("Az adott festmény már elkelt!");
			} else
			{
				if (licitekSzama == 0)
				{
					licitekSzama += 1;
					legutolsoLicitIdeje = DateTime.Now;
					legmagasabbLicit = 100;
				} else
				{
					Licit(10);
				}
			} 
		}
		public void Licit(int mertek)
		{
			if (mertek > 100 || 10 > mertek)
			{
				Console.WriteLine("Hibás mérték lett megadva!");
				return;
			}
			if (elkelt)
			{
				Console.WriteLine("Az adott festmény már elkelt!");
			}
			else
			{
				if (licitekSzama == 0)
				{
					Licit();
				} else
				{
					legmagasabbLicit = (int)(legmagasabbLicit * (double)((100 + mertek) / 100.0));
					licitekSzama += 1;
					legutolsoLicitIdeje = DateTime.Now;
				}
			}
		}
		override public string ToString()
		{
			if (elkelt)
			{
				return ($"{festo}: {cim}({stilus})\nElkelt\n{legmagasabbLicit}$ - {legutolsoLicitIdeje}(összesen: {licitekSzama}db)");
			} else
			{
				return ($"{festo}: {cim}({stilus})\n{legmagasabbLicit}$ - {legutolsoLicitIdeje}(összesen: {licitekSzama}db)");
			}
		}
	}
}
