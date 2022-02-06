using System;
using Sys = Cosmos.System;

namespace DoorOS
{

    public class InstructionExecutor
    {
        public static void Execute(string command)
        {
            if (command == "help")
            {
                Console.WriteLine("- help = Shows this information");
                Console.WriteLine("- shutdown = Shutdowns the OS");
                Console.WriteLine("- restart = Restarts the OS");
                Console.WriteLine("- cls/clear = Clears the screen");
                Console.WriteLine("- home = Opens the home panel");
                Console.WriteLine("- file explorer = View all files in a specific directory");
                Console.WriteLine("- read file = Reads a file and displays it's contents");
            }

            // Clear the screen
            else if (command == "cls" || command == "clear")
            {
                Console.Clear();
                Doorframe.GraphicsRenderer.Logo();
            }

            // Shutdown the OS
            else if (command == "shutdown")
            {
                Console.Clear();

                for (var shutdownPercent = 0; shutdownPercent <= 100; shutdownPercent += 10)
                {
                    Console.WriteLine($"Shutting down... ({shutdownPercent}%)");
                    Cosmos.HAL.Global.PIT.Wait(100);
                }

                Cosmos.HAL.Global.PIT.Wait(1000);
                Console.WriteLine("Shutdown process complete, see ya next time!");
                Cosmos.HAL.Global.PIT.Wait(1000);
                Sys.Power.Shutdown();
            }

            // Restart the OS
            else if (command == "restart")
            {
                Console.Clear();
                Console.WriteLine("Restarting...");
                Cosmos.HAL.Global.PIT.Wait(3000);
                Sys.Power.Reboot();
            }

            // Exit to main frame
            else if (command == "home")
            {
                Kernel.currentPanel = Panel.Home;
                Doorframe.PanelController.instructorOpen = false;
                //Doorframe.PanelController.Home();
            }

            else if (command == "goto")
            {
                Console.Write("Enter directory path: ");
                string dirPath = Console.ReadLine();

                if (dirPath == "previous")
                {
                    Console.WriteLine("hold on there partner, that don't work yet");
                }
                else if (dirPath == "root" || dirPath == "top")
                {
                    Kernel.currentDir = "0:/";
                }
                else
                {
                    Kernel.currentDir += dirPath + "/";
                }
            }

            // View all files in a directory
            else if (command == "file explorer")
            {
                Console.Write("Enter directory path: ");
                string dirPath = Console.ReadLine();

                foreach (var directoryEntry in Mailbox.DataGetter.GetDirectoryContents(dirPath))
                {
                    Console.WriteLine(directoryEntry.mName);
                }
            }

            // Read the contents of a file
            else if (command == "read file")
            {
                Console.Write("Enter file path: ");
                string filePath = Console.ReadLine();

                string fileContents = Mailbox.FileManager.ReadFile(filePath);

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

