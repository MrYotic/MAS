using PluginsAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Mac.Forms
{
    public partial class CheatStealer : Form
    {
        private ChestStealerPlugin chestStealerPlugin = null;
        public CheatStealer()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            chestStealerPlugin.SetPrepare(checkBox1.Checked);
            SaveCFG();
        }
        static PluginUpdater pluginUpdater = new PluginUpdater();
        private PluginClient pluginClient = new PluginClient(pluginUpdater);
        private void CheatStealer_Load(object sender, EventArgs e)
        {

            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox2.Items.Clear();
            comboBox1.Items.Clear();
            foreach (string name in Enum.GetNames(typeof(Keys)))
            {
                comboBox4.Items.Add(name);
                comboBox3.Items.Add(name);
                comboBox2.Items.Add(name);
                comboBox1.Items.Add(name);
            }
            chestStealerPlugin = new ChestStealerPlugin(this);
            chestStealerPlugin.LoadCFG();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Keys key = Keys.None;
            Enum.TryParse(comboBox2.Text, out key);
            Keys key2 = Keys.None;
            Enum.TryParse(comboBox1.Text, out key2);
            Keys key3 = Keys.None;
            Enum.TryParse(comboBox3.Text, out key3);
            Keys key4 = Keys.None;
            Enum.TryParse(comboBox4.Text, out key4);
            if (checkBox2.Checked)
            {
                chestStealerPlugin.prep_key_9x3 = key;
                chestStealerPlugin.activ_key_9x3 = key2;

                chestStealerPlugin.prep_key_9x6 = key4;
                chestStealerPlugin.activ_key_9x6 = key3;

                chestStealerPlugin.SaveCFG();

                pluginClient.PluginLoad(chestStealerPlugin);
            }
            else
            {
                chestStealerPlugin.prep_key_9x3 = key;
                chestStealerPlugin.activ_key_9x3 = key2;

                chestStealerPlugin.prep_key_9x6 = key4;
                chestStealerPlugin.activ_key_9x6 = key3;

                chestStealerPlugin.SaveCFG();

                pluginClient.PluginUnLoad(chestStealerPlugin);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Keys key2 = Keys.None;
            Enum.TryParse(comboBox1.Text, out key2);
            chestStealerPlugin.activ_key_9x3 = key2;
            SaveCFG();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int slot_switch_delay = 2;
            int.TryParse(textBox1.Text, out slot_switch_delay);
            chestStealerPlugin.slot_switch_delay = slot_switch_delay;
            SaveCFG();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int slot_aim_delay = 5;
            int.TryParse(textBox2.Text, out slot_aim_delay);
            chestStealerPlugin.slot_aim_delay = slot_aim_delay;
            SaveCFG();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int clicks = 2;
            int.TryParse(textBox3.Text, out clicks);
            chestStealerPlugin.clicks = clicks;
            SaveCFG();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int offset_x = 35;
            int.TryParse(textBox5.Text, out offset_x);
            chestStealerPlugin.offset_x = offset_x;
            SaveCFG();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int offset_y = 35;
            int.TryParse(textBox4.Text, out offset_y);
            chestStealerPlugin.offset_y = offset_y;
            SaveCFG();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int work_done_delay = 500;
            int.TryParse(textBox6.Text, out work_done_delay);
            chestStealerPlugin.work_done_delay = work_done_delay;
            SaveCFG();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Keys key3 = Keys.None;
            Enum.TryParse(comboBox3.Text, out key3);
            chestStealerPlugin.activ_key_9x6 = key3;
            SaveCFG();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Keys key = Keys.None;
            Enum.TryParse(comboBox2.Text, out key);
            chestStealerPlugin.prep_key_9x3 = key;
            SaveCFG();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Keys key4 = Keys.None;
            Enum.TryParse(comboBox4.Text, out key4);
            chestStealerPlugin.prep_key_9x6 = key4;
            SaveCFG();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            int shift_down_delay = 25;
            int.TryParse(textBox8.Text, out shift_down_delay);
            chestStealerPlugin.shift_down_delay = shift_down_delay;
            SaveCFG();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            int shift_up_delay = 25;
            int.TryParse(textBox7.Text, out shift_up_delay);
            chestStealerPlugin.shift_up_delay = shift_up_delay;
            SaveCFG();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            int mouse_down_delay = 0;
            int.TryParse(textBox10.Text, out mouse_down_delay);
            chestStealerPlugin.mouse_down_delay = mouse_down_delay;
            SaveCFG();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            int mouse_up_delay = 3;
            int.TryParse(textBox9.Text, out mouse_up_delay);
            chestStealerPlugin.mouse_up_delay = mouse_up_delay;
            SaveCFG();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            chestStealerPlugin.auto_close = checkBox4.Checked;
            SaveCFG();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            chestStealerPlugin.auto_open = checkBox5.Checked;
            SaveCFG();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            int auto_open_delay = 500;
            int.TryParse(textBox12.Text, out auto_open_delay);
            chestStealerPlugin.auto_open_delay = auto_open_delay;
            SaveCFG();
        }

        private void CheatStealer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            int click_delay = 2;
            int.TryParse(textBox12.Text, out click_delay);
            chestStealerPlugin.clicks_delay = click_delay;
            SaveCFG();
        }

        #region Дополнительные методы
        private void SaveCFG()
        {
            Task.Factory.StartNew(() =>
            {
                chestStealerPlugin.SaveCFG();
            });
        }
        #endregion
    }
    public class ChestStealerPlugin : Plugin
    {
        private CheatStealer stealer;
        public ChestStealerPlugin(CheatStealer stealer)
        {
            this.stealer = stealer;
            LoadCFG();
        }
        public Keys activ_key_9x3 = Keys.None; /* Клавиша активаций Одиночного сундука */
        public Keys activ_key_9x6 = Keys.None;  /* Клавиша активаций Двойного сундука */

        public Keys prep_key_9x3 = Keys.None;
        public Keys prep_key_9x6 = Keys.None;

        public int mouse_down_delay = 0;
        public int shift_down_delay = 25;
        public int shift_up_delay = 25;

        public int mouse_up_delay = 3;
        public int slot_switch_delay = 2;
        public int slot_aim_delay = 5;
        public int work_done_delay = 500;
        public int clicks = 2;
        public bool prepare = false;
        public int clicks_delay = 2;

        public bool auto_close = false;
        public bool auto_open = false;
        public int auto_open_delay = 1;

        public int offset_x = 35;
        public int offset_y = 35;

        public void LoadCFG()
        {
            if (File.Exists("Chest Stealer.ini"))
            {
                INIManager manager = new INIManager(Path.Combine(Application.StartupPath, "Chest Stealer.ini"));
                /* *Main settings */
                try 
                { 
                    slot_switch_delay = int.Parse(manager.GetPrivateString("Main settings", "Slot Switch Delay"));
                    stealer.textBox1.Text = slot_switch_delay.ToString();
                } catch { }
                try 
                { 
                    mouse_down_delay = int.Parse(manager.GetPrivateString("Main settings", "Mouse Down Delay"));
                } catch { }
                try 
                { 
                    mouse_up_delay = int.Parse(manager.GetPrivateString("Main settings", "Mouse Up Delay"));
                } catch { }
                try 
                { 
                    shift_down_delay = int.Parse(manager.GetPrivateString("Main settings", "Shift Down Delay"));
                    stealer.textBox8.Text = shift_down_delay.ToString();
                } catch { }
                try 
                { 
                    shift_up_delay = int.Parse(manager.GetPrivateString("Main settings", "Shift Up Delay"));
                    stealer.textBox7.Text = shift_up_delay.ToString();
                } catch { }
                try 
                { 
                    slot_aim_delay = int.Parse(manager.GetPrivateString("Main settings", "Slot Aim Delay"));
                    stealer.textBox2.Text = slot_aim_delay.ToString();
                } catch { }
                try 
                { 
                    work_done_delay = int.Parse(manager.GetPrivateString("Main settings", "End Delay")); 
                } catch { }
                try 
                { 
                    clicks = int.Parse(manager.GetPrivateString("Main settings", "Slot CPS"));
                    stealer.textBox3.Text = clicks.ToString();
                } catch { }
                try 
                { 
                    prepare = bool.Parse(manager.GetPrivateString("Main settings", "Location Manager"));
                    stealer.checkBox1.Checked = prepare;
                } catch { }
                try
                {
                    auto_close = bool.Parse(manager.GetPrivateString("Main settings", "Auto Close Chest"));
                    stealer.checkBox4.Checked = auto_close;
                }
                catch { }

                try
                {
                    auto_open = bool.Parse(manager.GetPrivateString("Main settings", "Auto Open Chest"));
                    stealer.checkBox5.Checked = auto_open;
                }
                catch { }
                try
                {
                    auto_open_delay = int.Parse(manager.GetPrivateString("Main settings", "Auto Open Chest Delay"));
                    stealer.textBox12.Text = auto_open_delay.ToString();
                }
                catch { }
                try
                {
                    clicks_delay = int.Parse(manager.GetPrivateString("Main settings", "Clicks Delay"));
                    stealer.textBox13.Text = clicks_delay.ToString();
                }
                catch { }

                try
                {
                    Point point = new Point(int.Parse(manager.GetPrivateString("Main settings", "Offset X")), int.Parse(manager.GetPrivateString("Main settings", "Offset Y")));
                    offset_x = point.X;
                    offset_y = point.Y;

                    stealer.textBox5.Text = offset_x.ToString();
                    stealer.textBox4.Text = offset_y.ToString();
                } catch { }

                /* Small chest */
                try 
                { 
                    prep_key_9x3 = (Keys)Enum.Parse(typeof(Keys), manager.GetPrivateString("9x3", "New Postion Activation Key"));
                    stealer.comboBox2.Text = prep_key_9x3.ToString();
                } catch { }
                try 
                { 
                    activ_key_9x3 = (Keys)Enum.Parse(typeof(Keys), manager.GetPrivateString("9x3", "Activation Key"));
                    stealer.comboBox1.Text = activ_key_9x3.ToString();
                } catch { }
                try
                {
                    Point point = new Point(int.Parse(manager.GetPrivateString("9x3", "First Slot X")), int.Parse(manager.GetPrivateString("9x3", "First Slot Y")));
                    first_slot_1_9x3 = point;
                } catch { }

                /* Large chest */
                try 
                { 
                    prep_key_9x6 = (Keys)Enum.Parse(typeof(Keys), manager.GetPrivateString("9x6", "New Postion Activation Key"));
                    stealer.comboBox4.Text = prep_key_9x6.ToString();
                } catch { }
                try 
                { 
                    activ_key_9x6 = (Keys)Enum.Parse(typeof(Keys), manager.GetPrivateString("9x6", "Activation Key"));
                    stealer.comboBox3.Text = activ_key_9x6.ToString();
                } catch { }
                try
                {
                    Point point2 = new Point(int.Parse(manager.GetPrivateString("9x6", "First Slot X")), int.Parse(manager.GetPrivateString("9x6", "First Slot Y")));
                    first_slot_1_9x6 = point2;
                } catch { }
            }
        }
        public void SaveCFG()
        {
            if (!File.Exists("Chest Stealer.ini"))
            {
                File.Create("Chest Stealer.ini").Close();
            }

            INIManager manager = new INIManager(Path.Combine(Application.StartupPath, "Chest Stealer.ini"));
            /* *Main settings */
            manager.WritePrivateString("Main settings", "Slot Switch Delay", slot_switch_delay.ToString());
            manager.WritePrivateString("Main settings", "Mouse Down Delay", mouse_down_delay.ToString());
            manager.WritePrivateString("Main settings", "Mouse Up Delay", mouse_up_delay.ToString());
            manager.WritePrivateString("Main settings", "Shift Down Delay", shift_down_delay.ToString());
            manager.WritePrivateString("Main settings", "Shift Up Delay", shift_up_delay.ToString());
            manager.WritePrivateString("Main settings", "Slot Aim Delay", slot_aim_delay.ToString());
            manager.WritePrivateString("Main settings", "End Delay", work_done_delay.ToString());
            manager.WritePrivateString("Main settings", "Slot CPS", clicks.ToString());
            manager.WritePrivateString("Main settings", "Location Manager", prepare.ToString());
            manager.WritePrivateString("Main settings", "Clicks Delay", clicks_delay.ToString());

            manager.WritePrivateString("Main settings", "Auto Close Chest", auto_close.ToString());
            manager.WritePrivateString("Main settings", "Auto Open Chest", auto_open.ToString());
            manager.WritePrivateString("Main settings", "Auto Open Chest Delay", auto_open_delay.ToString());

            manager.WritePrivateString("Main settings", "Offset X", offset_x.ToString());
            manager.WritePrivateString("Main settings", "Offset Y", offset_y.ToString());

            /* Small chest */
            manager.WritePrivateString("9x3", "New Postion Activation Key", prep_key_9x3.ToString());
            manager.WritePrivateString("9x3", "Activation Key", activ_key_9x3.ToString());
            manager.WritePrivateString("9x3", "First Slot X", first_slot_1_9x3.X.ToString());
            manager.WritePrivateString("9x3", "First Slot Y", first_slot_1_9x3.Y.ToString());

            /* Large chest */
            manager.WritePrivateString("9x6", "New Postion Activation Key", prep_key_9x6.ToString());
            manager.WritePrivateString("9x6", "Activation Key", activ_key_9x6.ToString());
            manager.WritePrivateString("9x6", "First Slot X", first_slot_1_9x6.X.ToString());
            manager.WritePrivateString("9x6", "First Slot Y", first_slot_1_9x6.Y.ToString());

        }
        public void SetPrepare(bool prepare)
        {
            this.prepare = prepare;
        }
        private void CollectSlot(Point location)
        {
            Cursor.Position = location;
            Thread.Sleep(slot_aim_delay);
            for (int i = 0; i < clicks; i++)
            {
                Thread.Sleep(clicks_delay);
                LeftClick();
            }
            Thread.Sleep(slot_switch_delay);
        }
        private Point first_slot_1_9x3;
        private Point first_slot_1_9x6;

        public void CollectChest(bool chest_doouble, Keys key)
        {
            int rows = 3;
            switch (chest_doouble)
            {
                case (true):
                    rows = 6;
                    break;
            }
            switch (auto_open)
            {
                case (true):
                    RightClick();
                    Thread.Sleep(auto_open_delay);
                    break;
            }
            KeyDown(Keys.ShiftKey);
            Thread.Sleep(shift_down_delay);
            for (int i2 = 0; i2 < rows; i2++)
            {
                if (IsKeyPressed(key))
                {
                    KeyDown(Keys.ShiftKey);
                    for (int i = 0; i < 9; i++)
                    {
                        if (IsKeyPressed(key))
                        {
                            KeyDown(Keys.ShiftKey);
                            switch (chest_doouble)
                            {
                                case (true):
                                    Point slot_6x9 = new Point(first_slot_1_9x6.X + (i * offset_x), first_slot_1_9x6.Y + (offset_y * i2));
                                    CollectSlot(slot_6x9);
                                    break;
                                default:
                                    Point slot_3x9 = new Point(first_slot_1_9x3.X + (i * offset_x), first_slot_1_9x3.Y + (offset_y * i2));
                                    CollectSlot(slot_3x9);
                                    break;
                            }
                        }
                        else
                        {
                            Thread.Sleep(shift_up_delay);
                            KeyUp(Keys.ShiftKey);
                            break;
                        }

                    }
                }
                else
                {
                    Thread.Sleep(shift_up_delay);
                    KeyUp(Keys.ShiftKey);
                    break;
                }
            }
            Thread.Sleep(shift_up_delay);
            KeyUp(Keys.ShiftKey);
            KeyUp(Keys.ControlKey);
            switch (auto_close)
            {
                case (true):
                    KeyDown(Keys.Escape);
                    KeyUp(Keys.Escape);
                    break;
            }
            Thread.Sleep(work_done_delay);
        }
        public override void Update()
        {
            if (IsKeyPressed(prep_key_9x3) && prepare)
            {
                first_slot_1_9x3 = Cursor.Position;
                SaveCFG();
                MessageBox.Show("Позиция первого слота сундука 9x3 сохранена", "Preloadning");
            }
            else if (IsKeyPressed(prep_key_9x6) && prepare)
            {
                first_slot_1_9x6 = Cursor.Position;
                SaveCFG();
                MessageBox.Show("Позиция первого слота сундука 9x6 сохранена", "Preloadning");
            }
            else if (IsKeyPressed(activ_key_9x3))
            {
                CollectChest(false, activ_key_9x3);
            }
            else if (IsKeyPressed(activ_key_9x6))
            {
                CollectChest(true, activ_key_9x6);
            }
        }
    }
}
