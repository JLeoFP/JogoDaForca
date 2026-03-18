using System;
using System.Reflection;
using System.Security.Cryptography;

/*Desafio 1: Validação, armazenamento e exibição de letras já digitadas
Não permitir uso de letras já chutadas, também exibir as letras erradas.

*/
class Program
{
    static void Main(string[] args)
    {   
        
        while(true)
        {
            
            IncioJogo();

            string palavraSecreta = PalavraAleatoria();

            char[] letrasAcertadas = PrencherLetrasAcertadas(palavraSecreta);

            RunLogicgame(letrasAcertadas, palavraSecreta);


            if(!DesejaContinuar())
            {
                break;
            }
        }
     
    }

    static void IncioJogo()
    {   
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Bem-vindo ao Jogo da Forca!");
        Console.WriteLine("Digite ENTER para iniciar o jogo.");
        Console.ReadLine();
    }

    static string PalavraAleatoria()
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
        
        int indexAleatorio = RandomNumberGenerator.GetInt32(palavras.Length);       
        
        string palavraSelecionada = palavras[indexAleatorio];                 //
        return palavraSelecionada;
    }

    static char[] PrencherLetrasAcertadas(string palavraSecreta)
    {
        char[] letrasAcertadas = new char[palavraSecreta.Length];

            for(int i=0; i < letrasAcertadas.Length; i++)   // Exibir os traços para as letras da palavra secreta.
            {
                letrasAcertadas[i] = '_';
            }
            return letrasAcertadas;
    }

    static void RunLogicgame(char[] letrasAcertadas, string palavraSecreta)
    {
        bool jogadorAcertouPalavra = false;
        bool jogadorPerdeu = false;
        int countErros = 0;
        
        // Arrays para letras chutadas y erradas

        char[] letrasErradas = new char[26];
        int countLetrasErradas = 0;
        char[] letrasJaChutadas = new char[26];
        int countLetrasJaChutadas = 0;

        while (!jogadorAcertouPalavra && !jogadorPerdeu)
        {
            ExibirForca(countErros);

            Console.WriteLine("Letras acertadas: " + string.Join("", letrasAcertadas));
            Console.WriteLine("---------------------------------");
            
            //exibição de letras erradas.

            if(countLetrasErradas > 0)
            {
                Console.Write("Letras erradas:");
                for(int i = 0; i < countLetrasErradas; i++)
                {
                    Console.Write(letrasErradas[i]);
                    if(i < countLetrasErradas - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine();
                
            }

            
            Console.WriteLine("Erros cometidos: " + countErros);
            Console.WriteLine("---------------------------------");
            
            // exibição de letras já digitadas

            if(countLetrasJaChutadas > 0)
            {
                Console.Write("Letra ya usada: ");
                for(int i=0; i < countLetrasJaChutadas; i++)
                {
                    Console.Write(letrasJaChutadas[i]);
                    if(i < countLetrasJaChutadas - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("---------------------------------");
            }

            Console.WriteLine("Digite uma letra: ");
            string? strLetra = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(strLetra))
                {
                    Console.WriteLine("Digite uma letra válida.");
                    Console.ReadLine();
                    continue;
                }
            char letraChute = char.ToUpper(Convert.ToChar(strLetra));

            //validar letra chutada.

            bool letraRepetida = false; 

            for(int i=0; i < countLetrasJaChutadas; i++)
            {
                if (letrasJaChutadas[i]== letraChute)
                {
                    letraRepetida = true;
                    break;
                }
            }

            if(letraRepetida)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Voce ja tentou a letra {letraChute}! Tente outra.");
                Console.WriteLine("---------------------------------");
                Console.ReadLine();
                continue;
            }

            letrasJaChutadas[countLetrasJaChutadas] = letraChute;
            countLetrasJaChutadas++;

            bool letraEncontrada = false;

            for(int cont = 0; cont < palavraSecreta.Length; cont++)
            {
                char letraAtual = palavraSecreta[cont];

                if(letraChute == letraAtual)
                {
                    letrasAcertadas[cont] = letraAtual;
                    letraEncontrada = true;
                }
            }
            
            if (letraEncontrada == false)
            {   
                countErros++;
                letrasErradas[countLetrasErradas] = letraChute;    //agreda al arrays de letras erradas
                countLetrasErradas++;
            }
            
            jogadorAcertouPalavra = palavraSecreta == string.Join("", letrasAcertadas);            // Verificar se o jogador acertou a palavra   
            jogadorPerdeu = countErros > 5;                                                                 // Verificar se o jogador errou 5 vezes

            if(jogadorAcertouPalavra)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Você acertou! A palavra secreta era {palavraSecreta}.");
                Console.WriteLine("---------------------------------");
            }
            else if(jogadorPerdeu)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Você perdeu! Tente novamente.");
                Console.WriteLine("---------------------------------");
            }

            Console.ReadLine();

        }
    }

    static void ExibirForca(int countErros)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Jogo da Forca");
        Console.WriteLine("---------------------------------");

        if (countErros == 0)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }

        else if (countErros == 1)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }

        else if (countErros == 2)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |         |        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }

        else if (countErros == 3)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|\       "); 
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }

        else if (countErros == 4)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|\       ");
            Console.WriteLine(@" |         |        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }

        else if (countErros == 5)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|\       ");
            Console.WriteLine(@" |         |        ");
            Console.WriteLine(@" |        / \       ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }

        Console.WriteLine("---------------------------------");
    }
    static bool DesejaContinuar()
    {
        Console.WriteLine("Deseja jogar novamente? (S/N)");
        string? resposta = Console.ReadLine().ToUpper();
        
        if(resposta != "S")
        {
            Console.WriteLine("Obrigado por jogar!");
            Console.ReadKey();
            return false;
        }
        return true;

    }

}

