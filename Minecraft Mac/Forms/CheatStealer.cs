using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PluginsAPI;
using System;
using System.Drawing;
using System.IO;
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
            chestStealerPlugin.settings.prepare = checkBoxEnablePreInt.Checked;
            SaveCFG();
        }
        static PluginUpdater pluginUpdater = new PluginUpdater();
        private PluginClient pluginClient = new PluginClient(pluginUpdater);
        private void CheatStealer_Load(object sender, EventArgs e)
        {
            comboBoxActivation9x6.Items.Clear();
            comboBoxPreIntKey9x6.Items.Clear();
            comboBoxPreIntKey9x3.Items.Clear();
            comboBoxActivation9x3.Items.Clear();
            foreach (string name in Enum.GetNames(typeof(Keys)))
            {
                comboBoxPreIntKey9x6.Items.Add(name);
                comboBoxActivation9x6.Items.Add(name);
                comboBoxPreIntKey9x3.Items.Add(name);
                comboBoxActivation9x3.Items.Add(name);
            }
            chestStealerPlugin = new ChestStealerPlugin(this);
            try
            {
                chestStealerPlugin.LoadCFG();
            }
            catch
            {
                chestStealerPlugin.SaveCFG();
            }

            #region Загрузка значений в форму
            comboBoxActivation9x3.Text = chestStealerPlugin.settings.chests.chest9x3.binds.enable.ToString();
            comboBoxActivation9x6.Text = chestStealerPlugin.settings.chests.chest9x6.binds.enable.ToString();

            checkBoxAutoCloseChest.Checked = chestStealerPlugin.settings.auto_close_chest.enabled;
            checkBoxAutoOpenChest.Checked = chestStealerPlugin.settings.auto_open_chest.enabled;

            textBoxAutoOpenDelay.Text = chestStealerPlugin.settings.auto_open_chest.delay.ToString();
            textBoxWorkDoneDelay.Text = chestStealerPlugin.settings.work_done_delay.ToString();
            textBoxShiftDownDelay.Text = chestStealerPlugin.settings.shift.shift_down_delay.ToString();
            textBoxShiftUpDelay.Text = chestStealerPlugin.settings.shift.shift_up_delay.ToString();

            textBoxMouseDownDelay.Text = chestStealerPlugin.settings.mouse.mouse_down_delay.ToString();
            textBoxMouseUpDelay.Text = chestStealerPlugin.settings.mouse.mouse_up_delay.ToString();

            textBoxOffset.Text = chestStealerPlugin.settings.chests.offset.ToString();

            comboBoxPreIntKey9x3.Text = chestStealerPlugin.settings.chests.chest9x3.binds.setlocation.ToString();
            comboBoxPreIntKey9x6.Text = chestStealerPlugin.settings.chests.chest9x6.binds.setlocation.ToString();
            checkBoxEnablePreInt.Checked = chestStealerPlugin.settings.prepare;

            textBoxCountClicks.Text = chestStealerPlugin.settings.mouse.firstSlot.clicks.ToString();
            textBoxClicksDelay.Text = chestStealerPlugin.settings.mouse.firstSlot.clicks_delay.ToString();
            textBoxSlotAimDelay.Text = chestStealerPlugin.settings.mouse.firstSlot.slot_aim_delay.ToString();
            textBoxSlotSwitchDelay.Text = chestStealerPlugin.settings.mouse.firstSlot.slot_switch_delay.ToString();

            textBox8.Text = chestStealerPlugin.settings.mouse.otherSlots.clicks.ToString();
            textBox5.Text = chestStealerPlugin.settings.mouse.otherSlots.clicks_delay.ToString();
            textBox7.Text = chestStealerPlugin.settings.mouse.otherSlots.slot_aim_delay.ToString();
            textBox6.Text = chestStealerPlugin.settings.mouse.otherSlots.slot_switch_delay.ToString();

            textBox4.Text = chestStealerPlugin.settings.mouse.lastSlot.clicks.ToString();
            textBox1.Text = chestStealerPlugin.settings.mouse.lastSlot.clicks_delay.ToString();
            textBox3.Text = chestStealerPlugin.settings.mouse.lastSlot.slot_aim_delay.ToString();
            textBox2.Text = chestStealerPlugin.settings.mouse.lastSlot.slot_switch_delay.ToString();
            #endregion
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Keys key = Keys.None;
            Enum.TryParse(comboBoxPreIntKey9x3.Text, out key);
            Keys key2 = Keys.None;
            Enum.TryParse(comboBoxActivation9x3.Text, out key2);
            Keys key3 = Keys.None;
            Enum.TryParse(comboBoxActivation9x6.Text, out key3);
            Keys key4 = Keys.None;
            Enum.TryParse(comboBoxPreIntKey9x6.Text, out key4);
            if (checkBoxEnableMacro.Checked)
            {
                chestStealerPlugin.SaveCFG();

                pluginClient.PluginLoad(chestStealerPlugin);
            }
            else
            {
                pluginClient.PluginUnLoad(chestStealerPlugin);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Keys key2 = Keys.None;
            Enum.TryParse(comboBoxActivation9x3.Text, out key2);
            chestStealerPlugin.settings.chests.chest9x3.binds.enable = key2;
            SaveCFG();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int slot_switch_delay = 2;
            int.TryParse(textBoxSlotSwitchDelay.Text, out slot_switch_delay);
            chestStealerPlugin.settings.mouse.firstSlot.slot_switch_delay = slot_switch_delay;
            SaveCFG();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int slot_aim_delay = 5;
            int.TryParse(textBoxSlotAimDelay.Text, out slot_aim_delay);
            chestStealerPlugin.settings.mouse.firstSlot.slot_aim_delay = slot_aim_delay;
            SaveCFG();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int clicks = 2;
            int.TryParse(textBoxCountClicks.Text, out clicks);
            chestStealerPlugin.settings.mouse.firstSlot.clicks = clicks;
            SaveCFG();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int offset = 35;
            int.TryParse(textBoxOffset.Text, out offset);
            chestStealerPlugin.settings.chests.offset = offset;
            SaveCFG();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int work_done_delay = 500;
            int.TryParse(textBoxWorkDoneDelay.Text, out work_done_delay);
            chestStealerPlugin.settings.work_done_delay = work_done_delay;
            SaveCFG();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Keys key3 = Keys.None;
            Enum.TryParse(comboBoxActivation9x6.Text, out key3);
            chestStealerPlugin.settings.chests.chest9x6.binds.enable = key3;
            SaveCFG();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Keys key = Keys.None;
            Enum.TryParse(comboBoxPreIntKey9x3.Text, out key);
            chestStealerPlugin.settings.chests.chest9x3.binds.setlocation = key;
            SaveCFG();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Keys key4 = Keys.None;
            Enum.TryParse(comboBoxPreIntKey9x6.Text, out key4);
            chestStealerPlugin.settings.chests.chest9x6.binds.setlocation = key4;
            SaveCFG();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            int shift_down_delay = 25;
            int.TryParse(textBoxShiftDownDelay.Text, out shift_down_delay);
            chestStealerPlugin.settings.shift.shift_down_delay = shift_down_delay;
            SaveCFG();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            int shift_up_delay = 25;
            int.TryParse(textBoxShiftUpDelay.Text, out shift_up_delay);
            chestStealerPlugin.settings.shift.shift_up_delay = shift_up_delay;
            SaveCFG();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            int mouse_down_delay = 0;
            int.TryParse(textBoxMouseDownDelay.Text, out mouse_down_delay);
            chestStealerPlugin.settings.mouse.mouse_down_delay = mouse_down_delay;
            SaveCFG();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            int mouse_up_delay = 3;
            int.TryParse(textBoxMouseUpDelay.Text, out mouse_up_delay);
            chestStealerPlugin.settings.mouse.mouse_up_delay = mouse_up_delay;
            SaveCFG();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            chestStealerPlugin.settings.auto_close_chest.enabled = checkBoxAutoCloseChest.Checked;
            SaveCFG();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            chestStealerPlugin.settings.auto_open_chest.enabled = checkBoxAutoOpenChest.Checked;
            SaveCFG();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            int auto_open_delay = 500;
            int.TryParse(textBoxAutoOpenDelay.Text, out auto_open_delay);
            chestStealerPlugin.settings.auto_open_chest.delay = auto_open_delay;
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
            int.TryParse(textBoxClicksDelay.Text, out click_delay);
            chestStealerPlugin.settings.mouse.firstSlot.clicks_delay = click_delay;
            SaveCFG();
        }

        #region Дополнительные методы
        private void SaveCFG()
        {
            chestStealerPlugin.SaveCFG();
        }
        #endregion

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

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged_1(object sender, EventArgs e)
        {
            int temp = 2;
            int.TryParse(textBox8.Text, out temp);
            chestStealerPlugin.settings.mouse.otherSlots.clicks = temp;
            SaveCFG();
        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            int temp = 2;
            int.TryParse(textBox5.Text, out temp);
            chestStealerPlugin.settings.mouse.otherSlots.clicks_delay = temp;
            SaveCFG();
        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {
            int temp = 2;
            int.TryParse(textBox7.Text, out temp);
            chestStealerPlugin.settings.mouse.otherSlots.slot_switch_delay = temp;
            SaveCFG();
        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {
            int temp = 2;
            int.TryParse(textBox6.Text, out temp);
            chestStealerPlugin.settings.mouse.otherSlots.slot_aim_delay = temp;
            SaveCFG();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int temp = 2;
            int.TryParse(textBox4.Text, out temp);
            chestStealerPlugin.settings.mouse.lastSlot.clicks = temp;
            SaveCFG();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            int temp = 2;
            int.TryParse(textBox1.Text, out temp);
            chestStealerPlugin.settings.mouse.lastSlot.clicks_delay = temp;
            SaveCFG();
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            int temp = 2;
            int.TryParse(textBox3.Text, out temp);
            chestStealerPlugin.settings.mouse.lastSlot.slot_switch_delay = temp;
            SaveCFG();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            int temp = 2;
            int.TryParse(textBox2.Text, out temp);
            chestStealerPlugin.settings.mouse.lastSlot.slot_aim_delay = temp;
            SaveCFG();
        }
    }
    public class ChestStealerPlugin : Plugin
    {
        private CheatStealer stealer;
        public ChestStealerSettings settings = new ChestStealerSettings();
        public ChestStealerPlugin(CheatStealer stealer)
        {
            this.stealer = stealer;
        }

        #region Работа с конфигурацией
        public void LoadCFG()
        {
            if (File.Exists("Settings\\Chest Stealer.json"))
            {

                using (StreamReader sr = new StreamReader("Settings\\Chest Stealer.json", encoding: System.Text.Encoding.UTF8))
                {
                    string line = sr.ReadToEnd();
                    settings = JsonConvert.DeserializeObject<ChestStealerSettings>(line);
                }
            }
        }
        public void SaveCFG()
        {
            if (!Directory.Exists("Settings"))
            {
                Directory.CreateDirectory("Settings");
            }
            if (!File.Exists("Settings\\Chest Stealer.json"))
            {
                File.Create("Settings\\Chest Stealer.json").Close();
            }

            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.Formatting = Formatting.Indented;

            using (StreamWriter sw = new StreamWriter("Settings\\Chest Stealer.json"))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, settings);
                }
            }
        }
        #endregion

        #region Логика макроса
        private void CollectOtherSlot(Point location)
        {
            Cursor.Position = location;
            Thread.Sleep(settings.mouse.otherSlots.slot_aim_delay);
            for (int i = 0; i < settings.mouse.otherSlots.clicks; i++)
            {
                Thread.Sleep(settings.mouse.otherSlots.clicks_delay);
                LeftClick();
            }
            Thread.Sleep(settings.mouse.otherSlots.slot_switch_delay);
        }
        private void CollectFirstSlot(Point location)
        {
            Cursor.Position = location;
            Thread.Sleep(settings.mouse.firstSlot.slot_aim_delay);
            for (int i = 0; i < settings.mouse.firstSlot.clicks; i++)
            {
                Thread.Sleep(settings.mouse.firstSlot.clicks_delay);
                LeftClick();
            }
            Thread.Sleep(settings.mouse.firstSlot.slot_switch_delay);
        }
        private void CollectLastSlot(Point location)
        {
            Cursor.Position = location;
            Thread.Sleep(settings.mouse.lastSlot.slot_aim_delay);
            for (int i = 0; i < settings.mouse.lastSlot.clicks; i++)
            {
                Thread.Sleep(settings.mouse.lastSlot.clicks_delay);
                LeftClick();
            }
            Thread.Sleep(settings.mouse.lastSlot.slot_switch_delay);
        }
        public void CollectChest(bool chest_doouble, Keys key)
        {
            int rows = 3;
            if (chest_doouble)
            {
                rows = 6;
            }
            if (settings.auto_open_chest.enabled)
            {
                RightClick();
                Thread.Sleep(settings.auto_open_chest.delay);
            }
            KeyDown(Keys.ShiftKey);
            Thread.Sleep(settings.shift.shift_down_delay);
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
                            if (chest_doouble)
                            {

                                Point slot_6x9 = new Point(settings.chests.chest9x6.first_slot.X + (i * settings.chests.offset), settings.chests.chest9x6.first_slot.Y + (settings.chests.offset * i2));
                                if (i2 == 0 && i == 0)
                                {
                                    CollectFirstSlot(slot_6x9);
                                }
                                else if (i2 == 5 && i == 8)
                                {
                                    CollectLastSlot(slot_6x9);
                                }
                                else
                                {
                                    CollectOtherSlot(slot_6x9);
                                }
                            }
                            else
                            {
                                Point slot_3x9 = new Point(settings.chests.chest9x3.first_slot.X + (i * settings.chests.offset), settings.chests.chest9x3.first_slot.Y + (settings.chests.offset * i2));
                                if (i2 == 0 && i == 0)
                                {
                                    CollectFirstSlot(slot_3x9);
                                }
                                else if (i2 == 2 && i == 8)
                                {
                                    CollectLastSlot(slot_3x9);
                                }
                                else
                                {
                                    CollectOtherSlot(slot_3x9);
                                }
                            }
                        }
                        else
                        {
                            Thread.Sleep(settings.shift.shift_up_delay);
                            KeyUp(Keys.ShiftKey);
                            break;
                        }

                    }
                }
                else
                {
                    Thread.Sleep(settings.shift.shift_up_delay);
                    KeyUp(Keys.ShiftKey);
                    break;
                }
            }
            Thread.Sleep(settings.shift.shift_up_delay);
            KeyUp(Keys.ShiftKey);
            KeyUp(Keys.ControlKey);
            switch (settings.auto_close_chest.enabled)
            {
                case (true):
                    KeyDown(Keys.Escape);
                    KeyUp(Keys.Escape);
                    break;
            }
            Thread.Sleep(settings.work_done_delay);
        }
        #endregion

        #region Проверка нажатия клавиш
        public override void Update()
        {
            if (IsKeyPressed(settings.chests.chest9x3.binds.setlocation) && settings.prepare)
            {
                settings.chests.chest9x3.first_slot = Cursor.Position;
                SaveCFG();
                MessageBox.Show("Позиция первого слота сундука 9x3 сохранена", "Preloadning");
            }
            else if (IsKeyPressed(settings.chests.chest9x6.binds.setlocation) && settings.prepare)
            {
                settings.chests.chest9x6.first_slot = Cursor.Position;
                SaveCFG();
                MessageBox.Show("Позиция первого слота сундука 9x6 сохранена", "Preloadning");
            }
            else if (IsKeyPressed(settings.chests.chest9x3.binds.enable))
            {
                CollectChest(false, settings.chests.chest9x3.binds.enable);
            }
            else if(IsKeyPressed(settings.chests.chest9x6.binds.enable))
            {
                CollectChest(true, settings.chests.chest9x6.binds.enable);
            }
        }
        #endregion
    }

    public class ChestStealerSettings
    {
        #region Настройки скорости
        [JsonProperty("Work done delay")]
        public int work_done_delay = 500;
        [JsonProperty("Set location tool")]
        public bool prepare = false;
        #endregion
        [JsonProperty("Shift")]
        public Shift shift = new Shift();
        public class Shift
        {
            [JsonProperty("Down delay")]
            public int shift_down_delay = 25;
            [JsonProperty("Up delay")]
            public int shift_up_delay = 25;
        }
        [JsonProperty("Mouse")]
        public Mouse mouse = new Mouse();
        public class Mouse
        {
            [JsonProperty("Down delay")]
            public int mouse_down_delay = 0;
            [JsonProperty("Up delay")]
            public int mouse_up_delay = 0;

            [JsonProperty("First slot")]
            public FirstSlot firstSlot = new FirstSlot();
            [JsonProperty("Last slot")]
            public LastSlot lastSlot = new LastSlot();
            [JsonProperty("Other slot's")]
            public OtherSlots otherSlots = new OtherSlots();
            public class FirstSlot
            {
                [JsonProperty("Switch delay")]
                public int slot_switch_delay = 2;
                [JsonProperty("Aim delay")]
                public int slot_aim_delay = 5;
                [JsonProperty("Clicks delay")]
                public int clicks_delay = 2;
                [JsonProperty("Clicks count")]
                public int clicks = 2;
            }
            public class LastSlot
            {
                [JsonProperty("Switch delay")]
                public int slot_switch_delay = 2;
                [JsonProperty("Aim delay")]
                public int slot_aim_delay = 5;
                [JsonProperty("Clicks delay")]
                public int clicks_delay = 2;
                [JsonProperty("Clicks count")]
                public int clicks = 2;
            }
            public class OtherSlots
            {
                [JsonProperty("Switch delay")]
                public int slot_switch_delay = 2;
                [JsonProperty("Aim delay")]
                public int slot_aim_delay = 5;
                [JsonProperty("Clicks delay")]
                public int clicks_delay = 2;
                [JsonProperty("Clicks count")]
                public int clicks = 2;
            }
        }
        #region Настройка включения настройки начального слота
        #endregion
        [JsonProperty("Chests")]
        public Chests chests = new Chests();

        public class Chests
        {
            [JsonProperty("Offset")]
            public int offset = 35;
            [JsonProperty("Chest 9x3")]
            public Chest9x3 chest9x3 = new Chest9x3();
            [JsonProperty("Chest 9x6")]
            public Chest9x6 chest9x6 = new Chest9x6();


            public class Chest9x3
            {
                [JsonProperty("Fist slot location")]
                public Point first_slot = new Point(0, 0);
                [JsonProperty("Binds")]
                public Binds binds = new Binds();
                public class Binds
                {
                    [JsonProperty("Enable")]
                    [JsonConverter(typeof(StringEnumConverter))]
                    public Keys enable = Keys.None;
                    [JsonProperty("Set fist slot location")]
                    [JsonConverter(typeof(StringEnumConverter))]
                    public Keys setlocation = Keys.None;
                }
            }
            public class Chest9x6
            {
                [JsonProperty("Fist slot location")]
                public Point first_slot = new Point(0, 0);
                [JsonProperty("Binds")]
                public Binds binds = new Binds();
                public class Binds
                {
                    [JsonProperty("Enable")]
                    [JsonConverter(typeof(StringEnumConverter))]
                    public Keys enable = Keys.None;
                    [JsonProperty("Set fist slot location")]
                    [JsonConverter(typeof(StringEnumConverter))]
                    public Keys setlocation = Keys.None;
                }
            }
        }

        #region Автоматизация
        [JsonProperty("Auto close chest")]
        public AutoCloseChest auto_close_chest = new AutoCloseChest();
        [JsonProperty("Auto open chest")]
        public AutoOpenChest auto_open_chest = new AutoOpenChest();
        public class AutoCloseChest
        {
            [JsonProperty("Enabled")]
            public bool enabled = false;
        }
        public class AutoOpenChest
        {
            [JsonProperty("Enabled")]
            public bool enabled = false;
            [JsonProperty("Delay")]
            public int delay = 500;
        }
        #endregion
    }
}
