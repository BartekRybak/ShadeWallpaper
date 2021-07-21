using System;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace ShadeWallpaper
{
    class Program
    {
        static void Main(string[] args)
        {
            Ninja.Hide();

            string directoryPath = string.Empty;
            if(args.Length > 0)
            {
                directoryPath = args[0];
                if(Directory.Exists(directoryPath))
                {
                    int lastHour = 0;
                    while(true)
                    {
                        int hour = DateTime.Now.Hour;
                        switch (hour)
                        {
                            case 0: hour = 12; break;
                            case 1: hour = 1; break;
                            case 2: hour = 1; break;
                            case 3: hour = 2; break;
                            case 4: hour = 2; break;
                            case 5: hour = 3; break;
                            case 6: hour = 3; break;
                            case 7: hour = 4; break;
                            case 8: hour = 4; break;
                            case 9: hour = 5; break;
                            case 10: hour = 5; break;
                            case 11: hour = 6; break;
                            case 12: hour = 6; break;
                            case 13: hour = 7; break;
                            case 14: hour = 7; break;
                            case 15: hour = 8; break;
                            case 16: hour = 8; break;
                            case 17: hour = 9; break;
                            case 18: hour = 9; break;
                            case 19: hour = 10; break;
                            case 20: hour = 10; break;
                            case 21: hour = 11; break;
                            case 22: hour = 11; break;
                            case 23: hour = 12; break;
                        }

                        if(lastHour != hour)
                        {
                            string fullFileName = Path.GetFullPath(directoryPath + @"\" + hour + ".png");
                            if(File.Exists(fullFileName))
                            {
                                Console.WriteLine("Updating Wallpaper - " + fullFileName);
                                Wallpaper.Set(Path.GetFullPath(fullFileName));
                                lastHour = hour;
                            }
                            else
                            {
                                Console.WriteLine("File does not exits - " + fullFileName);
                            } 
                        }
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("directory does not exist - " + args[1]);
                }
            }
            else
            {
                Console.WriteLine("ShadeWallpaper by ShadeHero");
                Console.WriteLine("Usage: shadewallpaper.exe [path to directory with 12 images]");
                Console.WriteLine("files signed by the hour - 1.jpg,2.jpg...");
            }
        }

    }
}
