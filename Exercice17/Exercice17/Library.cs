using System;

namespace Exercice17
{
    public class Library
    {
        // TODO Créer la fonction "Sum".
        public static int Sum(int[] values)
        {
            if (values == null)
            {
                throw new ArgumentException("le tableau ne peut pas être nul");
            }
            int[] tableau = values;
            int somme = 0;
            for (int i = 0; i < tableau.Length; i++)
            {
                somme = values[i] + somme;

            }
            return somme;
        }
        // TODO Créer la fonction "Average".
        public static int Average(int[] values)
        {
            if (values == null)
            {
                throw new ArgumentException("le tableau ne peut pas être nul");
            }
            int moyenne = 0;
            for (int i = 0; i < values.Length; i++)
            {
                moyenne += values[i] ;
            }
            if(values.Length > 0)
            {
                moyenne /= values.Length;
            }
            return moyenne;
        }
        // TODO Créer la fonction "Max".
        public static int Max(int[] values)
        {
            if(values == null)
            {
                throw new ArgumentException("le tableau ne peut pas être nul");
            }
            if (values.Length == 0)
            {
                return int.MinValue;
            }
            int nombreMaximal = values[0];
            for(int i = 1;i < values.Length;i++)
            {
                if (values[i] > nombreMaximal)
                {
                    nombreMaximal = values[i]; 
                }
            }
            return nombreMaximal;
        }
        // TODO Créer la fonction "FilterEven".
        public static int[] FilterEven(int[] valeurs)
        {
            if (valeurs == null)
            {
                throw new ArgumentException("le tableau ne peut pas être nul");
            }
            int montantDuPairs = 0;
            for(int k = 0; k < valeurs.Length;k++)
            {
                if (valeurs[k] % 2 == 0)
                {
                    montantDuPairs++;
                }
            }
            int[] lesPairs = new int[montantDuPairs];
            int j = 0;
            for(int i = 0;i < valeurs.Length; i++)
            {
                if (valeurs[i] % 2 == 0)
                {
                    lesPairs[j] = valeurs[i];
                    j++;
                }
            }
            return lesPairs;
        }
    }
}
