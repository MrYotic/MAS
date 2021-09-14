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
            int.TryParse(textBox12.Text, out cps);
            clickerMac.lmb_cps = cps;
            clickerMac.SaveCFG();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Keys key2 = Keys.None;
            Enum.TryParse(comboBox3.Text, out key2);
            clickerMac.rmb_key = key2;
            clickerMac.SaveCFG();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
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
            comboBox3.Items.Clear();
            comboBox1.Items.Clear();
            foreach (string name in Enum.GetNames(typeof(Keys)))
            {
                comboBox3.Items.Add(name);
                comboBox1.Items.Add(name);
            }
            clickerMac = new AutoClickerMac(this);
            clickerMac.LoadCFG();
        }

        static PluginUpdater pluginUpdater = new PluginUpdater();
        public static PluginClient pluginClient = new PluginClient(pluginUpdater);

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Keys key2 = Keys.None;
            Enum.TryParse(comboBox1.Text, out key2);
            clickerMac.lmb_key = key2;
            clickerMac.SaveCFG();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int cps = 12;
            int.TryParse(textBox6.Text, out cps);
            clickerMac.rmb_cps = cps;
            clickerMac.SaveCFG();
        }

        private void AutoClicker_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }

    public class AutoClickerMac : Plugin
    {
        private AutoClicker clicker;
        public AutoClickerMac(AutoClicker clicker)
        {
            this.clicker = clicker;
        }
        public Keys lmb_key = Keys.None;
        public Keys rmb_key = Keys.None;

        public int lmb_cps = 12;
        public int rmb_cps = 12;
        public void LoadCFG()
        {
            if (File.Exists("Auto Clicker.ini"))
            {
                INIManager manager = new INIManager(Path.Combine(Application.StartupPath, "Auto Clicker.ini"));
                try
                {
                    lmb_key = (Keys)Enum.Parse(typeof(Keys), manager.GetPrivateString("LMB", "Activation Key"));
                    clicker.comboBox1.Text = lmb_key.ToString();
                }
                catch { }
                try
                {
                    lmb_cps = int.Parse(manager.GetPrivateString("LMB", "CPS"));
                    clicker.textBox12.Text = lmb_cps.ToString();
                }
                catch { }

                try
                {
                    rmb_key = (Keys)Enum.Parse(typeof(Keys), manager.GetPrivateString("RMB", "Activation Key"));
                    clicker.comboBox3.Text = rmb_key.ToString();
                }
                catch { }
                try
                {
                    rmb_cps = int.Parse(manager.GetPrivateString("RMB", "CPS"));
                    clicker.textBox6.Text = rmb_cps.ToString();
                }
                catch { }
            }
        }
        public void SaveCFG()
        {
            if (!File.Exists("Auto Clicker.ini"))
            {
                File.Create("Auto Clicker.ini").Close();
            }

            INIManager manager = new INIManager(Path.Combine(Application.StartupPath, "Auto Clicker.ini"));

            manager.WritePrivateString("LMB", "Activation Key", lmb_key.ToString());
            manager.WritePrivateString("LMB", "CPS", lmb_cps.ToString());

            manager.WritePrivateString("RMB", "Activation Key", rmb_key.ToString());
            manager.WritePrivateString("RMB", "CPS", rmb_cps.ToString());
        }
        public override void Update()
        {
            if (IsKeyPressed(lmb_key))
            {
                LeftClick();
                Thread.Sleep(1000 / lmb_cps);
            }
            if (IsKeyPressed(rmb_key))
            {
                RightClick();
                Thread.Sleep(1000 / rmb_cps);
            }
        }
    }
}
