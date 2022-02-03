using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

//Global.Dbg.Break();

namespace DoorOS
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Console.Clear();
            GraphicsHandler.Logo();
        }

        protected override void Run()
        {
            Console.Write("\n>>> ");
            string userInput = Console.ReadLine();

            InstructionExecutor.Execute(userInput);
        }

    }
}
