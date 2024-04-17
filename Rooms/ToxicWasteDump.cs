using Survive_the_Wasteland.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survive_the_Wasteland.Rooms
{
    internal class ToxicWasteDump : Room
    {
        bool hasAWeapon = false;
        private Random random = new Random();

        internal override string CreateDescription() => @"1. [survey] You take a moment to glance around, perhaps hoping to find something intriguing.
2. [search] Scan your surroundings, hoping to discover any valuable items.
3. []";
        //add a code from going into the hospital that you can find

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "survey":
                case "1":
                    jump1:  Console.Clear();
                    Console.WriteLine("In the distance lies a hospital, yet a mutated creature obstructs the path, suggesting that confronting it may be\n necessary to proceed toward the medical facility.");
                    char answer = Convert.ToChar(Console.ReadLine());
                    if (answer == 'y')
                    {
                        if (hasAWeapon)
                        {
                            Console.Clear();
                            Console.WriteLine("You bravely engage the mutant creature and emerge victorious, though not unscathed. It appears you may have\n sustained\n a minor injury to your leg. Exercise caution as you proceed..");
                        }
                        else
                        {
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
                    Console.WriteLine("You explore your surroundings, hoping to find something of worth, and come across a worn blade.");
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
