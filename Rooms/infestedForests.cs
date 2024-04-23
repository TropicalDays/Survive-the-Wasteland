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
        public static bool haveEquipment = false;
        public static bool seedFound = false;
        private bool protectedHuman = false;

        internal override string CreateDescription() => @"1. [proceed deeper] Venture further into the unknown, risking encounters with hostile creatures.
2. [search] 20 minutes, Scour the undergrowth for useful items amidst the tangled vegetation.
3. [listen] Tune your ears to the forest sounds, hoping to discern any potential threats or opportunities.
4. [return] 1 hour, Return back to your Home Base.
5. [inventory] Display your inventory.";

        internal override void ReceiveChoice(string choice)
        {

            switch (choice)
            {
                case "return":
                case "4":
                    if (!ToxicWasteDump.injuredLeg)
                    {
                        Program.initialVulnerability -= TimeSpan.FromMinutes(1);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\t(Injured Leg) Travel time x0.5\n\n");
                        Console.ResetColor();
                        Program.initialVulnerability -= TimeSpan.FromMinutes(1);
                        Program.initialVulnerability -= TimeSpan.FromSeconds(30);
                    }
                    Console.WriteLine("You return to your Home Base.");
                    Game.Transition<HomeBase>();
                    break;
                case "search":
                case "2":
                    if (!seedFound)
                    {
                        Program.initialVulnerability -= TimeSpan.FromSeconds(20);
                        Console.WriteLine("Discover a treasure trove of potentially fertile seeds, ripe for cultivation.");
                        Item seed = new Item("Fertile Seed", "Perhaps there's a glimmer of hope for a few.");
                        Game.playerInventory.AddItem(seed);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n +1 Fertile Seed");
                        Console.ResetColor();
                        seedFound = true;
                    }
                    else
                    {
                        Program.initialVulnerability -= TimeSpan.FromSeconds(5);
                        Console.WriteLine("You search the dense foliage yet it yields no further discoveries.");
                    }
                    break;
                case "listen":
                case "3":
                    if (!protectedHuman)
                    {


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
                                protectedHuman = true;
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
                    }
                    else
                    {
                        Console.WriteLine("You attentively listen for any sound, but the surroundings remain peacefully silent.");
                    }
                    break;
                case "proceed deeper":
                case "1":
                    if (!haveEquipment || !Gardener.knowsTheEnd)
                    {
                        Console.WriteLine("Perhaps you're not quite prepared to delve further just now.");
                    }
                    else
                    {
                        Console.WriteLine("As you emerge from the once-infested forest, you'll find the book's wisdom affirmed: there's no trace of malevolence\n here, only sweeping vistas, invigorating air, and a promising new beginning awaiting you!");
                        Game.Finish();
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
