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
    public partial class _1_12_2 : Form
    {
        public _1_12_2()
        {
            InitializeComponent();
        }


        PistonDupe pistonDupe = new PistonDupe();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string itemname = comboBox1.SelectedItem.ToString();

                switch (itemname)
                {
                    case "Piston [Single Player]":
                        pistonDupe.Show();
                        break;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void _1_12_2_Load(object sender, EventArgs e)
        {

        }
    }
}
