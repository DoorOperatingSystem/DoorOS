using System;
using System.Collections.Generic;
using System.Text;

namespace DoorOS
{

    public class InstructionExecutor
    {
        public static void Execute(string command)
        {
            if (command == "help")
            {
                Console.WriteLine("- help = Shows this information");
                Console.WriteLine("- cls/clear = clears the screen");
                //Console.WriteLine();
            }

            // Clear the screen
            else if (command == "cls" || command == "clear")
            {
                Console.Clear();
                GraphicsHandler.Logo();
            }
        }
    }

}

