namespace osztalyokgyakorlas
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Cica macska1 = new( "Cicus",3, 6, "Abeszin", "narancs", 30, 2, "hím");
            Console.WriteLine(macska1.ToString());

            Console.WriteLine();
			macska1.KulonTenyezok();
            Console.WriteLine();
			macska1.EletKor();
            Console.WriteLine();
			macska1.Eves(85);
			Console.WriteLine();
			macska1.Alvas();
			Console.WriteLine();
			macska1.Ebredes();

            Console.WriteLine();

            macska1.Jatek();
            Console.WriteLine();
            Console.WriteLine(macska1);
        }
	}
}
