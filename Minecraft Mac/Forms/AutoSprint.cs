using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PluginsAPI;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Minecraft_Mac.Forms
{
    public partial class AutoSprint : Form
    {
        public AutoSprint()
        {
            InitializeComponent();
        }

        private void AutoSprint_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
        static PluginUpdater pluginUpdater = new PluginUpdater();
        private PluginClient pluginClient = new PluginClient(pluginUpdater);

        private AutoSprintMac sprintMac = new AutoSprintMac();
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                pluginClient.PluginLoad(sprintMac);
            }
            else
            {
                pluginClient.PluginUnLoad(sprintMac);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int delay = 5;
            int.TryParse(textBoxControlDelay.Text, out delay);
            sprintMac.settings.delay = delay;
            sprintMac.SaveCFG();
        }

        private void AutoSprint_Load(object sender, EventArgs e)
        {
            try
            {
                sprintMac.LoadCFG();
            } 
            catch
            {
                sprintMac.SaveCFG();
            }
            #region Загрузка значений в форму
            textBoxControlDelay.Text = sprintMac.settings.delay.ToString();
            #endregion
        }
    }

    public class AutoSprintMac : Plugin
    {
        public AutoSrintSettings settings = new AutoSrintSettings();
        public override void Update()
        {
            if (IsKeyPressed(Keys.W))
            {
                KeyDown(Keys.ControlKey);
                Thread.Sleep(settings.delay);
                KeyUp(Keys.ControlKey);
            }
        }

        #region Работа с CFG
        public void LoadCFG()
        {
            if (File.Exists("Settings\\Auto Sprint.json"))
            {
                using (StreamReader sr = new StreamReader("Settings\\Auto Sprint.json", encoding: System.Text.Encoding.UTF8))
                {
                    string line = sr.ReadToEnd();
                    settings = JsonConvert.DeserializeObject<AutoSrintSettings>(line);
                }
            }
        }
        public void SaveCFG()
        {
            if (!Directory.Exists("Settings"))
            {
                Directory.CreateDirectory("Settings");
            }
            if (!File.Exists("Settings\\Auto Sprint.json"))
            {
                File.Create("Settings\\Auto Sprint.json").Close();
            }

            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.Formatting = Formatting.Indented;

            using (StreamWriter sw = new StreamWriter("Settings\\Auto Sprint.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, settings);
            }
        }
        #endregion
    }

    public class AutoSrintSettings
    {
        public int delay = 25;
    }
}
