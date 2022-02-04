using System;
using System.Text;
using Sys = Cosmos.System;

namespace DoorOS.Mailbox
{
    public class FileManager
    {
        public static string ReadFile(string path)
        {
            try
            {
                var file = Sys.FileSystem.VFS.VFSManager.GetFile(path);
                var fileStream = file.GetFileStream();

                if (fileStream.CanRead)
                {
                    byte[] text_to_read = new byte[fileStream.Length];
                    fileStream.Read(text_to_read, 0, (int)fileStream.Length);
                    return Encoding.Default.GetString(text_to_read);
                }
            }
            catch (Exception e)
            {
                return "UH OH AN ERROR HAS OCCURED!!!";
            }

            return "if you can see this something is VERY wrong :O";
        } 
    }
}
