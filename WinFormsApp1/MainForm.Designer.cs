namespace LLMApiVisualiser
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox_events = new ListBox();
            label1 = new Label();
            textBox_promptText = new TextBox();
            button_moveUp = new Button();
            button_moveDown = new Button();
            button_deleteEvent = new Button();
            button_generate = new Button();
            button_addEvent = new Button();
            textBox_promptRole = new TextBox();
            groupBox1 = new GroupBox();
            numericUpDown_temperature = new NumericUpDown();
            label2 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_temperature).BeginInit();
            SuspendLayout();
            // 
            // listBox_events
            // 
            listBox_events.Font = new Font("Cascadia Code ExtraLight", 9F);
            listBox_events.HorizontalScrollbar = true;
            listBox_events.Location = new Point(6, 47);
            listBox_events.Name = "listBox_events";
            listBox_events.Size = new Size(150, 364);
            listBox_events.TabIndex = 0;
            listBox_events.SelectedIndexChanged += listBox_events_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(150, 25);
            label1.TabIndex = 1;
            label1.Text = "Events";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox_promptText
            // 
            textBox_promptText.Enabled = false;
            textBox_promptText.Location = new Point(262, 80);
            textBox_promptText.Multiline = true;
            textBox_promptText.Name = "textBox_promptText";
            textBox_promptText.PlaceholderText = "Enter Text...";
            textBox_promptText.ScrollBars = ScrollBars.Vertical;
            textBox_promptText.Size = new Size(508, 323);
            textBox_promptText.TabIndex = 3;
            textBox_promptText.TextChanged += textBox_promptText_TextChanged;
            // 
            // button_moveUp
            // 
            button_moveUp.Location = new Point(162, 47);
            button_moveUp.Name = "button_moveUp";
            button_moveUp.Size = new Size(94, 49);
            button_moveUp.TabIndex = 6;
            button_moveUp.Text = "Move Up";
            button_moveUp.UseVisualStyleBackColor = true;
            button_moveUp.Click += button_moveUp_Click;
            // 
            // button_moveDown
            // 
            button_moveDown.Location = new Point(162, 102);
            button_moveDown.Name = "button_moveDown";
            button_moveDown.Size = new Size(94, 49);
            button_moveDown.TabIndex = 7;
            button_moveDown.Text = "Move Down";
            button_moveDown.UseVisualStyleBackColor = true;
            button_moveDown.Click += button_moveDown_Click;
            // 
            // button_deleteEvent
            // 
            button_deleteEvent.Location = new Point(162, 181);
            button_deleteEvent.Name = "button_deleteEvent";
            button_deleteEvent.Size = new Size(94, 49);
            button_deleteEvent.TabIndex = 8;
            button_deleteEvent.Text = "Delete Event";
            button_deleteEvent.UseVisualStyleBackColor = true;
            button_deleteEvent.Click += button_deleteEvent_Click;
            // 
            // button_generate
            // 
            button_generate.Enabled = false;
            button_generate.Location = new Point(162, 330);
            button_generate.Name = "button_generate";
            button_generate.Size = new Size(94, 73);
            button_generate.TabIndex = 9;
            button_generate.Text = "Generate Text On Event";
            button_generate.UseVisualStyleBackColor = true;
            button_generate.Click += button_generate_Click;
            // 
            // button_addEvent
            // 
            button_addEvent.Location = new Point(162, 275);
            button_addEvent.Name = "button_addEvent";
            button_addEvent.Size = new Size(94, 49);
            button_addEvent.TabIndex = 10;
            button_addEvent.Text = "Add Event";
            button_addEvent.UseVisualStyleBackColor = true;
            button_addEvent.Click += button_addEvent_Click;
            // 
            // textBox_promptRole
            // 
            textBox_promptRole.Enabled = false;
            textBox_promptRole.Location = new Point(262, 47);
            textBox_promptRole.Name = "textBox_promptRole";
            textBox_promptRole.PlaceholderText = "Enter Prompt Role";
            textBox_promptRole.Size = new Size(393, 27);
            textBox_promptRole.TabIndex = 11;
            textBox_promptRole.TextChanged += textBox_promptRole_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numericUpDown_temperature);
            groupBox1.Controls.Add(button_generate);
            groupBox1.Controls.Add(button_addEvent);
            groupBox1.Controls.Add(button_deleteEvent);
            groupBox1.Controls.Add(textBox_promptRole);
            groupBox1.Controls.Add(listBox_events);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox_promptText);
            groupBox1.Controls.Add(button_moveDown);
            groupBox1.Controls.Add(button_moveUp);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 426);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            // 
            // numericUpDown_temperature
            // 
            numericUpDown_temperature.DecimalPlaces = 2;
            numericUpDown_temperature.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown_temperature.Location = new Point(661, 47);
            numericUpDown_temperature.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_temperature.Name = "numericUpDown_temperature";
            numericUpDown_temperature.Size = new Size(109, 27);
            numericUpDown_temperature.TabIndex = 12;
            numericUpDown_temperature.Value = new decimal(new int[] { 65, 0, 0, 131072 });
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(661, 26);
            label2.Name = "label2";
            label2.Size = new Size(109, 25);
            label2.TabIndex = 13;
            label2.Text = "Temperature";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_temperature).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox_events;
        private Label label1;
        private TextBox textBox_promptText;
        private Button button_moveUp;
        private Button button_moveDown;
        private Button button_deleteEvent;
        private Button button_generate;
        private Button button_addEvent;
        private TextBox textBox_promptRole;
        private GroupBox groupBox1;
        private NumericUpDown numericUpDown_temperature;
        private Label label2;
    }
}
