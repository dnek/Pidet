using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace pidet
{
    public partial class main : Form
    {
        #region Definitions

        public static string InputBox(string Prompt = "", string Title = "", string DefaultResponse = "")
        {
            var textBox = new TextBox();
            textBox.Location = new Point(12, 84);
            textBox.Size = new Size(329, 19);
            textBox.Text = DefaultResponse;

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
            label.Text = Prompt;

            var form = new Form();
            form.SuspendLayout();
            form.AcceptButton = okButton;
            form.CancelButton = cancelButton;
            form.AutoScaleDimensions = new SizeF(6F, 12F);
            form.AutoScaleMode = AutoScaleMode.Font;
            form.ClientSize = new Size(353, 120);
            form.ControlBox = false;
            form.Controls.Add(textBox);
            form.Controls.Add(okButton);
            form.Controls.Add(cancelButton);
            form.Controls.Add(label);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.ShowInTaskbar = false;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ResumeLayout(false);
            form.PerformLayout();
            form.Text = Title;

            if (form.ShowDialog() == DialogResult.OK) return textBox.Text;
            else return null;
        }

        public static int NumericInputBox(string Prompt = "", string Title = "", int DefaultResponse = 0, int MinValue = 0, int MaxValue = 100)
        {
            var nud = new NumericUpDown();
            nud.Location = new Point(12, 84);
            nud.Size = new Size(100, 19);
            nud.Minimum = MinValue;
            nud.Maximum = MaxValue;
            nud.Value = DefaultResponse;

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
            label.Text = Prompt;

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
            form.Text = Title;

            if (form.ShowDialog() == DialogResult.OK) return (int)nud.Value;
            else return 0;
        }

        static string FF_FILTER = "Image|*.png;*.bmp|PNG|*.png|Bitmap|*.bmp";

        class pColor
        {
            public const int LRed = 0, Red = 1, DRed = 2, LYellow = 3, Yellow = 4, DYellow = 5,
                LGreen = 6, Green = 7, DGreen = 8, LCyan = 9, Cyan = 10, DCyan = 11, 
                    LBlue = 12, Blue = 13, DBlue = 14, LMagenta = 15, Magenta = 16, DMagenta = 17, White = 18, Black = 19;
        }
        List<List<int>> codel = new List<List<int>>(), buffer = new List<List<int>>();
        List<List<bool>> bp = new List<List<bool>>();
        List<List<List<int>>> history = new List<List<List<int>>>();
        int cSize = 20, sX = 3, sY = 3, editMode = 0, hisIndex = -1, currentColor = 0, standardColor = 0; //editmode: 0=pen, 1=selector, 2=debug
        bool penWriting = false;

        int fileCSize = 10;
        string fileName = "NoName", filePath = "";
        bool saveRequired = false;

        int ccX, ccY, ncX, ncY, dp, cc, wc, sc;
        string inputStr, inputStrTmp, outputStr, currentCommand;
        bool inputRequired = false, paused = true;
        List<int> stack;
        List<List<int>> cbSize = new List<List<int>>();
        List<List<List<List<int>>>> corner = new List<List<List<List<int>>>>(); //R, D, L, U
        string[] commandsName = 
            { "*", "push", "pop", "add", "sub", "multi", "div", "mod", "not",
                "great", "point", "switch", "dup", "roll", "in(n)", "in(c)", "out(n)", "out(c)" },
                dpName = { "→(0)", "↓(1)", "←(2)", "↑(3)" },
                ccName = { "L(0)", "R(1)" };

        #endregion

        void ChangeEditMode(int e)
        {
            if (e == -1) e = dgv_field.MultiSelect ? 1 : 0;
            if (e == -2) e = dgv_field.MultiSelect ? 0 : 1;
            editMode = e;
            if (e == 0)
            {
                //dgv_field.Enabled = true;
                btn_change.Enabled = true;
                btn_reset.Enabled = false;
                dgv_field.Cursor = Cursors.Hand;
                dgv_field.MultiSelect = false;
                dgv_field.Refresh();
                lbl_status.BackColor = Color.Lavender;
            }
            else if (e == 1)
            {
                //dgv_field.Enabled = true;
                btn_change.Enabled = true;
                btn_reset.Enabled = false;
                dgv_field.Cursor = Cursors.Cross;
                dgv_field.MultiSelect = true;
                dgv_field.Refresh();
                lbl_status.BackColor = Color.Lavender;
            }
            else
            {
                //dgv_field.Enabled = false;
                btn_reset.Enabled = true;
                btn_change.Enabled = false;
                dgv_field.Cursor = Cursors.Default;
                lbl_status.BackColor = Color.LavenderBlush;
            }
        }

        #region Debug

        string ReplaceCrLf(string e, bool istoLF = true)
        {
            if (istoLF) return e.Replace("\r\n", "\n");
            else return e.Replace("\r\n", "\n").Replace("\n", "\r\n");
        }

        void PrepareDebug()
        {
            ChangeEditMode(2);
            ccX = ccY = ncX = ncY = dp = cc = wc = sc = 0;
            inputStr = inputStrTmp = ReplaceCrLf(tb_input.Text);
            outputStr = currentCommand = "";
            inputRequired = false;
            stack = new List<int>();
            cbSize.Clear();
            corner.Clear();
            for (int i = 0; i < sX; i++)
            {
                cbSize.Add(new List<int>());
                corner.Add(new List<List<List<int>>>());
                for (int j = 0; j < sY; j++)
			    {
                    cbSize[i].Add(0);
                    corner[i].Add(new List<List<int>>());
			    }
            }
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            #region algo1
            for (int i = 0; i < sX; i++)
            {
                for (int j = 0; j < sY; j++)
                {
                    if (corner[i][j].Count > 0) continue;
                    if (codel[i][j] == pColor.White || codel[i][j] == pColor.Black) continue;
                    List<Point> e1 = new List<Point> { new Point(i, j) }, e2 = new List<Point>();
                    List<List<int>> e3 = new List<List<int>>();
                    for (int k = 0; k < 2; k++)
                    {
                        e3.Add(new List<int> { i, j, j });
                        e3.Add(new List<int> { j, i, i });
                    }
                    while (e1.Count > 0)
                    {
                        int eX = e1[0].X, eY = e1[0].Y;
                        if ((eX > -1 && eX < sX && eY > -1 && eY < sY) && (!e2.Contains(new Point(eX, eY)) && codel[eX][eY] == codel[i][j]))
                        {
                            e2.Add(new Point(eX, eY));
                            if (eX == e3[0][0]) //R
                            {
                                e3[0][0] = eX;
                                if (eY < e3[0][1]) e3[0][1] = eY;
                                if (eY > e3[0][2]) e3[0][2] = eY;
                            }
                            else if (eX > e3[0][0])
                            {
                                e3[0][0] = eX;
                                e3[0][1] = e3[0][2] = eY;
                            }

                            if (eY == e3[1][0]) //D
                            {
                                e3[1][0] = eY;
                                if (eX > e3[1][1]) e3[1][1] = eX;
                                if (eX < e3[1][2]) e3[1][2] = eX;
                            }
                            else if (eY > e3[1][0])
                            {
                                e3[1][0] = eY;
                                e3[1][1] = e3[1][2] = eX;
                            }

                            if (eX == e3[2][0]) //L
                            {
                                e3[2][0] = eX;
                                if (eY > e3[2][1]) e3[2][1] = eY;
                                if (eY < e3[2][2]) e3[2][2] = eY;
                            }
                            else if (eX < e3[2][0])
                            {
                                e3[2][0] = eX;
                                e3[2][1] = e3[2][2] = eY;
                            }

                            if (eY == e3[3][0]) //U
                            {
                                e3[3][0] = eY;
                                if (eX < e3[3][1]) e3[3][1] = eX;
                                if (eX > e3[3][2]) e3[3][2] = eX;
                            }
                            else if (eY < e3[3][0])
                            {
                                e3[3][0] = eY;
                                e3[3][1] = e3[3][2] = eX;
                            }

                            e1.Add(new Point(eX - 1, eY));
                            e1.Add(new Point(eX + 1, eY));
                            e1.Add(new Point(eX, eY - 1));
                            e1.Add(new Point(eX, eY + 1));
                        }
                        e1.RemoveAt(0);
                    }
                    int e2c = e2.Count;
                    foreach (Point item in e2)
                    {
                        cbSize[item.X][item.Y] = e2c;
                        for (int k = 0; k < 4; k++)
                        {
                            corner[item.X][item.Y].Add(new List<int>());
                            for (int l = 0; l < 3; l++)
                            {
                                corner[item.X][item.Y][k].Add(0);
                            }
                        }
                        for (int k = 0; k < 4; k++)
                        {
                            for (int l = 0; l < 3; l++)
                            {
                                corner[item.X][item.Y][k][l] = e3[k][l];
                            }
                        }
                    }
                }
            }
            #endregion
            //sw.Stop();
            //MessageBox.Show(sw.ElapsedMilliseconds.ToString());
            #region algo2
            //List<List<Point>> blocks = new List<List<Point>>();
            //List<List<int>> blnum = new List<List<int>>();
            //List<int> linenum = new List<int>();
            //for (int i = 0; i < sX; i++)
            //{
            //    int now = 0;
            //    blocks.Add(new List<Point> { new Point(i, 0) });
            //    for (int j = 1; j < sY; j++)
            //    {
            //        if (codel[i][j] == codel[i][j - 1]) blocks[now].Add(new Point(i, j));
            //        else
            //        {
            //            blocks.Add(new List<Point> { new Point(i, j) });
            //            ++now;
            //        }
            //        linenum.Add(now);
            //    }
            //}
            #endregion
        }

        void AdvanceDebug()
        {
            if (wc == 0 && !inputRequired)
            {
                ccX = ncX;
                ccY = ncY;
            }
            if (inputRequired)
            {
                inputStr = ReplaceCrLf(tb_input.Text);
                inputRequired = false;
            }
            else
            {
                ++sc;
            }
            int coX = corner[ccX][ccY][dp][0], coY = corner[ccX][ccY][dp][cc + 1],
                dX = -(dp - 1) % 2, dY = -(dp - 2) % 2;
            if (dp % 2 == 0)
            {
                coX = corner[ccX][ccY][dp][0];
                coY = corner[ccX][ccY][dp][cc + 1];
            }
            else
            {
                coX = corner[ccX][ccY][dp][cc + 1];
                coY = corner[ccX][ccY][dp][0];
            }
            ncX = coX + dX;
            ncY = coY + dY;
            if (ncX < 0 || ncX > sX - 1 || ncY < 0 || ncY > sY - 1)
            {
                Wait();
                return;
            }
            if (codel[ncX][ncY] == pColor.Black)
            {
                Wait();
                return;
            }
            if (codel[ncX][ncY] != pColor.White)
            {
                wc = 0;
                int n = codel[ncX][ncY], c = codel[ccX][ccY],
                    diff = (n % 3 - c % 3 + 3) % 3 + (n / 3 - c / 3 + 6) % 6 * 3, last = stack.Count - 1;
                currentCommand = commandsName[diff];
                switch (diff)
                {
                    case 1: //push
                        stack.Add(cbSize[ccX][ccY]);
                        break;
                    case 2: //pop
                        if (stack.Count == 0) break;
                        stack.RemoveAt(last);
                        break;
                    case 3: //add
                        if (stack.Count < 2) break;
                        stack[last - 1] += stack[last];
                        stack.RemoveAt(last);
                        break;
                    case 4: //sub
                        if (stack.Count < 2) break;
                        stack[last - 1] -= stack[last];
                        stack.RemoveAt(last);
                        break;
                    case 5: //multi
                        if (stack.Count < 2) break;
                        stack[last - 1] *= stack[last];
                        stack.RemoveAt(last);
                        break;
                    case 6: //div
                        if (stack.Count < 2) break;
                        if (stack[last] == 0) break;
                        stack[last - 1] /= stack[last];
                        stack.RemoveAt(last);
                        break;
                    case 7: //mod
                        if (stack.Count < 2) break;
                        if (stack[last] == 0) break;
                        stack[last - 1] %= stack[last];
                        if (stack[last] * stack[last - 1] < 0) stack[last - 1] += stack[last];
                        stack.RemoveAt(last);
                        break;
                    case 8: //not
                        if (stack.Count == 0) break;
                        if (stack[last] == 0) stack[last] = 1;
                        else stack[last] = 0;
                        break;
                    case 9: //great
                        if (stack.Count < 2) break;
                        if (stack[last - 1] > stack[last])
                        {
                            stack.RemoveRange(last - 1, 2);
                            stack.Add(1);
                        }
                        else
                        {
                            stack.RemoveRange(last - 1, 2);
                            stack.Add(0);
                        }
                        break;
                    case 10: //point
                        if (stack.Count == 0) break;
                        dp = ((dp + stack[last]) % 4 + 4) % 4;
                        stack.RemoveAt(last);
                        break;
                    case 11: //switch
                        if (stack.Count == 0) break;
                        cc = ((cc + stack[last]) % 2 + 2) % 2;
                        stack.RemoveAt(last);
                        break;
                    case 12: //dup
                        if (stack.Count == 0) break;
                        stack.Add(stack[last]);
                        break;
                    case 13: //roll
                        if (stack.Count < 2) break;
                        if (stack[last - 1] < 0) break;
                        if (stack.Count - 2 < stack[last - 1]) break;
                        int rd = stack[last - 1], rc = (stack[last] % rd + rd) % rd;
                        for (int i = 0; i < rc; i++)
                        {
                            for (int j = 0; j < rd; j++)
                            {
                                stack[last - j - 1] = stack[last - j - 2];
                            }
                            stack[last - rd - 1] = stack[last - 1];
                        }
                        stack.RemoveRange(last - 1, 2);
                        break;
                    case 14: //in(n)
                        string[] tmp = inputStr.Split((string[])null, System.StringSplitOptions.RemoveEmptyEntries);
                        if (tmp.Length == 0)
                        {
                            paused = true;
                            inputRequired = true;
                            break;
                        }
                        int innum;
                        if(int.TryParse(tmp[0], out innum))
                        {
                            stack.Add(innum);
                            inputStr = inputStr.Remove(0, inputStr.IndexOf(tmp[0]) + tmp[0].Length);
                        }
                        break;
                    case 15: //in(c)
                        if (inputStr.Length == 0)
                        {
                            paused = true;
                            inputRequired = true;
                            break;
                        }
                        stack.Add(inputStr[0]);
                        inputStr = inputStr.Remove(0, 1);
                        break;
                    case 16: //out(n)
                        if (stack.Count == 0) break;
                        outputStr += stack[last].ToString();
                        stack.RemoveAt(last);
                        break;
                    case 17: //out(c)
                        if (stack.Count == 0) break;
                        try
                        {
                        outputStr += Convert.ToChar(stack[last]);
                        }
                        catch (Exception)
                        {
                            break;
                        }
                        stack.RemoveAt(last);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                while (true)
                {
                    ncX += dX;
                    ncY += dY;
                    if (ncX < 0 || ncX > sX - 1 || ncY < 0 || ncY > sY - 1)
                    {
                        Wait();
                        return;
                    }
                    if (codel[ncX][ncY] == pColor.Black)
                    {
                        Wait();
                        return;
                    }
                    if (codel[ncX][ncY] != pColor.White) //noop
                    {
                        wc = 0;
                        currentCommand = "noop";
                        return;
                    }
                }
            }
        }

        void Wait()
        {
            if (wc == 7) EndDebug("デバッグが終了しました。");
            if (wc % 2 == 0) cc = (cc + 1) % 2;
            else dp = (dp + 1) % 4;
            ++wc;
            currentCommand = "wait(" + wc.ToString() + ")";
        }

        void StartDebug(bool stepF = false, bool jumpF = false)
        {
            if (codel[0][0] == pColor.White || codel[0][0] == pColor.Black)
            {
                MessageBox.Show("左上のcodelが白または黒です。");
                return;
            }
            int jumpT = 0;
            if (jumpF)
            {
                jumpT = NumericInputBox("ジャンプする回数を指定して下さい。", "Pidet", 1, 1, 1000000000);
                if (jumpT == 0) return;
            }
            if (editMode != 2) PrepareDebug();
            if (stepF)
            {
                AdvanceDebug();
            }
            else if (jumpF)
            {
                int stepCount = 0;
                paused = false;
                while (!paused)
                {
                    AdvanceDebug();
                    ++stepCount;
                    if (ncX > -1 && ncX < sX && ncY > -1 && ncY < sY)
                    {
                        if (bp[ncX][ncY])
                        {
                            paused = true;
                            break;
                        }
                    }
                    if (stepCount == jumpT)
                    {
                        paused = true;
                    }
                }
            }
            else
            {
                paused = false;
                int stepCount = 0;
                while (!paused)
                {
                    AdvanceDebug();
                    ++stepCount;
                    if (ncX > -1 && ncX < sX && ncY > -1 && ncY < sY)
                    {
                        if (bp[ncX][ncY])
                        {
                            paused = true;
                            break;
                        }
                    }
                    if (stepCount == 1000000)
                    {
                        DialogResult result = MessageBox.Show("処理が1,000,000回続いています。中断しますか？", "Pidet", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes) EndDebug("デバッグを中断しました。");
                        else stepCount = 0;
                    }
                }
            }
            if (editMode == 2) PauseDebug();
        }

        void PauseDebug()
        {
            if (inputRequired)
            {
                MessageBox.Show("インプットが必要です。");
            }
            RefreshDebugStatus();
        }

        void RefreshDebugStatus()
        {
            tb_input.Text = ReplaceCrLf(inputStr, false);
            tb_output.Text = ReplaceCrLf(outputStr, false);
            string stackStr = "";
            foreach (int item in stack)
            {
                if (item < 32) stackStr += item.ToString() + "(??)\r\n";
                else
                {
                    try
                    {
                        stackStr += item.ToString() + "(" + Convert.ToChar(item) + ")\r\n";
                    }
                    catch (Exception)
                    {
                        stackStr += item.ToString() + "(??)\r\n";
                    }
                }
            }
            tb_stackbefore.Text = tb_stack.Text;
            tb_stack.Text = stackStr;
            dgv_field.Refresh();
        }

        void EndDebug(string msg = "")
        {
            if (msg != "") MessageBox.Show(msg);
            paused = true;
            ChangeEditMode(-1);
            tb_input.Text = ReplaceCrLf(inputStrTmp, false);
            tb_output.Text = ReplaceCrLf(outputStr, false);
            tb_stack.Text = "";
            tb_stackbefore.Text = "";
            dgv_field.Refresh();
        }

        void ResetDebug()
        {
            EndDebug("デバッグを中断しました。");
        }

        #endregion

        #region Edit

        void SetSaveRequired(bool e)
        {
            saveRequired = e;
            if (hisIndex > 0 && saveRequired) this.Text = fileName + " * - Pidet";
            else this.Text = fileName + " - Pidet";
        }

        void AddHistory()
        {
            ++hisIndex;
            SetSaveRequired(true);
            int c = history.Count;
            for (int i = hisIndex; i < c; i++)
            {
                history.RemoveAt(hisIndex);
            }
            history.Add(new List<List<int>>());
            for (int i = 0; i < sX; i++)
            {
                history[hisIndex].Add(new List<int>());
                for (int j = 0; j < sY; j++)
                {
                    history[hisIndex][i].Add(codel[i][j]);
                }
            }
        }

        void UndoHistory()
        {
            if (hisIndex < 1) return;
            --hisIndex;
            SynchronizeHistoryToCodel();
        }

        void RedoHistory()
        {
            if (hisIndex == history.Count - 1) return;
            ++hisIndex;
            SynchronizeHistoryToCodel();
        }

        void ResetHistory()
        {
            history.Clear();
            hisIndex = -1;
            AddHistory();
        }

        void SynchronizeHistoryToCodel()
        {
            //codel.Clear();
            //sX = history[hisIndex].Count;
            //sY = history[hisIndex][0].Count;
            //for (int i = 0; i < sX; i++)
            //{
            //    codel.Add(new List<int>());
            //    for (int j = 0; j < sY; j++)
            //    {
            //        codel[i].Add(history[hisIndex][i][j]);
            //    }
            //}
            //RefreshField();
            ChangeSX(history[hisIndex].Count);
            ChangeSY(history[hisIndex][0].Count);
            for (int i = 0; i < sX; i++)
            {
                for (int j = 0; j < sY; j++)
                {
                    codel[i][j] = history[hisIndex][i][j];
                }
            }
            RefreshField();
        }

        void RefreshField()
        {
            ChangeFieldX(sX);
            ChangeFieldY(sY);
            for (int i = 0; i < sX; i++)
            {
                for (int j = 0; j < sY; j++)
                {
                    dgv_field[i, j].Style.BackColor = ColorByIndex(codel[i][j]);
                }
            }
        }

        void ResetCodel()
        {
            codel.Clear();
            for (int i = 0; i < sX; i++)
            {
                codel.Add(new List<int>());
                for (int j = 0; j < sY; j++)
                {
                    codel[i].Add(pColor.White);
                }
            }
        }

        void ResetBP()
        {
            bp.Clear();
            for (int i = 0; i < sX; i++)
            {
                bp.Add(new List<bool>());
                for (int j = 0; j < sY; j++)
                {
                    bp[i].Add(false);
                }
            }
        }

        void ChangeFieldX(int e)
        {
            if (e < 1) return;
            int fieldX = dgv_field.ColumnCount;
            if (e < fieldX)
            {
                for (int i = e; i < fieldX; i++)
                {
                    dgv_field.Columns.RemoveAt(e);
                }
            }
            else if (e > fieldX)
            {
                for (int i = fieldX; i < e; i++)
                {
                    dgv_field.Columns.Add("", "");
                    dgv_field.Columns[i].Width = cSize;
                }
            }
        }

        void ChangeFieldY(int e)
        {
            if (e < 1) return;
            int fieldY = dgv_field.RowCount;
            if (e < fieldY)
            {
                for (int i = e; i < fieldY; i++)
                {
                    dgv_field.Rows.RemoveAt(e);
                }
            }
            else if (e > fieldY)
            {
                for (int i = fieldY; i < e; i++)
                {
                    dgv_field.Rows.Add();
                    dgv_field.Rows[i].Height = cSize;
                }
            }
        }

        void ChangeCSize(int e)
        {
            if (e < 5) return;
            cSize = e;
            for (int i = 0; i < sX; i++)
            {
                dgv_field.Columns[i].Width = cSize;
            }
            for (int i = 0; i < sY; i++)
            {
                dgv_field.Rows[i].Height = cSize;
            }
        }

        void ChangeSX(int e)
        {
            if (e < 1) return;
            if (e < sX)
            {
                for (int i = e; i < sX; i++)
                {
                    codel.RemoveAt(e);
                    bp.RemoveAt(e);
                    dgv_field.Columns.RemoveAt(e);
                }
            }
            else if (e > sX)
            {
                for (int i = sX; i < e; i++)
                {
                    codel.Add(new List<int>());
                    bp.Add(new List<bool>());
                    for (int j = 0; j < sY; j++)
                    {
                        codel[i].Add(pColor.White);
                        bp[i].Add(false);
                    }
                    dgv_field.Columns.Add("", "");
                    dgv_field.Columns[i].Width = cSize;
                }
            }
            sX = e;
        }

        void ChangeSY(int e)
        {
            if (e < 1) return;
            if (e < sY)
            {
                for (int i = e; i < sY; i++)
                {
                    for (int j = 0; j < sX; j++)
                    {
                        codel[j].RemoveAt(e);
                        bp[j].RemoveAt(e);
                    }
                    dgv_field.Rows.RemoveAt(e);
                }
            }
            else if (e > sY)
            {
                for (int i = sY; i < e; i++)
                {
                    for (int j = 0; j < sX; j++)
                    {
                        codel[j].Add(pColor.White);
                        bp[j].Add(false);
                    }
                    dgv_field.Rows.Add();
                    dgv_field.Rows[i].Height = cSize;
                }
            }
            sY = e;
        }

        void ChangeSXSY()
        {
            int newSX = NumericInputBox("キャンバスの幅を指定して下さい。", "Pidet", sX, 1, 100000);
            if (newSX == 0) return;
            int newSY = NumericInputBox("キャンバスの高さを指定して下さい。", "Pidet", sY, 1, 100000);
            if (newSY == 0) return;
            ChangeSX(newSX);
            ChangeSY(newSY);
            AddHistory();
        }

        Color ColorByIndex(int e)
        {
            const int C0 = 192, FF = 255;
            switch (e)
            {
                case pColor.LRed:
                    return Color.FromArgb(FF, C0, C0);
                case pColor.Red:
                    return Color.FromArgb(FF, 0, 0);
                case pColor.DRed:
                    return Color.FromArgb(C0, 0, 0);
                case pColor.LYellow:
                    return Color.FromArgb(FF, FF, C0);
                case pColor.Yellow:
                    return Color.FromArgb(FF, FF, 0);
                case pColor.DYellow:
                    return Color.FromArgb(C0, C0, 0);
                case pColor.LGreen:
                    return Color.FromArgb(C0, FF, C0);
                case pColor.Green:
                    return Color.FromArgb(0, FF, 0);
                case pColor.DGreen:
                    return Color.FromArgb(0, C0, 0);
                case pColor.LCyan:
                    return Color.FromArgb(C0, FF, FF);
                case pColor.Cyan:
                    return Color.FromArgb(0, FF, FF);
                case pColor.DCyan:
                    return Color.FromArgb(0, C0, C0);
                case pColor.LBlue:
                    return Color.FromArgb(C0, C0, FF);
                case pColor.Blue:
                    return Color.FromArgb(0, 0, FF);
                case pColor.DBlue:
                    return Color.FromArgb(0, 0, C0);
                case pColor.LMagenta:
                    return Color.FromArgb(FF, C0, FF);
                case pColor.Magenta:
                    return Color.FromArgb(FF, 0, FF);
                case pColor.DMagenta:
                    return Color.FromArgb(C0, 0, C0);
                case pColor.White:
                    return Color.FromArgb(FF, FF, FF);
                case pColor.Black:
                    return Color.FromArgb(0, 0, 0);
                default:
                    return Color.FromArgb(FF, FF, FF);
            }
        }

        Color ColorByIndexEx(int e, int dark = 0, int middle = 192, int light = 255)
        {
            switch (e)
            {
                case pColor.LRed:
                    return Color.FromArgb(light, middle, middle);
                case pColor.Red:
                    return Color.FromArgb(light, dark, dark);
                case pColor.DRed:
                    return Color.FromArgb(middle, dark, dark);
                case pColor.LYellow:
                    return Color.FromArgb(light, light, middle);
                case pColor.Yellow:
                    return Color.FromArgb(light, light, dark);
                case pColor.DYellow:
                    return Color.FromArgb(middle, middle, dark);
                case pColor.LGreen:
                    return Color.FromArgb(middle, light, middle);
                case pColor.Green:
                    return Color.FromArgb(dark, light, dark);
                case pColor.DGreen:
                    return Color.FromArgb(dark, middle, dark);
                case pColor.LCyan:
                    return Color.FromArgb(middle, light, light);
                case pColor.Cyan:
                    return Color.FromArgb(dark, light, light);
                case pColor.DCyan:
                    return Color.FromArgb(dark, middle, middle);
                case pColor.LBlue:
                    return Color.FromArgb(middle, middle, light);
                case pColor.Blue:
                    return Color.FromArgb(dark, dark, light);
                case pColor.DBlue:
                    return Color.FromArgb(dark, dark, middle);
                case pColor.LMagenta:
                    return Color.FromArgb(light, middle, light);
                case pColor.Magenta:
                    return Color.FromArgb(light, dark, light);
                case pColor.DMagenta:
                    return Color.FromArgb(middle, dark, middle);
                case pColor.White:
                    return Color.FromArgb(light, light, light);
                case pColor.Black:
                    return Color.FromArgb(dark, dark, dark);
                default:
                    return Color.FromArgb(light, light, light);
            }
        }

        int IndexByColor(Color e)
        {
            for (int i = 0; i < 20; i++)
            {
                if (e.Equals(ColorByIndex(i))) return i;
            }
            return pColor.White;
        }

        void ChangeColor(int cX,int cY,int e)
        {
            codel[cX][cY] = e;
            dgv_field[cX, cY].Style.BackColor = ColorByIndex(e);
        }

        void ChangeBP(int cX, int cY, bool e)
        {
            bp[cX][cY] = e;
            dgv_field.Refresh();
        }

        void ChangeCurrentColor(int e)
        {
            if (e < 0 || e > 19) return;
            currentColor = e;
            dgv_palette[2, 6].Style.BackColor = ColorByIndex(e);
            dgv_palette[2, 6].Style.SelectionBackColor = ColorByIndex(e);
        }

        void ChangeStandardColor(int e)
        {
            if (e < 0 || e > 17) return;
            standardColor = e;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    dgv_palette[(i + e % 3) % 3, (j + e / 3) % 6].Value = commandsName[i + j * 3];
                }
            }
        }

        void SelectColorBlock(int cX, int cY)
        {
            dgv_field.ClearSelection();
            //TrySelectColorBlock(cX, cY, codel[cX][cY]);
            List<Point> e = new List<Point> { new Point(cX, cY) };
            while (e.Count > 0)
            {
                int eX = e[0].X, eY = e[0].Y;
                if ((eX > -1 && eX < sX && eY > -1 && eY < sY) && (!dgv_field[eX, eY].Selected && codel[eX][eY] == codel[cX][cY]))
                {
                    dgv_field[eX, eY].Selected = true;
                    e.Add(new Point(eX - 1, eY));
                    e.Add(new Point(eX + 1, eY));
                    e.Add(new Point(eX, eY - 1));
                    e.Add(new Point(eX, eY + 1));
                }
                e.RemoveAt(0);
            }
            dgv_field.CurrentCell = dgv_field[cX, cY];
        }

        void TrySelectColorBlock(int cX, int cY, int e)
        {
            if (cX < 0 || cX > sX - 1 || cY < 0 || cY > sY - 1) return;
            if (dgv_field[cX, cY].Selected || codel[cX][cY] != e) return;
            dgv_field[cX, cY].Selected = true;
            TrySelectColorBlock(cX - 1, cY, e);
            TrySelectColorBlock(cX + 1, cY, e);
            TrySelectColorBlock(cX, cY - 1, e);
            TrySelectColorBlock(cX, cY + 1, e);
        }

        void RotateColor(int e)
        {
            int curX = dgv_field.CurrentCellAddress.X, curY = dgv_field.CurrentCellAddress.Y;
            if (codel[curX][curY] == pColor.Black || codel[curX][curY] == pColor.White) return;
            int dX = (e % 3 - codel[curX][curY] % 3 + 3) % 3, dY = (e / 3 - codel[curX][curY] / 3 + 6) % 6;
            foreach (DataGridViewCell item in dgv_field.SelectedCells)
            {
                int oldColor = codel[item.ColumnIndex][item.RowIndex];
                if (oldColor == pColor.White || oldColor == pColor.Black) continue;
                ChangeColor(item.ColumnIndex, item.RowIndex, (oldColor % 3 + dX) % 3 + (oldColor / 3 + dY) % 6 * 3);
            }
            AddHistory();
        }

        bool CopyRect()
        {
            int l, r, t, b, cnt = 0;
            l = r = dgv_field.CurrentCellAddress.X;
            t = b = dgv_field.CurrentCellAddress.Y;
            foreach (DataGridViewCell item in dgv_field.SelectedCells)
            {
                if (item.ColumnIndex < l) l = item.ColumnIndex;
                else if (item.ColumnIndex > r) r = item.ColumnIndex;
                if (item.RowIndex < t) t = item.RowIndex;
                else if (item.RowIndex > b) b = item.RowIndex;
                ++cnt;
            }
            if ((r - l + 1) * (b - t + 1) != cnt)
            {
                MessageBox.Show("矩形選択をして下さい。");
                return false;
            }
            buffer.Clear();
            for (int i = 0; i < r - l + 1; i++)
            {
                buffer.Add(new List<int>());
                for (int j = 0; j < b - t + 1; j++)
                {
                    buffer[i].Add(codel[l + i][t + j]);
                }
            }
            return true;
        }

        void CutRect()
        {
            if (!CopyRect()) return;
            foreach (DataGridViewCell item in dgv_field.SelectedCells)
            {
                ChangeColor(item.ColumnIndex, item.RowIndex, pColor.White);
            }
            AddHistory();
        }

        void PasteRect()
        {
            if (buffer.Count == 0) return;
            int l, t;
            l = dgv_field.CurrentCellAddress.X;
            t = dgv_field.CurrentCellAddress.Y;
            foreach (DataGridViewCell item in dgv_field.SelectedCells)
            {
                if (item.ColumnIndex < l) l = item.ColumnIndex;
                if (item.RowIndex < t) t = item.RowIndex;
            }
            int icnt = Math.Min(sX - l, buffer.Count), jcnt = Math.Min(sY - t, buffer[0].Count);
            for (int i = 0; i < icnt; i++)
            {
                for (int j = 0; j < jcnt; j++)
                {
                    ChangeColor(l + i, t + j, buffer[i][j]);
                }
            }
            AddHistory();
        }

        void Translate(int dX, int dY)
        {
            List<List<int>> temp = new List<List<int>>();
            for (int i = 0; i < sX; i++)
            {
                temp.Add(new List<int>());
                for (int j = 0; j < sY; j++)
                {
                    if (i < dX || i > sX + dX - 1 || j < dY || j > sY + dY - 1)
                    {
                        temp[i].Add(pColor.White);
                    }else
                    {
                        temp[i].Add(codel[i - dX][j - dY]);
                    }
                }
            }
            for (int i = 0; i < sX; i++)
            {
                for (int j = 0; j < sY; j++)
                {
                    ChangeColor(i, j, temp[i][j]);
                }
            }
            AddHistory();
        }

        #endregion

        #region File

        void CreateNew()
        {
            if (hisIndex > 0 && saveRequired)
            {
                DialogResult result = MessageBox.Show(fileName + "への変更内容を保存しますか？", "Pidet", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    SaveFile();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            int newSX = NumericInputBox("キャンバスの幅を指定して下さい。", "Pidet", 10, 1, 100000);
            if (newSX == 0) return;
            int newSY = NumericInputBox("キャンバスの高さを指定して下さい。", "Pidet", 10, 1, 100000);
            if (newSY == 0) return;
            if (editMode == 2) EndDebug();
            sX = newSX;
            sY = newSY;
            fileCSize = 10;
            fileName = "NoName";
            //this.Text = fileName + " - Pidet";
            filePath = "";
            ResetCodel();
            ResetBP();
            RefreshField();
            ResetHistory();
            SetSaveRequired(false);
        }

        void OpenFile(string openFilePath = "")
        {
            if (hisIndex > 0 && saveRequired)
            {
                DialogResult result = MessageBox.Show(fileName + "への変更内容を保存しますか？", "Pidet", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    SaveFile();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            if (openFilePath == "")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = FF_FILTER;
                if (ofd.ShowDialog() != DialogResult.OK) return;
                openFilePath = ofd.FileName;
            }
            int openCSize = NumericInputBox("コーデルサイズを指定して下さい。", "Pidet", 10, 1, 10000);
            if (openCSize < 1) return;
            if (editMode == 2) EndDebug();
            FileStream fs = null;
            Bitmap bmp = null;
            try
            {
                fs = new FileStream(openFilePath, FileMode.Open, FileAccess.Read);
                bmp = (Bitmap)Bitmap.FromStream(fs);
            }
            catch (Exception)
            {
                MessageBox.Show("ファイルの読み込みに失敗しました。");
                return;
            }
            finally
            {
                fs.Close();
            }
            int oX = bmp.Width / openCSize, oY = bmp.Height / openCSize;
            if (oX == 0 || oY == 0 || bmp.Width % openCSize != 0 || bmp.Height % openCSize != 0)
            {
                MessageBox.Show("画像サイズが不適切です。");
                bmp.Dispose();
                return;
            }
            fileCSize = openCSize;
            fileName = Path.GetFileName(openFilePath);
            //this.Text = fileName + " - Pidet";
            filePath = openFilePath;
            sX = oX;
            sY = oY;
            codel.Clear();
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            byte[] buf = new Byte[bmp.Width * bmp.Height * 4];
            Marshal.Copy(bmpData.Scan0, buf, 0, buf.Length);
            int stride = bmpData.Stride;
            for (int i = 0; i < sX; i++)
            {
                codel.Add(new List<int>());
                for (int j = 0; j < sY; j++)
                {
                    //codel[i].Add(IndexByColor(bmp.GetPixel(i * openCSize, j * openCSize)));
                    int pos = (i * 4 + j * stride) * openCSize;
                    codel[i].Add(IndexByColor(Color.FromArgb(buf[pos + 2], buf[pos + 1], buf[pos])));
                }
            }
            Marshal.Copy(buf, 0, bmpData.Scan0, buf.Length);
            bmp.UnlockBits(bmpData);
            bmp.Dispose();
            //sw.Stop();
            //MessageBox.Show(sw.ElapsedMilliseconds.ToString());
            ResetBP();
            RefreshField();
            ResetHistory();
            SetSaveRequired(false);
        }

        void SaveFile()
        {
            if (filePath == "")
            {
                SaveFileAs();
                return;
            }
            Bitmap bmp = new Bitmap(sX * fileCSize, sY * fileCSize);
            Graphics g = Graphics.FromImage(bmp);
            SolidBrush[] b=new SolidBrush[20];
            for (int i = 0; i < 20; i++)
			{
                b[i] = new SolidBrush(ColorByIndex(i));
			}
            for (int i = 0; i < sX; i++)
            {
                for (int j = 0; j < sY; j++)
                {
                    g.FillRectangle(b[codel[i][j]], i * fileCSize, j * fileCSize, fileCSize, fileCSize);
                }
            }
            for (int i = 0; i < 20; i++)
            {
                b[i].Dispose();
            }
            g.Dispose();
            try
            {
                bmp.Save(filePath,FormatByName(filePath));
                SetSaveRequired(false);
            }
            catch (Exception)
            {
                MessageBox.Show("保存に失敗しました。");
            }
        }

        void SaveFileAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = fileName;
            sfd.Filter = FF_FILTER;
            if (sfd.ShowDialog() != DialogResult.OK) return;
            int saveCSize = NumericInputBox("コーデルサイズを指定して下さい。", "Pidet", fileCSize, 1, 10000);
            if (saveCSize == 0) return;
            fileCSize = saveCSize;
            fileName = Path.GetFileName(sfd.FileName);
            //this.Text = fileName + " - Pidet";
            filePath = sfd.FileName;
            Bitmap bmp = new Bitmap(sX * fileCSize, sY * fileCSize);
            Graphics g = Graphics.FromImage(bmp);
            SolidBrush[] b = new SolidBrush[20];
            for (int i = 0; i < 20; i++)
            {
                b[i] = new SolidBrush(ColorByIndex(i));
            }
            for (int i = 0; i < sX; i++)
            {
                for (int j = 0; j < sY; j++)
                {
                    g.FillRectangle(b[codel[i][j]], i * fileCSize, j * fileCSize, fileCSize, fileCSize);
                }
            }
            for (int i = 0; i < 20; i++)
            {
                b[i].Dispose();
            }
            g.Dispose();
            try
            {
                bmp.Save(filePath, FormatByName(filePath));
                SetSaveRequired(false);
            }
            catch (Exception)
            {
                MessageBox.Show("保存に失敗しました。");
            }
        }

        void SaveFileAsEx()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = fileName;
            sfd.Filter = "Image|*.bmp;*.gif;*.png;*.jpg|Bitmap|*.bmp|GIF|*.gif|JPEG|*.jpg|PNG|*.png";
            sfd.Title = "Piet - RGB SelectMode";
            if (sfd.ShowDialog() != DialogResult.OK) return;
            int saveCSize = NumericInputBox("コーデルサイズを指定して下さい。", "Pidet", fileCSize, 1, 10000);
            if (saveCSize == 0) return;
            fileCSize = saveCSize;
            fileName = Path.GetFileName(sfd.FileName);
            //this.Text = fileName + " - Pidet";
            filePath = sfd.FileName;
            Bitmap bmp = new Bitmap(sX * fileCSize, sY * fileCSize);
            Graphics g = Graphics.FromImage(bmp);
            SolidBrush[] b = new SolidBrush[20];
            for (int i = 0; i < 20; i++)
            {
                b[i] = new SolidBrush(ColorByIndexEx(i,0,127,255));
            }
            for (int i = 0; i < sX; i++)
            {
                for (int j = 0; j < sY; j++)
                {
                    g.FillRectangle(b[codel[i][j]], i * fileCSize, j * fileCSize, fileCSize, fileCSize);
                }
            }
            for (int i = 0; i < 20; i++)
            {
                b[i].Dispose();
            }
            g.Dispose();
            try
            {
                bmp.Save(filePath);
                SetSaveRequired(false);
            }
            catch (Exception)
            {
                MessageBox.Show("保存に失敗しました。");
            }
        }

        ImageFormat FormatByName(string fileName)
        {
            ImageFormat ret = ImageFormat.Bmp;
            string ext = Path.GetExtension(fileName).ToLower();
            switch (ext)
            {
                case ".png":
                    ret = ImageFormat.Png;
                    break;
                default:
                    break;
            }
            return ret;
        }

        #endregion

        public main()
        {
            InitializeComponent();

            typeof(DataGridView).GetProperty
                ("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(dgv_field, true, null);
            typeof(DataGridView).GetProperty
                ("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(dgv_palette, true, null);
            this.dgv_field.MouseWheel+=dgv_field_MouseWheel;

            this.Text = fileName + " - Pidet";

            for (int i = 0; i < 3; i++)
            {
                dgv_palette.Columns.Add("", "");
                dgv_palette.Columns[i].Width = 50;
            }
            for (int i = 0; i < 7; i++)
            {
                dgv_palette.Rows.Add();
                dgv_palette.Rows[i].Height = 50;
            }
            dgv_palette.Width = 51 * 3;
            dgv_palette.Height = 51 * 7 - 4;
            for (int i = 0; i < 20; i++)
            {
                dgv_palette[i % 3, i / 3].Style.BackColor = ColorByIndex(i);
                dgv_palette[i % 3, i / 3].Style.SelectionBackColor = ColorByIndex(i);
                int e = (i % 3 + 2) * 60;
                dgv_palette[i % 3, i / 3].Style.ForeColor = Color.FromArgb(e, e, e);
                dgv_palette[i % 3, i / 3].Style.SelectionForeColor = Color.FromArgb(e, e, e);
            }
            ChangeCurrentColor(0);
            ChangeStandardColor(0);

            ResetCodel();
            ResetBP();
            RefreshField();
        }

        private void main_Load(object sender, EventArgs e)
        {
            ChangeEditMode(0);
            AddHistory();
            tm_status.Enabled = true;
            dgv_field.Select();
            string[] cmds = System.Environment.GetCommandLineArgs();
            if (cmds.Length > 1) OpenFile(cmds[1]);
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hisIndex > 0 && saveRequired)
            {
                DialogResult result = MessageBox.Show(fileName + "への変更内容を保存しますか？", "Pidet", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    SaveFile();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void dgv_field_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (editMode == 2)
            {
                if (e.ColumnIndex == ccX && e.RowIndex == ccY)
                {
                    e.Paint(e.CellBounds, e.PaintParts & ~DataGridViewPaintParts.Focus & ~DataGridViewPaintParts.SelectionBackground);
                    ControlPaint.DrawGrid(e.Graphics, e.CellBounds, new Size(3, 3), e.CellStyle.BackColor);
                }
                else if (e.ColumnIndex == ncX && e.RowIndex == ncY)
                {
                    e.Paint(e.CellBounds, e.PaintParts & ~DataGridViewPaintParts.Focus & ~DataGridViewPaintParts.SelectionBackground);
                    ControlPaint.DrawGrid(e.Graphics, e.CellBounds, new Size(4, 4), e.CellStyle.BackColor);
                }
                else
                {
                    e.Paint(e.CellBounds, e.PaintParts & ~DataGridViewPaintParts.Focus & ~DataGridViewPaintParts.SelectionBackground);
                }
            }
            else
            {
                if (((DataGridView)sender).CurrentCellAddress.X == e.ColumnIndex && ((DataGridView)sender).CurrentCellAddress.Y == e.RowIndex)
                {
                    e.Paint(e.CellBounds, e.PaintParts & ~DataGridViewPaintParts.Focus & ~DataGridViewPaintParts.SelectionBackground);
                    ControlPaint.DrawGrid(e.Graphics, e.CellBounds, new Size(3, 3), e.CellStyle.BackColor);
                }
                else if (dgv_field[e.ColumnIndex, e.RowIndex].Selected)
                {
                    e.Paint(e.CellBounds, e.PaintParts & ~DataGridViewPaintParts.Focus & ~DataGridViewPaintParts.SelectionBackground);
                    //ControlPaint.DrawFocusRectangle(e.Graphics, e.CellBounds);
                    ControlPaint.DrawGrid(e.Graphics, e.CellBounds, new Size(4, 4), e.CellStyle.BackColor);
                }
                else
                {
                    e.Paint(e.CellBounds, e.PaintParts & ~DataGridViewPaintParts.Focus & ~DataGridViewPaintParts.SelectionBackground);
                }
            }
            if (bp[e.ColumnIndex][e.RowIndex])
            {
                Point[] points = 
                    { new Point(e.CellBounds.X, e.CellBounds.Y), 
                        new Point(e.CellBounds.X+ cSize / 2, e.CellBounds.Y), new Point(e.CellBounds.X,e.CellBounds.Y+ cSize / 2) };
                e.Graphics.FillPolygon(Brushes.Red, points);
                e.Graphics.DrawLine(Pens.White, e.CellBounds.X + cSize / 2, e.CellBounds.Y, e.CellBounds.X, e.CellBounds.Y + cSize / 2);
                e.Graphics.DrawLine(Pens.White, e.CellBounds.X + cSize / 3, e.CellBounds.Y, e.CellBounds.X, e.CellBounds.Y + cSize / 3);
            }
            e.Handled = true;
        }

        private void dgv_field_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) ChangeCurrentColor(codel[e.ColumnIndex][e.RowIndex]);
        }

        private void main_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.D)
            //    MessageBox.Show(dgv_field[0, 0].Style.BackColor.A.ToString());
            if (e.KeyData == (Keys.Control | Keys.N)) CreateNew();
            if (e.KeyData == (Keys.Control | Keys.O)) OpenFile();
            if (e.KeyData == (Keys.Control | Keys.S)) SaveFile();
            if (e.KeyData == (Keys.Control | Keys.Shift | Keys.S)) SaveFileAs();
            //if (e.KeyData == (Keys.Control | Keys.Alt | Keys.Shift | Keys.S)) SaveFileAsEx();

            if (editMode == 2)
            {
                if (e.KeyData == Keys.Escape || (e.KeyData == (Keys.Shift | Keys.F5))) ResetDebug();
            }
            if (e.KeyData == Keys.F5) { StartDebug(); e.Handled = true; }
            if (e.KeyData == Keys.F10) { StartDebug(false, true); e.Handled = true; }
            if (e.KeyData == Keys.F11) { StartDebug(true); e.Handled = true; }

            if (editMode != 2)
            {
                if (e.KeyData == (Keys.Control | Keys.K)) ChangeCurrentColor(codel[dgv_field.CurrentCellAddress.X][dgv_field.CurrentCellAddress.Y]);
                if (e.KeyData == (Keys.Control | Keys.R)) ChangeSXSY();
                if (e.KeyData == (Keys.Control | Keys.Alt | Keys.Left)) { ChangeSX(sX - 1); AddHistory(); e.Handled = true; }
                if (e.KeyData == (Keys.Control | Keys.Alt | Keys.Right)) { ChangeSX(sX + 1); AddHistory(); e.Handled = true; }
                if (e.KeyData == (Keys.Control | Keys.Alt | Keys.Up)) { ChangeSY(sY - 1); AddHistory(); e.Handled = true; }
                if (e.KeyData == (Keys.Control | Keys.Alt | Keys.Down)) { ChangeSY(sY + 1); AddHistory(); e.Handled = true; }
                if (e.KeyData == (Keys.Shift | Keys.Alt | Keys.Left)) { Translate(-1, 0); e.Handled = true; }
                if (e.KeyData == (Keys.Shift | Keys.Alt | Keys.Right)) { Translate(1, 0); e.Handled = true; }
                if (e.KeyData == (Keys.Shift | Keys.Alt | Keys.Up)) { Translate(0, -1); e.Handled = true; }
                if (e.KeyData == (Keys.Shift | Keys.Alt | Keys.Down)) { Translate(0, 1); e.Handled = true; }
                if (e.KeyData == (Keys.Control | Keys.Enter) || e.KeyData == (Keys.Control | Keys.Space))
                { ChangeCurrentColor(codel[dgv_field.CurrentCellAddress.X][dgv_field.CurrentCellAddress.Y]); e.Handled = true; }
            }

            if (e.KeyData == (Keys.Control | Keys.Oemplus)) ChangeCSize(cSize + 1);
            if (e.KeyData == (Keys.Control | Keys.OemMinus)) ChangeCSize(cSize - 1);
            if (e.KeyData == (Keys.Control | Keys.Left)) { ChangeCurrentColor((currentColor + 2) % 3 + currentColor / 3 * 3); e.Handled = true; }
            if (e.KeyData == (Keys.Control | Keys.Right)) { ChangeCurrentColor((currentColor + 1) % 3 + currentColor / 3 * 3); e.Handled = true; }
            if (e.KeyData == (Keys.Control | Keys.Up)) { ChangeCurrentColor(currentColor % 3 + (currentColor / 3 + 6) % 7 * 3); e.Handled = true; }
            if (e.KeyData == (Keys.Control | Keys.Down)) { ChangeCurrentColor(currentColor % 3 + (currentColor / 3 + 1) % 7 * 3); e.Handled = true; }
            if (e.KeyData == (Keys.Alt | Keys.Left)) { ChangeStandardColor((standardColor + 2) % 3 + standardColor / 3 * 3); e.Handled = true; }
            if (e.KeyData == (Keys.Alt | Keys.Right)) { ChangeStandardColor((standardColor + 1) % 3 + standardColor / 3 * 3); e.Handled = true; }
            if (e.KeyData == (Keys.Alt | Keys.Up)) { ChangeStandardColor(standardColor % 3 + (standardColor / 3 + 5) % 6 * 3); e.Handled = true; }
            if (e.KeyData == (Keys.Alt | Keys.Down)) { ChangeStandardColor(standardColor % 3 + (standardColor / 3 + 1) % 6 * 3); e.Handled = true; }
        }

        private void dgv_field_KeyDown(object sender, KeyEventArgs e)
        {
            if (editMode != 2)
            {
                if (e.KeyData == Keys.C || e.KeyData == Keys.T) { ChangeEditMode(-2); e.Handled = true; }
                if (e.KeyData == (Keys.Control | Keys.A)) dgv_field.SelectAll();
                
                if (e.KeyData == (Keys.Control | Keys.B))
                {
                    Boolean bpChange = !bp[dgv_field.CurrentCellAddress.X][dgv_field.CurrentCellAddress.Y];
                    foreach (DataGridViewCell item in dgv_field.SelectedCells)
                    {
                        ChangeBP(item.ColumnIndex, item.RowIndex, bpChange);
                    }
                }
                if (e.KeyData == (Keys.Control | Keys.Shift | Keys.B))
                {
                    foreach (DataGridViewCell item in dgv_field.SelectedCells)
                    {
                        ChangeBP(item.ColumnIndex, item.RowIndex, false);
                    }
                }
                if (e.KeyData == (Keys.Control | Keys.Z)) if (!tb_input.Focused) UndoHistory();
                if (e.KeyData == (Keys.Control | Keys.Y)) if (!tb_input.Focused) RedoHistory();
                if (e.KeyData == (Keys.Control | Keys.C)) CopyRect();
                if (e.KeyData == (Keys.Control | Keys.X)) CutRect();
                if (e.KeyData == (Keys.Control | Keys.V)) PasteRect();
                if (e.KeyData == Keys.Enter || e.KeyData == Keys.Space)
                {
                    e.Handled = true;
                    foreach (DataGridViewCell item in dgv_field.SelectedCells)
                    {
                        ChangeColor(item.ColumnIndex, item.RowIndex, currentColor);
                    }
                    AddHistory();
                }
                if (e.KeyData == Keys.Delete)
                {
                    e.Handled = true;
                    foreach (DataGridViewCell item in dgv_field.SelectedCells)
                    {
                        ChangeColor(item.ColumnIndex, item.RowIndex, pColor.White);
                    }
                    AddHistory();
                }
            }
            if (editMode == 2) {
                //if (e.KeyData == (Keys.Control | Keys.B))
                //{
                //    Boolean bpChange = !bp[dgv_field.CurrentCellAddress.X][dgv_field.CurrentCellAddress.Y];
                //    foreach (DataGridViewCell item in dgv_field.SelectedCells)
                //    {
                //        ChangeBP(item.ColumnIndex, item.RowIndex, bpChange);
                //    }
                //}
                //if (e.KeyData == (Keys.Control | Keys.Shift | Keys.B))
                //{
                //    foreach (DataGridViewCell item in dgv_field.SelectedCells)
                //    {
                //        ChangeBP(item.ColumnIndex, item.RowIndex, false);
                //    }
                //}
                e.Handled = true;
            }
        }

        private void dgv_field_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (editMode == 1) SelectColorBlock(e.ColumnIndex, e.RowIndex);
        }

        private void dgv_field_DragDrop(object sender, DragEventArgs e)
        {
            OpenFile(((string[])e.Data.GetData(DataFormats.FileDrop, false))[0]);
        }

        private void dgv_field_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string ext = Path.GetExtension(((string[])e.Data.GetData(DataFormats.FileDrop, false))[0]).ToLower();
                if(ext == ".png" || ext == ".bmp")
                    e.Effect = DragDropEffects.Copy;
            }
        }

        private void dgv_field_MouseWheel(object sender, MouseEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                HandledMouseEventArgs wEventArgs = e as HandledMouseEventArgs;
                wEventArgs.Handled = true;
                ChangeCSize(cSize - e.Delta / 60);
            }
        }

        #region Palette

        private void dgv_palette_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Control.ModifierKeys == (Keys.Modifiers & Keys.None))
            {
                if(e.Button==MouseButtons.Left)if (e.ColumnIndex != 2 || e.RowIndex != 6) 
                    ChangeCurrentColor(e.ColumnIndex + e.RowIndex * 3);
                if (e.Button == MouseButtons.Right) if (e.RowIndex != 6)
                    ChangeStandardColor(e.ColumnIndex + e.RowIndex * 3);
            }
            else if (Control.ModifierKeys == (Keys.Modifiers & Keys.Control))
            {
                if (e.Button == MouseButtons.Left) RotateColor(e.ColumnIndex + e.RowIndex * 3);
            }
        }

        private void dgv_palette_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (editMode != 2)
            {
                foreach (DataGridViewCell item in dgv_field.SelectedCells)
                {
                    ChangeColor(item.ColumnIndex, item.RowIndex, currentColor);
                }
                AddHistory();
            }
        }

        private void dgv_palette_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.CellBounds, e.PaintParts & ~DataGridViewPaintParts.Focus & ~DataGridViewPaintParts.SelectionBackground);
            if (e.ColumnIndex == currentColor % 3 && e.RowIndex == currentColor / 3)
            {
                ControlPaint.DrawBorder3D(e.Graphics, e.CellBounds, Border3DStyle.Etched);
            }
            if (e.ColumnIndex == 2 && e.RowIndex == 6)  
            {
                ControlPaint.DrawBorder3D(e.Graphics, e.CellBounds,Border3DStyle.Bump);
            }
            e.Handled = true;
        }

        #endregion

        #region Buttons

        private void btn_debug_Click(object sender, EventArgs e)
        {
            StartDebug();
        }

        private void btn_jump_Click(object sender, EventArgs e)
        {
            StartDebug(false, true);
        }

        private void btn_step_Click(object sender, EventArgs e)
        {
            StartDebug(true);
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            ResetDebug();
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            ChangeEditMode(-2);
        }

        #endregion

        #region Pen

        private void dgv_field_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (editMode == 0)
            {
                if (e.Button == MouseButtons.Left && penWriting)
                {
                    ChangeColor(e.ColumnIndex, e.RowIndex, currentColor);
                    history[history.Count - 1][e.ColumnIndex][e.RowIndex] = currentColor;
                    dgv_field[e.ColumnIndex, e.RowIndex].Selected = true;
                }
                else if (e.Button == MouseButtons.Right)
                {

                }
            }
        }

        private void dgv_field_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (editMode == 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                penWriting = true;
                ChangeColor(e.ColumnIndex, e.RowIndex, currentColor);
                AddHistory();
                tm_pen.Enabled = true;
                }
            }
        }

        void StopPen()
        {
            penWriting = false;
            tm_pen.Enabled = false;
        }

        private void tm_pen_Tick(object sender, EventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Left) != MouseButtons.Left)
            {
                StopPen();
            }
        }

        #endregion

        #region tsmi

        private void tsmi_CreateNew_Click(object sender, EventArgs e)
        {
            CreateNew();
        }

        private void tsmi_OpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void tsmi_Cut_Click(object sender, EventArgs e)
        {
            if (editMode != 2) CutRect();
        }

        private void tsmi_Copy_Click(object sender, EventArgs e)
        {
            if (editMode != 2) CopyRect();
        }

        private void tsmi_Paste_Click(object sender, EventArgs e)
        {
            if (editMode != 2) PasteRect();
        }

        private void dgv_field_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.FillWeight = 0.001F;
        }

        private void tsmi_SaveFile_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void tsmi_SaveFileAs_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void tsmi_Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmi_Undo_Click(object sender, EventArgs e)
        {
            if (editMode != 2) UndoHistory();
        }

        private void tsmi_Redo_Click(object sender, EventArgs e)
        {
            if (editMode != 2) RedoHistory();
        }

        private void tsmi_ChangeTool_Click(object sender, EventArgs e)
        {
            if (editMode != 2) ChangeEditMode(-2);
        }

        private void tsmi_ZoomIn_Click(object sender, EventArgs e)
        {
            ChangeCSize(cSize + 1);
        }

        private void tsmi_ZoomOut_Click(object sender, EventArgs e)
        {
            ChangeCSize(cSize - 1);
        }

        private void tsmi_ChangeCanvasSize_Click(object sender, EventArgs e)
        {
            if (editMode != 2) ChangeSXSY();
        }

        private void tsmi_StartDebug_Click(object sender, EventArgs e)
        {
            StartDebug();
        }

        private void tsmi_JumpDebug_Click(object sender, EventArgs e)
        {
            StartDebug(false, true);
        }

        private void tsmi_StepDebug_Click(object sender, EventArgs e)
        {
            StartDebug(true);
        }

        private void tsmi_ResetDebug_Click(object sender, EventArgs e)
        {
            if (editMode == 2) ResetDebug();
        }

        #endregion

        private void tm_status_Tick(object sender, EventArgs e)
        {
            string statusStr = "[status]\r\n";
            statusStr += "W: " + sX.ToString() + " H: " + sY.ToString() + "\r\nD^2: " + (sX * sX + sY * sY).ToString() + "\r\ncS: " + cSize.ToString() + "\r\n\r\n";
            if (editMode == 2)
            {
                statusStr +=
                    "Debugging...\r\nCommand: " + currentCommand +
                    "\r\ndp: " + dpName[dp] + " cc: " + ccName[cc] + "\r\nStep: " + sc.ToString();
            }
            else
            {
                statusStr += "Editing...\r\nTool: " + ((editMode == 0) ? "Pen" : "Selector");
            }
            lbl_status.Text = statusStr;
        }

        #region SelectAll

        private void tb_input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.A)) tb_input.SelectAll();
        }

        private void tb_output_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.A)) tb_output.SelectAll();
        }

        private void tb_stackbefore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.A)) tb_stackbefore.SelectAll();
        }

        private void tb_stack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.A)) tb_stack.SelectAll();
        }

        #endregion

        private void dgv_field_Enter(object sender, EventArgs e)
        {
            sc_field.Panel1.BackColor = Color.Pink;
        }

        private void dgv_field_Leave(object sender, EventArgs e)
        {
            sc_field.Panel1.BackColor = SystemColors.Control;
        }

        private void dgv_field_MouseEnter(object sender, EventArgs e)
        {
            dgv_field.Focus();
        }
    }
}
