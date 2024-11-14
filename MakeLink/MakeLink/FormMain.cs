using System;
using System.Windows.Forms;

namespace MakeLink
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            comboBox.SelectedIndex = 0;
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

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxCreate.Text = saveFileDialog.FileName;
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
            string creatlk = textBoxCreate.Text.Trim().Replace('/', '\\');
            string pointto = textBoxPointTo.Text.Trim().Replace('/', '\\');
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
            string dir = System.IO.Path.GetDirectoryName(creatlk.TrimEnd('\\'));
            if (!string.IsNullOrEmpty(dir)&&!dir.EndsWith("\\"))
            {
                dir += "\\";
            }
            if (checkBoxXD.Checked && System.IO.Directory.Exists(dir))
            {
                creatlk = ToXiangdui(dir, creatlk.TrimEnd('\\'));
                pointto = ToXiangdui(dir, pointto.TrimEnd('\\'));
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
            p.StartInfo.FileName = "cmd";
            //p.StartInfo.Verb = "runas";
            if (System.IO.Directory.Exists(dir))
            {
                p.StartInfo.WorkingDirectory = dir;
            }
            string argcmd = "/c";
            argcmd += $" \"{mklink}\"";
            p.StartInfo.Arguments = argcmd;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;
            textBoxCMD.AppendText($"{p.StartInfo.WorkingDirectory}>{mklink}" + "\r\n");
            p.Start();
            string err = p.StandardError.ReadToEnd();
            string result = p.StandardOutput.ReadToEnd();
            //p.WaitForExit();
            p.Close();
            
            if (!string.IsNullOrWhiteSpace(result))
            {
                textBoxCMD.AppendText(result + "\r\n");
            }

            if (!string.IsNullOrWhiteSpace(err))
            {
                textBoxCMD.AppendText(err + "\r\n");
                MessageBox.Show(err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(result, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string ToXiangdui(string textM, string textQ)
        {
            string pM = FitPath(textM);
            string pQ = FitPath(textQ);
            if (string.IsNullOrEmpty(pM) || string.IsNullOrEmpty(pQ))
            {
                return textQ;
            }
            string[] sM = pM.Split('\\');
            string[] sQ = pQ.Split('\\');
            int len = Math.Min(sM.Length, sQ.Length);
            int sameIndex = -1;
            for (int i = 0; i < len - 1; i++)
            {
                if (sM[i].ToLower() == sQ[i].ToLower())
                {
                    sameIndex = i;
                }
                else
                {
                    break;
                }
            }
            if (sameIndex < 0)
            {
                return textQ;
            }
            string s1 = "";
            for (int i = sameIndex + 1; i < sM.Length - 1; i++)
            {
                s1 += "..\\";
            }
            for (int i = sameIndex + 1; i < sQ.Length - 1; i++)
            {
                s1 += sQ[i] + "\\";
            }
            s1 += sQ[sQ.Length - 1];
            return s1;
        }

        private string FitPath(string p)
        {
            if (string.IsNullOrEmpty(p))
            {
                return "";
            }
            p = p.Replace('/', '\\');
            string[] s1 = p.Split('\\');
            System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] == ".." && i != s1.Length - 1)
                {
                    if (lst.Count > 0)
                    {
                        lst.RemoveAt(lst.Count - 1);
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (s1[i] != "." && s1[i] != "")
                {
                    lst.Add(s1[i]);
                }
            }
            string pnew = p.StartsWith("\\") ? "\\" : "";
            if (lst.Count > 0)
            {
                pnew += string.Join("\\", lst);
                if (p.EndsWith("\\"))
                {
                    pnew += "\\";
                }
            }
            return pnew;
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
