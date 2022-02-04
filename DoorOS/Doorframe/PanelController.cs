using System;
using System.Collections.Generic;
using System.Text;

namespace DoorOS.Doorframe
{
    public class PanelController
    {
        public static void MainFrame()
        {
            UI.Button shutdownButton = new UI.Button();
            shutdownButton.init("Shutdown OS");

            UI.Button fancyButton = new UI.Button();
            fancyButton.init("ooh dynamic button sizes how fancy");

            Console.Clear();
            GraphicsRenderer.Logo();
            Console.WriteLine("");
            shutdownButton.display();
            fancyButton.display();
        }
    }
}
