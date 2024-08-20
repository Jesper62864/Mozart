using DiceLib;

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
            int roll = 0;
            int lockedRoll = 0;
            int[] dieToKeepArray = [0];

            for (int turnPhase = 1; turnPhase < 4; turnPhase++)
            {
                Console.WriteLine($"== Player 1 Turn: Roll #{turnPhase} ==");
                Console.WriteLine("Press enter to roll");
                while (true)
                {
                    ConsoleKeyInfo keypress = Console.ReadKey(true);
                    if (keypress.Key == ConsoleKey.Enter)
                    {
                        break;
                    }

                }
            
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
                        Console.Write(" "+ lockedRoll + " | ");
                    }

                }
                Console.WriteLine("");
                Console.WriteLine("Keep? (Separate with commas)");

                string dieToKeep = Console.ReadLine();
                try
                {
                    if (dieToKeep.Contains(",") == false)
                    {
                        dieToKeepArray = [int.Parse(dieToKeep)];
                    }
                    else
                    {
                        dieToKeepArray = dieToKeep.Split(',').Select(int.Parse).ToArray();
                    }

                }
                catch
                {
                    dieToKeepArray = [0];
                }
                foreach (YahtzeeDice dice in Dicebag)
                {
                    dice.isLocked = false;
                }
                try
                {
                    foreach (int i in dieToKeepArray)
                    {
                        if (i < 6 || i > 0)
                        {
                            Dicebag[i - 1].isLocked = true;
                        }
                        else
                        {
                            Dicebag[i - 1].isLocked = false;
                        }
                    }
                }
                catch { }
                Console.WriteLine("\n");
            }
        }
    }
}
