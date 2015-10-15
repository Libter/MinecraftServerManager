using System;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Globalization;

namespace MinecraftServerManager
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            if (Directory.Exists(Utils.Main.OldMainDirectory1))
            {
                Directory.Move(Utils.Main.OldMainDirectory1, Utils.Main.MainDirectory);
            }
            Directory.CreateDirectory(Utils.Main.MainDirectory);
            Directory.CreateDirectory(Utils.Main.ServersDirectory);
            Directory.CreateDirectory(Utils.Main.RemoteDirectory);
            Directory.CreateDirectory(Utils.Main.ImportDirectory);
            Directory.CreateDirectory(Utils.Main.EnginesDirectory);
            Directory.CreateDirectory(Utils.Main.TempDirectory);
            Directory.CreateDirectory(Utils.Main.DataDirectory);
            foreach (string remoteOldFile in Directory.GetFiles(Utils.Main.RemoteDirectory))
            {
                if (Path.GetExtension(remoteOldFile) == ".xml")
                {
                    string newDirName = remoteOldFile.Remove(remoteOldFile.Length - 4, 4) + Path.DirectorySeparatorChar;
                    Directory.CreateDirectory(newDirName);
                    File.Move(remoteOldFile, newDirName + "MainData.xml");
                }
            }
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                String resourceName = "MinecraftServerManager." +
                    new AssemblyName(args.Name).Name + ".dll"; 
                using (var stream = Assembly.GetExecutingAssembly()
                                            .GetManifestResourceStream(resourceName))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };

            if (File.Exists(Utils.Main.DataDirectory + "Language.xml"))
            {
                Data.Language language = Data.Language.Deserialize();
                Utils.Language.Init(language.SelectedLanguage);
            }
            else
            {
                CultureInfo culture = CultureInfo.CurrentCulture;
                string cultureCode = culture.TwoLetterISOLanguageName;
                if (cultureCode == "pl")
                    Utils.Language.Init("pl");
                else
                    Utils.Language.Init("en");
            }
                
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
