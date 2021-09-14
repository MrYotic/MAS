using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PluginsAPI;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Minecraft_Mac.Forms
{
    public partial class AutoClicker : Form
    {
        public AutoClicker()
        {
            InitializeComponent();
        }
        private AutoClickerMac clickerMac;

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            int cps = 12;
            int.TryParse(textBoxLMBDelay.Text, out cps);
            clickerMac.settings.lmb.cps = cps;
            clickerMac.SaveCFG();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Keys key2 = Keys.None;
            Enum.TryParse(comboBoxActivationRMB.Text, out key2);
            clickerMac.settings.rmb.enable = key2;
            clickerMac.SaveCFG();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEnableMacro.Checked)
            {
                pluginClient.PluginLoad(clickerMac);
            }
            else
            {
                pluginClient.PluginUnLoad(clickerMac);
            }
        }

        private void AutoClicker_Load(object sender, EventArgs e)
        {
            comboBoxActivationRMB.Items.Clear();
            comboBoxActivationLMB.Items.Clear();
            foreach (string name in Enum.GetNames(typeof(Keys)))
            {
                comboBoxActivationRMB.Items.Add(name);
                comboBoxActivationLMB.Items.Add(name);
            }
            clickerMac = new AutoClickerMac(this);
            try
            {
                clickerMac.LoadCFG();
            }
            catch
            {
                clickerMac.SaveCFG();
            }
            #region Загрузка значений в форму
            comboBoxActivationLMB.Text = clickerMac.settings.lmb.enable.ToString();
            textBoxLMBDelay.Text = clickerMac.settings.lmb.cps.ToString();

            comboBoxActivationRMB.Text = clickerMac.settings.rmb.enable.ToString();
            textBoxRMBDelay.Text = clickerMac.settings.rmb.cps.ToString();
            #endregion
        }

        static PluginUpdater pluginUpdater = new PluginUpdater();
        public static PluginClient pluginClient = new PluginClient(pluginUpdater);

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Keys key2 = Keys.None;
            Enum.TryParse(comboBoxActivationLMB.Text, out key2);
            clickerMac.settings.lmb.enable = key2;
            clickerMac.SaveCFG();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int cps = 12;
            int.TryParse(textBoxRMBDelay.Text, out cps);
            clickerMac.settings.rmb.cps = cps;
            clickerMac.SaveCFG();
        }

        private void AutoClicker_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
    }

    public class AutoClickerMac : Plugin
    {
        private AutoClicker clicker;
        public AutoClickerMac(AutoClicker clicker)
        {
            this.clicker = clicker;
        }
        public AutoClickerSettings settings = new AutoClickerSettings();

        #region Работа с CFG
        public void LoadCFG()
        {
            if (File.Exists("Settings\\Auto Clicker.json"))
            {
                using (StreamReader sr = new StreamReader("Settings\\Auto Clicker.json", encoding: System.Text.Encoding.UTF8))
                {
                    string line = sr.ReadToEnd();
                    settings = JsonConvert.DeserializeObject<AutoClickerSettings>(line);
                }
            }
        }
        public void SaveCFG()
        {
            if (!Directory.Exists("Settings"))
            {
                Directory.CreateDirectory("Settings");
            }
            if (!File.Exists("Settings\\Auto Clicker.json"))
            {
                File.Create("Settings\\Auto Clicker.json").Close();
            }

            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.Formatting = Formatting.Indented;

            using (StreamWriter sw = new StreamWriter("Settings\\Auto Clicker.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, settings);
            }
        }
        #endregion

        public override void Update()
        {
            if (IsKeyPressed(settings.lmb.enable))
            {
                LeftClick();
                Thread.Sleep(1000 / settings.lmb.cps);
            }
            if (IsKeyPressed(settings.rmb.enable))
            {
                RightClick();
                Thread.Sleep(1000 / settings.rmb.cps);
            }
        }
    }

    public class AutoClickerSettings
    {
        [JsonProperty("LMB")]
        public LMB lmb = new LMB();
        [JsonProperty("RMB")]
        public RMB rmb = new RMB();


        public class LMB
        {
            [JsonProperty("Keybind")]
            [JsonConverter(typeof(StringEnumConverter))]
            public Keys enable = Keys.None;
            [JsonProperty("CPS")]
            public int cps = 12;
        }
        public class RMB
        {
            [JsonProperty("Keybind")]
            [JsonConverter(typeof(StringEnumConverter))]
            public Keys enable = Keys.None;
            [JsonProperty("CPS")]
            public int cps = 12;
        }
    }
}
