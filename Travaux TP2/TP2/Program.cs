using System;

namespace TP2
{
  class Program
  {


    // Largeur de la console
    const int CONSOLE_WIDTH = 5 * Display.CARD_WIDTH;
    // Nombre d'itérations où le joueur peut changer ses cartes (max 10 ici)
    const int NUM_DRAWS = Game.NUM_CARDS/Game.NUM_CARDS_IN_HAND;

        static bool CheckForStraight(int[] cards)
        {
            // Check if the sequence includes Ace (0) and King (12) without sorting
            if (HasAceKingStraight(cards))
            {
                return true;
            }

            // Sort the array in ascending order
            Array.Sort(cards);

            // Check for consecutive values
            for (int i = 0; i < cards.Length - 1; i++)
            {
                if (cards[i] != cards[i + 1] - 1)
                {
                    return false;
                }
            }

            return true;
        }
        static bool HasAceKingStraight(int[] cards)
        {
            
            return cards.Length == 5 && cards[0] == 0 && cards[cards.Length - 1] == 12;
        }
        static void Main(string[] args)
    {
            //{ 13, 22, 36, 24, 12 };

            int[] cards = { 0, 9, 10,11, 12 }; // Example array

            bool hasStraight = CheckForStraight(cards);

            Console.WriteLine(hasStraight ? "There is a straight!" : "No straight found.");
            //int[] values = { 3, 15, 16, 24, 29 };

            //     //Console.WriteLine(43 % 13 - 1);
            //     //Console.WriteLine(Game.GetValueFromCardIndex(values[2]));
            //     bool x = Game.HasPair(values);
            // Console.WriteLine(x);
                 Console.ReadKey();


            /////////////////////////////////////////////////////////////////
            Display.Clear();
      Console.WindowWidth = CONSOLE_WIDTH;

      bool[] availableCards = new bool[Game.NUM_CARDS] ;
      for (int i = 0; i < availableCards.Length; i++)
        availableCards[i] = true;

      int[] cardValues = new int[Game.NUM_CARDS_IN_HAND] { 1, 1, 1, 1, 26 };

      bool[] selectedCards = new bool[Game.NUM_CARDS_IN_HAND];
      for (int i = 0; i < selectedCards.Length; i++)
        selectedCards[i] = false;

      Game.DrawCards(cardValues, selectedCards, availableCards);
      for (int i = 0; i < NUM_DRAWS; i++)
      {
        // Afficher les cartes
        Display.ShowCards(cardValues);
        // Afficher les consignes
        Display.ShowInstructions();
        // Afficher la meilleure main à date
        Game.ShowHand(cardValues);
        // Permettre au joueur de sélectionner les cartes à garder
        Display.SelectCards(selectedCards);
        // Relancer les cartes que le joueur ne veut pas garder.
        Game.DrawCards(cardValues, selectedCards, availableCards);
      }

      Display.WriteString("", 0, Console.WindowHeight - 2, ConsoleColor.Black);
    }
  }
}
