using System.Collections.Generic;
using Sys = Cosmos.System;

namespace DoorOS.Mailbox
{
    public class DataGetter
    {
        public static string GetFileSystemType()
        {
            string fs_type = Sys.FileSystem.VFS.VFSManager.GetFileSystemType("0:/");
            return fs_type;
        }

        public static long GetAvaliableSpace()
        {
            long available_space = Sys.FileSystem.VFS.VFSManager.GetAvailableFreeSpace("0:/");
            return available_space;
        }

        public static List<Sys.FileSystem.Listing.DirectoryEntry> GetDirectoryContents(string path)
        {
            var directory_list = Sys.FileSystem.VFS.VFSManager.GetDirectoryListing(path);
            return directory_list;
        }
    }
}
