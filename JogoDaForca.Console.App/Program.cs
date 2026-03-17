using System;
class Program
{
    static void Main(string[] args)
    {   
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Bem-vindo ao Jogo da Forca!");
        Console.WriteLine("---------------------------------");


     
    }

        static string palavraAleatoria()
        {
            string[] palavras = [
            "ABACATE",
            "ABACAXI",
            "ACEROLA",
            "AÇAÍ",
            "ARAÇÁ",
            "ABACATE",
            "BACABA",
            "BACURI",
            "BANANA",
            "CAJÁ",
            "CAJU",
            "CARAMBOLA",
            "CUPUAÇU",
            "GRAVIOLA",
            "GOIABA",
            "JABUTICABA",
            "JENIPAPO",
            "MAÇÃ",
            "MANGABA",
            "MANGA",
            "MARACUJÁ",
            "MURICI",
            "PEQUI",
            "PITANGA",
            "PITAYA",
            "SAPOTI",
            "TANGERINA",
            "UMBU",
            "UVA",
            "UVAIA"
            ];
            Random random = new Random();
            int index = random.Next(palavras.Length);
            return palavras[index];
        }

}
