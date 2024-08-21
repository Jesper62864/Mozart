using DiceLib;
using System.Diagnostics;
using Yahtzee.Classes;

namespace Yahtzee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Yahtzee");
            List<YahtzeeDice> Dicebag = new List<YahtzeeDice>()
            {
                new YahtzeeDice(),
                new YahtzeeDice(),
                new YahtzeeDice(),
                new YahtzeeDice(),
                new YahtzeeDice()
            };
            List<ScoreCategory> ScoreCategories = new List<ScoreCategory>()
            {
                new ScoreCategory("Aces", "Any amount of 1s, scores the sum.")
            };
            int roll = 0;
            int lockedRoll = 0;
            int lockedDice = -1;
            int[] dieToKeepArray = [0];

            for (int turnPhase = 1; turnPhase < 4; turnPhase++)
            {
                Console.SetCursorPosition(0,0);
                Console.WriteLine($"== Player 1 Turn: Roll #{turnPhase} ==");
                Console.WriteLine("Press enter to roll");
                //while (true)
                //{
                //    ConsoleKeyInfo keypress = Console.ReadKey(true);
                //    if (keypress.Key == ConsoleKey.Enter)
                //    {
                //        break;
                //    }

                //}
            
                Console.WriteLine("\n");
                Console.Write("|");

                foreach (YahtzeeDice dice in Dicebag)
                {
                    if (dice.isLocked == false)
                    {
                        roll = dice.RollDie();
                        Console.Write(" " + roll + " |");

                    }
                    else
                    {
                        lockedRoll = dice.LastRoll;
                        Console.Write(" ");
                        Console.Write(lockedRoll.ToString(), Console.ForegroundColor = ConsoleColor.Red);
                        Console.Write(" |", Console.ForegroundColor = ConsoleColor.White);
                    }

                }
                Console.WriteLine("");
                Console.WriteLine("Keep? (Separate with commas)");
                ConsoleKeyInfo keypress;
                do
                {
                    keypress = Console.ReadKey(true);
                    switch (keypress.Key)
                    {
                        case ConsoleKey.D1:
                            lockedDice = 0;
                            
                            break;
                        case ConsoleKey.D2:
                            lockedDice = 1;
                            break;
                        case ConsoleKey.D3:
                            lockedDice = 2;
                            break;
                        case ConsoleKey.D4:
                            lockedDice = 3;
                            break;
                        case ConsoleKey.D5:
                            lockedDice = 4;
                            break;
                        default:
                            lockedDice = -1;
                            break;
                    }
                    if (lockedDice != -1)
                    {
                        Console.SetCursorPosition(2 + 4 * lockedDice, 4);
                        if (Dicebag[lockedDice].isLocked == false)
                        {
                            Console.Write(Dicebag[lockedDice].LastRoll.ToString(), Console.ForegroundColor = ConsoleColor.Red);
                            Dicebag[lockedDice].isLocked = true;
                        }
                        else
                        {
                            Console.Write(Dicebag[lockedDice].LastRoll.ToString(), Console.ForegroundColor = ConsoleColor.White);
                            Dicebag[lockedDice].isLocked = false;
                        }
                    }
                    
                    

                } while (keypress.Key != ConsoleKey.Enter);


                Console.WriteLine("\n", Console.ForegroundColor = ConsoleColor.White);
                Console.Clear();
            }
        }
    }
}
