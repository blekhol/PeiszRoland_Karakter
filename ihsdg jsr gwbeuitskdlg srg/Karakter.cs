﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ihsdg_jsr_gwbeuitskdlg_srg
{
	internal class Karakter
	{
		private string nev;
		private int eletEro;
		private int ero;
		private int szint;

		public Karakter(string nev, int szint, int eletEro, int ero)
		{
			Nev = nev;
			EletEro = eletEro;
			Ero = ero;
			Szint = szint;
		}

		public string Nev { get => nev; set => nev = value; }
		public int EletEro { get => eletEro; set => eletEro = value; }
		public int Ero { get => ero; set => ero = value; }
		public int Szint { get => szint; set => szint = value; }

		public override string ToString()
		{
			return $"Név: {this.nev}\nÉleterő: {this.eletEro}\nErő: {this.ero}\nSzint: {this.szint}";
		}
	}
}
