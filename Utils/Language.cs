using System.Reflection;
using System.Globalization;
using System.Resources;

namespace MinecraftServerManager.Utils
{
    public class Language
    {
        private static ResourceManager resourceManager;

        public static void Init(string language)
        {
            if (language == "pl")
                resourceManager = Resources.LanguagePL.ResourceManager;
            else
                resourceManager = Resources.LanguageEN.ResourceManager;
        }

        public static string GetString(string name)
        {
            if (resourceManager == null) return "";
            return resourceManager.GetString(name);
        }
    }
}
