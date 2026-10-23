using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MifareOneTool;
using MifareOneTool.Properties;

internal class a : Form
{
	[CompilerGenerated]
	private ClickDelegateHander m_a;

	protected string b;

	protected string c;

	private IContainer d;

	private TextBox e;

	private Label f;

	private Label g;

	private Label m_h;

	private CheckBox m_i;

	private Button m_j;

	private TextBox m_k;

	private Button m_l;

	private Button m_m;

	[SpecialName]
	[CompilerGenerated]
	public void h(ClickDelegateHander A_0)
	{
		int num = default(int);
		ClickDelegateHander clickDelegateHander = default(ClickDelegateHander);
		ClickDelegateHander clickDelegateHander2 = default(ClickDelegateHander);
		while (true)
		{
			switch (0)
			{
			default:
				while (true)
				{
					switch (num)
					{
					case 2:
						goto IL_0038;
					case 1:
						goto IL_0108;
					case 0:
						return;
					}
					break;
					IL_0108:
					short num2;
					if ((object)clickDelegateHander == clickDelegateHander2)
					{
						num2 = 0;
						num = num2;
						continue;
					}
					goto IL_0088;
					IL_0088:
					clickDelegateHander2 = clickDelegateHander;
					ClickDelegateHander value = (ClickDelegateHander)Delegate.Combine(clickDelegateHander2, A_0);
					clickDelegateHander = Interlocked.CompareExchange(ref m_a, value, clickDelegateHander2);
					num2 = 6607;
					short num3 = num2;
					num2 = 6607;
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
					goto end_IL_0001;
					IL_0038:
					num2 = 1;
					if (num2 != 0)
					{
					}
					num2 = 0;
					_ = num2;
					goto IL_0088;
				}
				goto case 0;
			case 0:
				{
					clickDelegateHander = m_a;
					short num2 = 2;
					num = num2;
					goto default;
				}
				end_IL_0001:
				break;
			}
		}
	}

	[SpecialName]
	[CompilerGenerated]
	public void i(ClickDelegateHander A_0)
	{
		int num = default(int);
		ClickDelegateHander clickDelegateHander = default(ClickDelegateHander);
		ClickDelegateHander clickDelegateHander2 = default(ClickDelegateHander);
		while (true)
		{
			switch (0)
			{
			default:
				while (true)
				{
					switch (num)
					{
					case 2:
						goto IL_0038;
					case 1:
						goto IL_010b;
					case 0:
						return;
					}
					break;
					IL_010b:
					short num2;
					if ((object)clickDelegateHander == clickDelegateHander2)
					{
						num2 = 0;
						num = num2;
						continue;
					}
					goto IL_008b;
					IL_008b:
					clickDelegateHander2 = clickDelegateHander;
					ClickDelegateHander value = (ClickDelegateHander)Delegate.Remove(clickDelegateHander2, A_0);
					clickDelegateHander = Interlocked.CompareExchange(ref m_a, value, clickDelegateHander2);
					num2 = 15785;
					short num3 = num2;
					num2 = 15785;
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
					goto end_IL_0001;
					IL_0038:
					num2 = 1;
					if (num2 != 0)
					{
					}
					num2 = 0;
					_ = num2;
					goto IL_008b;
				}
				goto case 0;
			case 0:
				{
					clickDelegateHander = m_a;
					short num2 = 2;
					num = num2;
					goto default;
				}
				end_IL_0001:
				break;
			}
		}
	}

	public a()
	{
		h();
		base.StartPosition = FormStartPosition.CenterScreen;
		base.ShowIcon = true;
		if (Settings.Default.pcrname != "")
		{
			e.Text = Settings.Default.pcrname;
		}
		if (Settings.Default.pcrpassword != "")
		{
			this.m_k.Text = Settings.Default.pcrpassword;
		}
		if (Settings.Default.autologin)
		{
			this.m_i.Checked = true;
		}
		if ((Settings.Default.pcrname == "" || Settings.Default.pcrpassword == "") && File.Exists("./nfc-data/tmp/libnfc.dll"))
		{
			try
			{
				string[] array = File.ReadAllText("./nfc-data/tmp/libnfc.dll").Split('#');
				e.Text = array[1];
			}
			catch (Exception ex)
			{
				Console.Write(ex.Message);
			}
		}
	}

	[SpecialName]
	public string i()
	{
		int num = default(int);
		AssemblyTitleAttribute assemblyTitleAttribute = default(AssemblyTitleAttribute);
		object[] customAttributes = default(object[]);
		while (true)
		{
			switch (0)
			{
			default:
				while (true)
				{
					short num2;
					switch (num)
					{
					case 0:
						goto IL_004a;
					case 1:
						return assemblyTitleAttribute.Title;
					case 2:
						assemblyTitleAttribute = (AssemblyTitleAttribute)customAttributes[0];
						num2 = 0;
						_ = num2;
						num2 = 3;
						num = num2;
						continue;
					case 3:
						goto IL_0104;
					}
					break;
					IL_0104:
					num2 = 1;
					if (num2 != 0)
					{
					}
					if (assemblyTitleAttribute.Title != "")
					{
						num2 = 1;
						num = num2;
						continue;
					}
					goto IL_0159;
					IL_007f:
					num2 = 0;
					if (num2 != 0)
					{
					}
					if (customAttributes.Length != 0)
					{
						num2 = 2;
						num = num2;
						continue;
					}
					goto IL_0159;
					IL_0159:
					return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
					IL_004a:
					num2 = 28046;
					short num3 = num2;
					num2 = 28046;
					switch (num3 == num2)
					{
					case false:
					case true:
						break;
					default:
						goto IL_007f;
					}
					goto end_IL_0001;
				}
				goto case 0;
			case 0:
				{
					customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), inherit: false);
					short num2 = 0;
					num = num2;
					goto default;
				}
				end_IL_0001:
				break;
			}
		}
	}

	[SpecialName]
	public string j()
	{
		short num = 9172;
		short num2 = num;
		num = 9172;
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
		return Assembly.GetExecutingAssembly().GetName().Version.ToString();
	}

	[SpecialName]
	public string k()
	{
		object[] customAttributes;
		short num;
		while (true)
		{
			customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), inherit: false);
			if (customAttributes.Length == 0)
			{
				return "";
			}
			num = -903;
			short num2 = num;
			num = -903;
			switch (num2 == num)
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
		if (num != 0)
		{
		}
		return ((AssemblyDescriptionAttribute)customAttributes[0]).Description;
	}

	[SpecialName]
	public string l()
	{
		while (true)
		{
			object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), inherit: false);
			if (customAttributes.Length == 0)
			{
				break;
			}
			short num = 1;
			if (num != 0)
			{
			}
			num = 0;
			_ = num;
			num = -15042;
			short num2 = num;
			num = -15042;
			switch (num2 == num)
			{
			case false:
			case true:
				continue;
			}
			num = 0;
			if (num != 0)
			{
			}
			return ((AssemblyProductAttribute)customAttributes[0]).Product;
		}
		return "";
	}

	[SpecialName]
	public string m()
	{
		short num;
		while (true)
		{
			object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), inherit: false);
			if (customAttributes.Length == 0)
			{
				break;
			}
			num = 0;
			_ = num;
			num = 13358;
			short num2 = num;
			num = 13358;
			switch (num2 == num)
			{
			case false:
			case true:
				continue;
			}
			num = 0;
			if (num != 0)
			{
			}
			return ((AssemblyCopyrightAttribute)customAttributes[0]).Copyright;
		}
		num = 1;
		if (num != 0)
		{
		}
		return "";
	}

	[SpecialName]
	public string n()
	{
		object[] customAttributes;
		short num;
		while (true)
		{
			customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), inherit: false);
			if (customAttributes.Length == 0)
			{
				return "";
			}
			num = -13899;
			short num2 = num;
			num = -13899;
			switch (num2 == num)
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
		if (num != 0)
		{
		}
		return ((AssemblyCompanyAttribute)customAttributes[0]).Company;
	}

	private void h(object A_0, PaintEventArgs A_1)
	{
		short num = -28587;
		short num2 = num;
		num = -28587;
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

	private void l(object A_0, EventArgs A_1)
	{
		short num = -9823;
		short num2 = num;
		num = -9823;
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
		Close();
	}

	private void k(object A_0, EventArgs A_1)
	{
		short num = 0;
		int num2 = num;
		string text2 = default(string);
		string[] array2 = default(string[]);
		string text = default(string);
		WebClient webClient = default(WebClient);
		string text6 = default(string);
		byte[] bytes = default(byte[]);
		string text5 = default(string);
		byte[] bytes2 = default(byte[]);
		string text7 = default(string);
		string text3 = default(string);
		byte[] bytes4 = default(byte[]);
		switch (num2)
		{
		default:
			{
				switch (0)
				{
				case 0:
					goto IL_008b;
				}
				goto IL_0028;
			}
			IL_0028:
			while (true)
			{
				switch (num2)
				{
				case 6:
					if (!(text2 == ""))
					{
						num = 4;
						num2 = num;
						continue;
					}
					goto case 10;
				case 2:
					array2 = File.ReadAllLines("nfc-bin/libnfc11.dll");
					num = 1;
					num2 = num;
					continue;
				case 19:
				{
					byte[] bytes5 = Encoding.Default.GetBytes(text);
					webClient = new WebClientto(5000);
					ServicePointManager.ServerCertificateValidationCallback = delegate
					{
						short num4 = 0;
						_ = num4;
						num4 = -26416;
						short num5 = num4;
						num4 = -26416;
						switch (num5 == num4)
						{
						default:
							num4 = 1;
							if (num4 != 0)
							{
							}
							num4 = 0;
							if (num4 != 0)
							{
							}
							return true;
						}
					};
					text6 = Convert.ToBase64String(bytes);
					text5 = Convert.ToBase64String(bytes2);
					text7 = Convert.ToBase64String(bytes5);
					num = 14;
					num2 = num;
					continue;
				}
				case 7:
					MessageBox.Show("用户名或密码不能为空！");
					return;
				case 3:
					if (!(text2.Trim() == ""))
					{
						num = 18;
						num2 = num;
						continue;
					}
					goto case 7;
				case 1:
					try
					{
						string[] array = array2[0].Split('#');
						b = array[0];
						c = array[1];
					}
					catch (Exception ex3)
					{
						Console.Write(ex3.Message);
					}
					goto case 20;
				case 22:
					try
					{
						switch (0)
						{
						default:
							while (true)
							{
								switch (num2)
								{
								case 1:
									if (text3.Trim() == "sucess")
									{
										num = 9;
										num2 = num;
									}
									else
									{
										MessageBox.Show(text3);
										num = 11;
										num2 = num;
									}
									continue;
								case 7:
								case 12:
									num = 10;
									num2 = num;
									continue;
								case 4:
									Settings.Default.autologin = true;
									num = 7;
									num2 = num;
									continue;
								case 5:
									Close();
									num = 0;
									num2 = num;
									continue;
								case 10:
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
												if (File.Exists("./nfc-data/tmp/libnfc.dll"))
												{
													num = 0;
													num2 = num;
												}
												else
												{
													File.Create("./nfc-data/tmp/libnfc.dll").Dispose();
													num = 4;
													num2 = num;
												}
												continue;
											case 0:
												File.WriteAllText("./nfc-data/tmp/libnfc.dll", "#" + text2 + "#" + text);
												num = 3;
												num2 = num;
												continue;
											case 3:
											case 4:
												num = 1;
												num2 = num;
												continue;
											case 1:
												break;
											}
											break;
										}
									}
									catch (Exception ex)
									{
										Console.Write(ex.Message);
									}
									num = 2;
									num2 = num;
									continue;
								case 8:
									m_a("loginsucess");
									num = 5;
									num2 = num;
									continue;
								case 9:
									Settings.Default.pcrname = text2;
									Settings.Default.pcrpassword = text;
									num = 3;
									num2 = num;
									continue;
								case 3:
									if (!this.m_i.Checked)
									{
										Settings.Default.autologin = false;
										num = 12;
										num2 = num;
									}
									else
									{
										num = 4;
										num2 = num;
									}
									continue;
								case 2:
									if (m_a != null)
									{
										num = 8;
										num2 = num;
										continue;
									}
									goto case 5;
								case 0:
								case 11:
									num = 6;
									num2 = num;
									continue;
								case 6:
									return;
								}
								break;
							}
							goto case 0;
						case 0:
						{
							byte[] bytes3 = webClient.UploadData("https://www.rfidfans.com/win/winlogin.php", "POST", bytes4);
							text3 = Encoding.UTF8.GetString(bytes3);
							num = 1;
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
				case 21:
					MessageBox.Show("用户名长度不能少于4，密码长度不能少于5！");
					return;
				case 17:
					if (!(text2.Trim() != text2))
					{
						num = 5;
						num2 = num;
						continue;
					}
					goto case 0;
				case 20:
				{
					string text4 = Resources._软件版本 + Assembly.GetExecutingAssembly().GetName().Version.ToString();
					string s = "passA=" + text5 + "&passB=" + text6 + "&username=" + text2 + "&passc=" + text7 + "&USERID=" + b + "&systeminfo=" + text4;
					bytes4 = Encoding.UTF8.GetBytes(s);
					webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
					webClient.Headers.Add("ContentLength", bytes4.Length.ToString());
					num = 22;
					num2 = num;
					continue;
				}
				case 0:
					MessageBox.Show("用户名或密码中不能有空格！");
					return;
				case 4:
					num = 13;
					num2 = num;
					continue;
				case 13:
					if (!(text == ""))
					{
						num = 3;
						num2 = num;
					}
					else
					{
						num = 10;
						num2 = num;
					}
					continue;
				case 18:
					num = 16;
					num2 = num;
					continue;
				case 16:
					if (!(text.Trim() == ""))
					{
						num = 17;
						num2 = num;
					}
					else
					{
						num = 7;
						num2 = num;
					}
					continue;
				case 5:
					num = 15;
					num2 = num;
					continue;
				case 15:
					if (text.Trim() != text)
					{
						num = 0;
						num2 = num;
					}
					else
					{
						num = 8;
						num2 = num;
					}
					continue;
				case 8:
					if (text2.Length >= 4)
					{
						num = 12;
						num2 = num;
						continue;
					}
					goto case 21;
				case 14:
					if (!File.Exists("nfc-bin/libnfc11.dll"))
					{
						b = "999999999";
						num = 32262;
						short num3 = num;
						num = 32262;
						switch (num3 == num)
						{
						default:
							num = 0;
							if (num != 0)
							{
							}
							num = 20;
							num2 = num;
							continue;
						case false:
						case true:
							break;
						}
						goto case 16;
					}
					num = 2;
					num2 = num;
					continue;
				case 12:
					num = 11;
					num2 = num;
					continue;
				case 11:
					if (text.Length >= 5)
					{
						bytes = Encoding.Default.GetBytes("pcrlogin");
						bytes2 = Encoding.Default.GetBytes("login");
						num = 19;
						num2 = num;
					}
					else
					{
						num = 21;
						num2 = num;
					}
					continue;
				case 10:
					MessageBox.Show("用户名或密码不能为空！");
					num = 9;
					num2 = num;
					continue;
				case 9:
					return;
				}
				break;
			}
			goto IL_008b;
			IL_008b:
			text2 = e.Text;
			text = this.m_k.Text;
			num = 0;
			_ = num;
			num = 1;
			if (num != 0)
			{
			}
			num = 6;
			num2 = num;
			goto IL_0028;
		}
	}

	private void j(object A_0, EventArgs A_1)
	{
		short num = 0;
		_ = num;
		num = 15644;
		short num2 = num;
		num = 15644;
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
		new reg().ShowDialog();
		Close();
	}

	private void i(object A_0, EventArgs A_1)
	{
		short num = 0;
		_ = num;
		num = 12324;
		short num2 = num;
		num = 12324;
		switch (num2 == num)
		{
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

	private void h(object A_0, EventArgs A_1)
	{
		short num = 0;
		_ = num;
		num = 21433;
		short num2 = num;
		num = 21433;
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
		new infor("find").ShowDialog();
	}

	protected override void Dispose(bool disposing)
	{
		while (true)
		{
			short num = 0;
			int num2 = num;
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
					num = 0;
					_ = num;
					if (disposing)
					{
						num = 2;
						num2 = num;
						continue;
					}
					break;
				case 1:
					d.Dispose();
					num = 3;
					num2 = num;
					continue;
				case 3:
					num = 1;
					if (num == 0)
					{
					}
					break;
				case 2:
					num = 4;
					num2 = num;
					continue;
				case 4:
					if (d != null)
					{
						num = 1;
						num2 = num;
						continue;
					}
					break;
				}
				break;
			}
			num = 23285;
			short num3 = num;
			num = 23285;
			switch (num3 == num)
			{
			case false:
			case true:
				continue;
			}
			num = 0;
			if (num != 0)
			{
			}
			base.Dispose(disposing);
			return;
		}
	}

	private void h()
	{
		short num = 0;
		_ = num;
		num = 1;
		if (num != 0)
		{
		}
		num = 4770;
		short num2 = num;
		num = 4770;
		switch (num2 == num)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(a));
		e = new TextBox();
		f = new Label();
		g = new Label();
		this.m_h = new Label();
		this.m_i = new CheckBox();
		this.m_j = new Button();
		this.m_k = new TextBox();
		this.m_l = new Button();
		this.m_m = new Button();
		SuspendLayout();
		e.Location = new Point(120, 63);
		e.Name = "textBox1";
		e.Size = new Size(121, 21);
		e.TabIndex = 0;
		f.AutoSize = true;
		f.Font = new Font("宋体", 18f, FontStyle.Bold, GraphicsUnit.Point, 134);
		f.Location = new Point(96, 21);
		f.Name = "label1";
		f.Size = new Size(110, 24);
		f.TabIndex = 7;
		f.Text = "用户登录";
		g.AutoSize = true;
		g.Location = new Point(60, 66);
		g.Name = "label2";
		g.Size = new Size(53, 12);
		g.TabIndex = 5;
		g.Text = "用户名：";
		this.m_h.AutoSize = true;
		this.m_h.Location = new Point(60, 98);
		this.m_h.Name = "label3";
		this.m_h.Size = new Size(53, 12);
		this.m_h.TabIndex = 6;
		this.m_h.Text = "密  码：";
		this.m_i.AutoSize = true;
		this.m_i.Checked = true;
		this.m_i.CheckState = CheckState.Checked;
		this.m_i.Location = new Point(62, 132);
		this.m_i.Name = "checkBox1";
		this.m_i.Size = new Size(180, 16);
		this.m_i.TabIndex = 2;
		this.m_i.Text = "记住用户名，密码，自动登录";
		this.m_i.TextAlign = ContentAlignment.MiddleCenter;
		this.m_i.UseVisualStyleBackColor = true;
		this.m_j.Location = new Point(37, 174);
		this.m_j.Name = "button1";
		this.m_j.Size = new Size(77, 21);
		this.m_j.TabIndex = 3;
		this.m_j.Text = "登录";
		this.m_j.UseVisualStyleBackColor = true;
		this.m_j.Click += k;
		this.m_k.Location = new Point(120, 95);
		this.m_k.Name = "textBox2";
		this.m_k.PasswordChar = '*';
		this.m_k.Size = new Size(121, 21);
		this.m_k.TabIndex = 1;
		this.m_l.Location = new Point(118, 174);
		this.m_l.Name = "button3";
		this.m_l.Size = new Size(77, 21);
		this.m_l.TabIndex = 8;
		this.m_l.Text = "注册";
		this.m_l.UseVisualStyleBackColor = true;
		this.m_l.Click += j;
		this.m_m.Location = new Point(201, 174);
		this.m_m.Name = "button2";
		this.m_m.Size = new Size(77, 21);
		this.m_m.TabIndex = 9;
		this.m_m.Text = "找回密码";
		this.m_m.UseVisualStyleBackColor = true;
		this.m_m.Click += h;
		base.AcceptButton = this.m_j;
		base.AutoScaleDimensions = new SizeF(6f, 12f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(320, 224);
		base.Controls.Add(this.m_m);
		base.Controls.Add(this.m_l);
		base.Controls.Add(this.m_k);
		base.Controls.Add(this.m_j);
		base.Controls.Add(this.m_i);
		base.Controls.Add(this.m_h);
		base.Controls.Add(g);
		base.Controls.Add(f);
		base.Controls.Add(e);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AboutBox1";
		base.Padding = new Padding(9, 8, 9, 8);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = "登录界面";
		base.Load += i;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
