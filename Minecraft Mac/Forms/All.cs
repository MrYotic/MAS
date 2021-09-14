using System;
using System.Windows.Forms;

namespace Minecraft_Mac.Forms
{
    public partial class All : Form
    {
        public All()
        {
            InitializeComponent();
        }

        #region Формы с макросами
        private CheatStealer cheatStealer = new CheatStealer();
        private AutoSprint autoSprint = new AutoSprint();
        private AutoClicker autoClicker = new AutoClicker();
        #endregion

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

        private void All_Load(object sender, EventArgs e)
        {

        }
    }
}
