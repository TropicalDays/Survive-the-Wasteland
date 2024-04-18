using Survive_the_Wasteland.Rooms;
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
       public static bool hasAWeapon = false;
        private Random random = new Random();

        internal override string CreateDescription() => @"1. [survey] You take a moment to glance around, perhaps hoping to find something intriguing.
2. [search] Scan your surroundings, hoping to discover any valuable items.
3. [structure] Stroll over to a quaint structure nestled by the waterfront.
4. [return] Return back to your Home Base
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
                        if (hasAWeapon)
                        {
                            Console.Clear();
                            Console.WriteLine("You bravely engage the mutant creature and emerge victorious, though not unscathed. It appears you may have\n sustained a minor injury to your leg. Exercise caution as you proceed.\n");
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
                    Console.WriteLine("You explore your surroundings, hoping to find something of worth, and come across a worn blade.\n");
                    Console.WriteLine("\nWhile it currently doesn't appear to be functioning optimally, there might be someone with the skills to improve it.");
                    Item blade = new Item("Worn Blade", "A blade, though not currently optimized for formal combat engagements");
                    Game.playerInventory.AddItem(blade);
                    hasAWeapon = true;
                    Console.WriteLine("\n +1 Worn Blade");
                    break;
                case "structure":
                case "3":
                jump2: Console.Clear();
                    Console.WriteLine("You encounter a sturdily constructed building with a keypad lock with a 5 digit code, prompting curiosity about where \none might procure the access code.");
                    Console.WriteLine("Do you want to attempt the code?[y/n]");
                    char yn = Convert.ToChar(Console.ReadLine());
                    if (yn == 'y')
                    {
                        Console.Clear();
                       jump3: Console.WriteLine("1. [Return] Leave the buidlings front entrance\n Please Enter Code: _ _ _ _ _");
                        string option = Console.ReadLine();
                        if (option == Hospital.generatedPassword)
                        {
                            Console.WriteLine("The code is correct. You unlock the door and enter the building.");
                            Console.Write("Press \"Enter\" to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            Console.WriteLine("You'll notice something akin to a Scuba tank, enhancing your ability to travel extended distances while ensuring a \ncontinuous supply of fresh air.");
                            Item tank = new Item("Scuba Tank", "Enhancing your journey's reach, a scuba tank provides extended travel capabilities");
                            Game.playerInventory.AddItem(tank);
                            Console.WriteLine("\n +1 Scuba Tank");
                            Console.Write("\nPress \"Enter\" to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            Console.WriteLine("1. [Return] Leave the building\n2. [search] Explore additional items that could be of utility. ");
                            string choose = Console.ReadLine();
                            switch (choose)
                            {
                                case "return":
                                case "1":
                                    Console.WriteLine("You leave the building.");
                                    break;
                                case "search":
                                case "2":
                                    Console.WriteLine("You discover no other noteworthy items within the premise.");
                                    Console.WriteLine("You leave the building.");
                                    break;
                            }
                        }
                        else if (option == "return" || option == "1")
                        {
                            Console.Clear();
                            Console.WriteLine("You have returned to the main location of the Toxtic Waste Dump");
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
                    break;
                case "return":
                case "4":
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
