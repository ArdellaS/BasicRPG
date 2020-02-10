using System;
using System.Threading;

namespace InheritancePractice
{
    class Program
    {
        static void Main(string[] args)
        {

            string level = GetString("Please select difficulty: \nEasy\nNormal\nHard\n").ToLower();
            HP(level, out int hp);
            int life = hp;

            string cls = GetString("Please select a class: \nWarrior\nMage\n").ToLower();
            ClassType(cls, out string trueClass);
            ClssT(cls, out string charPick);

            CharacterSet(ref charPick, ref life);
            Console.WriteLine(trueClass);

            do
            {
                Console.Clear();
                Travel(ref life);


            } while (Continue());
            Console.WriteLine($"And thus ends the journey of the {charPick}");

        }

        static string GetString(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
        static void Travel(ref int life)
        {
            Random rand = new Random();
           

            string trapType = "";
            string roadType = "";

            Console.WriteLine($"You start your journey heading into a grand maze.");
            while (life > 0)
            {
                Danger rooms = (Danger)rand.Next(0, 5);
                Path roads = (Path)rand.Next(0, 3);
                switch (roads)
                {
                    case Path.straight:
                        roadType = $"The path continues forward and ";
                        break;
                    case Path.left:
                        roadType = $"The paths winds eerily to the left and  ";
                        break;
                    case Path.right:
                        roadType = $"The path carry foward winding sharply to the right and ";
                        break;
                    default:
                        break;
                }

                switch (rooms)
                {
                    case Danger.WallTrap:
                        trapType = $"the walls start to close in around you!";
                        break;
                    case Danger.FloorTrap:
                        trapType = $"the floor opens up under you revealing a slew of spikes!";
                        break;
                    case Danger.CielingTrap:
                        trapType = $"there are bricks falling from the ceiling one by one as you move foward.";
                        break;
                    case Danger.Safe:
                        trapType = $"the room is safe. You feel better.";
                        break;
                    default:
                        trapType = $"carry on";
                        break;
                }




                Console.WriteLine($"{roadType}{trapType}");
                Console.WriteLine("What will you do?");
                string action = GetString($"Dodge\tAttack\tRun").ToLower();

                if (action == "dodge")
                {
                    Console.WriteLine("You try to dodge, but are hit.");
                    life--;
                    Console.WriteLine($"Remainging life: {life}");
                }
                else if (action == "attack")
                {
                    Console.WriteLine("You attack the inanimate object. You hurt yourself.");
                    life--;
                    Console.WriteLine($"Remainging life: {life}");
                }
                else if (action == "run")
                {
                    Console.WriteLine("You got away safely");
                    Console.WriteLine($"Remainging life: {life}");
                }
                else
                {
                    Console.WriteLine("You hurt yourself in confusion.");
                    life--;
                    Console.WriteLine($"Remainging life: {life}");
                }
                Thread.Sleep(2000);
                Console.Clear();
            }


        }

        static void CharacterSet(ref string input, ref int life)
        {
            Warrior fighter = new Warrior(life, 8, 3);
            Mage wizard = new Mage(life, 3, 8);


            if (input == "warrior")
            {
                Console.WriteLine("Level 1 stats:");
                Console.WriteLine(fighter);
                Thread.Sleep(4000);

            }
            else if (input == "mage")
            {
                Console.WriteLine("Level 1 stats:");
                Console.WriteLine(wizard);
                Thread.Sleep(4000);
            }
        }
        static string ClassType(string input, out string output)
        {

            string cls = "";


            if (input == "warrior")
            {
                cls = "the mighty warrior!";
            }
            else if (input == "mage")
            {

                cls = "the astute mage!";
            }

            output = $"\nYou have started your adventure as {cls}\n";
            return output;
        }
        static string ClssT(string input, out string clssT)
        {
            clssT = "";

            if (input == "warrior")
            {
                clssT = "warrior";
            }
            else if (input == "mage")
            {

                clssT = "mage";
            }

            return clssT;
        }
        static int HP(string input, out int hp)
        {
            hp = 0;

            if (input == "easy")
            {
                hp = 3;
            }
            else if (input == "normal")
            {
                hp = 2;
            }
            else if (input == "hard")
            {
                hp = 1;
            }
            else
            {
                Console.WriteLine("Enter valid level.\n");
            }
            return hp;
        }
        static bool Continue()
        {
            char c;

            do
            {
                Console.WriteLine("Would you like to continue? y/n");
                c = Console.ReadKey().KeyChar;
                if (c == 'n' || c == 'N')
                {
                    return false;
                }
            } while (c != 'y' && c != 'Y');

            return true;

        }

    }
}
