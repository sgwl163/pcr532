using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using MifareOneTool.Properties;

namespace MifareOneTool;

public class reg : Form
{
	protected string userid;

	protected string nickname;

	protected string password;

	protected string username;

	protected string cellphonenum;

	protected string mibaonum;

	[CompilerGenerated]
	private ClickDelegateHander m_a;

	private IContainer m_b;

	private TextBox m_c;

	private Button m_d;

	private Button e;

	private Label f;

	private Label g;

	private TextBox h;

	private Label i;

	private TextBox j;

	private Label k;

	private TextBox l;

	private Label m;

	private TextBox n;

	private Label o;

	private Label p;

	private Label q;

	public event ClickDelegateHander ClickEvent
	{
		[CompilerGenerated]
		add
		{
			short num = 0;
			_ = num;
			num = -9230;
			short num2 = num;
			num = -9230;
			ClickDelegateHander clickDelegateHander = default(ClickDelegateHander);
			int num3 = default(int);
			ClickDelegateHander clickDelegateHander2 = default(ClickDelegateHander);
			switch (num2 == num)
			{
			default:
				num = 0;
				if (num != 0)
				{
				}
				switch (0)
				{
				case 0:
					goto IL_008f;
				}
				goto IL_007d;
			case false:
			case true:
				goto IL_008f;
				IL_008f:
				clickDelegateHander = this.m_a;
				num = 0;
				num3 = num;
				goto IL_007d;
				IL_007d:
				while (true)
				{
					switch (num3)
					{
					case 0:
					{
						clickDelegateHander2 = clickDelegateHander;
						ClickDelegateHander value2 = (ClickDelegateHander)Delegate.Combine(clickDelegateHander2, value);
						clickDelegateHander = Interlocked.CompareExchange(ref this.m_a, value2, clickDelegateHander2);
						num = 1;
						num3 = num;
						continue;
					}
					case 1:
						num = 1;
						if (num != 0)
						{
						}
						if ((object)clickDelegateHander == clickDelegateHander2)
						{
							num = 2;
							num3 = num;
							continue;
						}
						goto case 0;
					case 2:
						return;
					}
					break;
				}
				goto IL_008f;
			}
		}
		[CompilerGenerated]
		remove
		{
			short num = 0;
			_ = num;
			num = -28338;
			short num2 = num;
			num = -28338;
			int num3 = default(int);
			ClickDelegateHander clickDelegateHander2 = default(ClickDelegateHander);
			ClickDelegateHander clickDelegateHander = default(ClickDelegateHander);
			switch (num2 == num)
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
				switch (0)
				{
				case 0:
					goto IL_00b7;
				}
				goto IL_00a5;
			case false:
			case true:
				goto IL_00b7;
				IL_00a5:
				while (true)
				{
					switch (num3)
					{
					case 0:
					{
						clickDelegateHander2 = clickDelegateHander;
						ClickDelegateHander value2 = (ClickDelegateHander)Delegate.Remove(clickDelegateHander2, value);
						clickDelegateHander = Interlocked.CompareExchange(ref this.m_a, value2, clickDelegateHander2);
						num = 1;
						num3 = num;
						continue;
					}
					case 1:
						if ((object)clickDelegateHander == clickDelegateHander2)
						{
							num = 2;
							num3 = num;
							continue;
						}
						goto case 0;
					case 2:
						return;
					}
					break;
				}
				goto IL_00b7;
				IL_00b7:
				clickDelegateHander = this.m_a;
				num = 0;
				num3 = num;
				goto IL_00a5;
			}
		}
	}

	public reg()
	{
		a();
		base.StartPosition = FormStartPosition.CenterScreen;
	}

	private void d(object A_0, EventArgs A_1)
	{
		short num = 0;
		_ = num;
		num = 1;
		if (num != 0)
		{
		}
		num = 3448;
		short num2 = num;
		num = 3448;
		switch (num2 == num)
		{
		}
		num = 0;
		if (num == 0)
		{
		}
	}

	private void c(object A_0, EventArgs A_1)
	{
		short num = 0;
		_ = num;
		num = 1;
		if (num != 0)
		{
		}
		num = 22740;
		short num2 = num;
		num = 22740;
		switch (num2 == num)
		{
		}
		num = 0;
		if (num == 0)
		{
		}
	}

	private void b(object A_0, EventArgs A_1)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 11;
			int num2 = num;
			string pattern = default(string);
			string pattern2 = default(string);
			string text2 = default(string);
			string text = default(string);
			string text3 = default(string);
			string text5 = default(string);
			byte[] bytes5 = default(byte[]);
			WebClient webClient = default(WebClient);
			string text4 = default(string);
			byte[] bytes2 = default(byte[]);
			byte[] bytes3 = default(byte[]);
			string[] array2 = default(string[]);
			while (true)
			{
				switch (num2)
				{
				case 11:
					switch (0)
					{
					default:
						goto end_IL_003e;
					case 0:
						break;
					}
					goto default;
				default:
					if (!(h.Text == ""))
					{
						num = 9;
						num2 = num;
						break;
					}
					goto case 6;
				case 20:
					MessageBox.Show("用户名和密码长度不能小于6", "登陆提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				case 3:
					num = 10;
					num2 = num;
					break;
				case 10:
					if (this.m_c.Text.Length < 6)
					{
						num = 20;
						num2 = num;
						break;
					}
					username = h.Text;
					password = this.m_c.Text;
					cellphonenum = l.Text;
					mibaonum = n.Text;
					pattern = "[0-9]{11}";
					pattern2 = "[0-9]";
					num = 13;
					num2 = num;
					break;
				case 13:
					if (cellphonenum != "")
					{
						num = 19;
						num2 = num;
						break;
					}
					goto IL_08ba;
				case 15:
					MessageBox.Show("输入的密保号码不合规，必须为数字", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				case 9:
					num = 8;
					num2 = num;
					break;
				case 8:
					if (this.m_c.Text == "")
					{
						num = 6;
						num2 = num;
					}
					else
					{
						num = 2;
						num2 = num;
					}
					break;
				case 1:
					num = 17;
					num2 = num;
					break;
				case 17:
					if (!Regex.IsMatch(mibaonum, pattern2))
					{
						num = 15;
						num2 = num;
						break;
					}
					goto IL_0711;
				case 22:
					num = 4;
					num2 = num;
					break;
				case 4:
					if (cellphonenum.Length != 11)
					{
						num = 7;
						num2 = num;
						break;
					}
					goto IL_08ba;
				case 7:
					num = 0;
					_ = num;
					goto IL_02f6;
				case 24:
				{
					string s = "passA=" + text2 + "&passB=" + text + "&username=" + username + "&passc=" + text3 + "&USERID=" + userid + "&phonenum=" + cellphonenum + "&systeminfo=" + text5 + "&mibaonum=" + mibaonum;
					bytes5 = Encoding.UTF8.GetBytes(s);
					webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
					webClient.Headers.Add("ContentLength", bytes5.Length.ToString());
					num = 14;
					num2 = num;
					break;
				}
				case 25:
					MessageBox.Show("两次密码不相同！", "登陆提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				case 6:
					MessageBox.Show("账号和密码不能为空！", "登陆提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				case 14:
					try
					{
						switch (0)
						{
						default:
							while (true)
							{
								switch (num2)
								{
								case 6:
									if (text4.Trim() == "sucess")
									{
										num = 3;
										num2 = num;
									}
									else
									{
										MessageBox.Show(text4, "注册提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
										num = 2;
										num2 = num;
									}
									continue;
								case 3:
									Settings.Default.pcrname = username;
									Settings.Default.pcrpassword = password;
									MessageBox.Show("注册成功", "注册提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									num = 5;
									num2 = num;
									continue;
								case 5:
									if (this.m_a != null)
									{
										num = 1;
										num2 = num;
										continue;
									}
									goto case 0;
								case 0:
									Close();
									num = 7;
									num2 = num;
									continue;
								case 1:
									this.m_a("loginsucess");
									num = 0;
									num2 = num;
									continue;
								case 2:
								case 7:
									num = 4;
									num2 = num;
									continue;
								case 4:
									return;
								}
								break;
							}
							goto case 0;
						case 0:
						{
							byte[] bytes4 = webClient.UploadData("https://www.rfidfans.com/win/winlogin.php", "POST", bytes5);
							text4 = Encoding.UTF8.GetString(bytes4);
							num = 6;
							num2 = num;
							goto default;
						}
						}
					}
					catch (Exception ex2)
					{
						MessageBox.Show("请保持网络连接畅通：" + ex2.Message);
						return;
					}
				case 19:
					num = 1;
					if (num != 0)
					{
					}
					num = 16;
					num2 = num;
					break;
				case 16:
					if (Regex.IsMatch(cellphonenum, pattern))
					{
						num = 22;
						num2 = num;
						break;
					}
					goto IL_02f6;
				case 21:
					if (h.Text.Length >= 6)
					{
						num = 3;
						num2 = num;
						break;
					}
					goto case 20;
				case 2:
					if (!(this.m_c.Text != j.Text))
					{
						num = 21;
						num2 = num;
					}
					else
					{
						num = 25;
						num2 = num;
					}
					break;
				case 0:
				{
					byte[] bytes = Encoding.Default.GetBytes(password);
					webClient = new WebClientto(5000);
					ServicePointManager.ServerCertificateValidationCallback = delegate
					{
						short num4 = 1;
						if (num4 != 0)
						{
						}
						num4 = 24616;
						short num5 = num4;
						num4 = 24616;
						switch (num5 == num4)
						{
						default:
							num4 = 0;
							if (num4 != 0)
							{
							}
							num4 = 0;
							_ = num4;
							return true;
						}
					};
					text = Convert.ToBase64String(bytes2);
					text2 = Convert.ToBase64String(bytes3);
					text3 = Convert.ToBase64String(bytes);
					num = 18;
					num2 = num;
					break;
				}
				case 12:
				{
					array2 = File.ReadAllLines("nfc-bin/libnfc11.dll");
					num = -21987;
					short num3 = num;
					num = -21987;
					switch (num3 == num)
					{
					default:
						num = 0;
						if (num != 0)
						{
						}
						num = 23;
						num2 = num;
						goto end_IL_003e;
					case false:
					case true:
						break;
					}
					goto IL_089d;
				}
				case 23:
					try
					{
						string[] array = array2[0].Split('#');
						userid = array[0];
						nickname = array[1];
					}
					catch (Exception ex)
					{
						Console.Write(ex.Message);
					}
					goto case 24;
				case 18:
					if (!File.Exists("nfc-bin/libnfc11.dll"))
					{
						userid = "999999999";
						num = 24;
						num2 = num;
						break;
					}
					goto IL_089d;
				case 5:
					{
						if (mibaonum != "")
						{
							num = 1;
							num2 = num;
							break;
						}
						goto IL_0711;
					}
					IL_089d:
					num = 12;
					num2 = num;
					break;
					IL_08ba:
					num = 5;
					num2 = num;
					break;
					IL_02f6:
					MessageBox.Show("输入手机号码不合规，必须为11位数字", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
					IL_0711:
					text5 = Resources._软件版本 + Assembly.GetExecutingAssembly().GetName().Version.ToString();
					bytes2 = Encoding.Default.GetBytes("pcrlogin");
					bytes3 = Encoding.Default.GetBytes("reg");
					num = 0;
					num2 = num;
					break;
					end_IL_003e:
					break;
				}
			}
		}
		}
	}

	private void a(object A_0, EventArgs A_1)
	{
		short num = -19606;
		short num2 = num;
		num = -19606;
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
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		short num = 26305;
		short num2 = num;
		num = 26305;
		int num3;
		switch (num2 == num)
		{
		default:
			num = 0;
			if (num != 0)
			{
			}
			num = 3;
			num3 = num;
			goto IL_0067;
		case false:
		case true:
			{
				num = 1;
				if (num != 0)
				{
				}
				if (!disposing)
				{
					break;
				}
				num = 2;
				num3 = num;
				goto IL_0067;
			}
			IL_0067:
			while (true)
			{
				switch (num3)
				{
				case 3:
					switch (0)
					{
					default:
						continue;
					case 0:
						break;
					}
					break;
				case 0:
					this.m_b.Dispose();
					num = 1;
					num3 = num;
					continue;
				case 2:
					num = 0;
					_ = num;
					num = 4;
					num3 = num;
					continue;
				case 4:
					if (this.m_b != null)
					{
						num = 0;
						num3 = num;
						continue;
					}
					goto end_IL_0022;
				case 1:
					goto end_IL_0022;
				}
				break;
			}
			goto case false;
			end_IL_0022:
			break;
		}
		base.Dispose(disposing);
	}

	private void a()
	{
		short num = 16494;
		short num2 = num;
		num = 16494;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(reg));
		this.m_c = new TextBox();
		this.m_d = new Button();
		e = new Button();
		f = new Label();
		g = new Label();
		h = new TextBox();
		i = new Label();
		j = new TextBox();
		k = new Label();
		l = new TextBox();
		m = new Label();
		n = new TextBox();
		o = new Label();
		p = new Label();
		q = new Label();
		SuspendLayout();
		this.m_c.Location = new Point(139, 95);
		this.m_c.Name = "textBox2";
		this.m_c.PasswordChar = '*';
		this.m_c.Size = new Size(121, 21);
		this.m_c.TabIndex = 1;
		this.m_d.Location = new Point(198, 239);
		this.m_d.Name = "button2";
		this.m_d.Size = new Size(78, 29);
		this.m_d.TabIndex = 6;
		this.m_d.Text = "取消";
		this.m_d.UseVisualStyleBackColor = true;
		this.m_d.Click += a;
		e.Location = new Point(86, 239);
		e.Name = "button1";
		e.Size = new Size(76, 29);
		e.TabIndex = 5;
		e.Text = "注册";
		e.UseVisualStyleBackColor = true;
		e.Click += b;
		f.AutoSize = true;
		f.Location = new Point(80, 98);
		f.Name = "label3";
		f.Size = new Size(53, 12);
		f.TabIndex = 14;
		f.Text = "密  码：";
		g.AutoSize = true;
		g.Location = new Point(79, 66);
		g.Name = "label2";
		g.Size = new Size(53, 12);
		g.TabIndex = 13;
		g.Text = "用户名：";
		h.Location = new Point(139, 63);
		h.Name = "textBox1";
		h.Size = new Size(121, 21);
		h.TabIndex = 0;
		i.AutoSize = true;
		i.Font = new Font("宋体", 18f, FontStyle.Bold, GraphicsUnit.Point, 134);
		i.Location = new Point(125, 19);
		i.Name = "label1";
		i.Size = new Size(110, 24);
		i.TabIndex = 15;
		i.Text = "用户注册";
		i.Click += d;
		j.Location = new Point(139, 126);
		j.Name = "textBox3";
		j.PasswordChar = '*';
		j.Size = new Size(121, 21);
		j.TabIndex = 2;
		k.AutoSize = true;
		k.Location = new Point(43, 129);
		k.Name = "label4";
		k.Size = new Size(89, 12);
		k.TabIndex = 17;
		k.Text = "再次输入密码：";
		k.Click += c;
		l.Location = new Point(139, 162);
		l.Name = "textBox4";
		l.Size = new Size(121, 21);
		l.TabIndex = 3;
		m.AutoSize = true;
		m.Location = new Point(55, 165);
		m.Name = "label5";
		m.Size = new Size(77, 12);
		m.TabIndex = 19;
		m.Text = "  手机号码：";
		n.Location = new Point(139, 198);
		n.Name = "textBox5";
		n.Size = new Size(121, 21);
		n.TabIndex = 4;
		o.AutoSize = true;
		o.Location = new Point(67, 201);
		o.Name = "label6";
		o.Size = new Size(65, 12);
		o.TabIndex = 21;
		o.Text = "密保号码：";
		p.AutoSize = true;
		p.Location = new Point(266, 165);
		p.Name = "label7";
		p.Size = new Size(29, 12);
		p.TabIndex = 22;
		p.Text = "选填";
		q.AutoSize = true;
		q.Location = new Point(266, 201);
		q.Name = "label8";
		q.Size = new Size(89, 12);
		q.TabIndex = 23;
		q.Text = "找回用户名密码";
		base.AcceptButton = e;
		base.AutoScaleDimensions = new SizeF(6f, 12f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(366, 307);
		base.Controls.Add(q);
		base.Controls.Add(p);
		base.Controls.Add(n);
		base.Controls.Add(o);
		base.Controls.Add(l);
		base.Controls.Add(m);
		base.Controls.Add(j);
		base.Controls.Add(k);
		base.Controls.Add(this.m_c);
		base.Controls.Add(this.m_d);
		base.Controls.Add(e);
		base.Controls.Add(f);
		base.Controls.Add(g);
		base.Controls.Add(i);
		base.Controls.Add(h);
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "reg";
		Text = "用户注册";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
