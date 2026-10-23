using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MifareOneTool.Properties;

namespace MifareOneTool;

public class upload : Form
{
	private string m_a;

	private f m_b;

	private IContainer m_c;

	private Label m_d;

	private Label m_e;

	private Button m_f;

	private CheckBox g;

	private Label h;

	private ComboBox i;

	private TextBox j;

	private Button k;

	private Label l;

	private TextBox m;

	private TextBox n;

	public upload(string filename)
	{
		a();
		base.StartPosition = FormStartPosition.CenterScreen;
		m.Text = filename;
		i.Text = "80";
		this.m_a = filename;
	}

	private void f(object A_0, EventArgs A_1)
	{
		short num = 9476;
		short num2 = num;
		num = 9476;
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

	private void e(object A_0, EventArgs A_1)
	{
		short num = 30680;
		short num2 = num;
		num = 30680;
		switch (num2 == num)
		{
		}
		num = 0;
		_ = num;
		num = 0;
		if (num != 0)
		{
		}
		num = 1;
		if (num == 0)
		{
		}
	}

	private void d(object A_0, EventArgs A_1)
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
					short num2;
					if (Settings.Default.Lang.Equals("eng"))
					{
						num2 = 0;
						num = num2;
						continue;
					}
					openFileDialog.Title = Resources.请选择需要写入的MFD文件;
					num2 = -15424;
					short num3 = num2;
					num2 = -15424;
					switch (num3 == num2)
					{
					default:
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
					goto case 1;
				}
				case 0:
				{
					short num2 = 0;
					_ = num2;
					openFileDialog.Title = "please select the file you want write!";
					num2 = 3;
					num = num2;
					continue;
				}
				case 1:
				case 3:
					openFileDialog.Multiselect = false;
					return;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			short num2 = 1;
			if (num2 != 0)
			{
			}
			openFileDialog = new OpenFileDialog();
			openFileDialog.CheckFileExists = true;
			openFileDialog.Filter = Resources.MFD文件_mfd_dump;
			num2 = 2;
			num = num2;
			goto default;
		}
		}
	}

	private void c(object A_0, EventArgs A_1)
	{
		short num = 17439;
		short num2 = num;
		num = 17439;
		switch (num2 == num)
		{
		}
		num = 0;
		_ = num;
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

	private void b(object A_0, EventArgs A_1)
	{
		short num = -32437;
		short num2 = num;
		num = -32437;
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

	private void a(object A_0, EventArgs A_1)
	{
		short num = 0;
		int num2 = num;
		string text3 = default(string);
		string text5 = default(string);
		string text6 = default(string);
		string text = default(string);
		WebClient webClient2 = default(WebClient);
		byte[] bytes = default(byte[]);
		byte[] bytes2 = default(byte[]);
		string text8 = default(string);
		string text12 = default(string);
		int num3 = default(int);
		string text2 = default(string);
		byte[] bytes6 = default(byte[]);
		string text7 = default(string);
		switch (num2)
		{
		default:
			{
				switch (0)
				{
				case 0:
					goto IL_00a7;
				}
				goto IL_0028;
			}
			IL_0028:
			while (true)
			{
				switch (num2)
				{
				case 3:
				case 17:
				{
					string text4 = DateTime.Now.ToString();
					string address = "https://www.rfidfans.com/upload/upload.php";
					WebClient webClient = new WebClient();
					byte[] bytes3 = Encoding.Default.GetBytes(text4 + global::b.d(this.m_b.c()[0].f()[0]).Trim() + text3);
					text5 = BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(bytes3)).Replace("-", "");
					text6 = "nfc-data/tmp/" + text5 + ".dump";
					File.Copy(this.m_a, text6);
					webClient.QueryString = new NameValueCollection
					{
						{ "name", "file" },
						{ "filename", text6 }
					};
					byte[] bytes4 = webClient.UploadFile(address, "POST", text6);
					text = Encoding.ASCII.GetString(bytes4);
					num = 5;
					num2 = num;
					continue;
				}
				case 5:
					if (File.Exists(text6))
					{
						num = 27;
						num2 = num;
						continue;
					}
					goto case 14;
				case 7:
					num = 1;
					if (num != 0)
					{
					}
					MessageBox.Show("请选择下载需要积分");
					return;
				case 16:
					if (!(text3.Trim() == ""))
					{
						num = 18;
						num2 = num;
						continue;
					}
					goto case 24;
				case 1:
				{
					byte[] bytes7 = Encoding.Default.GetBytes(Settings.Default.pcrpassword);
					webClient2 = new WebClientto(2000);
					ServicePointManager.ServerCertificateValidationCallback = delegate
					{
						short num5 = 0;
						_ = num5;
						num5 = -31775;
						short num6 = num5;
						num5 = -31775;
						switch (num6 == num5)
						{
						default:
							num5 = 0;
							if (num5 != 0)
							{
							}
							num5 = 1;
							if (num5 != 0)
							{
							}
							return true;
						}
					};
					string text9 = Convert.ToBase64String(bytes);
					string text10 = Convert.ToBase64String(bytes2);
					string text11 = Convert.ToBase64String(bytes7);
					string s = "passA=" + text10 + "&passB=" + text9 + "&username=" + Settings.Default.pcrname + "&passc=" + text11 + "&city= " + text8 + "&district=&description=" + text3 + "&uid=" + text12 + "&uploadfilename=" + text5 + "&private=" + num3 + "&jifen_needpay=" + text2;
					bytes6 = Encoding.UTF8.GetBytes(s);
					webClient2.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
					webClient2.Headers.Add("ContentLength", bytes6.Length.ToString());
					num = 6;
					num2 = num;
					continue;
				}
				case 25:
					num = 2;
					num2 = num;
					continue;
				case 2:
					if (!(text8 == ""))
					{
						num = 16;
						num2 = num;
					}
					else
					{
						num = 28;
						num2 = num;
					}
					continue;
				case 6:
				{
					num = -16158;
					short num4 = num;
					num = -16158;
					switch (num4 == num)
					{
					default:
						num = 0;
						if (num != 0)
						{
						}
						try
						{
							switch (0)
							{
							default:
								while (true)
								{
									switch (num2)
									{
									case 2:
										if (text7.Trim() == "success")
										{
											num = 3;
											num2 = num;
										}
										else
										{
											MessageBox.Show(" 备份出错" + text7, "备份出错", MessageBoxButtons.OK, MessageBoxIcon.Hand);
											num = 1;
											num2 = num;
										}
										continue;
									case 3:
										MessageBox.Show("备份成功，你可以手机app+电脑软件》》通过我的云卡查看数据", "备份成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
										Close();
										num = 0;
										num2 = num;
										continue;
									case 0:
									case 1:
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
								byte[] bytes5 = webClient2.UploadData("https://www.rfidfans.com/win/adata.php", "POST", bytes6);
								text7 = Encoding.UTF8.GetString(bytes5);
								num = 2;
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
					case false:
					case true:
						break;
					}
					goto IL_05b9;
				}
				case 9:
					if (string.IsNullOrEmpty(i.Text))
					{
						num = 7;
						num2 = num;
					}
					else
					{
						text2 = i.SelectedItem.ToString();
						num = 29;
						num2 = num;
					}
					continue;
				case 18:
					num = 19;
					num2 = num;
					continue;
				case 19:
					if (text8.Trim() == "")
					{
						num = 24;
						num2 = num;
						continue;
					}
					goto IL_05b9;
				case 21:
					MessageBox.Show("城市区域 或者 小区名中不能有空格！");
					return;
				case 23:
					try
					{
						this.m_b.a(this.m_a);
					}
					catch (IOException ex2)
					{
						MessageBox.Show(ex2.Message, Resources.打开出错, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						this.m_b = new f();
						return;
					}
					text3 = j.Text;
					text8 = n.Text;
					text12 = Form1.hex(this.m_b.c()[0].f()[0].Skip(0).Take(4).ToArray());
					num = 15;
					num2 = num;
					continue;
				case 28:
					MessageBox.Show("城市区域 或者 小区名不能为空");
					return;
				case 24:
					MessageBox.Show("城市区域 或者 小区名不能为空格");
					return;
				case 4:
					if (!(text3.Trim() != text3))
					{
						num = 0;
						num2 = num;
						continue;
					}
					goto case 21;
				case 10:
					MessageBox.Show(text);
					return;
				case 27:
					File.Delete(text6);
					num = 14;
					num2 = num;
					continue;
				case 26:
					if (text3.Length >= 2)
					{
						num = 13;
						num2 = num;
						continue;
					}
					goto case 8;
				case 13:
					num = 12;
					num2 = num;
					continue;
				case 12:
					if (text8.Length >= 5)
					{
						num = 9;
						num2 = num;
					}
					else
					{
						num = 8;
						num2 = num;
					}
					continue;
				case 22:
					num3 = 0;
					num = 17;
					num2 = num;
					continue;
				case 0:
					num = 11;
					num2 = num;
					continue;
				case 11:
					if (!(text8.Trim() != text8))
					{
						num = 0;
						_ = num;
						num = 26;
						num2 = num;
					}
					else
					{
						num = 21;
						num2 = num;
					}
					continue;
				case 15:
					if (!(text3 == ""))
					{
						num = 25;
						num2 = num;
						continue;
					}
					goto case 28;
				case 8:
					MessageBox.Show("城市区域长度不能少于5，小区名长度不能少于2！");
					return;
				case 29:
					if (!g.Checked)
					{
						num3 = 1;
						num = 3;
						num2 = num;
					}
					else
					{
						num = 22;
						num2 = num;
					}
					continue;
				case 14:
					num = 20;
					num2 = num;
					continue;
				case 20:
					{
						if (text.Trim() == "success")
						{
							bytes = Encoding.Default.GetBytes("pcrwin");
							bytes2 = Encoding.Default.GetBytes("adddata");
							num = 1;
							num2 = num;
						}
						else
						{
							num = 10;
							num2 = num;
						}
						continue;
					}
					IL_05b9:
					num = 4;
					num2 = num;
					continue;
				}
				break;
			}
			goto IL_00a7;
			IL_00a7:
			this.m_b = new f();
			num = 23;
			num2 = num;
			goto IL_0028;
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
					num = 3;
					num2 = num;
					continue;
				}
				break;
			case 4:
				this.m_c.Dispose();
				num = 0;
				_ = num;
				num = 0;
				num2 = num;
				continue;
			case 0:
			{
				num = -22685;
				short num3 = num;
				num = -22685;
				switch (num3 == num)
				{
				default:
					num = 1;
					if (num != 0)
					{
					}
					num = 0;
					if (num == 0)
					{
					}
					break;
				case false:
				case true:
					break;
				}
				break;
			}
			case 3:
				num = 1;
				num2 = num;
				continue;
			case 1:
				if (this.m_c != null)
				{
					num = 4;
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
		short num = 0;
		_ = num;
		num = 7476;
		short num2 = num;
		num = 7476;
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
		this.m_d = new Label();
		this.m_e = new Label();
		this.m_f = new Button();
		g = new CheckBox();
		h = new Label();
		i = new ComboBox();
		j = new TextBox();
		k = new Button();
		l = new Label();
		m = new TextBox();
		n = new TextBox();
		SuspendLayout();
		this.m_d.AutoSize = true;
		this.m_d.Location = new Point(73, 35);
		this.m_d.Name = "label1";
		this.m_d.Size = new Size(95, 12);
		this.m_d.TabIndex = 6;
		this.m_d.Text = "请输入城市+区：";
		this.m_d.Click += b;
		this.m_e.AutoSize = true;
		this.m_e.Location = new Point(37, 84);
		this.m_e.Name = "label2";
		this.m_e.Size = new Size(131, 12);
		this.m_e.TabIndex = 7;
		this.m_e.Text = " 请填写备注名(小区)：\r\n";
		this.m_f.Location = new Point(97, 241);
		this.m_f.Name = "button1";
		this.m_f.Size = new Size(92, 23);
		this.m_f.TabIndex = 4;
		this.m_f.Text = "确定上传";
		this.m_f.UseVisualStyleBackColor = true;
		this.m_f.Click += a;
		g.AutoSize = true;
		g.Checked = true;
		g.CheckState = CheckState.Checked;
		g.Location = new Point(270, 192);
		g.Name = "checkBox1";
		g.Size = new Size(72, 16);
		g.TabIndex = 3;
		g.Text = "是否公开";
		g.UseVisualStyleBackColor = true;
		h.AutoSize = true;
		h.Location = new Point(67, 184);
		h.Name = "label3";
		h.Size = new Size(101, 24);
		h.TabIndex = 9;
		h.Text = "请选择他人下载该\r\n卡需要的金币数";
		i.DropDownStyle = ComboBoxStyle.DropDownList;
		i.FormattingEnabled = true;
		i.Items.AddRange(new object[3] { "80", "100", "120" });
		i.Location = new Point(177, 190);
		i.Name = "comboBox1";
		i.Size = new Size(69, 20);
		i.TabIndex = 2;
		j.Location = new Point(174, 81);
		j.Multiline = true;
		j.Name = "textBox1";
		j.Size = new Size(165, 24);
		j.TabIndex = 1;
		j.TextChanged += e;
		k.Location = new Point(220, 241);
		k.Name = "button2";
		k.Size = new Size(92, 23);
		k.TabIndex = 5;
		k.Text = "取消";
		k.UseVisualStyleBackColor = true;
		k.Click += c;
		l.AutoSize = true;
		l.Location = new Point(70, 125);
		l.Name = "label4";
		l.Size = new Size(101, 12);
		l.TabIndex = 8;
		l.Text = "你上传的文件为：";
		m.Enabled = false;
		m.Location = new Point(174, 122);
		m.Multiline = true;
		m.Name = "textBox2";
		m.Size = new Size(165, 53);
		m.TabIndex = 9;
		n.Location = new Point(174, 32);
		n.Multiline = true;
		n.Name = "textBox3";
		n.Size = new Size(165, 21);
		n.TabIndex = 0;
		n.Text = "深圳市福田区";
		base.AcceptButton = this.m_f;
		base.AutoScaleDimensions = new SizeF(6f, 12f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(396, 305);
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
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "upload";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		Text = "备份到卡云，随时随地都能用，审核通过奖励20-100金币";
		base.TopMost = true;
		base.Load += f;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
