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
            int nElemBotiga = 7;
            int li = 0;
            int ls = nElemBotiga - 1;

            string[] productesCistella = new string[10];
            int[] quantitat = new int[10];
            int nElemCistella = productesCistella.Length;
            //double diners;

            Console.Clear();
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
                    OrdenarProducte(productesBotiga, preus, li, ls);
                    Console.Clear();
                    Mostrar(productesBotiga, preus, nElemBotiga);
                    break;
                case 7:
                    OrdenarPreus(productesBotiga, preus, li, ls);
                    Console.Clear();
                    Mostrar(productesBotiga, preus, nElemBotiga);
                    break;
                case 8:
                    Mostrar(productesBotiga, preus, nElemBotiga);
                    break;
                case 9:
                    break;
                case 10:
                    Comprar1Producte(productesBotiga, preus, ref nElemBotiga, productesCistella, quantitat, ref nElemCistella);
                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    break;

            }
        }
        static int Menu()
        {
            int opcio;
            Console.WriteLine("╔════════════════════════╗\n" +
                              "║----------MENÚ----------║\n" +
                              "╠════════════════════════╣\n" +
                              "║*********BOTIGA*********║\n" +
                              "╠════════════════════════╣\n" +
                              "║ 1. Afegir 1 Producte   ║\n" +
                              "║ 2. Afegir +1 Producte  ║\n" +
                              "║ 3. Ampliar Botiga      ║\n" +
                              "║ 4. Modificar Preu      ║\n" +
                              "║ 5. Modificar Producte  ║\n" +
                              "║ 6. Ordenar Producte    ║\n" +
                              "║ 7. Ordenar Preus       ║\n" +
                              "║ 8. Mostrar             ║\n" +
                              "╠════════════════════════╣\n" +
                              "║********CISTELLA********║\n" +
                              "╠════════════════════════╣\n" +
                              "║ 9. Comprar 1 Producte  ║\n" +
                              "║ 10. Comprar +1 Producte║\n" +
                              "║ 11. Ordenar Cistella   ║\n" +
                              "║ 12. Mostra             ║\n" +
                              "║ 13. Mostra Tot         ║\n" +
                              "╚════════════════════════╝\n");
            Console.Write("Tria una opcio: ");
            opcio = Convert.ToInt32(Console.ReadLine());
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
        static void Mostrar(string[] productesBotiga, double[] preus, int nElem)
        {
            for (int i = 0; i < nElem; i++)
                Console.WriteLine(BotigaToString(productesBotiga, preus, nElem, i));
        }
        static string BotigaToString(string[] productesBotiga, double[] preus, int nElem, int i)
        {
            return $"Producte: {productesBotiga[i]} | Preu: {preus[i]};";
        }
        static void OrdenarPreus(string[] producteBotiga, double[] preus, int li, int ls)
        {
            int mig = Convert.ToInt32(preus[(li + ls) / 2]);
            int i = li;
            int j = ls;
            do
            {
                while (preus[i] < mig && i < ls) i++;
                while (preus[j] > mig && j > li) j--;
                if (i <= j)
                {
                    (preus[i], preus[j]) = (preus[j], preus[i]);
                    (producteBotiga[i], producteBotiga[j]) = (producteBotiga[j], producteBotiga[i]);
                    i++;
                    j--;
                }
            } while (i <= j);
            if (j > li) OrdenarPreus(producteBotiga, preus, li, j);
            if (i < ls) OrdenarPreus(producteBotiga, preus, i, ls);
        }
        static void OrdenarProducte(string[] producteBotiga, double[] preus, int li, int ls)
        {
            string mig = producteBotiga[(li + ls) / 2];
            int i = li;
            int j = ls;
            do
            {
                while (producteBotiga[i].CompareTo(mig) < 0 && i < ls) i++;
                while (producteBotiga[j].CompareTo(mig) > 0 && j > li) j--;
                if (i <= j)
                {
                    (preus[i], preus[j]) = (preus[j], preus[i]);
                    (producteBotiga[i], producteBotiga[j]) = (producteBotiga[j], producteBotiga[i]);
                    i++;
                    j--;
                }
            } while (i <= j);
        }

        //Cistella

        static void Comprar1Producte(string[] productesBotiga, double[] preus, ref int nElemBotiga, string[] productesCistella, int[] quantitat, ref int nElemCistella) //ref double d)
        {
            Console.Write("Quin producte vols afegir a la cistella? ");
            string producte = Convert.ToString(Console.ReadLine());
            Console.Clear();

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

            Console.Write("Quantes unitats vols? ");
            int unitats = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Console.Write("Quin pressupost tens? ");
            double diners = Convert.ToDouble(Console.ReadLine());
            Console.Clear();

            int posicio = Buscar(productesBotiga, nElemBotiga, producte);

            if (posicio == -1)
            {
                Console.WriteLine("No s'ha trobat el producte ");
            }
            else
            {
                double preuProducte = preus[posicio] * unitats;
                if (preuProducte <= diners)
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

        static int Buscar(string[] productesCistella, int nElemCistella, string nom)
        {
            int index = -1;
            for (int i = 0; i < nElemCistella; i++)
            {
                if (productesCistella[i] == nom)
                    index = i;
            }
            return index;
        }

        static void ComprarProductes(string[] productesBotiga, double[] preus, ref int nElemBotiga, string[] productesCistella, int[] quantitat, ref int nElemCistella)
        {

            Console.Write("Quina quantitat de productes vols comprar? ");
            int quant = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < quant; i++)
            {
                Comprar1Producte(productesBotiga, preus, ref nElemBotiga, productesCistella, quantitat, ref nElemCistella);

            }
        }
        static void OrdenarCistella(int[] productesCistella, int nElemCistella, int quantiat)
        {
            for (int numVolta = 0; numVolta < nElemCistella - 1; numVolta++)
            {
                for (int i = 0; i < nElemCistella; i++)
                {
                    if (productesCistella[i].CompareTo(productesCistella[i + 1]) > 0)
                    {
                        Permutar(ref productesCistella[i], ref productesCistella[i + 1]);
                    }
                }
            }
        }
        static void Permutar(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }
            static void MostrarCistella () 
        { 

        }
        static void CistellaToString()
        {

        }
    } 
}