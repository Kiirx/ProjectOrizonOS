﻿using System;
using System.Text;
using Sys = Cosmos.System;

namespace ProjectOrizonOS.Shell.Cmds.File
{
    internal class cCat
    {
        public static void Cat(string file)
        {
            try
            {
                var filed = Sys.FileSystem.VFS.VFSManager.GetFile(Kernel.current_directory + file);
                var file_stream = filed.GetFileStream();

                if (file_stream.CanRead)
                {
                    byte[] text_to_read = new byte[file_stream.Length];
                    file_stream.Read(text_to_read, 0, (int)file_stream.Length);
                    Kernel.shell.WriteLine(Encoding.Default.GetString(text_to_read));
                }
                else
                {
                    Kernel.shell.WriteLine("SkippleOS is needing read permissions for this file.", type: 3);
                }
            }
            catch (Exception ex)
            {
                Kernel.shell.WriteLine(ex.ToString(), type: 3);
            }
        }
    }
}
