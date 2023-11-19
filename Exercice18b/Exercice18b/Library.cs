using System;

namespace Exercice18b
{
    public class Library
    {
        // Code de la fonction Clamp
        public static void Clamp(int[] numbers, int min, int max)
        {
            if (numbers is null)
            {
                throw new ArgumentNullException($"Le tableau {numbers} peut pas etre null");
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    numbers[i] = min;
                }

                else if (numbers[i] > max)
                {
                    numbers[i] = max;
                }
            }
        }
        // Code de la fonction Insert
        public static int[] Insert(int[] numbers, int v1, int v2)
        {
            if (numbers is null)
            {
                throw new ArgumentException($"Le tableau {numbers} peut pas etre null");
            }
            int[] newArray = new int[numbers.Length + 1];
            for (int i = 0; i < v1; i++)
            {
                newArray[i] = numbers[i];
            }
            newArray[v1] = v2;
            for (int i = v1 + 1; i < newArray.Length; i++)
            {
                newArray[i] = numbers[i-1];
            }
            return newArray;
        }
        public static int[] Dedup(object value)
        {
            if (value is null)
            {
                throw new ArgumentException($"l'objets {value} peut pas etre null");
            }
            // je sais pas pourquoi le prof as passee le parametre comme objet
            int[] tableau = value as int[];
            bool[] contiens = new bool[tableau.Length];
            int montantDoublons = 0;
            for(int i = 1;i < tableau.Length;i++)
            {
                if (tableau[i] == tableau[i - 1])
                {
                    contiens[i] = true;
                    montantDoublons++;
                }
                else
                {
                    contiens[i] = false;
                }
            }
            int[] sansDoublons = new int[tableau.Length - montantDoublons];
            int j = 0;
            for(int i = 0;i < tableau.Length;i++)
            {
                if (!contiens[i])
                {
                    sansDoublons[j] = tableau[i];
                    j++;
                }
            }
            return sansDoublons;
        }
        // Code de la fonction Dedup

        // Code de la fonction Contains qui n'est pas demandée mais qui risque
        // d'être utile pour la fonction Dedup
    }
}
