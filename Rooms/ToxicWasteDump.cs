using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survive_the_Wasteland.Rooms
{
    internal class ToxicWasteDump : Room
    {
        private bool enteredCode = false;

        private Random random = new Random();
        private bool wornBladeFound = false;
        public static bool injuredLeg = false;

        

        internal override string CreateDescription() => @"1. [survey] You take a moment to glance around, perhaps hoping to find something intriguing.
2. [search] 15 minutes, Scan your surroundings, hoping to discover any valuable items.
3. [structure] 5 minutes, Stroll over to a quaint structure nestled by the waterfront.
4. [return] 1 hour, Return back to your Home Base
5. [inventory] Display your inventory";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "survey":
                case "1":
                jump1: Console.Clear();
                    Console.WriteLine("In the distance lies a hospital, yet a mutated creature obstructs the path, suggesting that confronting it may be\n necessary to proceed toward the medical facility.");
                    Console.WriteLine("--");
                    Console.WriteLine("Do you wish to proceed at this time?[y/n]");
                    char answer = Convert.ToChar(Console.ReadLine());
                    if (answer == 'y')
                    {
                        if (wornBladeFound)
                        {
                            Console.Clear();
                            Console.WriteLine("You bravely engage the mutant creature and emerge victorious, though not unscathed. It appears you may have\n sustained a minor injury to your leg. Exercise caution as you proceed.\n");
                            injuredLeg = true;
                        jump3: Console.WriteLine("--");
                            Console.WriteLine("Do you wish to proceed at this time?[y/n]");
                            char proceed = Convert.ToChar(Console.ReadLine());
                            if (proceed == 'y')
                            {
                                Console.Clear();
                                Console.WriteLine("You carefully proceed to the hospital, attending to your injured leg with each step.");
                                Game.Transition<Hospital>();
                            }
                            else if (proceed == 'n')
                            {
                                Console.Clear();
                                Console.WriteLine("You stay in the main location of the Toxtic Waste Dump.");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid Command");
                                goto jump3;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            DisplayRandomEquipmentMessage();
                        }
                    }
                    else if (answer == 'n')
                    {
                        Console.Clear();
                        Console.WriteLine("You opt for a safer approach and choose not to pursue it.");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Command");
                        goto jump1;
                    }
                    break;
                case "search":
                case "2":
                    if (!wornBladeFound)
                    {
                        Program.initialVulnerability -= TimeSpan.FromSeconds(15);
                        Console.WriteLine("You explore your surroundings, hoping to find something of worth, and come across a worn blade.\n");
                        Console.WriteLine("\nWhile it currently doesn't appear to be functioning optimally, there might be someone with the skills to improve it.");
                        Item blade = new Item("Worn Blade", "A blade, though not currently optimized for formal combat engagements");
                        Game.playerInventory.AddItem(blade);
                        wornBladeFound = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n +1 Worn Blade");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("You've exhausted the discovery of valuable items in your immediate vicinity.");
                    }
                    break;
                case "structure":
                case "3":
                    if (!enteredCode)
                    {
                        Program.initialVulnerability -= TimeSpan.FromSeconds(5);
                    jump2: Console.Clear();
                        Console.WriteLine("You encounter a sturdily constructed building with a keypad lock with a 5 digit code, prompting curiosity about where \none might procure the access code.");
                        Console.WriteLine("Do you want to attempt the code?[y/n]");
                        char yn = Convert.ToChar(Console.ReadLine());
                        if (yn == 'y')
                        {
                            Console.Clear();
                        jump3: Console.WriteLine("1. [Return] Leave the buidlings front entrance\n2. [inventory] Display your inventory.\n Please Enter Code: _ _ _ _ _\n--2");
                            string option = Console.ReadLine();

                            if (option == Hospital.generatedPassword)
                            {
                                Console.WriteLine("The code is correct. You unlock the door and enter the building.");
                                enteredCode = true;
                                Console.Write("Press \"Enter\" to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("You'll notice something akin to a Scuba tank, enhancing your ability to travel extended distances while ensuring a \ncontinuous supply of fresh air.");
                                Item tank = new Item("Scuba Tank", "Enhancing your journey's reach, a scuba tank provides extended travel capabilities");
                                Game.playerInventory.AddItem(tank);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\n +1 Scuba Tank");
                                Console.ResetColor();
                                Console.Write("\nPress \"Enter\" to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("1. [Return] Leave the building.");
                            }
                            else if (option == "return" || option == "1")
                            {
                                Console.Clear();
                                Console.WriteLine("You have returned to the main location of the Toxtic Waste Dump");
                            }
                            else if (option == "inventory" || option == "2")
                            {
                                Console.WriteLine("You look inside your inventory.");
                                Game.playerInventory.DisplayInventory();
                                goto jump3;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Incorrect code.");
                                goto jump3;
                            }


                        }
                        else if (yn == 'n')
                        {
                            Console.Clear();
                            Console.WriteLine("You opt for a safer approach and choose not to pursue it.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Command");
                            goto jump2;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You've already entered the code and explored the building.");
                    }
                    break;
                case "return":
                case "4":
                    if (!injuredLeg)
                    {
                        Program.initialVulnerability -= TimeSpan.FromMinutes(1);
                    }
                    else
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.Write("\t(Injured Leg) Travel time x0.5\n\n");
                        Console.ResetColor();
                        Program.initialVulnerability -= TimeSpan.FromMinutes(1);
                        Program.initialVulnerability -= TimeSpan.FromSeconds(30);
                    }
                    Console.WriteLine("You return to the Home Base");
                    Game.Transition<HomeBase>();
                    break;
                case "inventory":
                case "5":
                    Console.WriteLine("You look inside your inventory.");
                    Game.playerInventory.DisplayInventory();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
        private void DisplayRandomEquipmentMessage()
        {
            string[] messages = new string[]
            {
                "It might be wise to reconsider engaging the mutant monster without arming yourself.",
                "It might be safer to equip yourself with a weapon before engaging the mutant monster.",
                "It's advisable not to engage the mutant monster without arming yourself first."
            };

            int index = random.Next(messages.Length);
            Console.WriteLine(messages[index]);
        }
    }
}
