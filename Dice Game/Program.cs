using DiceLib;

namespace Dice_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userDefinedDieCount;
            bool isValidInput = false;

            int dieCount = 0;
            int roll = 0;
            int throwCount = 0;
            int sixCount = 0;
            bool isAllSixes = false;

            Dice dice = new Dice();
            while (isValidInput == false)
            {
                Console.WriteLine("How many dice to throw?");
                Console.WriteLine("Note this must be an integer.");

                userDefinedDieCount = Console.ReadLine();
                isValidInput = int.TryParse(userDefinedDieCount, out dieCount);
                if (isValidInput == false)
                {
                    Console.WriteLine("Invalid input: Must be integer.");
                }
            }
            // Roll once just for fun.
            Console.WriteLine($"Rolling {dieCount} die");
            for (int i = 0; i < dieCount; i++)
            {
                roll = (dice.RollDie());

                Console.Write(roll + " ");
            }
            Console.WriteLine($"\n\n");

            // How many throws until it hits all sixes.
            while (isAllSixes == false)
            {
                throwCount++;
                sixCount = 0;
                for (int i = 0; i < dieCount; i++)
                {
                    
                    roll = (dice.RollDie());
                    if (roll == 6)
                    {
                        sixCount++;
                        if (sixCount == dieCount)
                        {
                            Console.WriteLine($"It took {throwCount} throws to reach all sixes.");
                            isAllSixes = true;
                        }
                    }                 

                }                
            }
        }
    }
}
