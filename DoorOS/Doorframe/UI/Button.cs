using System;

namespace DoorOS.Doorframe.UI
{
    public class Button
    {
        private string buttonText;

        public void init(string text)
        {
            this.buttonText = text;
        }

        public void display()
        {
            string topEdgeStuff = "/-";
            string bottomEdgeStuff = "\\-";
            for (var i = buttonText.Length; i > 0; i--)
            {
                topEdgeStuff += "-";
                bottomEdgeStuff += "-";
            }
            topEdgeStuff += "-\\";
            bottomEdgeStuff += "-/";

            Console.WriteLine(topEdgeStuff);
            Console.WriteLine("| " + buttonText + " |");
            Console.WriteLine(bottomEdgeStuff);
        }
    }
}
