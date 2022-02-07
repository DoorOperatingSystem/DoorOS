using System;
using Sys = Cosmos.System;

namespace DoorOS
{

    public class InstructionExecutor
    {
        public static void Execute(string command)
        {
            string[] commandArgs = command.Split(" ");

            if (commandArgs[0] == "help")
            {
                Console.WriteLine("- help = Shows this information");
                Console.WriteLine("- cls/clear = Clears the screen");
                Console.WriteLine("- home = Opens the home panel");
                Console.WriteLine("- goto <path> = Changes the current directory");
                Console.WriteLine("- explorer = View all files in a specific directory");
                Console.WriteLine("- read <file name> = Reads a file and displays it's contents");
            }

            // Clear the screen
            else if (commandArgs[0] == "cls" || commandArgs[0] == "clear")
            {
                Console.Clear();
                Doorframe.GraphicsRenderer.Logo();
            }

            // Exit to main frame
            else if (commandArgs[0] == "home")
            {
                Kernel.currentPanel = Panel.Home;
                Doorframe.PanelController.instructorOpen = false;
                //Doorframe.PanelController.Home();
            }

            else if (commandArgs[0] == "goto")
            {
                if (commandArgs[1] == "previous")
                {
                    Console.WriteLine("hold on there partner, that don't work yet");
                }
                else if (commandArgs[1] == "root" || commandArgs[1] == "top")
                {
                    Kernel.currentDir = "0:/";
                }
                else
                {
                    Kernel.currentDir += commandArgs[1] + "/";
                }
            }

            // View all files in a directory
            else if (commandArgs[0] == "explorer")
            {
                foreach (var directoryEntry in Mailbox.DataGetter.GetDirectoryContents(Kernel.currentDir))
                {
                    Console.WriteLine(directoryEntry.mName);
                }
            }

            // Read the contents of a file
            else if (commandArgs[0] == "read")
            {
                string fileContents = Mailbox.FileManager.ReadFile(Kernel.currentDir + commandArgs[1]);

                if (fileContents == "UH OH AN ERROR HAS OCCURED!!!")
                {
                    ErrorHandler.Error(ErrorType.FileReadFailed);
                }
                else
                {
                    Console.WriteLine(fileContents);
                }
            }

            // ERROR
            else
            {
                ErrorHandler.Error(ErrorType.InvalidInstruction);
            }
        }
    }

}

