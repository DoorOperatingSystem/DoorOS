using System;
using System.Collections.Generic;
using System.Text;

namespace DoorOS.Doorframe
{
    public class PanelController
    {
        public static bool instructorOpen = false;

        public static int homeButtonIDs = 0;
        public static int maxID = 2;

        public static void Home()
        {
            UI.Button instructorButton = new UI.Button("Goto Instructor", 0);
            instructorButton.checkSelection(homeButtonIDs);

            UI.Button shutdownButton = new UI.Button("Shutdown OS", 1);
            shutdownButton.checkSelection(homeButtonIDs);

            UI.Button restartButton = new UI.Button("Restart OS", 2);
            restartButton.checkSelection(homeButtonIDs);

            Console.Clear();
            GraphicsRenderer.Logo();
            Console.WriteLine("");

            instructorButton.display();
            Console.WriteLine("\n");
            shutdownButton.display();
            restartButton.display();
        }

        public static void Instructor()
        {
            instructorOpen = true;
            Console.Clear();
            GraphicsRenderer.Logo();
            //GetInstructionInput();
        }
    }
}
