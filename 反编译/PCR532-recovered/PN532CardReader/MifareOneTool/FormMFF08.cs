using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MifareOneTool.Properties;

namespace MifareOneTool;

public class FormMFF08 : Form
{
	[CompilerGenerated]
	private sealed class a
	{
		public BackgroundWorker a;

		internal void b(object A_0, DataReceivedEventArgs A_1)
		{
			short num = 1;
			if (num != 0)
			{
			}
			num = -6388;
			short num2 = num;
			num = -6388;
			switch (num2 == num)
			{
			}
			num = 0;
			if (num != 0)
			{
			}
			num = 0;
			_ = num;
			a.ReportProgress(0, A_1.Data);
		}

		internal void c(object A_0, DataReceivedEventArgs A_1)
		{
			short num = 1;
			if (num != 0)
			{
			}
			num = -1339;
			short num2 = num;
			num = -1339;
			switch (num2 == num)
			{
			}
			num = 0;
			if (num != 0)
			{
			}
			num = 0;
			_ = num;
			a.ReportProgress(0, A_1.Data);
		}
	}

	private bool m_a;

	private Process m_b;

	private IContainer m_c;

	private GroupBox m_d;

	private Label m_e;

	private GroupBox f;

	private Button g;

	private TextBox h;

	private Label i;

	private Button j;

	private Button k;

	private GroupBox l;

	private RichTextBox m;

	private Button n;

	public FormMFF08()
	{
		a();
	}

	private void e(object A_0, EventArgs A_1)
	{
		int num = default(int);
		OpenFileDialog openFileDialog = default(OpenFileDialog);
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 2:
				{
					short num2 = 1;
					if (num2 != 0)
					{
					}
					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						num2 = 0;
						num = num2;
						continue;
					}
					goto case 1;
				}
				case 0:
				{
					h.Text = openFileDialog.FileName;
					short num2 = 1;
					num = num2;
					continue;
				}
				case 1:
					while (true)
					{
						short num2 = 0;
						_ = num2;
						num2 = -16206;
						short num3 = num2;
						num2 = -16206;
						switch (num3 == num2)
						{
						case false:
						case true:
							continue;
						}
						num2 = 0;
						if (num2 == 0)
						{
						}
						return;
					}
				}
				break;
			}
			goto case 0;
		case 0:
		{
			openFileDialog = new OpenFileDialog();
			openFileDialog.CheckFileExists = true;
			openFileDialog.Filter = Resources.MFD文件_mfd_DUMP文件_dump;
			openFileDialog.Title = Resources.请选择最后一次写卡导致0块损坏的卡数据文件;
			openFileDialog.Multiselect = false;
			short num2 = 2;
			num = num2;
			goto default;
		}
		}
	}

	private void d(object A_0, EventArgs A_1)
	{
		short num = 16550;
		short num2 = num;
		num = 16550;
		switch (num2 == num)
		{
		}
		num = 1;
		if (num != 0)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
		h.Text = "";
	}

	private void a(string A_0)
	{
		short num = 20962;
		short num2 = num;
		num = 20962;
		switch (num2 == num)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		num = 1;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
		m.AppendText(A_0 + "\n");
		m.ScrollToCaret();
	}

	private void a(object A_0, ProgressChangedEventArgs A_1)
	{
		short num = 6;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 6:
				switch (0)
				{
				default:
					continue;
				case 0:
					break;
				}
				goto default;
			default:
				if (A_1.ProgressPercentage == 100)
				{
					num = 5;
					num2 = num;
				}
				else
				{
					num = 3;
					num2 = num;
				}
				continue;
			case 5:
			{
				num = 32330;
				short num3 = num;
				num = 32330;
				switch (num3 == num)
				{
				default:
					num = 0;
					if (num != 0)
					{
					}
					num = 1;
					if (num != 0)
					{
					}
					a((string)A_1.UserState);
					f.Enabled = true;
					num = 0;
					num2 = num;
					continue;
				case false:
				case true:
					break;
				}
				goto IL_011c;
			}
			case 1:
				f.Enabled = false;
				num = 4;
				num2 = num;
				continue;
			case 3:
				if (A_1.ProgressPercentage != 1)
				{
					a((string)A_1.UserState);
					num = 2;
					num2 = num;
					continue;
				}
				goto IL_011c;
			case 2:
				num = 0;
				_ = num;
				break;
			case 0:
			case 4:
				break;
				IL_011c:
				num = 1;
				num2 = num;
				continue;
			}
			break;
		}
		Application.DoEvents();
	}

	private void c(object A_0, EventArgs A_1)
	{
		if (this.m_a)
		{
			while (true)
			{
				short num = 15040;
				short num2 = num;
				num = 15040;
				switch (num2 == num)
				{
				case false:
				case true:
					break;
				default:
					num = 1;
					if (num != 0)
					{
					}
					num = 0;
					if (num != 0)
					{
					}
					num = 0;
					_ = num;
					MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}
		}
		new f().d("nfc-data/tmp/mff08_empty.kmf");
		BackgroundWorker backgroundWorker = new BackgroundWorker();
		backgroundWorker.DoWork += a;
		backgroundWorker.WorkerReportsProgress = true;
		backgroundWorker.ProgressChanged += a;
		backgroundWorker.RunWorkerAsync(new string[4] { "nfc-data/tmp/mff08_empty.kmf", "A", "x", "" });
	}

	private void a(object A_0, DoWorkEventArgs A_1)
	{
		int num = default(int);
		a a = default(a);
		short num2;
		switch (0)
		{
		default:
		{
			string[] array = default(string[]);
			ProcessStartInfo processStartInfo2 = default(ProcessStartInfo);
			while (true)
			{
				switch (num)
				{
				case 6:
					goto IL_00d1;
				case 5:
					return;
				case 0:
					num2 = 4;
					num = num2;
					continue;
				case 4:
					if (array[2] == "")
					{
						num2 = 3;
						num = num2;
						continue;
					}
					goto case 2;
				case 1:
					if (array[3] != "")
					{
						num2 = 0;
						num = num2;
						continue;
					}
					goto case 2;
				case 3:
				{
					ProcessStartInfo processStartInfo = processStartInfo2;
					processStartInfo.Arguments = processStartInfo.Arguments + " \"" + array[3] + "\" f";
					num2 = 2;
					num = num2;
					continue;
				}
				case 2:
					processStartInfo2.CreateNoWindow = true;
					processStartInfo2.UseShellExecute = false;
					processStartInfo2.RedirectStandardOutput = true;
					processStartInfo2.RedirectStandardError = true;
					this.m_a = true;
					a.a = (BackgroundWorker)A_0;
					a.a.ReportProgress(1);
					this.m_b = Process.Start(processStartInfo2);
					this.m_b.OutputDataReceived += a.b;
					this.m_b.ErrorDataReceived += a.c;
					this.m_b.BeginOutputReadLine();
					this.m_b.BeginErrorReadLine();
					this.m_b.WaitForExit();
					this.m_a = false;
					a.a.ReportProgress(100, Resources._运行完毕);
					return;
				}
				break;
				IL_00d1:
				num2 = 0;
				_ = num2;
				if (!this.m_a)
				{
					processStartInfo2 = new ProcessStartInfo("nfc-bin/mff08.exe");
					array = (string[])A_1.Argument;
					processStartInfo2.Arguments = "c " + array[1] + " u \"" + array[0] + "\"";
					num2 = 1;
					num = num2;
					continue;
				}
				goto IL_00ec;
			}
			goto case 0;
		}
		case 0:
			{
				num2 = -22486;
				short num3 = num2;
				num2 = -22486;
				switch (num3 == num2)
				{
				case false:
				case true:
					goto IL_00ec;
				}
				num2 = 1;
				if (num2 != 0)
				{
				}
				num2 = 0;
				if (num2 != 0)
				{
				}
				a = new a();
				num2 = 6;
				num = num2;
				goto default;
			}
			IL_00ec:
			num2 = 5;
			num = num2;
			goto default;
		}
	}

	private void b(object A_0, EventArgs A_1)
	{
		short num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 3:
				switch (0)
				{
				default:
					goto end_IL_001f;
				case 0:
					break;
				}
				goto default;
			default:
				if (this.m_a)
				{
					num = 1;
					num2 = num;
				}
				else
				{
					new f().d("nfc-data/tmp/mff08_empty.kmf");
					num = 0;
					num2 = num;
				}
				break;
			case 1:
				num = 1;
				if (num != 0)
				{
				}
				MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			case 2:
				MessageBox.Show(Resources.您没有给定最后一次写卡导致0块损坏的卡数据文件来作为写卡时的, Resources.错误, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			case 0:
				{
					if (h.Text == "")
					{
						num = 10204;
						short num3 = num;
						num = 10204;
						switch (num3 == num)
						{
						case false:
						case true:
							break;
						default:
							num = 0;
							_ = num;
							num = 0;
							if (num != 0)
							{
							}
							num = 2;
							num2 = num;
							goto end_IL_001f;
						}
						goto case 1;
					}
					BackgroundWorker backgroundWorker = new BackgroundWorker();
					backgroundWorker.DoWork += a;
					backgroundWorker.WorkerReportsProgress = true;
					backgroundWorker.ProgressChanged += a;
					backgroundWorker.RunWorkerAsync(new string[4] { "nfc-data/tmp/mff08_empty.kmf", "C", "", h.Text });
					return;
				}
				end_IL_001f:
				break;
			}
		}
	}

	private void a(object A_0, EventArgs A_1)
	{
		short num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				switch (0)
				{
				default:
					goto end_IL_0020;
				case 0:
					break;
				}
				goto default;
			default:
				num = 1;
				if (num != 0)
				{
				}
				if (!File.Exists("nfc-bin/mff08.exe"))
				{
					num = 0;
					num2 = num;
					break;
				}
				goto case 1;
			case 0:
				MessageBox.Show(Resources.无法找到MFF08程序文件_操作终止, Resources.错误, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				goto IL_008e;
			case 1:
				{
					num = 0;
					_ = num;
					num = -8626;
					short num3 = num;
					num = -8626;
					switch (num3 == num)
					{
					case false:
					case true:
						break;
					default:
						num = 0;
						if (num == 0)
						{
						}
						return;
					}
					goto IL_008e;
				}
				IL_008e:
				num = 1;
				num2 = num;
				break;
				end_IL_0020:
				break;
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		short num = 4;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 4:
				num = 1;
				if (num != 0)
				{
				}
				switch (0)
				{
				default:
					continue;
				case 0:
					break;
				}
				goto default;
			default:
				if (disposing)
				{
					num = 3;
					num2 = num;
					continue;
				}
				break;
			case 0:
				this.m_c.Dispose();
				num = 1;
				num2 = num;
				continue;
			case 3:
				num = 2;
				num2 = num;
				continue;
			case 2:
			{
				num = 9772;
				short num3 = num;
				num = 9772;
				switch (num3 == num)
				{
				case false:
				case true:
					break;
				default:
					goto IL_00fe;
				}
				goto case 3;
			}
			case 1:
				break;
				IL_00fe:
				num = 0;
				_ = num;
				num = 0;
				if (num != 0)
				{
				}
				if (this.m_c != null)
				{
					num = 0;
					num2 = num;
					continue;
				}
				break;
			}
			break;
		}
		base.Dispose(disposing);
	}

	private void a()
	{
		short num = -4009;
		short num2 = num;
		num = -4009;
		switch (num2 == num)
		{
		}
		num = 1;
		if (num != 0)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormMFF08));
		this.m_d = new GroupBox();
		this.m_e = new Label();
		f = new GroupBox();
		n = new Button();
		g = new Button();
		h = new TextBox();
		i = new Label();
		j = new Button();
		k = new Button();
		l = new GroupBox();
		m = new RichTextBox();
		this.m_d.SuspendLayout();
		f.SuspendLayout();
		l.SuspendLayout();
		SuspendLayout();
		this.m_d.Controls.Add(this.m_e);
		componentResourceManager.ApplyResources(this.m_d, "groupBox1");
		this.m_d.Name = "groupBox1";
		this.m_d.TabStop = false;
		componentResourceManager.ApplyResources(this.m_e, "label1");
		this.m_e.ForeColor = Color.Blue;
		this.m_e.Name = "label1";
		f.Controls.Add(n);
		f.Controls.Add(g);
		f.Controls.Add(h);
		f.Controls.Add(i);
		f.Controls.Add(j);
		f.Controls.Add(k);
		componentResourceManager.ApplyResources(f, "groupBox2");
		f.Name = "groupBox2";
		f.TabStop = false;
		componentResourceManager.ApplyResources(n, "buttonClr");
		n.Name = "buttonClr";
		n.UseVisualStyleBackColor = true;
		n.Click += d;
		componentResourceManager.ApplyResources(g, "buttonLoadKey");
		g.Name = "buttonLoadKey";
		g.UseVisualStyleBackColor = true;
		g.Click += e;
		componentResourceManager.ApplyResources(h, "keyfileBox");
		h.Name = "keyfileBox";
		componentResourceManager.ApplyResources(i, "label2");
		i.Name = "label2";
		componentResourceManager.ApplyResources(j, "buttonKeyWrite");
		j.Name = "buttonKeyWrite";
		j.UseVisualStyleBackColor = true;
		j.Click += b;
		componentResourceManager.ApplyResources(k, "buttonWriteEmpty");
		k.Name = "buttonWriteEmpty";
		k.UseVisualStyleBackColor = true;
		k.Click += c;
		l.Controls.Add(m);
		componentResourceManager.ApplyResources(l, "groupBox3");
		l.Name = "groupBox3";
		l.TabStop = false;
		m.BackColor = Color.Black;
		componentResourceManager.ApplyResources(m, "logBox");
		m.ForeColor = Color.Gold;
		m.Name = "logBox";
		m.ReadOnly = true;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(l);
		base.Controls.Add(f);
		base.Controls.Add(this.m_d);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.Name = "FormMFF08";
		base.Load += a;
		this.m_d.ResumeLayout(performLayout: false);
		this.m_d.PerformLayout();
		f.ResumeLayout(performLayout: false);
		f.PerformLayout();
		l.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}
}
