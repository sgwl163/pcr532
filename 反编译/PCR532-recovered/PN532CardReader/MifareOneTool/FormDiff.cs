using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MifareOneTool.Properties;

namespace MifareOneTool;

public class FormDiff : Form
{
	private f m_a = new f();

	private f m_b = new f();

	private string m_c = "";

	private string m_d = "";

	private IContainer m_e;

	private RichTextBox f;

	private Button g;

	private Button h;

	private Button i;

	private TableLayoutPanel j;

	private FlowLayoutPanel k;

	private FlowLayoutPanel l;

	public FormDiff()
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
				short num2;
				switch (num)
				{
				case 2:
					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						goto IL_0081;
					}
					return;
				case 0:
					try
					{
						this.m_a.a(this.m_c);
						g.Text = "A=" + openFileDialog.SafeFileName;
						return;
					}
					catch (IOException ex)
					{
						MessageBox.Show(ex.Message, Resources.打开出错, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						this.m_a = new f();
						return;
					}
				case 1:
					this.m_a = new f();
					num2 = 0;
					num = num2;
					continue;
				case 3:
					{
						num2 = 22174;
						short num3 = num2;
						num2 = 22174;
						switch (num3 == num2)
						{
						case false:
						case true:
							break;
						default:
							num2 = 0;
							if (num2 != 0)
							{
							}
							num2 = 1;
							if (num2 != 0)
							{
							}
							this.m_c = openFileDialog.FileName;
							num2 = 1;
							num = num2;
							continue;
						}
						goto IL_0081;
					}
					IL_0081:
					num2 = 0;
					_ = num2;
					num2 = 3;
					num = num2;
					continue;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			openFileDialog = new OpenFileDialog();
			openFileDialog.CheckFileExists = true;
			openFileDialog.Filter = Resources.MFD文件_mfd_dump;
			openFileDialog.Title = Resources.请选择需要打开的MFD文件_比较A;
			openFileDialog.Multiselect = false;
			short num2 = 2;
			num = num2;
			goto default;
		}
		}
	}

	private void d(object A_0, EventArgs A_1)
	{
		short num = 29211;
		short num2 = num;
		num = 29211;
		switch (num2 == num)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
		num = 1;
		if (num == 0)
		{
		}
	}

	private void a(string A_0)
	{
		short num = 12987;
		short num2 = num;
		num = 12987;
		switch (num2 == num)
		{
		}
		num = 1;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
		num = 0;
		if (num != 0)
		{
		}
		f.AppendText(A_0 + "\n");
		f.ScrollToCaret();
	}

	private void c(object A_0, EventArgs A_1)
	{
		int num2 = default(int);
		OpenFileDialog openFileDialog = default(OpenFileDialog);
		switch (0)
		{
		default:
			while (true)
			{
				short num = 1;
				if (num != 0)
				{
				}
				switch (num2)
				{
				case 2:
					if (openFileDialog.ShowDialog() != DialogResult.OK)
					{
						return;
					}
					goto IL_0093;
				case 0:
					try
					{
						this.m_b.a(this.m_d);
						h.Text = "B=" + openFileDialog.SafeFileName;
						return;
					}
					catch (IOException ex)
					{
						MessageBox.Show(ex.Message, Resources.打开出错, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						this.m_b = new f();
						return;
					}
				case 1:
					num = 0;
					_ = num;
					this.m_b = new f();
					num = 0;
					num2 = num;
					continue;
				case 3:
					{
						num = 15201;
						short num3 = num;
						num = 15201;
						switch (num3 == num)
						{
						case false:
						case true:
							break;
						default:
							num = 0;
							if (num != 0)
							{
							}
							this.m_d = openFileDialog.FileName;
							num = 1;
							num2 = num;
							continue;
						}
						goto IL_0093;
					}
					IL_0093:
					num = 3;
					num2 = num;
					continue;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			openFileDialog = new OpenFileDialog();
			openFileDialog.CheckFileExists = true;
			openFileDialog.Filter = Resources.MFD文件_mfd_dump;
			openFileDialog.Title = Resources.请选择需要打开的MFD文件_比较B;
			openFileDialog.Multiselect = false;
			short num = 2;
			num2 = num;
			goto default;
		}
		}
	}

	private void b(object A_0, EventArgs A_1)
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				switch (0)
				{
				default:
					continue;
				case 0:
					break;
				}
				goto default;
			default:
				if (File.Exists(this.m_c))
				{
					num = 3;
					num2 = num;
					continue;
				}
				break;
			case 3:
				num = 0;
				_ = num;
				num = 0;
				num2 = num;
				continue;
			case 0:
				if (File.Exists(this.m_d))
				{
					num = 2;
					num2 = num;
					continue;
				}
				break;
			case 2:
			{
				num = -16243;
				short num3 = num;
				num = -16243;
				switch (num3 == num)
				{
				case false:
				case true:
					break;
				default:
					num = 0;
					if (num != 0)
					{
					}
					f.Clear();
					f.Text = b();
					return;
				}
				goto case 0;
			}
			}
			break;
		}
		a(Resources.AB文件中一个或两个无效);
	}

	private string b()
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			int num5 = default(int);
			int num3 = default(int);
			StringBuilder stringBuilder = default(StringBuilder);
			switch (0)
			{
			default:
			{
				int num4 = default(int);
				int num6 = default(int);
				string text = default(string);
				while (true)
				{
					switch (num2)
					{
					case 0:
						num4++;
						num = 3;
						num2 = num;
						continue;
					case 2:
					case 17:
						num = 15;
						num2 = num;
						continue;
					case 15:
						if (num6 >= 16)
						{
							num = 1;
							num2 = num;
						}
						else
						{
							num = 8;
							num2 = num;
						}
						continue;
					case 8:
						if (this.m_a.c()[num5].f()[num4][num6] == this.m_b.c()[num5].f()[num4][num6])
						{
							num = 1;
							if (num != 0)
							{
							}
							num = 18;
							num2 = num;
							continue;
						}
						goto IL_0410;
					case 13:
						num5++;
						num = 11;
						num2 = num;
						continue;
					case 14:
						num3++;
						num = 0;
						num2 = num;
						continue;
					case 11:
					case 16:
						num = 10;
						num2 = num;
						continue;
					case 10:
					{
						num = 21302;
						short num7 = num;
						num = 21302;
						switch (num7 == num)
						{
						default:
							num = 0;
							if (num != 0)
							{
							}
							if (num5 >= 16)
							{
								num = 5;
								num2 = num;
								continue;
							}
							stringBuilder.AppendLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
							stringBuilder.AppendLine(Resources.扇区0 + num5);
							num4 = 0;
							num = 7;
							num2 = num;
							continue;
						case false:
						case true:
							break;
						}
						goto IL_0410;
					}
					case 6:
					case 12:
						num6++;
						num = 2;
						num2 = num;
						continue;
					case 18:
						text += "-- ";
						num = 12;
						num2 = num;
						continue;
					case 3:
					case 7:
						num = 4;
						num2 = num;
						continue;
					case 4:
						if (num4 < 4)
						{
							text = "";
							num6 = 0;
							num = 17;
							num2 = num;
						}
						else
						{
							num = 13;
							num2 = num;
						}
						continue;
					case 1:
						stringBuilder.AppendLine("A: " + global::b.d(this.m_a.c()[num5].f()[num4]));
						stringBuilder.AppendLine("B: " + global::b.d(this.m_b.c()[num5].f()[num4]));
						stringBuilder.AppendLine("   " + text);
						num = 9;
						num2 = num;
						continue;
					case 9:
						if (text.Contains("##"))
						{
							num = 14;
							num2 = num;
							continue;
						}
						goto case 0;
					case 5:
						{
							num = 0;
							_ = num;
							return Resources.共找到 + num3 + Resources._个块不同 + stringBuilder.ToString();
						}
						IL_0410:
						text += "## ";
						num = 6;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				stringBuilder = new StringBuilder();
				num3 = 0;
				num5 = 0;
				num = 16;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private void a(object A_0, EventArgs A_1)
	{
		short num = 32063;
		short num2 = num;
		num = 32063;
		switch (num2 == num)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
		num = 1;
		if (num == 0)
		{
		}
	}

	protected override void Dispose(bool disposing)
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
					continue;
				case 0:
					break;
				}
				goto default;
			default:
				num = 0;
				_ = num;
				if (disposing)
				{
					num = 4;
					num2 = num;
					continue;
				}
				break;
			case 3:
				this.m_e.Dispose();
				num = 1;
				num2 = num;
				continue;
			case 1:
			{
				num = -19181;
				short num3 = num;
				num = -19181;
				switch (num3 == num)
				{
				case false:
				case true:
					break;
				default:
					goto IL_00dc;
				}
				goto case 3;
			}
			case 4:
				num = 0;
				num2 = num;
				continue;
			case 0:
				{
					if (this.m_e != null)
					{
						num = 3;
						num2 = num;
						continue;
					}
					break;
				}
				IL_00dc:
				num = 1;
				if (num != 0)
				{
				}
				num = 0;
				if (num == 0)
				{
				}
				break;
			}
			break;
		}
		base.Dispose(disposing);
	}

	private void a()
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = 24204;
		short num2 = num;
		num = 24204;
		switch (num2 == num)
		{
		}
		num = 0;
		_ = num;
		num = 0;
		if (num != 0)
		{
		}
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormDiff));
		f = new RichTextBox();
		g = new Button();
		h = new Button();
		i = new Button();
		j = new TableLayoutPanel();
		k = new FlowLayoutPanel();
		l = new FlowLayoutPanel();
		j.SuspendLayout();
		k.SuspendLayout();
		l.SuspendLayout();
		SuspendLayout();
		f.BackColor = Color.Black;
		componentResourceManager.ApplyResources(f, "richTextBox1");
		f.ForeColor = Color.Orange;
		f.Name = "richTextBox1";
		f.ReadOnly = true;
		f.TextChanged += a;
		componentResourceManager.ApplyResources(g, "button1");
		g.Name = "button1";
		g.UseVisualStyleBackColor = true;
		g.Click += e;
		componentResourceManager.ApplyResources(h, "button2");
		h.Name = "button2";
		h.UseVisualStyleBackColor = true;
		h.Click += c;
		componentResourceManager.ApplyResources(i, "button3");
		i.Name = "button3";
		i.UseVisualStyleBackColor = true;
		i.Click += b;
		componentResourceManager.ApplyResources(j, "tableLayoutPanel1");
		j.Controls.Add(k, 0, 0);
		j.Controls.Add(i, 1, 0);
		j.Name = "tableLayoutPanel1";
		componentResourceManager.ApplyResources(k, "flowLayoutPanel1");
		k.Controls.Add(g);
		k.Controls.Add(h);
		k.Name = "flowLayoutPanel1";
		componentResourceManager.ApplyResources(l, "flowLayoutPanel2");
		l.Controls.Add(j);
		l.Controls.Add(f);
		l.Name = "flowLayoutPanel2";
		base.AcceptButton = i;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(l);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.Name = "FormDiff";
		base.Load += d;
		j.ResumeLayout(performLayout: false);
		j.PerformLayout();
		k.ResumeLayout(performLayout: false);
		l.ResumeLayout(performLayout: false);
		l.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
