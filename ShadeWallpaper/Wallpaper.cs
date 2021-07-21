﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ShadeWallpaper
{
    class Wallpaper
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(
        UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);

        private static readonly UInt32 SPI_SETDESKWALLPAPER = 0x14;
        private static readonly UInt32 SPIF_UPDATEINIFILE = 0x01;
        private static readonly UInt32 SPIF_SENDWININICHANGE = 0x02;

        public static void Set(string path)
        {
            if(File.Exists(path))
            {
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path,
               SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
            }
        }
    }
}
