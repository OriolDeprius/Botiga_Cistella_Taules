using System.Runtime.Serialization.Formatters;
using System.Threading.Channels;

namespace Botiga_Cistella_Taules
{
    internal class Program
    {


        static void Main(string[] args)
        {
            string[] productesBotiga = new string[] { "kebab", "cocacola", "pomes", "peres", "llimones", "platans", "arros", "", "", "" };
            double[] preus = new double[] { 3.5, 2, 2, 3, 4, 5, 6, 0, 0, 0 };
            int nElemBotiga = 10;

            string[] productesCistella = new string[10];
            int[] quantitat = new int[10];
            int nElemCistella = productesCistella.Length;
            double diners;

            switch (Menu())
            {
                case 1:
                    AfegirProducte(productesBotiga, preus, ref nElemBotiga);
                    break;
                case 2:
                    AfegirProductes(productesBotiga, preus, ref nElemBotiga);
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;

            }
        }
        static int Menu()
        {
            int opcio;
            Console.WriteLine("╔═══════════════════════╗\n" +
                              "║---------MENÚ----------║\n" +
                              "╠═══════════════════════╣\n" +
                              "║********BOTIGA*********║\n" +
                              "╠═══════════════════════╣\n" +
                              "║1. Afegir 1 Producte   ║\n" +
                              "║2. Afegir +1 Producte  ║\n" +
                              "║3. Ampliar Botiga      ║\n" +
                              "║4. Modificar Preu      ║\n" +
                              "║5. Modificar Producte  ║\n" +
                              "║6. Ordenar Producte    ║\n" +
                              "║7. Ordenar Preus       ║\n" +
                              "║8. Mostrar             ║\n" +
                              "║9. Mostrar Tot         ║\n" +
                              "╠═══════════════════════╣\n" +
                              "║*******CISTELLA********║\n" +
                              "╠═══════════════════════╣\n" +
                              "║10. Comprar 1 Producte ║\n" +
                              "║11. Comprar +1 Producte║\n" +
                              "║12. Ordenar Cistella   ║\n" +
                              "║13. Mostra             ║\n" +
                              "║14. Mostra Tot         ║\n" +
                              "╚═══════════════════════╝\n");
            Console.Write("Tria una opcio: ");
            opcio = Convert.ToInt32(Console.ReadLine());
            return opcio;
        }
        static void AfegirProducte(string[] productesBotiga, double[] preus, ref int nElemBotiga)
        {
            string producteAfegir;
            double preuAfegir;
            Console.Clear();
            if (productesBotiga.Length == nElemBotiga)
            {
                char resposta;
                Console.WriteLine("La botiga està plena, vols ampliar-la?");
                Console.Write("(S/N) --> ");
                resposta = Console.ReadKey().KeyChar;
                resposta = Char.ToUpper(resposta);
                if (resposta == 'S')
                {
                    AmpliarBotiga();
                }
                else if (resposta == 'N')
                {
                    Console.Clear();
                    for (int i = 5; i >= 0; i--)
                    {
                        Console.WriteLine($"Tornant al menu en {i}...");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    Menu();
                }
                else
                {
                    Console.WriteLine("Resposta no valida!");
                    Menu();
                }
            }
            Console.Write("Quin producte vols afegir? --> ");
            producteAfegir = Console.ReadLine();
            productesBotiga[nElemBotiga] = producteAfegir;
            Console.Write("\nQuin és el preu d'aquest producte? --> ");
            preuAfegir = Convert.ToDouble(Console.ReadLine());
            preus[nElemBotiga] = preuAfegir;
            nElemBotiga++;
        }

        static void AfegirProductes(string[] productes, double[] preus, ref int nElem)
        {
            char resposta;
            string producteAfegir;
            Console.WriteLine("Vols afegir un producte?");
            Console.Write("(S/N) --> ");
            resposta = Console.ReadKey().KeyChar;
            resposta = char.ToUpper(resposta);
            if (resposta == 'S')
            {
                while (resposta == 'S')
                {
                    Console.WriteLine("Quin producte vols afegir?");
                    producteAfegir= Console.ReadLine();
                }

            }
        }
        static void AmpliarBotiga()
        {

        }
        //Cistella

        static void Comprar1Producte(string[] productesBotiga, double [] preus, int nElemBotiga, string [] productesCistella, int[] quantitat, ref int nElemCistella, ref double d)
        {
            Console.Write("Quin producte vols afegir a la cistella? ");
            string producte=Convert.ToString(Console.ReadLine());
            //int index;
            //do
            //{
            //    Console.WriteLine("tria un producte");
            //    for (int i = 0; i < nElemBotiga; i++)
            //    {
            //        Console.WriteLine($"{i} - {productesBotiga[i]} preu {preus[i]}");
            //    }
            //    index = Convert.ToInt32(Console.ReadLine());
            //    if(index > nElemBotiga)
            //        Console.WriteLine("escriu un valor valid");
            //} while (index > nElemBotiga);

            //string producte = productesBotiga[index];

            //Console.Write("Quantes unitats vols? ");
            int unitats=Convert.ToInt32(Console.ReadLine());

            int posicio = Buscar(productesBotiga, nElemBotiga, producte);

            if (posicio == -1 )
            {
                Console.WriteLine("No s'ha trobat el producte ");
            }
            else
            {
                double preuProducte = preus[posicio] * unitats;
                if (preuProducte <= d)
                {
                    //comprovar si cistella plena
                    productesCistella[nElemCistella] = producte;
                    quantitat[nElemCistella] = unitats;
                    nElemCistella++;
                }
                else
                {
                    Console.WriteLine("No hi ha prous diners");
                }
            }
        }

        static int Buscar (string[] productesCistella, int nElemCistella, string nom) 
        {
            int index = -1;
            for(int i = 0;i<nElemCistella;i++)
            {
                if (productesCistella[i] == nom)
                    index = i
            }
            return index;
        }
















        static void ComprarProductes (int[] productesBotiga, string[] quantitat)
        {
            int[] aux = new int[productesBotiga.Length + ];
            for (int i= 0; i < productesBotiga.Length; i++) 
                aux[i] = productesBotiga[i];
            productesBotiga= aux;

        }
        
    }
}
