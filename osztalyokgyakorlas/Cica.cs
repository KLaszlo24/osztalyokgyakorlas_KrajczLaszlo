using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osztalyokgyakorlas
{
	internal class Cica
	{
		//mindegyik private lesz, nem kell kiírni mindig
		string nev;
		int kor;
		int suly;
		string fajta;
		string szin;
		int rendetlensegSzint;
		int fogasztas;
		bool ehes;
		string nem;
		int eletero;

		List<string> jatekok = ["futás", "labdázás", "biciklizés", "hullahopp", "romlott kaja"];
		Random random = new Random();

		public int Kor { get => kor; set => kor = value; }
		public string Nev { get => nev; set => nev = value; }
		public int Suly { get => suly; set => suly = value; }
		public string Fajta { get => fajta; set => fajta = value; }
		public string Szin { get => szin; set => szin = value; }
		public int RendetlensegSzint { get => rendetlensegSzint; set => rendetlensegSzint = value; }
		public int Fogasztas { get => fogasztas; set => fogasztas = value; }
		public bool Ehes { get => ehes; set => ehes = value; }
		public string Nem { get => nem; set => nem = value; }
		public int Eletero { get => eletero; set => eletero = value; }

        public Cica(string nev, int kor, int suly, string fajta, string szin, int rendetlensegSzint, int fogasztas, string nem)
		{
			this.nev = nev;
			this.kor = kor;
			this.suly = suly;
			this.fajta = fajta;
			this.szin = szin;
			this.rendetlensegSzint = rendetlensegSzint;
			this.fogasztas = fogasztas;
			this.nem = nem;
			ehes = true;
			eletero = 10;
		}

		public void KulonTenyezok()
		{
			if (szin == "narancs")
			{
				rendetlensegSzint += 40;
                Console.WriteLine($"Ez egy túlbuzgó macska mivel narancs színű, ezért a szintje: {rendetlensegSzint}");
			}
			if (nem == "hím")
			{
                Console.WriteLine($"Ez egy hím macska, többet kell ennie:");
				Eves(2);
			}
		}

        public void EletKor()
        {
            if (kor == 0)
            {
                Console.WriteLine("Nincs nulla éves macska");
            }
            else if (kor >= 1 && kor <= 2)
            {
				eletero -= 2;
                rendetlensegSzint += 10;
                Console.WriteLine($"Nagyon hiperaktív a cica, szintje: {rendetlensegSzint} és makk egészséges, maradék élete: {eletero} ");
            }
            else if (kor >= 3 && kor <= 4)
            {
				eletero -= 4;
                rendetlensegSzint -= 10;
                Console.WriteLine($"Hiperaktív a cica, szintje: {rendetlensegSzint} és van még élete bőven, maradék élete: {eletero}");
            }
            else if (kor >= 5 && kor <= 6)
            {
				eletero -=6;
				rendetlensegSzint -= 20;
                Console.WriteLine($"Idősödő a cica, szintje: {rendetlensegSzint} és lassan meg fog halni, maradék élete: {eletero}");
            }
            else if (kor >= 7 && kor <= 9)
            {
				eletero -= 9;
                rendetlensegSzint -= 30;
                Console.WriteLine($"Nagyon öreg a cica, szintje: {rendetlensegSzint} és hamarosan meg fog halni, maradék élete: {eletero}");
            }
        }

        public void Eves(double kajaSuly)
		{
			Random random = new Random();
			int esely = random.Next(101);

			ehes = false;

			if (esely <= 4 || eletero<=2)
			{
				szin = "zöld";
				suly -= (int)(suly * (esely / 100.0));
				rendetlensegSzint /=2;
                Console.WriteLine($"A cica színe megváltozott: {szin}");
            }
			else
			{
				suly += (int)Math.Ceiling(fogasztas + (kajaSuly/1000));
            }
				
			Console.WriteLine($"a cica evés utáni rendetlenségi szintje: {rendetlensegSzint}, színe: {szin} lesz és súlya: {suly} lesz ");
            
        }

		public void Alvas()
		{

			if (szin == "zöld")
			{
				szin = "Eredeti";
			}
            Console.WriteLine($"A cica alvás utáni színe: {szin}");
        }

		public void Ebredes()
		{
			if (eletero <= 2)
			{
				rendetlensegSzint +=1 ;
			}
            if (eletero <= 4 && eletero>=3)
            {
                rendetlensegSzint += 2;
            }
            if (eletero >=8)
            {
				rendetlensegSzint = 100; ;
            }
            ehes =true;
            Console.WriteLine($"Felébredt a cica, nagyon éhes és rendetlenségi szintje: {rendetlensegSzint}");
        }

        public void Jatek()
        {
            List<string> jatek = new List<string>();

            if (rendetlensegSzint == 0)
            {
                Alvas();
            }
            else if (eletero < 4)
            {
                Console.WriteLine("Sajnos a cica nem tud játszani. Túl öreg");
            }
            else
            {
                int jatekokSzama = 0;

                if (rendetlensegSzint >= 1 && rendetlensegSzint <= 20) jatekokSzama = 1;
                else if (rendetlensegSzint >= 21 && rendetlensegSzint <= 53) jatekokSzama = 2;
                else if (rendetlensegSzint >= 54 && rendetlensegSzint <= 88) jatekokSzama = 3;
                else if (rendetlensegSzint >= 89 && rendetlensegSzint <= 100) jatekokSzama = 4;

                for (int i = 0; i < jatekokSzama; i++)
                {
                    jatek.Add(jatekok[random.Next(jatekok.Count)]);
                }

                Console.WriteLine($"Ezt a játékot fogja játszani: {string.Join(", ", jatek)}");

                if (jatek.Contains("romlott kaja"))
                {
                    Eves(10);
                }
            }
        }




        public override string ToString()
		{
			return @"
  /\_/\  
 ( o.o ) 
  > ^ <
" + $"Neve: {nev}, kora: {kor}, súlya: {suly}, fajtája: {fajta}, \n színe: {szin}, rendetlenségi szintje: {rendetlensegSzint}, fogyasztása: {fogasztas}, éhes e: {ehes}, neme: {nem}, életereje: {eletero} ";
			
		}

	}
}
