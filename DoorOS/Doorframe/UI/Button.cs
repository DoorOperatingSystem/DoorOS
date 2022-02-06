using System;

namespace DoorOS.Doorframe.UI
{
    public class Button
    {
        private string buttonText;
        public bool selected = false;

        public void init(string text)
        {
            this.buttonText = text;
        }

        public void display()
        {
            string displayText = buttonText;
            if (selected)
            {
                displayText = ">> " + buttonText + " <<";
            }

            string topEdgeStuff = "/-";
            string bottomEdgeStuff = "\\-";
            for (var i = displayText.Length; i > 0; i--)
            {
                topEdgeStuff += "-";
                bottomEdgeStuff += "-";
            }
            topEdgeStuff += "-\\";
            bottomEdgeStuff += "-/";

            Console.WriteLine(topEdgeStuff);
            Console.WriteLine("| " + displayText + " |");
            Console.WriteLine(bottomEdgeStuff);
        }
    }
}
