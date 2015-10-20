using System;
using System.Net;
using System.IO;

namespace MinecraftServerManager.Utils
{
    class Main
    {
        public static readonly string[] EngineVersions = new string[] { "1.8.8", "1.8.7", "1.8.6", "1.8.5", "1.8.5", "1.8.3", "1.8", "1.7.10", "1.7.9", "1.7.5", "1.7.2" };

        public static readonly string MainDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + "MinecraftServerManager" + Path.DirectorySeparatorChar;
        public static readonly string OldMainDirectory1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +  Path.DirectorySeparatorChar + "MinecraftServerCreator" + Path.DirectorySeparatorChar;
        public static readonly string ServersDirectory = MainDirectory + "Servers" + Path.DirectorySeparatorChar;
        public static readonly string RemoteDirectory = MainDirectory + "Remote" + Path.DirectorySeparatorChar;
        public static readonly string ImportDirectory = MainDirectory + "Import" + Path.DirectorySeparatorChar;
        public static readonly string EnginesDirectory = MainDirectory + "Engines" + Path.DirectorySeparatorChar;
        public static readonly string TempDirectory = MainDirectory + "Temp" + Path.DirectorySeparatorChar;
        public static readonly string DataDirectory = MainDirectory + "Data" + Path.DirectorySeparatorChar;
        public static readonly string TempRemoteDirectory = TempDirectory + "Remote" + Path.DirectorySeparatorChar;

        public static readonly int LicenseVersion = 1;

        public static void Delete(String filename)
        {
            if (File.Exists(filename))
                File.Delete(filename);
            if (Directory.Exists(filename))
                Directory.Delete(filename);
        }

        public static bool IsLinux
        {
            get
            {
                return Environment.OSVersion.Platform == PlatformID.Unix;
            }
        }

        public static bool HasInternetConnection()
        {
            try
            {
                IPHostEntry i = Dns.GetHostEntry("google.com");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
