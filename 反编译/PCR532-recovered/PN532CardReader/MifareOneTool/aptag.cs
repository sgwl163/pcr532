using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MifareOneTool.Properties;
using Newtonsoft.Json;

namespace MifareOneTool;

public class aptag : Form
{
	private string m_a = "";

	private pntag m_b;

	private IContainer m_c;

	private DataGridView m_d;

	private DataGridViewTextBoxColumn m_e;

	private DataGridViewTextBoxColumn m_f;

	private DataGridViewTextBoxColumn m_g;

	private TextBox m_h;

	private TextBox m_i;

	private Label m_j;

	private Button m_k;

	private ComboBox m_l;

	private Label m_m;

	private CheckBox m_n;

	private Label o;

	private Label p;

	private Button q;

	private Label r;

	private CheckBox s;

	private CheckBox t;

	private TextBox u;

	private Label v;

	private PictureBox w;

	private Button x;

	private Button y;

	private ImageList z;

	private GroupBox aa;

	private LinkLabel ab;

	private GroupBox ac;

	private LinkLabel ad;

	private ComboBox ae;

	private Button af;

	private Button ag;

	private Button ah;

	private Label ai;

	private Button aj;

	private Button ak;

	private Label al;

	private ComboBox am;

	private GroupBox an;

	private Button ao;

	private LinkLabel ap;

	public aptag()
	{
		a();
		x.Enabled = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		this.m_l.Text = "社交生活";
		ae.Text = "公开便签";
		am.Text = "风格一";
	}

	private void n(object A_0, EventArgs A_1)
	{
		short num;
		while (true)
		{
			num = 0;
			_ = num;
			if (!t.Checked)
			{
				break;
			}
			num = -7146;
			short num2 = num;
			num = -7146;
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
			x.Enabled = true;
			return;
		}
		num = 1;
		if (num != 0)
		{
		}
		x.Enabled = false;
	}

	private void m(object A_0, EventArgs A_1)
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
				case 1:
					num2 = 1;
					if (num2 != 0)
					{
					}
					if (Settings.Default.Lang.Equals("eng"))
					{
						num2 = 4;
						num = num2;
						continue;
					}
					openFileDialog.Title = Resources.请选择需要写入的MFD文件;
					goto IL_00fe;
				case 5:
				case 6:
					openFileDialog.Multiselect = false;
					num2 = 3;
					num = num2;
					continue;
				case 3:
					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						num2 = 0;
						num = num2;
						continue;
					}
					goto case 2;
				case 4:
					openFileDialog.Title = "please select the file you want write!";
					num2 = 6;
					num = num2;
					continue;
				case 0:
				{
					this.m_a = openFileDialog.FileName;
					w.Image = Image.FromFile(this.m_a);
					num2 = 1191;
					short num3 = num2;
					num2 = 1191;
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
						num2 = 2;
						num = num2;
						continue;
					}
					goto IL_00fe;
				}
				case 2:
					{
						num2 = 0;
						_ = num2;
						return;
					}
					IL_00fe:
					num2 = 5;
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
			openFileDialog.Filter = Resources.图片文件;
			short num2 = 1;
			num = num2;
			goto default;
		}
		}
	}

	private void l(object A_0, EventArgs A_1)
	{
		short num = 0;
		_ = num;
		num = -17978;
		short num2 = num;
		num = -17978;
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

	private void k(object A_0, EventArgs A_1)
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
				{
					string obj = ae.SelectedItem.ToString();
					if (obj == "公开便签")
					{
						ah.Text = "私有该便签";
						ag.Text = "无效该便签";
					}
					if (obj == "私有便签")
					{
						ah.Text = "公开该便签";
						ag.Text = "无效该便签";
					}
					if (obj == "无效便签")
					{
						num = 1;
						if (num != 0)
						{
						}
						num = 2;
						num2 = num;
						continue;
					}
					goto case 1;
				}
				case 2:
					break;
				case 1:
					num = 0;
					_ = num;
					return;
				}
				num = 21680;
				short num3 = num;
				num = 21680;
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
					ag.Text = "有效该便签";
					num = 1;
					num2 = num;
					continue;
				}
				break;
			}
		}
	}

	private void j(object A_0, EventArgs A_1)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 9;
			int num2 = num;
			string text12 = default(string);
			string text = default(string);
			string text6 = default(string);
			string text7 = default(string);
			int num6 = default(int);
			int num3 = default(int);
			WebClient webClient = default(WebClient);
			string text10 = default(string);
			byte[] bytes3 = default(byte[]);
			string text9 = default(string);
			byte[] bytes4 = default(byte[]);
			string text11 = default(string);
			string text2 = default(string);
			string text3 = default(string);
			int num5 = default(int);
			string text5 = default(string);
			byte[] bytes2 = default(byte[]);
			string text4 = default(string);
			while (true)
			{
				switch (num2)
				{
				case 9:
					switch (0)
					{
					default:
						goto end_IL_0040;
					case 0:
						break;
					}
					goto default;
				default:
					if (!(u.Text == ""))
					{
						num = 33;
						num2 = num;
						break;
					}
					goto case 12;
				case 33:
					num = 1;
					if (num != 0)
					{
					}
					num = 17;
					num2 = num;
					break;
				case 17:
					if (!(this.m_i.Text == ""))
					{
						num = 29;
						num2 = num;
						break;
					}
					goto case 12;
				case 0:
					MessageBox.Show("请选择一个分类", "请选择一个分类", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				case 13:
					File.Delete(text12);
					num = 25;
					num2 = num;
					break;
				case 4:
				{
					string text13 = DateTime.Now.ToString();
					string address = "http://121.5.38.228/ptag/upload.php";
					WebClient webClient2 = new WebClient();
					byte[] bytes5 = Encoding.Default.GetBytes(text13 + text);
					text6 = BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(bytes5)).Replace("-", "");
					text12 = "nfc-data/tmp/" + text6 + ".jpg";
					File.Copy(this.m_a, text12);
					webClient2.QueryString = new NameValueCollection
					{
						{ "name", "file" },
						{ "filename", text12 }
					};
					byte[] bytes6 = webClient2.UploadFile(address, "POST", text12);
					text7 = Encoding.ASCII.GetString(bytes6);
					num = 6;
					num2 = num;
					break;
				}
				case 6:
					if (File.Exists(text12))
					{
						num = 13;
						num2 = num;
						break;
					}
					goto case 25;
				case 11:
					num = 28;
					num2 = num;
					break;
				case 28:
					if (this.m_a != "")
					{
						num = 4;
						num2 = num;
						break;
					}
					goto IL_03e0;
				case 37:
					num6 = 0;
					num = 27;
					num2 = num;
					break;
				case 3:
				case 30:
					text6 = "default";
					num = 34;
					num2 = num;
					break;
				case 34:
					if (num3 > 0)
					{
						num = 24;
						num2 = num;
						break;
					}
					goto IL_0810;
				case 38:
				{
					byte[] bytes7 = Encoding.Default.GetBytes(Settings.Default.pcrpassword);
					webClient = new WebClientto(2000);
					ServicePointManager.ServerCertificateValidationCallback = delegate
					{
						short num7 = -5173;
						short num8 = num7;
						num7 = -5173;
						switch (num8 == num7)
						{
						default:
							num7 = 0;
							_ = num7;
							num7 = 1;
							if (num7 != 0)
							{
							}
							num7 = 0;
							if (num7 != 0)
							{
							}
							return true;
						}
					};
					text10 = Convert.ToBase64String(bytes3);
					text9 = Convert.ToBase64String(bytes4);
					text11 = Convert.ToBase64String(bytes7);
					num = 31;
					num2 = num;
					break;
				}
				case 29:
					num = 14;
					num2 = num;
					break;
				case 14:
					if (!(this.m_h.Text == ""))
					{
						text = this.m_h.Text;
						text2 = u.Text;
						text3 = this.m_i.Text;
						num = 21;
						num2 = num;
					}
					else
					{
						num = 12;
						num2 = num;
					}
					break;
				case 12:
					MessageBox.Show("信息不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				case 7:
					MessageBox.Show("你选择了图片便签，但是没有上传图片", "你选择了图片便签，但是没有上传图片", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				case 16:
					num3 = 1;
					num = 30;
					num2 = num;
					break;
				case 27:
				case 39:
					num = 10;
					num2 = num;
					break;
				case 10:
					if (t.Checked)
					{
						num = 16;
						num2 = num;
					}
					else
					{
						num3 = 0;
						num = 3;
						num2 = num;
					}
					break;
				case 15:
				case 22:
					num = 5;
					num2 = num;
					break;
				case 5:
					if (!this.m_n.Checked)
					{
						num6 = 1;
						num = 39;
						num2 = num;
					}
					else
					{
						num = 37;
						num2 = num;
					}
					break;
				case 24:
					num = 19;
					num2 = num;
					break;
				case 19:
					if (this.m_a == "")
					{
						num = 7;
						num2 = num;
						break;
					}
					goto IL_0810;
				case 18:
					if (s.Checked)
					{
						num = 8;
						num2 = num;
					}
					else
					{
						num5 = 0;
						num = 15;
						num2 = num;
					}
					break;
				case 2:
					MessageBox.Show("请先登录", "请先登录", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					num = 20;
					num2 = num;
					break;
				case 32:
					MessageBox.Show(text7);
					num = 35;
					num2 = num;
					break;
				case 35:
					return;
				case 20:
				{
					string text8 = "passA=" + text9 + "&passB=" + text10 + "&username=" + Settings.Default.pcrname + "&passc=" + text11 + "&privateyesno=" + num6 + "&img_url=" + text6 + "&ptag_title=" + text + "&click_url=" + text2 + "&text=" + text3 + "&centent_classify=" + text5 + "&is_top=" + num5 + "&have_image=" + num3;
					bytes2 = Encoding.UTF8.GetBytes(text8);
					webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
					webClient.Headers.Add("ContentLength", bytes2.Length.ToString());
					num = 1;
					num2 = num;
					break;
				}
				case 25:
					num = 26;
					num2 = num;
					break;
				case 26:
					if (!(text7.Trim() == "success"))
					{
						num = 32;
						num2 = num;
						break;
					}
					goto IL_03e0;
				case 23:
					if (num3 > 0)
					{
						num = 11;
						num2 = num;
						break;
					}
					goto IL_03e0;
				case 31:
					if (Settings.Default.pcrname == "")
					{
						num = 2;
						num2 = num;
						break;
					}
					goto case 20;
				case 36:
					if (!string.IsNullOrEmpty(this.m_l.SelectedItem.ToString()))
					{
						text5 = this.m_l.SelectedItem.ToString();
						num = 18;
						num2 = num;
					}
					else
					{
						num = 0;
						_ = num;
						num = 0;
						num2 = num;
					}
					break;
				case 8:
					num5 = 1;
					num = 22;
					num2 = num;
					break;
				case 1:
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
								{
									num = 25001;
									short num4 = num;
									num = 25001;
									switch (num4 == num)
									{
									default:
										num = 0;
										if (num != 0)
										{
										}
										if (text4.Trim() == "success")
										{
											num = 3;
											num2 = num;
										}
										else
										{
											MessageBox.Show("添加出错", "添加出错" + text4, MessageBoxButtons.OK, MessageBoxIcon.Hand);
											num = 1;
											num2 = num;
										}
										continue;
									case false:
									case true:
										break;
									}
									goto case 3;
								}
								case 3:
									MessageBox.Show("添加成功！");
									num = 2;
									num2 = num;
									continue;
								case 1:
								case 2:
									num = 0;
									num2 = num;
									continue;
								case 0:
									return;
								}
								break;
							}
							goto case 0;
						case 0:
						{
							byte[] bytes = webClient.UploadData("https://www.rfidfans.com/ptag/adata.php", "POST", bytes2);
							text4 = Encoding.UTF8.GetString(bytes);
							num = 4;
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
				case 21:
					{
						try
						{
							text = this.m_h.Text.Trim();
							text2 = u.Text.Trim();
							text3 = this.m_i.Text.Trim();
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
							return;
						}
						num = 36;
						num2 = num;
						break;
					}
					IL_0810:
					num = 23;
					num2 = num;
					break;
					IL_03e0:
					bytes3 = Encoding.Default.GetBytes("pcrwin");
					bytes4 = Encoding.Default.GetBytes("addptag");
					num = 38;
					num2 = num;
					break;
					end_IL_0040:
					break;
				}
			}
		}
		}
	}

	private void i(object A_0, EventArgs A_1)
	{
		short num = 782;
		short num2 = num;
		num = 782;
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
	}

	private void h(object A_0, EventArgs A_1)
	{
		short num = 0;
		int num2 = num;
		WebClient webClient = default(WebClient);
		string text6 = default(string);
		byte[] bytes3 = default(byte[]);
		string text5 = default(string);
		byte[] bytes4 = default(byte[]);
		string text7 = default(string);
		int num3 = default(int);
		int num4 = default(int);
		string text3 = default(string);
		string text = default(string);
		int num5 = default(int);
		byte[] bytes2 = default(byte[]);
		switch (num2)
		{
		default:
			{
				switch (0)
				{
				case 0:
					goto IL_008b;
				}
				goto IL_0027;
			}
			IL_0027:
			while (true)
			{
				string text4;
				switch (num2)
				{
				case 11:
					if (Settings.Default.pcrpassword == "")
					{
						num = 7;
						num2 = num;
					}
					else
					{
						num = 5;
						num2 = num;
					}
					continue;
				case 17:
				{
					byte[] bytes5 = Encoding.Default.GetBytes(Settings.Default.pcrpassword);
					webClient = new WebClientto(1500);
					ServicePointManager.ServerCertificateValidationCallback = delegate
					{
						short num7 = 1;
						if (num7 != 0)
						{
						}
						num7 = -31915;
						short num8 = num7;
						num7 = -31915;
						switch (num8 == num7)
						{
						default:
							num7 = 0;
							_ = num7;
							break;
						case true:
							break;
						}
						num7 = 0;
						if (num7 != 0)
						{
						}
						return true;
					};
					text6 = Convert.ToBase64String(bytes3);
					text5 = Convert.ToBase64String(bytes4);
					text7 = Convert.ToBase64String(bytes5);
					num = 10;
					num2 = num;
					continue;
				}
				case 1:
					MessageBox.Show("请选择你要搜索的分类！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				case 13:
					num3 = 1;
					num4 = 1;
					num = 9;
					num2 = num;
					continue;
				case 12:
					if (!(text3 == ""))
					{
						num = 8;
						num2 = num;
						continue;
					}
					goto case 1;
				case 8:
					num = 2;
					num2 = num;
					continue;
				case 2:
					if (text3 != null)
					{
						num3 = 1;
						num4 = 1;
						bytes3 = Encoding.Default.GetBytes("pcrwin");
						bytes4 = Encoding.Default.GetBytes("customdata");
						num = 17;
						num2 = num;
					}
					else
					{
						num = 1;
						num2 = num;
					}
					continue;
				case 5:
					try
					{
						text3 = ae.SelectedItem.ToString();
					}
					catch (Exception ex2)
					{
						Console.WriteLine(ex2.Message);
						return;
					}
					num = 12;
					num2 = num;
					continue;
				case 4:
					num = 15;
					num2 = num;
					continue;
				case 15:
					if (text3 == "私有便签")
					{
						num = 13;
						num2 = num;
						continue;
					}
					goto case 9;
				case 7:
					MessageBox.Show("请先登录！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				case 9:
					num = 3;
					num2 = num;
					continue;
				case 3:
					if (text3 == "无效便签")
					{
						num = 0;
						num2 = num;
						continue;
					}
					goto IL_01da;
				case 10:
					if (text3 == "公开便签")
					{
						num = 14;
						num2 = num;
						continue;
					}
					goto case 4;
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
								case 1:
									if (text.Length < 40)
									{
										num = 7;
										num2 = num;
										continue;
									}
									this.m_b = JsonConvert.DeserializeObject<pntag>(text);
									num5 = 0;
									num = 3;
									num2 = num;
									continue;
								case 0:
								case 3:
									num = 6;
									num2 = num;
									continue;
								case 6:
								{
									if (num5 >= this.m_b.ppntag.Count)
									{
										num = 24929;
										short num6 = num;
										num = 24929;
										switch (num6 == num)
										{
										default:
											num = 0;
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
										goto IL_058a;
									}
									int index = this.m_d.Rows.Add();
									this.m_d.Rows[index].Cells[0].Value = this.m_b.ppntag[num5].centent_classify;
									this.m_d.Rows[index].Cells[1].Value = this.m_b.ppntag[num5].is_top;
									this.m_d.Rows[index].Cells[2].Value = this.m_b.ppntag[num5].ptag_title;
									num5++;
									num = 0;
									num2 = num;
									continue;
								}
								case 7:
									MessageBox.Show("还没有任何数据！", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									goto IL_058a;
								case 4:
									return;
								case 5:
									num = 2;
									num2 = num;
									continue;
								case 2:
									return;
									IL_058a:
									num = 4;
									num2 = num;
									continue;
								}
								break;
							}
							goto case 0;
						case 0:
						{
							byte[] bytes = webClient.UploadData("https://www.rfidfans.com/ptag/cdata.php", "POST", bytes2);
							string text2 = Encoding.UTF8.GetString(bytes);
							text = "{\"ppntag\":" + text2 + "}";
							num = 1;
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
					num3 = 1;
					num4 = 0;
					num = 4;
					num2 = num;
					continue;
				case 0:
					num3 = 0;
					num4 = 0;
					num = 6;
					num2 = num;
					continue;
				case 6:
					{
						num = 1;
						if (num == 0)
						{
						}
						goto IL_01da;
					}
					IL_01da:
					text4 = "passA=" + text5 + "&passB=" + text6 + "&username=" + Settings.Default.pcrname + "&passc=" + text7 + "&isvalid=" + num3 + "&isprivate=" + num4;
					bytes2 = Encoding.UTF8.GetBytes(text4);
					webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
					webClient.Headers.Add("ContentLength", bytes2.Length.ToString());
					this.m_d.Rows.Clear();
					num = 16;
					num2 = num;
					continue;
				}
				break;
			}
			goto IL_008b;
			IL_008b:
			num = 0;
			_ = num;
			text3 = "";
			num = 11;
			num2 = num;
			goto IL_0027;
		}
	}

	private void g(object A_0, EventArgs A_1)
	{
		int index;
		short num;
		try
		{
			num = 0;
			index = (int)num switch
			{
				_ => this.m_d.CurrentRow.Index, 
			};
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return;
		}
		int num2 = 1;
		byte[] bytes = Encoding.Default.GetBytes("pcrwin");
		byte[] bytes2 = Encoding.Default.GetBytes("mdata_setvalid");
		num = 3;
		int num3 = num;
		string text2 = default(string);
		string text3 = default(string);
		string text4 = default(string);
		byte[] bytes3 = default(byte[]);
		WebClient webClient = default(WebClient);
		string text5 = default(string);
		while (true)
		{
			switch (num3)
			{
			default:
			{
				string text = "passA=" + text2 + "&passB=" + text3 + "&username=" + Settings.Default.pcrname + "&passc=" + text4 + "&setvalid=" + num2 + "&ID=" + this.m_b.ppntag[index].ID;
				bytes3 = Encoding.UTF8.GetBytes(text);
				webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
				webClient.Headers.Add("ContentLength", bytes3.Length.ToString());
				num = 5;
				num3 = num;
				break;
			}
			case 0:
				num2 = 0;
				num = 4;
				num3 = num;
				break;
			case 4:
			{
				num = 11383;
				short num4 = num;
				num = 11383;
				switch (num4 == num)
				{
				case false:
				case true:
					goto IL_0395;
				}
				num = 0;
				if (num == 0)
				{
				}
				goto IL_0043;
			}
			case 3:
			{
				byte[] bytes5 = Encoding.Default.GetBytes(Settings.Default.pcrpassword);
				webClient = new WebClientto(1500);
				ServicePointManager.ServerCertificateValidationCallback = delegate
				{
					short num5 = 30566;
					short num6 = num5;
					num5 = 30566;
					switch (num6 == num5)
					{
					default:
						num5 = 0;
						_ = num5;
						num5 = 1;
						if (num5 != 0)
						{
						}
						num5 = 0;
						if (num5 != 0)
						{
						}
						return true;
					}
				};
				text3 = Convert.ToBase64String(bytes);
				text2 = Convert.ToBase64String(bytes2);
				text4 = Convert.ToBase64String(bytes5);
				goto IL_0395;
			}
			case 5:
				try
				{
					switch (0)
					{
					default:
						while (true)
						{
							switch (num3)
							{
							case 4:
								if (text5.Trim() == "success")
								{
									num = 3;
									num3 = num;
								}
								else
								{
									MessageBox.Show("设置出错" + text5, "设置出错", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									num = 1;
									num3 = num;
								}
								continue;
							case 3:
								MessageBox.Show("设置成功！");
								num = 2;
								num3 = num;
								continue;
							case 1:
							case 2:
								num = 0;
								num3 = num;
								continue;
							case 0:
								return;
							}
							break;
						}
						goto case 0;
					case 0:
					{
						byte[] bytes4 = webClient.UploadData("https://www.rfidfans.com/ptag/mmdata.php", "POST", bytes3);
						text5 = Encoding.UTF8.GetString(bytes4);
						num = 4;
						num3 = num;
						goto default;
					}
					}
				}
				catch (Exception ex2)
				{
					Console.Write(ex2.Message);
					return;
				}
			case 2:
				num = 0;
				_ = num;
				goto IL_0043;
			case 1:
				{
					if (this.m_b.ppntag[index].isvalid != 1)
					{
						num2 = 1;
						num = 2;
						num3 = num;
						break;
					}
					num = 1;
					if (num != 0)
					{
					}
					num = 0;
					num3 = num;
					break;
				}
				IL_0395:
				num = 1;
				num3 = num;
				break;
				IL_0043:
				switch (0)
				{
				default:
					goto end_IL_004f;
				case 0:
					break;
				}
				goto default;
				end_IL_004f:
				break;
			}
		}
	}

	private void f(object A_0, EventArgs A_1)
	{
		int index;
		short num;
		try
		{
			num = 0;
			index = (int)num switch
			{
				_ => this.m_d.CurrentRow.Index, 
			};
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return;
		}
		int num2 = 1;
		byte[] bytes = Encoding.Default.GetBytes("pcrwin");
		byte[] bytes2 = Encoding.Default.GetBytes("mdata_setprivate");
		num = 0;
		int num3 = num;
		string text3 = default(string);
		string text2 = default(string);
		string text4 = default(string);
		byte[] bytes4 = default(byte[]);
		WebClient webClient = default(WebClient);
		string text = default(string);
		while (true)
		{
			switch (num3)
			{
			case 4:
				switch (0)
				{
				default:
					goto end_IL_004e;
				case 0:
					break;
				}
				goto default;
			default:
			{
				string text5 = "passA=" + text3 + "&passB=" + text2 + "&username=" + Settings.Default.pcrname + "&passc=" + text4 + "&setprivate=" + num2 + "&ID=" + this.m_b.ppntag[index].ID;
				bytes4 = Encoding.UTF8.GetBytes(text5);
				webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
				webClient.Headers.Add("ContentLength", bytes4.Length.ToString());
				num = 3;
				num3 = num;
				break;
			}
			case 5:
				num2 = 0;
				num = 1;
				if (num != 0)
				{
				}
				num = 1;
				num3 = num;
				break;
			case 1:
			{
				num = -24057;
				short num4 = num;
				num = -24057;
				switch (num4 == num)
				{
				case false:
				case true:
					goto IL_03bd;
				}
				num = 0;
				if (num == 0)
				{
				}
				goto case 4;
			}
			case 0:
			{
				byte[] bytes5 = Encoding.Default.GetBytes(Settings.Default.pcrpassword);
				webClient = new WebClientto(1500);
				ServicePointManager.ServerCertificateValidationCallback = delegate
				{
					short num5 = 16490;
					short num6 = num5;
					num5 = 16490;
					switch (num6 == num5)
					{
					default:
						num5 = 0;
						_ = num5;
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
				text2 = Convert.ToBase64String(bytes);
				text3 = Convert.ToBase64String(bytes2);
				text4 = Convert.ToBase64String(bytes5);
				goto IL_03bd;
			}
			case 3:
				try
				{
					switch (0)
					{
					default:
						while (true)
						{
							switch (num3)
							{
							case 2:
								if (text.Trim() == "success")
								{
									num = 0;
									num3 = num;
								}
								else
								{
									MessageBox.Show("设置出错" + text, "设置出错", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									num = 1;
									num3 = num;
								}
								continue;
							case 0:
								MessageBox.Show("设置成功！");
								num = 3;
								num3 = num;
								continue;
							case 1:
							case 3:
								num = 4;
								num3 = num;
								continue;
							case 4:
								return;
							}
							break;
						}
						goto case 0;
					case 0:
					{
						byte[] bytes3 = webClient.UploadData("https://www.rfidfans.com/ptag/mmdata.php", "POST", bytes4);
						text = Encoding.UTF8.GetString(bytes3);
						num = 2;
						num3 = num;
						goto default;
					}
					}
				}
				catch (Exception ex2)
				{
					Console.Write(ex2.Message);
					return;
				}
			case 2:
				{
					if (this.m_b.ppntag[index].isprivate != 1)
					{
						num2 = 1;
						num = 0;
						_ = num;
						num = 4;
						num3 = num;
					}
					else
					{
						num = 5;
						num3 = num;
					}
					break;
				}
				IL_03bd:
				num = 2;
				num3 = num;
				break;
				end_IL_004e:
				break;
			}
		}
	}

	private void e(object A_0, EventArgs A_1)
	{
		int index;
		short num;
		try
		{
			num = 0;
			index = (int)num switch
			{
				_ => this.m_d.CurrentRow.Index, 
			};
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return;
		}
		int num2 = 1;
		byte[] bytes = Encoding.Default.GetBytes("pcrwin");
		byte[] bytes2 = Encoding.Default.GetBytes("mdata_settop");
		num = 0;
		int num3 = num;
		string text2 = default(string);
		string text3 = default(string);
		string text4 = default(string);
		byte[] bytes3 = default(byte[]);
		WebClient webClient = default(WebClient);
		string text5 = default(string);
		while (true)
		{
			switch (num3)
			{
			default:
			{
				string text = "passA=" + text2 + "&passB=" + text3 + "&username=" + Settings.Default.pcrname + "&passc=" + text4 + "&settop=" + num2 + "&ID=" + this.m_b.ppntag[index].ID;
				bytes3 = Encoding.UTF8.GetBytes(text);
				webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
				webClient.Headers.Add("ContentLength", bytes3.Length.ToString());
				num = 3;
				num3 = num;
				break;
			}
			case 5:
				num2 = 0;
				num = 1;
				num3 = num;
				break;
			case 1:
			{
				num = -29905;
				short num4 = num;
				num = -29905;
				switch (num4 == num)
				{
				case false:
				case true:
					goto IL_03bb;
				}
				num = 0;
				if (num == 0)
				{
				}
				goto IL_0043;
			}
			case 0:
			{
				byte[] bytes5 = Encoding.Default.GetBytes(Settings.Default.pcrpassword);
				webClient = new WebClientto(1500);
				ServicePointManager.ServerCertificateValidationCallback = delegate
				{
					short num5 = -26832;
					short num6 = num5;
					num5 = -26832;
					switch (num6 == num5)
					{
					default:
						num5 = 0;
						_ = num5;
						num5 = 1;
						if (num5 != 0)
						{
						}
						num5 = 0;
						if (num5 != 0)
						{
						}
						return true;
					}
				};
				text3 = Convert.ToBase64String(bytes);
				text2 = Convert.ToBase64String(bytes2);
				text4 = Convert.ToBase64String(bytes5);
				goto IL_03bb;
			}
			case 3:
				try
				{
					switch (0)
					{
					default:
						while (true)
						{
							switch (num3)
							{
							case 2:
								if (text5.Trim() == "success")
								{
									num = 0;
									num3 = num;
								}
								else
								{
									MessageBox.Show("设置出错" + text5, "设置出错", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									num = 1;
									num3 = num;
								}
								continue;
							case 0:
								MessageBox.Show("设置成功！");
								num = 3;
								num3 = num;
								continue;
							case 1:
							case 3:
								num = 4;
								num3 = num;
								continue;
							case 4:
								return;
							}
							break;
						}
						goto case 0;
					case 0:
					{
						byte[] bytes4 = webClient.UploadData("https://www.rfidfans.com/ptag/mmdata.php", "POST", bytes3);
						text5 = Encoding.UTF8.GetString(bytes4);
						num = 2;
						num3 = num;
						goto default;
					}
					}
				}
				catch (Exception ex2)
				{
					Console.Write(ex2.Message);
					return;
				}
			case 4:
				num = 0;
				_ = num;
				num = 1;
				if (num == 0)
				{
				}
				goto IL_0043;
			case 2:
				{
					if (this.m_b.ppntag[index].is_top != 1)
					{
						num2 = 1;
						num = 4;
						num3 = num;
					}
					else
					{
						num = 5;
						num3 = num;
					}
					break;
				}
				IL_03bb:
				num = 2;
				num3 = num;
				break;
				IL_0043:
				switch (0)
				{
				default:
					goto end_IL_004f;
				case 0:
					break;
				}
				goto default;
				end_IL_004f:
				break;
			}
		}
	}

	private void a(object A_0, DataGridViewCellEventArgs A_1)
	{
		int index;
		try
		{
			index = this.m_d.CurrentRow.Index;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return;
		}
		while (true)
		{
			this.m_h.Text = this.m_b.ppntag[index].ptag_title;
			this.m_i.Text = this.m_b.ppntag[index].text;
			u.Text = this.m_b.ppntag[index].click_url;
			short num = 4;
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
					t.Checked = true;
					num = 12;
					num2 = num;
					continue;
				case 10:
					break;
				case 5:
				case 12:
					num = 7;
					num2 = num;
					continue;
				case 7:
					if (this.m_b.ppntag[index].have_image == 1)
					{
						num = 9;
						num2 = num;
						continue;
					}
					return;
				case 4:
					if (this.m_b.ppntag[index].isprivate == 0)
					{
						num = 10;
						num2 = num;
						continue;
					}
					num = 0;
					_ = num;
					this.m_n.Checked = false;
					num = 14;
					num2 = num;
					continue;
				case 6:
				case 8:
					num = 1;
					num2 = num;
					continue;
				case 1:
					if (this.m_b.ppntag[index].have_image == 1)
					{
						num = 0;
						num2 = num;
						continue;
					}
					t.Checked = false;
					num = 1;
					if (num != 0)
					{
					}
					num = 5;
					num2 = num;
					continue;
				case 9:
				{
					string requestUriString = "https://www.rfidfans.com/ptag/asdfghjkl/" + this.m_b.ppntag[index].img_url + ".jpg";
					w.Image = Image.FromStream(WebRequest.Create(requestUriString).GetResponse().GetResponseStream());
					num = 3;
					num2 = num;
					continue;
				}
				case 3:
					return;
				case 11:
				case 14:
					num = 13;
					num2 = num;
					continue;
				case 13:
					if (this.m_b.ppntag[index].is_top != 1)
					{
						s.Checked = false;
						num = 6;
						num2 = num;
					}
					else
					{
						num = 2;
						num2 = num;
					}
					continue;
				case 2:
					s.Checked = true;
					num = 8;
					num2 = num;
					continue;
				}
				num = 8239;
				short num3 = num;
				num = 8239;
				switch (num3 == num)
				{
				default:
					num = 0;
					if (num != 0)
					{
					}
					this.m_n.Checked = true;
					num = 11;
					num2 = num;
					continue;
				case false:
				case true:
					break;
				}
				break;
			}
		}
	}

	private void d(object A_0, EventArgs A_1)
	{
		short num = -18556;
		short num2 = num;
		num = -18556;
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
		Process.Start("http://www.rfidfans.com/thread/26");
	}

	private void c(object A_0, EventArgs A_1)
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
		num = 2584;
		short num2 = num;
		num = 2584;
		switch (num2 == num)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		Close();
	}

	private void b(object A_0, EventArgs A_1)
	{
		short num = -5725;
		short num2 = num;
		num = -5725;
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
		string text = "designbyleon";
		byte[] bytes = Encoding.Default.GetBytes(Settings.Default.pcrname + text);
		string text2 = BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(bytes)).Replace("-", "").ToLower();
		Process.Start("http://www.rfidfans.com/ptag/index.php?uname=" + Settings.Default.pcrname + "&unicode=" + text2);
	}

	private void a(object A_0, EventArgs A_1)
	{
		short num = 3758;
		short num2 = num;
		num = 3758;
		int num3 = default(int);
		switch (num2 == num)
		{
		default:
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
			num = 0;
			num3 = num;
			switch (num3)
			{
			}
			break;
		case false:
		case true:
			break;
		}
		string text = am.Text;
		byte[] bytes = Encoding.Default.GetBytes("pcrwin");
		byte[] bytes2 = Encoding.Default.GetBytes("modifytheme");
		byte[] bytes3 = Encoding.Default.GetBytes(Settings.Default.pcrpassword);
		WebClient webClient = new WebClientto(2000);
		ServicePointManager.ServerCertificateValidationCallback = delegate
		{
			short num4 = 11623;
			short num5 = num4;
			num4 = 11623;
			switch (num5 == num4)
			{
			default:
				num4 = 0;
				_ = num4;
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
		string text2 = Convert.ToBase64String(bytes);
		string text3 = Convert.ToBase64String(bytes2);
		string text4 = Convert.ToBase64String(bytes3);
		string text5 = "passA=" + text3 + "&passB=" + text2 + "&username=" + Settings.Default.pcrname + "&passc=" + text4 + "&theme= " + text;
		byte[] bytes4 = Encoding.UTF8.GetBytes(text5);
		webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
		webClient.Headers.Add("ContentLength", bytes4.Length.ToString());
		try
		{
			string text6 = default(string);
			switch (0)
			{
			default:
				while (true)
				{
					switch (num3)
					{
					case 2:
						if (text6.Trim() == "success")
						{
							num = 0;
							num3 = num;
						}
						else
						{
							MessageBox.Show(text6);
							num = 3;
							num3 = num;
						}
						continue;
					case 0:
						MessageBox.Show("风格修改成功");
						num = 1;
						num3 = num;
						continue;
					case 1:
					case 3:
						num = 4;
						num3 = num;
						continue;
					case 4:
						return;
					}
					break;
				}
				goto case 0;
			case 0:
			{
				byte[] bytes5 = webClient.UploadData("https://www.rfidfans.com/win/addinfo.php", "POST", bytes4);
				text6 = Encoding.UTF8.GetString(bytes5);
				num = 2;
				num3 = num;
				goto default;
			}
			}
		}
		catch (Exception ex)
		{
			Console.Write(ex.Message);
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
					num = 0;
					num2 = num;
					continue;
				}
				break;
			case 0:
				num = 1;
				if (num != 0)
				{
				}
				num = 3;
				num2 = num;
				continue;
			case 3:
				if (this.m_c != null)
				{
					num = 0;
					_ = num;
					num = 4;
					num2 = num;
					continue;
				}
				break;
			case 4:
			{
				num = -2362;
				short num3 = num;
				num = -2362;
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
					this.m_c.Dispose();
					num = 1;
					num2 = num;
					continue;
				}
				goto case 0;
			}
			case 1:
				break;
			}
			break;
		}
		base.Dispose(disposing);
	}

	private void a()
	{
		short num = -30497;
		short num2 = num;
		num = -30497;
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
		this.m_c = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(aptag));
		this.m_d = new DataGridView();
		this.m_e = new DataGridViewTextBoxColumn();
		this.m_f = new DataGridViewTextBoxColumn();
		this.m_g = new DataGridViewTextBoxColumn();
		this.m_h = new TextBox();
		this.m_i = new TextBox();
		this.m_j = new Label();
		this.m_k = new Button();
		this.m_l = new ComboBox();
		this.m_m = new Label();
		this.m_n = new CheckBox();
		o = new Label();
		p = new Label();
		q = new Button();
		r = new Label();
		s = new CheckBox();
		t = new CheckBox();
		u = new TextBox();
		v = new Label();
		w = new PictureBox();
		x = new Button();
		y = new Button();
		z = new ImageList(this.m_c);
		aa = new GroupBox();
		aj = new Button();
		ai = new Label();
		ab = new LinkLabel();
		ak = new Button();
		ac = new GroupBox();
		ad = new LinkLabel();
		ae = new ComboBox();
		af = new Button();
		ag = new Button();
		ah = new Button();
		al = new Label();
		am = new ComboBox();
		an = new GroupBox();
		ao = new Button();
		ap = new LinkLabel();
		((ISupportInitialize)this.m_d).BeginInit();
		((ISupportInitialize)w).BeginInit();
		aa.SuspendLayout();
		ac.SuspendLayout();
		an.SuspendLayout();
		SuspendLayout();
		this.m_d.AllowUserToAddRows = false;
		this.m_d.AllowUserToDeleteRows = false;
		this.m_d.AllowUserToResizeColumns = false;
		this.m_d.AllowUserToResizeRows = false;
		this.m_d.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.m_d.Columns.AddRange(this.m_e, this.m_f, this.m_g);
		this.m_d.Location = new Point(316, 48);
		this.m_d.Name = "dataGridView1";
		this.m_d.ReadOnly = true;
		this.m_d.RowTemplate.Height = 23;
		this.m_d.Size = new Size(444, 454);
		this.m_d.TabIndex = 0;
		this.m_d.CellContentClick += a;
		this.m_e.HeaderText = "内容分类";
		this.m_e.Name = "Column1";
		this.m_e.ReadOnly = true;
		this.m_f.HeaderText = "是否置顶";
		this.m_f.Name = "Column5";
		this.m_f.ReadOnly = true;
		this.m_g.HeaderText = "内容简介";
		this.m_g.Name = "Column4";
		this.m_g.ReadOnly = true;
		this.m_g.Width = 200;
		this.m_h.Location = new Point(120, 17);
		this.m_h.Multiline = true;
		this.m_h.Name = "textBox3";
		this.m_h.Size = new Size(165, 21);
		this.m_h.TabIndex = 1;
		this.m_h.Text = "例如: 我的微信/我的行程码";
		this.m_h.TextChanged += i;
		this.m_i.Location = new Point(120, 117);
		this.m_i.Multiline = true;
		this.m_i.Name = "textBox2";
		this.m_i.Size = new Size(165, 53);
		this.m_i.TabIndex = 6;
		this.m_i.Text = "例如：微信号/公司简介（点击将会复制）";
		this.m_j.AutoSize = true;
		this.m_j.Location = new Point(19, 120);
		this.m_j.Name = "label4";
		this.m_j.Size = new Size(101, 12);
		this.m_j.TabIndex = 18;
		this.m_j.Text = "便签的具体内容：";
		this.m_k.Location = new Point(15, 428);
		this.m_k.Name = "button2";
		this.m_k.Size = new Size(84, 23);
		this.m_k.TabIndex = 9;
		this.m_k.Text = "确定添加";
		this.m_k.UseVisualStyleBackColor = true;
		this.m_k.Click += j;
		this.m_l.DropDownStyle = ComboBoxStyle.DropDownList;
		this.m_l.FormattingEnabled = true;
		this.m_l.Items.AddRange(new object[2] { "社交生活", "个人备忘录" });
		this.m_l.Location = new Point(123, 81);
		this.m_l.Name = "comboBox1";
		this.m_l.Size = new Size(104, 20);
		this.m_l.TabIndex = 5;
		this.m_m.AutoSize = true;
		this.m_m.Location = new Point(19, 248);
		this.m_m.Name = "label3";
		this.m_m.Size = new Size(77, 12);
		this.m_m.TabIndex = 20;
		this.m_m.Text = "便签图片信息";
		this.m_n.AutoSize = true;
		this.m_n.Checked = true;
		this.m_n.CheckState = CheckState.Checked;
		this.m_n.Location = new Point(21, 50);
		this.m_n.Name = "checkBox1";
		this.m_n.Size = new Size(72, 16);
		this.m_n.TabIndex = 2;
		this.m_n.Text = "是否公开";
		this.m_n.UseVisualStyleBackColor = true;
		o.AutoSize = true;
		o.Location = new Point(19, 84);
		o.Name = "label2";
		o.Size = new Size(65, 12);
		o.TabIndex = 17;
		o.Text = "便签分类：";
		p.AutoSize = true;
		p.Location = new Point(19, 20);
		p.Name = "label1";
		p.Size = new Size(65, 12);
		p.TabIndex = 16;
		p.Text = "便签标题：";
		q.Location = new Point(676, 12);
		q.Name = "button5";
		q.Size = new Size(82, 23);
		q.TabIndex = 14;
		q.Text = "置顶/取消置顶";
		q.UseVisualStyleBackColor = true;
		q.Click += e;
		r.AutoSize = true;
		r.Font = new Font("宋体", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
		r.Location = new Point(18, 20);
		r.Name = "label5";
		r.Size = new Size(256, 56);
		r.TabIndex = 0;
		r.Text = "电子便签：便于生活/社交，加微信\r\n好友 ，打开行程码/健康码直接碰一\r\n下一键搞定，家里/车上/公司/手机上\r\n都可以贴个ntag标签";
		s.AutoSize = true;
		s.Checked = true;
		s.CheckState = CheckState.Checked;
		s.Location = new Point(120, 50);
		s.Name = "checkBox2";
		s.Size = new Size(72, 16);
		s.TabIndex = 3;
		s.Text = "是否置顶";
		s.UseVisualStyleBackColor = true;
		t.AutoSize = true;
		t.Location = new Point(213, 50);
		t.Name = "checkBox3";
		t.Size = new Size(84, 16);
		t.TabIndex = 4;
		t.Text = "是否有图片";
		t.UseVisualStyleBackColor = true;
		t.CheckedChanged += n;
		u.Location = new Point(120, 185);
		u.Multiline = true;
		u.Name = "textBox4";
		u.Size = new Size(165, 53);
		u.TabIndex = 7;
		u.Text = "例如：weixin:// 或者公司网站 http://www.rfidfans.com 或者行程码地址";
		v.AutoSize = true;
		v.Location = new Point(19, 188);
		v.Name = "label6";
		v.Size = new Size(101, 12);
		v.TabIndex = 28;
		v.Text = "该便签对应网址：";
		w.Location = new Point(120, 248);
		w.Name = "pictureBox1";
		w.Size = new Size(165, 165);
		w.SizeMode = PictureBoxSizeMode.StretchImage;
		w.TabIndex = 30;
		w.TabStop = false;
		w.Click += l;
		x.Location = new Point(15, 355);
		x.Name = "button7";
		x.Size = new Size(84, 23);
		x.TabIndex = 8;
		x.Text = "选择图片";
		x.UseVisualStyleBackColor = true;
		x.Click += m;
		y.Location = new Point(108, 428);
		y.Name = "button6";
		y.Size = new Size(84, 23);
		y.TabIndex = 10;
		y.Text = "查看帮助";
		y.UseVisualStyleBackColor = true;
		y.Click += d;
		z.ColorDepth = ColorDepth.Depth8Bit;
		z.ImageSize = new Size(16, 16);
		z.TransparentColor = Color.Transparent;
		aa.BackColor = Color.Transparent;
		aa.Controls.Add(aj);
		aa.Controls.Add(ai);
		aa.Controls.Add(ab);
		aa.Controls.Add(x);
		aa.Controls.Add(p);
		aa.Controls.Add(w);
		aa.Controls.Add(o);
		aa.Controls.Add(y);
		aa.Controls.Add(this.m_n);
		aa.Controls.Add(v);
		aa.Controls.Add(this.m_m);
		aa.Controls.Add(u);
		aa.Controls.Add(this.m_l);
		aa.Controls.Add(t);
		aa.Controls.Add(this.m_k);
		aa.Controls.Add(s);
		aa.Controls.Add(this.m_j);
		aa.Controls.Add(this.m_i);
		aa.Controls.Add(this.m_h);
		aa.Location = new Point(5, 110);
		aa.Name = "groupBox19";
		aa.Size = new Size(302, 462);
		aa.TabIndex = 40;
		aa.TabStop = false;
		aa.Text = "便签添加";
		aj.Location = new Point(201, 428);
		aj.Name = "button8";
		aj.Size = new Size(84, 23);
		aj.TabIndex = 32;
		aj.Text = "关闭退出";
		aj.UseVisualStyleBackColor = true;
		aj.Click += c;
		ai.AutoSize = true;
		ai.Location = new Point(19, 283);
		ai.Name = "label7";
		ai.Size = new Size(83, 48);
		ai.TabIndex = 31;
		ai.Text = "为了美观，请\r\n先编辑好照片\r\n到1024x768,大\r\n小小于500k";
		ab.AutoSize = true;
		ab.ImeMode = ImeMode.NoControl;
		ab.Location = new Point(13, 20);
		ab.Name = "linkLabel11";
		ab.Size = new Size(0, 12);
		ab.TabIndex = 0;
		ak.Location = new Point(288, 24);
		ak.Name = "button9";
		ak.Size = new Size(84, 23);
		ak.TabIndex = 33;
		ak.Text = "预览便签";
		ak.UseVisualStyleBackColor = true;
		ak.Click += b;
		ac.BackColor = Color.Transparent;
		ac.Controls.Add(ad);
		ac.Controls.Add(r);
		ac.Location = new Point(5, 14);
		ac.Name = "groupBox1";
		ac.Size = new Size(302, 90);
		ac.TabIndex = 41;
		ac.TabStop = false;
		ac.Text = "Ntag便签简介";
		ad.AutoSize = true;
		ad.ImeMode = ImeMode.NoControl;
		ad.Location = new Point(13, 20);
		ad.Name = "linkLabel1";
		ad.Size = new Size(0, 12);
		ad.TabIndex = 0;
		ae.DropDownStyle = ComboBoxStyle.DropDownList;
		ae.FormattingEnabled = true;
		ae.Items.AddRange(new object[3] { "公开便签", "私有便签", "无效便签" });
		ae.Location = new Point(316, 14);
		ae.Name = "comboBox2";
		ae.Size = new Size(104, 20);
		ae.TabIndex = 42;
		ae.SelectedIndexChanged += k;
		af.Location = new Point(426, 12);
		af.Name = "button1";
		af.Size = new Size(78, 23);
		af.TabIndex = 43;
		af.Text = "搜索该分类";
		af.UseVisualStyleBackColor = true;
		af.Click += h;
		ag.Location = new Point(510, 12);
		ag.Name = "button3";
		ag.Size = new Size(77, 23);
		ag.TabIndex = 44;
		ag.Text = "有效该标签";
		ag.UseVisualStyleBackColor = true;
		ag.Click += g;
		ah.Location = new Point(593, 12);
		ah.Name = "button4";
		ah.Size = new Size(77, 23);
		ah.TabIndex = 45;
		ah.Text = "私有该标签";
		ah.UseVisualStyleBackColor = true;
		ah.Click += f;
		al.AutoSize = true;
		al.Location = new Point(14, 27);
		al.Name = "label8";
		al.Size = new Size(89, 12);
		al.TabIndex = 35;
		al.Text = "电子标签风格：";
		am.DropDownStyle = ComboBoxStyle.DropDownList;
		am.FormattingEnabled = true;
		am.Items.AddRange(new object[9] { "风格一", "风格二", "风格三", "风格四", "风格五", "风格六", "风格七", "风格八", "风格九" });
		am.Location = new Point(103, 24);
		am.Name = "comboBox3";
		am.Size = new Size(71, 20);
		am.TabIndex = 34;
		an.BackColor = Color.Transparent;
		an.Controls.Add(ao);
		an.Controls.Add(ap);
		an.Controls.Add(al);
		an.Controls.Add(am);
		an.Controls.Add(ak);
		an.Location = new Point(316, 516);
		an.Name = "groupBox2";
		an.Size = new Size(442, 56);
		an.TabIndex = 46;
		an.TabStop = false;
		an.Text = "Ntag便签简介";
		ao.Location = new Point(188, 24);
		ao.Name = "button10";
		ao.Size = new Size(84, 23);
		ao.TabIndex = 36;
		ao.Text = "确定提交";
		ao.UseVisualStyleBackColor = true;
		ao.Click += a;
		ap.AutoSize = true;
		ap.ImeMode = ImeMode.NoControl;
		ap.Location = new Point(13, 20);
		ap.Name = "linkLabel2";
		ap.Size = new Size(0, 12);
		ap.TabIndex = 0;
		base.AutoScaleDimensions = new SizeF(6f, 12f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(770, 580);
		base.Controls.Add(an);
		base.Controls.Add(ah);
		base.Controls.Add(ag);
		base.Controls.Add(af);
		base.Controls.Add(ae);
		base.Controls.Add(ac);
		base.Controls.Add(aa);
		base.Controls.Add(q);
		base.Controls.Add(this.m_d);
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "aptag";
		Text = "aptag";
		((ISupportInitialize)this.m_d).EndInit();
		((ISupportInitialize)w).EndInit();
		aa.ResumeLayout(performLayout: false);
		aa.PerformLayout();
		ac.ResumeLayout(performLayout: false);
		ac.PerformLayout();
		an.ResumeLayout(performLayout: false);
		an.PerformLayout();
		ResumeLayout(performLayout: false);
	}
}
