using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MifareOneTool.Properties;

namespace MifareOneTool;

public class FormHTool : Form
{
	private f m_a = new f();

	private g m_b = new g();

	private string m_c = "";

	private bool m_d = true;

	private int m_e = -1;

	[CompilerGenerated]
	private ClickDelegateHander m_f;

	private IContainer m_g;

	private MenuStrip m_h;

	private ToolStripMenuItem m_i;

	private ToolStripMenuItem m_j;

	private ToolStripMenuItem m_k;

	private ToolStripMenuItem m_l;

	private ToolStripSeparator m_m;

	private ToolStripMenuItem m_n;

	private ToolStripMenuItem m_o;

	private ToolStripMenuItem m_p;

	private ToolStripMenuItem m_q;

	private GroupBox m_r;

	private DataGridView m_s;

	private DataGridViewTextBoxColumn t;

	private BindingSource u;

	private GroupBox v;

	private Label w;

	private TextBox x;

	private Label y;

	private Label z;

	private TextBox aa;

	private Label ab;

	private Label ac;

	private TextBox ad;

	private TextBox ae;

	private TextBox af;

	private Label ag;

	private Button ah;

	private ComboBox ai;

	private ComboBox aj;

	private ComboBox ak;

	private ComboBox al;

	private Label am;

	private Label an;

	private Label ao;

	private Label ap;

	private GroupBox aq;

	private RichTextBox ar;

	private ToolStripMenuItem @as;

	private ToolStripMenuItem at;

	private ToolStripSeparator au;

	private ToolStripSeparator av;

	private ToolStripMenuItem aw;

	private ToolStripMenuItem ax;

	private ToolStripMenuItem ay;

	private ToolStripSeparator az;

	private ToolStripMenuItem a0;

	private TableLayoutPanel a1;

	private FlowLayoutPanel a2;

	private TableLayoutPanel a3;

	private FlowLayoutPanel a4;

	private FlowLayoutPanel a5;

	private TableLayoutPanel a6;

	private Button a7;

	private Button a8;

	public event ClickDelegateHander ClickEvent
	{
		[CompilerGenerated]
		add
		{
			int num = default(int);
			ClickDelegateHander clickDelegateHander = default(ClickDelegateHander);
			switch (0)
			{
			default:
			{
				ClickDelegateHander clickDelegateHander2 = default(ClickDelegateHander);
				while (true)
				{
					switch (num)
					{
					case 1:
					{
						short num2 = 0;
						_ = num2;
						clickDelegateHander2 = clickDelegateHander;
						ClickDelegateHander value2 = (ClickDelegateHander)Delegate.Combine(clickDelegateHander2, value);
						clickDelegateHander = Interlocked.CompareExchange(ref this.m_f, value2, clickDelegateHander2);
						num2 = 26003;
						short num3 = num2;
						num2 = 26003;
						switch (num3 == num2)
						{
						case false:
						case true:
							return;
						}
						num2 = 1;
						if (num2 != 0)
						{
						}
						num2 = 0;
						if (num2 != 0)
						{
						}
						num2 = 2;
						num = num2;
						continue;
					}
					case 2:
					{
						if ((object)clickDelegateHander != clickDelegateHander2)
						{
							goto case 1;
						}
						short num2 = 0;
						num = num2;
						continue;
					}
					case 0:
						return;
					}
					break;
				}
				goto case 0;
			}
			case 0:
			{
				clickDelegateHander = this.m_f;
				short num2 = 1;
				num = num2;
				goto default;
			}
			}
		}
		[CompilerGenerated]
		remove
		{
			int num = default(int);
			ClickDelegateHander clickDelegateHander = default(ClickDelegateHander);
			switch (0)
			{
			default:
			{
				ClickDelegateHander clickDelegateHander2 = default(ClickDelegateHander);
				while (true)
				{
					switch (num)
					{
					case 1:
					{
						short num2 = 0;
						_ = num2;
						clickDelegateHander2 = clickDelegateHander;
						ClickDelegateHander value2 = (ClickDelegateHander)Delegate.Remove(clickDelegateHander2, value);
						clickDelegateHander = Interlocked.CompareExchange(ref this.m_f, value2, clickDelegateHander2);
						num2 = -28609;
						short num3 = num2;
						num2 = -28609;
						switch (num3 == num2)
						{
						case false:
						case true:
							return;
						}
						num2 = 0;
						if (num2 != 0)
						{
						}
						num2 = 1;
						if (num2 != 0)
						{
						}
						num2 = 2;
						num = num2;
						continue;
					}
					case 2:
					{
						if ((object)clickDelegateHander != clickDelegateHander2)
						{
							goto case 1;
						}
						short num2 = 0;
						num = num2;
						continue;
					}
					case 0:
						return;
					}
					break;
				}
				goto case 0;
			}
			case 0:
			{
				clickDelegateHander = this.m_f;
				short num2 = 1;
				num = num2;
				goto default;
			}
			}
		}
	}

	public FormHTool(string filename)
	{
		a();
		if (filename == "")
		{
			return;
		}
		this.m_c = filename;
		File.SetAttributes(this.m_c, FileAttributes.Normal);
		a(-1);
		if (!Settings.Default.pcrqinlin)
		{
			this.m_a = new f();
			try
			{
				if (new FileInfo(this.m_c).Length > 2100)
				{
					string text = "./nfc-data/tmp/mcttxtedit.tmp";
					if (File.Exists(text))
					{
						File.SetAttributes(text, FileAttributes.Normal);
						File.Delete(text);
					}
					this.m_a.c(this.m_c);
					this.m_a.d(text);
					this.m_c = text;
					this.m_d = true;
				}
				else
				{
					this.m_a.a(this.m_c);
					this.m_d = true;
				}
			}
			catch (IOException ex)
			{
				MessageBox.Show(ex.Message, Resources.打开出错, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				this.m_a = new f();
				return;
			}
		}
		else
		{
			this.m_b = new g();
			try
			{
				if (new FileInfo(this.m_c).Length > 2100)
				{
					string text2 = "./nfc-data/tmp/mcttxtedit.tmp";
					if (File.Exists(text2))
					{
						File.SetAttributes(text2, FileAttributes.Normal);
						File.Delete(text2);
					}
					this.m_b.c(this.m_c);
					this.m_b.d(text2);
					this.m_c = text2;
					this.m_d = true;
				}
				else
				{
					this.m_b.a(this.m_c);
					this.m_d = true;
				}
			}
			catch (IOException ex2)
			{
				MessageBox.Show(ex2.Message, Resources.打开出错, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				this.m_b = new g();
				return;
			}
		}
		b();
		a(Resources.打开了 + this.m_c);
	}

	private void a(object A_0, DataGridViewCellEventArgs A_1)
	{
		short num = 1;
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
				if (this.m_s.SelectedRows.Count > 0)
				{
					num = 2;
					num2 = num;
					continue;
				}
				break;
			case 2:
			{
				int a_ = this.m_s.SelectedRows[0].Index / 5;
				a(a_);
				a(Resources.显示扇区 + a_);
				num = 0;
				num2 = num;
				continue;
			}
			case 0:
				break;
			}
			num = 14377;
			short num3 = num;
			num = 14377;
			switch (num3 == num)
			{
			case false:
			case true:
				continue;
			default:
				num = 0;
				_ = num;
				break;
			case true:
				break;
			}
			break;
		}
		num = 1;
		if (num != 0)
		{
		}
		num = 0;
		if (num == 0)
		{
		}
	}

	private void a(string A_0)
	{
		short num = -23880;
		short num2 = num;
		num = -23880;
		switch (num2 == num)
		{
		}
		num = 0;
		_ = num;
		num = 1;
		if (num != 0)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		ar.AppendText(A_0 + "\n");
		ar.ScrollToCaret();
	}

	private void a(int A_0)
	{
		string text2 = default(string);
		string text = default(string);
		while (true)
		{
			short num = 0;
			switch (num)
			{
			}
			num = 6;
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
					if (Settings.Default.pcrqinlin)
					{
						num = 10;
						num2 = num;
					}
					else
					{
						this.m_e = A_0;
						num = 11;
						num2 = num;
					}
					continue;
				case 10:
					this.m_e = A_0;
					num = 7;
					num2 = num;
					continue;
				case 7:
				{
					if (A_0 == -1)
					{
						num = 3;
						num2 = num;
						continue;
					}
					w.Text = Resources.当前选定扇区0 + A_0;
					x.Text = Form1.hex(this.m_b.c()[A_0].f()[0]);
					aa.Text = Form1.hex(this.m_b.c()[A_0].f()[1]);
					af.Text = Form1.hex(this.m_b.c()[A_0].f()[2]);
					ae.Text = Form1.hex(this.m_b.c()[A_0].f()[3].Skip(0).Take(6).ToArray());
					ad.Text = Form1.hex(this.m_b.c()[A_0].f()[3].Skip(10).Take(6).ToArray());
					byte[] array2 = global::b.c(this.m_b.c()[A_0].f()[3].Skip(6).Take(4).ToArray());
					al.SelectedIndex = array2[0] & 7;
					ak.SelectedIndex = array2[1] & 7;
					aj.SelectedIndex = array2[2] & 7;
					ai.SelectedIndex = array2[3] & 7;
					num = 1;
					num2 = num;
					continue;
				}
				case 3:
					al.SelectedIndex = 0;
					ak.SelectedIndex = 0;
					aj.SelectedIndex = 0;
					ai.SelectedIndex = 1;
					ad.Text = "";
					ae.Text = "";
					af.Text = "";
					aa.Text = "";
					x.Text = "";
					w.Text = Resources.当前选定扇区;
					return;
				case 1:
				{
					int num4 = this.m_b.c()[A_0].i();
					text2 = "";
					if ((num4 & 1) == 1)
					{
						this.m_b.c()[A_0].f()[0][4] = (byte)(this.m_b.c()[A_0].f()[0][0] ^ this.m_b.c()[A_0].f()[0][1] ^ this.m_b.c()[A_0].f()[0][2] ^ this.m_b.c()[A_0].f()[0][3]);
						x.Text = Form1.hex(this.m_b.c()[A_0].f()[0]);
						text2 += Resources.该扇区UID校验值错误_已经自动为您更正;
					}
					if ((num4 & 2) == 2)
					{
						al.SelectedIndex = 0;
						ak.SelectedIndex = 0;
						aj.SelectedIndex = 0;
						ai.SelectedIndex = 1;
						text2 += Resources.该扇区访问控制位无效_写入将会损坏卡片_已重新设置;
					}
					if ((num4 & 4) == 4)
					{
						al.SelectedIndex = 0;
						ak.SelectedIndex = 0;
						aj.SelectedIndex = 0;
						ai.SelectedIndex = 1;
						text2 += Resources.该扇区访问控制位损坏_写入将会损坏卡片_已重新设置;
					}
					if (num4 != 0)
					{
						num = 8;
						num2 = num;
						continue;
					}
					break;
				}
				case 8:
					MessageBox.Show(text2.Trim());
					num = 5;
					num2 = num;
					continue;
				case 11:
				{
					if (A_0 == -1)
					{
						num = 2;
						num2 = num;
						continue;
					}
					w.Text = Resources.当前选定扇区0 + A_0;
					x.Text = Form1.hex(this.m_a.c()[A_0].f()[0]);
					aa.Text = Form1.hex(this.m_a.c()[A_0].f()[1]);
					af.Text = Form1.hex(this.m_a.c()[A_0].f()[2]);
					ae.Text = Form1.hex(this.m_a.c()[A_0].f()[3].Skip(0).Take(6).ToArray());
					ad.Text = Form1.hex(this.m_a.c()[A_0].f()[3].Skip(10).Take(6).ToArray());
					byte[] array = global::b.c(this.m_a.c()[A_0].f()[3].Skip(6).Take(4).ToArray());
					al.SelectedIndex = array[0] & 7;
					ak.SelectedIndex = array[1] & 7;
					aj.SelectedIndex = array[2] & 7;
					ai.SelectedIndex = array[3] & 7;
					num = 0;
					num2 = num;
					continue;
				}
				case 2:
					num = 1;
					if (num != 0)
					{
					}
					al.SelectedIndex = 0;
					ak.SelectedIndex = 0;
					aj.SelectedIndex = 0;
					ai.SelectedIndex = 1;
					ad.Text = "";
					ae.Text = "";
					af.Text = "";
					aa.Text = "";
					x.Text = "";
					w.Text = Resources.当前选定扇区;
					return;
				case 0:
				{
					int num3 = this.m_a.c()[A_0].i();
					text = "";
					if ((num3 & 1) == 1)
					{
						this.m_a.c()[A_0].f()[0][4] = (byte)(this.m_a.c()[A_0].f()[0][0] ^ this.m_a.c()[A_0].f()[0][1] ^ this.m_a.c()[A_0].f()[0][2] ^ this.m_a.c()[A_0].f()[0][3]);
						x.Text = Form1.hex(this.m_a.c()[A_0].f()[0]);
						text += Resources.该扇区UID校验值错误_已经自动为您更正;
					}
					if ((num3 & 2) == 2)
					{
						al.SelectedIndex = 0;
						ak.SelectedIndex = 0;
						aj.SelectedIndex = 0;
						ai.SelectedIndex = 1;
						text += Resources.该扇区访问控制位无效_写入将会损坏卡片_已重新设置;
					}
					if ((num3 & 4) == 4)
					{
						al.SelectedIndex = 0;
						ak.SelectedIndex = 0;
						aj.SelectedIndex = 0;
						ai.SelectedIndex = 1;
						text += Resources.该扇区访问控制位损坏_写入将会损坏卡片_已重新设置;
					}
					if (num3 != 0)
					{
						num = 9;
						num2 = num;
						continue;
					}
					break;
				}
				case 9:
					num = 0;
					_ = num;
					MessageBox.Show(text.Trim());
					num = 4;
					num2 = num;
					continue;
				case 4:
				case 5:
					break;
				}
				break;
			}
			num = 12401;
			short num5 = num;
			num = 12401;
			switch (num5 == num)
			{
			case false:
			case true:
				continue;
			}
			num = 0;
			if (num != 0)
			{
			}
			ValidateChildren();
			return;
		}
	}

	private void s(object A_0, EventArgs A_1)
	{
		OpenFileDialog openFileDialog = default(OpenFileDialog);
		int num = default(int);
		switch (0)
		{
		default:
		{
			string text = default(string);
			while (true)
			{
				switch (num)
				{
				case 3:
					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						short num2 = 1;
						num = num2;
						continue;
					}
					return;
				case 1:
				{
					this.m_c = openFileDialog.FileName;
					short num2 = 4;
					num = num2;
					continue;
				}
				case 4:
				{
					short num2 = -32316;
					short num3 = num2;
					num2 = -32316;
					switch (num3 == num2)
					{
					case false:
					case true:
						break;
					default:
						num2 = 1;
						if (num2 != 0)
						{
						}
						num2 = 0;
						if (num2 != 0)
						{
						}
						num2 = 0;
						_ = num2;
						this.m_a = new f();
						num2 = 0;
						num = num2;
						continue;
					}
					goto case 1;
				}
				case 2:
					return;
				case 0:
				{
					short num2;
					try
					{
						num2 = 6;
						num = num2;
						while (true)
						{
							switch (num)
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
								if (new FileInfo(this.m_c).Length > 2100)
								{
									num2 = 5;
									num = num2;
									continue;
								}
								this.m_a.a(this.m_c);
								this.m_d = true;
								num2 = 4;
								num = num2;
								continue;
							case 7:
								File.SetAttributes(text, FileAttributes.Normal);
								File.Delete(text);
								num2 = 0;
								num = num2;
								continue;
							case 5:
								text = "./nfc-data/tmp/mcttxtedit.tmp";
								num2 = 1;
								num = num2;
								continue;
							case 1:
								if (File.Exists(text))
								{
									num2 = 7;
									num = num2;
									continue;
								}
								goto case 0;
							case 0:
								this.m_a.c(this.m_c);
								this.m_a.d(text);
								this.m_c = text;
								this.m_d = true;
								num2 = 2;
								num = num2;
								continue;
							case 2:
							case 4:
								num2 = 3;
								num = num2;
								continue;
							case 3:
								break;
							}
							break;
						}
					}
					catch (IOException ex)
					{
						MessageBox.Show(ex.Message, Resources.打开出错, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						this.m_a = new f();
						return;
					}
					b();
					a(Resources.打开了 + openFileDialog.FileName);
					num2 = 2;
					num = num2;
					continue;
				}
				}
				break;
			}
			goto case 0;
		}
		case 0:
		{
			a(-1);
			openFileDialog = new OpenFileDialog();
			openFileDialog.CheckFileExists = true;
			openFileDialog.Filter = Resources.MFD文件_mfd_dump;
			openFileDialog.Title = Resources.请选择需要打开的MFD文件;
			openFileDialog.Multiselect = false;
			short num2 = 3;
			num = num2;
			goto default;
		}
		}
	}

	private void b()
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			int num3 = default(int);
			switch (0)
			{
			default:
			{
				int num5 = default(int);
				int index = default(int);
				int num4 = default(int);
				while (true)
				{
					switch (num2)
					{
					case 14:
						if (Settings.Default.pcrqinlin)
						{
							num = 13;
							num2 = num;
							continue;
						}
						goto case 4;
					case 7:
					case 8:
						num = 18;
						num2 = num;
						continue;
					case 18:
						if (num5 >= 4)
						{
							num = 17;
							num2 = num;
						}
						else
						{
							index = this.m_s.Rows.Add();
							num = 6;
							num2 = num;
						}
						continue;
					case 5:
						this.m_s.Rows[index].Cells[0].Style.ForeColor = Color.Chocolate;
						num = 15;
						num2 = num;
						continue;
					case 1:
					case 16:
						num = 2;
						num2 = num;
						continue;
					case 2:
						if (num4 < num3)
						{
							index = this.m_s.Rows.Add();
							this.m_s.Rows[index].Cells[0].Value = Resources.扇区0 + num4;
							num5 = 0;
							num = 7;
							num2 = num;
						}
						else
						{
							num = 12;
							num2 = num;
						}
						continue;
					case 4:
						num4 = 0;
						num = 1;
						num2 = num;
						continue;
					case 17:
						num4++;
						goto IL_021d;
					case 9:
					case 10:
						num = 11;
						num2 = num;
						continue;
					case 11:
						if (num5 == 3)
						{
							num = 5;
							num2 = num;
							continue;
						}
						goto case 15;
					case 6:
						if (Settings.Default.pcrqinlin)
						{
							num = 19;
							num2 = num;
							continue;
						}
						num = 1;
						if (num != 0)
						{
						}
						this.m_s.Rows[index].Cells[0].Value = global::b.d(this.m_a.c()[num4].f()[num5]);
						num = 10;
						num2 = num;
						continue;
					case 12:
						num = 0;
						num2 = num;
						continue;
					case 0:
						if (this.m_a.e()[16] != 0)
						{
							num = 3;
							num2 = num;
							continue;
						}
						return;
					case 3:
					{
						num = 19374;
						short num6 = num;
						num = 19374;
						switch (num6 == num)
						{
						case false:
						case true:
							break;
						default:
							num = 0;
							if (num != 0)
							{
							}
							MessageBox.Show(Resources.打开出错, Resources.打开出错, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							return;
						}
						goto IL_021d;
					}
					case 15:
						num = 0;
						_ = num;
						num5++;
						num = 8;
						num2 = num;
						continue;
					case 19:
						this.m_s.Rows[index].Cells[0].Value = global::b.d(this.m_b.c()[num4].f()[num5]);
						num = 9;
						num2 = num;
						continue;
					case 13:
						{
							num3 = 18;
							num = 4;
							num2 = num;
							continue;
						}
						IL_021d:
						num = 16;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				this.m_s.Rows.Clear();
				num3 = 16;
				num = 14;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private void r(object A_0, EventArgs A_1)
	{
		short num = 0;
		_ = num;
		num = 16540;
		short num2 = num;
		num = 16540;
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
		Close();
	}

	private void q(object A_0, EventArgs A_1)
	{
		short num;
		try
		{
			num = 6;
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
					if (Settings.Default.pcrqinlin)
					{
						num = 1;
						num2 = num;
						continue;
					}
					goto IL_015d;
				case 3:
					this.m_a.d(this.m_c);
					num = 2;
					num2 = num;
					continue;
				case 1:
					num = 4;
					num2 = num;
					continue;
				case 4:
					if (!this.m_d)
					{
						this.m_b.e(this.m_c);
						num = 0;
						num2 = num;
					}
					else
					{
						num = 10;
						num2 = num;
					}
					continue;
				case 10:
					this.m_b.d(this.m_c);
					num = 5;
					num2 = num;
					continue;
				case 7:
					if (!this.m_d)
					{
						this.m_a.e(this.m_c);
						num = 8;
						num2 = num;
					}
					else
					{
						num = 3;
						num2 = num;
					}
					continue;
				case 0:
				case 2:
				case 5:
				case 8:
					num = 9;
					num2 = num;
					continue;
				case 9:
					{
						num = -22826;
						short num3 = num;
						num = -22826;
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
							goto end_IL_0020;
						}
						goto IL_015d;
					}
					IL_015d:
					num = 7;
					num2 = num;
					continue;
					end_IL_0020:
					break;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, Resources.写入出错, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		num = 1;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
		a(Resources.已保存到 + this.m_c + Resources.res);
	}

	private void p(object A_0, EventArgs A_1)
	{
		SaveFileDialog saveFileDialog = default(SaveFileDialog);
		int num = default(int);
		switch (0)
		{
		default:
		{
			string fileName = default(string);
			while (true)
			{
				switch (num)
				{
				case 0:
					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						short num2 = 3;
						num = num2;
						continue;
					}
					return;
				case 1:
					try
					{
						short num2 = 6;
						num = num2;
						while (true)
						{
							switch (num)
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
								if (Settings.Default.pcrqinlin)
								{
									num2 = 1;
									num = num2;
								}
								else
								{
									num2 = 5;
									num = num2;
								}
								continue;
							case 7:
								this.m_a.d(this.m_c);
								num2 = 2;
								num = num2;
								continue;
							case 1:
								num2 = 10;
								num = num2;
								continue;
							case 10:
								if (!this.m_d)
								{
									this.m_b.e(this.m_c);
									num2 = 4;
									num = num2;
								}
								else
								{
									num2 = 8;
									num = num2;
								}
								continue;
							case 5:
								if (!this.m_d)
								{
									this.m_a.e(this.m_c);
									num2 = 0;
									num = num2;
								}
								else
								{
									num2 = 7;
									num = num2;
								}
								continue;
							case 8:
								this.m_b.d(this.m_c);
								num2 = 3;
								num = num2;
								continue;
							case 0:
							case 2:
							case 3:
							case 4:
								num2 = 9;
								num = num2;
								continue;
							case 9:
								{
									num2 = -28091;
									short num3 = num2;
									num2 = -28091;
									switch (num3 == num2)
									{
									case false:
									case true:
										break;
									default:
										num2 = 0;
										if (num2 == 0)
										{
										}
										goto end_IL_00db;
									}
									goto case 7;
								}
								end_IL_00db:
								break;
							}
							break;
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, Resources.写入出错, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					a(Resources.已保存到 + fileName + "。");
					return;
				case 3:
				{
					fileName = saveFileDialog.FileName;
					short num2 = 2;
					num = num2;
					continue;
				}
				case 2:
				{
					short num2 = 1;
					if (num2 != 0)
					{
					}
					num2 = 1;
					num = num2;
					continue;
				}
				}
				break;
			}
			goto case 0;
		}
		case 0:
		{
			saveFileDialog = new SaveFileDialog();
			saveFileDialog.AddExtension = true;
			saveFileDialog.DefaultExt = ".mfd";
			saveFileDialog.Title = Resources.请选择MFD文件保存位置及文件名;
			saveFileDialog.OverwritePrompt = true;
			saveFileDialog.Filter = Resources.MFD文件_mfd_DUMP文件_dump;
			short num2 = 0;
			_ = num2;
			num2 = 0;
			num = num2;
			goto default;
		}
		}
	}

	private void c(object A_0, CancelEventArgs A_1)
	{
		int num = default(int);
		string text = default(string);
		TextBox textBox = default(TextBox);
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 0:
				{
					short num2 = -22100;
					short num3 = num2;
					num2 = -22100;
					switch (num3 == num2)
					{
					default:
						num2 = 0;
						if (num2 != 0)
						{
						}
						if (!Regex.IsMatch(text, "[0-9A-Fa-f]{32}"))
						{
							break;
						}
						goto case false;
					case false:
					case true:
						num2 = 3;
						num = num2;
						continue;
					}
					goto case 2;
				}
				case 2:
					textBox.BackColor = Color.Tomato;
					return;
				case 3:
				{
					short num2 = 1;
					num = num2;
					continue;
				}
				case 1:
					if (text.Length != 32)
					{
						short num2 = 2;
						num = num2;
						continue;
					}
					textBox.BackColor = Color.Aquamarine;
					textBox.Text = text;
					return;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			textBox = (TextBox)A_0;
			text = textBox.Text.Trim();
			short num2 = 1;
			if (num2 != 0)
			{
			}
			num2 = 0;
			_ = num2;
			num2 = 0;
			num = num2;
			goto default;
		}
		}
	}

	private void b(object A_0, CancelEventArgs A_1)
	{
		int num = default(int);
		string text = default(string);
		TextBox textBox = default(TextBox);
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 0:
				{
					short num2 = 0;
					_ = num2;
					num2 = 9;
					short num3 = num2;
					num2 = 9;
					switch (num3 == num2)
					{
					default:
						num2 = 0;
						if (num2 != 0)
						{
						}
						if (!Regex.IsMatch(text, "[0-9A-Fa-f]{12}"))
						{
							break;
						}
						goto case false;
					case false:
					case true:
						num2 = 3;
						num = num2;
						continue;
					}
					goto case 2;
				}
				case 3:
				{
					short num2 = 1;
					if (num2 != 0)
					{
					}
					num2 = 1;
					num = num2;
					continue;
				}
				case 2:
					textBox.BackColor = Color.Tomato;
					return;
				case 1:
					if (text.Length != 12)
					{
						short num2 = 2;
						num = num2;
						continue;
					}
					textBox.BackColor = Color.Aquamarine;
					textBox.Text = text;
					return;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			textBox = (TextBox)A_0;
			text = textBox.Text.Trim();
			short num2 = 0;
			num = num2;
			goto default;
		}
		}
	}

	private void o(object A_0, EventArgs A_1)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 15;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 15:
					switch (0)
					{
					default:
						goto end_IL_003f;
					case 0:
						break;
					}
					goto default;
				default:
					if (Settings.Default.pcrqinlin)
					{
						num = 34;
						num2 = num;
					}
					else
					{
						num = 12;
						num2 = num;
					}
					break;
				case 28:
					num = 1;
					num2 = num;
					break;
				case 1:
					if (!(ae.BackColor != Color.Aquamarine))
					{
						num = 31;
						num2 = num;
						break;
					}
					goto case 8;
				case 2:
					num = 33;
					num2 = num;
					break;
				case 33:
					if (this.m_e <= 15)
					{
						num = 5;
						num2 = num;
						break;
					}
					return;
				case 30:
					num = 14;
					num2 = num;
					break;
				case 14:
					if (!(ae.BackColor != Color.Aquamarine))
					{
						num = 3;
						num2 = num;
						break;
					}
					goto case 21;
				case 36:
				{
					try
					{
						num = 0;
						num2 = num;
						while (true)
						{
							switch (num2)
							{
							case 0:
								switch (0)
								{
								default:
									continue;
								case 0:
									break;
								}
								goto default;
							default:
								if (this.m_d)
								{
									num = 1;
									num2 = num;
								}
								else
								{
									this.m_a.e(this.m_c);
									num = 2;
									num2 = num;
								}
								continue;
							case 1:
								this.m_a.d(this.m_c);
								num = 4;
								num2 = num;
								continue;
							case 2:
							case 4:
								num = 3;
								num2 = num;
								continue;
							case 3:
								break;
							}
							break;
						}
					}
					catch (Exception ex2)
					{
						MessageBox.Show(ex2.Message, Resources.写入出错, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					num = 23101;
					short num3 = num;
					num = 23101;
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
						num = 18;
						num2 = num;
						goto end_IL_003f;
					}
					goto IL_0307;
				}
				case 16:
					num = 10;
					num2 = num;
					break;
				case 10:
					if (!(aa.BackColor != Color.Aquamarine))
					{
						goto IL_0307;
					}
					goto case 21;
				case 27:
					num = 4;
					num2 = num;
					break;
				case 4:
					if (!(af.BackColor != Color.Aquamarine))
					{
						num = 28;
						num2 = num;
						break;
					}
					goto case 8;
				case 18:
					if (this.m_f != null)
					{
						num = 13;
						num2 = num;
						break;
					}
					goto case 26;
				case 12:
					if (this.m_e >= 0)
					{
						num = 2;
						num2 = num;
						break;
					}
					return;
				case 3:
					num = 25;
					num2 = num;
					break;
				case 25:
				{
					if (ad.BackColor != Color.Aquamarine)
					{
						num = 21;
						num2 = num;
						break;
					}
					this.m_b.c()[this.m_e].f()[0] = global::b.a(x.Text.Trim(), 16);
					this.m_b.c()[this.m_e].f()[1] = global::b.a(aa.Text.Trim(), 16);
					this.m_b.c()[this.m_e].f()[2] = global::b.a(af.Text.Trim(), 16);
					byte[] collection4 = global::b.a(ae.Text.Trim(), 6);
					byte[] collection5 = global::b.a(ad.Text.Trim(), 6);
					byte[] collection6 = global::b.a(new byte[4]
					{
						(byte)al.SelectedIndex,
						(byte)ak.SelectedIndex,
						(byte)aj.SelectedIndex,
						(byte)ai.SelectedIndex
					});
					List<byte> list2 = new List<byte>(collection4);
					list2.AddRange(collection6);
					list2.AddRange(collection5);
					byte[] array2 = list2.Take(16).ToArray();
					byte b2 = this.m_b.c()[this.m_e].f()[3][9];
					this.m_b.c()[this.m_e].f()[3] = array2;
					this.m_b.c()[this.m_e].f()[3][9] = b2;
					this.b();
					a(Resources.已更新扇区 + this.m_e);
					num = 0;
					num2 = num;
					break;
				}
				case 26:
					a(Resources.已保存到 + this.m_c + Resources.res);
					num = 1;
					if (num != 0)
					{
					}
					num = 7;
					num2 = num;
					break;
				case 7:
					return;
				case 34:
					num = 38;
					num2 = num;
					break;
				case 38:
					if (this.m_e >= 0)
					{
						num = 37;
						num2 = num;
						break;
					}
					return;
				case 19:
					num = 6;
					num2 = num;
					break;
				case 6:
					if (!(af.BackColor != Color.Aquamarine))
					{
						num = 30;
						num2 = num;
						break;
					}
					goto case 21;
				case 21:
					MessageBox.Show(Resources.当前扇区数据仍有错误_不能执行修改);
					return;
				case 31:
					num = 9;
					num2 = num;
					break;
				case 9:
					if (!(ad.BackColor != Color.Aquamarine))
					{
						this.m_a.c()[this.m_e].f()[0] = global::b.a(x.Text.Trim(), 16);
						this.m_a.c()[this.m_e].f()[1] = global::b.a(aa.Text.Trim(), 16);
						this.m_a.c()[this.m_e].f()[2] = global::b.a(af.Text.Trim(), 16);
						byte[] collection = global::b.a(ae.Text.Trim(), 6);
						byte[] collection2 = global::b.a(ad.Text.Trim(), 6);
						byte[] collection3 = global::b.a(new byte[4]
						{
							(byte)al.SelectedIndex,
							(byte)ak.SelectedIndex,
							(byte)aj.SelectedIndex,
							(byte)ai.SelectedIndex
						});
						List<byte> list = new List<byte>(collection);
						list.AddRange(collection3);
						list.AddRange(collection2);
						byte[] array = list.Take(16).ToArray();
						byte b = this.m_a.c()[this.m_e].f()[3][9];
						this.m_a.c()[this.m_e].f()[3] = array;
						this.m_a.c()[this.m_e].f()[3][9] = b;
						this.b();
						a(Resources.已更新扇区 + this.m_e);
						num = 36;
						num2 = num;
					}
					else
					{
						num = 8;
						num2 = num;
					}
					break;
				case 35:
					if (this.m_f != null)
					{
						num = 32;
						num2 = num;
						break;
					}
					goto case 24;
				case 32:
					this.m_f("Datasaved");
					num = 24;
					num2 = num;
					break;
				case 29:
					num = 22;
					num2 = num;
					break;
				case 22:
					if (!(aa.BackColor != Color.Aquamarine))
					{
						num = 27;
						num2 = num;
						break;
					}
					goto case 8;
				case 0:
					try
					{
						num = 0;
						num2 = num;
						while (true)
						{
							switch (num2)
							{
							case 0:
								switch (0)
								{
								default:
									continue;
								case 0:
									break;
								}
								goto default;
							default:
								if (this.m_d)
								{
									num = 1;
									num2 = num;
								}
								else
								{
									this.m_b.e(this.m_c);
									num = 2;
									num2 = num;
								}
								continue;
							case 1:
								this.m_b.d(this.m_c);
								num = 4;
								num2 = num;
								continue;
							case 2:
							case 4:
								num = 3;
								num2 = num;
								continue;
							case 3:
								break;
							}
							break;
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, Resources.写入出错, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					num = 35;
					num2 = num;
					break;
				case 20:
					ValidateChildren();
					num = 11;
					num2 = num;
					break;
				case 11:
					if (!(x.BackColor != Color.Aquamarine))
					{
						num = 16;
						num2 = num;
						break;
					}
					goto case 21;
				case 13:
					this.m_f("Datasaved");
					num = 26;
					num2 = num;
					break;
				case 24:
					a(Resources.已保存到 + this.m_c + Resources.res);
					return;
				case 37:
					num = 17;
					num2 = num;
					break;
				case 17:
					if (this.m_e <= 17)
					{
						num = 20;
						num2 = num;
						break;
					}
					return;
				case 5:
					ValidateChildren();
					num = 23;
					num2 = num;
					break;
				case 23:
					if (!(x.BackColor != Color.Aquamarine))
					{
						num = 29;
						num2 = num;
						break;
					}
					goto case 8;
				case 8:
					{
						num = 0;
						_ = num;
						MessageBox.Show(Resources.当前扇区数据仍有错误_不能执行修改);
						return;
					}
					IL_0307:
					num = 19;
					num2 = num;
					break;
					end_IL_003f:
					break;
				}
			}
		}
		}
	}

	private void a(object A_0, CancelEventArgs A_1)
	{
		int num = default(int);
		ComboBox comboBox = default(ComboBox);
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 0:
				{
					short num2 = 0;
					_ = num2;
					num2 = -13297;
					short num3 = num2;
					num2 = -13297;
					switch (num3 == num2)
					{
					default:
						num2 = 0;
						if (num2 != 0)
						{
						}
						num2 = 1;
						if (num2 != 0)
						{
						}
						if (comboBox.SelectedIndex < 0)
						{
							break;
						}
						goto case false;
					case false:
					case true:
						num2 = 3;
						num = num2;
						continue;
					}
					goto case 2;
				}
				case 2:
					comboBox.BackColor = Color.Tomato;
					return;
				case 3:
				{
					short num2 = 1;
					num = num2;
					continue;
				}
				case 1:
					if (comboBox.Text == Resources._文件中的值错误)
					{
						short num2 = 2;
						num = num2;
						continue;
					}
					comboBox.BackColor = Color.Aquamarine;
					return;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			comboBox = (ComboBox)A_0;
			short num2 = 0;
			num = num2;
			goto default;
		}
		}
	}

	private void n(object A_0, EventArgs A_1)
	{
		int num = default(int);
		int[] array = default(int[]);
		switch (0)
		{
		default:
		{
			string text = default(string);
			int num4 = default(int);
			while (true)
			{
				short num2;
				switch (num)
				{
				case 11:
					if (array[16] == 0)
					{
						num2 = 12;
						num = num2;
						continue;
					}
					text = Resources.该文件存在以下错误;
					num4 = 0;
					num2 = 4;
					num = num2;
					continue;
				case 7:
					num2 = 14;
					num = num2;
					continue;
				case 14:
					if (array[num4] == 0)
					{
						num2 = 0;
						_ = num2;
						num2 = 16;
						num = num2;
						continue;
					}
					goto case 17;
				case 8:
					if ((array[num4] & 4) == 4)
					{
						num2 = 0;
						num = num2;
						continue;
					}
					goto case 7;
				case 9:
					if ((array[num4] & 1) == 1)
					{
						num2 = 1;
						num = num2;
						continue;
					}
					goto IL_023f;
				case 17:
					num4++;
					num2 = 6;
					num = num2;
					continue;
				case 0:
					text += Resources.该扇区访问控制位损坏_写入将会损坏卡片_请重新设置;
					num2 = 7;
					num = num2;
					continue;
				case 4:
				case 6:
					num2 = 5;
					num = num2;
					continue;
				case 5:
					if (num4 < 16)
					{
						text = text + Resources.扇区 + num4 + "：\n";
						num2 = 9;
						num = num2;
					}
					else
					{
						num2 = 10;
						num = num2;
					}
					continue;
				case 15:
					if ((array[num4] & 2) == 2)
					{
						num2 = 2;
						num = num2;
						continue;
					}
					goto IL_0103;
				case 12:
					MessageBox.Show(Resources.该文件一切正常);
					return;
				case 16:
					text += Resources.该扇区一切正常;
					num2 = 17;
					num = num2;
					continue;
				case 2:
					text += Resources.该扇区访问控制位无效_写入将会损坏卡片_请重新设置;
					num2 = 13;
					num = num2;
					continue;
				case 13:
					num2 = 1;
					if (num2 == 0)
					{
					}
					goto IL_0103;
				case 1:
					text += Resources.该扇区UID校验值错误_请点击打开扇区0来自动更正;
					num2 = 3;
					num = num2;
					continue;
				case 3:
				{
					num2 = -19037;
					short num3 = num2;
					num2 = -19037;
					switch (num3 == num2)
					{
					case false:
					case true:
						break;
					default:
						goto IL_0356;
					}
					goto case 2;
				}
				case 10:
					{
						ar.Clear();
						ar.Text = text;
						return;
					}
					IL_0356:
					num2 = 0;
					if (num2 == 0)
					{
					}
					goto IL_023f;
					IL_0103:
					num2 = 8;
					num = num2;
					continue;
					IL_023f:
					num2 = 15;
					num = num2;
					continue;
				}
				break;
			}
			goto case 0;
		}
		case 0:
		{
			array = this.m_a.e();
			short num2 = 11;
			num = num2;
			goto default;
		}
		}
	}

	private void m(object A_0, EventArgs A_1)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			string text = default(string);
			string pattern = default(string);
			byte[] array = default(byte[]);
			switch (0)
			{
			default:
			{
				byte b = default(byte);
				while (true)
				{
					switch (num2)
					{
					case 2:
						if (!Regex.IsMatch(text, pattern))
						{
							num = 4;
							num2 = num;
							continue;
						}
						array = global::b.a(text, 4);
						b = (byte)(array[0] ^ array[1] ^ array[2] ^ array[3]);
						num = 3;
						num2 = num;
						continue;
					case 0:
					{
						num = -32592;
						short num3 = num;
						num = -32592;
						switch (num3 == num)
						{
						default:
							num = 1;
							if (num != 0)
							{
							}
							num = 0;
							if (num != 0)
							{
							}
							this.m_a.c()[0].f()[0][0] = array[0];
							this.m_a.c()[0].f()[0][1] = array[1];
							this.m_a.c()[0].f()[0][2] = array[2];
							this.m_a.c()[0].f()[0][3] = array[3];
							this.m_a.c()[0].f()[0][4] = b;
							num = 1;
							num2 = num;
							continue;
						case false:
						case true:
							break;
						}
						goto IL_0311;
					}
					case 3:
						if (Settings.Default.pcrqinlin)
						{
							num = 0;
							num2 = num;
							continue;
						}
						this.m_a.c()[0].f()[0][0] = array[0];
						this.m_a.c()[0].f()[0][1] = array[1];
						this.m_a.c()[0].f()[0][2] = array[2];
						this.m_a.c()[0].f()[0][3] = array[3];
						this.m_a.c()[0].f()[0][4] = b;
						goto IL_0311;
					case 4:
						MessageBox.Show(Resources.输入的UID号不合法, Resources.InputError, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					case 1:
					case 5:
						{
							a(Resources.UID已改为 + Form1.hex(array) + Resources._计算得到BCC + Form1.hex(new byte[1] { b }));
							a(0);
							return;
						}
						IL_0311:
						num = 5;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				a(-1);
				array = new byte[4];
				new RNGCryptoServiceProvider().GetNonZeroBytes(array);
				text = Interaction.InputBox(Resources.请输入需要更改的UID卡号_共8位十六进制数_如E44A3B, Resources.请输入UID号, Form1.hex(array)).Trim();
				pattern = "[0-9A-Fa-f]{8}";
				num = 0;
				_ = num;
				num = 2;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private void l(object A_0, EventArgs A_1)
	{
		int num = default(int);
		short num2;
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 2:
					goto IL_003b;
				case 1:
					this.m_b = new g();
					num2 = 3;
					num = num2;
					continue;
				case 0:
				case 3:
					b();
					a(Resources.已重置并新建卡);
					return;
				}
				break;
				IL_003b:
				num2 = 1;
				if (num2 != 0)
				{
				}
				num2 = 0;
				_ = num2;
				if (Settings.Default.pcrqinlin)
				{
					num2 = -30613;
					short num3 = num2;
					num2 = -30613;
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
						num = num2;
						continue;
					}
					goto IL_0027;
				}
				this.m_a = new f();
				num2 = 0;
				num = num2;
			}
			goto case 0;
		case 0:
			{
				a(-1);
				goto IL_0027;
			}
			IL_0027:
			num2 = 2;
			num = num2;
			goto default;
		}
	}

	private void k(object A_0, EventArgs A_1)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			int[] array2 = default(int[]);
			byte[] array = default(byte[]);
			switch (0)
			{
			default:
			{
				string text = default(string);
				int num5 = default(int);
				int num3 = default(int);
				int num4 = default(int);
				while (true)
				{
					switch (num2)
					{
					case 19:
					{
						if (array2[16] == 0)
						{
							num = 2;
							num2 = num;
							continue;
						}
						text = Resources.该文件存在以下错误;
						num5 = 0;
						num = -9834;
						short num6 = num;
						num = -9834;
						switch (num6 == num)
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
							num = 5;
							num2 = num;
							continue;
						case false:
						case true:
							break;
						}
						goto IL_059c;
					}
					case 6:
					case 16:
						num = 20;
						num2 = num;
						continue;
					case 20:
						if (num3 >= 10)
						{
							num = 7;
							num2 = num;
							continue;
						}
						this.m_a.c()[num5].f()[3][num3] = array[num3 - 6];
						num3++;
						num = 16;
						num2 = num;
						continue;
					case 11:
						num = 22;
						num2 = num;
						continue;
					case 22:
						if ((array2[num5] & 4) == 4)
						{
							num = 24;
							num2 = num;
							continue;
						}
						goto case 21;
					case 23:
						this.m_a.c()[num5].f()[0][4] = (byte)(this.m_a.c()[num5].f()[0][0] ^ this.m_a.c()[num5].f()[0][1] ^ this.m_a.c()[num5].f()[0][2] ^ this.m_a.c()[num5].f()[0][3]);
						x.Text = Form1.hex(this.m_a.c()[num5].f()[0]);
						text += Resources.该扇区UID校验值错误_已自动更正;
						num = 9;
						num2 = num;
						continue;
					case 0:
						text += Resources.该扇区一切正常;
						num = 3;
						num2 = num;
						continue;
					case 3:
						num5++;
						num = 8;
						num2 = num;
						continue;
					case 18:
						text += Resources.该扇区访问控制位无效_写入将会损坏卡片_已重新设置;
						num = 11;
						num2 = num;
						continue;
					case 9:
						num = 17;
						num2 = num;
						continue;
					case 17:
						if ((array2[num5] & 2) == 2)
						{
							num = 4;
							num2 = num;
							continue;
						}
						goto case 11;
					case 21:
						num = 10;
						num2 = num;
						continue;
					case 10:
						num = 0;
						_ = num;
						if (array2[num5] == 0)
						{
							num = 0;
							num2 = num;
							continue;
						}
						goto case 3;
					case 5:
					case 8:
						num = 14;
						num2 = num;
						continue;
					case 14:
						if (num5 >= 16)
						{
							num = 12;
							num2 = num;
						}
						else
						{
							text = text + Resources.扇区 + num5 + "：\n";
							num = 13;
							num2 = num;
						}
						continue;
					case 2:
						MessageBox.Show(Resources.该文件一切正常);
						return;
					case 13:
						if ((array2[num5] & 1) == 1)
						{
							num = 23;
							num2 = num;
							continue;
						}
						goto case 9;
					case 4:
						num4 = 6;
						num = 1;
						num2 = num;
						continue;
					case 1:
					case 15:
						num = 25;
						num2 = num;
						continue;
					case 25:
						if (num4 < 10)
						{
							this.m_a.c()[num5].f()[3][num4] = array[num4 - 6];
							num4++;
							num = 15;
							num2 = num;
						}
						else
						{
							num = 18;
							num2 = num;
						}
						continue;
					case 7:
						text += Resources.该扇区访问控制位损坏_写入将会损坏卡片_已重新设置;
						goto IL_059c;
					case 24:
						num3 = 6;
						num = 6;
						num2 = num;
						continue;
					case 12:
						{
							ar.Clear();
							ar.Text = text;
							return;
						}
						IL_059c:
						num = 21;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				array = new byte[4] { 255, 7, 128, 105 };
				array2 = this.m_a.e();
				num = 19;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private void j(object A_0, EventArgs A_1)
	{
		int num = default(int);
		SaveFileDialog saveFileDialog = default(SaveFileDialog);
		switch (0)
		{
		default:
		{
			string fileName = default(string);
			while (true)
			{
				switch (num)
				{
				case 2:
				{
					if (saveFileDialog.ShowDialog() != DialogResult.OK)
					{
						return;
					}
					short num2 = 22296;
					short num3 = num2;
					num2 = 22296;
					switch (num3 == num2)
					{
					default:
						num2 = 0;
						_ = num2;
						goto case true;
					case true:
						num2 = 1;
						if (num2 != 0)
						{
						}
						num2 = 0;
						if (num2 != 0)
						{
						}
						num2 = 1;
						num = num2;
						continue;
					case false:
					case true:
						break;
					}
					goto case 3;
				}
				case 0:
					try
					{
						this.m_a.e(fileName);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, Resources.写入出错, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					a(Resources.已导出MCT文件 + fileName + "。");
					return;
				case 3:
				{
					short num2 = 0;
					num = num2;
					continue;
				}
				case 1:
				{
					fileName = saveFileDialog.FileName;
					short num2 = 3;
					num = num2;
					continue;
				}
				}
				break;
			}
			goto case 0;
		}
		case 0:
		{
			saveFileDialog = new SaveFileDialog();
			saveFileDialog.AddExtension = true;
			saveFileDialog.DefaultExt = ".txt";
			saveFileDialog.Title = Resources.请选择MCT_txt文件保存位置及文件名;
			saveFileDialog.OverwritePrompt = true;
			saveFileDialog.Filter = Resources.txt文件_txt;
			short num2 = 2;
			num = num2;
			goto default;
		}
		}
	}

	private void i(object A_0, EventArgs A_1)
	{
		int num = default(int);
		SaveFileDialog saveFileDialog = default(SaveFileDialog);
		short num2;
		switch (0)
		{
		default:
		{
			string fileName = default(string);
			while (true)
			{
				switch (num)
				{
				case 1:
					goto IL_00da;
				case 0:
					fileName = saveFileDialog.FileName;
					num2 = 2;
					num = num2;
					continue;
				case 2:
					File.WriteAllLines(fileName, this.m_a.g().ToArray());
					a(Resources.已导出密钥字典文件 + fileName + "。");
					return;
				}
				break;
			}
			goto case 0;
		}
		case 0:
			{
				saveFileDialog = new SaveFileDialog();
				saveFileDialog.AddExtension = true;
				saveFileDialog.DefaultExt = ".dic";
				saveFileDialog.Title = Resources.请选择密钥字典文件保存位置及文件名;
				saveFileDialog.OverwritePrompt = true;
				saveFileDialog.Filter = Resources.字典文件_dic;
				num2 = 10107;
				short num3 = num2;
				num2 = 10107;
				switch (num3 == num2)
				{
				default:
					num2 = 0;
					_ = num2;
					goto case true;
				case true:
					num2 = 0;
					if (num2 == 0)
					{
					}
					goto IL_00c3;
				case false:
				case true:
					break;
				}
				goto IL_00da;
			}
			IL_00da:
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				num2 = 1;
				if (num2 != 0)
				{
				}
				num2 = 0;
				num = num2;
				goto default;
			}
			break;
			IL_00c3:
			num2 = 1;
			num = num2;
			goto default;
		}
	}

	private void h(object A_0, EventArgs A_1)
	{
		int num = default(int);
		OpenFileDialog openFileDialog = default(OpenFileDialog);
		switch (0)
		{
		default:
		{
			string text = default(string);
			while (true)
			{
				switch (num)
				{
				case 3:
				{
					if (openFileDialog.ShowDialog() != DialogResult.OK)
					{
						return;
					}
					short num2 = 11253;
					short num3 = num2;
					num2 = 11253;
					switch (num3 == num2)
					{
					default:
						num2 = 0;
						if (num2 != 0)
						{
						}
						num2 = 0;
						_ = num2;
						num2 = 0;
						num = num2;
						continue;
					case false:
					case true:
						break;
					}
					goto case 1;
				}
				case 1:
				{
					this.m_a = new f();
					short num2 = 2;
					num = num2;
					continue;
				}
				case 0:
				{
					this.m_c = openFileDialog.FileName;
					short num2 = 1;
					num = num2;
					continue;
				}
				case 4:
					return;
				case 2:
				{
					short num2;
					try
					{
						switch (0)
						{
						default:
							while (true)
							{
								switch (num)
								{
								case 2:
									if (File.Exists(text))
									{
										num2 = 1;
										num = num2;
										continue;
									}
									goto IL_0230;
								case 1:
									File.SetAttributes(text, FileAttributes.Normal);
									File.Delete(text);
									num2 = 0;
									num = num2;
									continue;
								case 0:
									num2 = 1;
									if (num2 == 0)
									{
									}
									goto IL_0230;
								case 3:
									goto end_IL_0190;
									IL_0230:
									this.m_a.c(this.m_c);
									this.m_a.d(text);
									this.m_c = text;
									num2 = 3;
									num = num2;
									continue;
								}
								goto case 0;
								continue;
								end_IL_0190:
								break;
							}
							break;
						case 0:
							text = "./nfc-data/tmp/mcttxtedit.tmp";
							num2 = 2;
							num = num2;
							goto default;
						}
					}
					catch (IOException ex)
					{
						MessageBox.Show(ex.Message, Resources.打开出错, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						this.m_a = new f();
						return;
					}
					b();
					a(Resources.打开了 + openFileDialog.FileName);
					num2 = 4;
					num = num2;
					continue;
				}
				}
				break;
			}
			goto case 0;
		}
		case 0:
		{
			a(-1);
			openFileDialog = new OpenFileDialog();
			openFileDialog.CheckFileExists = true;
			openFileDialog.Filter = Resources.MCT格式;
			openFileDialog.Title = Resources.请选择需要打开的MCT格式文件;
			openFileDialog.Multiselect = false;
			short num2 = 3;
			num = num2;
			goto default;
		}
		}
	}

	private void g(object A_0, EventArgs A_1)
	{
		int num = default(int);
		int num2 = default(int);
		StringBuilder stringBuilder = default(StringBuilder);
		switch (0)
		{
		default:
			while (true)
			{
				short num3;
				switch (num)
				{
				case 2:
				{
					num3 = 31199;
					short num4 = num3;
					num3 = 31199;
					switch (num4 == num3)
					{
					case false:
					case true:
						goto IL_00f4;
					}
					num3 = 0;
					if (num3 != 0)
					{
					}
					num3 = 0;
					_ = num3;
					num3 = 1;
					if (num3 == 0)
					{
					}
					goto case 3;
				}
				case 3:
					num3 = 1;
					num = num3;
					continue;
				case 1:
					if (num2 < 16)
					{
						stringBuilder.AppendLine(Resources._扇区 + num2);
						stringBuilder.AppendLine("[A] " + global::b.e(this.m_a.c()[num2].j()));
						stringBuilder.AppendLine("[B] " + global::b.e(this.m_a.c()[num2].k()));
						num2++;
						num3 = 3;
						num = num3;
						continue;
					}
					goto IL_00f4;
				case 0:
					{
						ar.Clear();
						ar.Text = stringBuilder.ToString();
						return;
					}
					IL_00f4:
					num3 = 0;
					num = num3;
					continue;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			stringBuilder = new StringBuilder();
			num2 = 0;
			short num3 = 2;
			num = num3;
			goto default;
		}
		}
	}

	private void f(object A_0, EventArgs A_1)
	{
		short num = -30347;
		short num2 = num;
		num = -30347;
		switch (num2 == num)
		{
		default:
			num = 0;
			_ = num;
			break;
		case true:
			break;
		}
		num = 0;
		if (num != 0)
		{
		}
		num = 1;
		if (num == 0)
		{
		}
	}

	private void e(object A_0, EventArgs A_1)
	{
		short num = 2456;
		short num2 = num;
		num = 2456;
		switch (num2 == num)
		{
		default:
			num = 0;
			_ = num;
			break;
		case true:
			break;
		}
		num = 1;
		if (num != 0)
		{
		}
		num = 0;
		if (num == 0)
		{
		}
	}

	private void d(object A_0, EventArgs A_1)
	{
		short num = -2908;
		short num2 = num;
		num = -2908;
		switch (num2 == num)
		{
		default:
			num = 0;
			_ = num;
			break;
		case true:
			break;
		}
		num = 1;
		if (num != 0)
		{
		}
		num = 0;
		if (num == 0)
		{
		}
	}

	private void c(object A_0, EventArgs A_1)
	{
		OpenFileDialog openFileDialog = default(OpenFileDialog);
		int num = default(int);
		switch (0)
		{
		default:
		{
			string text2 = default(string);
			string text = default(string);
			while (true)
			{
				short num2;
				switch (num)
				{
				case 5:
					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						num2 = 7;
						num = num2;
						continue;
					}
					return;
				case 0:
					try
					{
						num2 = 5;
						num = num2;
						while (true)
						{
							switch (num)
							{
							case 5:
								switch (0)
								{
								default:
									continue;
								case 0:
									break;
								}
								goto default;
							default:
								if (new FileInfo(this.m_c).Length > 2100)
								{
									num2 = 7;
									num = num2;
									continue;
								}
								this.m_a.a(this.m_c);
								this.m_d = true;
								num2 = 4;
								num = num2;
								continue;
							case 2:
								File.SetAttributes(text2, FileAttributes.Normal);
								File.Delete(text2);
								num2 = 0;
								num = num2;
								continue;
							case 7:
								text2 = "./nfc-data/tmp/mcttxtedit.tmp";
								num2 = 1;
								num = num2;
								continue;
							case 1:
								if (File.Exists(text2))
								{
									num2 = 2;
									num = num2;
									continue;
								}
								goto case 0;
							case 0:
								this.m_a.c(this.m_c);
								this.m_a.d(text2);
								this.m_c = text2;
								this.m_d = false;
								num2 = 6;
								num = num2;
								continue;
							case 4:
							case 6:
								num2 = 3;
								num = num2;
								continue;
							case 3:
								break;
							}
							break;
						}
					}
					catch (IOException ex2)
					{
						MessageBox.Show(ex2.Message, Resources.打开出错, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						this.m_a = new f();
						return;
					}
					goto IL_0280;
				case 7:
					this.m_c = openFileDialog.FileName;
					num2 = 4;
					num = num2;
					continue;
				case 1:
					return;
				case 3:
					this.m_b = new g();
					num2 = 1;
					if (num2 != 0)
					{
					}
					num2 = 2;
					num = num2;
					continue;
				case 4:
					File.SetAttributes(this.m_c, FileAttributes.Normal);
					num2 = 0;
					_ = num2;
					num2 = 6;
					num = num2;
					continue;
				case 6:
					if (!Settings.Default.pcrqinlin)
					{
						this.m_a = new f();
						num2 = 0;
						num = num2;
					}
					else
					{
						num2 = 3;
						num = num2;
					}
					continue;
				case 2:
					{
						try
						{
							num2 = 5;
							num = num2;
							while (true)
							{
								switch (num)
								{
								case 5:
									switch (0)
									{
									default:
										continue;
									case 0:
										break;
									}
									goto default;
								default:
									if (new FileInfo(this.m_c).Length > 2100)
									{
										num2 = 7;
										num = num2;
										continue;
									}
									this.m_b.a(this.m_c);
									this.m_d = true;
									num2 = 2;
									num = num2;
									continue;
								case 7:
									text = "./nfc-data/tmp/mcttxtedit.tmp";
									goto IL_03fc;
								case 4:
									if (File.Exists(text))
									{
										num2 = 0;
										num = num2;
										continue;
									}
									goto IL_04dc;
								case 0:
									File.SetAttributes(text, FileAttributes.Normal);
									File.Delete(text);
									num2 = 1;
									num = num2;
									continue;
								case 1:
								{
									num2 = -3390;
									short num3 = num2;
									num2 = -3390;
									switch (num3 == num2)
									{
									case false:
									case true:
										break;
									default:
										goto IL_0491;
									}
									goto IL_03fc;
								}
								case 2:
								case 6:
									num2 = 3;
									num = num2;
									continue;
								case 3:
									break;
									IL_0491:
									num2 = 0;
									if (num2 == 0)
									{
									}
									goto IL_04dc;
									IL_04dc:
									this.m_b.c(this.m_c);
									this.m_b.d(text);
									this.m_c = text;
									this.m_d = true;
									num2 = 6;
									num = num2;
									continue;
									IL_03fc:
									num2 = 4;
									num = num2;
									continue;
								}
								break;
							}
						}
						catch (IOException ex)
						{
							MessageBox.Show(ex.Message, Resources.打开出错, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							this.m_b = new g();
							return;
						}
						goto IL_0280;
					}
					IL_0280:
					b();
					a(Resources.打开了 + openFileDialog.FileName);
					num2 = 1;
					num = num2;
					continue;
				}
				break;
			}
			goto case 0;
		}
		case 0:
		{
			a(-1);
			openFileDialog = new OpenFileDialog();
			openFileDialog.CheckFileExists = true;
			openFileDialog.Filter = Resources.MFD文件_mfd_dump;
			openFileDialog.Title = Resources.请选择需要打开的MFD文件;
			openFileDialog.Multiselect = false;
			short num2 = 5;
			num = num2;
			goto default;
		}
		}
	}

	private void b(object A_0, EventArgs A_1)
	{
		short num = 0;
		switch (num)
		{
		}
		num = 15;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 15:
				switch (0)
				{
				default:
					continue;
				case 0:
					break;
				}
				goto default;
			default:
				if (Settings.Default.pcrqinlin)
				{
					num = 34;
					num2 = num;
				}
				else
				{
					num = 35;
					num2 = num;
				}
				continue;
			case 27:
				num = 13;
				num2 = num;
				continue;
			case 13:
			{
				if (ad.BackColor != Color.Aquamarine)
				{
					num = 31;
					num2 = num;
					continue;
				}
				this.m_a.c()[this.m_e].f()[0] = global::b.a(x.Text.Trim(), 16);
				this.m_a.c()[this.m_e].f()[1] = global::b.a(aa.Text.Trim(), 16);
				this.m_a.c()[this.m_e].f()[2] = global::b.a(af.Text.Trim(), 16);
				byte[] collection4 = global::b.a(ae.Text.Trim(), 6);
				byte[] collection5 = global::b.a(ad.Text.Trim(), 6);
				byte[] collection6 = global::b.a(new byte[4]
				{
					(byte)al.SelectedIndex,
					(byte)ak.SelectedIndex,
					(byte)aj.SelectedIndex,
					(byte)ai.SelectedIndex
				});
				List<byte> list2 = new List<byte>(collection4);
				list2.AddRange(collection6);
				list2.AddRange(collection5);
				byte[] array2 = list2.Take(16).ToArray();
				byte b2 = this.m_a.c()[this.m_e].f()[3][9];
				this.m_a.c()[this.m_e].f()[3] = array2;
				this.m_a.c()[this.m_e].f()[3][9] = b2;
				this.b();
				a(Resources.已更新扇区 + this.m_e);
				num = 0;
				_ = num;
				num = 9;
				num2 = num;
				continue;
			}
			case 32:
				ValidateChildren();
				num = 22;
				num2 = num;
				continue;
			case 22:
				if (!(x.BackColor != Color.Aquamarine))
				{
					num = 29;
					num2 = num;
					continue;
				}
				goto case 31;
			case 7:
				num = 30;
				num2 = num;
				continue;
			case 30:
				if (!(ae.BackColor != Color.Aquamarine))
				{
					num = 36;
					num2 = num;
					continue;
				}
				goto case 21;
			case 9:
				num = 20;
				num2 = num;
				continue;
			case 10:
				ValidateChildren();
				num = 5;
				num2 = num;
				continue;
			case 5:
				if (!(x.BackColor != Color.Aquamarine))
				{
					num = 14;
					num2 = num;
					continue;
				}
				goto case 21;
			case 12:
				num = 1;
				num2 = num;
				continue;
			case 1:
				if (!(ae.BackColor != Color.Aquamarine))
				{
					num = 27;
					num2 = num;
					continue;
				}
				goto case 31;
			case 3:
				if (this.m_f != null)
				{
					num = 6;
					num2 = num;
					continue;
				}
				break;
			case 24:
				num = 18;
				num2 = num;
				continue;
			case 18:
				if (this.m_e <= 15)
				{
					num = 32;
					num2 = num;
					continue;
				}
				goto case 9;
			case 36:
				num = 16;
				num2 = num;
				continue;
			case 16:
			{
				if (ad.BackColor != Color.Aquamarine)
				{
					num = 21;
					num2 = num;
					continue;
				}
				this.m_b.c()[this.m_e].f()[0] = global::b.a(x.Text.Trim(), 16);
				this.m_b.c()[this.m_e].f()[1] = global::b.a(aa.Text.Trim(), 16);
				this.m_b.c()[this.m_e].f()[2] = global::b.a(af.Text.Trim(), 16);
				byte[] collection = global::b.a(ae.Text.Trim(), 6);
				byte[] collection2 = global::b.a(ad.Text.Trim(), 6);
				byte[] collection3 = global::b.a(new byte[4]
				{
					(byte)al.SelectedIndex,
					(byte)ak.SelectedIndex,
					(byte)aj.SelectedIndex,
					(byte)ai.SelectedIndex
				});
				List<byte> list = new List<byte>(collection);
				list.AddRange(collection3);
				list.AddRange(collection2);
				byte[] array = list.Take(16).ToArray();
				byte b = this.m_b.c()[this.m_e].f()[3][9];
				this.m_b.c()[this.m_e].f()[3] = array;
				this.m_b.c()[this.m_e].f()[3][9] = b;
				this.b();
				a(Resources.已更新扇区 + this.m_e);
				num = 19;
				num2 = num;
				continue;
			}
			case 20:
				try
				{
					num = 2;
					num2 = num;
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
							if (this.m_d)
							{
								num = 4;
								num2 = num;
							}
							else
							{
								this.m_a.e(this.m_c);
								num = 3;
								num2 = num;
							}
							continue;
						case 4:
							this.m_a.d(this.m_c);
							num = 0;
							num2 = num;
							continue;
						case 0:
						case 3:
							num = 1;
							num2 = num;
							continue;
						case 1:
							break;
						}
						break;
					}
				}
				catch (Exception ex2)
				{
					MessageBox.Show(ex2.Message, Resources.写入出错, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				goto IL_02c3;
			case 6:
				this.m_f("Datasaved");
				num = 28;
				num2 = num;
				continue;
			case 19:
				num = 33;
				num2 = num;
				continue;
			case 34:
				num = 17;
				num2 = num;
				continue;
			case 17:
				if (this.m_e >= 0)
				{
					num = 2;
					num2 = num;
					continue;
				}
				goto case 19;
			case 26:
				num = 11;
				num2 = num;
				continue;
			case 11:
				if (!(af.BackColor != Color.Aquamarine))
				{
					num = 7;
					num2 = num;
					continue;
				}
				goto case 21;
			case 14:
				num = 0;
				num2 = num;
				continue;
			case 0:
				if (!(aa.BackColor != Color.Aquamarine))
				{
					num = 26;
					num2 = num;
					continue;
				}
				goto case 21;
			case 31:
				MessageBox.Show(Resources.当前扇区数据仍有错误_不能执行修改);
				return;
			case 33:
				try
				{
					num = 2;
					num2 = num;
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
						{
							if (this.m_d)
							{
								num = 4;
								num2 = num;
								continue;
							}
							this.m_b.e(this.m_c);
							num = 23706;
							short num3 = num;
							num = 23706;
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
								num = 3;
								num2 = num;
								continue;
							}
							goto case 4;
						}
						case 4:
							this.m_b.d(this.m_c);
							num = 0;
							num2 = num;
							continue;
						case 0:
							num = 1;
							if (num == 0)
							{
							}
							break;
						case 3:
							break;
						case 1:
							goto end_IL_09af;
						}
						num = 1;
						num2 = num;
						continue;
						end_IL_09af:
						break;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, Resources.写入出错, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				goto IL_02c3;
			case 29:
				num = 8;
				num2 = num;
				continue;
			case 8:
				if (!(aa.BackColor != Color.Aquamarine))
				{
					num = 23;
					num2 = num;
					continue;
				}
				goto case 31;
			case 21:
				MessageBox.Show(Resources.当前扇区数据仍有错误_不能执行修改);
				return;
			case 2:
				num = 25;
				num2 = num;
				continue;
			case 25:
				if (this.m_e <= 16)
				{
					num = 10;
					num2 = num;
					continue;
				}
				goto case 19;
			case 35:
				if (this.m_e >= 0)
				{
					num = 24;
					num2 = num;
					continue;
				}
				goto case 9;
			case 23:
				num = 4;
				num2 = num;
				continue;
			case 4:
				if (!(af.BackColor != Color.Aquamarine))
				{
					num = 12;
					num2 = num;
					continue;
				}
				goto case 31;
			case 28:
				break;
				IL_02c3:
				num = 3;
				num2 = num;
				continue;
			}
			break;
		}
		a(Resources.已保存到 + this.m_c + Resources.res);
	}

	private void a(object A_0, EventArgs A_1)
	{
		short num = -18342;
		short num2 = num;
		num = -18342;
		switch (num2 == num)
		{
		}
		num = 0;
		_ = num;
		num = 1;
		if (num != 0)
		{
		}
		num = 0;
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
				if (disposing)
				{
					num = 4;
					num2 = num;
					continue;
				}
				break;
			case 1:
				num = 1;
				if (num != 0)
				{
				}
				this.m_g.Dispose();
				num = 0;
				num2 = num;
				continue;
			case 4:
				num = 3;
				num2 = num;
				continue;
			case 3:
			{
				num = 6468;
				short num3 = num;
				num = 6468;
				switch (num3 == num)
				{
				case false:
				case true:
					break;
				default:
					goto IL_00f5;
				}
				goto case 4;
			}
			case 0:
				break;
				IL_00f5:
				num = 0;
				if (num != 0)
				{
				}
				num = 0;
				_ = num;
				if (this.m_g != null)
				{
					num = 1;
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
		short num = 23503;
		short num2 = num;
		num = 23503;
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
		this.m_g = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormHTool));
		this.m_h = new MenuStrip();
		this.m_i = new ToolStripMenuItem();
		@as = new ToolStripMenuItem();
		this.m_j = new ToolStripMenuItem();
		this.m_k = new ToolStripMenuItem();
		this.m_l = new ToolStripMenuItem();
		this.m_m = new ToolStripSeparator();
		this.m_n = new ToolStripMenuItem();
		this.m_o = new ToolStripMenuItem();
		this.m_p = new ToolStripMenuItem();
		au = new ToolStripSeparator();
		this.m_q = new ToolStripMenuItem();
		at = new ToolStripMenuItem();
		av = new ToolStripSeparator();
		ay = new ToolStripMenuItem();
		aw = new ToolStripMenuItem();
		ax = new ToolStripMenuItem();
		az = new ToolStripSeparator();
		a0 = new ToolStripMenuItem();
		this.m_r = new GroupBox();
		this.m_s = new DataGridView();
		t = new DataGridViewTextBoxColumn();
		v = new GroupBox();
		a1 = new TableLayoutPanel();
		a2 = new FlowLayoutPanel();
		ap = new Label();
		al = new ComboBox();
		ao = new Label();
		ak = new ComboBox();
		an = new Label();
		aj = new ComboBox();
		am = new Label();
		ai = new ComboBox();
		a3 = new TableLayoutPanel();
		ag = new Label();
		ae = new TextBox();
		ac = new Label();
		ad = new TextBox();
		a4 = new FlowLayoutPanel();
		w = new Label();
		ah = new Button();
		a5 = new FlowLayoutPanel();
		y = new Label();
		x = new TextBox();
		ab = new Label();
		aa = new TextBox();
		z = new Label();
		af = new TextBox();
		aq = new GroupBox();
		ar = new RichTextBox();
		a6 = new TableLayoutPanel();
		a7 = new Button();
		a8 = new Button();
		u = new BindingSource(this.m_g);
		this.m_h.SuspendLayout();
		this.m_r.SuspendLayout();
		((ISupportInitialize)this.m_s).BeginInit();
		v.SuspendLayout();
		a1.SuspendLayout();
		a2.SuspendLayout();
		a3.SuspendLayout();
		a4.SuspendLayout();
		a5.SuspendLayout();
		aq.SuspendLayout();
		((ISupportInitialize)u).BeginInit();
		SuspendLayout();
		this.m_h.ImageScalingSize = new Size(24, 24);
		this.m_h.Items.AddRange(new ToolStripItem[2] { this.m_i, this.m_o });
		componentResourceManager.ApplyResources(this.m_h, "menuStrip1");
		this.m_h.Name = "menuStrip1";
		this.m_i.DropDownItems.AddRange(new ToolStripItem[6] { @as, this.m_j, this.m_k, this.m_l, this.m_m, this.m_n });
		this.m_i.Name = "文件ToolStripMenuItem";
		componentResourceManager.ApplyResources(this.m_i, "文件ToolStripMenuItem");
		this.m_i.Click += a;
		@as.Name = "新建ToolStripMenuItem";
		componentResourceManager.ApplyResources(@as, "新建ToolStripMenuItem");
		@as.Click += l;
		this.m_j.Name = "打开ToolStripMenuItem";
		componentResourceManager.ApplyResources(this.m_j, "打开ToolStripMenuItem");
		this.m_j.Click += s;
		this.m_k.Name = "保存ToolStripMenuItem";
		componentResourceManager.ApplyResources(this.m_k, "保存ToolStripMenuItem");
		this.m_k.Click += q;
		this.m_l.Name = "另存为ToolStripMenuItem";
		componentResourceManager.ApplyResources(this.m_l, "另存为ToolStripMenuItem");
		this.m_l.Click += p;
		this.m_m.Name = "toolStripSeparator1";
		componentResourceManager.ApplyResources(this.m_m, "toolStripSeparator1");
		this.m_n.Name = "退出ToolStripMenuItem";
		componentResourceManager.ApplyResources(this.m_n, "退出ToolStripMenuItem");
		this.m_n.Click += r;
		this.m_o.DropDownItems.AddRange(new ToolStripItem[10] { this.m_p, au, this.m_q, at, av, ay, aw, ax, az, a0 });
		this.m_o.Name = "工具ToolStripMenuItem";
		componentResourceManager.ApplyResources(this.m_o, "工具ToolStripMenuItem");
		this.m_p.Name = "修改UIDToolStripMenuItem";
		componentResourceManager.ApplyResources(this.m_p, "修改UIDToolStripMenuItem");
		this.m_p.Click += m;
		au.Name = "toolStripSeparator2";
		componentResourceManager.ApplyResources(au, "toolStripSeparator2");
		this.m_q.Name = "检查全卡ToolStripMenuItem";
		componentResourceManager.ApplyResources(this.m_q, "检查全卡ToolStripMenuItem");
		this.m_q.Click += n;
		at.Name = "检查并纠正全卡ToolStripMenuItem";
		componentResourceManager.ApplyResources(at, "检查并纠正全卡ToolStripMenuItem");
		at.Click += k;
		av.Name = "toolStripSeparator3";
		componentResourceManager.ApplyResources(av, "toolStripSeparator3");
		ay.Name = "导入MCT格式ToolStripMenuItem";
		componentResourceManager.ApplyResources(ay, "导入MCT格式ToolStripMenuItem");
		ay.Click += h;
		aw.Name = "导出为MCT格式ToolStripMenuItem";
		componentResourceManager.ApplyResources(aw, "导出为MCT格式ToolStripMenuItem");
		aw.Click += j;
		ax.Name = "导出密钥字典ToolStripMenuItem";
		componentResourceManager.ApplyResources(ax, "导出密钥字典ToolStripMenuItem");
		ax.Click += i;
		az.Name = "toolStripSeparator4";
		componentResourceManager.ApplyResources(az, "toolStripSeparator4");
		a0.Name = "列出全卡密钥ToolStripMenuItem";
		componentResourceManager.ApplyResources(a0, "列出全卡密钥ToolStripMenuItem");
		a0.Click += g;
		this.m_r.Controls.Add(this.m_s);
		componentResourceManager.ApplyResources(this.m_r, "groupBox1");
		this.m_r.Name = "groupBox1";
		this.m_r.TabStop = false;
		this.m_s.AllowUserToAddRows = false;
		this.m_s.AllowUserToDeleteRows = false;
		this.m_s.AllowUserToResizeColumns = false;
		this.m_s.AllowUserToResizeRows = false;
		this.m_s.BorderStyle = BorderStyle.Fixed3D;
		this.m_s.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.m_s.Columns.AddRange(t);
		componentResourceManager.ApplyResources(this.m_s, "dataGridView1");
		this.m_s.EditMode = DataGridViewEditMode.EditProgrammatically;
		this.m_s.MultiSelect = false;
		this.m_s.Name = "dataGridView1";
		this.m_s.ReadOnly = true;
		this.m_s.RowHeadersVisible = false;
		this.m_s.RowTemplate.Height = 27;
		this.m_s.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.m_s.CellClick += a;
		t.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		componentResourceManager.ApplyResources(t, "Column1");
		t.Name = "Column1";
		t.ReadOnly = true;
		t.SortMode = DataGridViewColumnSortMode.NotSortable;
		componentResourceManager.ApplyResources(v, "groupBox2");
		v.Controls.Add(a1);
		v.Name = "groupBox2";
		v.TabStop = false;
		v.Enter += d;
		componentResourceManager.ApplyResources(a1, "tableLayoutPanel2");
		a1.Controls.Add(a2, 0, 3);
		a1.Controls.Add(a3, 0, 2);
		a1.Controls.Add(a4, 0, 0);
		a1.Controls.Add(a5, 0, 1);
		a1.Name = "tableLayoutPanel2";
		componentResourceManager.ApplyResources(a2, "flowLayoutPanel3");
		a2.Controls.Add(ap);
		a2.Controls.Add(al);
		a2.Controls.Add(ao);
		a2.Controls.Add(ak);
		a2.Controls.Add(an);
		a2.Controls.Add(aj);
		a2.Controls.Add(am);
		a2.Controls.Add(ai);
		a2.Name = "flowLayoutPanel3";
		componentResourceManager.ApplyResources(ap, "label6");
		ap.Name = "label6";
		al.DropDownStyle = ComboBoxStyle.DropDownList;
		al.FormattingEnabled = true;
		al.Items.AddRange(new object[8]
		{
			componentResourceManager.GetString("comboBox1.Items"),
			componentResourceManager.GetString("comboBox1.Items1"),
			componentResourceManager.GetString("comboBox1.Items2"),
			componentResourceManager.GetString("comboBox1.Items3"),
			componentResourceManager.GetString("comboBox1.Items4"),
			componentResourceManager.GetString("comboBox1.Items5"),
			componentResourceManager.GetString("comboBox1.Items6"),
			componentResourceManager.GetString("comboBox1.Items7")
		});
		componentResourceManager.ApplyResources(al, "comboBox1");
		al.Name = "comboBox1";
		al.Validating += a;
		componentResourceManager.ApplyResources(ao, "label7");
		ao.Name = "label7";
		ak.DropDownStyle = ComboBoxStyle.DropDownList;
		ak.FormattingEnabled = true;
		ak.Items.AddRange(new object[8]
		{
			componentResourceManager.GetString("comboBox2.Items"),
			componentResourceManager.GetString("comboBox2.Items1"),
			componentResourceManager.GetString("comboBox2.Items2"),
			componentResourceManager.GetString("comboBox2.Items3"),
			componentResourceManager.GetString("comboBox2.Items4"),
			componentResourceManager.GetString("comboBox2.Items5"),
			componentResourceManager.GetString("comboBox2.Items6"),
			componentResourceManager.GetString("comboBox2.Items7")
		});
		componentResourceManager.ApplyResources(ak, "comboBox2");
		ak.Name = "comboBox2";
		ak.Validating += a;
		componentResourceManager.ApplyResources(an, "label8");
		an.Name = "label8";
		aj.DropDownStyle = ComboBoxStyle.DropDownList;
		aj.FormattingEnabled = true;
		aj.Items.AddRange(new object[8]
		{
			componentResourceManager.GetString("comboBox3.Items"),
			componentResourceManager.GetString("comboBox3.Items1"),
			componentResourceManager.GetString("comboBox3.Items2"),
			componentResourceManager.GetString("comboBox3.Items3"),
			componentResourceManager.GetString("comboBox3.Items4"),
			componentResourceManager.GetString("comboBox3.Items5"),
			componentResourceManager.GetString("comboBox3.Items6"),
			componentResourceManager.GetString("comboBox3.Items7")
		});
		componentResourceManager.ApplyResources(aj, "comboBox3");
		aj.Name = "comboBox3";
		aj.Validating += a;
		componentResourceManager.ApplyResources(am, "label9");
		am.Name = "label9";
		ai.DropDownStyle = ComboBoxStyle.DropDownList;
		ai.DropDownWidth = 400;
		ai.FormattingEnabled = true;
		ai.Items.AddRange(new object[8]
		{
			componentResourceManager.GetString("comboBox4.Items"),
			componentResourceManager.GetString("comboBox4.Items1"),
			componentResourceManager.GetString("comboBox4.Items2"),
			componentResourceManager.GetString("comboBox4.Items3"),
			componentResourceManager.GetString("comboBox4.Items4"),
			componentResourceManager.GetString("comboBox4.Items5"),
			componentResourceManager.GetString("comboBox4.Items6"),
			componentResourceManager.GetString("comboBox4.Items7")
		});
		componentResourceManager.ApplyResources(ai, "comboBox4");
		ai.Name = "comboBox4";
		ai.Validating += a;
		componentResourceManager.ApplyResources(a3, "tableLayoutPanel3");
		a3.Controls.Add(ag, 0, 0);
		a3.Controls.Add(ae, 0, 1);
		a3.Controls.Add(ac, 1, 0);
		a3.Controls.Add(ad, 1, 1);
		a3.Name = "tableLayoutPanel3";
		componentResourceManager.ApplyResources(ag, "label4");
		ag.Name = "label4";
		componentResourceManager.ApplyResources(ae, "keyAEdit");
		ae.Name = "keyAEdit";
		ae.TextChanged += e;
		ae.Validating += b;
		componentResourceManager.ApplyResources(ac, "label5");
		ac.Name = "label5";
		componentResourceManager.ApplyResources(ad, "keyBEdit");
		ad.Name = "keyBEdit";
		ad.Validating += b;
		componentResourceManager.ApplyResources(a4, "flowLayoutPanel1");
		a4.Controls.Add(w);
		a4.Controls.Add(ah);
		a4.Name = "flowLayoutPanel1";
		componentResourceManager.ApplyResources(w, "labelCurSec");
		w.Name = "labelCurSec";
		componentResourceManager.ApplyResources(ah, "buttonSaveSectorEdit");
		ah.Name = "buttonSaveSectorEdit";
		ah.UseVisualStyleBackColor = true;
		ah.Click += o;
		componentResourceManager.ApplyResources(a5, "flowLayoutPanel2");
		a5.Controls.Add(y);
		a5.Controls.Add(x);
		a5.Controls.Add(ab);
		a5.Controls.Add(aa);
		a5.Controls.Add(z);
		a5.Controls.Add(af);
		a5.Name = "flowLayoutPanel2";
		componentResourceManager.ApplyResources(y, "label1");
		y.Name = "label1";
		componentResourceManager.ApplyResources(x, "block0Edit");
		x.Name = "block0Edit";
		x.Validating += c;
		componentResourceManager.ApplyResources(ab, "label2");
		ab.Name = "label2";
		componentResourceManager.ApplyResources(aa, "block1Edit");
		aa.Name = "block1Edit";
		aa.Validating += c;
		componentResourceManager.ApplyResources(z, "label3");
		z.Name = "label3";
		componentResourceManager.ApplyResources(af, "block2Edit");
		af.Name = "block2Edit";
		af.Validating += c;
		componentResourceManager.ApplyResources(aq, "groupBox3");
		aq.Controls.Add(ar);
		aq.Name = "groupBox3";
		aq.TabStop = false;
		ar.BackColor = SystemColors.Window;
		ar.ForeColor = SystemColors.Desktop;
		componentResourceManager.ApplyResources(ar, "richTextBox1");
		ar.Name = "richTextBox1";
		ar.ReadOnly = true;
		componentResourceManager.ApplyResources(a6, "tableLayoutPanel1");
		a6.Name = "tableLayoutPanel1";
		componentResourceManager.ApplyResources(a7, "button4");
		a7.Name = "button4";
		a7.UseVisualStyleBackColor = true;
		a7.Click += c;
		componentResourceManager.ApplyResources(a8, "button1");
		a8.Name = "button1";
		a8.UseVisualStyleBackColor = true;
		a8.Click += b;
		u.DataSource = typeof(f);
		base.AcceptButton = ah;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(a8);
		base.Controls.Add(this.m_r);
		base.Controls.Add(a7);
		base.Controls.Add(aq);
		base.Controls.Add(v);
		base.Controls.Add(a6);
		base.Controls.Add(this.m_h);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MainMenuStrip = this.m_h;
		base.MaximizeBox = false;
		base.Name = "FormHTool";
		base.Load += f;
		this.m_h.ResumeLayout(performLayout: false);
		this.m_h.PerformLayout();
		this.m_r.ResumeLayout(performLayout: false);
		((ISupportInitialize)this.m_s).EndInit();
		v.ResumeLayout(performLayout: false);
		v.PerformLayout();
		a1.ResumeLayout(performLayout: false);
		a1.PerformLayout();
		a2.ResumeLayout(performLayout: false);
		a2.PerformLayout();
		a3.ResumeLayout(performLayout: false);
		a3.PerformLayout();
		a4.ResumeLayout(performLayout: false);
		a4.PerformLayout();
		a5.ResumeLayout(performLayout: false);
		a5.PerformLayout();
		aq.ResumeLayout(performLayout: false);
		((ISupportInitialize)u).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
