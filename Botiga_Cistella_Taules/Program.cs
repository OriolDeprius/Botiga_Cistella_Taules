namespace Botiga_Cistella_Taules
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] productesBotiga = new string[10] { "kebab", "cocacola", "pomes", "peres", "llimones", "platans", "arros",  "", "", ""};
            double[] preus = new double[10] {3.5, 2, 2, 3, 4, 5, 6, 0, 0, 0};
            int nElemBotiga = productesBotiga.Length;

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

            }
        }
        static int Menu()
        {
            int opcio;
            Console.WriteLine("╔══════════════════════╗\n" +
                              "║---------MENÚ---------║\n" +
                              "╠══════════════════════╣\n" +
                              "║********BOTIGA********║\n" +
                              "╠══════════════════════╣\n" +
                              "║1. Afegir Producte    ║\n" +
                              "║2. Ampliar Botiga     ║\n" +
                              "║3. Modificar Preu     ║\n" +
                              "║4. Modificar Producte ║\n" +
                              "║5. Ordenar Producte   ║\n" +
                              "║6. Ordenar Preus      ║\n" +
                              "║7. Mostrar            ║\n" +
                              "║8. Mostrar Tot        ║\n" +
                              "╠══════════════════════╣\n" +
                              "║*******CISTELLA*******║\n" +
                              "╠══════════════════════╣\n" +
                              "║9. Comprar Producte   ║\n" +
                              "║10. Ordenar Cistella  ║\n" +
                              "║11. Mostra            ║\n" +
                              "║12. Mostra Tot        ║\n" +
                              "╚══════════════════════╝\n");
            Console.Write("Tria una opcio: ");
            opcio = Convert.ToInt32(Console.ReadLine());
            return opcio;
        }
        static void AfegirProducte(string[] productesBotiga, double[] preus, ref int nElemBotiga)
        {

        }
    }
}
