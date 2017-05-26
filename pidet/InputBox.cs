using System.Drawing;
using System.Windows.Forms;

namespace Pidet
{
    static class InputBoxes
    {
        public static int NumericInputBox(string prompt = "", string title = "", int defaultResponse = 0, int minValue = 0, int maxValue = 100)
        {
            var nud = new NumericUpDown();
            nud.Location = new Point(12, 84);
            nud.Size = new Size(100, 19);
            nud.Minimum = minValue;
            nud.Maximum = maxValue;
            nud.Value = defaultResponse;

            var okButton = new Button();
            okButton.DialogResult = DialogResult.OK;
            okButton.Location = new Point(266, 9);
            okButton.Size = new Size(75, 23);
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;

            var cancelButton = new Button();
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(266, 38);
            cancelButton.Size = new Size(75, 23);
            cancelButton.Text = "キャンセル";
            cancelButton.UseVisualStyleBackColor = true;

            var label = new Label();
            label.AutoSize = true;
            label.Location = new Point(12, 9);
            label.Size = new Size(0, 12);
            label.Text = prompt;

            var form = new Form();
            form.SuspendLayout();
            form.AcceptButton = okButton;
            form.CancelButton = cancelButton;
            form.AutoScaleDimensions = new SizeF(6F, 12F);
            form.AutoScaleMode = AutoScaleMode.Font;
            form.ClientSize = new Size(353, 120);
            form.ControlBox = false;
            form.Controls.Add(nud);
            form.Controls.Add(okButton);
            form.Controls.Add(cancelButton);
            form.Controls.Add(label);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.ShowInTaskbar = false;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ResumeLayout(false);
            form.PerformLayout();
            form.Text = title;

            if (form.ShowDialog() == DialogResult.OK) return (int)nud.Value;
            else return 0;
        }

    }
}
