using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survive_the_Wasteland.Rooms
{
    internal class Death : Room
    {

        internal override string CreateDescription()
        {
            string darkRed = "\u001b[31m";
            string resetColor = "\u001b[0m";

            return darkRed + "You Have Died...\n\n" + resetColor + "Type '1' to continue.";
        }

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Program.stopwatch = Stopwatch.StartNew();
                    Program.initialVulnerability = TimeSpan.FromMinutes(4);
                    Game.Transition<HomeBase>();
                    break;
            }

        }

    }
}
