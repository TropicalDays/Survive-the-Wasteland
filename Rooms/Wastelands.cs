using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survive_the_Wasteland.Rooms
{
    internal class Wastelands : Room
    {
        public static bool repairKitFound = false;
        private bool suitAndGasMaskFound = false;

        internal override string CreateDescription() => @"1. [Search] 15 minutes, Scour the wasteland for valuable resources amidst the toxic hazards.
2. [investigate] 15 minutes, Approach the decrepit building to see if there are any salvageable items or clues inside.
3. [survey] Take a moment to assess your surroundings for potential threats or hidden treasures.
4. [return] 30 minutes, Return back to your Home Base.
5. [inventory] Display your inventory";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "search":
                case "1":
                    if (!repairKitFound)
                    {
                        Program.initialVulnerability -= TimeSpan.FromSeconds(15);
                        Console.WriteLine("Exploring the wasteland, you stumble upon a repair kit, essential for restoring any broken equipment you may encounter.");
                        Item RepairKit = new Item("Repair Kit", "Restores broken equipment.");
                        Game.playerInventory.AddItem(RepairKit);
                        repairKitFound =true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n +1 Repair Kit!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("You've already found everything valuable here.");
                    }
                    break;
                case "investigate":
                case "2":
                    if (!suitAndGasMaskFound)
                    {
                        Program.initialVulnerability -= TimeSpan.FromSeconds(15);
                        Console.WriteLine("As you explore the aging structure, you discover essential protective gear like a hazmat suit and gas mask, which could\n be valuable for further exploration in other locations.");
                        Item hazmatSuit = new Item("Hazmat Suit", "Provides a safeguard against potentially contaminated environments.");
                        Game.playerInventory.AddItem(hazmatSuit);
                        Item gasMask = new Item("Gas Mask", "Enables you to comfortably breathe in specific zones.");
                        Game.playerInventory.AddItem(gasMask);
                        Location.hasHazardEquipment = true;
                        suitAndGasMaskFound = true; 
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n +1 Gas Mask!");
                        Console.WriteLine("\n +1 Hazmat Suit!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("There's nothing particularly noteworthy left to seize");
                    }
                    break;
                case "survey":
                case "3":
                    Console.WriteLine("As you scan the horizon, a subtle shift catches your attention, stirring a sense of unease. Doubts surface as you\n discern peculiar, almost otherworldly forms in the distance, leaving you with a chilling sensation of disbelief.");
                    break;
                case "home base":
                case "4":
                    Game.Transition<HomeBase>();
                    if (!ToxicWasteDump.injuredLeg)
                    {
                        Program.initialVulnerability -= TimeSpan.FromSeconds(30);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\t(Injured Leg) Travel time x0.5\n\n");
                        Console.ResetColor();
                        Program.initialVulnerability -= TimeSpan.FromSeconds(45);
                    }
                    Console.WriteLine("You return back to your Home Base.");
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
