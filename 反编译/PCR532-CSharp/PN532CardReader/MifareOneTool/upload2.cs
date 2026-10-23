using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using MifareOneTool.Properties;

namespace MifareOneTool;

public class upload2 : Form
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static RemoteCertificateValidationCallback _003C_003E9__6_0;

		public static RemoteCertificateValidationCallback _003C_003E9__6_1;

		public static RemoteCertificateValidationCallback _003C_003E9__6_2;

		public static RemoteCertificateValidationCallback _003C_003E9__10_0;

		static _003C_003Ec()
		{
			short num = -28600;
			short num2 = num;
			num = -28600;
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
			if (num != 0)
			{
			}
			_003C_003E9 = new _003C_003Ec();
		}

		internal bool a(object A_0, X509Certificate A_1, X509Chain A_2, SslPolicyErrors A_3)
		{
			short num = -24492;
			short num2 = num;
			num = -24492;
			switch (num2 == num)
			{
			default:
				num = 0;
				if (num != 0)
				{
				}
				num = 0;
				_ = num;
				num = 1;
				if (num != 0)
				{
				}
				return true;
			}
		}

		internal bool b(object A_0, X509Certificate A_1, X509Chain A_2, SslPolicyErrors A_3)
		{
			short num = 14442;
			short num2 = num;
			num = 14442;
			switch (num2 == num)
			{
			default:
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
				return true;
			}
		}

		internal bool c(object A_0, X509Certificate A_1, X509Chain A_2, SslPolicyErrors A_3)
		{
			short num = 24582;
			short num2 = num;
			num = 24582;
			switch (num2 == num)
			{
			default:
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
				return true;
			}
		}

		internal bool d(object A_0, X509Certificate A_1, X509Chain A_2, SslPolicyErrors A_3)
		{
			short num = 1;
			if (num != 0)
			{
			}
			num = -32505;
			short num2 = num;
			num = -32505;
			switch (num2 == num)
			{
			default:
				num = 0;
				_ = num;
				num = 0;
				if (num != 0)
				{
				}
				return true;
			}
		}
	}

	private string m_a;

	private int m_b;

	private f m_c = new f();

	private bool m_d;

	private cardneed.cardneed_cell m_e;

	private IContainer f;

	private TextBox g;

	private TextBox h;

	private Label i;

	private Button j;

	private TextBox k;

	private ComboBox l;

	private Label m;

	private CheckBox n;

	private Button o;

	private Label p;

	private Label q;

	private Label r;

	private Button s;

	private Button t;

	private TextBox u;

	private Label v;

	public upload2(string filename, int mode, cardneed.cardneed_cell cneed)
	{
		this.m_a = filename;
		this.m_b = mode;
		a();
		base.StartPosition = FormStartPosition.CenterScreen;
		h.Text = filename;
		this.m_e = cneed;
		if (mode == 0)
		{
			s.Visible = false;
			o.Text = "确定上传";
			h.Text = filename;
			l.Text = "368";
			this.m_c = new f();
			try
			{
				this.m_c.a(this.m_a);
			}
			catch (IOException ex)
			{
				MessageBox.Show(ex.Message, Resources.打开出错, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				this.m_c = new f();
				return;
			}
		}
		if (mode == 1)
		{
			o.Text = "删除该任务";
			s.Visible = false;
			l.Enabled = false;
			n.Visible = false;
			m.Visible = false;
			g.Text = cneed.city;
			k.Text = cneed.xiaoqu;
			u.Text = cneed.description;
			l.Text = cneed.jifen_needpay;
			l.Enabled = false;
			k.Enabled = false;
			g.Enabled = false;
			u.Enabled = false;
		}
		if (mode == 2)
		{
			o.Text = "我来解决";
			n.Visible = false;
			s.Visible = true;
			t.Visible = true;
			g.Text = cneed.city;
			k.Text = cneed.xiaoqu;
			u.Text = cneed.description;
			h.Text = "选择你的解决文件";
			i.Text = "你的解决文件为：";
			k.Enabled = false;
			g.Enabled = false;
			u.Enabled = false;
			l.Text = cneed.jifen_needpay;
			l.Enabled = false;
		}
		if (mode == 3)
		{
			o.Text = "数据有效";
			n.Visible = false;
			s.Visible = false;
			t.Text = "下载解决文件";
			t.Visible = true;
			l.Text = cneed.jifen_needpay;
			l.Enabled = false;
			g.Text = cneed.city;
			k.Text = cneed.xiaoqu;
			u.Text = cneed.description;
			k.Enabled = false;
			g.Enabled = false;
			u.Enabled = false;
		}
	}

	private void e(object A_0, EventArgs A_1)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			string text7 = default(string);
			string text6 = default(string);
			string text10 = default(string);
			string text8 = default(string);
			switch (0)
			{
			default:
			{
				string text25 = default(string);
				string text24 = default(string);
				string text27 = default(string);
				string text26 = default(string);
				byte[] bytes16 = default(byte[]);
				byte[] bytes17 = default(byte[]);
				WebClient webClient4 = default(WebClient);
				byte[] bytes14 = default(byte[]);
				string text19 = default(string);
				byte[] bytes11 = default(byte[]);
				byte[] bytes12 = default(byte[]);
				WebClient webClient3 = default(WebClient);
				byte[] bytes9 = default(byte[]);
				string text14 = default(string);
				string text9 = default(string);
				string text12 = default(string);
				string text11 = default(string);
				byte[] bytes4 = default(byte[]);
				byte[] bytes5 = default(byte[]);
				WebClient webClient = default(WebClient);
				byte[] bytes2 = default(byte[]);
				string text = default(string);
				while (true)
				{
					switch (num2)
					{
					case 41:
						if (this.m_b == 0)
						{
							num = 11;
							num2 = num;
							continue;
						}
						goto IL_0910;
					case 11:
						num = 44;
						num2 = num;
						continue;
					case 44:
						if (!(text7 == ""))
						{
							num = 42;
							num2 = num;
							continue;
						}
						goto case 1;
					case 42:
						num = 33;
						num2 = num;
						continue;
					case 33:
						if (!(text6 == ""))
						{
							num = 48;
							num2 = num;
							continue;
						}
						goto case 1;
					case 48:
						num = 8;
						num2 = num;
						continue;
					case 8:
						if (text10 == "")
						{
							num = 1;
							num2 = num;
							continue;
						}
						num = 0;
						_ = num;
						num = 30;
						num2 = num;
						continue;
					case 1:
						MessageBox.Show("城市区域 或者 小区名不能为空");
						return;
					case 30:
						if (!(text7.Trim() == ""))
						{
							num = 25;
							num2 = num;
							continue;
						}
						goto case 35;
					case 25:
						num = 12;
						num2 = num;
						continue;
					case 12:
						if (!(text6.Trim() == ""))
						{
							num = 31;
							num2 = num;
							continue;
						}
						goto case 35;
					case 31:
						num = 6;
						num2 = num;
						continue;
					case 6:
						if (text10.Trim() == "")
						{
							num = 35;
							num2 = num;
						}
						else
						{
							num = 20;
							num2 = num;
						}
						continue;
					case 35:
						MessageBox.Show("城市区域 或者 小区名不能为空格");
						return;
					case 20:
						if (!(text7.Trim() != text7))
						{
							num = 46;
							num2 = num;
							continue;
						}
						goto case 14;
					case 46:
						num = 47;
						num2 = num;
						continue;
					case 47:
						if (text6.Trim() != text6)
						{
							num = 14;
							num2 = num;
						}
						else
						{
							num = 15;
							num2 = num;
						}
						continue;
					case 14:
						MessageBox.Show("城市区域 或者 小区名中不能有空格！");
						return;
					case 15:
						if (text7.Length >= 2)
						{
							num = 17;
							num2 = num;
							continue;
						}
						goto case 26;
					case 17:
						num = 4;
						num2 = num;
						continue;
					case 4:
						if (text6.Length < 5)
						{
							num = 26;
							num2 = num;
						}
						else
						{
							num = 18;
							num2 = num;
						}
						continue;
					case 26:
						MessageBox.Show("城市区域长度不能少于5，小区名长度不能少于2！");
						return;
					case 18:
					{
						if (string.IsNullOrEmpty(l.Text))
						{
							num = 2;
							num2 = num;
							continue;
						}
						text25 = l.SelectedItem.ToString();
						string text28 = DateTime.Now.ToString();
						string address2 = "http://121.5.38.228/upload/upload.php";
						WebClient webClient5 = new WebClient();
						byte[] bytes18 = Encoding.Default.GetBytes(text28 + this.m_c.c()[0].f()[0].ToString() + text7);
						text24 = BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(bytes18)).Replace("-", "");
						text27 = "nfc-data/tmp/" + text24 + ".dump";
						File.Copy(this.m_a, text27);
						webClient5.QueryString = new NameValueCollection
						{
							{ "name", "file" },
							{ "filename", text27 }
						};
						byte[] bytes19 = webClient5.UploadFile(address2, "POST", text27);
						text26 = Encoding.ASCII.GetString(bytes19);
						num = 45;
						num2 = num;
						continue;
					}
					case 2:
						MessageBox.Show("请选择下载需要积分");
						return;
					case 45:
						if (File.Exists(text27))
						{
							num = 24;
							num2 = num;
							continue;
						}
						goto case 9;
					case 24:
						File.Delete(text27);
						num = 9;
						num2 = num;
						continue;
					case 9:
						num = 38;
						num2 = num;
						continue;
					case 38:
						if (!(text26.Trim() == "success"))
						{
							num = 21;
							num2 = num;
							continue;
						}
						bytes16 = Encoding.Default.GetBytes("pcrwin");
						bytes17 = Encoding.Default.GetBytes("adddata");
						num = 32;
						num2 = num;
						continue;
					case 21:
						num = 1;
						if (num != 0)
						{
						}
						MessageBox.Show(text26);
						return;
					case 32:
					{
						byte[] bytes15 = Encoding.Default.GetBytes(Settings.Default.pcrpassword);
						webClient4 = new WebClientto(2000);
						ServicePointManager.ServerCertificateValidationCallback = delegate
						{
							short num4 = -24492;
							short num5 = num4;
							num4 = -24492;
							switch (num5 == num4)
							{
							default:
								num4 = 0;
								if (num4 != 0)
								{
								}
								num4 = 0;
								_ = num4;
								num4 = 1;
								if (num4 != 0)
								{
								}
								return true;
							}
						};
						string text20 = Convert.ToBase64String(bytes16);
						string text21 = Convert.ToBase64String(bytes17);
						string text22 = Convert.ToBase64String(bytes15);
						string text23 = "passA=" + text21 + "&passB=" + text20 + "&username=" + Settings.Default.pcrname + "&passc=" + text22 + "&city= " + text6 + "&district=&description=" + text7 + "&uid=" + text8 + "&uploadfilename=" + text24 + "&private=0&jifen_needpay=" + text25 + "&information=" + text10;
						bytes14 = Encoding.UTF8.GetBytes(text23);
						webClient4.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
						webClient4.Headers.Add("ContentLength", bytes14.Length.ToString());
						num = 16;
						num2 = num;
						continue;
					}
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
									case 4:
										if (text19.Trim() == "success")
										{
											num = 3;
											num2 = num;
										}
										else
										{
											MessageBox.Show(text19);
											num = 2;
											num2 = num;
										}
										continue;
									case 3:
										MessageBox.Show("需求发布成功，等待大神帮忙解决！");
										Close();
										num = 1;
										num2 = num;
										continue;
									case 2:
										return;
									case 1:
										num = 0;
										num2 = num;
										continue;
									case 0:
										goto end_IL_0819;
									}
									goto case 0;
									continue;
									end_IL_0819:
									break;
								}
								break;
							case 0:
							{
								byte[] bytes13 = webClient4.UploadData("https://www.rfidfans.com/win/adata_need.php", "POST", bytes14);
								text19 = Encoding.UTF8.GetString(bytes13);
								num = 4;
								num2 = num;
								goto default;
							}
							}
						}
						catch (Exception ex3)
						{
							Console.Write(ex3.Message);
						}
						goto IL_0910;
					case 39:
						if (this.m_b == 1)
						{
							num = 7;
							num2 = num;
							continue;
						}
						goto IL_0bfe;
					case 7:
						bytes11 = Encoding.Default.GetBytes("pcrwin");
						bytes12 = Encoding.Default.GetBytes("after_pub_need");
						num = 10;
						num2 = num;
						continue;
					case 10:
					{
						byte[] bytes10 = Encoding.Default.GetBytes(Settings.Default.pcrpassword);
						webClient3 = new WebClientto(2000);
						ServicePointManager.ServerCertificateValidationCallback = delegate
						{
							short num4 = 14442;
							short num5 = num4;
							num4 = 14442;
							switch (num5 == num4)
							{
							default:
								num4 = 1;
								if (num4 != 0)
								{
								}
								num4 = 0;
								_ = num4;
								num4 = 0;
								if (num4 != 0)
								{
								}
								return true;
							}
						};
						string text15 = Convert.ToBase64String(bytes11);
						string text16 = Convert.ToBase64String(bytes12);
						string text17 = Convert.ToBase64String(bytes10);
						string text18 = "passA=" + text16 + "&passB=" + text15 + "&username=" + Settings.Default.pcrname + "&passc=" + text17 + "&cardid=" + this.m_e.ID + "&operate=delete";
						bytes9 = Encoding.UTF8.GetBytes(text18);
						webClient3.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
						webClient3.Headers.Add("ContentLength", bytes9.Length.ToString());
						num = 29;
						num2 = num;
						continue;
					}
					case 29:
						try
						{
							switch (0)
							{
							default:
								while (true)
								{
									switch (num2)
									{
									case 4:
										if (text14.Trim() == "success")
										{
											num = -8283;
											short num3 = num;
											num = -8283;
											switch (num3 == num)
											{
											default:
												num = 0;
												if (num != 0)
												{
												}
												num = 3;
												num2 = num;
												continue;
											case false:
											case true:
												break;
											}
											goto IL_0bbe;
										}
										MessageBox.Show(text14);
										num = 1;
										num2 = num;
										continue;
									case 1:
										return;
									case 3:
										MessageBox.Show("删除需求成功");
										Close();
										goto IL_0bbe;
									case 2:
										num = 0;
										num2 = num;
										continue;
									case 0:
										goto end_IL_0abb;
										IL_0bbe:
										num = 2;
										num2 = num;
										continue;
									}
									goto case 0;
									continue;
									end_IL_0abb:
									break;
								}
								break;
							case 0:
							{
								byte[] bytes8 = webClient3.UploadData("https://www.rfidfans.com/win/after_pub_need.php", "POST", bytes9);
								text14 = Encoding.UTF8.GetString(bytes8);
								num = 4;
								num2 = num;
								goto default;
							}
							}
						}
						catch (Exception ex2)
						{
							Console.Write(ex2.Message);
						}
						goto IL_0bfe;
					case 34:
						if (this.m_b == 2)
						{
							num = 3;
							num2 = num;
							continue;
						}
						goto IL_10b0;
					case 3:
						num = 27;
						num2 = num;
						continue;
					case 27:
					{
						if (!this.m_d)
						{
							num = 37;
							num2 = num;
							continue;
						}
						string text13 = DateTime.Now.ToString();
						string address = "http://121.5.38.228/upload/upload.php";
						WebClient webClient2 = new WebClient();
						byte[] bytes6 = Encoding.Default.GetBytes(text13 + global::b.d(this.m_c.c()[0].f()[0]).Trim() + text7);
						text9 = BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(bytes6)).Replace("-", "");
						text12 = "nfc-data/tmp/" + text9 + ".dump";
						File.Copy(this.m_a, text12);
						webClient2.QueryString = new NameValueCollection
						{
							{ "name", "file" },
							{ "filename", text12 }
						};
						byte[] bytes7 = webClient2.UploadFile(address, "POST", text12);
						text11 = Encoding.ASCII.GetString(bytes7);
						num = 28;
						num2 = num;
						continue;
					}
					case 37:
						MessageBox.Show("请先选择解决文件！");
						return;
					case 28:
						if (File.Exists(text12))
						{
							num = 23;
							num2 = num;
							continue;
						}
						goto case 5;
					case 23:
						File.Delete(text12);
						num = 5;
						num2 = num;
						continue;
					case 5:
						num = 43;
						num2 = num;
						continue;
					case 43:
						if (!(text11.Trim() == "success"))
						{
							num = 13;
							num2 = num;
							continue;
						}
						bytes4 = Encoding.Default.GetBytes("pcrwin");
						bytes5 = Encoding.Default.GetBytes("add_need_data");
						num = 40;
						num2 = num;
						continue;
					case 13:
						MessageBox.Show(text11);
						return;
					case 40:
					{
						byte[] bytes3 = Encoding.Default.GetBytes(Settings.Default.pcrpassword);
						webClient = new WebClientto(2000);
						ServicePointManager.ServerCertificateValidationCallback = delegate
						{
							short num4 = 24582;
							short num5 = num4;
							num4 = 24582;
							switch (num5 == num4)
							{
							default:
								num4 = 1;
								if (num4 != 0)
								{
								}
								num4 = 0;
								_ = num4;
								num4 = 0;
								if (num4 != 0)
								{
								}
								return true;
							}
						};
						string text2 = Convert.ToBase64String(bytes4);
						string text3 = Convert.ToBase64String(bytes5);
						string text4 = Convert.ToBase64String(bytes3);
						string text5 = "passA=" + text3 + "&passB=" + text2 + "&username=" + Settings.Default.pcrname + "&passc=" + text4 + "&city= " + text6 + "&district=&description=" + text7 + "&uid=" + text8 + "&uploadfilename=" + text9 + "&private=0&jifen_needpay=120&information=" + text10 + "&cardid=" + this.m_e.ID;
						bytes2 = Encoding.UTF8.GetBytes(text5);
						webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
						webClient.Headers.Add("ContentLength", bytes2.Length.ToString());
						num = 19;
						num2 = num;
						continue;
					}
					case 19:
						try
						{
							switch (0)
							{
							default:
								while (true)
								{
									switch (num2)
									{
									case 4:
										if (text.Trim() == "success")
										{
											num = 3;
											num2 = num;
										}
										else
										{
											MessageBox.Show(text);
											num = 2;
											num2 = num;
										}
										continue;
									case 3:
										MessageBox.Show("上传成功，等待对方的测试结果！");
										Close();
										num = 1;
										num2 = num;
										continue;
									case 2:
										return;
									case 1:
										num = 0;
										num2 = num;
										continue;
									case 0:
										goto end_IL_0fb9;
									}
									goto case 0;
									continue;
									end_IL_0fb9:
									break;
								}
								break;
							case 0:
							{
								byte[] bytes = webClient.UploadData("https://www.rfidfans.com/win/adata.php", "POST", bytes2);
								text = Encoding.UTF8.GetString(bytes);
								num = 4;
								num2 = num;
								goto default;
							}
							}
						}
						catch (Exception ex)
						{
							Console.Write(ex.Message);
						}
						goto IL_10b0;
					case 36:
						if (this.m_b == 3)
						{
							num = 0;
							num2 = num;
							continue;
						}
						return;
					case 0:
						MessageBox.Show("谢谢评价！");
						num = 22;
						num2 = num;
						continue;
					case 22:
						return;
						IL_10b0:
						num = 36;
						num2 = num;
						continue;
						IL_0bfe:
						num = 34;
						num2 = num;
						continue;
						IL_0910:
						num = 39;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				text7 = k.Text;
				text6 = g.Text;
				text10 = u.Text;
				text8 = Form1.hex(this.m_c.c()[0].f()[0].Skip(0).Take(4).ToArray());
				num = 41;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private void d(object A_0, EventArgs A_1)
	{
		short num = 7176;
		short num2 = num;
		num = 7176;
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
		if (num == 0)
		{
		}
	}

	private void c(object A_0, EventArgs A_1)
	{
		short num = -11255;
		short num2 = num;
		num = -11255;
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
		Close();
	}

	private void b(object A_0, EventArgs A_1)
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
				case 9:
					if (Settings.Default.Lang.Equals("eng"))
					{
						short num2 = 6;
						num = num2;
					}
					else
					{
						openFileDialog.Title = Resources.请选择需要写入的MFD文件;
						short num2 = 8;
						num = num2;
					}
					continue;
				case 0:
				{
					short num2;
					if (this.m_c.e()[16] != 0)
					{
						num2 = 2;
						num = num2;
						continue;
					}
					h.Text = this.m_a;
					this.m_d = true;
					num2 = 4;
					num = num2;
					continue;
				}
				case 5:
				{
					try
					{
						this.m_c.a(this.m_a);
					}
					catch (IOException ex)
					{
						MessageBox.Show(ex.Message, Resources.打开出错, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						this.m_c = new f();
						return;
					}
					short num2 = 0;
					num = num2;
					continue;
				}
				case 2:
					MessageBox.Show(Resources.打开出错, Resources.打开出错, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				case 6:
				{
					openFileDialog.Title = "please select the file you want write!";
					short num2 = 10;
					num = num2;
					continue;
				}
				case 4:
				{
					short num2 = 1;
					if (num2 == 0)
					{
					}
					return;
				}
				case 3:
				{
					this.m_a = openFileDialog.FileName;
					short num2 = -28159;
					short num3 = num2;
					num2 = -28159;
					switch (num3 == num2)
					{
					default:
						num2 = 0;
						if (num2 != 0)
						{
						}
						num2 = 7;
						num = num2;
						continue;
					case false:
					case true:
						break;
					}
					goto case 7;
				}
				case 8:
				case 10:
				{
					openFileDialog.Multiselect = false;
					short num2 = 1;
					num = num2;
					continue;
				}
				case 1:
					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						short num2 = 3;
						num = num2;
						continue;
					}
					goto case 7;
				case 7:
				{
					this.m_c = new f();
					short num2 = 5;
					num = num2;
					continue;
				}
				}
				break;
			}
			goto case 0;
		case 0:
		{
			openFileDialog = new OpenFileDialog();
			openFileDialog.CheckFileExists = true;
			openFileDialog.Filter = Resources.MFD文件_mfd_dump;
			short num2 = 0;
			_ = num2;
			num2 = 9;
			num = num2;
			goto default;
		}
		}
	}

	private void a(object A_0, EventArgs A_1)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			WebClient webClient2 = default(WebClient);
			switch (0)
			{
			default:
			{
				string text5 = default(string);
				WebClient webClient = default(WebClient);
				byte[] bytes4 = default(byte[]);
				while (true)
				{
					RemoteCertificateValidationCallback remoteCertificateValidationCallback;
					switch (num2)
					{
					case 4:
						num = 0;
						_ = num;
						remoteCertificateValidationCallback = _003C_003Ec._003C_003E9__10_0;
						if (remoteCertificateValidationCallback == null)
						{
							num = 3;
							num2 = num;
							continue;
						}
						goto IL_00d9;
					case 0:
						if (this.m_b == 3)
						{
							num = 5;
							num2 = num;
						}
						else
						{
							MessageBox.Show("下载完成，已经保存在dumpfiles/" + this.m_e.xiaoqu + ".dump");
							num = 1;
							num2 = num;
						}
						continue;
					case 3:
						remoteCertificateValidationCallback = (_003C_003Ec._003C_003E9__10_0 = delegate
						{
							short num4 = 1;
							if (num4 != 0)
							{
							}
							num4 = -32505;
							short num5 = num4;
							num4 = -32505;
							switch (num5 == num4)
							{
							default:
								num4 = 0;
								_ = num4;
								num4 = 0;
								if (num4 != 0)
								{
								}
								return true;
							}
						});
						goto IL_00d9;
					case 5:
						MessageBox.Show("下载完成，已经保存在dumpfiles/" + this.m_e.xiaoqu + this.m_e.description + ".dump");
						return;
					case 2:
						try
						{
							num = 6;
							num2 = num;
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
									if (this.m_b == 2)
									{
										num = 3;
										num2 = num;
										continue;
									}
									goto case 0;
								case 1:
									try
									{
										short num3;
										switch (0)
										{
										default:
											while (true)
											{
												switch (num2)
												{
												case 2:
													goto IL_025f;
												case 3:
													MessageBox.Show(text5);
													num = 0;
													num2 = num;
													continue;
												case 0:
													goto IL_02ac;
												case 1:
													goto end_IL_0207;
												}
												break;
												IL_025f:
												if (!(text5.Trim() == "success"))
												{
													num = 3;
													num2 = num;
												}
												else
												{
													num = 1;
													num2 = num;
												}
											}
											goto case 0;
										case 0:
											{
												byte[] bytes5 = webClient.UploadData("https://www.rfidfans.com/win/ddata.php", "POST", bytes4);
												text5 = Encoding.UTF8.GetString(bytes5);
												goto IL_0249;
											}
											IL_02ac:
											num = -6316;
											num3 = num;
											num = -6316;
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
												goto IL_05e3;
											}
											goto IL_0249;
											IL_0249:
											num = 2;
											num2 = num;
											goto default;
											end_IL_0207:
											break;
										}
									}
									catch (Exception ex)
									{
										Console.Write(ex.Message);
									}
									webClient2.DownloadFile("https://www.rfidfans.com/upload/asdfghjkl/" + this.m_e.download_address + ".dump", "dumpfiles/" + this.m_e.xiaoqu + this.m_e.description + ".dump");
									num = 4;
									num2 = num;
									continue;
								case 0:
									num = 2;
									num2 = num;
									continue;
								case 2:
									if (this.m_b == 3)
									{
										num = 7;
										num2 = num;
										continue;
									}
									break;
								case 3:
									webClient2.DownloadFile("https://www.rfidfans.com/upload/asdfghjkl/" + this.m_e.upload_address + ".dump", "dumpfiles/" + this.m_e.xiaoqu + ".dump");
									num = 0;
									num2 = num;
									continue;
								case 7:
								{
									byte[] bytes = Encoding.Default.GetBytes("pcrwin");
									byte[] bytes2 = Encoding.Default.GetBytes("add_need_finish");
									byte[] bytes3 = Encoding.Default.GetBytes(Settings.Default.pcrpassword);
									webClient = new WebClientto(2000);
									string text = Convert.ToBase64String(bytes);
									string text2 = Convert.ToBase64String(bytes2);
									string text3 = Convert.ToBase64String(bytes3);
									string text4 = "passA=" + text2 + "&passB=" + text + "&username=" + Settings.Default.pcrname + "&passc=" + text3 + "&cardusername=" + this.m_e.finishusername + "&jifen_pay=" + this.m_e.jifen_needpay + "&cardid=" + this.m_e.ID + "&carduid=" + this.m_e.carduid + "&description=" + this.m_e.city + this.m_e.xiaoqu + "&download_address=" + this.m_e.download_address;
									bytes4 = Encoding.UTF8.GetBytes(text4);
									webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
									webClient.Headers.Add("ContentLength", bytes4.Length.ToString());
									num = 1;
									num2 = num;
									continue;
								}
								case 4:
									break;
								case 5:
									goto end_IL_01b9;
								}
								num = 5;
								num2 = num;
								continue;
								end_IL_01b9:
								break;
							}
						}
						catch (Exception ex2)
						{
							Console.Write(ex2.Message);
							goto IL_05e3;
						}
						num = 0;
						num2 = num;
						continue;
					case 1:
						goto IL_05e3;
						IL_00d9:
						ServicePointManager.ServerCertificateValidationCallback = remoteCertificateValidationCallback;
						num = 2;
						num2 = num;
						continue;
						IL_05e3:
						num = 1;
						if (num == 0)
						{
						}
						return;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				webClient2 = new WebClientto(4000);
				num = 4;
				num2 = num;
				goto default;
			}
		}
		}
	}

	protected override void Dispose(bool disposing)
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
			{
				if (!disposing)
				{
					break;
				}
				num = 0;
				_ = num;
				num = 16944;
				short num3 = num;
				num = 16944;
				switch (num3 == num)
				{
				default:
					num = 0;
					if (num != 0)
					{
					}
					num = 2;
					num2 = num;
					continue;
				case false:
				case true:
					break;
				}
				goto IL_00d7;
			}
			case 1:
				f.Dispose();
				goto IL_00d7;
			case 4:
				num = 1;
				if (num == 0)
				{
				}
				break;
			case 2:
				num = 0;
				num2 = num;
				continue;
			case 0:
				{
					if (f != null)
					{
						num = 1;
						num2 = num;
						continue;
					}
					break;
				}
				IL_00d7:
				num = 4;
				num2 = num;
				continue;
			}
			break;
		}
		base.Dispose(disposing);
	}

	private void a()
	{
		short num = -31972;
		short num2 = num;
		num = -31972;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(upload2));
		g = new TextBox();
		h = new TextBox();
		i = new Label();
		j = new Button();
		k = new TextBox();
		l = new ComboBox();
		m = new Label();
		n = new CheckBox();
		o = new Button();
		p = new Label();
		q = new Label();
		r = new Label();
		s = new Button();
		t = new Button();
		u = new TextBox();
		v = new Label();
		SuspendLayout();
		g.Location = new Point(162, 55);
		g.Multiline = true;
		g.Name = "textBox3";
		g.Size = new Size(165, 21);
		g.TabIndex = 0;
		g.Text = "深圳市福田区";
		h.Enabled = false;
		h.Location = new Point(162, 155);
		h.Multiline = true;
		h.Name = "textBox2";
		h.Size = new Size(165, 43);
		h.TabIndex = 3;
		h.TextChanged += d;
		i.AutoSize = true;
		i.Location = new Point(58, 155);
		i.Name = "label4";
		i.Size = new Size(101, 12);
		i.TabIndex = 18;
		i.Text = "你的原始文件为：";
		j.Location = new Point(208, 264);
		j.Name = "button2";
		j.Size = new Size(92, 23);
		j.TabIndex = 6;
		j.Text = "取消";
		j.UseVisualStyleBackColor = true;
		j.Click += c;
		k.Location = new Point(162, 81);
		k.Multiline = true;
		k.Name = "textBox1";
		k.Size = new Size(165, 23);
		k.TabIndex = 1;
		l.DropDownStyle = ComboBoxStyle.DropDownList;
		l.FormattingEnabled = true;
		l.Items.AddRange(new object[7] { "368", "468", "666", "888", "999", "1399", "1688" });
		l.Location = new Point(165, 213);
		l.Name = "comboBox1";
		l.Size = new Size(69, 20);
		l.TabIndex = 4;
		m.AutoSize = true;
		m.Location = new Point(67, 216);
		m.Name = "label3";
		m.Size = new Size(89, 12);
		m.TabIndex = 20;
		m.Text = "悬赏的金币数：";
		n.AutoSize = true;
		n.Checked = true;
		n.CheckState = CheckState.Checked;
		n.Location = new Point(258, 215);
		n.Name = "checkBox1";
		n.Size = new Size(72, 16);
		n.TabIndex = 7;
		n.Text = "是否公开";
		n.UseVisualStyleBackColor = true;
		n.Visible = false;
		o.Location = new Point(85, 264);
		o.Name = "button1";
		o.Size = new Size(92, 23);
		o.TabIndex = 5;
		o.Text = "确定上传";
		o.UseVisualStyleBackColor = true;
		o.Click += e;
		p.AutoSize = true;
		p.Location = new Point(10, 84);
		p.Name = "label2";
		p.Size = new Size(149, 12);
		p.TabIndex = 17;
		p.Text = "    请填写备注名(小区)：";
		q.AutoSize = true;
		q.Location = new Point(61, 58);
		q.Name = "label1";
		q.Size = new Size(95, 12);
		q.TabIndex = 16;
		q.Text = "请输入城市+区：";
		r.AutoSize = true;
		r.Location = new Point(2, 18);
		r.Name = "label5";
		r.Size = new Size(383, 24);
		r.TabIndex = 21;
		r.Text = "问题卡例如滚动码/需求通卡，你可以上传你的原始数据，然后悬赏金币\r\n大神会帮忙解决你的问题！";
		s.Location = new Point(60, 175);
		s.Name = "button3";
		s.Size = new Size(80, 23);
		s.TabIndex = 22;
		s.Text = "选择文件";
		s.UseVisualStyleBackColor = true;
		s.Click += b;
		t.Location = new Point(240, 213);
		t.Name = "button4";
		t.Size = new Size(98, 23);
		t.TabIndex = 23;
		t.Text = "下载原始文件";
		t.UseVisualStyleBackColor = true;
		t.Visible = false;
		t.Click += a;
		u.Location = new Point(162, 110);
		u.Multiline = true;
		u.Name = "textBox4";
		u.Size = new Size(165, 23);
		u.TabIndex = 2;
		v.AutoSize = true;
		v.Location = new Point(7, 113);
		v.Name = "label6";
		v.Size = new Size(149, 12);
		v.TabIndex = 25;
		v.Text = " 你的需求(滚动码/通卡)：";
		base.AcceptButton = o;
		base.AutoScaleDimensions = new SizeF(6f, 12f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(385, 308);
		base.Controls.Add(v);
		base.Controls.Add(u);
		base.Controls.Add(t);
		base.Controls.Add(s);
		base.Controls.Add(r);
		base.Controls.Add(g);
		base.Controls.Add(h);
		base.Controls.Add(i);
		base.Controls.Add(j);
		base.Controls.Add(k);
		base.Controls.Add(l);
		base.Controls.Add(m);
		base.Controls.Add(n);
		base.Controls.Add(o);
		base.Controls.Add(p);
		base.Controls.Add(q);
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "upload2";
		Text = "发布/解决需求";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
