﻿using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace TP2
{
    public class Game
    {
        public const int SPADE = 0;
        public const int CLUB = 1;
        public const int DIAMOND = 2;
        public const int HEART = 3;

        public const int CA = 0;
        public const int C2 = 1;
        public const int C3 = 2;
        public const int C4 = 3;
        public const int C5 = 4;
        public const int C6 = 5;
        public const int C7 = 6;
        public const int C8 = 7;
        public const int C9 = 8;
        public const int C10= 9;
        public const int CJ = 10;
        public const int CQ = 11;
        public const int CK = 12;

        public static int[] valeurs = { CA, C2, C3, C4, C5 , C6, C7, C8, C9, C10, CJ, CQ, CK};

        public const int HIGH_CARD = 0;
        public const int ONE_PAIR = 1;
        public const int TWO_PAIRS = 2;
        public const int THREE_OF_A_KIND = 3;
        public const int STRAIGHT = 4;
        public const int FLUSH = 5;
        public const int FULL_HOUSE = 6;
        public const int FOUR_OF_A_KIND = 7;
        public const int STRAIGHT_FLUSH = 8;
        public const int ROYAL_FLUSH = 9;

        public const int NUM_SUITS = 4;
        public const int NUM_CARDS_PER_SUIT = 13;
        public const int NUM_CARDS = NUM_SUITS * NUM_CARDS_PER_SUIT;
        public const int NUM_CARDS_IN_HAND = 5;

        public static int GetSuitFromCardIndex(int index)
        {
            // A COMPLETER
            // ...
            // return donné juste pour que ça compile mais valeur incorrecte
            if (index < 0 || index > 51)
            {
                throw new ArgumentOutOfRangeException();
            }
            int result = 0;
            switch (index)
            {
                case int n when n >= 0 && n <= 12:
                    result = SPADE;
                    break;
                case int n when n >= 13 && n <= 25:
                    result = CLUB;
                    break;
                case int n when n >= 26 && n <= 38:
                    result = DIAMOND;
                    break;
                case int n when n >= 39 && n <= 51:
                    result = HEART;
                    break;
            }
            return result;
        }
        public static int GetValueFromCardIndex(int index)
        {
            // A COMPLETER
            // ...
            // return donné juste pour que ça compile mais valeur incorrecte
            if (index < 0 || index > 52)
            {
                throw new ArgumentOutOfRangeException();
            }
            return valeurs[(index % 13)] + 1;
        }
	    public static void DrawCards(int[] cardValues, bool[] selectedCards, bool[] availableCards)
        {
            Random random = new Random();
            // A COMPLETER
            // ...
            for (int i = 0; i < NUM_CARDS_IN_HAND; i++)
            {
                int pige;
                do
                {
                    pige = random.Next(NUM_CARDS - 1);
                } while (!availableCards[pige]);
                if (selectedCards[i] == false)
                {
                    cardValues[i] = pige;
                }
                availableCards[pige] = false;
            }
        }

        public static int GetHand(int[] cardValues)
        {
            int hand = HIGH_CARD;
            if (HasPair(cardValues))
                return ONE_PAIR;
            else if (HasTwoPairs(cardValues))
                return TWO_PAIRS;
            else if (HasThreeOfAKind(cardValues))
                return THREE_OF_A_KIND;
            else if(HasStraight(cardValues))
                return STRAIGHT;
            else if(HasFlush(cardValues))
                return FLUSH;
            // A COMPLETER
            // ...
            return hand;
        }

        // A COMPLETER
        // ...
        // Il manque toutes les méthodes pour trouver les paires, les doubles paires, les brelans, etc.
        // Référez-vous aux tests pour les noms de méthodes appropriés.

        public static void ShowHand ( int[] cardValues )
        {
            int hand = GetHand (cardValues);
            Display.WriteString ($"Vous avez actuellement {Display.ConvertHandToString (hand)}", 0, Display.CARD_HEIGHT + 14, ConsoleColor.Black);
        }

        public static int GetHighestCard(int[] values)
        {
            if (values == null)
            {
                throw new ArgumentException("le tableau ne peut pas être nul");
            }
            if (values.Length == 0)
            {
                return int.MinValue;
            }
            int nombreMaximal = values[0];
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == CA)
                    return CA;
                if (GetValueFromCardIndex(values[i]) > GetValueFromCardIndex(nombreMaximal))
                {
                    nombreMaximal = values[i];    
                }
            }
            return nombreMaximal;
        }
        public static bool HasPair(int[] values)
        {
            Console.WriteLine(GetValueFromCardIndex(values[0]));
            if (HasThreeOfAKind(values) || HasFourOfAKind(values))
            {
                return false;
            }
            for (int i = 1; i < values.Length; i++)
            {
                Console.WriteLine(GetValueFromCardIndex(values[i]));
                if (GetValueFromCardIndex(values[i - 1]) == GetValueFromCardIndex(values[i]))
                return true;
            }
            for (int i = 0; i < values.Length - 1; i++)
            {
                for (int j = i + 1; j < values.Length; j++)
                {
                    if (GetValueFromCardIndex(values[i]) == GetValueFromCardIndex(values[j]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool HasTwoPairs(int[] values)
        {
            int[] cardValues = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                cardValues[i] = GetValueFromCardIndex(values[i]);
            }
            int[] montant = new int[13];
            foreach (int num in cardValues)
            {
                montant[num]++;
            }
            int pairCount = 0;
            foreach (int count in montant)
            {
                if (count == 2)
                {
                    pairCount++;
                }
            }
            return pairCount == 2;
        }

        public static bool HasThreeOfAKind(int[] values)
        {
            if(HasFourOfAKind(values))
            { return false; }
            for (int i = 0; i < values.Length - 2; i++)
            {
                for (int j = i + 1; j < values.Length - 1; j++)
                {
                    for (int k = j + 1; k < values.Length; k++)
                    {
                        if (GetValueFromCardIndex(values[i]) == GetValueFromCardIndex(values[j]) && GetValueFromCardIndex(values[j]) == GetValueFromCardIndex(values[k]))
                        {
                            return true;
                        }
                    }
                }
            }
            return false; 
        }
        public static bool HasStraight(int[] values)
        {
            bool dec = true;
            for (int i = 1; i < values.Length; i++)
            {
                if (GetValueFromCardIndex(values[i]) >= GetValueFromCardIndex(values[i - 1]))
                {
                    dec = false;
                }
            }
            if(dec == false)
            {
                for (int i = 1; i < values.Length; i++)
                {
                    if (GetValueFromCardIndex(values[i]) <= GetValueFromCardIndex(values[i - 1]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool HasFlush(int[] values)
        {
            for (int i = 1; i < values.Length; i++)
            {
                if (GetSuitFromCardIndex(values[0]) != GetSuitFromCardIndex(values[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool HasFullHouse(int[] values)
        {
            return HasPair(values) && HasThreeOfAKind(values);
        }

        public static bool HasFourOfAKind(int[] values)
        {
            for (int i = 0; i < values.Length - 3; i++)
            {
                for (int j = i + 1; j < values.Length - 2; j++)
                {
                    for (int k = j + 1; k < values.Length - 1; k++)
                    {
                        for (int l = k + 1; l < values.Length; l++)
                        {
                            if (GetValueFromCardIndex(values[i]) == GetValueFromCardIndex(values[j]) && GetValueFromCardIndex(values[j]) == GetValueFromCardIndex(values[k]) && GetValueFromCardIndex(values[k]) == GetValueFromCardIndex(values[l]))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static bool HasStraightFlush(int[] values)
        {
            if (HasRoyalFlush(values))
            {
                return false;
            }
            if (!HasStraight(values))
            {
                return false;
            }
            for (int i = 1; i < values.Length; i++)
            {
                if (GetSuitFromCardIndex(values[0]) != GetSuitFromCardIndex(values[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool HasRoyalFlush(int[] values)
        {
            return false;
        }
    
    }
}