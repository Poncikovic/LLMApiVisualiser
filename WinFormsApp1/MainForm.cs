using LLMFramework;
using System.ComponentModel;
using System.Windows.Forms;


#pragma warning disable IDE1006 // Naming Styles
namespace LLMApiVisualiser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void listBox_events_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isValid = listBox_events.SelectedItem != null;

            textBox_promptRole.Enabled = isValid;
            textBox_promptText.Enabled = isValid;
            button_generate.Enabled = isValid;
            if (isValid)
            {
                textBox_promptRole.Text = (listBox_events.SelectedItem as PromptEvent)!.Role;
                textBox_promptText.Text = (listBox_events.SelectedItem as PromptEvent)!.Text;

            }
            else
            {
                textBox_promptRole.Text = "";
                textBox_promptText.Text = "";
            }


        }

        private void button_addEvent_Click(object sender, EventArgs e)
        {
            listBox_events.Items.Insert(listBox_events.SelectedIndex + 1, new PromptEvent("user", ""));
            listBox_events.SelectedIndex++;
        }

        private void button_moveUp_Click(object sender, EventArgs e)
        {
            if (listBox_events.SelectedItem == null) { return; }

            PromptEvent tempEvent = (listBox_events.SelectedItem as PromptEvent)!;
            int tempIndex = listBox_events.SelectedIndex;
            if (tempIndex == 0) { return; }

            listBox_events.Items.Insert(tempIndex - 1, tempEvent);
            listBox_events.SelectedIndex = tempIndex - 1;
            listBox_events.Items.RemoveAt(tempIndex + 1);

        }

        private void button_moveDown_Click(object sender, EventArgs e)
        {
            if (listBox_events.SelectedItem == null) { return; }

            PromptEvent tempEvent = (listBox_events.SelectedItem as PromptEvent)!;
            int tempIndex = listBox_events.SelectedIndex;
            if (tempIndex == listBox_events.Items.Count - 1) { return; }

            listBox_events.Items.Insert(tempIndex + 2, tempEvent);
            listBox_events.SelectedIndex = tempIndex + 2;
            listBox_events.Items.RemoveAt(tempIndex);

        }

        private void button_deleteEvent_Click(object sender, EventArgs e)
        {
            if (listBox_events.SelectedIndex == -1) { return; }
            var ind = listBox_events.SelectedIndex;
            listBox_events.Items.RemoveAt(listBox_events.SelectedIndex);
            listBox_events.SelectedIndex = ind - 1;
        }

        private void textBox_promptRole_TextChanged(object sender, EventArgs e)
        {
            if (listBox_events.SelectedItem == null) { return; }
            var previousCursorPos = textBox_promptRole.SelectionStart;

            (listBox_events.SelectedItem as PromptEvent)!.Role = textBox_promptRole.Text;
            UpdateSingleListElement(listBox_events.SelectedIndex);
            textBox_promptRole.Focus();

            textBox_promptRole.SelectionStart = previousCursorPos;
            textBox_promptRole.SelectionLength = 0;

            button_generate.Enabled = (textBox_promptRole.Text.Length > 0);
        }

        private void textBox_promptText_TextChanged(object sender, EventArgs e)
        {
            if (listBox_events.SelectedItem == null) { return; }
            var previousCursorPos = textBox_promptText.SelectionStart;

            (listBox_events.SelectedItem as PromptEvent)!.Text = textBox_promptText.Text;
            textBox_promptText.Focus();

            textBox_promptText.SelectionStart = previousCursorPos;
            textBox_promptText.SelectionLength = 0;
        }


        private void UpdateWholeList()
        {
            int count = listBox_events.Items.Count;
            listBox_events.SuspendLayout();
            for (int i = 0; i < count; i++)
            {
                listBox_events.Items[i] = listBox_events.Items[i]; // This is for invoking the value set function.
            }
            listBox_events.ResumeLayout();

        }
        private void UpdateSingleListElement(int index)
        {
            listBox_events.Items[index] = listBox_events.Items[index]; // This is for invoking the value set function.
        }

        private async void button_generate_Click(object sender, EventArgs e)
        {
            #region If the function is going to replace the text, ask user if they are sure to proceed.
            if ((listBox_events.SelectedItem as PromptEvent)!.Text != String.Empty)
            {
                if (MessageBox.Show(
                    "The generated text will replace current content. Are you sure you want to proceed?",
                    "Before You Continue",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk) != DialogResult.Yes)
                {
                    return;
                }
            }
            #endregion If the function is going to replace the text, ask user if they are sure to proceed.

            #region Disable menu.
            // Make sure GUI is uninteractable until an API result has come.
            groupBox1.Enabled = false;
            #endregion Disable menu.

            #region Prepare roles and prompts into a single list to be sent to the API.
            List<Dictionary<string, object>>? MessageHistory = [];

            for (int ind = 0; ind < listBox_events.SelectedIndex; ind++)
            {
                PromptEvent promptEvent = (PromptEvent)listBox_events.Items[ind];
                MessageHistory.Add(
                    new Dictionary<string, object>
                        {
                            { "role", promptEvent.Role },
                            { "content", promptEvent.Text }
                        }
                );
            }
            #endregion Prepare roles and prompts into a single list to be sent to the API.

            #region Connect to API and retrieve a text.
            string output = String.Empty;
            bool connectingToServer = true;
            while (connectingToServer)
            {
                try
                {
                    output = await (ApiHelper.GetResponseFromApi(((PromptEvent)listBox_events.SelectedItem!).Role, MessageHistory, Convert.ToDouble(numericUpDown_temperature.Value)));
                }
                catch(Exception ex)
                {
                    var userResponse = MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    if(userResponse == DialogResult.Cancel) { connectingToServer = false; }
                }
            }
            #endregion Connect to api and retrieve a text.

            #region Convert output into proper format.
            // Output text should have proper NewLine characters for C#.
            output = output.Replace("\n",System.Environment.NewLine);
            #endregion Convert output into proper format.

            #region Reenable menu, apply output text and refresh textbox.
            this.Invoke((MethodInvoker)delegate
            {
                // Reenable controls.
                groupBox1.Enabled = true;

                // Apply text.
                if (listBox_events.SelectedItem != null)
                    (listBox_events.SelectedItem as PromptEvent)!.Text = output;

                // Refresh so that text can be seen (might need refinement).
                var tmp = listBox_events.SelectedIndex;
                listBox_events.SelectedIndex = -1;
                listBox_events.SelectedIndex = tmp;
            });
            #endregion Reenable menu, apply output text and refresh textbox.
        }
    }

}

#pragma warning restore IDE1006 // Naming Styles