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
        Program
    }

    public class Kernel : Sys.Kernel
    {
        public static CosmosVFS fileSystem = new Sys.FileSystem.CosmosVFS();

        public static Panel currentPanel = Panel.Home;
        public static string currentDir = "0:/";

        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fileSystem);
            Console.WriteLine(Mailbox.DataGetter.GetAvaliableSpace());
            Console.WriteLine(Mailbox.DataGetter.GetFileSystemType());

            Cosmos.HAL.Global.PIT.Wait(3000);
            Console.Clear();
        }

        protected override void Run()
        {
            if (currentPanel == Panel.Home)
            {
                Doorframe.PanelController.Home();

                var keyInput = Sys.KeyboardManager.ReadKey();
                if (keyInput.Key == Sys.ConsoleKeyEx.UpArrow)
                {
                    if (Doorframe.PanelController.homeButtons[0])
                    {
                        Doorframe.PanelController.homeButtons[1] = true;
                        Doorframe.PanelController.homeButtons[0] = false;
                    }
                    else if (Doorframe.PanelController.homeButtons[1])
                    {
                        Doorframe.PanelController.homeButtons[0] = true;
                        Doorframe.PanelController.homeButtons[1] = false;
                    }
                }
                if (keyInput.Key == Sys.ConsoleKeyEx.DownArrow)
                {
                    if (Doorframe.PanelController.homeButtons[0])
                    {
                        Doorframe.PanelController.homeButtons[1] = true;
                        Doorframe.PanelController.homeButtons[0] = false;
                    }
                    else if (Doorframe.PanelController.homeButtons[1])
                    {
                        Doorframe.PanelController.homeButtons[0] = true;
                        Doorframe.PanelController.homeButtons[1] = false;
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

    }
}
