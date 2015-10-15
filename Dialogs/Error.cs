using System.Windows.Forms;
using MinecraftServerManager.Utils;

namespace MinecraftServerManager.Dialogs
{
    public class Error
    {
        public static void Show(string errorID)
        {
            MessageBox.Show(Language.GetString(errorID), Language.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
