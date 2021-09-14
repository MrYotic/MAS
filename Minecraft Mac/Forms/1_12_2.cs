using System;
using System.Windows.Forms;

namespace Minecraft_Mac.Forms
{
    public partial class _1_12_2 : Form
    {
        public _1_12_2()
        {
            InitializeComponent();
        }


        private PistonDupe pistonDupe = new PistonDupe();

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
