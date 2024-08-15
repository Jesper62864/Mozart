using DiceLib;
using System.Media;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Mozart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dice rng = new Dice();
            SoundPlayer player = new SoundPlayer();

            Console.WriteLine("Define instrument to play");
            Console.WriteLine("Valid instruments are: piano, clarinet, flute-harp, mbira");
            string userDefinedInstrument = Console.ReadLine(); 

            string currentDirectory = Environment.CurrentDirectory;
            bool isValidInstrument = false;
            switch (userDefinedInstrument)
            {
                case "piano":
                   isValidInstrument = true;
                   break;
                case "clarinet":
                    isValidInstrument = true;
                    break;
                case "flute-harp":
                    isValidInstrument = true;
                    break;
                case "mbira":
                    isValidInstrument = true;
                    break;

                default:
                    isValidInstrument = false;
                    userDefinedInstrument = "mbira";
                    break;
            }

            string filePath = Path.Combine(currentDirectory, "Data", userDefinedInstrument);
            string soundFile;
            int sound;
            for (int i = 0; i < 16; i++)
            {
                sound = rng.RollDie() + rng.RollDie();
                soundFile = Path.Combine(filePath, $"minuet{i}-{sound}.wav");
                Console.WriteLine($"minuet{i}-{sound}.wav");
                player.SoundLocation = soundFile;
                player.Load();
                player.PlaySync();
            }
            for (int i = 0; i < 16; i++)
            {
                sound = rng.RollDie();
                soundFile = Path.Combine(filePath, $"trio{i}-{sound}.wav");
                Console.WriteLine($"trio{i}-{sound}.wav");
                player.SoundLocation = soundFile;
                player.Load();
                player.PlaySync();
            }


        }
    }
}
