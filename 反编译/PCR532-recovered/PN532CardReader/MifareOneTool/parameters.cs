using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MifareOneTool.Properties;

namespace MifareOneTool;

public class parameters : Form
{
	[CompilerGenerated]
	private ClickDelegateHander m_a;

	private IContainer m_b;

	private Label m_c;

	private Label m_d;

	private CheckBox m_e;

	private Label m_f;

	private CheckBox g;

	private Label h;

	private CheckBox i;

	private Button j;

	private Button k;

	private Label l;

	private CheckBox m;

	private Label n;

	private CheckBox o;

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
					ClickDelegateHander value2;
					short num2;
					switch (num)
					{
					case 1:
						num2 = 1;
						if (num2 == 0)
						{
						}
						goto IL_005f;
					case 2:
						if ((object)clickDelegateHander != clickDelegateHander2)
						{
							goto IL_005f;
						}
						goto IL_0099;
					case 0:
						{
							num2 = 2494;
							short num3 = num2;
							num2 = 2494;
							switch (num3 == num2)
							{
							case false:
							case true:
								break;
							default:
								num2 = 0;
								_ = num2;
								goto case true;
							case true:
								num2 = 0;
								if (num2 == 0)
								{
								}
								return;
							}
							goto IL_0099;
						}
						IL_0099:
						num2 = 0;
						num = num2;
						continue;
						IL_005f:
						clickDelegateHander2 = clickDelegateHander;
						value2 = (ClickDelegateHander)Delegate.Combine(clickDelegateHander2, value);
						clickDelegateHander = Interlocked.CompareExchange(ref this.m_a, value2, clickDelegateHander2);
						num2 = 2;
						num = num2;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
			{
				clickDelegateHander = this.m_a;
				short num2 = 1;
				num = num2;
				goto default;
			}
			}
		}
		[CompilerGenerated]
		remove
		{
			short num = 0;
			_ = num;
			int num2 = default(int);
			ClickDelegateHander clickDelegateHander2 = default(ClickDelegateHander);
			switch (0)
			{
			default:
			{
				ClickDelegateHander clickDelegateHander = default(ClickDelegateHander);
				while (true)
				{
					switch (num2)
					{
					case 1:
					{
						clickDelegateHander = clickDelegateHander2;
						ClickDelegateHander value2 = (ClickDelegateHander)Delegate.Remove(clickDelegateHander, value);
						clickDelegateHander2 = Interlocked.CompareExchange(ref this.m_a, value2, clickDelegateHander);
						num = 2;
						num2 = num;
						continue;
					}
					case 2:
						if ((object)clickDelegateHander2 != clickDelegateHander)
						{
							goto case 1;
						}
						goto IL_0099;
					case 0:
						{
							num = 1;
							if (num != 0)
							{
							}
							num = -6648;
							short num3 = num;
							num = -6648;
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
							goto IL_0099;
						}
						IL_0099:
						num = 0;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				clickDelegateHander2 = this.m_a;
				num = 1;
				num2 = num;
				goto default;
			}
		}
	}

	public parameters()
	{
		a();
		base.StartPosition = FormStartPosition.CenterScreen;
	}

	private void f(object A_0, EventArgs A_1)
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
					continue;
				case 0:
					break;
				}
				goto default;
			default:
				num = 1;
				if (num != 0)
				{
				}
				if (Settings.Default.pcrqinlin)
				{
					num = 1;
					num2 = num;
					continue;
				}
				goto case 7;
			case 2:
				num = 0;
				_ = num;
				num = 0;
				num2 = num;
				continue;
			case 0:
				if (Settings.Default.unuse_historykye)
				{
					num = 5;
					num2 = num;
					continue;
				}
				break;
			case 6:
				o.Checked = true;
				num = 2;
				num2 = num;
				continue;
			case 1:
				this.m_e.Checked = true;
				num = 7;
				num2 = num;
				continue;
			case 5:
				m.Checked = true;
				num = 8;
				num2 = num;
				continue;
			case 7:
				num = 4;
				num2 = num;
				continue;
			case 4:
				if (!Settings.Default.writecard_nohint)
				{
					goto case 2;
				}
				num = 6;
				num2 = num;
				continue;
			case 8:
				break;
			}
			num = -5197;
			short num3 = num;
			num = -5197;
			switch (num3 == num)
			{
			case false:
			case true:
				continue;
			}
			num = 0;
			if (num == 0)
			{
			}
			return;
		}
	}

	private void e(object A_0, EventArgs A_1)
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
					goto end_IL_0020;
				case 0:
					break;
				}
				goto default;
			default:
			{
				num = 1;
				if (num != 0)
				{
				}
				num = 1738;
				short num3 = num;
				num = 1738;
				switch (num3 == num)
				{
				default:
					num = 0;
					if (num != 0)
					{
					}
					if (!this.m_e.Checked)
					{
						num = 0;
						_ = num;
						num = 1;
						num2 = num;
						goto end_IL_0020;
					}
					return;
				case false:
				case true:
					break;
				}
				goto case 1;
			}
			case 1:
				Settings.Default.pcrqinlin = false;
				num = 2;
				num2 = num;
				break;
			case 2:
				return;
				end_IL_0020:
				break;
			}
		}
	}

	private void a(string A_0)
	{
		short num = 0;
		_ = num;
		num = 11921;
		short num2 = num;
		num = 11921;
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
			throw new NotImplementedException();
		}
	}

	private void d(object A_0, EventArgs A_1)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 1;
			int num2 = num;
			byte[] bytes2 = default(byte[]);
			byte[] bytes3 = default(byte[]);
			WebClient webClient = default(WebClient);
			byte[] bytes4 = default(byte[]);
			string text4 = default(string);
			while (true)
			{
				switch (num2)
				{
				case 1:
					switch (0)
					{
					default:
						goto end_IL_0042;
					case 0:
						break;
					}
					goto default;
				default:
					if (this.m_e.Checked)
					{
						num = 3;
						num2 = num;
						break;
					}
					goto case 8;
				case 3:
					num = 1;
					if (num != 0)
					{
					}
					bytes2 = Encoding.Default.GetBytes("pcrwin");
					bytes3 = Encoding.Default.GetBytes("check_vip");
					num = 10;
					num2 = num;
					break;
				case 10:
				{
					byte[] bytes = Encoding.Default.GetBytes(Settings.Default.pcrpassword);
					webClient = new WebClientto(2500);
					ServicePointManager.ServerCertificateValidationCallback = delegate
					{
						short num4 = 0;
						_ = num4;
						num4 = 26885;
						short num5 = num4;
						num4 = 26885;
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
					string text = Convert.ToBase64String(bytes2);
					string text2 = Convert.ToBase64String(bytes3);
					string text3 = Convert.ToBase64String(bytes);
					string s = "passA=" + text2 + "&passB=" + text + "&username=" + Settings.Default.pcrname + "&passc=" + text3;
					bytes4 = Encoding.UTF8.GetBytes(s);
					webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
					webClient.Headers.Add("ContentLength", bytes4.Length.ToString());
					num = 2;
					num2 = num;
					break;
				}
				case 8:
					num = 7;
					num2 = num;
					break;
				case 7:
					if (m.Checked)
					{
						num = 4;
						num2 = num;
					}
					else
					{
						Settings.Default.unuse_historykye = false;
						num = 11;
						num2 = num;
					}
					break;
				case 6:
				case 15:
					MessageBox.Show("设置完成", "设置完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					num = 5;
					num2 = num;
					break;
				case 5:
					if (this.m_a != null)
					{
						num = 0;
						_ = num;
						num = 12;
						num2 = num;
						break;
					}
					return;
				case 12:
					this.m_a("setsucess");
					num = 14;
					num2 = num;
					break;
				case 14:
					return;
				case 4:
				{
					Settings.Default.unuse_historykye = true;
					num = -20972;
					short num3 = num;
					num = -20972;
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
						num = 0;
						num2 = num;
						goto end_IL_0042;
					}
					goto case 6;
				}
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
								case 0:
									if (!(text4.Trim() == "success"))
									{
										num = 1;
										num2 = num;
									}
									else
									{
										num = 3;
										num2 = num;
									}
									continue;
								case 1:
									this.m_e.Checked = false;
									MessageBox.Show(text4);
									num = 2;
									num2 = num;
									continue;
								case 2:
									return;
								case 3:
									goto end_IL_03d8;
								}
								goto case 0;
								continue;
								end_IL_03d8:
								break;
							}
							break;
						case 0:
						{
							byte[] bytes5 = webClient.UploadData("https://www.rfidfans.com/win/ddata.php", "POST", bytes4);
							text4 = Encoding.UTF8.GetString(bytes5);
							num = 0;
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
					Settings.Default.pcrqinlin = true;
					num = 8;
					num2 = num;
					break;
				case 13:
					Settings.Default.writecard_nohint = true;
					num = 15;
					num2 = num;
					break;
				case 0:
				case 11:
					num = 9;
					num2 = num;
					break;
				case 9:
					{
						if (!o.Checked)
						{
							Settings.Default.writecard_nohint = false;
							num = 6;
							num2 = num;
						}
						else
						{
							num = 13;
							num2 = num;
						}
						break;
					}
					end_IL_0042:
					break;
				}
			}
		}
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
		num = 15791;
		short num2 = num;
		num = 15791;
		switch (num2 == num)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		MessageBox.Show("暂时还没实现");
	}

	private void b(object A_0, EventArgs A_1)
	{
		short num = 0;
		_ = num;
		num = 9513;
		short num2 = num;
		num = 9513;
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

	private void a(object A_0, EventArgs A_1)
	{
		short num = 0;
		_ = num;
		num = -27821;
		short num2 = num;
		num = -27821;
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
					num = 0;
					_ = num;
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
						num = 1;
						num2 = num;
						continue;
					}
					goto IL_014e;
				case 2:
					this.m_b.Dispose();
					num = 3;
					num2 = num;
					continue;
				case 3:
				{
					num = 10071;
					short num3 = num;
					num = 10071;
					switch (num3 == num)
					{
					case false:
					case true:
						goto end_IL_0049;
					}
					num = 0;
					if (num == 0)
					{
					}
					goto IL_014e;
				}
				case 1:
					num = 4;
					num2 = num;
					continue;
				case 4:
					{
						num = 1;
						if (num != 0)
						{
						}
						if (this.m_b != null)
						{
							num = 2;
							num2 = num;
							continue;
						}
						goto IL_014e;
					}
					IL_014e:
					base.Dispose(disposing);
					return;
					end_IL_0049:
					break;
				}
				break;
			}
		}
	}

	private void a()
	{
		short num = 0;
		_ = num;
		num = 19207;
		short num2 = num;
		num = 19207;
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
		this.m_c = new Label();
		this.m_d = new Label();
		this.m_e = new CheckBox();
		this.m_f = new Label();
		g = new CheckBox();
		h = new Label();
		i = new CheckBox();
		j = new Button();
		k = new Button();
		l = new Label();
		m = new CheckBox();
		n = new Label();
		o = new CheckBox();
		SuspendLayout();
		this.m_c.AutoSize = true;
		this.m_c.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		this.m_c.Location = new Point(122, 26);
		this.m_c.Name = "label1";
		this.m_c.Size = new Size(72, 16);
		this.m_c.TabIndex = 0;
		this.m_c.Text = "参数设置";
		this.m_d.AutoSize = true;
		this.m_d.Location = new Point(14, 73);
		this.m_d.Name = "label2";
		this.m_d.Size = new Size(179, 12);
		this.m_d.TabIndex = 1;
		this.m_d.Text = "开始解卡/一键写卡为亲邻卡模式";
		this.m_e.AutoSize = true;
		this.m_e.Location = new Point(211, 73);
		this.m_e.Name = "checkBox1";
		this.m_e.Size = new Size(84, 16);
		this.m_e.TabIndex = 2;
		this.m_e.Text = "亲邻卡模式";
		this.m_e.UseVisualStyleBackColor = true;
		this.m_e.CheckedChanged += e;
		this.m_f.AutoSize = true;
		this.m_f.Location = new Point(14, 182);
		this.m_f.Name = "label3";
		this.m_f.Size = new Size(173, 12);
		this.m_f.TabIndex = 3;
		this.m_f.Text = "一键写卡为写卡之后再校验模式";
		g.AutoSize = true;
		g.Location = new Point(211, 182);
		g.Name = "checkBox2";
		g.Size = new Size(90, 16);
		g.TabIndex = 4;
		g.Text = "写-校验模式";
		g.UseVisualStyleBackColor = true;
		g.CheckedChanged += c;
		h.AutoSize = true;
		h.Location = new Point(14, 218);
		h.Name = "label4";
		h.Size = new Size(185, 12);
		h.TabIndex = 5;
		h.Text = "读卡数据的控制位和实际一致模式";
		i.AutoSize = true;
		i.Location = new Point(211, 218);
		i.Name = "checkBox3";
		i.Size = new Size(60, 16);
		i.TabIndex = 6;
		i.Text = "控制位";
		i.UseVisualStyleBackColor = true;
		i.CheckedChanged += a;
		j.Location = new Point(52, 269);
		j.Name = "button1";
		j.Size = new Size(96, 26);
		j.TabIndex = 7;
		j.Text = "确定修改";
		j.UseVisualStyleBackColor = true;
		j.Click += d;
		k.Location = new Point(187, 269);
		k.Name = "button2";
		k.Size = new Size(96, 26);
		k.TabIndex = 8;
		k.Text = "关闭窗口";
		k.UseVisualStyleBackColor = true;
		k.Click += b;
		l.AutoSize = true;
		l.Location = new Point(14, 112);
		l.Name = "label5";
		l.Size = new Size(101, 12);
		l.TabIndex = 9;
		l.Text = "是否使用历史密钥";
		m.AutoSize = true;
		m.Location = new Point(211, 108);
		m.Name = "checkBox4";
		m.Size = new Size(108, 16);
		m.TabIndex = 10;
		m.Text = "不使用历史密钥";
		m.UseVisualStyleBackColor = true;
		n.AutoSize = true;
		n.Location = new Point(14, 145);
		n.Name = "label6";
		n.Size = new Size(89, 12);
		n.TabIndex = 11;
		n.Text = "写卡时是否提示";
		o.AutoSize = true;
		o.Location = new Point(211, 144);
		o.Name = "checkBox5";
		o.Size = new Size(60, 16);
		o.TabIndex = 12;
		o.Text = "不提示";
		o.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new SizeF(6f, 12f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(349, 332);
		base.Controls.Add(o);
		base.Controls.Add(n);
		base.Controls.Add(m);
		base.Controls.Add(l);
		base.Controls.Add(k);
		base.Controls.Add(j);
		base.Controls.Add(i);
		base.Controls.Add(h);
		base.Controls.Add(g);
		base.Controls.Add(this.m_f);
		base.Controls.Add(this.m_e);
		base.Controls.Add(this.m_d);
		base.Controls.Add(this.m_c);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "parameters";
		base.ShowIcon = false;
		Text = "参数设置";
		base.Load += f;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
