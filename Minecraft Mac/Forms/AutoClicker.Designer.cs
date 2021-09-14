
namespace Minecraft_Mac.Forms
{
    partial class AutoClicker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxEnableMacro = new System.Windows.Forms.CheckBox();
            this.comboBoxActivationRMB = new System.Windows.Forms.ComboBox();
            this.comboBoxActivationLMB = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxRMBDelay = new System.Windows.Forms.TextBox();
            this.textBoxLMBDelay = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxEnableMacro);
            this.groupBox2.Controls.Add(this.comboBoxActivationRMB);
            this.groupBox2.Controls.Add(this.comboBoxActivationLMB);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 92);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Main settings";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // checkBoxEnableMacro
            // 
            this.checkBoxEnableMacro.AutoSize = true;
            this.checkBoxEnableMacro.Location = new System.Drawing.Point(6, 70);
            this.checkBoxEnableMacro.Name = "checkBoxEnableMacro";
            this.checkBoxEnableMacro.Size = new System.Drawing.Size(91, 17);
            this.checkBoxEnableMacro.TabIndex = 8;
            this.checkBoxEnableMacro.Text = "Enable macro";
            this.checkBoxEnableMacro.UseVisualStyleBackColor = true;
            this.checkBoxEnableMacro.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // comboBoxActivationRMB
            // 
            this.comboBoxActivationRMB.FormattingEnabled = true;
            this.comboBoxActivationRMB.Location = new System.Drawing.Point(6, 43);
            this.comboBoxActivationRMB.Name = "comboBoxActivationRMB";
            this.comboBoxActivationRMB.Size = new System.Drawing.Size(137, 21);
            this.comboBoxActivationRMB.TabIndex = 26;
            this.comboBoxActivationRMB.Text = "Activation key RMB";
            this.comboBoxActivationRMB.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboBoxActivationLMB
            // 
            this.comboBoxActivationLMB.FormattingEnabled = true;
            this.comboBoxActivationLMB.Location = new System.Drawing.Point(6, 16);
            this.comboBoxActivationLMB.Name = "comboBoxActivationLMB";
            this.comboBoxActivationLMB.Size = new System.Drawing.Size(137, 21);
            this.comboBoxActivationLMB.TabIndex = 9;
            this.comboBoxActivationLMB.Text = "Activation key LMB";
            this.comboBoxActivationLMB.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxRMBDelay);
            this.groupBox1.Controls.Add(this.textBoxLMBDelay);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(12, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 76);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CPS";
            // 
            // textBoxRMBDelay
            // 
            this.textBoxRMBDelay.Location = new System.Drawing.Point(39, 49);
            this.textBoxRMBDelay.Name = "textBoxRMBDelay";
            this.textBoxRMBDelay.Size = new System.Drawing.Size(104, 20);
            this.textBoxRMBDelay.TabIndex = 25;
            this.textBoxRMBDelay.Text = "500";
            this.textBoxRMBDelay.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            this.textBoxRMBDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPress);
            // 
            // textBoxLMBDelay
            // 
            this.textBoxLMBDelay.Location = new System.Drawing.Point(39, 23);
            this.textBoxLMBDelay.Name = "textBoxLMBDelay";
            this.textBoxLMBDelay.Size = new System.Drawing.Size(104, 20);
            this.textBoxLMBDelay.TabIndex = 43;
            this.textBoxLMBDelay.Text = "500";
            this.textBoxLMBDelay.TextChanged += new System.EventHandler(this.textBox12_TextChanged);
            this.textBoxLMBDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox12_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 42;
            this.label13.Text = "LMB:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "RMB:";
            // 
            // AutoClicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 197);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoClicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clicker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoClicker_FormClosing);
            this.Load += new System.EventHandler(this.AutoClicker_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.CheckBox checkBoxEnableMacro;
        public System.Windows.Forms.ComboBox comboBoxActivationRMB;
        public System.Windows.Forms.ComboBox comboBoxActivationLMB;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox textBoxRMBDelay;
        public System.Windows.Forms.TextBox textBoxLMBDelay;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
    }
}