using System.Drawing;
using System.Windows.Forms;

namespace MinecraftServerManager.Controls
{
    public partial class PropertiesEditor : UserControl
    {
        private Tabs tabs;

        public PropertiesEditor()
        {
            InitializeComponent();
        }

        public new void Load(Tabs _tabs)
        {
            for (int i = 0; i < Properties.Length; i += 3)
            {
                int y = i * 9;

                string propertyName = Properties[i];
                string text = Properties[i + 1];
                string type = Properties[i + 2];

                Label label = new Label();
                label.Text = text;
                label.Location = new Point(0, y);
                label.Font = new Font("Calibri", 12);
                this.Controls.Add(label);

                switch (type)
                {
                    case "boolean":
                        break;
                }
            }
            this.tabs = _tabs;
            tabs.AddTab("Ustawienia", this);
        }

        private string[] Properties = 
        {
            "online-mode", "Autentykacja premium", "boolean",
            "difficulty", "Trudność", "difficulty",
            "gamemode", "Tryb gry", "gamemode",
            "max-players", "Maksymalna liczba graczy", "int",
            "motd", "Opis serwera", "string",
            "spawn-protection", "Ochrona spawnu", "int",
            "view-distance", "Odległość renderowania", "view-distance",
            "spawn-animals", "Zwierzęta", "boolean",
            "spawn-monsters", "Potwory", "boolean",
            "spawn-npcs", "Wieśniacy", "boolean",
            "generate-structures", "Generuj struktury", "boolean",
            "allow-nether", "Piekło", "boolean",
            "allow-flight", "Latanie", "boolean",
            "pvp", "PvP", "boolean",
            "white-list", "Biała lista", "boolean",
            "enable-command-block", "Bloki poleceń", "boolean",
            "enable-query", "Query", "boolean",
            "query.port", "Port query", "port",
            "enable-rcon", "RCON", "boolean",
            "rcon.port", "Port RCON", "port",
            "rcon.password", "Hasło RCON", "port",
            "force-gamemode", "Wymuszanie trybu gry", "boolean",
            "hardcore", "Tryb hardcore", "boolean",
            "player-idle-timeout", "Usuwaj graczy AFK:", "int",
            "op-permission-level", "Poziom uprawnień OPa", "op-permission-level",
            "resource-pack", "Paczka zasobów", "string",
            "resource-pack-hash", "Hash paczki zasobów", "string",
            "level-name", "Nazwa świata", "string",
            "level-type", "Typ świata", "level-type",
            "level-seed", "Seed generatora", "string",
            "generator-settings", "Ustawienia generatora", "string",
            "max-world-size", "Maksymalna wielkość świata:", "int",
            "max-build-height", "Maksymalna wysokość budowania", "byte",
            "max-tick-time", "Maksymalna długość ticku", "int",
            "network-compression-threshold", "Kompresja pakietów", "int",
            "snooper-enabled", "Włącz Snooper", "boolean",
            "use-native-transport", "Szybsze przesyłanie pakietów", "boolean",
            "server-ip", "IP serwera", "string",
            "server-port", "Port serwera", "port"
        };
    }
}
