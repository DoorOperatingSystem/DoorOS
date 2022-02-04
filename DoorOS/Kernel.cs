using Cosmos.System.FileSystem;
using System;
using Sys = Cosmos.System;

//Global.Dbg.Break();

namespace DoorOS
{
    public enum Panel
    {
        InstructionPanel,
        MainPanel
    }

    public class Kernel : Sys.Kernel
    {
        public static CosmosVFS fileSystem = new Sys.FileSystem.CosmosVFS();

        public static Panel currentPanel = Panel.InstructionPanel;
        public static string currentDir = "0:/";

        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fileSystem);
            Console.WriteLine(Mailbox.DataGetter.GetAvaliableSpace());
            Console.WriteLine(Mailbox.DataGetter.GetFileSystemType());

            Cosmos.HAL.Global.PIT.Wait(3000);
            Console.Clear();
            Doorframe.GraphicsRenderer.Logo();
        }

        protected override void Run()
        {
            var keyInput = Sys.KeyboardManager.ReadKey();

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
        }

        static void GetInstructionInput()
        {
            Console.Write($"\n{currentDir}>>> ");
            string userInput = Console.ReadLine();

            InstructionExecutor.Execute(userInput);
        }

    }
}
