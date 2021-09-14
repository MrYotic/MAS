using PluginsAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Mac.Forms
{
    public partial class PistonDupe : Form
    {
        private Dupe_1_12_2 dupe = new Dupe_1_12_2();
        public PistonDupe()
        {
            InitializeComponent();
        }
        static PluginUpdater pluginUpdater = new PluginUpdater();
        private PluginClient pluginClient = new PluginClient(pluginUpdater);
        private void PistonDupe_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            foreach (string name in Enum.GetNames(typeof(Keys)))
            {
                comboBox2.Items.Add(name);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Keys key = Keys.None;
            Enum.TryParse(comboBox2.Text, out key);
            if (checkBox1.Checked)
            {
                dupe.SetKey(key);
                pluginClient.PluginLoad(dupe);
            }
            else
            {
                dupe.SetKey(key);
                pluginClient.PluginUnLoad(dupe);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dupe.SetDelay(int.Parse(textBox1.Text));
        }

        private void PistonDupe_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
    public class Dupe_1_12_2 : Plugin
    {
        private Keys key;
        private int delay = 1018;
        public void SetKey(Keys key)
        {
            this.key = key;
        }
        public void SetDelay(int delay)
        {
            this.delay = delay;
        }
        public List<string> NeedItems()
        {
            List<string> items = new List<string>();
            items.Add("Itemframe x1");
            items.Add("Piston x1");
            items.Add("Stone button x1");
            items.Add("Colid block x1");
            return items;
        }
        public override void Update()
        {
            if (IsKeyPressed(key))
            {
                RightClick();
                Thread.Sleep(delay);
                LeftClick();
            }
        }
    }
}
