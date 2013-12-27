using System;
using System.Windows.Forms;

namespace Codifier
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void PasteTextIntoInputTextBox()
        {
            if (!Clipboard.ContainsText())
                return;

            var text = Clipboard.GetText();
            inputTextBox.Text = text;
        }

        private void CopyPastFromTextBox()
        {
            var text = outputTextBox.Text;
            if (!string.IsNullOrEmpty(text))
                Clipboard.SetText(text);
        }

        private void UpdateOutputTextBox()
        {
            var input = inputTextBox.Text;
            var output = BlogPost.GenerateHtml(input);
            outputTextBox.Text = output;
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (autoPasteCheckBox.Checked)
                PasteTextIntoInputTextBox();
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateOutputTextBox();
        }

        private void outputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (autoCopyCheckBox.Checked)
                CopyPastFromTextBox();
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            PasteTextIntoInputTextBox();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            UpdateOutputTextBox();
        }
    }
}
