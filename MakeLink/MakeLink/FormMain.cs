using System;
using System.Windows.Forms;

namespace MakeLink
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void ButtonShowCMD_Click(object sender, EventArgs e)
        {
            if (buttonShowCMD.Text == "显示命令行>>")
            {
                buttonShowCMD.Text = "隐藏命令行<<";
                textBoxCMD.Visible = true;
                Height = 465;
            }
            else
            {
                buttonShowCMD.Text = "显示命令行>>";
                textBoxCMD.Visible = false;
                Height = 230;
            }
        }

        private void FormMain_Load(object sender, EventArgs e) => comboBox.SelectedIndex = 0;

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            if ((comboBox.SelectedIndex == 0 || comboBox.SelectedIndex == 2) && saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxCreate.Text = saveFileDialog.FileName;
            }
            else if ((comboBox.SelectedIndex == 1 || comboBox.SelectedIndex == 3) && folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxCreate.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void ButtonPointTo_Click(object sender, EventArgs e)
        {
            if ((comboBox.SelectedIndex == 0 || comboBox.SelectedIndex == 2) && openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPointTo.Text = openFileDialog.FileName;
            }
            else if ((comboBox.SelectedIndex == 1 || comboBox.SelectedIndex == 3) && folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPointTo.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void ButtonRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxCreate.Text) || string.IsNullOrWhiteSpace(textBoxPointTo.Text))
            {
                MessageBox.Show("创建目标和指向位置不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCMD.Text = "创建目标和指向位置不能为空！";
                return;
            }
            string cfg;
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    cfg = "";
                    break;
                case 1:
                    cfg = "/d";
                    break;
                case 2:
                    cfg = "/h";
                    break;
                case 3:
                    cfg = "/j";
                    break;
                default:
                    cfg = "";
                    break;
            }
            string creatlk = textBoxCreate.Text.Trim();
            string pointto = textBoxPointTo.Text.Trim();
            if ((cfg == "/d" || cfg == "/j")
                && System.IO.File.Exists(pointto)
                && MessageBox.Show("指向位置是一个文件，确定要创建目录链接吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
            {
                return;
            }
            else if ((cfg == "" || cfg == "/h")
                && System.IO.Directory.Exists(pointto)
                && MessageBox.Show("指向位置是一个目录，确定要创建文件链接吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
            {
                return;
            }
            if (creatlk.Contains(" "))
            {
                creatlk = $"\"{creatlk}\"";
            }
            if (pointto.Contains(" "))
            {
                pointto = $"\"{pointto}\"";
            }
            string mklink = $"mklink {cfg} {creatlk} {pointto}";
            textBoxCMD.Clear();
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            p.StandardOutput.ReadLine();
            p.StandardOutput.ReadLine();
            p.StandardOutput.ReadLine();

            //p.StandardInput.WriteLine("TITLE %cd%");
            //textBoxCMD.AppendText(p.StandardOutput.ReadLine() + "\r\n");
            //textBoxCMD.AppendText(p.StandardOutput.ReadLine() + "\r\n");

            p.StandardInput.WriteLine(mklink);
            textBoxCMD.AppendText(SetOutput(p.StandardOutput.ReadLine()) + "\r\n");
            string result = p.StandardOutput.ReadLine();
            textBoxCMD.AppendText(result + "\r\n");
            p.StandardInput.WriteLine("exit");
            string err = p.StandardError.ReadToEnd();
            textBoxCMD.AppendText(err + "\r\n");
            //textBoxCMD.AppendText(p.StandardOutput.ReadLine() + "\r\n");
            //textBoxCMD.AppendText(p.StandardOutput.ReadLine() + "\r\n");
            //p.StandardOutput.ReadLine();
            //p.StandardOutput.ReadLine();

            //textBoxCMD.AppendText(p.StandardOutput.ReadLine() + "\r\n");
            p.Close();
            if (!string.IsNullOrWhiteSpace(err))
            {
                MessageBox.Show(err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(result, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string SetOutput(string v)
        {
            return v.Contains(">") ? v.Substring(v.IndexOf(">")) : v;
        }

        private void TextBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void TextBox_DragDrop(object sender, DragEventArgs e)
        {
            ((TextBox)sender).Text = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
        }
    }
}
