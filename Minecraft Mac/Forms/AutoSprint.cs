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
    public partial class AutoSprint : Form
    {
        public AutoSprint()
        {
            InitializeComponent();
        }

        private void AutoSprint_Load(object sender, EventArgs e)
        {

        }

        private void AutoSprint_HelpButtonClicked(object sender, CancelEventArgs e)
        {

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
    }

    public class AutoSprintMac : Plugin
    {
        public override void Update()
        {
            if (IsKeyPressed(Keys.W))
            {
                KeyDown(Keys.ControlKey);
                Thread.Sleep(25);
                KeyUp(Keys.ControlKey);
            }
        }
    }
}
