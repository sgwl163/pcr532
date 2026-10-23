using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MifareOneTool.Properties;

namespace MifareOneTool;

public class infor : Form
{
	private bool m_a;

	private string m_b;

	private IContainer m_c;

	private TextBox d;

	private Label e;

	private TextBox f;

	private Button g;

	private Label h;

	private Label i;

	private TextBox j;

	private Label k;

	private Button l;

	public infor(string mode)
	{
		a();
		base.StartPosition = FormStartPosition.CenterScreen;
		if (!(mode == "find"))
		{
			if (Settings.Default.pcrpassword == null)
			{
				return;
			}
			byte[] bytes = Encoding.Default.GetBytes("pcrwin");
			byte[] bytes2 = Encoding.Default.GetBytes("findinfo");
			byte[] bytes3 = Encoding.Default.GetBytes(Settings.Default.pcrpassword);
			WebClient webClient = new WebClientto(2000);
			ServicePointManager.ServerCertificateValidationCallback = delegate
			{
				short num = 14868;
				short num2 = num;
				num = 14868;
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
				if (num != 0)
				{
				}
				return true;
			};
			string text = Convert.ToBase64String(bytes);
			string text2 = Convert.ToBase64String(bytes2);
			string text3 = Convert.ToBase64String(bytes3);
			string s = "passA=" + text2 + "&passB=" + text + "&username=" + Settings.Default.pcrname + "&passc=" + text3;
			byte[] bytes4 = Encoding.UTF8.GetBytes(s);
			webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
			webClient.Headers.Add("ContentLength", bytes4.Length.ToString());
			try
			{
				byte[] bytes5 = webClient.UploadData("https://www.rfidfans.com/win/addinfo.php", "POST", bytes4);
				string[] array = Encoding.UTF8.GetString(bytes5).Trim().Split('#');
				if (array[0].Trim() == "sucess")
				{
					j.Text = array[1];
					f.Text = array[2];
					d.Text = array[3];
				}
				return;
			}
			catch (Exception ex)
			{
				Console.Write(ex.Message);
				return;
			}
		}
		Text = "找回用户名和密码";
		k.Text = "手机/密保号找回用户名/密码";
		e.Text = "返回信息：";
		this.m_a = true;
	}

	private void c(object A_0, EventArgs A_1)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 22;
			int num2 = num;
			WebClient webClient2 = default(WebClient);
			byte[] bytes4 = default(byte[]);
			byte[] bytes5 = default(byte[]);
			string text5 = default(string);
			string text6 = default(string);
			string text7 = default(string);
			byte[] bytes7 = default(byte[]);
			WebClient webClient = default(WebClient);
			byte[] bytes2 = default(byte[]);
			string text3 = default(string);
			string text4 = default(string);
			byte[] bytes3 = default(byte[]);
			string[] array = default(string[]);
			string text12 = default(string);
			string text11 = default(string);
			string pattern2 = default(string);
			string pattern = default(string);
			while (true)
			{
				switch (num2)
				{
				case 22:
					switch (0)
					{
					default:
						goto end_IL_003f;
					case 0:
						break;
					}
					goto default;
				default:
					if (this.m_a)
					{
						num = 17;
						num2 = num;
					}
					else
					{
						num = 4;
						num2 = num;
					}
					break;
				case 1:
				{
					byte[] bytes6 = Encoding.Default.GetBytes(Settings.Default.pcrpassword);
					webClient2 = new WebClientto(2000);
					ServicePointManager.ServerCertificateValidationCallback = delegate
					{
						short num4 = 19724;
						short num5 = num4;
						num4 = 19724;
						switch (num5 == num4)
						{
						default:
							num4 = 0;
							_ = num4;
							break;
						case true:
							break;
						}
						num4 = 1;
						if (num4 != 0)
						{
						}
						num4 = 0;
						if (num4 != 0)
						{
						}
						return true;
					};
					string text8 = Convert.ToBase64String(bytes4);
					string text9 = Convert.ToBase64String(bytes5);
					string text10 = Convert.ToBase64String(bytes6);
					string s2 = "passA=" + text9 + "&passB=" + text8 + "&username=" + Settings.Default.pcrname + "&passc=" + text10 + "&telnum=" + text5 + "&qqnum=" + text6 + "&email=" + text7;
					bytes7 = Encoding.UTF8.GetBytes(s2);
					webClient2.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
					webClient2.Headers.Add("ContentLength", bytes7.Length.ToString());
					num = 8;
					num2 = num;
					break;
				}
				case 18:
				{
					byte[] bytes = Encoding.Default.GetBytes("findu");
					webClient = new WebClientto(2000);
					ServicePointManager.ServerCertificateValidationCallback = delegate
					{
						short num4 = -21051;
						short num5 = num4;
						num4 = -21051;
						switch (num5 == num4)
						{
						default:
							num4 = 0;
							_ = num4;
							break;
						case true:
							break;
						}
						num4 = 0;
						if (num4 != 0)
						{
						}
						num4 = 1;
						if (num4 != 0)
						{
						}
						return true;
					};
					string text = Convert.ToBase64String(bytes2);
					string text2 = Convert.ToBase64String(bytes);
					string s = "passA=" + text2 + "&passB=" + text + "&telnum=" + text3 + "&qqnum=" + text4;
					bytes3 = Encoding.UTF8.GetBytes(s);
					webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
					webClient.Headers.Add("ContentLength", bytes3.Length.ToString());
					num = 16;
					num2 = num;
					break;
				}
				case 6:
					MessageBox.Show("输入的电话号码不合规:长度为11，全部为数字", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				case 10:
					num = 20;
					num2 = num;
					break;
				case 20:
					if (j.Text.Length == 11)
					{
						text3 = j.Text.Trim();
						text4 = f.Text.Trim();
						bytes2 = Encoding.Default.GetBytes("pcrwin");
						num = 18;
						num2 = num;
					}
					else
					{
						num = 6;
						num2 = num;
					}
					break;
				case 13:
					num = 0;
					num2 = num;
					break;
				case 0:
					if (!(f.Text == ""))
					{
						num = 5;
						num2 = num;
						break;
					}
					goto case 2;
				case 5:
					num = 1;
					if (num != 0)
					{
					}
					num = 7;
					num2 = num;
					break;
				case 17:
					num = 15;
					num2 = num;
					break;
				case 15:
					if (!(j.Text == ""))
					{
						num = 23;
						num2 = num;
						break;
					}
					goto case 11;
				case 4:
					if (!(j.Text == ""))
					{
						num = 13;
						num2 = num;
						break;
					}
					goto case 2;
				case 16:
					try
					{
						switch (0)
						{
						default:
							while (true)
							{
								switch (num2)
								{
								case 3:
									if (array[0].Trim() == "sucess")
									{
										num = 0;
										num2 = num;
									}
									else
									{
										MessageBox.Show(text12);
										num = 4;
										num2 = num;
									}
									continue;
								case 0:
									d.Text = "你的用户名为：" + array[1];
									l.Visible = true;
									this.m_b = array[1];
									num = 1;
									num2 = num;
									continue;
								case 1:
								case 4:
									num = 2;
									num2 = num;
									continue;
								case 2:
									return;
								}
								break;
							}
							goto case 0;
						case 0:
						{
							byte[] bytes9 = webClient.UploadData("https://www.rfidfans.com/win/addinfo.php", "POST", bytes3);
							text12 = Encoding.UTF8.GetString(bytes9);
							array = text12.Trim().Split('#');
							num = 3;
							num2 = num;
							goto default;
						}
						}
					}
					catch (Exception ex2)
					{
						Console.Write(ex2.Message);
						return;
					}
				case 8:
					try
					{
						switch (0)
						{
						default:
							while (true)
							{
								switch (num2)
								{
								case 3:
									if (text11.Trim() == "success")
									{
										num = 0;
										num2 = num;
									}
									else
									{
										MessageBox.Show(text11);
										num = 1;
										num2 = num;
									}
									continue;
								case 0:
									MessageBox.Show("信息添加成功");
									Close();
									goto IL_05fd;
								case 1:
								{
									num = -16143;
									short num3 = num;
									num = -16143;
									switch (num3 == num)
									{
									case false:
									case true:
										break;
									default:
										goto IL_066e;
									}
									goto IL_05fd;
								}
								case 4:
									num = 2;
									num2 = num;
									continue;
								case 2:
									return;
									IL_066e:
									num = 0;
									if (num == 0)
									{
									}
									goto case 4;
									IL_05fd:
									num = 4;
									num2 = num;
									continue;
								}
								break;
							}
							goto case 0;
						case 0:
						{
							byte[] bytes8 = webClient2.UploadData("https://www.rfidfans.com/win/addinfo.php", "POST", bytes7);
							text11 = Encoding.UTF8.GetString(bytes8);
							num = 3;
							num2 = num;
							goto default;
						}
						}
					}
					catch (Exception ex)
					{
						Console.Write(ex.Message);
						return;
					}
				case 14:
					if (Regex.IsMatch(j.Text, pattern2))
					{
						num = 10;
						num2 = num;
						break;
					}
					goto case 6;
				case 23:
					num = 21;
					num2 = num;
					break;
				case 21:
					if (!(f.Text == ""))
					{
						pattern2 = "[0-9]{11}";
						num = 14;
						num2 = num;
					}
					else
					{
						num = 11;
						num2 = num;
					}
					break;
				case 9:
					MessageBox.Show("输入的电话号码不合规:长度为11，全部为数字", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				case 11:
					MessageBox.Show("电话/密保不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				case 7:
					if (d.Text == "")
					{
						num = 2;
						num2 = num;
						break;
					}
					num = 0;
					_ = num;
					pattern = "[0-9]{11}";
					num = 3;
					num2 = num;
					break;
				case 19:
					num = 12;
					num2 = num;
					break;
				case 12:
					if (j.Text.Length == 11)
					{
						text5 = j.Text.Trim();
						text6 = f.Text.Trim();
						text7 = d.Text.Trim();
						bytes4 = Encoding.Default.GetBytes("pcrwin");
						bytes5 = Encoding.Default.GetBytes("addinfo");
						num = 1;
						num2 = num;
					}
					else
					{
						num = 9;
						num2 = num;
					}
					break;
				case 2:
					MessageBox.Show("电话/email/密保不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				case 3:
					{
						if (Regex.IsMatch(j.Text, pattern))
						{
							num = 19;
							num2 = num;
							break;
						}
						goto case 9;
					}
					end_IL_003f:
					break;
				}
			}
		}
		}
	}

	private void b(object A_0, EventArgs A_1)
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
		num = -11373;
		short num2 = num;
		num = -11373;
		switch (num2 == num)
		{
		}
		num = 0;
		if (num == 0)
		{
		}
	}

	private void a(object A_0, EventArgs A_1)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 0;
			_ = num;
			num = 8;
			int num2 = num;
			string pattern = default(string);
			string text3 = default(string);
			string text4 = default(string);
			byte[] bytes2 = default(byte[]);
			byte[] bytes3 = default(byte[]);
			string text5 = default(string);
			WebClient webClient = default(WebClient);
			byte[] bytes4 = default(byte[]);
			while (true)
			{
				switch (num2)
				{
				case 8:
					switch (0)
					{
					default:
						goto end_IL_0069;
					case 0:
						break;
					}
					goto default;
				default:
					if (this.m_b == null)
					{
						num = 6;
						num2 = num;
					}
					else
					{
						num = 3;
						num2 = num;
					}
					break;
				case 7:
					MessageBox.Show("输入的电话号码不合规", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				case 6:
					MessageBox.Show("请先找回用户名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				case 5:
					if (f.Text == "")
					{
						num = 0;
						num2 = num;
					}
					else
					{
						pattern = "[0-9]{11}";
						num = 9;
						num2 = num;
					}
					break;
				case 0:
					MessageBox.Show("电话/密保不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				case 9:
					if (!Regex.IsMatch(j.Text, pattern))
					{
						num = 7;
						num2 = num;
						break;
					}
					text3 = j.Text.Trim();
					text4 = f.Text.Trim();
					d.Text.Trim();
					bytes2 = Encoding.Default.GetBytes("pcrwin");
					bytes3 = Encoding.Default.GetBytes("resetpsw");
					num = 4;
					num2 = num;
					break;
				case 2:
					try
					{
						switch (0)
						{
						default:
							while (true)
							{
								switch (num2)
								{
								case 3:
									if (text5.Trim() == "sucess")
									{
										num = 0;
										num2 = num;
										continue;
									}
									d.Text = text5;
									MessageBox.Show(text5);
									num = 1;
									num2 = num;
									continue;
								case 0:
									MessageBox.Show("密码重置成功,为123abc");
									d.Text = "用户名：" + this.m_b + "密码：123abc";
									goto IL_0241;
								case 1:
								{
									num = -19190;
									short num3 = num;
									num = -19190;
									switch (num3 == num)
									{
									case false:
									case true:
										break;
									default:
										goto IL_02be;
									}
									goto IL_0241;
								}
								case 4:
									num = 2;
									num2 = num;
									continue;
								case 2:
									return;
									IL_02be:
									num = 0;
									if (num == 0)
									{
									}
									goto case 4;
									IL_0241:
									num = 4;
									num2 = num;
									continue;
								}
								break;
							}
							goto case 0;
						case 0:
						{
							byte[] bytes5 = webClient.UploadData("https://www.rfidfans.com/win/addinfo.php", "POST", bytes4);
							text5 = Encoding.UTF8.GetString(bytes5);
							num = 3;
							num2 = num;
							goto default;
						}
						}
					}
					catch (Exception ex)
					{
						Console.Write(ex.Message);
						return;
					}
				case 4:
				{
					byte[] bytes = Encoding.Default.GetBytes(Settings.Default.pcrpassword);
					webClient = new WebClientto(2000);
					ServicePointManager.ServerCertificateValidationCallback = delegate
					{
						short num4 = 1;
						if (num4 != 0)
						{
						}
						num4 = 0;
						_ = num4;
						num4 = -21904;
						short num5 = num4;
						num4 = -21904;
						switch (num5 == num4)
						{
						default:
							num4 = 0;
							if (num4 != 0)
							{
							}
							return true;
						}
					};
					string text = Convert.ToBase64String(bytes2);
					string text2 = Convert.ToBase64String(bytes3);
					Convert.ToBase64String(bytes);
					string s = "passA=" + text2 + "&passB=" + text + "&username=" + this.m_b + "&telnum=" + text3 + "&qqnum=" + text4;
					bytes4 = Encoding.UTF8.GetBytes(s);
					webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
					webClient.Headers.Add("ContentLength", bytes4.Length.ToString());
					num = 2;
					num2 = num;
					break;
				}
				case 3:
					if (!(j.Text == ""))
					{
						num = 1;
						num2 = num;
						break;
					}
					goto case 0;
				case 1:
					{
						num = 1;
						if (num != 0)
						{
						}
						num = 5;
						num2 = num;
						break;
					}
					end_IL_0069:
					break;
				}
			}
		}
		}
	}

	protected override void Dispose(bool disposing)
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = 3;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 3:
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
					num = 0;
					num2 = num;
					continue;
				}
				break;
			case 2:
				this.m_c.Dispose();
				num = 4;
				num2 = num;
				continue;
			case 0:
				num = 1;
				num2 = num;
				continue;
			case 1:
				while (this.m_c != null)
				{
					num = 1102;
					short num3 = num;
					num = 1102;
					switch (num3 == num)
					{
					case false:
					case true:
						continue;
					}
					goto IL_00f6;
				}
				break;
			case 4:
				break;
				IL_00f6:
				num = 0;
				if (num != 0)
				{
				}
				num = 0;
				_ = num;
				num = 2;
				num2 = num;
				continue;
			}
			break;
		}
		base.Dispose(disposing);
	}

	private void a()
	{
		short num = -18692;
		short num2 = num;
		num = -18692;
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
		if (num != 0)
		{
		}
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(infor));
		d = new TextBox();
		e = new Label();
		f = new TextBox();
		g = new Button();
		h = new Label();
		i = new Label();
		j = new TextBox();
		k = new Label();
		l = new Button();
		SuspendLayout();
		d.Location = new Point(87, 125);
		d.Name = "textBox3";
		d.Size = new Size(154, 21);
		d.TabIndex = 22;
		e.AutoSize = true;
		e.Location = new Point(12, 125);
		e.Name = "label4";
		e.Size = new Size(65, 12);
		e.TabIndex = 28;
		e.Text = "电子邮箱：";
		f.Location = new Point(87, 94);
		f.Name = "textBox2";
		f.Size = new Size(154, 21);
		f.TabIndex = 21;
		g.Location = new Point(111, 179);
		g.Name = "button1";
		g.Size = new Size(87, 31);
		g.TabIndex = 24;
		g.Text = "提交";
		g.UseVisualStyleBackColor = true;
		g.Click += c;
		h.AutoSize = true;
		h.Location = new Point(12, 97);
		h.Name = "label3";
		h.Size = new Size(65, 12);
		h.TabIndex = 27;
		h.Text = "密保号码：";
		h.Click += b;
		i.AutoSize = true;
		i.Location = new Point(6, 65);
		i.Name = "label2";
		i.Size = new Size(71, 12);
		i.TabIndex = 26;
		i.Text = " 电话号码：";
		j.Location = new Point(87, 62);
		j.Name = "textBox1";
		j.Size = new Size(154, 21);
		j.TabIndex = 20;
		k.AutoSize = true;
		k.Location = new Point(71, 29);
		k.Name = "label1";
		k.Size = new Size(161, 12);
		k.TabIndex = 29;
		k.Text = "完善信息方便找回账号和密码";
		l.Location = new Point(193, 152);
		l.Name = "button2";
		l.Size = new Size(76, 21);
		l.TabIndex = 30;
		l.Text = "重置密码";
		l.UseVisualStyleBackColor = true;
		l.Visible = false;
		l.Click += a;
		base.AcceptButton = g;
		base.AutoScaleDimensions = new SizeF(6f, 12f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(295, 214);
		base.Controls.Add(l);
		base.Controls.Add(k);
		base.Controls.Add(d);
		base.Controls.Add(e);
		base.Controls.Add(f);
		base.Controls.Add(g);
		base.Controls.Add(h);
		base.Controls.Add(i);
		base.Controls.Add(j);
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "infor";
		Text = "个人信息";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
