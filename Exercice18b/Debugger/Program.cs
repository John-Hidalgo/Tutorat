using Exercice18b;

namespace Debugger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var res = Library.Dedup(new[] { 1, 1, 2, 3, 4, 5, 1, });
            AfficheTableau(res);
        }
        public static void AfficheTableau(int[] tableau)
        {
            Console.Write("{");
            foreach (int item in tableau)
            {
                Console.Write(item + ",");
            }
            Console.Write("}");
        }
    }
}

