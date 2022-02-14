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

            // Debugging instructions
            else if (commandArgs[0] == "debug")
            {
                try
                {
                    // Version
                    if (commandArgs[1] == "version")
                    {
                        Console.WriteLine(Kernel.VERSION);
                    }

                    // Crash
                    else if (commandArgs[1] == "crash")
                    {
                        Kernel.currentPanel = Panel.BlueScreenOfDeath;
                    }

                    // Nope
                    else
                    {
                        Console.WriteLine("na");
                    }
                }
                catch
                {
                    Console.WriteLine("na");
                }
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

            // Change current directory
            else if (commandArgs[0] == "goto")
            {
                if (commandArgs[1] == "previous")
                {
                    string[] dirParts = Kernel.currentDir.Split("/");
                    string newDir = "";

                    int partNumber = 0;
                    foreach (var value in dirParts)
                    {
                        if (partNumber != dirParts.Length - 1)
                        {
                            newDir += dirParts[partNumber] + "/";
                        }
                        partNumber += 1;
                    }

                    Kernel.currentDir = newDir;
                    //Console.WriteLine("hold on there partner, that don't work yet");
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
                try
                {
                    foreach (var directoryEntry in Mailbox.DataGetter.GetDirectoryContents(Kernel.currentDir))
                    {
                        Console.WriteLine(directoryEntry.mName);
                    }
                }
                catch
                {
                    ErrorHandler.Error(ErrorType.InvalidDir);
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

            else if (commandArgs[0] == "loadfor")
            {
                for (int time = (int)Int64.Parse(commandArgs[1]); time > 0; time -= 1)
                {
                    Console.Write(".");
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

