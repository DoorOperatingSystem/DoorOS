using System;

namespace DoorOS.Doorframe.UI
{
    public class Button
    {
        private string buttonText;
        private bool selected = false;
        private int buttonID = 0;

        public Button(string text, int ID)
        {
            this.buttonText = text;
            this.buttonID = ID;
        }

        public void checkSelection(int currentID)
        {
            if (currentID == this.buttonID)
            {
                selected = true;
            }
            else
            {
                selected = false;
            }
        }

        public void display()
        {
            string topEdgeStuff;
            string bottomEdgeStuff;

            if (selected)
            {
                topEdgeStuff = "/%";
                bottomEdgeStuff = "\\%";
                for (var i = this.buttonText.Length; i > 0; i--)
                {
                    topEdgeStuff += "%";
                    bottomEdgeStuff += "%";
                }
                topEdgeStuff += "%\\";
                bottomEdgeStuff += "%/";
            }
            else
            {
                topEdgeStuff = "/-";
                bottomEdgeStuff = "\\-";
                for (var i = this.buttonText.Length; i > 0; i--)
                {
                    topEdgeStuff += "-";
                    bottomEdgeStuff += "-";
                }
                topEdgeStuff += "-\\";
                bottomEdgeStuff += "-/";
            }

            Console.WriteLine(topEdgeStuff);
            if (selected)
            {
                Console.WriteLine("% " + this.buttonText + " %");
            }
            else
            {
                Console.WriteLine("| " + this.buttonText + " |");
            }
            Console.WriteLine(bottomEdgeStuff);
        }
    }
}
