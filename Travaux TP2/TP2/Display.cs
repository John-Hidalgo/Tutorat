using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
  class Display
  {
    public const int CARD_WIDTH = 30;
    public const int CARD_HEIGHT = 14;
    public static readonly String[] SPADE_LOGO = {
      "           &.            ",
      "        &&&&&&&@         ",
      "      &&&&&&&&&&&&&      ",
      "    &&&&&&&&&&&&&&&&&    ",
      "  %&&&&&&%%%%%%%%&&&&&&  ",
      " &&&&&&&%%%%%%%%%&&&&&&& ",
      " &&&&&&&&%%%%%%%%&&&&&&& ",
      "  &&&&&&&&&%%&&&&&&&&&&@ ",
      "    &&&&&&& && &&&&&&    ",
      "           &&&           ",
      "           &&&&          "
    };

    public static readonly String[] HEART_LOGO = {
    "    /####.     #####     ",
    " .#######(##(((########  ",
    " #####((((((((((((###### ",
    " ####(((((((((((((((#### ",
    "  ##((((((((((((((((###  ",
    "   ((((((((((((((((((    ",
    "     #((((((((((((#      ",
    "        ##((((((#        ",
    "           ##,           "
    };
    public static readonly String[] DIAMOND_LOGO = {
    "           %##           ",
    "          ######         ",
    "        (((((((((#       ",
    "      (((((((((((((.     ",
    "    #((((((((((((((((    ",
    "    (((((((((((((((((    ",
    "      ((((((((((((((     ",
    "        ((((((((((       ",
    "         /######         ",
    "           ###           "
    };
    public static readonly String[] CLUB_LOGO ={
    "        &&&&&&&&%        ",
    "      @&&&&&&&&&&&       ",
    "      &&&&&&&&&&&&       ",
    "       %&%%%%%%%&        ",
    " &&&&&&&%%%%%%%%%&&&&&&  ",
    "&&&&&&&&%%%%%%%%%&&&&&&& ",
    "&&&&&&&&&%%%%%%%&&&&&&&& ",
    " &&&&&&&&&*&& &&&&&&&&&  ",
    "           &&.           ",
    "          &&&&           "
    };
    public static void DrawArrayOfStrings ( String[] logo, int posX, int posY, ConsoleColor color )
    {
      for (int i = 0; i < logo.Length; i++)
      {
        Display.WriteString (logo[i], posX, posY + i, color);
      }
    }
    public static void DrawCard ( int value, int suit, int posX, int posY )
    {
      String[] border ={
      "*****************************",
      "*                           *",
      "*                           *",
      "*                           *",
      "*                           *",
      "*                           *",
      "*                           *",
      "*                           *",
      "*                           *",
      "*                           *",
      "*                           *",
      "*                           *",
      "*                           *",
      "*****************************",
      };


      ConsoleColor color = ConsoleColor.Black;
      String[] logo = SPADE_LOGO;
      if (suit == Game.CLUB)
        logo = CLUB_LOGO;
      if (suit == Game.DIAMOND)
      {
        logo = DIAMOND_LOGO;
        color = ConsoleColor.Red;
      }
      if (suit == Game.HEART)
      {
        logo = HEART_LOGO;
        color = ConsoleColor.Red;
      }
      DrawArrayOfStrings (border, posX, posY, ConsoleColor.Black);


      DrawArrayOfStrings (logo, posX + 2, posY + 2, color);
      WriteString (ConvertValueToString (value), posX + 2, posY + 1, color);
      WriteString (ConvertValueToString (value), posX + 24, posY + 12, color);
    }
    public static string ConvertHandToString ( int hand )
    {
      string stringRepresentationOfHand = "High card";
      switch (hand)
      {
        case Game.ONE_PAIR:
        {
          stringRepresentationOfHand = "One pair";
          break;
        }
        case Game.TWO_PAIRS:
        {
          stringRepresentationOfHand = "Two pairs";
          break;
        }
        case Game.THREE_OF_A_KIND:
        {
          stringRepresentationOfHand = "Three of a kind";
          break;
        }
        case Game.STRAIGHT:
        {
          stringRepresentationOfHand = "Straight";
          break;
        }
        case Game.FLUSH:
        {
          stringRepresentationOfHand = "Flush";
          break;
        }
        case Game.FULL_HOUSE:
        {
          stringRepresentationOfHand = "Full house";
          break;
        }
        case Game.FOUR_OF_A_KIND:
        {
          stringRepresentationOfHand = "Four of a kind";
          break;
        }
        case Game.STRAIGHT_FLUSH:
        {
          stringRepresentationOfHand = "Straight flush";
          break;
        }
        case Game.ROYAL_FLUSH:
        {
          stringRepresentationOfHand = "Royal flush";
          break;
        }
      }
      return stringRepresentationOfHand;
    }
    public static string ConvertValueToString ( int value )
    {
      string stringRepresentationOfValue = "A";
      switch (value)
      {
        case Game.CA:
        {
          stringRepresentationOfValue = "A";
          break;
        }
        case Game.C2:
        case Game.C3:
        case Game.C4:
        case Game.C5:
        case Game.C6:
        case Game.C7:
        case Game.C8:
        case Game.C9:
        case Game.C10:
        {
          stringRepresentationOfValue = Convert.ToString (value + 1);
          break;
        }
        case Game.CJ:
        {
          stringRepresentationOfValue = "J";
          break;
        }
        case Game.CQ:
        {
          stringRepresentationOfValue = "Q";
          break;
        }
        case Game.CK:
        {
          stringRepresentationOfValue = "K";
          break;
        }
      }
      return stringRepresentationOfValue;
    }

    public static void WriteString ( String message, int posX, int posY, ConsoleColor color )
    {
      Console.SetCursorPosition (posX, posY);
      Console.ForegroundColor = color;
      Console.Write (message);
    }
    public static void Clear ()
    {
      Console.BackgroundColor = ConsoleColor.White;
      Console.Clear ();
      Console.CursorVisible = false;
    }
    public static void ShowCards ( int[] cardValues )
    {
      Display.Clear ();
      for (int i = 0; i < cardValues.Length; i++)
      {
        Display.DrawCard (Game.GetValueFromCardIndex (cardValues[i]),
                          Game.GetSuitFromCardIndex (cardValues[i]),
                         i * CARD_WIDTH,
                         0);
      }
    }

    public static void ShowSelectedMarks ( bool[] selectedCards )
    {
      for (int i = 0; i < selectedCards.Length; i++)
      {
        String text = "[ ]";
        if (selectedCards[i])
          text = "[X]";
        Display.WriteString (text, (CARD_WIDTH - text.Length) / 2 + i * CARD_WIDTH, CARD_HEIGHT + 2, ConsoleColor.Black);
      }
    }
    public static bool IsKeyAvailable ()
    {
      return Console.KeyAvailable;
    }
    public static void HighLightText ( String message, int posX, int posY )
    {
      Console.SetCursorPosition (posX, posY);
      Console.BackgroundColor = ConsoleColor.Black;
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write (message);
      Console.BackgroundColor = ConsoleColor.White;
      Console.ForegroundColor = ConsoleColor.Black;
    }
    public static void SelectCards ( bool[] selectedCards )
    {
      Display.ShowSelectedMarks (selectedCards);
      int current = 0;
      String symbol = " ";
      if (selectedCards[current])
        symbol = "X";
      Display.HighLightText (symbol, (Display.CARD_WIDTH - symbol.Length) / 2 + current * Display.CARD_WIDTH, Display.CARD_HEIGHT + 2);

      while (true)
      {
        if (Display.IsKeyAvailable ())
        {
          ConsoleKey currentKey = Console.ReadKey ().Key;
          if (currentKey == ConsoleKey.Enter)
            break;
          if (currentKey == ConsoleKey.Tab)
          {
            current = (current + 1) % selectedCards.Length;
          }
          if (currentKey == ConsoleKey.Spacebar)
            selectedCards[current] = !selectedCards[current];

          Display.ShowSelectedMarks (selectedCards);
          symbol = " ";
          if (selectedCards[current])
            symbol = "X";
          Display.HighLightText (symbol, (Display.CARD_WIDTH - symbol.Length) / 2 + current * Display.CARD_WIDTH, Display.CARD_HEIGHT + 2);
        }
      }
    }
    public static void ShowInstructions ()
    {
      Display.WriteString ("Appuyez sur espace pour sélectionner/désélectionner la carte.", 0, Display.CARD_HEIGHT + 10, ConsoleColor.Black);
      Display.WriteString ("Appuyez sur tab pour passer à la carte suivante.", 0, Display.CARD_HEIGHT + 11, ConsoleColor.Black);
      Display.WriteString ("Appuyez sur enter pour relancer les cartes.", 0, Display.CARD_HEIGHT + 12, ConsoleColor.Black);
    }

  }
}







