using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Mac.Forms
{
    public partial class All : Form
    {
        public All()
        {
            InitializeComponent();
        }
        private CheatStealer cheatStealer = new CheatStealer();
        private AutoSprint autoSprint = new AutoSprint();
        private AutoClicker autoClicker = new AutoClicker();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void All_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string itemname = comboBox1.SelectedItem.ToString();

                switch (itemname)
                {
                    case "Chest Stealer":
                        cheatStealer.Show();
                        break;
                    case "Auto Sprint":
                        autoSprint.Show();
                        break;
                    case "Auto Clicker":
                        autoClicker.Show();
                        break;
                }
            }
        }
    }
}
