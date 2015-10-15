using System.Windows.Forms;

namespace MinecraftServerManager.Controls
{
    public class Button : System.Windows.Forms.Button
    {
        public Button() : base() 
        {
            this.SetStyle(ControlStyles.Selectable, false);
        }

        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }
    }
}