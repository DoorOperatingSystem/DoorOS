using Cosmos.System.FileSystem;
using System;
using Sys = Cosmos.System;

//Global.Dbg.Break();

namespace DoorOS
{
    public enum Panel
    {
        Home,
        Instructor,
        Program,
        BlueScreenOfDeath
    }

    public class Kernel : Sys.Kernel
    {
        public const string VERSION = "snapshot 10a1"; // 1.0

        public static CosmosVFS fileSystem = new Sys.FileSystem.CosmosVFS();

        public static Panel currentPanel = Panel.Home;
        public static string currentDir = "0:/";

        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fileSystem);
            Console.WriteLine(Mailbox.DataGetter.GetAvaliableSpace());
            Console.WriteLine(Mailbox.DataGetter.GetFileSystemType());

            Cosmos.HAL.Global.PIT.Wait(500);
            Console.Clear();

            Console.WriteLine($"Loading DoorOS {VERSION}");
            Console.WriteLine("Now 90% bug free!\n");

            for (int i = 200; i > 0; i--)
            {
                Console.Write(".");
                Cosmos.HAL.Global.PIT.Wait(10);
            }

            Cosmos.HAL.Global.PIT.Wait(100);
            Console.Clear();
        }

        protected override void Run()
        {
            if (currentPanel == Panel.Home)
            {
                if (Doorframe.PanelController.homeButtonIDs < 0)
                {
                    Doorframe.PanelController.homeButtonIDs = 0;
                }
                if (Doorframe.PanelController.homeButtonIDs > Doorframe.PanelController.maxID)
                {
                    Doorframe.PanelController.homeButtonIDs = Doorframe.PanelController.maxID;
                }

                Doorframe.PanelController.Home();

                var keyInput = Sys.KeyboardManager.ReadKey();

                if (keyInput.Key == Sys.ConsoleKeyEx.UpArrow)
                {
                    Doorframe.PanelController.homeButtonIDs -= 1;
                }
                if (keyInput.Key == Sys.ConsoleKeyEx.DownArrow)
                {
                    Doorframe.PanelController.homeButtonIDs += 1;
                }

                if (keyInput.Key == Sys.ConsoleKeyEx.Enter)
                {
                    if (Doorframe.PanelController.homeButtonIDs == 0)
                    {
                        currentPanel = Panel.Instructor;
                    }
                    else if (Doorframe.PanelController.homeButtonIDs == 1)
                    {
                        Shutdown();
                    }
                    else if (Doorframe.PanelController.homeButtonIDs == 2)
                    {
                        ReStart();
                    }
                }

                if (keyInput.Key == Sys.ConsoleKeyEx.LWin)
                {
                    currentPanel = Panel.Instructor;
                    Doorframe.PanelController.instructorOpen = false;
                }
            }
            if (currentPanel == Panel.Instructor && Doorframe.PanelController.instructorOpen == false)
            {
                Doorframe.PanelController.Instructor();
            }

            if (currentPanel == Panel.Instructor)
            {
                GetInstructionInput();
            }

            if (currentPanel == Panel.BlueScreenOfDeath)
            {
                Console.Clear();

                Console.WriteLine("                                                                               ");
                Console.WriteLine("             ##                                                                ");
                Console.WriteLine("   ###      ##            ##      ##  ##    ##       ######    ##    ##        ");
                Console.WriteLine("   ###     ##             ##      ##  ##    ##      ##    ##   ##    ##        ");
                Console.WriteLine("           ##             ##      ##  ##    ##     ##      ##  ##    ##        ");
                Console.WriteLine("           ##             ##      ##  ########     ##      ##  ########        ");
                Console.WriteLine("           ##             ##      ##  ##    ##     ##      ##  ##    ##        ");
                Console.WriteLine("   ###     ##              ##    ##   ##    ##      ##    ##   ##    ##        ");
                Console.WriteLine("   ###      ##              ######    ##    ##       ######    ##    ##        ");
                Console.WriteLine("             ##                                                                ");
                Console.WriteLine("                                                                               ");
                Console.WriteLine("                                                                               ");
                Console.WriteLine("                          Something that was not expected has happened         ");
                Console.WriteLine("                                     at this point in time!                    ");
                Console.WriteLine("                                                                               ");
                Console.WriteLine("                                                                               ");
                Console.WriteLine("                                                                               ");
                Console.WriteLine("                               This is the opposite of good!!!1!               ");
                Console.WriteLine("                                                                               ");
                Console.WriteLine("                                                                               ");
                Console.WriteLine("                                                                               ");
                Console.WriteLine("                                                                               ");
                Console.WriteLine("                                                                               ");
                Console.WriteLine("Press any key to reboot OS...                                                  ");

                Sys.KeyboardManager.ReadKey();

                Sys.Power.Reboot();
            }

            //var keyInput = Sys.KeyboardManager.ReadKey();

            /*
            if (currentPanel == Panel.InstructionPanel)
            {
                Console.Clear();
                Doorframe.GraphicsRenderer.Logo();
                GetInstructionInput();
            }

            if (keyInput.Key == Sys.ConsoleKeyEx.LWin && currentPanel != Panel.InstructionPanel)
            {
                currentPanel = Panel.MainPanel;
                Doorframe.PanelController.MainFrame();
            }       
            */
        }

        static void GetInstructionInput()
        {
            Console.Write($"\n{currentDir}>>> ");
            string userInput = Console.ReadLine();

            InstructionExecutor.Execute(userInput);
        }

        public static void Shutdown()
        {
            Console.Clear();

            for (var shutdownPercent = 0; shutdownPercent <= 100; shutdownPercent += 5)
            {
                Console.WriteLine($"Shutting down... ({shutdownPercent}%)");
                Cosmos.HAL.Global.PIT.Wait(10);
            }

            Cosmos.HAL.Global.PIT.Wait(1000);
            Console.WriteLine("Shutdown process complete, see ya next time!");
            Cosmos.HAL.Global.PIT.Wait(1000);
            Sys.Power.Shutdown();
        }

        public static void ReStart()
        {
            Console.Clear();
            Console.WriteLine("Restarting...");
            Cosmos.HAL.Global.PIT.Wait(3000);
            Sys.Power.Reboot();
        }

    }
}
