using System;

namespace DoorOS
{
    public enum ErrorType
    {
        InvalidInstruction,
        FileReadFailed,
        InvalidDir
    }

    public class ErrorHandler
    {

        public static void Error(ErrorType errorType)
        {
            string errMessage = "";
            if (errorType == ErrorType.InvalidInstruction)
            {
                errMessage = "Failed to recognise instruction | try 'help' for a list of instructions";
            }
            else if (errorType == ErrorType.FileReadFailed)
            {
                errMessage = "Failed to read file contents | did you get the file name wrong?";
            }
            else if (errorType == ErrorType.InvalidDir)
            {
                errMessage = "Invalid Directory | try a different dir";
            }

            Console.WriteLine($"ERROR: {errMessage} (errcode: {((int) errorType)})");
        }

    }
}
