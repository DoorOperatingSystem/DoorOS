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
                Console.WriteLine("- cls/clear = clears the screen");
                Console.WriteLine("- exit/shutdown/stop/quit = Foce shutdowns the OS");
                Console.WriteLine("- restart/reboot = Restarts the OS");
                Console.WriteLine("- home/main/close = Closes the instruction frame and opens the Main frame");
                Console.WriteLine("- file explorer/files/file search = View all files in a specific directory");
                Console.WriteLine("- read file/get file contents = Reads a file and displays it's contents");
                Console.WriteLine("- logo/flex = shows of the cool logo thingy");
            }

            // Clear the screen
            else if (command == "cls" || command == "clear")
            {
                Console.Clear();
                Doorframe.GraphicsRenderer.Logo();
            }

            // Shutdown the OS
            else if (command == "exit" || command == "shutdown" || command == "stop" || command == "quit")
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
            else if (command == "restart" || command == "reboot")
            {
                Console.Clear();
                Console.WriteLine("Restarting...");
                Cosmos.HAL.Global.PIT.Wait(3000);
                Sys.Power.Reboot();
            }

            // Exit to main frame
            else if (command == "home" || command == "main" || command == "close")
            {
                Kernel.currentPanel = Panel.MainPanel;
                Doorframe.PanelController.MainFrame();
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
            else if (command == "file explorer" || command == "files" || command == "file search")
            {
                Console.Write("Enter directory path: ");
                string dirPath = Console.ReadLine();

                foreach (var directoryEntry in Mailbox.DataGetter.GetDirectoryContents(dirPath))
                {
                    Console.WriteLine(directoryEntry.mName);
                }
            }

            // Read the contents of a file
            else if (command == "read file" || command == "get file contents")
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

