namespace RevisionExamen1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int reste1 = Modulos(13, 2);
            int reste2 = 13 % 2;
        }
        public static bool EstPremier(int entree)
        {
            int diviseur = 2;
            bool resultat = true;
            while (diviseur < entree)
            {
                if (entree % diviseur == 0)
                {
                    resultat = false;
                }
                diviseur++;
            }
            return resultat;
        }
        public static bool EstPremierOptimisee(int entree)
        {
            int diviseur = 2;
            bool resultat = true;
            while (diviseur < Math.Sqrt(entree))
            {
                if (entree % diviseur == 0)
                {
                    resultat = false;
                }
                diviseur++;
            }
            return resultat;
        }
        public static void AfficheDiviseurs(int entree)
        {
            int diviseurs = 1;
            while(diviseurs <= entree)
            {
                if(entree % diviseurs == 0)
                {
                    Console.WriteLine(diviseurs);
                }
                diviseurs = diviseurs + 1;
            }    
        }
        

        static bool IsPalindrome(string entree)
        {
            int i = 0; 
            int j = entree.Length - 1;
            while (i < j)
            {
                if (entree[i] != entree[j])
                {
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }
        public static bool IsPalindrome2(string entree)
        {
            int i = 0;
            int j = entree.Length - 1;
            bool resultat = true;
            while (i < j)
            {
                if (entree[i] != entree[j])
                {
                    resultat = false;
                }
                i++;
                j--;
            }
            return resultat;
        }
        public static int Modulos(int entree,int modulus)
        {
            int rest = entree;
            while (rest >= modulus)
            {
                rest = rest - modulus;

            }
            return rest;
        }
        public static string InverseChaine(string entree)
        {
            string entreeInvers = "";
            for (int i = entree.Length - 1; i > -1; i--)
            {
                entreeInvers += entree[i];
            }
            return entreeInvers;
        }
        public static int Fibonacci(int n)
        {
            int precedant = 0;
            int courrant = 1;
            for (int i = 2; i <= n; i++)
            {
                int suivant = precedant + courrant;
                precedant = courrant;
                courrant = suivant;
            }
            return courrant;
        }

    }
}