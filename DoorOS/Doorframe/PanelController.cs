using System;
using System.Collections.Generic;
using System.Text;

namespace DoorOS.Doorframe
{
    public class PanelController
    {
        public static bool instructorOpen = false;

        public static bool[] homeButtons = new bool[] {
            true,
            false
        };

        public static void Home()
        {
            UI.Button shutdownButton = new UI.Button();
            shutdownButton.init("Shutdown OS");
            shutdownButton.selected = homeButtons[0];

            UI.Button fancyButton = new UI.Button();
            fancyButton.init("ooh dynamic button sizes how fancy");
            fancyButton.selected = homeButtons[1];

            Console.Clear();
            GraphicsRenderer.Logo();
            Console.WriteLine("");
            shutdownButton.display();
            fancyButton.display();
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
