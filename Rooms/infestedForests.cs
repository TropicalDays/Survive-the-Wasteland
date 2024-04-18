using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Survive_the_Wasteland.Rooms
{
    internal class InfestedForests : Room
    {
        bool haveEquipment = false;
        private bool seedFound = false;

        internal override string CreateDescription() => @"1. [proceed deeper]: Venture further into the unknown, risking encounters with hostile creatures.
2. [search]: Scour the undergrowth for useful items amidst the tangled vegetation.
3. [listen]: Tune your ears to the forest sounds, hoping to discern any potential threats or opportunities.
4. [return]: Return back to your Home Base.
5. [inventory] Display your inventory.";

        internal override void ReceiveChoice(string choice)
        {

            switch (choice)
            {
                case "return":
                case "4":
                    Console.WriteLine("You return to your Home Base.");
                    Game.Transition<HomeBase>();
                    break;
                case "search":
                case "2":
                    if (!seedFound)
                    {
                        Console.WriteLine("Discover a treasure trove of potentially fertile seeds, ripe for cultivation.");
                        Item seed = new Item("Fertile Seed", "Perhaps there's a glimmer of hope for a few.");
                        Game.playerInventory.AddItem(seed);
                        Console.WriteLine("\n +1 Fertile Seed");
                        seedFound = true;
                    }
                    else
                    {
                        Console.WriteLine("The dense foliage yields no further discoveries.");
                    }
                    break;
                case "listen":
                case "3":
                jump2: Console.Clear();
                    Console.WriteLine("Imagine hearing what seems like distant screams, perhaps from another person. Would you dare to investigate? [y/n]");
                    string yn = Console.ReadLine();
                    if (yn == "y")
                    {
                    jump1: Console.Clear();
                        Console.WriteLine("Do you encounter an infected critter trying to attack a human? Would you spring into action to protect or simply\n let the drama unfold? [protect/unfold]");
                        string decision = Console.ReadLine();
                        if (decision == "protect")
                        {
                            Console.Clear();
                            Console.WriteLine("You safeguard the individual by confronting the critter, albeit at the expense of your gasmask's condition\n (it seems to be leaking quicker then normal), and receive recognition for your efforts.");
                            Program.isProtecting = true;
                        }
                        else if (decision == "unfold")
                        {
                            Console.Clear();
                            Console.WriteLine("You quietly retreat, choosing to keep your decision private, feeling remorseful for your actions.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Command");
                            goto jump1;
                        }
                    }
                    else if (yn == "n")
                    {
                        Console.Clear();
                        Console.WriteLine("You choose to remove yourself from potentially challenging circumstances.");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Command");
                        goto jump2;
                    }
                    break;
                case "proceed deeper":
                case "1":
                    if (haveEquipment == false)
                    {
                        Console.WriteLine("Perhaps considering your current equipment, it might be prudent to hold off on venturing farther. However, with the\n acquisition of suitable gear, you could potentially uncover promising rewards.");
                    }
                    else
                    {
                        Console.WriteLine("you reach the end of your quest something something");
                    }
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
    }
}
