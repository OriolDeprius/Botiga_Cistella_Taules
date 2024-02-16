namespace Botiga_Cistella_Taules
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] productesBotiga = new string[] { "kebab", "cocacola", "pomes", "peres", "llimones", "platans", "arros", "", "", "" };
            double[] preus = new double[] { 3.5, 2, 2, 3, 4, 5, 6, 0, 0, 0 };
            int nElemBotiga = 7;

            string[] productesCistella = new string[10];
            int[] productes = new int[10];
            int nElemCistella = productesCistella.Length;
            double diners;

            switch (Menu())
            {
                case 1:
                    AfegirProducte(productesBotiga, preus, ref nElemBotiga);
                    break;
                case 2:
                    int quantitatAfegir;
                    Console.Write("Quants productes vols afegir?");
                    quantitatAfegir = Convert.ToInt32(Console.ReadLine());
                    AfegirProductes(productesBotiga, preus, ref nElemBotiga, quantitatAfegir);
                    break;
                case 3:
                    int ampliacio;
                    Console.Write("Quants elements vols ampliar? --> ");
                    ampliacio = Convert.ToInt32(Console.ReadLine());
                    AmpliarBotiga(ref productesBotiga, ref preus, ampliacio);
                    break;
                case 4:
                    string producteModificar;
                    Console.Write("A quin producte li vols canviar el preu? --> ");
                    producteModificar = Console.ReadLine();
                    ModificarPreu(productesBotiga, preus, producteModificar);
                    break;
                case 5:
                    string producteAntic, producteNou;
                    Console.Write("Quin producte vols modificar?");
                    producteAntic = Console.ReadLine();
                    Console.Write("Quin és el nou producte?");
                    producteNou = Console.ReadLine();
                    ModificarProducte(productesBotiga, producteAntic, producteNou);
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
            Console.Clear();
            return opcio;
        }
        static void AfegirProducte(string[] productesBotiga, double[] preus, ref int nElemBotiga)
        {
            string producteAfegir;
            double preuAfegir;
            
            if (productesBotiga.Length == nElemBotiga)
            {
                char resposta;
                Console.WriteLine("La botiga està plena, vols ampliar-la?");
                Console.Write("(S/N) --> ");
                resposta = Console.ReadKey().KeyChar;
                resposta = Char.ToUpper(resposta);
                if (resposta == 'S')
                {
                    AmpliarBotiga(ref productesBotiga, ref preus);
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

        static void AfegirProductes(string[] productes, double[] preus, ref int nElem, int quantitatAfegir)
        {
            for (int i = 0; i < quantitatAfegir; i++)
                AfegirProducte(productes, preus, ref nElem);
        }
        static void AmpliarBotiga(ref string[] productesBotiga, ref double[] preus, int ampliacio)
        {
            string[] auxProductes = new string[productesBotiga.Length + ampliacio];
            double[] auxPreus = new double[preus.Length + ampliacio];

            for (int i = 0; i < productesBotiga.Length; i++)
            {
                auxProductes[i] = productesBotiga[i];
                auxPreus[i] = preus[i];
            }
            productesBotiga = auxProductes;
            preus = auxPreus;
        }
        static void AmpliarBotiga(ref string[] productesBotiga, ref double[] preus)
        {
            int ampliacio;
            Console.Write("Quants elements vols ampliar? --> ");
            ampliacio = Convert.ToInt32(Console.ReadLine());
            string[] auxProductes = new string[productesBotiga.Length + ampliacio];
            double[] auxPreus = new double[preus.Length + ampliacio];

            for (int i = 0; i < productesBotiga.Length; i++)
            {
                auxProductes[i] = productesBotiga[i];
                auxPreus[i] = preus[i];
            }
            productesBotiga = auxProductes;
            preus = auxPreus;
        }
        static void ModificarPreu(string[] productesBotiga, double[] preus, string producteModificar)
        {
            int posicio = -1;
            
            for (int i = 0; i < productesBotiga.Length; i++)
            {
                if (producteModificar == productesBotiga[i])
                {
                    posicio = i;
                }
            }
            if (posicio == -1)
            {
                Console.WriteLine("Aquest producte no existeix!");
            }
            else
            {
                Console.Write("Quin és el nou preu d'aquest producte? --> ");
                preus[posicio] = Convert.ToDouble(Console.ReadLine());
            }
        }
        static void ModificarProducte(string[] productesBotiga, string producteAntic, string producteNou)
        {
            int posicio = -1;

            for (int i = 0; i < productesBotiga.Length; i++)
            {
                if (producteAntic == productesBotiga[i])
                {
                    posicio = i;
                }
            }
            if (posicio == -1)
            {
                Console.WriteLine("Aquest producte no existeix!");
            }
            else
            {
                productesBotiga[posicio] = producteNou;
            }
        }
    }
}