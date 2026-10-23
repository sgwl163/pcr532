using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Be.Windows.Forms;
using ChameleonMiniGUI.Dump;
using ChameleonMiniGUI.Json;
using ChameleonMiniGUI.Properties;
using Crapto1Sharp;

namespace ChameleonMiniGUI;

public class frm_main : Form
{
	private class a
	{
		public byte[] a;

		public byte[] b;
	}

	[CompilerGenerated]
	private sealed class b
	{
		public string a;

		internal void b(TextBox A_0)
		{
			short num = 0;
			_ = num;
			num = 1;
			if (num != 0)
			{
			}
			num = 18295;
			short num2 = num;
			num = 18295;
			switch (num2 == num)
			{
			}
			num = 0;
			if (num != 0)
			{
			}
			A_0.Text = a;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct c : IAsyncStateMachine
	{
		public int a;

		public AsyncVoidMethodBuilder b;

		public frm_main c;

		public string d;

		private RichTextBox m_e;

		private TaskAwaiter<object> f;

		private void e()
		{
			TaskAwaiter<object> awaiter = default(TaskAwaiter<object>);
			string text = default(string);
			while (true)
			{
				short num = 0;
				switch (num)
				{
				}
				num = 1;
				if (num != 0)
				{
				}
				int num2 = a;
				frm_main frm_main2 = c;
				try
				{
					num = 0;
					int num3 = num;
					while (true)
					{
						switch (num3)
						{
						case 7:
							break;
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
							if (num2 != 0)
							{
								num = 11;
								num3 = num;
								continue;
							}
							awaiter = f;
							f = default(TaskAwaiter<object>);
							num2 = (a = -1);
							num = 10;
							num3 = num;
							continue;
						case 11:
							this.m_e = frm_main2.fc;
							this.m_e.Focus();
							this.m_e.SelectedText = string.Empty;
							this.m_e.SelectionStart = this.m_e.TextLength;
							this.m_e.SelectionColor = Color.Goldenrod;
							this.m_e.AppendText(Environment.NewLine + "--> " + d);
							this.m_e.ScrollToCaret();
							num = 1;
							num3 = num;
							continue;
						case 1:
							if (d.ToLower().StartsWith("upload"))
							{
								num = 9;
								num3 = num;
							}
							else
							{
								num = 2;
								num3 = num;
							}
							continue;
						case 13:
							num2 = (a = 0);
							f = awaiter;
							b.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							num = 12;
							num3 = num;
							continue;
						case 12:
							goto end_IL_009b;
						case 10:
							text = awaiter.GetResult().ToString();
							num = 6;
							num3 = num;
							continue;
						case 4:
							text = "Putting Chameleon into upgrade mode";
							frm_main2.n("UPGRADE" + frm_main2.m_i);
							frm_main2.c();
							num = 8;
							num3 = num;
							continue;
						case 9:
							text = "This command is not supported in this serial interface. Use Operations tag to upload.";
							num = 3;
							num3 = num;
							continue;
						case 5:
							if (!awaiter.IsCompleted)
							{
								num = 13;
								num3 = num;
								continue;
							}
							goto case 10;
						case 2:
							if (!d.ToLower().StartsWith("upgrade"))
							{
								awaiter = frm_main2.j(d).GetAwaiter();
								num = 5;
								num3 = num;
							}
							else
							{
								num = 4;
								num3 = num;
							}
							continue;
						case 3:
						case 6:
						case 8:
							this.m_e.SelectedText = string.Empty;
							this.m_e.SelectionStart = this.m_e.TextLength;
							this.m_e.SelectionColor = this.m_e.ForeColor;
							this.m_e.AppendText(Environment.NewLine + text);
							this.m_e.ScrollToCaret();
							frm_main2.fd.Focus();
							num = 7;
							num3 = num;
							continue;
						}
						break;
					}
					goto IL_0069;
					end_IL_009b:;
				}
				catch (Exception exception)
				{
					a = -2;
					this.m_e = null;
					b.SetException(exception);
				}
				goto IL_0431;
				IL_0431:
				num = -15583;
				short num4 = num;
				num = -15583;
				switch (num4 == num)
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
				IL_0069:
				num = 0;
				_ = num;
				a = -2;
				this.m_e = null;
				b.SetResult();
				goto IL_0431;
			}
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in e
			this.e();
		}

		[DebuggerHidden]
		private void e(IAsyncStateMachine A_0)
		{
			short num = 13410;
			short num2 = num;
			num = 13410;
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
			b.SetStateMachine(A_0);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine A_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in e
			this.e(A_0);
		}
	}

	[CompilerGenerated]
	private sealed class d
	{
		public string a;

		internal bool b(string A_0)
		{
			short num = -24873;
			short num2 = num;
			num = -24873;
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
				num = 0;
				_ = num;
				return a.Contains(A_0);
			}
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct e : IAsyncStateMachine
	{
		public int a;

		public AsyncTaskMethodBuilder<object> b;

		public string c;

		public frm_main d;

		private byte[] m_e;

		private TaskAwaiter<int> f;

		private void e()
		{
			short num = -28419;
			short num2 = num;
			num = -28419;
			switch (num2 == num)
			{
			default:
				num = 0;
				_ = num;
				goto case true;
			case true:
				num = 1;
				if (num != 0)
				{
				}
				num = 0;
				if (num != 0)
				{
				}
				num = 0;
				switch (num)
				{
				}
				break;
			case false:
			case true:
				break;
			}
			int num3 = a;
			frm_main frm_main2 = d;
			object result = default(object);
			try
			{
				num = 0;
				int num4 = num;
				TaskAwaiter<int> awaiter = default(TaskAwaiter<int>);
				string text = default(string);
				StringBuilder stringBuilder = default(StringBuilder);
				int result2 = default(int);
				byte[] array2 = default(byte[]);
				int num5 = default(int);
				int num6 = default(int);
				byte[] array3 = default(byte[]);
				byte[] array = default(byte[]);
				while (true)
				{
					switch (num4)
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
						if (num3 != 0)
						{
							num = 8;
							num4 = num;
							continue;
						}
						goto IL_0150;
					case 8:
						num = 9;
						num4 = num;
						continue;
					case 9:
						if (string.IsNullOrWhiteSpace(c))
						{
							num = 1;
							num4 = num;
						}
						else
						{
							num = 2;
							num4 = num;
						}
						continue;
					case 7:
						result = string.Empty;
						num = 5;
						num4 = num;
						continue;
					case 5:
						break;
					case 6:
						try
						{
							num = 22;
							num4 = num;
							while (true)
							{
								switch (num4)
								{
								case 22:
									switch (0)
									{
									default:
										continue;
									case 0:
										break;
									}
									goto default;
								default:
									if (num3 != 0)
									{
										num = 11;
										num4 = num;
										continue;
									}
									awaiter = f;
									f = default(TaskAwaiter<int>);
									num3 = (a = -1);
									num = 18;
									num4 = num;
									continue;
								case 8:
									text += stringBuilder.ToString();
									num = 1;
									num4 = num;
									continue;
								case 17:
									if (text.Contains("110:WAITING FOR XMODEM"))
									{
										num = 24;
										num4 = num;
										continue;
									}
									break;
								case 11:
								{
									byte[] bytes = Encoding.ASCII.GetBytes(c);
									Thread.Sleep(10);
									frm_main2.m_a.Write(bytes, 0, bytes.Length);
									frm_main2.m_a.Write("\r\n");
									Thread.Sleep(100);
									int num7 = 512;
									CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
									this.m_e = new byte[num7];
									awaiter = frm_main2.m_a.BaseStream.ReadAsync(this.m_e, 0, num7, cancellationTokenSource.Token).GetAwaiter();
									num = 7;
									num4 = num;
									continue;
								}
								case 7:
									if (!awaiter.IsCompleted)
									{
										num = 13;
										num4 = num;
										continue;
									}
									goto case 18;
								case 2:
									result = string.Empty;
									num = 14;
									num4 = num;
									continue;
								case 14:
									goto end_IL_01ef;
								case 18:
									result2 = awaiter.GetResult();
									num = 5;
									num4 = num;
									continue;
								case 5:
									if (result2 <= 0)
									{
										num = 2;
										num4 = num;
										continue;
									}
									array2 = new byte[result2];
									Buffer.BlockCopy(this.m_e, 0, array2, 0, result2);
									num = 15;
									num4 = num;
									continue;
								case 3:
									num = 21;
									num4 = num;
									continue;
								case 21:
									if (c.Contains("DETECTION" + frm_main2.m_i + "?"))
									{
										num = 25;
										num4 = num;
										continue;
									}
									goto IL_02bc;
								case 19:
									num5++;
									num = 20;
									num4 = num;
									continue;
								case 9:
									if ((double)num6 > frm_main2.ByteWidth - 1.0)
									{
										num = 10;
										num4 = num;
										continue;
									}
									goto case 19;
								case 24:
									text = "110:WAITING FOR XMODEM" + Environment.NewLine;
									array3 = frm_main2.k();
									stringBuilder = new StringBuilder(array3.Length * 2);
									num = 12;
									num4 = num;
									continue;
								case 12:
									stringBuilder.Append(Environment.NewLine ?? "");
									num6 = 0;
									num = 27;
									num4 = num;
									continue;
								case 25:
								{
									byte[] array4 = new byte[result2];
									Array.Copy(this.m_e, 8, array4, 0, result2 - 7);
									string text2 = BitConverter.ToString(array4).Replace("-", " ");
									result = Environment.NewLine + text2 + Environment.NewLine;
									num = 28;
									num4 = num;
									continue;
								}
								case 28:
									goto end_IL_01ef;
								case 23:
									result = global::e.a(array3);
									num = 26;
									num4 = num;
									continue;
								case 26:
									goto end_IL_01ef;
								case 15:
									if (frm_main2.m_w == global::b.b)
									{
										num = 3;
										num4 = num;
										continue;
									}
									goto IL_02bc;
								case 10:
									num6 = 0;
									stringBuilder.Append(Environment.NewLine);
									num = 19;
									num4 = num;
									continue;
								case 27:
									if (c.Contains("LOGDOWNLOAD" + frm_main2.m_i))
									{
										num = 23;
										num4 = num;
										continue;
									}
									array = array3;
									num5 = 0;
									num = 16;
									num4 = num;
									continue;
								case 13:
									num3 = (a = 0);
									f = awaiter;
									this.b.AwaitUnsafeOnCompleted(ref awaiter, ref this);
									num = 4;
									num4 = num;
									continue;
								case 4:
									return;
								case 16:
								case 20:
									num = 6;
									num4 = num;
									continue;
								case 6:
									if (num5 < array.Length)
									{
										byte b = array[num5];
										stringBuilder.AppendFormat("{0:x2} ", b);
										num6++;
										num = 9;
										num4 = num;
									}
									else
									{
										num = 8;
										num4 = num;
									}
									continue;
								case 1:
									break;
								case 0:
									goto end_IL_01ef;
									IL_02bc:
									text = new string(Encoding.ASCII.GetChars(array2));
									num = 17;
									num4 = num;
									continue;
								}
								result = text;
								num = 0;
								num4 = num;
								continue;
								end_IL_01ef:
								break;
							}
						}
						catch (Exception ex)
						{
							string text3 = Environment.NewLine + "[!] " + ex.Message + Environment.NewLine;
							frm_main2.m_ar.AppendText(text3);
							result = string.Empty;
						}
						break;
					case 2:
						if (frm_main2.m_a != null)
						{
							num = 4;
							num4 = num;
							continue;
						}
						goto case 7;
					case 1:
						result = string.Empty;
						num = 10;
						num4 = num;
						continue;
					case 10:
						break;
					case 4:
						num = 3;
						num4 = num;
						continue;
					case 3:
						{
							if (!frm_main2.m_a.IsOpen)
							{
								num = 7;
								num4 = num;
								continue;
							}
							goto IL_0150;
						}
						IL_0150:
						num = 6;
						num4 = num;
						continue;
					}
					break;
				}
			}
			catch (Exception exception)
			{
				a = -2;
				this.b.SetException(exception);
				return;
			}
			a = -2;
			this.b.SetResult(result);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in e
			this.e();
		}

		[DebuggerHidden]
		private void e(IAsyncStateMachine A_0)
		{
			short num = -5006;
			short num2 = num;
			num = -5006;
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
			b.SetStateMachine(A_0);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine A_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in e
			this.e(A_0);
		}
	}

	[CompilerGenerated]
	private sealed class f
	{
		public string a;

		public string b;

		public string c;

		public string d;

		public string e;

		internal void f(ComboBox A_0)
		{
			short num = 8837;
			short num2 = num;
			num = 8837;
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
			A_0.SelectedItem = a;
		}

		internal void g(ComboBox A_0)
		{
			short num = -5372;
			short num2 = num;
			num = -5372;
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
			A_0.SelectedItem = b;
		}

		internal void h(ComboBox A_0)
		{
			short num = -29969;
			short num2 = num;
			num = -29969;
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
			A_0.SelectedItem = c;
		}

		internal void i(ComboBox A_0)
		{
			short num = -8309;
			short num2 = num;
			num = -8309;
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
			A_0.SelectedItem = d;
		}

		internal void j(ComboBox A_0)
		{
			short num = 1;
			if (num != 0)
			{
			}
			num = -32537;
			short num2 = num;
			num = -32537;
			switch (num2 == num)
			{
			}
			num = 0;
			if (num != 0)
			{
			}
			num = 0;
			_ = num;
			A_0.SelectedItem = e;
		}
	}

	[CompilerGenerated]
	private sealed class g
	{
		public string a;

		internal void b(ComboBox A_0)
		{
			short num = -8949;
			short num2 = num;
			num = -8949;
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
			A_0.SelectedItem = a;
		}
	}

	[CompilerGenerated]
	private sealed class h
	{
		public BackgroundWorker a;

		public frm_main b;

		public string c;

		internal void d(object A_0, DataReceivedEventArgs A_1)
		{
			short num = 0;
			int num2 = num;
			switch (num2)
			{
			default:
				switch (0)
				{
				default:
				{
					string pattern6 = default(string);
					int num4 = default(int);
					string[] array = default(string[]);
					List<string> list = default(List<string>);
					string pattern2 = default(string);
					string pattern7 = default(string);
					StreamWriter streamWriter = default(StreamWriter);
					string text = default(string);
					string pattern5 = default(string);
					string pattern3 = default(string);
					string pattern = default(string);
					string pattern4 = default(string);
					while (true)
					{
						switch (num2)
						{
						case 21:
							if (!string.IsNullOrEmpty(A_1.Data))
							{
								num = 27;
								num2 = num;
								continue;
							}
							return;
						case 13:
							b.m_ag = true;
							num = 16;
							num2 = num;
							continue;
						case 11:
							if (Regex.IsMatch(A_1.Data, pattern6))
							{
								num = 22;
								num2 = num;
								continue;
							}
							goto case 14;
						case 7:
						case 19:
							num = 29;
							num2 = num;
							continue;
						case 29:
						{
							if (num4 >= array.Length)
							{
								num = 4;
								num2 = num;
								continue;
							}
							string item = array[num4];
							list.Add(item);
							num4++;
							num = 7;
							num2 = num;
							continue;
						}
						case 5:
							pattern2 = "No\\sNFC\\sdevice\\sfound";
							num = 10;
							num2 = num;
							continue;
						case 10:
							if (Regex.IsMatch(A_1.Data, pattern2))
							{
								num = 18;
								num2 = num;
								continue;
							}
							goto case 17;
						case 24:
						{
							num = 0;
							_ = num;
							string[] array2 = File.ReadAllLines("auto_keys/h.dic");
							list = new List<string>
							{
								"ffffffffffff", "a0a1a2a3a4a5", "d3f7d3f7d3f7", "000000000000", "b0b1b2b3b4b5", "4d3a99c351dd", "1a982c7e459a", "aabbccddeeff", "714c5c886e97", "587ee5f9350f",
								"a0478cc39091", "533cb6c723f6", "8fd0a4f256e9"
							};
							array = array2;
							num4 = 0;
							num = 19;
							num2 = num;
							continue;
						}
						case 16:
							num = 8;
							num2 = num;
							continue;
						case 8:
							if (Regex.IsMatch(A_1.Data, pattern7))
							{
								num = 15;
								num2 = num;
								continue;
							}
							goto case 5;
						case 17:
							num = 26;
							num2 = num;
							continue;
						case 26:
							if (Regex.IsMatch(A_1.Data, b.m_ad))
							{
								num = 30;
								num2 = num;
								continue;
							}
							return;
						case 2:
							streamWriter.WriteLine(text);
							num = 12;
							num2 = num;
							continue;
						case 12:
							num = 1;
							if (num == 0)
							{
							}
							goto IL_0138;
						case 4:
							pattern5 = "Found\\sKey\\:\\sA\\s\\[([0-9A-Fa-f]{12})\\]";
							pattern3 = "Found\\sKey\\:\\sB\\s\\[([0-9A-Fa-f]{12})\\]";
							text = "";
							streamWriter = new StreamWriter(c, append: true);
							num = 25;
							num2 = num;
							continue;
						case 25:
							if (Regex.IsMatch(A_1.Data, pattern5))
							{
								num = 20;
								num2 = num;
								continue;
							}
							goto case 33;
						case 18:
							a.ReportProgress(107, "运行出错");
							num = 17;
							num2 = num;
							continue;
						case 30:
							a.ReportProgress(107, "运行出错");
							num = 1;
							num2 = num;
							continue;
						case 1:
							return;
						case 9:
							streamWriter.WriteLine(text);
							num = 33;
							num2 = num;
							continue;
						case 27:
							pattern = "UID\\s\\(NFCID[0-9]\\)\\: ([0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2})";
							num = 31;
							num2 = num;
							continue;
						case 31:
							if (!Regex.IsMatch(A_1.Data, pattern))
							{
								goto case 24;
							}
							num = 3;
							num2 = num;
							continue;
						case 20:
							text = Regex.Match(A_1.Data, pattern5).Captures[0].Value.Replace(" ", "").Replace("FoundKey:B", "").Replace("FoundKey:A", "")
								.Replace("[", "")
								.Replace("]", "");
							a.ReportProgress(0, "  发现新的keyA:  " + text);
							num = 0;
							num2 = num;
							continue;
						case 0:
						{
							num = 28684;
							short num3 = num;
							num = 28684;
							switch (num3 == num)
							{
							case false:
							case true:
								break;
							default:
								goto IL_063a;
							}
							goto case 7;
						}
						case 33:
							num = 23;
							num2 = num;
							continue;
						case 23:
							if (Regex.IsMatch(A_1.Data, pattern3))
							{
								num = 32;
								num2 = num;
								continue;
							}
							goto IL_0138;
						case 15:
							b.m_ah = true;
							num = 5;
							num2 = num;
							continue;
						case 14:
							num = 28;
							num2 = num;
							continue;
						case 28:
							if (Regex.IsMatch(A_1.Data, pattern4))
							{
								num = 13;
								num2 = num;
								continue;
							}
							goto case 16;
						case 32:
							text = Regex.Match(A_1.Data, pattern3).Captures[0].Value.Replace(" ", "").Replace("FoundKey:B", "").Replace("FoundKey:A", "")
								.Replace("[", "")
								.Replace("]", "");
							a.ReportProgress(0, "  发现新的keyB:  " + text);
							num = 6;
							num2 = num;
							continue;
						case 6:
							if (!list.Contains(text))
							{
								num = 2;
								num2 = num;
								continue;
							}
							goto IL_0138;
						case 3:
							b.m_aj = Regex.Match(A_1.Data, pattern).Captures[0].Value.Replace(" ", "").Replace("UID(NFCID1):", "").Replace("UID(NFCID3):", "")
								.Replace("UID(NFCID2):", "");
							a.ReportProgress(0, "  发现卡:  " + b.m_aj);
							num = 24;
							num2 = num;
							continue;
						case 22:
							{
								b.m_af = true;
								num = 14;
								num2 = num;
								continue;
							}
							IL_063a:
							num = 0;
							if (num != 0)
							{
							}
							if (!list.Contains(text))
							{
								num = 9;
								num2 = num;
								continue;
							}
							goto case 33;
							IL_0138:
							streamWriter.Close();
							pattern6 = "此卡为国产兼容卡";
							pattern4 = "此卡为无漏洞卡";
							pattern7 = "这个是全加密卡，可以尝试用 爆破全加密";
							num = 11;
							num2 = num;
							continue;
						}
						break;
					}
					goto case 0;
				}
				case 0:
					a.ReportProgress(0, A_1.Data);
					num = 21;
					num2 = num;
					goto default;
				}
			}
		}

		internal void e(object A_0, DataReceivedEventArgs A_1)
		{
			int num = default(int);
			switch (0)
			{
			default:
			{
				string pattern = default(string);
				while (true)
				{
					switch (num)
					{
					case 0:
					{
						if (string.IsNullOrEmpty(A_1.Data))
						{
							return;
						}
						short num2 = -12528;
						short num3 = num2;
						num2 = -12528;
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
							num2 = 2;
							num = num2;
							continue;
						case false:
						case true:
							break;
						}
						goto case 2;
					}
					case 5:
						if (Regex.IsMatch(A_1.Data, b.m_ad))
						{
							short num2 = 3;
							num = num2;
							continue;
						}
						return;
					case 1:
						a.ReportProgress(107, "运行出错");
						return;
					case 2:
					{
						pattern = "No\\sNFC\\sdevice\\sfound";
						short num2 = 0;
						_ = num2;
						num2 = 4;
						num = num2;
						continue;
					}
					case 4:
						if (!Regex.IsMatch(A_1.Data, pattern))
						{
							short num2 = 5;
							num = num2;
						}
						else
						{
							short num2 = 1;
							num = num2;
						}
						continue;
					case 3:
					{
						a.ReportProgress(107, "运行出错");
						short num2 = 6;
						num = num2;
						continue;
					}
					case 6:
						return;
					}
					break;
				}
				goto case 0;
			}
			case 0:
			{
				a.ReportProgress(0, A_1.Data);
				short num2 = 0;
				num = num2;
				goto default;
			}
			}
		}
	}

	[CompilerGenerated]
	private sealed class i
	{
		public BackgroundWorker a;

		public frm_main b;

		internal void c(object A_0, DataReceivedEventArgs A_1)
		{
			int num = default(int);
			switch (0)
			{
			default:
			{
				string pattern2 = default(string);
				string pattern = default(string);
				while (true)
				{
					switch (num)
					{
					case 1:
					{
						short num2 = 24008;
						short num3 = num2;
						num2 = 24008;
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
						if (!string.IsNullOrEmpty(A_1.Data))
						{
							num2 = 4;
							num = num2;
							continue;
						}
						return;
					}
					case 10:
					{
						short num2 = 6;
						num = num2;
						continue;
					}
					case 6:
						if (Regex.IsMatch(A_1.Data, b.m_ad))
						{
							short num2 = 2;
							num = num2;
							continue;
						}
						return;
					case 3:
					{
						pattern2 = "No\\sNFC\\sdevice\\sfound";
						short num2 = 9;
						num = num2;
						continue;
					}
					case 9:
						if (Regex.IsMatch(A_1.Data, pattern2))
						{
							short num2 = 5;
							num = num2;
							continue;
						}
						goto case 10;
					case 4:
					{
						pattern = "UID\\s\\(NFCID1\\)\\: ([0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2})";
						short num2 = 7;
						num = num2;
						continue;
					}
					case 7:
						if (Regex.IsMatch(A_1.Data, pattern))
						{
							short num2 = 8;
							num = num2;
							continue;
						}
						goto case 3;
					case 2:
					{
						a.ReportProgress(107, "运行出错");
						short num2 = 0;
						num = num2;
						continue;
					}
					case 0:
						return;
					case 8:
					{
						b.m_aj = Regex.Match(A_1.Data, pattern).Captures[0].Value.Replace(" ", "").Replace("UID(NFCID1):", "");
						short num2 = 0;
						_ = num2;
						num2 = 3;
						num = num2;
						continue;
					}
					case 5:
					{
						a.ReportProgress(107, "运行出错");
						short num2 = 10;
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
				a.ReportProgress(0, A_1.Data);
				short num2 = 1;
				num = num2;
				goto default;
			}
			}
		}

		internal void d(object A_0, DataReceivedEventArgs A_1)
		{
			int num = default(int);
			switch (0)
			{
			default:
			{
				string pattern = default(string);
				while (true)
				{
					switch (num)
					{
					case 0:
					{
						if (string.IsNullOrEmpty(A_1.Data))
						{
							return;
						}
						short num2 = 18009;
						short num3 = num2;
						num2 = 18009;
						switch (num3 == num2)
						{
						default:
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
						case false:
						case true:
							break;
						}
						goto case 2;
					}
					case 5:
						if (Regex.IsMatch(A_1.Data, b.m_ad))
						{
							short num2 = 3;
							num = num2;
							continue;
						}
						return;
					case 1:
						a.ReportProgress(107, "运行出错");
						return;
					case 2:
					{
						pattern = "No\\sNFC\\sdevice\\sfound";
						short num2 = 0;
						_ = num2;
						num2 = 4;
						num = num2;
						continue;
					}
					case 4:
						if (!Regex.IsMatch(A_1.Data, pattern))
						{
							short num2 = 5;
							num = num2;
						}
						else
						{
							short num2 = 1;
							num = num2;
						}
						continue;
					case 3:
					{
						a.ReportProgress(107, "运行出错");
						short num2 = 6;
						num = num2;
						continue;
					}
					case 6:
						return;
					}
					break;
				}
				goto case 0;
			}
			case 0:
			{
				a.ReportProgress(0, A_1.Data);
				short num2 = 0;
				num = num2;
				goto default;
			}
			}
		}
	}

	[CompilerGenerated]
	private sealed class j
	{
		public BackgroundWorker a;

		public frm_main b;

		internal void c(object A_0, DataReceivedEventArgs A_1)
		{
			int num = default(int);
			switch (0)
			{
			default:
			{
				string pattern2 = default(string);
				string pattern = default(string);
				while (true)
				{
					switch (num)
					{
					case 1:
					{
						short num2 = -5135;
						short num3 = num2;
						num2 = -5135;
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
						if (!string.IsNullOrEmpty(A_1.Data))
						{
							num2 = 4;
							num = num2;
							continue;
						}
						return;
					}
					case 10:
					{
						short num2 = 6;
						num = num2;
						continue;
					}
					case 6:
						if (Regex.IsMatch(A_1.Data, b.m_ad))
						{
							short num2 = 2;
							num = num2;
							continue;
						}
						return;
					case 3:
					{
						pattern2 = "No\\sNFC\\sdevice\\sfound";
						short num2 = 9;
						num = num2;
						continue;
					}
					case 9:
						if (Regex.IsMatch(A_1.Data, pattern2))
						{
							short num2 = 5;
							num = num2;
							continue;
						}
						goto case 10;
					case 4:
					{
						pattern = "UID\\s\\(NFCID1\\)\\: ([0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2})";
						short num2 = 7;
						num = num2;
						continue;
					}
					case 7:
						if (Regex.IsMatch(A_1.Data, pattern))
						{
							short num2 = 8;
							num = num2;
							continue;
						}
						goto case 3;
					case 2:
					{
						a.ReportProgress(107, "运行出错");
						short num2 = 0;
						num = num2;
						continue;
					}
					case 0:
						return;
					case 8:
					{
						b.m_aj = Regex.Match(A_1.Data, pattern).Captures[0].Value.Replace(" ", "").Replace("UID(NFCID1):", "");
						short num2 = 0;
						_ = num2;
						num2 = 3;
						num = num2;
						continue;
					}
					case 5:
					{
						a.ReportProgress(107, "运行出错");
						short num2 = 10;
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
				a.ReportProgress(0, A_1.Data);
				short num2 = 1;
				num = num2;
				goto default;
			}
			}
		}

		internal void d(object A_0, DataReceivedEventArgs A_1)
		{
			int num = default(int);
			switch (0)
			{
			default:
			{
				string pattern = default(string);
				while (true)
				{
					switch (num)
					{
					case 0:
					{
						if (string.IsNullOrEmpty(A_1.Data))
						{
							return;
						}
						short num2 = -26277;
						short num3 = num2;
						num2 = -26277;
						switch (num3 == num2)
						{
						default:
							num2 = 0;
							if (num2 != 0)
							{
							}
							num2 = 2;
							num = num2;
							continue;
						case false:
						case true:
							break;
						}
						goto case 2;
					}
					case 5:
						if (Regex.IsMatch(A_1.Data, b.m_ad))
						{
							short num2 = 3;
							num = num2;
							continue;
						}
						return;
					case 3:
					{
						short num2 = 1;
						if (num2 != 0)
						{
						}
						a.ReportProgress(107, "运行出错");
						num2 = 6;
						num = num2;
						continue;
					}
					case 1:
						a.ReportProgress(107, "运行出错");
						return;
					case 2:
					{
						pattern = "No\\sNFC\\sdevice\\sfound";
						short num2 = 0;
						_ = num2;
						num2 = 4;
						num = num2;
						continue;
					}
					case 4:
						if (!Regex.IsMatch(A_1.Data, pattern))
						{
							short num2 = 5;
							num = num2;
						}
						else
						{
							short num2 = 1;
							num = num2;
						}
						continue;
					case 6:
						return;
					}
					break;
				}
				goto case 0;
			}
			case 0:
			{
				a.ReportProgress(0, A_1.Data);
				short num2 = 0;
				num = num2;
				goto default;
			}
			}
		}
	}

	[CompilerGenerated]
	private sealed class k
	{
		public BackgroundWorker a;

		public frm_main b;

		internal void c(object A_0, DataReceivedEventArgs A_1)
		{
			int num = default(int);
			switch (0)
			{
			default:
			{
				string pattern2 = default(string);
				string pattern = default(string);
				while (true)
				{
					switch (num)
					{
					case 1:
					{
						short num2 = 32000;
						short num3 = num2;
						num2 = 32000;
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
						if (!string.IsNullOrEmpty(A_1.Data))
						{
							num2 = 4;
							num = num2;
							continue;
						}
						return;
					}
					case 10:
					{
						short num2 = 6;
						num = num2;
						continue;
					}
					case 6:
						if (Regex.IsMatch(A_1.Data, b.m_ad))
						{
							short num2 = 2;
							num = num2;
							continue;
						}
						return;
					case 3:
					{
						pattern2 = "No\\sNFC\\sdevice\\sfound";
						short num2 = 9;
						num = num2;
						continue;
					}
					case 9:
						if (Regex.IsMatch(A_1.Data, pattern2))
						{
							short num2 = 5;
							num = num2;
							continue;
						}
						goto case 10;
					case 4:
					{
						pattern = "UID\\s\\(NFCID1\\)\\: ([0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2})";
						short num2 = 7;
						num = num2;
						continue;
					}
					case 7:
						if (Regex.IsMatch(A_1.Data, pattern))
						{
							short num2 = 8;
							num = num2;
							continue;
						}
						goto case 3;
					case 8:
					{
						short num2 = 1;
						if (num2 != 0)
						{
						}
						b.m_aj = Regex.Match(A_1.Data, pattern).Captures[0].Value.Replace(" ", "").Replace("UID(NFCID1):", "");
						num2 = 0;
						_ = num2;
						num2 = 3;
						num = num2;
						continue;
					}
					case 2:
					{
						a.ReportProgress(107, "运行出错");
						short num2 = 0;
						num = num2;
						continue;
					}
					case 0:
						return;
					case 5:
					{
						a.ReportProgress(107, "运行出错");
						short num2 = 10;
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
				a.ReportProgress(0, A_1.Data);
				short num2 = 1;
				num = num2;
				goto default;
			}
			}
		}

		internal void d(object A_0, DataReceivedEventArgs A_1)
		{
			int num = default(int);
			switch (0)
			{
			default:
			{
				string pattern = default(string);
				while (true)
				{
					switch (num)
					{
					case 0:
					{
						if (string.IsNullOrEmpty(A_1.Data))
						{
							return;
						}
						short num2 = 29953;
						short num3 = num2;
						num2 = 29953;
						switch (num3 == num2)
						{
						default:
							num2 = 0;
							if (num2 != 0)
							{
							}
							num2 = 2;
							num = num2;
							continue;
						case false:
						case true:
							break;
						}
						goto case 2;
					}
					case 5:
						if (Regex.IsMatch(A_1.Data, b.m_ad))
						{
							short num2 = 3;
							num = num2;
							continue;
						}
						return;
					case 1:
					{
						short num2 = 1;
						if (num2 != 0)
						{
						}
						a.ReportProgress(107, "运行出错");
						return;
					}
					case 2:
					{
						pattern = "No\\sNFC\\sdevice\\sfound";
						short num2 = 0;
						_ = num2;
						num2 = 4;
						num = num2;
						continue;
					}
					case 4:
						if (!Regex.IsMatch(A_1.Data, pattern))
						{
							short num2 = 5;
							num = num2;
						}
						else
						{
							short num2 = 1;
							num = num2;
						}
						continue;
					case 3:
					{
						a.ReportProgress(107, "运行出错");
						short num2 = 6;
						num = num2;
						continue;
					}
					case 6:
						return;
					}
					break;
				}
				goto case 0;
			}
			case 0:
			{
				a.ReportProgress(0, A_1.Data);
				short num2 = 0;
				num = num2;
				goto default;
			}
			}
		}
	}

	[CompilerGenerated]
	private sealed class l
	{
		public BackgroundWorker a;

		public frm_main b;

		internal void c(object A_0, DataReceivedEventArgs A_1)
		{
			int num = default(int);
			switch (0)
			{
			default:
			{
				string pattern2 = default(string);
				string pattern = default(string);
				while (true)
				{
					switch (num)
					{
					case 1:
					{
						short num2 = -11931;
						short num3 = num2;
						num2 = -11931;
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
						if (!string.IsNullOrEmpty(A_1.Data))
						{
							num2 = 1;
							if (num2 != 0)
							{
							}
							num2 = 4;
							num = num2;
							continue;
						}
						return;
					}
					case 10:
					{
						short num2 = 6;
						num = num2;
						continue;
					}
					case 6:
						if (Regex.IsMatch(A_1.Data, b.m_ad))
						{
							short num2 = 2;
							num = num2;
							continue;
						}
						return;
					case 3:
					{
						pattern2 = "No\\sNFC\\sdevice\\sfound";
						short num2 = 9;
						num = num2;
						continue;
					}
					case 9:
						if (Regex.IsMatch(A_1.Data, pattern2))
						{
							short num2 = 5;
							num = num2;
							continue;
						}
						goto case 10;
					case 4:
					{
						pattern = "UID\\s\\(NFCID1\\)\\: ([0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2})";
						short num2 = 7;
						num = num2;
						continue;
					}
					case 7:
						if (Regex.IsMatch(A_1.Data, pattern))
						{
							short num2 = 8;
							num = num2;
							continue;
						}
						goto case 3;
					case 2:
					{
						a.ReportProgress(107, "运行出错");
						short num2 = 0;
						num = num2;
						continue;
					}
					case 0:
						return;
					case 8:
					{
						b.m_aj = Regex.Match(A_1.Data, pattern).Captures[0].Value.Replace(" ", "").Replace("UID(NFCID1):", "");
						short num2 = 0;
						_ = num2;
						num2 = 3;
						num = num2;
						continue;
					}
					case 5:
					{
						a.ReportProgress(107, "运行出错");
						short num2 = 10;
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
				a.ReportProgress(0, A_1.Data);
				short num2 = 1;
				num = num2;
				goto default;
			}
			}
		}

		internal void d(object A_0, DataReceivedEventArgs A_1)
		{
			int num = default(int);
			switch (0)
			{
			default:
			{
				string pattern = default(string);
				while (true)
				{
					switch (num)
					{
					case 0:
						if (!string.IsNullOrEmpty(A_1.Data))
						{
							short num2 = -3647;
							short num3 = num2;
							num2 = -3647;
							switch (num3 == num2)
							{
							default:
								num2 = 0;
								if (num2 != 0)
								{
								}
								num2 = 2;
								num = num2;
								continue;
							case false:
							case true:
								break;
							}
							goto case 2;
						}
						goto case 6;
					case 5:
						if (Regex.IsMatch(A_1.Data, b.m_ad))
						{
							short num2 = 3;
							num = num2;
							continue;
						}
						goto case 6;
					case 1:
						a.ReportProgress(107, "运行出错");
						return;
					case 2:
					{
						pattern = "No\\sNFC\\sdevice\\sfound";
						short num2 = 4;
						num = num2;
						continue;
					}
					case 4:
					{
						short num2 = 0;
						_ = num2;
						if (!Regex.IsMatch(A_1.Data, pattern))
						{
							num2 = 5;
							num = num2;
						}
						else
						{
							num2 = 1;
							num = num2;
						}
						continue;
					}
					case 3:
					{
						a.ReportProgress(107, "运行出错");
						short num2 = 6;
						num = num2;
						continue;
					}
					case 6:
					{
						short num2 = 1;
						if (num2 == 0)
						{
						}
						return;
					}
					}
					break;
				}
				goto case 0;
			}
			case 0:
			{
				a.ReportProgress(0, A_1.Data);
				short num2 = 0;
				num = num2;
				goto default;
			}
			}
		}
	}

	[CompilerGenerated]
	private sealed class m
	{
		public BackgroundWorker a;

		public frm_main b;

		internal void c(object A_0, DataReceivedEventArgs A_1)
		{
			short num = 0;
			int num2 = num;
			switch (num2)
			{
			default:
				switch (0)
				{
				default:
				{
					List<string> list = default(List<string>);
					string[] array = default(string[]);
					int num3 = default(int);
					string pattern5 = default(string);
					string pattern4 = default(string);
					string pattern2 = default(string);
					string pattern3 = default(string);
					string pattern = default(string);
					while (true)
					{
						switch (num2)
						{
						case 11:
							if (!string.IsNullOrEmpty(A_1.Data))
							{
								num = 10;
								num2 = num;
								continue;
							}
							return;
						case 19:
							b.m_ah = true;
							num = 3;
							num2 = num;
							continue;
						case 6:
							b.m_ag = true;
							num = 17;
							num2 = num;
							continue;
						case 14:
						{
							string[] array2 = File.ReadAllLines("auto_keys/h.dic");
							list = new List<string>
							{
								"ffffffffffff", "a0a1a2a3a4a5", "d3f7d3f7d3f7", "000000000000", "b0b1b2b3b4b5", "4d3a99c351dd", "1a982c7e459a", "aabbccddeeff", "714c5c886e97", "587ee5f9350f",
								"a0478cc39091", "533cb6c723f6", "8fd0a4f256e9"
							};
							array = array2;
							num3 = 0;
							num = 4;
							num2 = num;
							continue;
						}
						case 12:
							a.ReportProgress(107, "运行出错");
							num = 7;
							num2 = num;
							continue;
						case 16:
							b.m_aj = Regex.Match(A_1.Data, pattern5).Captures[0].Value.Replace(" ", "").Replace("UID(NFCID1):", "");
							b.a(b.m_aj);
							num = 14;
							num2 = num;
							continue;
						case 17:
							num = 0;
							num2 = num;
							continue;
						case 0:
							if (Regex.IsMatch(A_1.Data, pattern4))
							{
								num = 19;
								num2 = num;
								continue;
							}
							goto case 3;
						case 9:
							a.ReportProgress(107, "运行出错");
							num = 15;
							num2 = num;
							continue;
						case 15:
							return;
						case 18:
							b.m_af = true;
							num = 2;
							num2 = num;
							continue;
						case 7:
							num = 5;
							num2 = num;
							continue;
						case 5:
						{
							num = 1;
							if (num != 0)
							{
							}
							num = -2869;
							short num4 = num;
							num = -2869;
							switch (num4 == num)
							{
							case false:
							case true:
								break;
							default:
								num = 0;
								if (num != 0)
								{
								}
								if (Regex.IsMatch(A_1.Data, b.m_ad))
								{
									num = 9;
									num2 = num;
									continue;
								}
								return;
							}
							goto case 16;
						}
						case 3:
							pattern2 = "No\\sNFC\\sdevice\\sfound";
							num = 13;
							num2 = num;
							continue;
						case 13:
							if (Regex.IsMatch(A_1.Data, pattern2))
							{
								num = 12;
								num2 = num;
								continue;
							}
							goto case 7;
						case 4:
						case 22:
							num = 1;
							num2 = num;
							continue;
						case 1:
							if (num3 < array.Length)
							{
								num = 0;
								_ = num;
								string item = array[num3];
								list.Add(item);
								num3++;
								num = 22;
								num2 = num;
							}
							else
							{
								num = 20;
								num2 = num;
							}
							continue;
						case 10:
							pattern5 = "UID\\s\\(NFCID1\\)\\: ([0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2})";
							num = 21;
							num2 = num;
							continue;
						case 21:
							if (Regex.IsMatch(A_1.Data, pattern5))
							{
								num = 16;
								num2 = num;
								continue;
							}
							goto case 14;
						case 20:
							pattern3 = "此卡为国产兼容卡";
							pattern = "此卡为无漏洞卡";
							pattern4 = "这个是全加密卡，可以尝试用 爆破全加密";
							num = 8;
							num2 = num;
							continue;
						case 8:
							if (Regex.IsMatch(A_1.Data, pattern3))
							{
								num = 18;
								num2 = num;
								continue;
							}
							goto case 2;
						case 2:
							num = 23;
							num2 = num;
							continue;
						case 23:
							if (Regex.IsMatch(A_1.Data, pattern))
							{
								num = 6;
								num2 = num;
								continue;
							}
							goto case 17;
						}
						break;
					}
					goto case 0;
				}
				case 0:
					a.ReportProgress(0, A_1.Data);
					num = 11;
					num2 = num;
					goto default;
				}
			}
		}

		internal void d(object A_0, DataReceivedEventArgs A_1)
		{
			int num = default(int);
			switch (0)
			{
			default:
			{
				string pattern = default(string);
				while (true)
				{
					switch (num)
					{
					case 0:
					{
						if (string.IsNullOrEmpty(A_1.Data))
						{
							return;
						}
						short num2 = 1441;
						short num3 = num2;
						num2 = 1441;
						switch (num3 == num2)
						{
						default:
							num2 = 0;
							if (num2 != 0)
							{
							}
							num2 = 2;
							num = num2;
							continue;
						case false:
						case true:
							break;
						}
						goto case 2;
					}
					case 5:
						if (Regex.IsMatch(A_1.Data, b.m_ad))
						{
							short num2 = 1;
							if (num2 != 0)
							{
							}
							num2 = 3;
							num = num2;
							continue;
						}
						return;
					case 1:
						a.ReportProgress(107, "运行出错");
						return;
					case 2:
					{
						pattern = "No\\sNFC\\sdevice\\sfound";
						short num2 = 0;
						_ = num2;
						num2 = 4;
						num = num2;
						continue;
					}
					case 4:
						if (!Regex.IsMatch(A_1.Data, pattern))
						{
							short num2 = 5;
							num = num2;
						}
						else
						{
							short num2 = 1;
							num = num2;
						}
						continue;
					case 3:
					{
						a.ReportProgress(107, "运行出错");
						short num2 = 6;
						num = num2;
						continue;
					}
					case 6:
						return;
					}
					break;
				}
				goto case 0;
			}
			case 0:
			{
				a.ReportProgress(0, A_1.Data);
				short num2 = 0;
				num = num2;
				goto default;
			}
			}
		}
	}

	private SerialPort m_a;

	private string[] m_b;

	private string[] m_c;

	private string[] m_d;

	private string[] m_e;

	private string[] m_f;

	private string[] m_g;

	private string[] m_h;

	private string m_i = "";

	private System.Windows.Forms.Timer m_j;

	private bool m_k;

	private bool m_l;

	private string m_m = string.Empty;

	private string m_n;

	private string m_o;

	private int m_p;

	private const int m_q = 80;

	private const int m_r = 175;

	private const int m_s = 4000;

	private const int m_t = 6000;

	private const int m_u = 12000;

	private bool m_v;

	private global::b m_w = global::b.c;

	private int m_x;

	private bool m_y;

	private Process m_z = new Process();

	private bool m_aa;

	private bool m_ab;

	private string m_ac = "";

	private string m_ad = "pn53x_check_communication error";

	private string m_ae = "115200";

	private bool m_af;

	private bool m_ag;

	private bool m_ah;

	private string m_ai = "";

	private string m_aj = "";

	private List<string> m_ak = new List<string>();

	private List<string> m_al = new List<string>(new string[4] { "200:UNKNOWN COMMAND", "201:INVALID COMMAND USAGE", "202:INVALID PARAMETER", "203:TIMEOUT" });

	private string m_am = "";

	public const int WM_DEVICE_CHANGE = 537;

	public const int DBT_DEVICEARRIVAL = 32768;

	public const int DBT_DEVICE_REMOVE_COMPLETE = 32772;

	private bool m_an;

	private int m_ao;

	private string m_ap = "./nfc-data/tmp/fwrite.tmp";

	private IContainer m_aq;

	private TextBox m_ar;

	private OpenFileDialog m_as;

	private SaveFileDialog m_at;

	private GroupBox m_au;

	private TabPage m_av;

	private GroupBox m_aw;

	private Label m_ax;

	private TextBox m_ay;

	private Button m_az;

	private GroupBox m_a0;

	private Button m_a1;

	private TextBox m_a2;

	private Label m_a3;

	private TabPage m_a4;

	private CheckBox m_a5;

	private CheckBox m_a6;

	private CheckBox m_a7;

	private CheckBox m_a8;

	private CheckBox m_a9;

	private CheckBox m_ba;

	private CheckBox m_bb;

	private CheckBox m_bc;

	private GroupBox m_bd;

	private Button m_be;

	private Button m_bf;

	private Button m_bg;

	private Button m_bh;

	private Button m_bi;

	private Button m_bj;

	private global::c bk;

	private TextBox bl;

	private Label bm;

	private ComboBox bn;

	private Label bo;

	private TextBox bp;

	private Label bq;

	private Label br;

	private ComboBox bs;

	private global::c bt;

	private Label bu;

	private ComboBox bv;

	private TextBox bw;

	private Label bx;

	private ComboBox by;

	private Label bz;

	private Label b0;

	private TextBox b1;

	private global::c b2;

	private TextBox b3;

	private Label b4;

	private ComboBox b5;

	private Label b6;

	private TextBox b7;

	private Label b8;

	private Label b9;

	private ComboBox ca;

	private global::c cb;

	private TextBox cc;

	private Label cd;

	private ComboBox ce;

	private Label cf;

	private TextBox cg;

	private Label ch;

	private Label ci;

	private ComboBox cj;

	private global::c ck;

	private TextBox cl;

	private Label cm;

	private ComboBox cn;

	private Label co;

	private TextBox cp;

	private Label cq;

	private Label cr;

	private ComboBox cs;

	private global::c ct;

	private TextBox cu;

	private Label cv;

	private ComboBox cw;

	private Label cx;

	private TextBox cy;

	private Label cz;

	private Label c0;

	private ComboBox c1;

	private global::c c2;

	private TextBox c3;

	private Label c4;

	private ComboBox c5;

	private Label c6;

	private TextBox c7;

	private Label c8;

	private Label c9;

	private ComboBox da;

	private global::c db;

	private TextBox dc;

	private Label dd;

	private ComboBox de;

	private Label df;

	private TextBox dg;

	private Label dh;

	private Label di;

	private ComboBox dj;

	private TabControl dk;

	private GroupBox dl;

	private Label dm;

	private Button dn;

	private Button dp;

	private Button dq;

	private Button dr;

	private Button ds;

	private Label dt;

	private Label du;

	private Button dv;

	private FolderBrowserDialog dw;

	private GroupBox dx;

	private GroupBox dy;

	private Button dz;

	private TextBox d0;

	private Label d1;

	private CheckBox d2;

	private TextBox d3;

	private Button d4;

	private Button d5;

	private TextBox d6;

	private TabPage d7;

	private HexBox d8;

	private HexBox d9;

	private Button ea;

	private Button eb;

	private Button ec;

	private Button ed;

	private ComboBox ee;

	private Label ef;

	private ComboBox eg;

	private Label eh;

	private ComboBox ei;

	private Label ej;

	private ComboBox ek;

	private Label el;

	private ComboBox em;

	private Label en;

	private ComboBox eo;

	private Label ep;

	private ComboBox eq;

	private Label er;

	private ComboBox es;

	private Label et;

	private RadioButton eu;

	private RadioButton ev;

	private RadioButton ew;

	private Label ex;

	private Label ey;

	private Label ez;

	private CheckBox e0;

	private PictureBox e1;

	private ContextMenuStrip e2;

	private ToolStripMenuItem e3;

	private ComboBox e4;

	private BindingSource e5;

	private GroupBox e6;

	private ComboBox e7;

	private BindingSource e8;

	private Button e9;

	private Label fa;

	private TabPage fb;

	private RichTextBox fc;

	private TextBox fd;

	private Button fe;

	private GroupBox ff;

	private LinkLabel fg;

	private LinkLabel fh;

	private ContextMenuStrip fi;

	private ToolStripMenuItem fj;

	private ToolStripMenuItem fk;

	private GroupBox fl;

	private FlowLayoutPanel fm;

	private Button fn;

	private UcLegend fo;

	private Button fp;

	private Button fq;

	private ToolStripMenuItem fr;

	private OpenFileDialog fs;

	private Label ft;

	private ComboBox fu;

	private ComboBox fv;

	private ComboBox fw;

	private ComboBox fx;

	private ComboBox fy;

	private ComboBox fz;

	private ComboBox f0;

	private ComboBox f1;

	private ComboBox f2;

	private ComboBox f3;

	private ComboBox f4;

	private ComboBox f5;

	private ComboBox f6;

	private ComboBox f7;

	private ComboBox f8;

	private ComboBox f9;

	private ComboBox ga;

	private ComboBox gb;

	private Label gc;

	private Label gd;

	private ComboBox ge;

	private ComboBox gf;

	private Label gg;

	private Label gh;

	private ComboBox gi;

	private ComboBox gj;

	private Label gk;

	private Label gl;

	private ComboBox gm;

	private ComboBox gn;

	private Label go;

	private Label gp;

	private ComboBox gq;

	private ComboBox gr;

	private Label gs;

	private Label gt;

	private ComboBox gu;

	private ComboBox gv;

	private Label gw;

	private Label gx;

	private ComboBox gy;

	private ComboBox gz;

	private Label g0;

	private Label g1;

	private ComboBox g2;

	private ComboBox g3;

	private Label g4;

	private Label g5;

	private ToolTip g6;

	private UcTextFlow g7;

	private Button g8;

	private TableLayoutPanel g9;

	private TableLayoutPanel ha;

	private TableLayoutPanel hb;

	private TableLayoutPanel hc;

	private TableLayoutPanel hd;

	private TableLayoutPanel he;

	private TableLayoutPanel hf;

	private TableLayoutPanel hg;

	private ToolStripMenuItem hh;

	private Button hi;

	private Button hj;

	private Button hk;

	private ComboBox hl;

	private GroupBox hm;

	private LinkLabel hn;

	private Button ho;

	private Button hp;

	private Button hq;

	private Button hr;

	private Button hs;

	private Button ht;

	private Button hu;

	private Button hv;

	private Button hw;

	private Button hx;

	private Button hy;

	private Button hz;

	private Button h0;

	private Button h1;

	private Button h2;

	private CheckBox h3;

	private CheckBox h4;

	private Button h5;

	private ComboBox h6;

	private CheckBox h7;

	private CheckBox h8;

	private CheckBox h9;

	private Button ia;

	public string SoftwareVersion
	{
		get
		{
			short num = -26372;
			short num2 = num;
			num = -26372;
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
				num = 0;
				_ = num;
				return "Chameleon Mini GUI - Iceman Edition 冰人";
			}
		}
	}

	private double ByteWidth
	{
		get
		{
			int num2 = default(int);
			double num3 = default(double);
			switch (0)
			{
			default:
				while (true)
				{
					short num = 0;
					_ = num;
					switch (num2)
					{
					case 6:
						if (num3 > 32.0)
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
					case 2:
						num3 = 16.0;
						num = 5;
						num2 = num;
						continue;
					case 3:
					{
						num = 1;
						if (num != 0)
						{
						}
						if (num3 > 16.0)
						{
							num = 2;
							num2 = num;
							continue;
						}
						num3 = 8.0;
						num = -18477;
						short num4 = num;
						num = -18477;
						switch (num4 == num)
						{
						default:
							num = 0;
							if (num != 0)
							{
							}
							num = 0;
							num2 = num;
							continue;
						case false:
						case true:
							break;
						}
						goto case 0;
					}
					case 1:
						num3 = 32.0;
						num = 4;
						num2 = num;
						continue;
					case 0:
					case 4:
					case 5:
						return num3;
					}
					break;
				}
				goto case 0;
			case 0:
			{
				num3 = (double)fc.Width / ((double)fc.Font.SizeInPoints * 2.5);
				short num = 6;
				num2 = num;
				goto default;
			}
			}
		}
	}

	public string FirmwareVersion
	{
		get
		{
			short num = 1;
			if (num != 0)
			{
			}
			num = 11942;
			short num2 = num;
			num = 11942;
			switch (num2 == num)
			{
			default:
				num = 0;
				if (num != 0)
				{
				}
				num = 0;
				_ = num;
				return this.m_o;
			}
		}
		set
		{
			short num = -23290;
			short num2 = num;
			num = -23290;
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
			this.m_o = value;
			d6.Text = this.m_o;
		}
	}

	protected override CreateParams CreateParams
	{
		get
		{
			short num = -25860;
			short num2 = num;
			num = -25860;
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
			CreateParams obj = base.CreateParams;
			obj.ExStyle |= 33554432;
			return obj;
		}
	}

	public frm_main()
	{
		a();
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = SoftwareVersion;
		base.TopMost = true;
	}

	private void bj(object A_0, EventArgs A_1)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
			switch (0)
			{
			default:
			{
				string text = default(string);
				List<CheckBox>.Enumerator enumerator = default(List<CheckBox>.Enumerator);
				int num4 = default(int);
				string[] array = default(string[]);
				while (true)
				{
					switch (num2)
					{
					case 12:
						if (File.Exists("config/libnfc.conf"))
						{
							num = 15;
							num2 = num;
							continue;
						}
						hl.Items.Insert(0, "请选择设备");
						hl.SelectedIndex = 0;
						h6.Items.Insert(0, "请选择设备");
						h6.SelectedIndex = 0;
						num = 10;
						num2 = num;
						continue;
					case 16:
						r();
						w();
						num = 13;
						num2 = num;
						continue;
					case 10:
						num = 0;
						_ = num;
						goto case 4;
					case 11:
					{
						string[] array2 = text.Replace("device.connstring = \"pn532_uart", "").Replace("\"", "").Split(':');
						this.m_am = array2[1];
						text.Replace("device.connstring = \"pn532_uart:" + this.m_am + ":", "").Replace("\"", "");
						num = 6;
						num2 = num;
						continue;
					}
					case 14:
						try
						{
							num = 3;
							num2 = num;
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
									num = 4;
									num2 = num;
									continue;
								case 4:
									if (enumerator.MoveNext())
									{
										enumerator.Current.Checked = false;
										goto IL_0248;
									}
									num = 1;
									num2 = num;
									continue;
								case 1:
								{
									num = -8146;
									short num3 = num;
									num = -8146;
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
										num = 2;
										num2 = num;
										continue;
									}
									goto IL_0248;
								}
								case 2:
									break;
									IL_0248:
									num = 0;
									num2 = num;
									continue;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
						new MultiLanguage().LoadLanguage(base.Controls, "Chinese.txt");
						Settings.Default.Language = "Chinese.txt";
						Settings.Default.EnableKeepAlive = false;
						Settings.Default.KeepAliveInterval = 50000;
						Settings.Default.DownloadDumpPath = "./dumpfiles/";
						Settings.Default.Save();
						v();
						j();
						this.m_j.Stop();
						return;
					case 7:
						if (text.StartsWith("device.connstring = \"pn532_uart:"))
						{
							num = 11;
							num2 = num;
							continue;
						}
						goto case 6;
					case 9:
						num = 8;
						num2 = num;
						continue;
					case 8:
						if (this.m_a.IsOpen)
						{
							num = 16;
							num2 = num;
							continue;
						}
						goto case 13;
					case 6:
						num4++;
						num = 5;
						num2 = num;
						continue;
					case 13:
						enumerator = a<CheckBox>(this.m_a4.Controls, "checkBox").GetEnumerator();
						num = 14;
						num2 = num;
						continue;
					case 4:
						base.TopMost = false;
						num = 1;
						num2 = num;
						continue;
					case 1:
						if (this.m_a != null)
						{
							num = 9;
							num2 = num;
							continue;
						}
						goto case 13;
					case 15:
						array = File.ReadAllLines("config/libnfc.conf");
						num4 = 0;
						num = 2;
						num2 = num;
						continue;
					case 2:
					case 5:
						num = 3;
						num2 = num;
						continue;
					case 3:
						if (num4 < array.Length)
						{
							text = array[num4];
							num = 7;
							num2 = num;
						}
						else
						{
							num = 0;
							num2 = num;
						}
						continue;
					case 0:
						num = 1;
						if (num != 0)
						{
						}
						hl.Items.Insert(0, this.m_am);
						h6.Items.Insert(0, this.m_am);
						hl.SelectedIndex = 0;
						h6.SelectedIndex = 0;
						num = 4;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				this.m_ar.SelectionStart = 0;
				num = 12;
				num2 = num;
				goto default;
			}
		}
	}

	private bool a(string A_0, string A_1)
	{
		short num = 0;
		int num2 = num;
		SerialPort serialPort = default(SerialPort);
		byte[] array = default(byte[]);
		int num6 = default(int);
		byte[] array2 = default(byte[]);
		int num3 = default(int);
		byte[] buffer = default(byte[]);
		int num4 = default(int);
		switch (num2)
		{
		default:
			{
				switch (0)
				{
				case 0:
					goto IL_008f;
				}
				goto IL_0028;
			}
			IL_0028:
			while (true)
			{
				switch (num2)
				{
				case 19:
					if (serialPort.IsOpen)
					{
						num = 7;
						num2 = num;
					}
					else
					{
						num = 10;
						num2 = num;
					}
					continue;
				case 22:
					num = 1;
					if (num != 0)
					{
					}
					if (array[num6] != array2[num6])
					{
						num = 20;
						num2 = num;
						continue;
					}
					goto case 14;
				case 11:
					if (serialPort != null)
					{
						num = 17;
						num2 = num;
						continue;
					}
					goto IL_0412;
				case 6:
				case 18:
					num = 5;
					num2 = num;
					continue;
				case 5:
					if (num6 < 15)
					{
						num = 22;
						num2 = num;
					}
					else
					{
						num = 12;
						num2 = num;
					}
					continue;
				case 10:
					try
					{
						serialPort.Open();
					}
					catch (Exception ex3)
					{
						Console.Write(ex3.Message);
						return false;
					}
					num = 11;
					num2 = num;
					continue;
				case 0:
					MessageBox.Show("发现NFC设备", "连接成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					a("pn532_uart:" + A_0 + ":" + A_1, A_1: true, A_2: false);
					return true;
				case 1:
					num = 4;
					num2 = num;
					continue;
				case 4:
					if (serialPort.IsOpen)
					{
						num = 23;
						num2 = num;
						continue;
					}
					goto case 12;
				case 23:
					num = 0;
					_ = num;
					array = new byte[15];
					array2 = new byte[15]
					{
						0, 0, 255, 0, 255, 0, 0, 0, 255, 2,
						254, 213, 21, 22, 0
					};
					num = 16;
					num2 = num;
					continue;
				case 17:
					num = 15;
					num2 = num;
					continue;
				case 15:
					if (serialPort.IsOpen)
					{
						num = 9;
						num2 = num;
						continue;
					}
					goto IL_0412;
				case 12:
					num = 2;
					num2 = num;
					continue;
				case 2:
					if (num3 == 0)
					{
						num = 0;
						num2 = num;
						continue;
					}
					return false;
				case 7:
					serialPort.Close();
					return false;
				case 9:
					buffer = new byte[24]
					{
						85, 85, 0, 0, 0, 0, 0, 0, 0, 0,
						0, 0, 0, 0, 0, 0, 255, 3, 253, 212,
						20, 1, 23, 0
					};
					num = 21;
					num2 = num;
					continue;
				case 21:
					try
					{
						serialPort.Write(buffer, 0, 24);
					}
					catch (Exception ex2)
					{
						Console.Write(ex2.Message);
						num3++;
					}
					goto IL_0412;
				case 14:
					num6++;
					num = 6;
					num2 = num;
					continue;
				case 13:
					if (num3 == 0)
					{
						num = 8;
						num2 = num;
						continue;
					}
					goto case 12;
				case 8:
					num = 3;
					num2 = num;
					continue;
				case 3:
					if (serialPort != null)
					{
						num = 1;
						num2 = num;
						continue;
					}
					goto case 12;
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
								case 3:
									while (true)
									{
										num = 5818;
										short num5 = num;
										num = 5818;
										switch (num5 == num)
										{
										case false:
										case true:
											continue;
										}
										break;
									}
									num = 0;
									if (num != 0)
									{
									}
									num = 0;
									num2 = num;
									continue;
								case 0:
									if (num4 >= 15)
									{
										num = 4;
										num2 = num;
										continue;
									}
									array[num4] = (byte)serialPort.ReadByte();
									num4++;
									num = 1;
									num2 = num;
									continue;
								case 4:
									num = 2;
									num2 = num;
									continue;
								case 2:
									goto end_IL_0491;
								}
								goto case 0;
								continue;
								end_IL_0491:
								break;
							}
							break;
						case 0:
							num4 = 0;
							num = 3;
							num2 = num;
							goto default;
						}
					}
					catch (Exception ex)
					{
						Console.Write(ex.Message);
						num3++;
					}
					serialPort.Close();
					num6 = 0;
					num = 18;
					num2 = num;
					continue;
				case 20:
					{
						num3++;
						num = 14;
						num2 = num;
						continue;
					}
					IL_0412:
					num = 13;
					num2 = num;
					continue;
				}
				break;
			}
			goto IL_008f;
			IL_008f:
			num3 = 0;
			n("DETECTION" + this.m_i + "=9");
			serialPort = new SerialPort();
			serialPort.PortName = A_0;
			serialPort.BaudRate = int.Parse(A_1);
			serialPort.DataBits = 8;
			serialPort.StopBits = StopBits.One;
			serialPort.Parity = Parity.None;
			serialPort.ReadTimeout = 500;
			num = 19;
			num2 = num;
			goto IL_0028;
		}
	}

	private void a(object A_0, FormClosedEventArgs A_1)
	{
		short num = 8;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 8:
			{
				num = -5919;
				short num3 = num;
				num = -5919;
				switch (num3 == num)
				{
				case false:
				case true:
					goto IL_01c1;
				}
				num = 0;
				_ = num;
				num = 0;
				if (num != 0)
				{
				}
				switch (0)
				{
				default:
					goto end_IL_0098;
				case 0:
					break;
				}
				goto default;
			}
			default:
			{
				System.Windows.Forms.Timer timer = this.m_j;
				if (timer != null)
				{
					timer.Stop();
					num = 7;
					num2 = num;
				}
				else
				{
					num = 12;
					num2 = num;
				}
				break;
			}
			case 4:
				num = 11;
				num2 = num;
				break;
			case 11:
				if (!string.IsNullOrEmpty(this.m_ay.Text))
				{
					num = 6;
					num2 = num;
					break;
				}
				return;
			case 0:
				this.m_a.Close();
				num = 4;
				num2 = num;
				break;
			case 10:
				Settings.Default.DownloadDumpPath = this.m_ay.Text;
				Settings.Default.Save();
				num = 1;
				num2 = num;
				break;
			case 1:
				return;
			case 12:
				goto IL_01c1;
			case 6:
				num = 2;
				num2 = num;
				break;
			case 2:
				if (Directory.Exists(this.m_ay.Text))
				{
					num = 10;
					num2 = num;
					break;
				}
				return;
			case 3:
				num = 5;
				num2 = num;
				break;
			case 5:
				if (this.m_a.IsOpen)
				{
					num = 0;
					num2 = num;
					break;
				}
				goto case 4;
			case 7:
				num = 9;
				num2 = num;
				break;
			case 9:
				{
					if (this.m_a != null)
					{
						num = 3;
						num2 = num;
						break;
					}
					goto case 4;
				}
				IL_01c1:
				num = 1;
				if (num == 0)
				{
				}
				goto case 7;
				end_IL_0098:
				break;
			}
		}
	}

	private void bi(object A_0, EventArgs A_1)
	{
		short num = 6;
		int num2 = num;
		KeyValuePair<string, string> keyValuePair = default(KeyValuePair<string, string>);
		while (true)
		{
			object obj;
			switch (num2)
			{
			case 6:
				switch (0)
				{
				default:
					goto end_IL_001f;
				case 0:
					break;
				}
				goto default;
			default:
				if (this.m_v)
				{
					num = 2;
					num2 = num;
				}
				else
				{
					num = 0;
					num2 = num;
				}
				break;
			case 2:
				return;
			case 0:
			{
				ComboBox comboBox = e4;
				if (comboBox != null)
				{
					obj = comboBox.SelectedItem;
					goto IL_01fe;
				}
				num = 26856;
				short num3 = num;
				num = 26856;
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
					num = 4;
					num2 = num;
					goto end_IL_001f;
				}
				goto case 3;
			}
			case 3:
				Settings.Default.Language = keyValuePair.Value;
				a(keyValuePair.Value);
				Settings.Default.Save();
				num = 7;
				num2 = num;
				break;
			case 7:
				num = 0;
				_ = num;
				return;
			case 5:
				if (!string.IsNullOrEmpty(keyValuePair.Value))
				{
					num = 3;
					num2 = num;
					break;
				}
				return;
			case 4:
				num = 1;
				if (num != 0)
				{
				}
				obj = null;
				goto IL_01fe;
			case 1:
				return;
				IL_01fe:
				if (obj != null)
				{
					keyValuePair = (KeyValuePair<string, string>)e4.SelectedItem;
					new MultiLanguage().LoadLanguage(base.Controls, keyValuePair.Value);
					num = 5;
					num2 = num;
				}
				else
				{
					num = 1;
					num2 = num;
				}
				break;
				end_IL_001f:
				break;
			}
		}
	}

	private void bh(object A_0, EventArgs A_1)
	{
		short num = 1;
		int num2 = num;
		ComboBox comboBox = default(ComboBox);
		while (true)
		{
			switch (num2)
			{
			case 1:
				num = 1;
				if (num != 0)
				{
				}
				switch (0)
				{
				default:
					goto end_IL_0047;
				case 0:
					break;
				}
				goto default;
			default:
			{
				if (this.m_v)
				{
					num = 5;
					num2 = num;
					break;
				}
				comboBox = (ComboBox)A_0;
				num = 4167;
				short num3 = num;
				num = 4167;
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
					goto end_IL_0047;
				}
				goto IL_012e;
			}
			case 5:
				return;
			case 7:
			{
				if (comboBox.SelectedIndex == 0)
				{
					num = 6;
					num2 = num;
					break;
				}
				KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)comboBox.SelectedItem;
				List<IlegendItem> list = new List<IlegendItem>();
				Templating templating = new Templating();
				templating.LoadTemplate(d9, keyValuePair.Value, list);
				templating.LoadTemplate(d8, keyValuePair.Value, list);
				fo.Items = list;
				return;
			}
			case 6:
				num = 0;
				_ = num;
				goto IL_012e;
			case 0:
				num = 2;
				num2 = num;
				break;
			case 2:
				if (comboBox.SelectedItem != null)
				{
					num = 7;
					num2 = num;
				}
				else
				{
					num = 4;
					num2 = num;
				}
				break;
			case 4:
				return;
			case 3:
				{
					if (comboBox != null)
					{
						num = 0;
						num2 = num;
						break;
					}
					return;
				}
				IL_012e:
				fo.Items = null;
				i();
				return;
				end_IL_0047:
				break;
			}
		}
	}

	private void bg(object A_0, EventArgs A_1)
	{
		short num = 0;
		switch (num)
		{
		}
		Cursor = Cursors.WaitCursor;
		e();
		List<CheckBox>.Enumerator enumerator = a<CheckBox>(this.m_a4.Controls, "checkBox").GetEnumerator();
		try
		{
			num = 14;
			int num2 = num;
			string text2 = default(string);
			ComboBox comboBox = default(ComboBox);
			b b = default(b);
			int num4 = default(int);
			CheckBox current = default(CheckBox);
			string text = default(string);
			TextBox textBox = default(TextBox);
			uint a_ = default(uint);
			while (true)
			{
				switch (num2)
				{
				case 14:
					switch (0)
					{
					default:
						continue;
					case 0:
						break;
					}
					goto default;
				case 9:
					num = 21;
					num2 = num;
					continue;
				case 21:
				{
					string obj = m("CONFIG" + this.m_i + "?").ToString();
					text2 = comboBox.SelectedItem.ToString();
					if (obj != text2)
					{
						num = 5;
						num2 = num;
						continue;
					}
					goto case 0;
				}
				case 17:
					num = 10;
					num2 = num;
					continue;
				case 10:
					if (!b.a.StartsWith("202:"))
					{
						num = 3;
						num2 = num;
						continue;
					}
					goto default;
				case 23:
					num4 = int.Parse(current.Name.Substring(current.Name.Length - 1));
					num = 18;
					num2 = num;
					continue;
				case 18:
					if (num4 > 0)
					{
						num = 25;
						num2 = num;
						continue;
					}
					goto default;
				case 22:
					n("UID" + this.m_i + "=" + text);
					num = 7;
					num2 = num;
					continue;
				case 3:
					a<TextBox>(this.m_a4.Controls, $"txt_size{num4}").ForEach(b.b);
					num = 27;
					num2 = num;
					continue;
				case 13:
				case 20:
					textBox = a<TextBox>(this.m_a4.Controls, $"txt_uid{num4}").FirstOrDefault();
					num = 24;
					num2 = num;
					continue;
				case 24:
					if (textBox != null)
					{
						num = 8;
						num2 = num;
						continue;
					}
					goto case 2;
				case 5:
					n($"CONFIG{this.m_i}={comboBox.SelectedItem}");
					num = 0;
					num2 = num;
					continue;
				case 2:
					b.a = m("MEMSIZE" + this.m_i + "?").ToString();
					num = 19;
					num2 = num;
					continue;
				case 19:
					if (!string.IsNullOrEmpty(b.a))
					{
						num = 17;
						num2 = num;
						continue;
					}
					goto default;
				default:
					num = 26;
					num2 = num;
					continue;
				case 26:
					if (!enumerator.MoveNext())
					{
						num = 11;
						num2 = num;
						continue;
					}
					current = enumerator.Current;
					b = new b();
					num = 12;
					num2 = num;
					continue;
				case 4:
					a<ComboBox>(this.m_a4.Controls, $"cb_Lbutton{num4}").ForEach(delegate(ComboBox comboBox2)
					{
						short num5 = 12488;
						short num6 = num5;
						num5 = 12488;
						switch (num6 == num5)
						{
						default:
							num5 = 0;
							_ = num5;
							break;
						case true:
							break;
						}
						num5 = 1;
						if (num5 != 0)
						{
						}
						num5 = 0;
						if (num5 != 0)
						{
						}
						n($"LBUTTON{this.m_i}={comboBox2.SelectedItem}");
					});
					a<ComboBox>(this.m_a4.Controls, $"cb_Lbuttonlong{num4}").ForEach(delegate(ComboBox comboBox2)
					{
						short num5 = 31122;
						short num6 = num5;
						num5 = 31122;
						switch (num6 == num5)
						{
						default:
							num5 = 0;
							_ = num5;
							break;
						case true:
							break;
						}
						num5 = 1;
						if (num5 != 0)
						{
						}
						num5 = 0;
						if (num5 != 0)
						{
						}
						n($"LBUTTON_LONG{this.m_i}={comboBox2.SelectedItem}");
					});
					a<ComboBox>(this.m_a4.Controls, $"cb_Rbutton{num4}").ForEach(delegate(ComboBox comboBox2)
					{
						short num5 = 24864;
						short num6 = num5;
						num5 = 24864;
						switch (num6 == num5)
						{
						default:
							num5 = 0;
							_ = num5;
							break;
						case true:
							break;
						}
						num5 = 1;
						if (num5 != 0)
						{
						}
						num5 = 0;
						if (num5 != 0)
						{
						}
						n($"RBUTTON{this.m_i}={comboBox2.SelectedItem}");
					});
					a<ComboBox>(this.m_a4.Controls, $"cb_Rbuttonlong{num4}").ForEach(delegate(ComboBox comboBox2)
					{
						short num5 = -10320;
						short num6 = num5;
						num5 = -10320;
						switch (num6 == num5)
						{
						default:
							num5 = 0;
							_ = num5;
							break;
						case true:
							break;
						}
						num5 = 1;
						if (num5 != 0)
						{
						}
						num5 = 0;
						if (num5 != 0)
						{
						}
						n($"RBUTTON_LONG{this.m_i}={comboBox2.SelectedItem}");
					});
					num = 20;
					num2 = num;
					continue;
				case 12:
					if (current.Checked)
					{
						num = 23;
						num2 = num;
						continue;
					}
					goto default;
				case 25:
					n("SETTING" + this.m_i + "=" + (num4 - this.m_p));
					text2 = string.Empty;
					comboBox = a<ComboBox>(this.m_a4.Controls, $"cb_mode{num4}").FirstOrDefault();
					num = 15;
					num2 = num;
					continue;
				case 15:
					if (comboBox != null)
					{
						num = 9;
						num2 = num;
						continue;
					}
					goto case 0;
				case 0:
					num = 6;
					num2 = num;
					continue;
				case 6:
					if (this.m_w == global::b.c)
					{
						num = 4;
						num2 = num;
						continue;
					}
					a<ComboBox>(this.m_a4.Controls, $"cb_Lbutton{num4}").ForEach(delegate(ComboBox comboBox2)
					{
						short num5 = -5525;
						short num6 = num5;
						num5 = -5525;
						switch (num6 == num5)
						{
						default:
							num5 = 0;
							_ = num5;
							break;
						case true:
							break;
						}
						num5 = 1;
						if (num5 != 0)
						{
						}
						num5 = 0;
						if (num5 != 0)
						{
						}
						n($"BUTTON{this.m_i}={comboBox2.SelectedItem}");
					});
					a<ComboBox>(this.m_a4.Controls, $"cb_Lbuttonlong{num4}").ForEach(delegate(ComboBox comboBox2)
					{
						short num5 = 4066;
						short num6 = num5;
						num5 = 4066;
						switch (num6 == num5)
						{
						default:
							num5 = 0;
							_ = num5;
							break;
						case true:
							break;
						}
						num5 = 0;
						if (num5 != 0)
						{
						}
						num5 = 1;
						if (num5 != 0)
						{
						}
						n($"BUTTON_LONG{this.m_i}={comboBox2.SelectedItem}");
					});
					num = 13;
					num2 = num;
					continue;
				case 7:
					textBox.Text = m("UID" + this.m_i + "?").ToString();
					num = 2;
					num2 = num;
					continue;
				case 8:
					text = textBox.Text;
					a_ = uint.Parse(m("UIDSIZE" + this.m_i + "?").ToString());
					num = 16;
					num2 = num;
					continue;
				case 16:
				{
					num = 27371;
					short num3 = num;
					num = 27371;
					switch (num3 == num)
					{
					case false:
					case true:
						break;
					default:
						goto IL_071a;
					}
					goto case 23;
				}
				case 11:
					num = 1;
					num2 = num;
					continue;
				case 1:
					break;
					IL_071a:
					num = 0;
					if (num != 0)
					{
					}
					if (a(text, a_, text2))
					{
						num = 22;
						num2 = num;
						continue;
					}
					goto case 7;
				}
				break;
			}
		}
		finally
		{
			num = 1;
			if (num != 0)
			{
			}
			((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
		}
		num = 0;
		_ = num;
		d();
		Cursor = Cursors.Default;
	}

	private void bf(object A_0, EventArgs A_1)
	{
		short num = -5926;
		short num2 = num;
		num = -5926;
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
		n("UPGRADE" + this.m_i);
		c();
	}

	private void be(object A_0, EventArgs A_1)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			ManagementObjectCollection managementObjectCollection = default(ManagementObjectCollection);
			bool flag = default(bool);
			bool flag2 = default(bool);
			switch (0)
			{
			default:
			{
				string text7 = default(string);
				string path6 = default(string);
				string text8 = default(string);
				string path5 = default(string);
				string text6 = default(string);
				string text = default(string);
				ManagementObject managementObject = default(ManagementObject);
				string text3 = default(string);
				string path2 = default(string);
				string path = default(string);
				string text2 = default(string);
				string text4 = default(string);
				string text5 = default(string);
				while (true)
				{
					switch (num2)
					{
					case 11:
						if (managementObjectCollection != null)
						{
							num = 18;
							num2 = num;
							continue;
						}
						goto IL_0494;
					case 21:
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
										if (File.Exists(text7))
										{
											num = 6;
											num2 = num;
											continue;
										}
										goto IL_024a;
									case 0:
										num = 8;
										num2 = num;
										continue;
									case 8:
										if (File.Exists(path6))
										{
											num = 4;
											num2 = num;
											continue;
										}
										goto IL_024a;
									case 4:
										Process.Start(new ProcessStartInfo
										{
											UseShellExecute = true,
											WorkingDirectory = text8,
											FileName = text7
										});
										flag = true;
										num = 7;
										num2 = num;
										continue;
									case 6:
										num = 1;
										num2 = num;
										continue;
									case 1:
										if (File.Exists(path5))
										{
											num = 0;
											num2 = num;
											continue;
										}
										goto IL_024a;
									case 3:
									case 7:
										num = 5;
										num2 = num;
										continue;
									case 5:
										goto end_IL_00ed;
										IL_024a:
										this.m_ar.AppendText("[!] Firmware flashing failed: Unable to find all the required files to flash the firmware");
										num = 3;
										num2 = num;
										continue;
									}
									goto case 0;
									continue;
									end_IL_00ed:
									break;
								}
								break;
							case 0:
							{
								string path7 = ConfigurationManager.AppSettings["BOOTLOADER_PATH"];
								string path8 = ConfigurationManager.AppSettings["BOOTLOADER_EXE"];
								string path9 = ConfigurationManager.AppSettings["FLASH_BINARY"];
								string path10 = ConfigurationManager.AppSettings["EEPROM_BINARY"];
								text8 = Path.Combine(Application.StartupPath, path7);
								text7 = Path.Combine(text8, path8);
								path5 = Path.Combine(text8, path9);
								path6 = Path.Combine(text8, path10);
								num = 2;
								num2 = num;
								goto default;
							}
							}
						}
						catch (Exception ex2)
						{
							Console.WriteLine(ex2.Message);
						}
						goto IL_0494;
					case 7:
						if (text6.Equals("atxmega32a4u"))
						{
							num = 1;
							num2 = num;
							continue;
						}
						goto IL_0494;
					case 14:
						num = 15;
						num2 = num;
						continue;
					case 15:
						if (!text.Contains("vid_03eb&pid_2fde"))
						{
							num = 22;
							num2 = num;
							continue;
						}
						goto case 13;
					case 22:
						num = 1;
						if (num != 0)
						{
						}
						num = 3;
						num2 = num;
						continue;
					case 9:
						this.m_ar.AppendText("[+] Firmware flashed successfully");
						return;
					case 2:
						managementObject = managementObjectCollection.OfType<ManagementObject>().FirstOrDefault();
						num = 4;
						num2 = num;
						continue;
					case 4:
						if (managementObject != null)
						{
							num = 24;
							num2 = num;
							continue;
						}
						goto IL_0494;
					case 5:
						flag2 = true;
						num = 21;
						num2 = num;
						continue;
					case 12:
						if (!flag2)
						{
							num = 16;
							num2 = num;
							continue;
						}
						goto case 10;
					case 3:
						if (!text.Contains("vid_03eb&pid_204a"))
						{
							num = 23;
							num2 = num;
							continue;
						}
						goto case 13;
					case 17:
						if (!flag)
						{
							num = 12;
							num2 = num;
						}
						else
						{
							num = 9;
							num2 = num;
						}
						continue;
					case 16:
						this.m_ar.AppendText("[!] Firmware flashing failed: Unable to find a ChameleonMini device. Maybe not in bootloader mode?");
						num = 10;
						num2 = num;
						continue;
					case 13:
						flag2 = true;
						num = 20;
						num2 = num;
						continue;
					case 18:
						num = 0;
						num2 = num;
						continue;
					case 0:
						if (managementObjectCollection.Count > 0)
						{
							num = 2;
							num2 = num;
							continue;
						}
						goto IL_0494;
					case 24:
						text6 = managementObject["Name"].ToString().ToLower();
						text = managementObject["DeviceID"].ToString().ToLower();
						num = 8;
						num2 = num;
						continue;
					case 8:
						if (text6.Equals("atxmega128a4u"))
						{
							num = 14;
							num2 = num;
							continue;
						}
						goto IL_02e1;
					case 23:
						num = 6;
						num2 = num;
						continue;
					case 6:
						if (text.Contains("vid_2341&pid_0043"))
						{
							num = 13;
							num2 = num;
							continue;
						}
						goto IL_02e1;
					case 20:
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
										if (File.Exists(text3))
										{
											num = 6;
											num2 = num;
											continue;
										}
										goto IL_0739;
									case 6:
										num = 8;
										num2 = num;
										continue;
									case 8:
										if (File.Exists(path2))
										{
											num = 4;
											num2 = num;
											continue;
										}
										goto IL_0739;
									case 4:
										num = 3;
										num2 = num;
										continue;
									case 3:
										if (File.Exists(path))
										{
											num = 1;
											num2 = num;
											continue;
										}
										goto IL_0739;
									case 1:
									{
										num = -32573;
										short num3 = num;
										num = -32573;
										switch (num3 == num)
										{
										case false:
										case true:
											break;
										default:
										{
											num = 0;
											if (num != 0)
											{
											}
											ProcessStartInfo processStartInfo = new ProcessStartInfo();
											processStartInfo.UseShellExecute = true;
											processStartInfo.WorkingDirectory = text2;
											processStartInfo.FileName = text3;
											processStartInfo.Arguments = "-c flip2 -p ATXMega128A4U -B 60 -P usb -U application:w:" + text4 + ":i -U eeprom:w:" + text5 + ":i";
											Process.Start(processStartInfo);
											flag = true;
											num = 0;
											num2 = num;
											continue;
										}
										}
										goto case 3;
									}
									case 0:
									case 7:
										num = 5;
										num2 = num;
										continue;
									case 5:
										goto end_IL_0623;
										IL_0739:
										this.m_ar.AppendText("[!] Firmware flashing failed: Unable to find all the required files to flash the firmware");
										num = 7;
										num2 = num;
										continue;
									}
									goto case 0;
									continue;
									end_IL_0623:
									break;
								}
								break;
							case 0:
							{
								string path3 = ConfigurationManager.AppSettings["BOOTLOADER_PATH"];
								string path4 = ConfigurationManager.AppSettings["AVRDUDE_EXE"];
								text4 = ConfigurationManager.AppSettings["REVG_FLASH_HEX"];
								text5 = ConfigurationManager.AppSettings["REVG_EEPROM_HEX"];
								text2 = Path.Combine(Application.StartupPath, path3);
								text3 = Path.Combine(text2, path4);
								path2 = Path.Combine(text2, text4);
								path = Path.Combine(text2, text5);
								num = 2;
								num2 = num;
								goto default;
							}
							}
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
						}
						goto IL_0494;
					case 1:
						num = 19;
						num2 = num;
						continue;
					case 19:
						if (text.Contains("vid_03eb&pid_2fe4"))
						{
							num = 0;
							_ = num;
							num = 5;
							num2 = num;
							continue;
						}
						goto IL_0494;
					case 10:
						{
							MessageBox.Show("Unable to flash the firmware. Check the log output for more information.", "Firmware flashing failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							return;
						}
						IL_02e1:
						num = 7;
						num2 = num;
						continue;
						IL_0494:
						num = 17;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				flag = false;
				flag2 = false;
				managementObjectCollection = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity where DeviceID like '%VID_03EB&PID_2FDE%' or DeviceID like '%VID_03EB&PID_204A%' or DeviceID like '%VID_03EB&PID_2FE4%'or DeviceID like '%VID_2341&PID_0043%'").Get();
				num = 11;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private void bd(object A_0, EventArgs A_1)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
			switch (0)
			{
			default:
			{
				List<CheckBox>.Enumerator enumerator = default(List<CheckBox>.Enumerator);
				CheckBox current2 = default(CheckBox);
				int num4 = default(int);
				string fileName = default(string);
				CheckBox current = default(CheckBox);
				int num3 = default(int);
				while (true)
				{
					switch (num2)
					{
					case 0:
						if (this.m_ac == "")
						{
							num = 4;
							num2 = num;
						}
						else
						{
							enumerator = a<CheckBox>(this.m_a4.Controls, "checkBox").GetEnumerator();
							num = 6;
							num2 = num;
						}
						continue;
					case 6:
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
								case 6:
									if (current2.Checked)
									{
										goto IL_011b;
									}
									goto default;
								default:
									num = 4;
									num2 = num;
									continue;
								case 4:
								{
									if (enumerator.MoveNext())
									{
										current2 = enumerator.Current;
										num = 6;
										num2 = num;
										continue;
									}
									num = 20521;
									short num5 = num;
									num = 20521;
									switch (num5 == num)
									{
									case false:
									case true:
										break;
									default:
										num = 0;
										if (num != 0)
										{
										}
										num = 7;
										num2 = num;
										continue;
									}
									goto IL_011b;
								}
								case 0:
									n($"SETTING{this.m_i}={num4 - this.m_p}");
									r(this.m_ac);
									a($"将上传刚解卡的数据{this.m_ac}至卡位{num4 - this.m_p}");
									a(num4, A_1: false);
									num = 3;
									num2 = num;
									continue;
								case 8:
									num4 = int.Parse(current2.Name.Substring(current2.Name.Length - 1));
									num = 1;
									num2 = num;
									continue;
								case 1:
									if (num4 > 0)
									{
										num = 0;
										num2 = num;
										continue;
									}
									goto default;
								case 7:
									num = 5;
									num2 = num;
									continue;
								case 5:
									break;
									IL_011b:
									num = 8;
									num2 = num;
									continue;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
						this.m_ac = "";
						num = 3;
						num2 = num;
						continue;
					case 2:
						num = 0;
						_ = num;
						fileName = this.m_as.FileName;
						enumerator = a<CheckBox>(this.m_a4.Controls, "checkBox").GetEnumerator();
						num = 5;
						num2 = num;
						continue;
					case 3:
						num = 1;
						if (num == 0)
						{
						}
						goto IL_05c2;
					case 4:
						num = 1;
						num2 = num;
						continue;
					case 1:
						if (this.m_as.ShowDialog() == DialogResult.OK)
						{
							num = 2;
							num2 = num;
							continue;
						}
						goto IL_05c2;
					case 5:
						{
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
									case 6:
										if (current.Checked)
										{
											num = 8;
											num2 = num;
											continue;
										}
										goto default;
									case 8:
										num3 = int.Parse(current.Name.Substring(current.Name.Length - 1));
										num = 4;
										num2 = num;
										continue;
									case 4:
										if (num3 > 0)
										{
											num = 7;
											num2 = num;
											continue;
										}
										goto default;
									case 7:
										n($"SETTING{this.m_i}={num3 - this.m_p}");
										r(fileName);
										n("STORE" + this.m_i);
										a(num3, A_1: false);
										num = 3;
										num2 = num;
										continue;
									default:
										num = 1;
										num2 = num;
										continue;
									case 1:
										if (enumerator.MoveNext())
										{
											current = enumerator.Current;
											num = 6;
											num2 = num;
										}
										else
										{
											num = 0;
											num2 = num;
										}
										continue;
									case 0:
										num = 5;
										num2 = num;
										continue;
									case 5:
										break;
									}
									break;
								}
							}
							finally
							{
								((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
							}
							goto IL_05c2;
						}
						IL_05c2:
						d();
						Cursor = Cursors.Default;
						return;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				Cursor = Cursors.WaitCursor;
				e();
				num = 0;
				num2 = num;
				goto default;
			}
		}
	}

	protected override void WndProc(ref Message m)
	{
		short num = 5;
		int num2 = num;
		IntPtr wParam = default(IntPtr);
		while (true)
		{
			switch (num2)
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
			{
				num = 15502;
				short num3 = num;
				num = 15502;
				switch (num3 == num)
				{
				case false:
				case true:
					goto IL_0162;
				}
				num = 0;
				if (num != 0)
				{
				}
				if (m.Msg == 537)
				{
					num = 8;
					num2 = num;
					continue;
				}
				break;
			}
			case 4:
				if (this.m_k)
				{
					num = 7;
					num2 = num;
					continue;
				}
				break;
			case 3:
				a("USB 未拔出" + Environment.NewLine);
				num = 2;
				num2 = num;
				continue;
			case 8:
				wParam = m.WParam;
				num = 6;
				num2 = num;
				continue;
			case 6:
				if (wParam.ToInt32() != 32772)
				{
					break;
				}
				goto IL_0162;
			case 7:
				this.m_a.Close();
				a("[!] ChameleonMini GP Disconnected" + Environment.NewLine);
				a("[!]检测到设备已经拔出" + Environment.NewLine);
				c();
				this.m_k = false;
				hu.Text = "连接设备";
				num = 0;
				num2 = num;
				continue;
			case 0:
				num = 1;
				if (num == 0)
				{
				}
				break;
			case 9:
				num = 1;
				num2 = num;
				continue;
			case 1:
				if (!SerialPort.GetPortNames().Contains(this.m_m))
				{
					num = 4;
					num2 = num;
					continue;
				}
				num = 0;
				_ = num;
				num = 3;
				num2 = num;
				continue;
			case 2:
				break;
				IL_0162:
				num = 9;
				num2 = num;
				continue;
			}
			break;
		}
		base.WndProc(ref m);
	}

	private void bc(object A_0, EventArgs A_1)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			string startupPath = default(string);
			switch (0)
			{
			default:
			{
				List<CheckBox>.Enumerator enumerator = default(List<CheckBox>.Enumerator);
				string text = default(string);
				string text2 = default(string);
				string text3 = default(string);
				int num5 = default(int);
				CheckBox current = default(CheckBox);
				int filterIndex = default(int);
				int num4 = default(int);
				while (true)
				{
					switch (num2)
					{
					case 1:
						if (!string.IsNullOrEmpty(this.m_ay.Text))
						{
							num = 4;
							num2 = num;
							continue;
						}
						goto case 3;
					case 3:
						enumerator = a<CheckBox>(this.m_a4.Controls, "checkBox").GetEnumerator();
						num = 2;
						num2 = num;
						continue;
					case 2:
						num = 0;
						_ = num;
						try
						{
							num = 38;
							num2 = num;
							while (true)
							{
								string obj2;
								string obj;
								string obj4;
								string obj3;
								switch (num2)
								{
								case 38:
									switch (0)
									{
									default:
										continue;
									case 0:
										break;
									}
									goto default;
								case 30:
									num = 3;
									num2 = num;
									continue;
								case 3:
									obj2 = text;
									goto IL_0457;
								case 9:
								case 32:
									num = 24;
									num2 = num;
									continue;
								case 24:
									if (!File.Exists(text2))
									{
										num = 21;
										num2 = num;
									}
									else
									{
										text2 = Path.Combine(startupPath, $"{text3}_{++num5}.bin");
										num = 32;
										num2 = num;
									}
									continue;
								case 26:
									obj = text + ".eml";
									goto IL_06b9;
								case 33:
									if (text.ToLower().Contains(".bin"))
									{
										num = 10;
										num2 = num;
									}
									else
									{
										num = 17;
										num2 = num;
									}
									continue;
								case 42:
									text2 = Path.Combine(startupPath, text3 + ".bin");
									num5 = 0;
									num = 9;
									num2 = num;
									continue;
								default:
									num = 36;
									num2 = num;
									continue;
								case 36:
									if (!enumerator.MoveNext())
									{
										num = 41;
										num2 = num;
									}
									else
									{
										current = enumerator.Current;
										num = 29;
										num2 = num;
									}
									continue;
								case 34:
									num = 8;
									num2 = num;
									continue;
								case 8:
									obj4 = text;
									goto IL_0630;
								case 29:
									if (current.Checked)
									{
										num = 2;
										num2 = num;
										continue;
									}
									goto default;
								case 1:
									num = 19;
									num2 = num;
									continue;
								case 5:
									text = this.m_at.FileName.Trim();
									filterIndex = this.m_at.FilterIndex;
									num = 23;
									num2 = num;
									continue;
								case 23:
									switch (filterIndex)
									{
									case 1:
										num = 33;
										num2 = num;
										break;
									default:
										num = 1;
										num2 = num;
										break;
									case 2:
										num = 4;
										num2 = num;
										break;
									case 4:
										num = 37;
										num2 = num;
										break;
									case 3:
										num = 28;
										num2 = num;
										break;
									}
									continue;
								case 17:
									obj3 = text + ".bin";
									goto IL_0538;
								case 7:
									obj4 = text + ".json";
									goto IL_0630;
								case 4:
									if (!text.ToLower().EndsWith(".json"))
									{
										num = 7;
										num2 = num;
									}
									else
									{
										num = 34;
										num2 = num;
									}
									continue;
								case 37:
									if (text.ToLower().EndsWith(".mct"))
									{
										num = 30;
										num2 = num;
									}
									else
									{
										num = 14;
										num2 = num;
									}
									continue;
								case 39:
									this.m_at.InitialDirectory = startupPath;
									num = 12;
									num2 = num;
									continue;
								case 12:
									if (this.m_at.ShowDialog() == DialogResult.OK)
									{
										num = 5;
										num2 = num;
										continue;
									}
									break;
								case 31:
									if (!string.IsNullOrEmpty(text3))
									{
										num = 42;
										num2 = num;
										continue;
									}
									goto default;
								case 10:
									num = 27;
									num2 = num;
									continue;
								case 27:
									obj3 = text;
									goto IL_0538;
								case 6:
									n($"SETTING{this.m_i}={num4 - this.m_p}");
									num = 18;
									num2 = num;
									continue;
								case 18:
									if (!dv.Enabled)
									{
										text3 = m("UID" + this.m_i + "?").ToString();
										num = 31;
										num2 = num;
									}
									else
									{
										num = 39;
										num2 = num;
									}
									continue;
								case 2:
									num4 = int.Parse(current.Name.Substring(current.Name.Length - 1));
									num = 20;
									num2 = num;
									continue;
								case 20:
									if (num4 > 0)
									{
										num = 6;
										num2 = num;
										continue;
									}
									goto default;
								case 14:
									obj2 = text + ".mct";
									goto IL_0457;
								case 0:
									num = 15;
									num2 = num;
									continue;
								case 15:
									obj = text;
									goto IL_06b9;
								case 21:
									s(text2);
									num = 13;
									num2 = num;
									continue;
								case 28:
									if (!text.ToLower().EndsWith(".eml"))
									{
										num = 26;
										num2 = num;
									}
									else
									{
										num = 0;
										num2 = num;
									}
									continue;
								case 16:
								case 19:
								case 22:
								case 25:
								case 40:
									s(text);
									num = 11;
									num2 = num;
									continue;
								case 11:
									goto end_IL_00ef;
								case 41:
									break;
								case 35:
									goto end_IL_00ef;
									IL_0457:
									text = obj2;
									num = 40;
									num2 = num;
									continue;
									IL_06b9:
									text = obj;
									num = 25;
									num2 = num;
									continue;
									IL_0538:
									text = obj3;
									num = 22;
									num2 = num;
									continue;
									IL_0630:
									text = obj4;
									num = 16;
									num2 = num;
									continue;
								}
								num = 35;
								num2 = num;
								continue;
								end_IL_00ef:
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
						d();
						Cursor = Cursors.Default;
						return;
					case 4:
						num = 0;
						num2 = num;
						continue;
					case 0:
					{
						if (!Directory.Exists(this.m_ay.Text))
						{
							goto case 3;
						}
						num = -5065;
						short num3 = num;
						num = -5065;
						switch (num3 == num)
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
						goto IL_0941;
					}
					case 5:
						{
							startupPath = this.m_ay.Text;
							goto IL_0941;
						}
						IL_0941:
						num = 3;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				num = 1;
				if (num != 0)
				{
				}
				Cursor = Cursors.WaitCursor;
				e();
				startupPath = Application.StartupPath;
				num = 1;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private void bb(object A_0, EventArgs A_1)
	{
		short num = 0;
		switch (num)
		{
		}
		num = 96;
		int num2 = num;
		byte[] array2 = default(byte[]);
		int num6 = default(int);
		int num5 = default(int);
		string path = default(string);
		List<string> list3 = default(List<string>);
		string[] array3 = default(string[]);
		int num7 = default(int);
		StreamWriter streamWriter = default(StreamWriter);
		List<MyKey> list4 = default(List<MyKey>);
		byte b2 = default(byte);
		byte b = default(byte);
		MyKey myKey3 = default(MyKey);
		string text2 = default(string);
		MyKey myKey4 = default(MyKey);
		List<MyKey> list = default(List<MyKey>);
		List<MyKey> list2 = default(List<MyKey>);
		int num8 = default(int);
		int num9 = default(int);
		MyKey myKey6 = default(MyKey);
		int num10 = default(int);
		MyKey myKey7 = default(MyKey);
		MyKey myKey5 = default(MyKey);
		int num3 = default(int);
		MyKey myKey = default(MyKey);
		MyKey myKey2 = default(MyKey);
		string text = default(string);
		while (true)
		{
			int num4;
			switch (num2)
			{
			case 96:
				switch (0)
				{
				default:
					continue;
				case 0:
					break;
				}
				goto default;
			default:
				if (MessageBox.Show("计算侦测数据时间可能非常长，如果系统不复杂可以点取消，然后点快速计算侦测数据，点击确定，继续计算", "耐心等待", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
				{
					num = 14;
					num2 = num;
					continue;
				}
				Cursor = Cursors.WaitCursor;
				e();
				num = 62;
				num2 = num;
				continue;
			case 14:
				return;
			case 62:
				if (this.m_w == global::b.b)
				{
					num = 24;
					num2 = num;
				}
				else
				{
					num = 87;
					num2 = num;
				}
				continue;
			case 24:
				num = 1;
				if (num != 0)
				{
				}
				num = 22;
				num2 = num;
				continue;
			case 22:
			{
				ParallelQuery<string> values = a<CheckBox>(this.m_a4.Controls, "checkBox").Where(delegate(CheckBox checkBox)
				{
					short num12 = 0;
					_ = num12;
					num12 = 2759;
					short num13 = num12;
					num12 = 2759;
					switch (num13 == num12)
					{
					default:
						num12 = 1;
						if (num12 != 0)
						{
						}
						num12 = 0;
						if (num12 != 0)
						{
						}
						return checkBox.Checked;
					}
				}).Select(delegate(CheckBox checkBox)
				{
					short num12 = -14669;
					short num13 = num12;
					num12 = -14669;
					switch (num13 == num12)
					{
					default:
						num12 = 0;
						_ = num12;
						break;
					case true:
						break;
					}
					num12 = 1;
					if (num12 != 0)
					{
					}
					num12 = 0;
					if (num12 != 0)
					{
					}
					int num14 = int.Parse(checkBox.Name.Substring(checkBox.Name.Length - 1));
					n($"SETTING{this.m_i}={num14 - this.m_p}");
					byte[] value = m("DETECTION" + this.m_i + "?") as byte[];
					return new KeyValuePair<int, byte[]>(num14, value);
				}).OrderBy(delegate(KeyValuePair<int, byte[]> keyValuePair)
				{
					short num12 = 0;
					_ = num12;
					num12 = -9956;
					short num13 = num12;
					num12 = -9956;
					switch (num13 == num12)
					{
					default:
						num12 = 0;
						if (num12 != 0)
						{
						}
						num12 = 1;
						if (num12 != 0)
						{
						}
						return keyValuePair.Key;
					}
				})
					.AsParallel()
					.AsOrdered()
					.Select(delegate(KeyValuePair<int, byte[]> keyValuePair)
					{
						int num12 = default(int);
						string text3 = default(string);
						switch (0)
						{
						default:
							while (true)
							{
								switch (num12)
								{
								case 2:
									if (keyValuePair.Value.Length < 208)
									{
										short num13 = 1;
										num12 = num13;
									}
									else
									{
										text3 = MfKeyAttacks.Attack(keyValuePair.Value);
										short num13 = 5;
										num12 = num13;
									}
									continue;
								case 4:
								case 5:
								{
									short num13 = 6;
									num12 = num13;
									continue;
								}
								case 6:
									if (string.IsNullOrWhiteSpace(text3))
									{
										short num13 = 3;
										num12 = num13;
										continue;
									}
									goto IL_01c2;
								case 3:
								{
									short num13 = 1;
									if (num13 != 0)
									{
									}
									text3 = "mfkey32 attack failed, no keys found" + Environment.NewLine;
									num13 = 0;
									num12 = num13;
									continue;
								}
								case 1:
								{
									text3 = "";
									short num13 = 4;
									num12 = num13;
									continue;
								}
								case 0:
									{
										short num13 = 0;
										_ = num13;
										num13 = -5515;
										short num14 = num13;
										num13 = -5515;
										switch (num14 == num13)
										{
										case false:
										case true:
											continue;
										}
										num13 = 0;
										if (num13 == 0)
										{
										}
										goto IL_01c2;
									}
									IL_01c2:
									return $"[Tag slot {keyValuePair.Key}]{Environment.NewLine}" + text3;
								}
								break;
							}
							goto case 0;
						case 0:
						{
							text3 = "";
							short num13 = 2;
							num12 = num13;
							goto default;
						}
						}
					});
				this.m_ar.AppendText(string.Join(string.Empty, values));
				num = 5;
				num2 = num;
				continue;
			}
			case 87:
				if (this.m_w == global::b.c)
				{
					num = 70;
					num2 = num;
					continue;
				}
				break;
			case 70:
				n("PCRDETECTION" + this.m_i + "?");
				array2 = k();
				num6 = array2.Length;
				num4 = 0;
				num = 27;
				num2 = num;
				continue;
			case 27:
				if (num6 > 4096)
				{
					num = 85;
					num2 = num;
				}
				else
				{
					num = 45;
					num2 = num;
				}
				continue;
			case 85:
				n("PCRDETECTION" + this.m_i + "=0");
				a("还没有任何侦测数据");
				num = 25;
				num2 = num;
				continue;
			case 45:
				if (num6 >= 2)
				{
					num = 61;
					num2 = num;
					continue;
				}
				goto case 25;
			case 61:
			{
				byte[] array4 = new byte[2]
				{
					array2[num4++],
					array2[num4++]
				};
				num5 = (array4[1] << 8) | array4[0];
				path = "auto_keys/h.dic";
				string[] array5 = File.ReadAllLines("auto_keys/h.dic");
				list3 = new List<string>
				{
					"ffffffffffff", "d3f7d3f7d3f7", "000000000000", "b0b1b2b3b4b5", "4d3a99c351dd", "1a982c7e459a", "aabbccddeeff", "714c5c886e97", "587ee5f9350f", "a0478cc39091",
					"533cb6c723f6", "8fd0a4f256e9"
				};
				array3 = array5;
				num7 = 0;
				num = 46;
				num2 = num;
				continue;
			}
			case 3:
			case 46:
				num = 8;
				num2 = num;
				continue;
			case 8:
				if (num7 < array3.Length)
				{
					string item = array3[num7];
					list3.Add(item);
					num7++;
					num = 3;
					num2 = num;
				}
				else
				{
					num = 86;
					num2 = num;
				}
				continue;
			case 86:
				streamWriter = new StreamWriter(path, append: true);
				a("记录一共有" + num5 + "个字节侦测数据\n");
				list4 = new List<MyKey>();
				num = 26;
				num2 = num;
				continue;
			case 49:
				if (num4 + 4 <= num5)
				{
					num = 38;
					num2 = num;
					continue;
				}
				goto case 30;
			case 38:
				b2 = array2[num4++];
				b = array2[num4++];
				num = 16;
				num2 = num;
				continue;
			case 16:
				if (b2 != 192)
				{
					num = 55;
					num2 = num;
					continue;
				}
				goto case 57;
			case 55:
				num = 63;
				num2 = num;
				continue;
			case 63:
				if (b2 == 161)
				{
					num = 57;
					num2 = num;
					continue;
				}
				goto case 26;
			case 57:
				num = 37;
				num2 = num;
				continue;
			case 37:
				if (b > 0)
				{
					num = 23;
					num2 = num;
					continue;
				}
				goto case 81;
			case 23:
				num = 35;
				num2 = num;
				continue;
			case 35:
				if (num4 + b <= num5)
				{
					num = 9;
					num2 = num;
					continue;
				}
				goto case 81;
			case 9:
			{
				byte[] array = new byte[b];
				Array.Copy(array2, num4, array, 0, b);
				myKey3 = new MyKey
				{
					KeyType = array[0],
					Block = array[1],
					UID = MfKeyAttacks.ToUInt32(array, 2),
					nt0 = MfKeyAttacks.ToUInt32(array, 6),
					nr0 = MfKeyAttacks.ToUInt32(array, 10),
					ar0 = MfKeyAttacks.ToUInt32(array, 14),
					ar1 = MfKeyAttacks.ToUInt32(array, 18)
				};
				myKey3.Sector = MfKeyAttacks.ToSector(myKey3.Block);
				num = 56;
				num2 = num;
				continue;
			}
			case 56:
				if (myKey3.ar1 != 0)
				{
					num = 34;
					num2 = num;
					continue;
				}
				goto IL_0a65;
			case 34:
				num = 92;
				num2 = num;
				continue;
			case 92:
				if (myKey3.UID != 0)
				{
					num = 72;
					num2 = num;
					continue;
				}
				goto IL_0a65;
			case 72:
				num = 80;
				num2 = num;
				continue;
			case 80:
				if (myKey3.nt0 != 0)
				{
					num = 21;
					num2 = num;
					continue;
				}
				goto IL_0a65;
			case 21:
				try
				{
					myKey3.key = MfKey.MfKey64(myKey3.UID, myKey3.nt0, myKey3.nr0, myKey3.ar0, myKey3.ar1);
					myKey3.Found = myKey3.key != ulong.MaxValue;
				}
				catch (Exception)
				{
				}
				num = 28;
				num2 = num;
				continue;
			case 28:
				if (myKey3.Found)
				{
					num = 19;
					num2 = num;
					continue;
				}
				goto case 51;
			case 19:
			{
				a("认证成功的key:");
				string a_2 = $"[Sector{myKey3.Sector}/Block{myKey3.Block}]  Key found [{myKey3.key:x12}]  UID [{myKey3.UID:x8}]  ";
				a(a_2);
				text2 = $"{myKey3.key:x12}";
				num = 52;
				num2 = num;
				continue;
			}
			case 52:
				if (!list3.Contains(text2))
				{
					num = 10;
					num2 = num;
					continue;
				}
				goto case 51;
			case 10:
				streamWriter.WriteLine(text2);
				list3.Add(text2);
				a("已经添加到历史密钥");
				num = 51;
				num2 = num;
				continue;
			case 51:
				num4 += b;
				num = 83;
				num2 = num;
				continue;
			case 47:
				if (myKey3.Sector != byte.MaxValue)
				{
					num = 82;
					num2 = num;
					continue;
				}
				goto case 81;
			case 82:
			{
				num = -24753;
				short num11 = num;
				num = -24753;
				switch (num11 == num)
				{
				default:
					num = 0;
					if (num != 0)
					{
					}
					list4.Add(myKey3);
					num = 81;
					num2 = num;
					continue;
				case false:
				case true:
					break;
				}
				goto IL_0c0a;
			}
			case 81:
				num4 += b;
				num = 91;
				num2 = num;
				continue;
			case 26:
			case 83:
			case 91:
				num = 74;
				num2 = num;
				continue;
			case 74:
				if (num4 <= num5)
				{
					num = 49;
					num2 = num;
				}
				else
				{
					num = 30;
					num2 = num;
				}
				continue;
			case 30:
				num = 36;
				num2 = num;
				continue;
			case 36:
				if (!list4.Any())
				{
					num = 64;
					num2 = num;
				}
				else
				{
					num = 6;
					num2 = num;
				}
				continue;
			case 64:
				d();
				Cursor = Cursors.Default;
				this.m_ar.AppendText(Environment.NewLine + "Didn't find any nonces for mfkey32" + Environment.NewLine);
				streamWriter.Close();
				return;
			case 6:
				if (list4.Count <= 60)
				{
					this.m_ar.AppendText($"{Environment.NewLine}Starting mfkey32 with {list4.Count} nonces {Environment.NewLine}");
					num = 89;
					num2 = num;
					continue;
				}
				goto IL_0c0a;
			case 71:
				this.m_ar.AppendText($"{Environment.NewLine}Starting mfkey32 with {list4.Count} nonces {Environment.NewLine}{Environment.NewLine}数据量太大，计算时间超过10分钟，请耐心等待，下次请侦测前清除侦测数据/记录，或者侦测时刷的次数不要太多。 {Environment.NewLine}{Environment.NewLine}{Environment.NewLine}");
				num = 99;
				num2 = num;
				continue;
			case 89:
			case 99:
				new KeyCompareruid();
				new KeyComparer();
				a("正在计算侦测的key，耐心等待");
				myKey4 = new MyKey();
				list = new List<MyKey>();
				list2 = new List<MyKey>();
				num = 60;
				num2 = num;
				continue;
			case 60:
				if (list4.Count() - 6 > 0)
				{
					num = 77;
					num2 = num;
					continue;
				}
				goto case 73;
			case 77:
				list4.Count();
				num = 73;
				num2 = num;
				continue;
			case 73:
				num8 = list4.Count() - 1;
				num = 15;
				num2 = num;
				continue;
			case 11:
				if (num9 <= 5)
				{
					num = 59;
					num2 = num;
					continue;
				}
				goto case 40;
			case 59:
				myKey6 = list4[num10];
				myKey7 = myKey5;
				num = 1;
				num2 = num;
				continue;
			case 1:
				if (myKey6.Block == myKey7.Block)
				{
					num = 0;
					num2 = num;
					continue;
				}
				goto case 94;
			case 0:
				num = 98;
				num2 = num;
				continue;
			case 98:
				if (myKey6.Sector == myKey7.Sector)
				{
					num = 4;
					num2 = num;
					continue;
				}
				goto case 94;
			case 4:
				num = 12;
				num2 = num;
				continue;
			case 12:
				if (myKey6.KeyType == myKey7.KeyType)
				{
					num = 90;
					num2 = num;
					continue;
				}
				goto case 94;
			case 90:
				num = 84;
				num2 = num;
				continue;
			case 84:
				if (myKey6.UID == myKey7.UID)
				{
					num = 78;
					num2 = num;
					continue;
				}
				goto case 94;
			case 78:
				list.Add(myKey6);
				list2.Add(myKey7);
				num9++;
				num = 94;
				num2 = num;
				continue;
			case 94:
				num10--;
				num = 20;
				num2 = num;
				continue;
			case 17:
			case 20:
				num = 76;
				num2 = num;
				continue;
			case 76:
				if (num10 > 0)
				{
					num = 11;
					num2 = num;
					continue;
				}
				num = 0;
				_ = num;
				num = 40;
				num2 = num;
				continue;
			case 40:
				num8--;
				num = 68;
				num2 = num;
				continue;
			case 15:
			case 68:
				num = 2;
				num2 = num;
				continue;
			case 2:
				if (num8 > 0)
				{
					myKey5 = list4[num8];
					num9 = 0;
					num10 = num8 - 1;
					num = 17;
					num2 = num;
				}
				else
				{
					num = 58;
					num2 = num;
				}
				continue;
			case 58:
				num7 = list.Count;
				a("配对结束共有" + num7 + "组\n");
				num3 = 0;
				num = 95;
				num2 = num;
				continue;
			case 31:
				if (myKey.Sector == myKey2.Sector)
				{
					num = 39;
					num2 = num;
					continue;
				}
				goto case 43;
			case 39:
				num = 13;
				num2 = num;
				continue;
			case 13:
				if (myKey.UID == myKey2.UID)
				{
					num = 54;
					num2 = num;
					continue;
				}
				goto case 69;
			case 54:
				num = 75;
				num2 = num;
				continue;
			case 75:
				if (myKey.Sector == myKey2.Sector)
				{
					num = 50;
					num2 = num;
					continue;
				}
				goto case 69;
			case 50:
				num = 18;
				num2 = num;
				continue;
			case 18:
				if (myKey.KeyType == myKey2.KeyType)
				{
					num = 67;
					num2 = num;
					continue;
				}
				goto case 69;
			case 67:
				num = 53;
				num2 = num;
				continue;
			case 53:
				try
				{
					a("正在计算，请稍后,第" + num3 + "组....\n");
					myKey.key = MfKey.MfKey32(myKey.UID, myKey.nt0, myKey.nr0, myKey.ar0, myKey2.nt0, myKey2.nr0, myKey2.ar0);
					myKey.Found = myKey.key != ulong.MaxValue;
				}
				catch (Exception)
				{
				}
				num = 65;
				num2 = num;
				continue;
			case 65:
				if (myKey.Found)
				{
					num = 66;
					num2 = num;
					continue;
				}
				goto case 69;
			case 66:
				num = 7;
				num2 = num;
				continue;
			case 7:
				if (myKey4.KeyType == myKey.KeyType)
				{
					num = 79;
					num2 = num;
					continue;
				}
				goto case 48;
			case 79:
				num = 93;
				num2 = num;
				continue;
			case 93:
				if (myKey4.UID == myKey.UID)
				{
					num = 41;
					num2 = num;
					continue;
				}
				goto case 48;
			case 41:
				num = 97;
				num2 = num;
				continue;
			case 97:
				if (myKey4.Sector != myKey.Sector)
				{
					num = 48;
					num2 = num;
					continue;
				}
				goto case 69;
			case 48:
			{
				string a_ = $"[Sector/扇区{myKey.Sector}/Block{myKey.Block}]  Key found/发现密钥 [{myKey.key:x12}]   UID卡号 [{myKey.UID:x8}]  ";
				a(a_);
				text = $"{myKey.key:x12}";
				num = 44;
				num2 = num;
				continue;
			}
			case 44:
				if (!list3.Contains(text))
				{
					num = 33;
					num2 = num;
					continue;
				}
				goto case 69;
			case 33:
				streamWriter.WriteLine(text);
				list3.Add(text);
				a("已经添加到历史密钥");
				num = 69;
				num2 = num;
				continue;
			case 69:
				num3++;
				num = 32;
				num2 = num;
				continue;
			case 32:
			case 95:
				num = 42;
				num2 = num;
				continue;
			case 42:
				if (num3 < list.Count())
				{
					myKey = list[num3];
					myKey2 = list2[num3];
					num = 31;
					num2 = num;
				}
				else
				{
					num = 43;
					num2 = num;
				}
				continue;
			case 43:
				streamWriter.Close();
				Cursor = Cursors.Default;
				num = 29;
				num2 = num;
				continue;
			case 25:
			case 29:
				d();
				Cursor = Cursors.Default;
				num = 88;
				num2 = num;
				continue;
			case 5:
			case 88:
				break;
				IL_0a65:
				num = 47;
				num2 = num;
				continue;
				IL_0c0a:
				num = 71;
				num2 = num;
				continue;
			}
			break;
		}
		d();
		Cursor = Cursors.Default;
	}

	private void ba(object A_0, EventArgs A_1)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			List<CheckBox>.Enumerator enumerator = default(List<CheckBox>.Enumerator);
			List<CheckBox> list = default(List<CheckBox>);
			List<CheckBox> list2 = default(List<CheckBox>);
			switch (0)
			{
			default:
			{
				int num3 = default(int);
				CheckBox current = default(CheckBox);
				while (true)
				{
					switch (num2)
					{
					case 8:
						try
						{
							num = 9;
							num2 = num;
							while (true)
							{
								switch (num2)
								{
								case 9:
									switch (0)
									{
									default:
										continue;
									case 0:
										break;
									}
									goto default;
								default:
									num = 11;
									num2 = num;
									continue;
								case 11:
								{
									if (!enumerator.MoveNext())
									{
										num = 6;
										num2 = num;
										continue;
									}
									CheckBox current2 = enumerator.Current;
									num3 = int.Parse(current2.Name.Substring(current2.Name.Length - 1));
									num = 12;
									num2 = num;
									continue;
								}
								case 12:
									if (num3 > 0)
									{
										num = 1;
										num2 = num;
										continue;
									}
									goto default;
								case 1:
								{
									int num5 = num3 - this.m_p;
									n($"SETTING{this.m_i}={num5}");
									num = 8;
									num2 = num;
									continue;
								}
								case 8:
									if (this.m_w == global::b.c)
									{
										num = 27908;
										short num4 = num;
										num = 27908;
										switch (num4 == num)
										{
										case false:
										case true:
											continue;
										}
										num = 0;
										if (num != 0)
										{
										}
										n("PCRCLEAR" + this.m_i);
										num = 4;
										num2 = num;
									}
									else
									{
										num = 2;
										num2 = num;
									}
									continue;
								case 2:
									n("CLEAR" + this.m_i);
									num = 5;
									num2 = num;
									continue;
								case 4:
								case 5:
									num = 7;
									num2 = num;
									continue;
								case 7:
									if (this.m_w == global::b.c)
									{
										num = 0;
										num2 = num;
										continue;
									}
									goto case 13;
								case 13:
									a(num3, A_1: false);
									num = 3;
									num2 = num;
									continue;
								case 0:
									a<ComboBox>(this.m_a4.Controls, $"cb_mode{num3}").ForEach(delegate
									{
										short num6 = 24524;
										short num7 = num6;
										num6 = 24524;
										switch (num7 == num6)
										{
										default:
											num6 = 0;
											_ = num6;
											break;
										case true:
											break;
										}
										num6 = 1;
										if (num6 != 0)
										{
										}
										num6 = 0;
										if (num6 != 0)
										{
										}
										n("CONFIG" + this.m_i + "=NONE");
									});
									a<ComboBox>(this.m_a4.Controls, $"cb_Lbutton{num3}").ForEach(delegate(ComboBox comboBox)
									{
										short num6 = -8398;
										short num7 = num6;
										num6 = -8398;
										switch (num7 == num6)
										{
										default:
											num6 = 0;
											_ = num6;
											break;
										case true:
											break;
										}
										num6 = 0;
										if (num6 != 0)
										{
										}
										num6 = 1;
										if (num6 != 0)
										{
										}
										n($"LBUTTON{this.m_i}={comboBox.Items[0]}");
									});
									a<ComboBox>(this.m_a4.Controls, $"cb_Lbuttonlong{num3}").ForEach(delegate(ComboBox comboBox)
									{
										short num6 = 26897;
										short num7 = num6;
										num6 = 26897;
										switch (num7 == num6)
										{
										default:
											num6 = 0;
											_ = num6;
											break;
										case true:
											break;
										}
										num6 = 1;
										if (num6 != 0)
										{
										}
										num6 = 0;
										if (num6 != 0)
										{
										}
										n($"LBUTTON_LONG{this.m_i}={comboBox.Items[0]}");
									});
									a<ComboBox>(this.m_a4.Controls, $"cb_Rbutton{num3}").ForEach(delegate(ComboBox comboBox)
									{
										short num6 = -18583;
										short num7 = num6;
										num6 = -18583;
										switch (num7 == num6)
										{
										default:
											num6 = 0;
											_ = num6;
											break;
										case true:
											break;
										}
										num6 = 1;
										if (num6 != 0)
										{
										}
										num6 = 0;
										if (num6 != 0)
										{
										}
										n($"RBUTTON{this.m_i}={comboBox.Items[0]}");
									});
									a<ComboBox>(this.m_a4.Controls, $"cb_Rbuttonlong{num3}").ForEach(delegate(ComboBox comboBox)
									{
										short num6 = 1;
										if (num6 != 0)
										{
										}
										num6 = 0;
										_ = num6;
										num6 = 20656;
										short num7 = num6;
										num6 = 20656;
										switch (num7 == num6)
										{
										default:
											num6 = 0;
											if (num6 != 0)
											{
											}
											n($"RBUTTON_LONG{this.m_i}={comboBox.Items[0]}");
											break;
										}
									});
									a<ComboBox>(this.m_a4.Controls, $"cb_ledgreen{num3}").ForEach(delegate(ComboBox comboBox)
									{
										short num6 = 7189;
										short num7 = num6;
										num6 = 7189;
										switch (num7 == num6)
										{
										default:
											num6 = 0;
											_ = num6;
											break;
										case true:
											break;
										}
										num6 = 1;
										if (num6 != 0)
										{
										}
										num6 = 0;
										if (num6 != 0)
										{
										}
										n($"LEDGREEN{this.m_i}={comboBox.Items[0]}");
									});
									a<ComboBox>(this.m_a4.Controls, $"cb_ledred{num3}").ForEach(delegate(ComboBox comboBox)
									{
										short num6 = 1;
										if (num6 != 0)
										{
										}
										num6 = 0;
										_ = num6;
										num6 = 20922;
										short num7 = num6;
										num6 = 20922;
										switch (num7 == num6)
										{
										default:
											num6 = 0;
											if (num6 != 0)
											{
											}
											n($"LEDRED{this.m_i}={comboBox.Items[0]}");
											break;
										}
									});
									num = 13;
									num2 = num;
									continue;
								case 6:
									num = 10;
									num2 = num;
									continue;
								case 10:
									break;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
						d();
						num = 4;
						num2 = num;
						continue;
					case 6:
						n("CLEARALL");
						p();
						num = 2;
						num2 = num;
						continue;
					case 7:
						try
						{
							num = 4;
							num2 = num;
							while (true)
							{
								switch (num2)
								{
								case 4:
									switch (0)
									{
									default:
										continue;
									case 0:
										break;
									}
									goto default;
								case 1:
									list.Add(current);
									num = 5;
									num2 = num;
									continue;
								case 0:
									if (current.Checked)
									{
										num = 1;
										num2 = num;
										continue;
									}
									goto default;
								default:
									num = 2;
									num2 = num;
									continue;
								case 2:
									if (enumerator.MoveNext())
									{
										current = enumerator.Current;
										num = 0;
										num2 = num;
									}
									else
									{
										num = 3;
										num2 = num;
									}
									continue;
								case 3:
									num = 6;
									num2 = num;
									continue;
								case 6:
									break;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
						num = 0;
						_ = num;
						num = 0;
						num2 = num;
						continue;
					case 5:
						num = 1;
						num2 = num;
						continue;
					case 1:
						if (list.Count == list2.Count)
						{
							num = 1;
							if (num != 0)
							{
							}
							num = 3;
							num2 = num;
							continue;
						}
						goto IL_0604;
					case 0:
						if (this.m_w == global::b.b)
						{
							num = 5;
							num2 = num;
							continue;
						}
						goto IL_0604;
					case 3:
						num = 9;
						num2 = num;
						continue;
					case 9:
						if (this.m_ak.Contains("CLEARALL"))
						{
							num = 6;
							num2 = num;
							continue;
						}
						goto IL_0604;
					case 2:
					case 4:
						{
							Cursor = Cursors.Default;
							return;
						}
						IL_0604:
						e();
						enumerator = list.GetEnumerator();
						num = 8;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				Cursor = Cursors.WaitCursor;
				list = new List<CheckBox>();
				list2 = a<CheckBox>(this.m_a4.Controls, "checkBox");
				enumerator = list2.GetEnumerator();
				num = 7;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private void a9(object A_0, EventArgs A_1)
	{
		short num = -15231;
		short num2 = num;
		num = -15231;
		switch (num2 == num)
		{
		default:
		{
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
			Cursor = Cursors.WaitCursor;
			using (List<CheckBox>.Enumerator enumerator = a<CheckBox>(this.m_a4.Controls, "checkBox").GetEnumerator())
			{
				num = 11;
				int num3 = num;
				int num4 = default(int);
				CheckBox current = default(CheckBox);
				while (true)
				{
					switch (num3)
					{
					case 11:
						switch (0)
						{
						default:
							continue;
						case 0:
							break;
						}
						goto default;
					case 12:
						num4 = int.Parse(current.Name.Substring(current.Name.Length - 1));
						num = 13;
						num3 = num;
						continue;
					case 13:
						if (num4 > 0)
						{
							num = 5;
							num3 = num;
							continue;
						}
						goto default;
					case 14:
						if (current.Checked)
						{
							num = 12;
							num3 = num;
							continue;
						}
						goto default;
					case 15:
						h4.Checked = true;
						num = 3;
						num3 = num;
						continue;
					default:
						num = 10;
						num3 = num;
						continue;
					case 10:
						if (enumerator.MoveNext())
						{
							current = enumerator.Current;
							num = 14;
							num3 = num;
						}
						else
						{
							num = 7;
							num3 = num;
						}
						continue;
					case 5:
						a(num4, A_1: true);
						this.m_y = true;
						num = 1;
						num3 = num;
						continue;
					case 1:
						if (!m("GDMMODE" + this.m_i + "?").ToString().Equals("1"))
						{
							h9.Checked = false;
							num = 2;
							num3 = num;
						}
						else
						{
							num = 4;
							num3 = num;
						}
						continue;
					case 2:
					case 6:
						num = 0;
						num3 = num;
						continue;
					case 0:
						if (!m("SAKMODE" + this.m_i + "?").ToString().Equals("1"))
						{
							h4.Checked = false;
							num = 8;
							num3 = num;
						}
						else
						{
							num = 15;
							num3 = num;
						}
						continue;
					case 4:
						h9.Checked = true;
						num = 6;
						num3 = num;
						continue;
					case 7:
						num = 9;
						num3 = num;
						continue;
					case 9:
						break;
					}
					break;
				}
			}
			break;
		}
		case false:
		case true:
			break;
		}
		this.m_y = false;
		Cursor = Cursors.Default;
	}

	private void a8(object A_0, EventArgs A_1)
	{
		short num = 6478;
		short num2 = num;
		num = 6478;
		switch (num2 == num)
		{
		default:
		{
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
			Cursor = Cursors.WaitCursor;
			using (List<CheckBox>.Enumerator enumerator = a<CheckBox>(this.m_a4.Controls, "checkBox").GetEnumerator())
			{
				num = 6;
				int num3 = num;
				CheckBox current = default(CheckBox);
				int num4 = default(int);
				while (true)
				{
					switch (num3)
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
					case 0:
						if (current.Checked)
						{
							num = 7;
							num3 = num;
							continue;
						}
						goto default;
					default:
						num = 1;
						num3 = num;
						continue;
					case 1:
						if (enumerator.MoveNext())
						{
							current = enumerator.Current;
							num = 0;
							num3 = num;
						}
						else
						{
							num = 2;
							num3 = num;
						}
						continue;
					case 7:
						num4 = int.Parse(current.Name.Substring(current.Name.Length - 1));
						num = 3;
						num3 = num;
						continue;
					case 3:
						if (num4 > 0)
						{
							num = 4;
							num3 = num;
							continue;
						}
						goto default;
					case 4:
						n($"SETTING{this.m_i}={num4 - this.m_p}");
						this.m_x = num4;
						num = 8;
						num3 = num;
						continue;
					case 8:
						break;
					case 2:
						num = 5;
						num3 = num;
						continue;
					case 5:
						break;
					}
					break;
				}
			}
			break;
		}
		case false:
		case true:
			break;
		}
		f();
		Cursor = Cursors.Default;
	}

	private void a7(object A_0, EventArgs A_1)
	{
		short num = 8;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 8:
				switch (0)
				{
				default:
					goto end_IL_0020;
				case 0:
					break;
				}
				goto default;
			default:
				if (this.m_a != null)
				{
					num = 10;
					num2 = num;
				}
				else
				{
					s();
					num = 9;
					num2 = num;
				}
				break;
			case 3:
				num = 5;
				num2 = num;
				break;
			case 5:
				if (!this.m_a.IsOpen)
				{
					num = -9019;
					short num3 = num;
					num = -9019;
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
						num = 11;
						num2 = num;
						break;
					}
				}
				else
				{
					r();
					w();
					num = 2;
					num2 = num;
				}
				break;
			case 11:
				return;
			case 9:
				if (!this.m_l)
				{
					num = 7;
					num2 = num;
					break;
				}
				return;
			case 7:
				num = 0;
				_ = num;
				q();
				num = 6;
				num2 = num;
				break;
			case 4:
				return;
			case 10:
				num = 1;
				num2 = num;
				break;
			case 1:
				num = 1;
				if (num != 0)
				{
				}
				if (!d2.Checked)
				{
					num = 4;
					num2 = num;
				}
				else
				{
					num = 12;
					num2 = num;
				}
				break;
			case 6:
				if (this.m_a == null)
				{
					return;
				}
				num = 3;
				num2 = num;
				break;
			case 2:
				return;
			case 0:
				r();
				return;
			case 12:
				{
					if (!string.IsNullOrEmpty(m("PCRPANDA" + this.m_i + "?").ToString()))
					{
						num = 0;
						num2 = num;
						break;
					}
					s();
					return;
				}
				end_IL_0020:
				break;
			}
		}
	}

	private void a6(object A_0, EventArgs A_1)
	{
		short num = 5866;
		short num2 = num;
		num = 5866;
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
		a(A_0: true);
	}

	private void a5(object A_0, EventArgs A_1)
	{
		short num = -26593;
		short num2 = num;
		num = -26593;
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
		a(A_0: false);
	}

	private void a4(object A_0, EventArgs A_1)
	{
		short num = 1;
		if (num != 0)
		{
		}
		int num2 = default(int);
		int num3 = default(int);
		switch (0)
		{
		default:
			while (true)
			{
				switch (num2)
				{
				case 4:
				{
					if (num3 == 1)
					{
						num = 5;
						num2 = num;
						continue;
					}
					num = -27151;
					short num4 = num;
					num = -27151;
					switch (num4 == num)
					{
					default:
						num = 0;
						if (num != 0)
						{
						}
						num = 0;
						num2 = num;
						continue;
					case false:
					case true:
						break;
					}
					goto case 0;
				}
				case 1:
					this.m_bh.Enabled = true;
					this.m_be.Enabled = true;
					this.m_bf.Enabled = true;
					dv.Enabled = false;
					this.m_bg.Enabled = true;
					this.m_bj.Enabled = true;
					this.m_bi.Enabled = true;
					g8.Enabled = false;
					h3.Enabled = true;
					h7.Enabled = true;
					h4.Enabled = false;
					ia.Enabled = true;
					h8.Enabled = true;
					h9.Enabled = false;
					return;
				case 0:
					num = 0;
					_ = num;
					if (num3 > 1)
					{
						num = 1;
						num2 = num;
						continue;
					}
					this.m_bh.Enabled = false;
					this.m_be.Enabled = false;
					this.m_bf.Enabled = false;
					dv.Enabled = false;
					this.m_bg.Enabled = false;
					this.m_bj.Enabled = false;
					this.m_bi.Enabled = false;
					g8.Enabled = false;
					h3.Enabled = false;
					h4.Enabled = false;
					h7.Enabled = false;
					h8.Enabled = false;
					h9.Enabled = false;
					ia.Enabled = false;
					num = 6;
					num2 = num;
					continue;
				case 5:
					this.m_bh.Enabled = true;
					this.m_be.Enabled = true;
					this.m_bf.Enabled = true;
					dv.Enabled = true;
					this.m_bg.Enabled = true;
					ia.Enabled = true;
					this.m_bj.Enabled = true;
					this.m_bi.Enabled = true;
					num = 2;
					num2 = num;
					continue;
				case 2:
					if (this.m_w == global::b.c)
					{
						num = 3;
						num2 = num;
						continue;
					}
					return;
				case 6:
					return;
				case 3:
					g8.Enabled = true;
					h3.Enabled = true;
					h4.Enabled = true;
					h7.Enabled = true;
					h8.Enabled = true;
					h9.Enabled = true;
					return;
				}
				break;
			}
			goto case 0;
		case 0:
			num3 = t();
			num = 4;
			num2 = num;
			goto default;
		}
	}

	private void a3(object A_0, EventArgs A_1)
	{
		short num = -7644;
		short num2 = num;
		num = -7644;
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
		n("RESET" + this.m_i);
	}

	private void a2(object A_0, EventArgs A_1)
	{
		short num = 15020;
		short num2 = num;
		num = 15020;
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
		object obj = m("RSSI" + this.m_i + "?");
		this.m_a2.Text = obj.ToString();
	}

	private void a1(object A_0, EventArgs A_1)
	{
		short num = 3;
		int num2 = num;
		string selectedPath = default(string);
		while (true)
		{
			switch (num2)
			{
			case 3:
				switch (0)
				{
				default:
					goto end_IL_0021;
				case 0:
					break;
				}
				goto default;
			default:
				num = 1;
				if (num != 0)
				{
				}
				if (dw.ShowDialog() == DialogResult.OK)
				{
					num = 4;
					num2 = num;
					break;
				}
				return;
			case 4:
			{
				num = -29275;
				short num3 = num;
				num = -29275;
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
					selectedPath = dw.SelectedPath;
					num = 2;
					num2 = num;
					goto end_IL_0021;
				}
				goto case 3;
			}
			case 1:
				this.m_ay.Text = selectedPath;
				Settings.Default.DownloadDumpPath = selectedPath;
				Settings.Default.Save();
				num = 0;
				num2 = num;
				break;
			case 0:
				return;
			case 2:
				{
					if (selectedPath != null)
					{
						num = 1;
						num2 = num;
						break;
					}
					return;
				}
				end_IL_0021:
				break;
			}
		}
	}

	private void a0(object A_0, EventArgs A_1)
	{
		int num = default(int);
		int result = default(int);
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 6:
					if (!string.IsNullOrEmpty(d0.Text))
					{
						short num2 = 7;
						num = num2;
						continue;
					}
					goto case 0;
				case 4:
				{
					this.m_j.Stop();
					this.m_j.Interval = result;
					this.m_j.Start();
					short num2 = 2;
					num = num2;
					continue;
				}
				case 5:
				{
					short num2 = 28472;
					short num3 = num2;
					num2 = 28472;
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
						num2 = 1;
						num = num2;
						continue;
					case false:
					case true:
						break;
					}
					goto IL_021c;
				}
				case 1:
					if (d2.Checked)
					{
						short num2 = 4;
						num = num2;
						continue;
					}
					goto case 2;
				case 7:
				{
					int.TryParse(d0.Text, out result);
					short num2 = 0;
					num = num2;
					continue;
				}
				case 2:
				{
					short num2 = 0;
					_ = num2;
					Settings.Default.EnableKeepAlive = d2.Checked;
					Settings.Default.KeepAliveInterval = result;
					Settings.Default.Save();
					return;
				}
				case 0:
				{
					short num2 = 3;
					num = num2;
					continue;
				}
				case 3:
					{
						if (result > 0)
						{
							short num2 = 5;
							num = num2;
							continue;
						}
						goto IL_021c;
					}
					IL_021c:
					MessageBox.Show("Only positive numbers are allowed for the interval of the keep-alive setting", "Interval not valid", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			result = 0;
			short num2 = 6;
			num = num2;
			goto default;
		}
		}
	}

	private void az(object A_0, EventArgs A_1)
	{
		short num = 28151;
		short num2 = num;
		num = 28151;
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
		c();
	}

	private void ay(object A_0, EventArgs A_1)
	{
		short num = 4;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 4:
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
				if (this.m_k)
				{
					num = 5;
					num2 = num;
				}
				else
				{
					q();
					num = 1;
					num2 = num;
				}
				continue;
			case 5:
			{
				num = -24584;
				short num3 = num;
				num = -24584;
				switch (num3 == num)
				{
				default:
					num = 0;
					if (num == 0)
					{
					}
					return;
				case false:
				case true:
					break;
				}
				goto case 2;
			}
			case 3:
				num = 2;
				num2 = num;
				continue;
			case 2:
				if (!this.m_a.IsOpen)
				{
					num = 1;
					if (num != 0)
					{
					}
					num = 0;
					num2 = num;
					continue;
				}
				this.m_l = false;
				r();
				w();
				return;
			case 1:
				if (this.m_a != null)
				{
					num = 3;
					num2 = num;
					continue;
				}
				break;
			case 0:
				break;
			}
			break;
		}
		MessageBox.Show("Unable to connect to the Chameleon device", "Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	private void ax(object A_0, EventArgs A_1)
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
					goto end_IL_001f;
				case 0:
					break;
				}
				goto default;
			default:
				if (this.m_as.ShowDialog() == DialogResult.OK)
				{
					num = 0;
					_ = num;
					num = 0;
					num2 = num;
					break;
				}
				return;
			case 0:
			{
				num = 1;
				if (num != 0)
				{
				}
				string fileName = this.m_as.FileName;
				OpenFile(fileName, d9);
				num = -23814;
				short num3 = num;
				num = -23814;
				switch (num3 == num)
				{
				default:
					num = 0;
					if (num != 0)
					{
					}
					num = 1;
					num2 = num;
					break;
				case false:
				case true:
					return;
				}
				break;
			}
			case 1:
				return;
				end_IL_001f:
				break;
			}
		}
	}

	private void aw(object A_0, EventArgs A_1)
	{
		short num = -26712;
		short num2 = num;
		num = -26712;
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
		d(d9);
	}

	private void av(object A_0, EventArgs A_1)
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
					goto end_IL_001f;
				case 0:
					break;
				}
				goto default;
			default:
				if (this.m_as.ShowDialog() == DialogResult.OK)
				{
					num = 0;
					_ = num;
					num = 0;
					num2 = num;
					break;
				}
				return;
			case 0:
			{
				num = 1;
				if (num != 0)
				{
				}
				string fileName = this.m_as.FileName;
				OpenFile(fileName, d8);
				num = 12570;
				short num3 = num;
				num = 12570;
				switch (num3 == num)
				{
				default:
					num = 0;
					if (num != 0)
					{
					}
					num = 1;
					num2 = num;
					break;
				case false:
				case true:
					return;
				}
				break;
			}
			case 1:
				return;
				end_IL_001f:
				break;
			}
		}
	}

	private void au(object A_0, EventArgs A_1)
	{
		short num = 15110;
		short num2 = num;
		num = 15110;
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
		d(d8);
	}

	private void d(object A_0, DragEventArgs A_1)
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
					goto end_IL_0021;
				case 0:
					break;
				}
				goto default;
			default:
				if (A_1.Data.GetDataPresent(DataFormats.FileDrop))
				{
					num = 0;
					_ = num;
					num = 0;
					num2 = num;
					break;
				}
				return;
			case 0:
			{
				num = 1;
				if (num != 0)
				{
				}
				A_1.Effect = DragDropEffects.Copy;
				num = 4571;
				short num3 = num;
				num = 4571;
				switch (num3 == num)
				{
				default:
					num = 0;
					if (num != 0)
					{
					}
					num = 1;
					num2 = num;
					break;
				case false:
				case true:
					return;
				}
				break;
			}
			case 1:
				return;
				end_IL_0021:
				break;
			}
		}
	}

	private void c(object A_0, DragEventArgs A_1)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			string[] array = default(string[]);
			switch (0)
			{
			default:
			{
				Control control = default(Control);
				while (true)
				{
					object obj;
					HexBox hexBox;
					switch (num2)
					{
					case 10:
						if (array != null)
						{
							num = 7;
							num2 = num;
							continue;
						}
						goto case 3;
					case 11:
						obj = (HexBox)control;
						goto IL_01d7;
					case 9:
						num = 2;
						num2 = num;
						continue;
					case 2:
						obj = d9;
						goto IL_01d7;
					case 5:
						num = 6;
						num2 = num;
						continue;
					case 6:
						if (array.Length == 1)
						{
							num = 4;
							num2 = num;
							continue;
						}
						OpenFile(array[0], d9);
						OpenFile(array[1], d8);
						num = 3;
						num2 = num;
						continue;
					case 7:
						num = 8;
						num2 = num;
						continue;
					case 8:
						if (array.Length != 0)
						{
							num = 5;
							num2 = num;
							continue;
						}
						goto case 3;
					case 0:
					{
						num = -6273;
						short num3 = num;
						num = -6273;
						switch (num3 == num)
						{
						case false:
						case true:
							continue;
						}
						num = 1;
						if (num != 0)
						{
						}
						num = 0;
						if (num == 0)
						{
						}
						goto case 3;
					}
					case 4:
					{
						Point pos = d7.PointToClient(new Point(A_1.X, A_1.Y));
						control = FindControlAtPoint(d7, pos);
						num = 1;
						num2 = num;
						continue;
					}
					case 1:
						if (control is HexBox)
						{
							num = 11;
							num2 = num;
						}
						else
						{
							num = 9;
							num2 = num;
						}
						continue;
					case 3:
						{
							d9.Focus();
							return;
						}
						IL_01d7:
						hexBox = (HexBox)obj;
						OpenFile(array[0], hexBox);
						num = 0;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				array = (string[])A_1.Data.GetData(DataFormats.FileDrop);
				num = 0;
				_ = num;
				num = 10;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private void at(object A_0, EventArgs A_1)
	{
		int num = default(int);
		RadioButton radioButton = default(RadioButton);
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 3:
				{
					short num2 = -957;
					short num3 = num2;
					num2 = -957;
					switch (num3 == num2)
					{
					default:
						num2 = 0;
						_ = num2;
						goto case true;
					case true:
						num2 = 0;
						if (num2 != 0)
						{
						}
						if (radioButton == null)
						{
							num2 = 0;
							num = num2;
						}
						else
						{
							num2 = 1;
							num = num2;
						}
						continue;
					case false:
					case true:
						break;
					}
					goto case 2;
				}
				case 0:
					return;
				case 1:
				{
					if (!radioButton.Checked)
					{
						short num2 = 2;
						num = num2;
						continue;
					}
					string a_ = radioButton.Name.Substring(radioButton.Name.Length - 2);
					p(a_);
					return;
				}
				case 2:
				{
					short num2 = 1;
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
			radioButton = A_0 as RadioButton;
			short num2 = 3;
			num = num2;
			goto default;
		}
		}
	}

	private void @as(object A_0, EventArgs A_1)
	{
		short num = -13331;
		short num2 = num;
		num = -13331;
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
		i();
	}

	private void b(object A_0, VScrollEventArgs A_1)
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
				if (!e0.Checked)
				{
					return;
				}
				num = 0;
				_ = num;
				num = -7237;
				short num3 = num;
				num = -7237;
				switch (num3 == num)
				{
				default:
					num = 0;
					if (num != 0)
					{
					}
					num = 4;
					num2 = num;
					goto end_IL_0020;
				case false:
				case true:
					break;
				}
				goto IL_0155;
			}
			case 1:
				d8.PerformScrollToLine(A_1.Pos);
				num = 0;
				num2 = num;
				break;
			case 0:
				return;
			case 4:
				num = 2;
				num2 = num;
				break;
			case 2:
				{
					if (A_1.Pos == d8.CurrentLine)
					{
						return;
					}
					goto IL_0155;
				}
				IL_0155:
				num = 1;
				num2 = num;
				break;
				end_IL_0020:
				break;
			}
		}
	}

	private void a(object A_0, VScrollEventArgs A_1)
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
				if (!e0.Checked)
				{
					break;
				}
				num = 22803;
				short num3 = num;
				num = 22803;
				switch (num3 == num)
				{
				default:
					num = 0;
					_ = num;
					goto case true;
				case true:
					num = 0;
					if (num != 0)
					{
					}
					num = 4;
					num2 = num;
					continue;
				case false:
				case true:
					break;
				}
				goto IL_012a;
			}
			case 1:
				d9.PerformScrollToLine(A_1.Pos);
				num = 0;
				num2 = num;
				continue;
			case 4:
				num = 2;
				num2 = num;
				continue;
			case 2:
				if (A_1.Pos == d9.CurrentLine)
				{
					break;
				}
				goto IL_012a;
			case 0:
				break;
				IL_012a:
				num = 1;
				num2 = num;
				continue;
			}
			break;
		}
		num = 1;
		if (num == 0)
		{
		}
	}

	private void ar(object A_0, EventArgs A_1)
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
			{
				if (d9.Focused)
				{
					return;
				}
				num = -31097;
				short num3 = num;
				num = -31097;
				switch (num3 == num)
				{
				default:
					num = 0;
					_ = num;
					goto case true;
				case true:
					num = 0;
					if (num != 0)
					{
					}
					num = 4;
					num2 = num;
					goto end_IL_001f;
				case false:
				case true:
					break;
				}
				goto IL_014c;
			}
			case 1:
				d9.Focus();
				num = 1;
				if (num != 0)
				{
				}
				num = 0;
				num2 = num;
				break;
			case 0:
				return;
			case 4:
				num = 2;
				num2 = num;
				break;
			case 2:
				{
					if (d8.Focused)
					{
						return;
					}
					goto IL_014c;
				}
				IL_014c:
				num = 1;
				num2 = num;
				break;
				end_IL_001f:
				break;
			}
		}
	}

	private void b(object A_0, ToolStripItemClickedEventArgs A_1)
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
				if (A_1.ClickedItem.Name == "toolStripMenuItem1")
				{
					num = 4;
					num2 = num;
				}
				else
				{
					num = 2;
					num2 = num;
				}
				break;
			case 4:
			{
				num = -7887;
				short num3 = num;
				num = -7887;
				switch (num3 == num)
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
					_ = num;
					num = 0;
					if (num != 0)
					{
					}
					e0.Checked = !e0.Checked;
					return;
				}
				goto case 3;
			}
			case 1:
				c(d9);
				c(d8);
				num = 0;
				num2 = num;
				break;
			case 0:
				return;
			case 2:
				{
					if (A_1.ClickedItem.Name == "toolStripMenuItem2")
					{
						num = 1;
						num2 = num;
						break;
					}
					return;
				}
				end_IL_001f:
				break;
			}
		}
	}

	private void aq(object A_0, EventArgs A_1)
	{
		short num = 7159;
		short num2 = num;
		num = 7159;
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
		e0.Checked = !e0.Checked;
	}

	private void ap(object A_0, EventArgs A_1)
	{
		short num = 1;
		if (num != 0)
		{
		}
		int num2 = default(int);
		HexBox hexBox = default(HexBox);
		switch (0)
		{
		default:
			while (true)
			{
				switch (num2)
				{
				case 2:
					num = 0;
					_ = num;
					if (!hexBox.Focused)
					{
						num = 0;
						num2 = num;
						continue;
					}
					return;
				case 0:
					hexBox.Focus();
					goto IL_00ae;
				case 1:
					{
						num = 19704;
						short num3 = num;
						num = 19704;
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
						goto IL_00ae;
					}
					IL_00ae:
					num = 1;
					num2 = num;
					continue;
				}
				break;
			}
			goto case 0;
		case 0:
			hexBox = (HexBox)A_0;
			num = 2;
			num2 = num;
			goto default;
		}
	}

	private void ao(object A_0, EventArgs A_1)
	{
		short num = -19298;
		short num2 = num;
		num = -19298;
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
		Process.Start(Application.StartupPath);
	}

	private void an(object A_0, EventArgs A_1)
	{
		short num = 22685;
		short num2 = num;
		num = 22685;
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
		fd.Text = string.Empty;
		fc.Text = string.Empty;
	}

	private void b(object A_0, LinkLabelLinkClickedEventArgs A_1)
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = -11703;
		short num2 = num;
		num = -11703;
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
		fg.LinkVisited = true;
		Process.Start("https://github.com/iceman1001/ChameleonMini-rebooted/wiki/Terminal-Commands");
	}

	private void a(object A_0, LinkLabelLinkClickedEventArgs A_1)
	{
		short num = 7577;
		short num2 = num;
		num = 7577;
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
		fh.LinkVisited = true;
		Process.Start("https://rawgit.com/emsec/ChameleonMini/master/Doc/Doxygen/html/_page__command_line.html");
	}

	private void a(object A_0, ToolStripItemClickedEventArgs A_1)
	{
		short num = 8;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 8:
				switch (0)
				{
				default:
					goto end_IL_001f;
				case 0:
					break;
				}
				goto default;
			default:
				if (A_1.ClickedItem.Name == "tsmi_selectall")
				{
					num = 1;
					num2 = num;
					break;
				}
				goto case 6;
			case 4:
				num = 0;
				num2 = num;
				break;
			case 0:
				if (A_1.ClickedItem.Name == "tsmi_clear")
				{
					num = 7;
					num2 = num;
					break;
				}
				return;
			case 1:
				fc.Focus();
				fc.SelectAll();
				num = 6;
				num2 = num;
				break;
			case 7:
				num = 0;
				_ = num;
				fc.Text = string.Empty;
				num = 2;
				num2 = num;
				break;
			case 2:
				return;
			case 6:
				num = 3;
				num2 = num;
				break;
			case 3:
				if (A_1.ClickedItem.Name == "tsmi_copy")
				{
					num = 5;
					num2 = num;
					break;
				}
				goto case 4;
			case 5:
				{
					num = 1;
					if (num != 0)
					{
					}
					num = 23525;
					short num3 = num;
					num = 23525;
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
						Clipboard.SetText(fc.Text);
						num = 4;
						num2 = num;
						goto end_IL_001f;
					}
					goto case 1;
				}
				end_IL_001f:
				break;
			}
		}
	}

	private void a(object A_0, KeyPressEventArgs A_1)
	{
		short num = 3;
		int num2 = num;
		string text = default(string);
		while (true)
		{
			switch (num2)
			{
			case 3:
				num = 1;
				if (num != 0)
				{
				}
				switch (0)
				{
				default:
					goto end_IL_0049;
				case 0:
					break;
				}
				goto default;
			default:
				if (A_1.KeyChar != '\r')
				{
					num = 2;
					num2 = num;
				}
				else
				{
					text = ((TextBox)A_0).Text.Trim();
					num = 1;
					num2 = num;
				}
				break;
			case 0:
				return;
			case 1:
				if (string.IsNullOrWhiteSpace(text))
				{
					num = 0;
					num2 = num;
					break;
				}
				q(text);
				return;
			case 2:
				{
					num = -8838;
					short num3 = num;
					num = -8838;
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
						_ = num;
						return;
					}
					break;
				}
				end_IL_0049:
				break;
			}
		}
	}

	private void am(object A_0, EventArgs A_1)
	{
		string text = fd.Text.Trim();
		short num;
		if (string.IsNullOrWhiteSpace(text))
		{
			num = 0;
			_ = num;
			return;
		}
		num = 30055;
		short num2 = num;
		num = 30055;
		switch (num2 == num)
		{
		case false:
		case true:
			return;
		}
		num = 1;
		if (num != 0)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		q(text);
	}

	private void al(object A_0, EventArgs A_1)
	{
		short num = 31122;
		short num2 = num;
		num = 31122;
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
		c(d9);
	}

	private void ak(object A_0, EventArgs A_1)
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = -8142;
		short num2 = num;
		num = -8142;
		switch (num2 == num)
		{
		}
		num = 0;
		_ = num;
		num = 0;
		if (num != 0)
		{
		}
		c(d8);
	}

	private void aj(object A_0, EventArgs A_1)
	{
		short num = 3386;
		short num2 = num;
		num = 3386;
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
		global::c.e(this.m_a4);
	}

	private void ai(object A_0, EventArgs A_1)
	{
		short num = -3923;
		short num2 = num;
		num = -3923;
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

	private void ah(object A_0, EventArgs A_1)
	{
		short num = -32239;
		short num2 = num;
		num = -32239;
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
		global::c.e(this.m_a4);
	}

	private void ag(object A_0, EventArgs A_1)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			int num3 = default(int);
			string[] array = default(string[]);
			switch (0)
			{
			default:
			{
				int num4 = default(int);
				List<CheckBox>.Enumerator enumerator = default(List<CheckBox>.Enumerator);
				CheckBox current = default(CheckBox);
				while (true)
				{
					switch (num2)
					{
					case 3:
						num = 1;
						if (num != 0)
						{
						}
						try
						{
							num = 8;
							num2 = num;
							while (true)
							{
								switch (num2)
								{
								case 8:
									switch (0)
									{
									default:
										continue;
									case 0:
										break;
									}
									goto default;
								case 6:
									a(num4, A_1: true);
									num = 1;
									num2 = num;
									continue;
								default:
									num = 0;
									num2 = num;
									continue;
								case 0:
									if (!enumerator.MoveNext())
									{
										num = 8116;
										short num5 = num;
										num = 8116;
										switch (num5 == num)
										{
										default:
											num = 0;
											if (num != 0)
											{
											}
											num = 7;
											num2 = num;
											continue;
										case false:
										case true:
											break;
										}
										break;
									}
									current = enumerator.Current;
									num = 2;
									num2 = num;
									continue;
								case 3:
									num4 = int.Parse(current.Name.Substring(current.Name.Length - 1));
									num = 4;
									num2 = num;
									continue;
								case 4:
									if (num4 > 0)
									{
										num = 6;
										num2 = num;
										continue;
									}
									goto default;
								case 2:
									if (current.Checked)
									{
										num = 3;
										num2 = num;
										continue;
									}
									goto default;
								case 7:
									break;
								case 5:
									goto end_IL_00c0;
								}
								num = 5;
								num2 = num;
								continue;
								end_IL_00c0:
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
						d();
						Cursor = Cursors.Default;
						return;
					case 2:
					case 4:
						num = 0;
						num2 = num;
						continue;
					case 0:
						if (num3 < array.Length)
						{
							string text = array[num3];
							this.m_ar.AppendText("[+] " + text + Environment.NewLine);
							num3++;
							num = 2;
							num2 = num;
						}
						else
						{
							num = 1;
							num2 = num;
						}
						continue;
					case 1:
						num = 0;
						_ = num;
						enumerator = a<CheckBox>(this.m_a4.Controls, "checkBox").GetEnumerator();
						num = 3;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				Cursor = Cursors.WaitCursor;
				e();
				array = l("IDENTIFY" + this.m_i).ToString().Split(new string[1] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
				num3 = 0;
				num = 4;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private void af(object A_0, EventArgs A_1)
	{
		short num;
		if (!(A_0 is TextBox textBox))
		{
			num = 0;
			_ = num;
			return;
		}
		num = -26444;
		short num2 = num;
		num = -26444;
		switch (num2 == num)
		{
		case false:
		case true:
			return;
		}
		num = 0;
		if (num != 0)
		{
		}
		num = 1;
		if (num != 0)
		{
		}
		fd.Text = textBox.Text;
		fd.SelectionStart = fd.Text.Length;
		fd.SelectionLength = 0;
		base.ActiveControl = fd;
	}

	private void b(object A_0, DragEventArgs A_1)
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
		if (!A_1.Data.GetDataPresent(DataFormats.FileDrop))
		{
			num = -15646;
			short num2 = num;
			num = -15646;
			switch (num2 == num)
			{
			case false:
			case true:
				break;
			default:
				num = 0;
				if (num != 0)
				{
				}
				A_1.Effect = DragDropEffects.None;
				return;
			}
		}
		A_1.Effect = DragDropEffects.Copy;
	}

	private void a(object A_0, DragEventArgs A_1)
	{
		int num = default(int);
		string[] array = default(string[]);
		switch (0)
		{
		default:
		{
			int num4 = default(int);
			string text = default(string);
			while (true)
			{
				switch (num)
				{
				case 6:
					if (array.Length != 0)
					{
						short num2 = 1;
						num = num2;
						continue;
					}
					return;
				case 4:
					return;
				case 2:
				{
					num4 = int.Parse(((TableLayoutPanel)A_0).Name.Substring(((TableLayoutPanel)A_0).Name.Length - 1));
					short num2 = 5;
					num = num2;
					continue;
				}
				case 5:
				{
					short num2 = 24656;
					short num3 = num2;
					num2 = 24656;
					switch (num3 == num2)
					{
					default:
						num2 = 0;
						if (num2 != 0)
						{
						}
						num2 = 0;
						_ = num2;
						if (num4 <= 0)
						{
							num2 = 4;
							num = num2;
							continue;
						}
						n($"SETTING{this.m_i}={num4 - this.m_p}");
						r(text);
						a(num4, A_1: true);
						num2 = 3;
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
					text = array[0];
					short num2 = 0;
					num = num2;
					continue;
				}
				case 0:
					if (File.Exists(text))
					{
						short num2 = 2;
						num = num2;
						continue;
					}
					return;
				case 3:
					return;
				}
				break;
			}
			goto case 0;
		}
		case 0:
		{
			short num2 = 1;
			if (num2 != 0)
			{
			}
			array = (string[])A_1.Data.GetData(DataFormats.FileDrop, autoConvert: false);
			num2 = 6;
			num = num2;
			goto default;
		}
		}
	}

	private void ae(object A_0, EventArgs A_1)
	{
		int num = default(int);
		TextBox textBox = default(TextBox);
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 3:
				{
					short num2 = 0;
					_ = num2;
					if (textBox != null)
					{
						num2 = 2;
						num = num2;
						continue;
					}
					return;
				}
				case 2:
				{
					short num2 = 1;
					num = num2;
					continue;
				}
				case 1:
				{
					short num2;
					if (!textBox.Visible)
					{
						num2 = 0;
						num = num2;
						continue;
					}
					num2 = 1;
					if (num2 != 0)
					{
					}
					textBox.SelectionStart = textBox.TextLength;
					textBox.ScrollToCaret();
					return;
				}
				case 0:
				{
					short num2 = 21128;
					short num3 = num2;
					num2 = 21128;
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
						return;
					}
					break;
				}
				}
				break;
			}
			goto case 0;
		case 0:
		{
			textBox = (TextBox)A_0;
			short num2 = 3;
			num = num2;
			goto default;
		}
		}
	}

	private void w()
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = -22655;
		short num2 = num;
		num = -22655;
		switch (num2 == num)
		{
		}
		num = 0;
		_ = num;
		num = 0;
		if (num != 0)
		{
		}
		g7.AvailableCommands = this.m_ak;
		g7.SetList();
	}

	private void v()
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 15;
			int num2 = num;
			KeyValuePair<string, string> keyValuePair = default(KeyValuePair<string, string>);
			string text = default(string);
			IEnumerator enumerator = default(IEnumerator);
			IDisposable disposable = default(IDisposable);
			MultiLanguage multiLanguage = default(MultiLanguage);
			Dictionary<string, string> templates = default(Dictionary<string, string>);
			Dictionary<string, string> languages = default(Dictionary<string, string>);
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
					if (!string.IsNullOrEmpty(Settings.Default.DownloadDumpPath))
					{
						num = 18;
						num2 = num;
						break;
					}
					goto case 17;
				case 16:
					try
					{
						num = 8;
						num2 = num;
						while (true)
						{
							switch (num2)
							{
							case 8:
								switch (0)
								{
								default:
									continue;
								case 0:
									break;
								}
								goto default;
							case 1:
								if (!(keyValuePair.Key.ToLowerInvariant() == text))
								{
									num = 0;
									num2 = num;
									continue;
								}
								goto case 4;
							case 0:
								num = 7;
								num2 = num;
								continue;
							case 7:
							{
								num = 31466;
								short num3 = num;
								num = 31466;
								switch (num3 == num)
								{
								case false:
								case true:
									break;
								default:
									goto IL_01b0;
								}
								goto case 1;
							}
							default:
								num = 6;
								num2 = num;
								continue;
							case 6:
								if (enumerator.MoveNext())
								{
									keyValuePair = (KeyValuePair<string, string>)enumerator.Current;
									num = 1;
									num2 = num;
								}
								else
								{
									num = 2;
									num2 = num;
								}
								continue;
							case 4:
								e4.SelectedItem = keyValuePair;
								num = 3;
								num2 = num;
								continue;
							case 3:
								break;
							case 2:
								num = 5;
								num2 = num;
								continue;
							case 5:
								break;
								IL_01b0:
								num = 0;
								if (num != 0)
								{
								}
								if (keyValuePair.Value.ToLowerInvariant() == text)
								{
									num = 4;
									num2 = num;
									continue;
								}
								goto default;
							}
							break;
						}
					}
					finally
					{
						switch (0)
						{
						default:
							while (true)
							{
								switch (num2)
								{
								case 2:
									if (disposable != null)
									{
										num = 0;
										num2 = num;
										continue;
									}
									goto end_IL_028c;
								case 0:
									disposable.Dispose();
									num = 1;
									num2 = num;
									continue;
								case 1:
									goto end_IL_028c;
								}
								goto case 0;
								continue;
								end_IL_028c:
								break;
							}
							break;
						case 0:
							disposable = enumerator as IDisposable;
							num = 2;
							num2 = num;
							goto default;
						}
					}
					this.m_v = false;
					num = 0;
					num2 = num;
					break;
				case 7:
					if (!string.IsNullOrWhiteSpace(text))
					{
						num = 10;
						num2 = num;
						break;
					}
					goto case 0;
				case 10:
					num = 1;
					if (num != 0)
					{
					}
					multiLanguage.LoadLanguage(base.Controls, text);
					this.m_v = true;
					enumerator = e4.Items.GetEnumerator();
					num = 16;
					num2 = num;
					break;
				case 17:
					d2.Checked = Settings.Default.EnableKeepAlive;
					num = 3;
					num2 = num;
					break;
				case 3:
					if (Settings.Default.KeepAliveInterval > 0)
					{
						num = 2;
						num2 = num;
					}
					else
					{
						d0.Text = "10000";
						num = 14;
						num2 = num;
					}
					break;
				case 11:
					this.m_ay.Text = Settings.Default.DownloadDumpPath;
					num = 17;
					num2 = num;
					break;
				case 9:
					this.m_v = true;
					e8.DataSource = templates;
					e7.DisplayMember = "Key";
					e7.ValueMember = "Value";
					this.m_v = false;
					num = 1;
					num2 = num;
					break;
				case 1:
					return;
				case 8:
					this.m_v = true;
					e5.DataSource = languages;
					e4.DisplayMember = "Key";
					e4.ValueMember = "Value";
					this.m_v = false;
					num = 4;
					num2 = num;
					break;
				case 4:
					num = 0;
					_ = num;
					goto IL_02fa;
				case 2:
					d0.Text = Settings.Default.KeepAliveInterval.ToString();
					num = 13;
					num2 = num;
					break;
				case 0:
					templates = new Templating().GetTemplates();
					num = 5;
					num2 = num;
					break;
				case 5:
					if (templates.Any())
					{
						num = 9;
						num2 = num;
						break;
					}
					return;
				case 18:
					num = 12;
					num2 = num;
					break;
				case 12:
					if (Directory.Exists(Settings.Default.DownloadDumpPath))
					{
						num = 11;
						num2 = num;
						break;
					}
					goto case 17;
				case 13:
				case 14:
					multiLanguage = new MultiLanguage();
					languages = multiLanguage.GetLanguages();
					num = 6;
					num2 = num;
					break;
				case 6:
					{
						if (languages.Any())
						{
							num = 8;
							num2 = num;
							break;
						}
						goto IL_02fa;
					}
					IL_02fa:
					text = Settings.Default.Language.ToLowerInvariant();
					num = 7;
					num2 = num;
					break;
					end_IL_003f:
					break;
				}
			}
		}
		}
	}

	[AsyncStateMachine(typeof(c))]
	private void q(string A_0)
	{
		short num = -14097;
		short num2 = num;
		num = -14097;
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
		c stateMachine = default(c);
		stateMachine.b = AsyncVoidMethodBuilder.Create();
		stateMachine.c = this;
		stateMachine.d = A_0;
		stateMachine.a = -1;
		stateMachine.b.Start(ref stateMachine);
	}

	private void b(int A_0)
	{
		short num = 27981;
		short num2 = num;
		num = 27981;
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
		d9.BytesPerLine = A_0;
		d8.BytesPerLine = A_0;
	}

	private void p(string A_0)
	{
		short num = 2;
		int num2 = num;
		int result = default(int);
		while (true)
		{
			switch (num2)
			{
			case 2:
			{
				num = -11454;
				short num3 = num;
				num = -11454;
				switch (num3 == num)
				{
				case false:
				case true:
					goto IL_00af;
				}
				num = 0;
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
			}
			default:
				num = 1;
				if (num != 0)
				{
				}
				if (int.TryParse(A_0, out result))
				{
					break;
				}
				goto IL_00af;
			case 0:
				result = 16;
				num = 1;
				num2 = num;
				continue;
			case 1:
				{
					num = 0;
					_ = num;
					break;
				}
				IL_00af:
				num = 0;
				num2 = num;
				continue;
			}
			break;
		}
		b(result);
	}

	private void u()
	{
		int num3 = default(int);
		string text = default(string);
		switch (0)
		{
		default:
			while (true)
			{
				short num = -18496;
				short num2 = num;
				num = -18496;
				switch (num2 == num)
				{
				default:
					num = 0;
					if (num != 0)
					{
					}
					num = 0;
					_ = num;
					switch (num3)
					{
					case 2:
						if (!string.IsNullOrWhiteSpace(this.m_n))
						{
							num = 0;
							num3 = num;
							continue;
						}
						goto case 1;
					case 0:
						text = "(" + this.m_n + ")";
						num = 1;
						num3 = num;
						continue;
					case 1:
						Text = SoftwareVersion + " ---> Connected " + this.m_m + " " + text + " - " + Environment.OSVersion.VersionString;
						return;
					}
					break;
				case false:
				case true:
					break;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			text = string.Empty;
			short num = 1;
			if (num != 0)
			{
			}
			num = 2;
			num3 = num;
			goto default;
		}
		}
	}

	private void a(bool A_0)
	{
		short num = 1;
		if (num != 0)
		{
		}
		using (List<CheckBox>.Enumerator enumerator = a<CheckBox>(this.m_a4.Controls, "checkBox").GetEnumerator())
		{
			num = 4;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 4:
					switch (0)
					{
					default:
						continue;
					case 0:
						break;
					}
					goto default;
				default:
					num = 2;
					num2 = num;
					continue;
				case 2:
					if (enumerator.MoveNext())
					{
						enumerator.Current.Checked = A_0;
						num = 3;
						num2 = num;
					}
					else
					{
						num = 0;
						num2 = num;
					}
					continue;
				case 0:
				{
					num = 17852;
					short num3 = num;
					num = 17852;
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
					num = 1;
					num2 = num;
					continue;
				}
				case 1:
					break;
				}
				break;
			}
		}
		num = 0;
		_ = num;
	}

	private int t()
	{
		short num = 15949;
		short num2 = num;
		num = 15949;
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
		return a<CheckBox>(this.m_a4.Controls, "checkBox").Count(delegate(CheckBox A_0)
		{
			short num3 = -23004;
			short num4 = num3;
			num3 = -23004;
			switch (num4 == num3)
			{
			default:
				num3 = 1;
				if (num3 != 0)
				{
				}
				num3 = 0;
				if (num3 != 0)
				{
				}
				num3 = 0;
				_ = num3;
				return A_0.Checked;
			}
		});
	}

	private void s()
	{
		short num = 3;
		int num2 = num;
		List<CheckBox>.Enumerator enumerator = default(List<CheckBox>.Enumerator);
		while (true)
		{
			switch (num2)
			{
			case 3:
				num = 1;
				if (num != 0)
				{
				}
				switch (0)
				{
				default:
					goto end_IL_004a;
				case 0:
					break;
				}
				goto default;
			default:
				num = 0;
				_ = num;
				if (!this.m_k)
				{
					num = 0;
					num2 = num;
				}
				else
				{
					this.m_k = false;
					num = 4;
					num2 = num;
				}
				break;
			case 0:
				return;
			case 2:
				try
				{
					num = 21775;
					short num3 = num;
					num = 21775;
					switch (num3 == num)
					{
					default:
						num = 0;
						if (num != 0)
						{
						}
						num = 3;
						num2 = num;
						goto IL_011a;
					case false:
					case true:
						{
							num = 1;
							num2 = num;
							goto IL_011a;
						}
						IL_011a:
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
								num = 4;
								num2 = num;
								continue;
							case 4:
								if (enumerator.MoveNext())
								{
									CheckBox current = enumerator.Current;
									current.Enabled = false;
									current.Checked = false;
									num = 0;
									num2 = num;
									continue;
								}
								break;
							case 1:
								num = 2;
								num2 = num;
								continue;
							case 2:
								goto end_IL_011a;
							}
							goto case false;
							continue;
							end_IL_011a:
							break;
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
				}
				dq.Enabled = false;
				dr.Enabled = false;
				this.m_bh.Enabled = false;
				this.m_be.Enabled = false;
				this.m_bf.Enabled = false;
				dv.Enabled = false;
				g8.Enabled = false;
				this.m_bg.Enabled = false;
				this.m_bj.Enabled = false;
				this.m_bi.Enabled = false;
				ds.Enabled = false;
				dn.Enabled = false;
				this.m_a1.Enabled = false;
				dz.Enabled = false;
				d4.Enabled = false;
				d5.Enabled = true;
				fn.Enabled = false;
				fd.Enabled = false;
				g7.AvailableCommands = null;
				g7.SetList();
				return;
			case 4:
				try
				{
					this.m_a.Close();
				}
				catch (Exception)
				{
				}
				finally
				{
					this.m_a = null;
				}
				num = 1;
				num2 = num;
				break;
			case 1:
				{
					Text = SoftwareVersion ?? "";
					e1.Image = e1.InitialImage;
					FirmwareVersion = string.Empty;
					d3.Text = "NOT CONNECTED";
					d3.BackColor = Color.Red;
					d3.ForeColor = Color.White;
					d3.SelectionStart = 0;
					enumerator = a<CheckBox>(this.m_a4.Controls, "checkBox").GetEnumerator();
					num = 2;
					num2 = num;
					break;
				}
				end_IL_004a:
				break;
			}
		}
	}

	private void r()
	{
		short num = 0;
		_ = num;
		num = 1;
		int num2 = num;
		List<CheckBox>.Enumerator enumerator = default(List<CheckBox>.Enumerator);
		while (true)
		{
			switch (num2)
			{
			case 1:
				switch (0)
				{
				default:
					goto end_IL_0048;
				case 0:
					break;
				}
				goto default;
			default:
				num = 1;
				if (num != 0)
				{
				}
				if (this.m_k)
				{
					num = 2;
					num2 = num;
					break;
				}
				Cursor = Cursors.WaitCursor;
				this.m_k = true;
				u();
				SuspendUpdate.Suspend(this.m_a4);
				enumerator = a<CheckBox>(this.m_a4.Controls, "checkBox").GetEnumerator();
				num = 0;
				num2 = num;
				break;
			case 2:
				return;
			case 0:
				{
					try
					{
						num = -4108;
						short num3 = num;
						num = -4108;
						switch (num3 == num)
						{
						default:
							num = 0;
							if (num != 0)
							{
							}
							num = 3;
							num2 = num;
							goto IL_010c;
						case false:
						case true:
							{
								num = 1;
								num2 = num;
								goto IL_010c;
							}
							IL_010c:
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
									num = 4;
									num2 = num;
									continue;
								case 4:
									if (enumerator.MoveNext())
									{
										CheckBox current = enumerator.Current;
										current.Enabled = true;
										current.Checked = false;
										num = 0;
										num2 = num;
										continue;
									}
									break;
								case 1:
									num = 2;
									num2 = num;
									continue;
								case 2:
									goto end_IL_010c;
								}
								goto case false;
								continue;
								end_IL_010c:
								break;
							}
							break;
						}
					}
					finally
					{
						((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
					}
					d3.Text = "CONNECTED!";
					d3.BackColor = Color.Green;
					d3.ForeColor = Color.White;
					d3.SelectionLength = 0;
					m();
					p();
					dq.Enabled = true;
					dr.Enabled = true;
					this.m_bh.Enabled = false;
					this.m_be.Enabled = false;
					this.m_bf.Enabled = false;
					dv.Enabled = false;
					this.m_bg.Enabled = false;
					g8.Enabled = false;
					this.m_bj.Enabled = false;
					this.m_bi.Enabled = false;
					ds.Enabled = true;
					dn.Enabled = true;
					this.m_a1.Enabled = true;
					dz.Enabled = true;
					d4.Enabled = true;
					d5.Enabled = false;
					fn.Enabled = true;
					fd.Enabled = true;
					SuspendUpdate.Resume(this.m_a4);
					Cursor = Cursors.Default;
					return;
				}
				end_IL_0048:
				break;
			}
		}
	}

	private void q()
	{
		int num = default(int);
		switch (0)
		{
		default:
		{
			string text = default(string);
			while (true)
			{
				short num2;
				switch (num)
				{
				case 0:
					this.m_ar.AppendText(Environment.NewLine ?? "");
					text = h6.SelectedItem.ToString();
					this.m_a = new SerialPort();
					num2 = 11;
					num = num2;
					continue;
				case 2:
					this.m_i = string.Empty;
					this.m_ar.AppendText("[+] Success, found ChameleonGP device on '" + text + "' with " + this.m_n + " installed" + Environment.NewLine);
					this.m_m = text;
					Cursor = Cursors.Default;
					this.m_n = "Firmware RevGP RFIDFANS.COM  Official";
					e1.Image = (Bitmap)Resources.ResourceManager.GetObject("chamRevG1");
					this.m_w = global::b.c;
					this.m_p = 0;
					this.m_a4.Hide();
					g();
					this.m_a4.Show();
					dk.SelectedTab = this.m_a4;
					a("pn532_uart:" + h6.SelectedItem.ToString() + ":115200", A_1: true, A_2: false);
					return;
				case 5:
					FirmwareVersion = m("PCRPANDA?").ToString();
					num2 = 13;
					num = num2;
					continue;
				case 13:
					if (!string.IsNullOrEmpty(this.m_o))
					{
						num2 = 10;
						num = num2;
						continue;
					}
					goto IL_02a8;
				case 14:
					MessageBox.Show("请插入设备或者请安装驱动", "连接设备错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				case 6:
					num2 = 3;
					num = num2;
					continue;
				case 3:
					if (this.m_o.Contains("Chameleon"))
					{
						num2 = 4;
						num = num2;
						continue;
					}
					goto IL_0329;
				case 11:
					if (string.IsNullOrEmpty(h6.SelectedItem.ToString()))
					{
						num2 = 14;
						num = num2;
						continue;
					}
					this.m_a.PortName = h6.SelectedItem.ToString();
					this.m_a.BaudRate = 115200;
					this.m_a.DataBits = 8;
					this.m_a.StopBits = StopBits.One;
					this.m_a.Parity = Parity.None;
					this.m_a.ReadTimeout = 4000;
					this.m_a.WriteTimeout = 6000;
					this.m_a.DtrEnable = true;
					this.m_a.RtsEnable = true;
					num2 = 12;
					num = num2;
					continue;
				case 9:
					num2 = 1;
					if (num2 != 0)
					{
					}
					if (!string.IsNullOrEmpty(this.m_o))
					{
						num2 = 6;
						num = num2;
						continue;
					}
					goto IL_0329;
				case 7:
					return;
				case 1:
					if (this.m_a.IsOpen)
					{
						num2 = 5;
						num = num2;
						continue;
					}
					return;
				case 4:
					this.m_i = "MY";
					this.m_ar.AppendText("[+] Success, found Chameleon Mini device on '" + text + "' with " + this.m_n + " installed" + Environment.NewLine);
					this.m_m = text;
					e1.Image = (Bitmap)Resources.ResourceManager.GetObject("chamRevE");
					this.m_w = global::b.b;
					this.m_a4.Hide();
					h();
					dk.SelectedTab = this.m_a4;
					this.m_a4.Show();
					a("pn532_uart:" + hl.SelectedItem.ToString() + ":115200", A_1: true, A_2: false);
					Cursor = Cursors.Default;
					return;
				case 10:
					num2 = 8;
					num = num2;
					continue;
				case 8:
					if (this.m_o.Contains("Chameleon"))
					{
						num2 = 2;
						num = num2;
						continue;
					}
					goto IL_02a8;
				case 12:
					{
						try
						{
							num2 = -11423;
							short num3 = num2;
							num2 = -11423;
							switch (num3 == num2)
							{
							default:
								num2 = 0;
								if (num2 != 0)
								{
								}
								num2 = 2;
								num = num2;
								goto IL_0641;
							case false:
							case true:
								goto IL_0657;
								IL_069d:
								this.m_ar.AppendText("[=] Connecting  at " + h6.SelectedItem.ToString() + Environment.NewLine);
								this.m_a.Open();
								num2 = 1;
								num = num2;
								goto IL_0641;
								IL_0641:
								while (true)
								{
									switch (num)
									{
									case 1:
										break;
									case 2:
										switch (0)
										{
										default:
											continue;
										case 0:
											break;
										}
										goto IL_0657;
									default:
										goto IL_0657;
									case 3:
										this.m_a.Close();
										num2 = 0;
										num = num2;
										continue;
									case 0:
										goto IL_069d;
									}
									break;
								}
								break;
								IL_0657:
								if (this.m_a.IsOpen)
								{
									num2 = 3;
									num = num2;
									goto IL_0641;
								}
								goto IL_069d;
							}
						}
						catch (Exception)
						{
							this.m_m = string.Empty;
							Cursor = Cursors.Default;
							this.m_ar.AppendText("[!] Failed " + h6.SelectedItem.ToString() + Environment.NewLine);
							return;
						}
						num2 = 0;
						_ = num2;
						num2 = 1;
						num = num2;
						continue;
					}
					IL_0329:
					e1.Image = (Bitmap)Resources.ResourceManager.GetObject("usbWarning");
					this.m_a.Close();
					this.m_m = string.Empty;
					Cursor = Cursors.Default;
					this.m_ar.AppendText("Didn't find any Chameleon Mini device connected" + Environment.NewLine);
					num2 = 7;
					num = num2;
					continue;
					IL_02a8:
					FirmwareVersion = m("VERSIONMY?").ToString();
					num2 = 9;
					num = num2;
					continue;
				}
				break;
			}
			goto case 0;
		}
		case 0:
		{
			Cursor = Cursors.WaitCursor;
			e1.Image = e1.InitialImage;
			short num2 = 0;
			num = num2;
			goto default;
		}
		}
	}

	private bool o(string A_0)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 1;
			int num2 = num;
			bool flag = default(bool);
			byte[] bytes = default(byte[]);
			while (true)
			{
				bool result;
				switch (num2)
				{
				case 1:
					switch (0)
					{
					default:
						goto end_IL_003f;
					case 0:
						break;
					}
					goto default;
				default:
					if (!k(A_0))
					{
						num = 2;
						num2 = num;
					}
					else
					{
						flag = false;
						num = 0;
						num2 = num;
					}
					break;
				case 2:
					num = 1;
					if (num != 0)
					{
					}
					return false;
				case 0:
					{
						try
						{
							num = -30391;
							short num3 = num;
							num = -30391;
							switch (num3 == num)
							{
							default:
								num = 0;
								if (num != 0)
								{
								}
								num = 3;
								num2 = num;
								goto IL_0107;
							case false:
							case true:
								{
									num = 1;
									num2 = num;
									goto IL_0107;
								}
								IL_0107:
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
										if (A_0.StartsWith("PCRCLEAR"))
										{
											num = 0;
											num2 = num;
											continue;
										}
										goto case 1;
									case 4:
										try
										{
											Thread.Sleep(10);
										}
										catch (Exception)
										{
										}
										this.m_a.Write(bytes, 0, bytes.Length);
										this.m_a.Write("\r\n");
										num = 2;
										num2 = num;
										continue;
									case 1:
										this.m_a.DiscardInBuffer();
										this.m_a.DiscardOutBuffer();
										bytes = Encoding.ASCII.GetBytes(A_0);
										num = 4;
										num2 = num;
										continue;
									case 0:
										flag = true;
										this.m_a.ReadTimeout = 12000;
										this.m_a.WriteTimeout = 12000;
										break;
									case 2:
										goto end_IL_0107;
									}
									goto case false;
									continue;
									end_IL_0107:
									break;
								}
								break;
							}
						}
						catch (Exception ex2)
						{
							string text = Environment.NewLine + "[!] " + A_0 + ": " + ex2.Message + Environment.NewLine;
							this.m_ar.AppendText(text);
							result = false;
							goto IL_0317;
						}
						finally
						{
							num = 1;
							num2 = num;
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
									if (flag)
									{
										num = 2;
										num2 = num;
										continue;
									}
									break;
								case 2:
									this.m_a.ReadTimeout = 4000;
									this.m_a.WriteTimeout = 6000;
									num = 0;
									num2 = num;
									continue;
								case 0:
									break;
								}
								break;
							}
						}
						return true;
					}
					IL_0317:
					num = 0;
					_ = num;
					return result;
					end_IL_003f:
					break;
				}
			}
		}
		}
	}

	private bool n(string A_0)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 1;
			int num2 = num;
			bool flag = default(bool);
			d d = default(d);
			byte[] bytes = default(byte[]);
			while (true)
			{
				num = 1;
				if (num != 0)
				{
				}
				bool result;
				switch (num2)
				{
				case 1:
					switch (0)
					{
					default:
						goto end_IL_0067;
					case 0:
						break;
					}
					goto default;
				default:
					if (!k(A_0))
					{
						num = 2;
						num2 = num;
					}
					else
					{
						flag = false;
						num = 0;
						num2 = num;
					}
					break;
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
							{
								num = 27501;
								short num3 = num;
								num = 27501;
								switch (num3 == num)
								{
								case false:
								case true:
									goto IL_01f6;
								}
								num = 0;
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
							}
							default:
								if (!A_0.StartsWith("PCRCLEAR"))
								{
									num = 11;
									num2 = num;
									continue;
								}
								goto case 6;
							case 2:
								num = 8;
								num2 = num;
								continue;
							case 8:
								if (!A_0.StartsWith("$PCRDETECTION"))
								{
									num = 3;
									num2 = num;
									continue;
								}
								break;
							case 7:
								throw new Exception(A_0 + "returned: " + d.a.Replace("\r", ""));
							case 6:
								flag = true;
								this.m_a.ReadTimeout = 12000;
								this.m_a.WriteTimeout = 12000;
								goto IL_01f6;
							case 3:
								d = new d();
								d.a = this.m_a.ReadLine();
								num = 12;
								num2 = num;
								continue;
							case 12:
								if (this.m_al.Any(d.b))
								{
									num = 7;
									num2 = num;
									continue;
								}
								break;
							case 4:
								if (A_0.StartsWith("DETECTION" + this.m_i + "?"))
								{
									num = 2;
									num2 = num;
									continue;
								}
								goto case 3;
							case 9:
								this.m_a.DiscardInBuffer();
								this.m_a.DiscardOutBuffer();
								bytes = Encoding.ASCII.GetBytes(A_0);
								num = 1;
								num2 = num;
								continue;
							case 11:
								num = 10;
								num2 = num;
								continue;
							case 10:
								if (A_0.StartsWith("PCRPANDA"))
								{
									num = 6;
									num2 = num;
									continue;
								}
								goto case 9;
							case 1:
								try
								{
									Thread.Sleep(15);
								}
								catch (Exception)
								{
								}
								this.m_a.Write(bytes, 0, bytes.Length);
								this.m_a.Write("\r\n");
								num = 4;
								num2 = num;
								continue;
							case 5:
								goto end_IL_010a;
								IL_01f6:
								num = 9;
								num2 = num;
								continue;
							}
							num = 5;
							num2 = num;
							continue;
							end_IL_010a:
							break;
						}
					}
					catch (Exception ex2)
					{
						string text = Environment.NewLine + "[!] " + A_0 + ": " + ex2.Message + Environment.NewLine;
						this.m_ar.AppendText(text);
						result = false;
						goto IL_04b0;
					}
					finally
					{
						num = 1;
						num2 = num;
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
								if (flag)
								{
									num = 2;
									num2 = num;
									continue;
								}
								break;
							case 2:
								this.m_a.ReadTimeout = 4000;
								this.m_a.WriteTimeout = 6000;
								num = 0;
								num2 = num;
								continue;
							case 0:
								break;
							}
							break;
						}
					}
					return true;
				case 2:
					{
						return false;
					}
					IL_04b0:
					num = 0;
					_ = num;
					return result;
					end_IL_0067:
					break;
				}
			}
		}
		}
	}

	private object m(string A_0)
	{
		short num = -27962;
		short num2 = num;
		num = -27962;
		switch (num2 == num)
		{
		default:
		{
			num = 0;
			if (num != 0)
			{
			}
			num = 0;
			switch (num)
			{
			}
			num = 0;
			int num3 = num;
			object result = default(object);
			string text = default(string);
			byte[] array2 = default(byte[]);
			int num4 = default(int);
			while (true)
			{
				switch (num3)
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
					if (!k(A_0))
					{
						num = 1;
						num3 = num;
					}
					else
					{
						num = 2;
						num3 = num;
					}
					continue;
				case 1:
					break;
				case 2:
					num = 1;
					if (num != 0)
					{
					}
					try
					{
						num = 1;
						num3 = num;
						while (true)
						{
							switch (num3)
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
								if (!n(A_0))
								{
									num = 10;
									num3 = num;
								}
								else
								{
									num = 6;
									num3 = num;
								}
								continue;
							case 6:
								if (!A_0.Contains("DETECTION" + this.m_i + "?"))
								{
									num = 3;
									num3 = num;
									continue;
								}
								goto case 5;
							case 0:
								result = string.Empty;
								num = 7;
								num3 = num;
								continue;
							case 7:
								break;
							case 3:
								num = 2;
								num3 = num;
								continue;
							case 2:
								if (!A_0.Contains("PCRDETECTION" + this.m_i + "?"))
								{
									text = string.Empty;
									num = 8;
									num3 = num;
								}
								else
								{
									num = 5;
									num3 = num;
								}
								continue;
							case 8:
								try
								{
									num = 2;
									num3 = num;
									while (true)
									{
										switch (num3)
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
											num3 = num;
											continue;
										case 0:
											if (string.IsNullOrEmpty(text))
											{
												text = this.m_a.ReadLine();
												num = 1;
												num3 = num;
											}
											else
											{
												num = 4;
												num3 = num;
											}
											continue;
										case 4:
											num = 3;
											num3 = num;
											continue;
										case 3:
											break;
										}
										break;
									}
								}
								catch (TimeoutException ex)
								{
									string text2 = Environment.NewLine + "[!] " + A_0 + ": " + ex.Message + Environment.NewLine;
									this.m_ar.AppendText(text2);
								}
								result = text.Replace("\r", "");
								num = 4;
								num3 = num;
								continue;
							case 9:
								break;
							case 10:
								result = string.Empty;
								num = 11;
								num3 = num;
								continue;
							case 11:
								break;
							case 5:
								Thread.Sleep(100);
								array2 = new byte[275];
								num4 = this.m_a.Read(array2, 0, array2.Length);
								num = 12;
								num3 = num;
								continue;
							case 12:
								if (num4 > 0)
								{
									byte[] array = new byte[num4];
									Array.Copy(array2, 0, array, 0, num4);
									result = array;
									num = 9;
									num3 = num;
								}
								else
								{
									num = 0;
									num3 = num;
								}
								continue;
							case 4:
								break;
							}
							break;
						}
					}
					catch (Exception)
					{
						result = string.Empty;
					}
					return result;
				}
				break;
			}
			num = 0;
			_ = num;
			break;
		}
		case false:
		case true:
			break;
		}
		return string.Empty;
	}

	private object l(string A_0)
	{
		short num = -1133;
		short num2 = num;
		num = -1133;
		switch (num2 == num)
		{
		default:
		{
			num = 1;
			if (num != 0)
			{
			}
			num = 0;
			if (num != 0)
			{
			}
			num = 0;
			switch (num)
			{
			}
			num = 0;
			int num3 = num;
			string text = default(string);
			string text2 = default(string);
			bool flag = default(bool);
			TimeSpan timeSpan = default(TimeSpan);
			DateTime now = default(DateTime);
			DateTime now2 = default(DateTime);
			object result = default(object);
			while (true)
			{
				switch (num3)
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
					if (!k(A_0))
					{
						num = 0;
						_ = num;
						num = 1;
						num3 = num;
					}
					else
					{
						text = string.Empty;
						num = 2;
						num3 = num;
					}
					continue;
				case 2:
					try
					{
						switch (0)
						{
						default:
							while (true)
							{
								switch (num3)
								{
								case 8:
									if (!string.IsNullOrWhiteSpace(text2))
									{
										num = 0;
										num3 = num;
										continue;
									}
									goto case 2;
								case 10:
									num = 6;
									num3 = num;
									continue;
								case 6:
									if (flag)
									{
										num = 5;
										num3 = num;
										continue;
									}
									goto case 7;
								case 5:
									timeSpan = DateTime.Now.Subtract(now);
									num = 1;
									num3 = num;
									continue;
								case 1:
									if (!(timeSpan.TotalMilliseconds < 100.0))
									{
										num = 7;
										num3 = num;
										continue;
									}
									goto IL_0188;
								case 2:
								case 3:
									timeSpan = DateTime.Now.Subtract(now2);
									num = 9;
									num3 = num;
									continue;
								case 9:
									if (!(timeSpan.TotalMilliseconds < 1200.0))
									{
										num = 10;
										num3 = num;
										continue;
									}
									goto IL_0188;
								case 0:
									text += text2;
									now = DateTime.Now;
									flag = true;
									num = 3;
									num3 = num;
									continue;
								case 7:
									text = text.Replace("101:OK WITH TEXT", "").Replace("100:OK", "");
									result = text;
									num = 4;
									num3 = num;
									continue;
								case 4:
									goto end_IL_011e;
									IL_0188:
									text2 = this.m_a.ReadExisting();
									num = 8;
									num3 = num;
									continue;
								}
								goto case 0;
								continue;
								end_IL_011e:
								break;
							}
							break;
						case 0:
							n(A_0);
							text2 = string.Empty;
							flag = false;
							now2 = DateTime.Now;
							now = DateTime.Now;
							num = 2;
							num3 = num;
							goto default;
						}
					}
					catch
					{
						result = string.Empty;
					}
					return result;
				case 1:
					break;
				}
				break;
			}
			break;
		}
		case false:
		case true:
			break;
		}
		return string.Empty;
	}

	private bool k(string A_0)
	{
		short num = -1293;
		short num2 = num;
		num = -1293;
		switch (num2 == num)
		{
		default:
		{
			num = 0;
			if (num != 0)
			{
			}
			num = 1;
			int num3 = num;
			while (true)
			{
				switch (num3)
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
					if (this.m_a != null)
					{
						num = 0;
						num3 = num;
						continue;
					}
					goto IL_0137;
				case 0:
					num = 2;
					num3 = num;
					continue;
				case 2:
					if (this.m_a.IsOpen)
					{
						num = 3;
						num3 = num;
						continue;
					}
					goto IL_0137;
				case 3:
					break;
					IL_0137:
					return false;
				}
				break;
			}
			break;
		}
		case false:
		case true:
			break;
		}
		num = 1;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
		return !string.IsNullOrWhiteSpace(A_0);
	}

	[AsyncStateMachine(typeof(e))]
	private Task<object> j(string A_0)
	{
		short num = 19238;
		short num2 = num;
		num = 19238;
		switch (num2 == num)
		{
		default:
		{
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
			e stateMachine = default(e);
			stateMachine.b = AsyncTaskMethodBuilder<object>.Create();
			stateMachine.d = this;
			stateMachine.c = A_0;
			stateMachine.a = -1;
			stateMachine.b.Start(ref stateMachine);
			return stateMachine.b.Task;
		}
		}
	}

	private bool a(string A_0, uint A_1, string A_2)
	{
		short num = 3;
		int num2 = num;
		while (true)
		{
			num = 1;
			if (num != 0)
			{
			}
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
				if (!string.IsNullOrEmpty(A_0))
				{
					num = 0;
					num2 = num;
					continue;
				}
				break;
			case 4:
				return A_0.Length == A_1 * 2;
			case 1:
				num = 2;
				num2 = num;
				continue;
			case 2:
			{
				if (!Regex.IsMatch(A_0, "\\A\\b[0-9a-fA-F]+\\b\\Z"))
				{
					break;
				}
				num = -7853;
				short num3 = num;
				num = -7853;
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
					_ = num;
					num = 4;
					num2 = num;
					continue;
				}
				goto case 1;
			}
			case 0:
				num = 5;
				num2 = num;
				continue;
			case 5:
				if (!string.IsNullOrEmpty(A_2))
				{
					num = 1;
					num2 = num;
					continue;
				}
				break;
			}
			break;
		}
		return false;
	}

	private void p()
	{
		int num = default(int);
		int num3 = default(int);
		switch (0)
		{
		default:
			while (true)
			{
				short num2;
				switch (num)
				{
				case 6:
				case 14:
					num2 = 13;
					num = num2;
					continue;
				case 13:
					if (!m("UIDMODE" + this.m_i + "?").ToString().Equals("1"))
					{
						h3.Checked = false;
						num2 = 4;
						num = num2;
					}
					else
					{
						num2 = 9;
						num = num2;
					}
					continue;
				case 2:
					num2 = 5;
					num = num2;
					continue;
				case 5:
					if (num3 >= 9)
					{
						num2 = 11;
						num = num2;
						continue;
					}
					a(num3, A_1: false);
					num3++;
					num2 = 1;
					num = num2;
					continue;
				case 0:
					h8.Checked = true;
					num2 = 3;
					num = num2;
					continue;
				case 1:
				{
					num2 = -30329;
					short num4 = num2;
					num2 = -30329;
					switch (num4 == num2)
					{
					case false:
					case true:
						goto IL_02d3;
					}
					num2 = 0;
					_ = num2;
					num2 = 0;
					if (num2 != 0)
					{
					}
					num2 = 1;
					if (num2 == 0)
					{
					}
					goto case 2;
				}
				case 4:
				case 12:
					num2 = 10;
					num = num2;
					continue;
				case 10:
					if (m("AUTOCHANGEMODE" + this.m_i + "?").ToString().Equals("1"))
					{
						num2 = 0;
						num = num2;
					}
					else
					{
						h8.Checked = false;
						num2 = 8;
						num = num2;
					}
					continue;
				case 11:
					goto IL_02d3;
				case 15:
					if (!m("FIREWALLMODE" + this.m_i + "?").ToString().Equals("1"))
					{
						h7.Checked = false;
						num2 = 14;
						num = num2;
					}
					else
					{
						num2 = 7;
						num = num2;
					}
					continue;
				case 9:
					h3.Checked = true;
					num2 = 12;
					num = num2;
					continue;
				case 7:
					h7.Checked = true;
					num2 = 6;
					num = num2;
					continue;
				case 3:
				case 8:
					{
						this.m_y = false;
						d();
						return;
					}
					IL_02d3:
					this.m_y = true;
					num2 = 15;
					num = num2;
					continue;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			e();
			num3 = 1;
			short num2 = 2;
			num = num2;
			goto default;
		}
		}
	}

	private void a(int A_0, bool A_1 = true)
	{
		short num = 0;
		_ = num;
		num = 0;
		switch (num)
		{
		default:
		{
			num = 14;
			int num2 = num;
			f f = default(f);
			List<ComboBox>.Enumerator enumerator = default(List<ComboBox>.Enumerator);
			string text = default(string);
			string value = default(string);
			g g = default(g);
			string value2 = default(string);
			List<TextBox>.Enumerator enumerator2 = default(List<TextBox>.Enumerator);
			while (true)
			{
				switch (num2)
				{
				case 14:
					switch (0)
					{
					default:
						goto end_IL_0069;
					case 0:
						break;
					}
					goto default;
				default:
					if (A_1)
					{
						num = 4;
						num2 = num;
						break;
					}
					goto case 1;
				case 2:
					a<ComboBox>(this.m_a4.Controls, $"cb_rbuttonlong{A_0 + this.m_p}").ForEach(f.j);
					num = 21;
					num2 = num;
					break;
				case 30:
					f.c = m("LBUTTON_LONG" + this.m_i + "?").ToString();
					num = 15;
					num2 = num;
					break;
				case 15:
					if (this.g(f.c))
					{
						num = 11;
						num2 = num;
						break;
					}
					goto case 7;
				case 36:
					try
					{
						num = 3;
						num2 = num;
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
								num = 0;
								num2 = num;
								continue;
							case 0:
								if (enumerator.MoveNext())
								{
									enumerator.Current.SelectedItem = text;
									num = 2;
									num2 = num;
								}
								else
								{
									num = 4;
									num2 = num;
								}
								continue;
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
					finally
					{
						((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
					}
					goto IL_0482;
				case 34:
					if (!string.IsNullOrWhiteSpace(value))
					{
						num = 25;
						num2 = num;
						break;
					}
					goto IL_0420;
				case 23:
					f.e = m("RBUTTON_LONG" + this.m_i + "?").ToString();
					num = 28;
					num2 = num;
					break;
				case 28:
					if (this.f(f.e))
					{
						num = 2;
						num2 = num;
						break;
					}
					goto case 21;
				case 32:
					a<ComboBox>(this.m_a4.Controls, $"cb_lbutton{A_0}").ForEach(g.b);
					num = 24;
					num2 = num;
					break;
				case 12:
					a<ComboBox>(this.m_a4.Controls, $"cb_lbutton{A_0}").ForEach(f.g);
					num = 30;
					num2 = num;
					break;
				case 8:
					if (!string.IsNullOrEmpty(value2))
					{
						num = 18;
						num2 = num;
						break;
					}
					goto IL_0517;
				case 10:
					if (i(g.a))
					{
						num = 32;
						num2 = num;
						break;
					}
					goto case 21;
				case 35:
					d();
					num = 9;
					num2 = num;
					break;
				case 9:
					return;
				case 5:
					if (this.m_w == global::b.c)
					{
						num = 17;
						num2 = num;
						break;
					}
					g = new g();
					text = m("CONFIG" + this.m_i + "?").ToString();
					num = 26;
					num2 = num;
					break;
				case 4:
					e();
					num = 1;
					num2 = num;
					break;
				case 16:
					try
					{
						num = 3;
						num2 = num;
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
								num = 0;
								num2 = num;
								continue;
							case 0:
								if (enumerator2.MoveNext())
								{
									enumerator2.Current.Text = value;
									num = 2;
									num2 = num;
								}
								else
								{
									num = 4;
									num2 = num;
								}
								continue;
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
					finally
					{
						((IDisposable)enumerator2/*cast due to .constrained prefix*/).Dispose();
					}
					goto IL_0420;
				case 25:
					enumerator2 = a<TextBox>(this.m_a4.Controls, $"txt_uid{A_0}").GetEnumerator();
					num = 16;
					num2 = num;
					break;
				case 13:
					try
					{
						num = 3;
						num2 = num;
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
								num = 0;
								num2 = num;
								continue;
							case 0:
								if (enumerator2.MoveNext())
								{
									num = 26723;
									short num3 = num;
									num = 26723;
									switch (num3 == num)
									{
									default:
										num = 0;
										if (num != 0)
										{
										}
										enumerator2.Current.Text = value2;
										num = 2;
										num2 = num;
										continue;
									case false:
									case true:
										break;
									}
									goto default;
								}
								num = 4;
								num2 = num;
								continue;
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
					finally
					{
						((IDisposable)enumerator2/*cast due to .constrained prefix*/).Dispose();
					}
					goto IL_0517;
				case 26:
					if (c(text))
					{
						num = 0;
						num2 = num;
						break;
					}
					goto IL_0482;
				case 17:
					f = new f();
					f.a = m("CONFIG" + this.m_i + "?").ToString();
					num = 19;
					num2 = num;
					break;
				case 19:
					if (c(f.a))
					{
						num = 31;
						num2 = num;
						break;
					}
					goto case 22;
				case 31:
					a<ComboBox>(this.m_a4.Controls, $"cb_mode{A_0}").ForEach(f.f);
					num = 22;
					num2 = num;
					break;
				case 7:
					f.d = m("RBUTTON" + this.m_i + "?").ToString();
					num = 3;
					num2 = num;
					break;
				case 3:
					if (h(f.d))
					{
						num = 6;
						num2 = num;
						break;
					}
					goto case 23;
				case 18:
					enumerator2 = a<TextBox>(this.m_a4.Controls, $"txt_size{A_0}").GetEnumerator();
					num = 13;
					num2 = num;
					break;
				case 20:
					return;
				case 0:
					enumerator = a<ComboBox>(this.m_a4.Controls, $"cb_mode{A_0}").GetEnumerator();
					num = 36;
					num2 = num;
					break;
				case 22:
					f.b = m("LBUTTON" + this.m_i + "?").ToString();
					num = 33;
					num2 = num;
					break;
				case 33:
					if (i(f.b))
					{
						num = 12;
						num2 = num;
						break;
					}
					goto case 30;
				case 1:
					num = 1;
					if (num != 0)
					{
					}
					n($"SETTING{this.m_i}={A_0 - this.m_p}");
					num = 27;
					num2 = num;
					break;
				case 27:
					if (m("SETTING" + this.m_i + "?").ToString().Contains((A_0 - this.m_p).ToString()))
					{
						value = m("UID" + this.m_i + "?").ToString();
						num = 34;
						num2 = num;
					}
					else
					{
						num = 20;
						num2 = num;
					}
					break;
				case 6:
					a<ComboBox>(this.m_a4.Controls, $"cb_rbutton{A_0}").ForEach(f.i);
					num = 23;
					num2 = num;
					break;
				case 11:
					a<ComboBox>(this.m_a4.Controls, $"cb_lbuttonlong{A_0}").ForEach(f.h);
					num = 7;
					num2 = num;
					break;
				case 21:
				case 24:
					num = 29;
					num2 = num;
					break;
				case 29:
					{
						if (A_1)
						{
							num = 35;
							num2 = num;
							break;
						}
						return;
					}
					IL_0420:
					value2 = m("MEMSIZE" + this.m_i + "?").ToString();
					num = 8;
					num2 = num;
					break;
					IL_0482:
					g.a = m("BUTTON" + this.m_i + "?").ToString();
					num = 10;
					num2 = num;
					break;
					IL_0517:
					num = 5;
					num2 = num;
					break;
					end_IL_0069:
					break;
				}
			}
		}
		}
	}

	private bool i(string A_0)
	{
		if (!string.IsNullOrWhiteSpace(A_0))
		{
			short num = 28684;
			short num2 = num;
			num = 28684;
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
				_ = num;
				num = 0;
				if (num != 0)
				{
				}
				return this.m_c.Contains(A_0);
			}
		}
		return false;
	}

	private bool h(string A_0)
	{
		if (!string.IsNullOrWhiteSpace(A_0))
		{
			short num = 4946;
			short num2 = num;
			num = 4946;
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
				_ = num;
				num = 0;
				if (num != 0)
				{
				}
				return this.m_e.Contains(A_0);
			}
		}
		return false;
	}

	private bool g(string A_0)
	{
		if (!string.IsNullOrWhiteSpace(A_0))
		{
			short num = -28548;
			short num2 = num;
			num = -28548;
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
				_ = num;
				num = 0;
				if (num != 0)
				{
				}
				return this.m_d.Contains(A_0);
			}
		}
		return false;
	}

	private bool f(string A_0)
	{
		if (!string.IsNullOrWhiteSpace(A_0))
		{
			short num = 10897;
			short num2 = num;
			num = 10897;
			switch (num2 == num)
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
				_ = num;
				num = 1;
				if (num != 0)
				{
				}
				return this.m_f.Contains(A_0);
			}
		}
		return false;
	}

	private bool e(string A_0)
	{
		short num = 1;
		if (num != 0)
		{
		}
		if (!string.IsNullOrWhiteSpace(A_0))
		{
			num = 10599;
			short num2 = num;
			num = 10599;
			switch (num2 == num)
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
				return this.m_g.Contains(A_0);
			}
		}
		return false;
	}

	private bool d(string A_0)
	{
		if (!string.IsNullOrWhiteSpace(A_0))
		{
			short num = 1;
			if (num != 0)
			{
			}
			num = -18571;
			short num2 = num;
			num = -18571;
			switch (num2 == num)
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
				return this.m_h.Contains(A_0);
			}
		}
		return false;
	}

	private bool c(string A_0)
	{
		if (!string.IsNullOrWhiteSpace(A_0))
		{
			short num = 9183;
			short num2 = num;
			num = 9183;
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
				_ = num;
				num = 0;
				if (num != 0)
				{
				}
				return this.m_b.Contains(A_0);
			}
		}
		return false;
	}

	private void o()
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			string text3 = default(string);
			switch (0)
			{
			default:
			{
				string text = default(string);
				List<ComboBox>.Enumerator enumerator = default(List<ComboBox>.Enumerator);
				string text2 = default(string);
				string text6 = default(string);
				string text4 = default(string);
				string text7 = default(string);
				string text5 = default(string);
				while (true)
				{
					switch (num2)
					{
					case 12:
						if (!string.IsNullOrEmpty(text3))
						{
							num = 0;
							num2 = num;
							continue;
						}
						goto IL_0c93;
					case 30:
						return;
					case 5:
						if (string.IsNullOrEmpty(text))
						{
							num = 14;
							num2 = num;
							continue;
						}
						this.m_e = text.Split(',');
						num = 25;
						num2 = num;
						continue;
					case 14:
						return;
					case 10:
						if (!this.m_c.Any())
						{
							num = 8;
							num2 = num;
							continue;
						}
						enumerator = a<ComboBox>(this.m_a4.Controls, "cb_Lbutton").GetEnumerator();
						num = 1;
						if (num != 0)
						{
						}
						num = 37;
						num2 = num;
						continue;
					case 8:
						return;
					case 17:
						return;
					case 34:
						if (!this.m_h.Any())
						{
							num = 4;
							num2 = num;
						}
						else
						{
							enumerator = a<ComboBox>(this.m_a4.Controls, "cb_ledred").GetEnumerator();
							num = 16;
							num2 = num;
						}
						continue;
					case 4:
						return;
					case 9:
						if (text2.ToLower().StartsWith("200"))
						{
							num = 27;
							num2 = num;
							continue;
						}
						this.m_f = text2.Split(',');
						num = 40;
						num2 = num;
						continue;
					case 25:
						if (!this.m_e.Any())
						{
							num = 29;
							num2 = num;
						}
						else
						{
							enumerator = a<ComboBox>(this.m_a4.Controls, "cb_Rbutton").GetEnumerator();
							num = 7;
							num2 = num;
						}
						continue;
					case 29:
						return;
					case 20:
						if (!string.IsNullOrEmpty(text6))
						{
							this.m_h = text6.Split(',');
							num = 34;
							num2 = num;
						}
						else
						{
							num = 3;
							num2 = num;
						}
						continue;
					case 3:
						return;
					case 16:
						try
						{
							num = 1;
							num2 = num;
							while (true)
							{
								switch (num2)
								{
								case 1:
									switch (0)
									{
									default:
										goto end_IL_03f8;
									case 0:
										break;
									}
									goto default;
								default:
									num = 0;
									num2 = num;
									break;
								case 0:
								{
									if (!enumerator.MoveNext())
									{
										num = 2;
										num2 = num;
										break;
									}
									ComboBox current7 = enumerator.Current;
									current7.Items.Clear();
									ComboBox.ObjectCollection items6 = current7.Items;
									object[] items2 = this.m_h;
									items6.AddRange(items2);
									num = 3;
									num2 = num;
									break;
								}
								case 2:
									num = 4;
									num2 = num;
									break;
								case 4:
									return;
									end_IL_03f8:
									break;
								}
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
					case 1:
						try
						{
							num = 1;
							num2 = num;
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
									num = 2;
									num2 = num;
									continue;
								case 2:
									if (enumerator.MoveNext())
									{
										ComboBox current5 = enumerator.Current;
										current5.Items.Clear();
										current5.Enabled = false;
										num = 0;
										num2 = num;
									}
									else
									{
										num = 3;
										num2 = num;
									}
									continue;
								case 3:
									num = 4;
									num2 = num;
									continue;
								case 4:
									break;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
						goto IL_0a59;
					case 0:
						this.m_b = text3.Split(',');
						num = 36;
						num2 = num;
						continue;
					case 36:
						if (this.m_b.Any())
						{
							num = 33;
							num2 = num;
							continue;
						}
						goto IL_0c93;
					case 2:
						return;
					case 21:
						enumerator = a<ComboBox>(this.m_a4.Controls, "cb_Lbuttonlong").GetEnumerator();
						num = 1;
						num2 = num;
						continue;
					case 28:
						if (text4.ToLower().StartsWith("200"))
						{
							num = 0;
							_ = num;
							num = 21;
							num2 = num;
						}
						else
						{
							this.m_d = text4.Split(',');
							num = 6;
							num2 = num;
						}
						continue;
					case 37:
						try
						{
							num = 1;
							num2 = num;
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
									num = 0;
									num2 = num;
									continue;
								case 0:
								{
									if (!enumerator.MoveNext())
									{
										num = 2;
										num2 = num;
										continue;
									}
									ComboBox current = enumerator.Current;
									current.Items.Clear();
									ComboBox.ObjectCollection items = current.Items;
									object[] items2 = this.m_c;
									items.AddRange(items2);
									num = 3;
									num2 = num;
									continue;
								}
								case 2:
									num = 4;
									num2 = num;
									continue;
								case 4:
									break;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
						text = m("RBUTTON" + this.m_i + "=?").ToString();
						num = 5;
						num2 = num;
						continue;
					case 35:
						return;
					case 7:
						try
						{
							num = 1;
							num2 = num;
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
									num = 2;
									num2 = num;
									continue;
								case 2:
									if (enumerator.MoveNext())
									{
										ComboBox current9 = enumerator.Current;
										current9.Items.Clear();
										ComboBox.ObjectCollection items8 = current9.Items;
										object[] items2 = this.m_e;
										items8.AddRange(items2);
										num = 0;
										num2 = num;
									}
									else
									{
										num = 3;
										num2 = num;
									}
									continue;
								case 3:
									num = 4;
									num2 = num;
									continue;
								case 4:
									break;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
						text4 = m("LBUTTON_LONG" + this.m_i + "=?").ToString();
						num = 31;
						num2 = num;
						continue;
					case 33:
						enumerator = a<ComboBox>(this.m_a4.Controls, "cb_mode").GetEnumerator();
						num = 19;
						num2 = num;
						continue;
					case 24:
						try
						{
							num = 1;
							num2 = num;
							while (true)
							{
								num = 19033;
								short num3 = num;
								num = 19033;
								switch (num3 == num)
								{
								default:
									num = 0;
									if (num != 0)
									{
									}
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
										num = 0;
										num2 = num;
										continue;
									case 0:
									{
										if (!enumerator.MoveNext())
										{
											num = 2;
											num2 = num;
											continue;
										}
										ComboBox current8 = enumerator.Current;
										current8.Enabled = true;
										current8.Items.Clear();
										ComboBox.ObjectCollection items7 = current8.Items;
										object[] items2 = this.m_d;
										items7.AddRange(items2);
										break;
									}
									case 2:
										num = 4;
										num2 = num;
										continue;
									case 4:
										goto end_IL_0946;
									}
									break;
								case false:
								case true:
									break;
								}
								num = 3;
								num2 = num;
								continue;
								end_IL_0946:
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
						text2 = m("RBUTTON_LONG" + this.m_i + "=?").ToString();
						num = 23;
						num2 = num;
						continue;
					case 15:
						if (string.IsNullOrEmpty(text7))
						{
							num = 2;
							num2 = num;
							continue;
						}
						this.m_g = text7.Split(',');
						num = 11;
						num2 = num;
						continue;
					case 6:
						if (!this.m_d.Any())
						{
							num = 22;
							num2 = num;
						}
						else
						{
							enumerator = a<ComboBox>(this.m_a4.Controls, "cb_lbuttonlong").GetEnumerator();
							num = 24;
							num2 = num;
						}
						continue;
					case 22:
						return;
					case 26:
						return;
					case 19:
						try
						{
							num = 1;
							num2 = num;
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
									num = 0;
									num2 = num;
									continue;
								case 0:
								{
									if (!enumerator.MoveNext())
									{
										num = 2;
										num2 = num;
										continue;
									}
									ComboBox current6 = enumerator.Current;
									current6.Items.Clear();
									ComboBox.ObjectCollection items5 = current6.Items;
									object[] items2 = this.m_b;
									items5.AddRange(items2);
									num = 3;
									num2 = num;
									continue;
								}
								case 2:
									num = 4;
									num2 = num;
									continue;
								case 4:
									break;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
						goto IL_0c93;
					case 39:
						return;
					case 11:
						if (this.m_g.Any())
						{
							enumerator = a<ComboBox>(this.m_a4.Controls, "cb_ledgreen").GetEnumerator();
							num = 18;
							num2 = num;
						}
						else
						{
							num = 35;
							num2 = num;
						}
						continue;
					case 38:
						if (!string.IsNullOrEmpty(text5))
						{
							this.m_c = text5.Split(',');
							num = 10;
							num2 = num;
						}
						else
						{
							num = 26;
							num2 = num;
						}
						continue;
					case 32:
						try
						{
							num = 1;
							num2 = num;
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
									num = 2;
									num2 = num;
									continue;
								case 2:
									if (enumerator.MoveNext())
									{
										ComboBox current4 = enumerator.Current;
										current4.Enabled = true;
										current4.Items.Clear();
										ComboBox.ObjectCollection items4 = current4.Items;
										object[] items2 = this.m_f;
										items4.AddRange(items2);
										num = 0;
										num2 = num;
									}
									else
									{
										num = 3;
										num2 = num;
									}
									continue;
								case 3:
									num = 4;
									num2 = num;
									continue;
								case 4:
									break;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
						goto IL_0a59;
					case 18:
						try
						{
							num = 1;
							num2 = num;
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
									num = 2;
									num2 = num;
									continue;
								case 2:
									if (enumerator.MoveNext())
									{
										ComboBox current3 = enumerator.Current;
										current3.Items.Clear();
										ComboBox.ObjectCollection items3 = current3.Items;
										object[] items2 = this.m_g;
										items3.AddRange(items2);
										num = 0;
										num2 = num;
									}
									else
									{
										num = 3;
										num2 = num;
									}
									continue;
								case 3:
									num = 4;
									num2 = num;
									continue;
								case 4:
									break;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
						text6 = m("LEDRED" + this.m_i + "=?").ToString();
						num = 20;
						num2 = num;
						continue;
					case 31:
						if (!string.IsNullOrEmpty(text4))
						{
							num = 28;
							num2 = num;
						}
						else
						{
							num = 39;
							num2 = num;
						}
						continue;
					case 13:
						try
						{
							num = 1;
							num2 = num;
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
									num = 2;
									num2 = num;
									continue;
								case 2:
									if (enumerator.MoveNext())
									{
										ComboBox current2 = enumerator.Current;
										current2.Items.Clear();
										current2.Enabled = false;
										num = 0;
										num2 = num;
									}
									else
									{
										num = 3;
										num2 = num;
									}
									continue;
								case 3:
									num = 4;
									num2 = num;
									continue;
								case 4:
									break;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
						goto IL_0a59;
					case 23:
						if (!string.IsNullOrEmpty(text2))
						{
							num = 9;
							num2 = num;
						}
						else
						{
							num = 30;
							num2 = num;
						}
						continue;
					case 27:
						enumerator = a<ComboBox>(this.m_a4.Controls, "cb_rbuttonlong").GetEnumerator();
						num = 13;
						num2 = num;
						continue;
					case 40:
						{
							if (this.m_f.Any())
							{
								enumerator = a<ComboBox>(this.m_a4.Controls, "cb_rbuttonlong").GetEnumerator();
								num = 32;
								num2 = num;
							}
							else
							{
								num = 17;
								num2 = num;
							}
							continue;
						}
						IL_0c93:
						text5 = m("LBUTTON" + this.m_i + "=?").ToString();
						num = 38;
						num2 = num;
						continue;
						IL_0a59:
						text7 = m("LEDGREEN" + this.m_i + "=?").ToString();
						num = 15;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				text3 = m("CONFIG" + this.m_i + "=?").ToString();
				num = 12;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private void n()
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			string text2 = default(string);
			switch (0)
			{
			default:
			{
				List<ComboBox>.Enumerator enumerator = default(List<ComboBox>.Enumerator);
				string text3 = default(string);
				string text = default(string);
				while (true)
				{
					switch (num2)
					{
					case 10:
						if (!string.IsNullOrEmpty(text2))
						{
							num = 1;
							if (num != 0)
							{
							}
							num = 6;
							num2 = num;
							continue;
						}
						goto IL_01c8;
					case 15:
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
										goto end_IL_011b;
									case 0:
										break;
									}
									goto default;
								default:
									num = 0;
									num2 = num;
									break;
								case 0:
									if (enumerator.MoveNext())
									{
										ComboBox current = enumerator.Current;
										current.Items.Clear();
										current.Enabled = false;
										num = 3;
										num2 = num;
									}
									else
									{
										num = 1;
										num2 = num;
									}
									break;
								case 1:
									num = 4;
									num2 = num;
									break;
								case 4:
									return;
									end_IL_011b:
									break;
								}
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
					case 17:
						return;
					case 3:
						if (string.IsNullOrEmpty(text3))
						{
							num = 13;
							num2 = num;
							continue;
						}
						this.m_c = text3.Split(',');
						num = 9;
						num2 = num;
						continue;
					case 13:
						return;
					case 12:
						return;
					case 5:
						try
						{
							num = 2;
							num2 = num;
							while (true)
							{
								num = -28727;
								short num3 = num;
								num = -28727;
								switch (num3 == num)
								{
								default:
									num = 0;
									if (num != 0)
									{
									}
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
										num2 = num;
										continue;
									case 0:
										if (enumerator.MoveNext())
										{
											ComboBox current4 = enumerator.Current;
											current4.Items.Clear();
											ComboBox.ObjectCollection items4 = current4.Items;
											object[] items2 = this.m_b;
											items4.AddRange(items2);
											break;
										}
										num = 1;
										num2 = num;
										continue;
									case 1:
										num = 4;
										num2 = num;
										continue;
									case 4:
										goto end_IL_0248;
									}
									break;
								case false:
								case true:
									break;
								}
								num = 3;
								num2 = num;
								continue;
								end_IL_0248:
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
						goto IL_01c8;
					case 7:
						num = 0;
						_ = num;
						enumerator = a<ComboBox>(this.m_a4.Controls, "cb_Lbuttonlong").GetEnumerator();
						num = 15;
						num2 = num;
						continue;
					case 16:
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
										goto end_IL_03dc;
									case 0:
										break;
									}
									goto default;
								default:
									num = 0;
									num2 = num;
									break;
								case 0:
									if (enumerator.MoveNext())
									{
										ComboBox current2 = enumerator.Current;
										current2.Enabled = true;
										current2.Items.Clear();
										ComboBox.ObjectCollection items = current2.Items;
										object[] items2 = this.m_d;
										items.AddRange(items2);
										num = 3;
										num2 = num;
									}
									else
									{
										num = 1;
										num2 = num;
									}
									break;
								case 1:
									num = 4;
									num2 = num;
									break;
								case 4:
									return;
									end_IL_03dc:
									break;
								}
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
					case 6:
						this.m_b = text2.Split(',');
						num = 8;
						num2 = num;
						continue;
					case 8:
						if (this.m_b.Any())
						{
							num = 1;
							num2 = num;
							continue;
						}
						goto IL_01c8;
					case 9:
						if (this.m_c.Any())
						{
							enumerator = a<ComboBox>(this.m_a4.Controls, "cb_Lbutton").GetEnumerator();
							num = 4;
							num2 = num;
						}
						else
						{
							num = 14;
							num2 = num;
						}
						continue;
					case 14:
						return;
					case 11:
						if (this.m_d.Any())
						{
							enumerator = a<ComboBox>(this.m_a4.Controls, "cb_lbuttonlong").GetEnumerator();
							num = 16;
							num2 = num;
						}
						else
						{
							num = 12;
							num2 = num;
						}
						continue;
					case 4:
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
									num = 0;
									num2 = num;
									continue;
								case 0:
									if (enumerator.MoveNext())
									{
										ComboBox current3 = enumerator.Current;
										current3.Items.Clear();
										ComboBox.ObjectCollection items3 = current3.Items;
										object[] items2 = this.m_c;
										items3.AddRange(items2);
										num = 3;
										num2 = num;
									}
									else
									{
										num = 1;
										num2 = num;
									}
									continue;
								case 1:
									num = 4;
									num2 = num;
									continue;
								case 4:
									break;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
						text = m("BUTTON_LONG" + this.m_i).ToString();
						num = 2;
						num2 = num;
						continue;
					case 2:
						if (string.IsNullOrEmpty(text))
						{
							num = 17;
							num2 = num;
						}
						else
						{
							num = 0;
							num2 = num;
						}
						continue;
					case 0:
						if (!text.ToLower().StartsWith("200"))
						{
							this.m_d = text.Split(',');
							num = 11;
							num2 = num;
						}
						else
						{
							num = 7;
							num2 = num;
						}
						continue;
					case 1:
						{
							enumerator = a<ComboBox>(this.m_a4.Controls, "cb_mode").GetEnumerator();
							num = 5;
							num2 = num;
							continue;
						}
						IL_01c8:
						text3 = m("BUTTON" + this.m_i).ToString();
						num = 3;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				text2 = m("CONFIG" + this.m_i).ToString();
				num = 10;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private void m()
	{
		int num = default(int);
		global::b b = default(global::b);
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
					if (b != global::b.b)
					{
						num2 = 4;
						num = num2;
						continue;
					}
					n();
					goto IL_0097;
				case 4:
					num2 = 5;
					num = num2;
					continue;
				case 5:
					if (b == global::b.c)
					{
						num2 = -14389;
						short num3 = num2;
						num2 = -14389;
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
							num2 = 3;
							num = num2;
							continue;
						}
						goto IL_0097;
					}
					goto case 0;
				case 3:
					num2 = 0;
					_ = num2;
					o();
					num2 = 0;
					num = num2;
					continue;
				case 0:
				case 2:
					{
						SuspendUpdate.Resume(this.m_a4);
						return;
					}
					IL_0097:
					num2 = 2;
					num = num2;
					continue;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			SuspendUpdate.Suspend(this.m_a4);
			b = this.m_w;
			short num2 = 1;
			num = num2;
			goto default;
		}
		}
	}

	private void l()
	{
		int num3 = default(int);
		string text = default(string);
		switch (0)
		{
		default:
		{
			string[] array = default(string[]);
			while (true)
			{
				short num = 1;
				if (num != 0)
				{
				}
				num = 0;
				_ = num;
				num = 25486;
				short num2 = num;
				num = 25486;
				switch (num2 == num)
				{
				default:
					num = 0;
					if (num != 0)
					{
					}
					switch (num3)
					{
					case 2:
						goto IL_00ee;
					case 0:
						return;
					case 3:
						return;
					case 1:
						goto IL_013c;
					}
					break;
				case false:
				case true:
					goto IL_013c;
					IL_00ee:
					if (string.IsNullOrEmpty(text))
					{
						num = 0;
						num3 = num;
						continue;
					}
					array = text.Split(',');
					num = 1;
					num3 = num;
					continue;
					IL_013c:
					if (!array.Any())
					{
						num = 3;
						num3 = num;
						continue;
					}
					Array.Sort(array);
					this.m_ak.Clear();
					this.m_ak.AddRange(array);
					return;
				}
				break;
			}
			goto case 0;
		}
		case 0:
		{
			string a_ = "HELP" + this.m_i;
			text = m(a_).ToString();
			short num = 2;
			num3 = num;
			goto default;
		}
		}
	}

	private static a b(string A_0)
	{
		short num = 0;
		int num2 = num;
		FileInfo fileInfo = default(FileInfo);
		byte[] array = default(byte[]);
		switch (num2)
		{
		default:
			{
				switch (0)
				{
				case 0:
					goto IL_0057;
				}
				goto IL_0028;
			}
			IL_0028:
			while (true)
			{
				switch (num2)
				{
				case 2:
					if (!fileInfo.Exists)
					{
						num = 5;
						num2 = num;
					}
					else
					{
						array = DumpStrategyFactory.Create(fileInfo.FullName).Read();
						num = 6;
						num2 = num;
					}
					continue;
				case 3:
				{
					IEnumerable<byte> second3 = array.Skip(0).Take(8);
					IEnumerable<byte> second4 = array.Skip(12).Take(32);
					IEnumerable<byte> first2 = array.Skip(44).Take(12);
					return new a
					{
						a = array.Skip(56).ToArray(),
						b = first2.Concat(second3).Concat(second4).ToArray()
					};
				}
				case 8:
					if (MifareUltralightModel.HasUltralightNewHeader(array))
					{
						num = 3;
						num2 = num;
					}
					else
					{
						num = 4;
						num2 = num;
					}
					continue;
				case 6:
					if (array.Length < 1024)
					{
						num = 1;
						num2 = num;
						continue;
					}
					goto case 7;
				case 1:
				{
					num = 1;
					if (num != 0)
					{
					}
					num = 2315;
					short num3 = num;
					num = 2315;
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
						num = 9;
						num2 = num;
						continue;
					}
					goto case 5;
				}
				case 0:
				{
					IEnumerable<byte> second = array.Skip(0).Take(8);
					IEnumerable<byte> first = new byte[3].Concat(array.Skip(10).Take(1)).Concat(new byte[3]).Concat(array.Skip(11).Take(1))
						.Concat(new byte[3])
						.Concat(array.Skip(12).Take(1));
					IEnumerable<byte> second2 = array.Skip(16).Take(32);
					return new a
					{
						a = array.Skip(48).ToArray(),
						b = first.Concat(second).Concat(second2).ToArray()
					};
				}
				case 5:
					return null;
				case 4:
					if (MifareUltralightModel.HasUltralightHeader(array))
					{
						num = 0;
						num2 = num;
						continue;
					}
					return new a
					{
						a = array,
						b = Enumerable.Repeat((byte)0, 52).ToArray()
					};
				case 7:
				{
					num = 0;
					_ = num;
					a a = new a();
					a.a = array;
					a.b = new byte[0];
					return a;
				}
				case 9:
					if (array.Length != 320)
					{
						num = 8;
						num2 = num;
					}
					else
					{
						num = 7;
						num2 = num;
					}
					continue;
				}
				break;
			}
			goto IL_0057;
			IL_0057:
			fileInfo = new FileInfo(A_0);
			num = 2;
			num2 = num;
			goto IL_0028;
		}
	}

	internal void r(string A_0)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		}
		byte[] array = default(byte[]);
		a a = default(a);
		int num3 = default(int);
		XMODEM xMODEM = default(XMODEM);
		while (true)
		{
			switch (0)
			{
			default:
				while (true)
				{
					switch (num2)
					{
					case 3:
						goto IL_00d6;
					case 1:
						num = 6;
						num2 = num;
						continue;
					case 6:
						goto IL_011a;
					case 2:
					case 7:
						array = a.a.Concat(a.b).ToArray();
						num3 = xMODEM.Send(array);
						num = 0;
						num2 = num;
						continue;
					case 0:
						goto IL_017c;
					case 5:
						n("UPLOAD" + this.m_i);
						num = 7;
						num2 = num;
						continue;
					case 4:
					{
						string value = "[+] File upload ok" + Environment.NewLine;
						Console.WriteLine(value);
						this.m_ar.AppendText(value);
						return;
					}
					}
					break;
					IL_017c:
					num = -31893;
					short num4 = num;
					num = -31893;
					switch (num4 == num)
					{
					case false:
					case true:
						break;
					default:
						goto IL_01b0;
					}
					goto end_IL_001f;
					IL_01b0:
					num = 0;
					if (num != 0)
					{
					}
					if (num3 == array.Length)
					{
						num = 1;
						num2 = num;
						continue;
					}
					goto IL_027b;
					IL_00d6:
					if (this.m_w != global::b.c)
					{
						num = 5;
						num2 = num;
					}
					else
					{
						n("PCRUPLOAD" + this.m_i);
						num = 2;
						num2 = num;
					}
					continue;
					IL_027b:
					this.m_ar.AppendText("发送成功" + num3);
					string text = "[!] Failed to upload file" + Environment.NewLine;
					MessageBox.Show(text);
					this.m_ar.AppendText(text);
					return;
					IL_011a:
					if (xMODEM.TerminationReason == XMODEM.TerminationReasonEnum.EndOfFile)
					{
						num = 4;
						num2 = num;
						continue;
					}
					goto IL_027b;
				}
				goto case 0;
			case 0:
				{
					num = 1;
					if (num != 0)
					{
					}
					a = b(A_0);
					this.a(a);
					xMODEM = new XMODEM(this.m_a, XMODEM.Variants.XModemChecksum, 26, 4);
					num = 0;
					_ = num;
					num = 3;
					num2 = num;
					goto default;
				}
				end_IL_001f:
				break;
			}
		}
	}

	private int a(byte[] A_0)
	{
		short num = 2;
		int num2 = num;
		while (true)
		{
			num = 0;
			_ = num;
			switch (num2)
			{
			case 2:
				switch (0)
				{
				default:
					goto end_IL_0047;
				case 0:
					break;
				}
				goto default;
			default:
			{
				if ((byte)(A_0[0] ^ A_0[1] ^ A_0[2] ^ A_0[3]) != A_0[4])
				{
					goto IL_00df;
				}
				num = 1675;
				short num3 = num;
				num = 1675;
				switch (num3 == num)
				{
				default:
					num = 0;
					if (num != 0)
					{
					}
					num = 5;
					num2 = num;
					goto end_IL_0047;
				case false:
				case true:
					break;
				}
				goto case 3;
			}
			case 1:
				if ((A_0[8] & 0xC0) == 64)
				{
					num = 0;
					num2 = num;
					break;
				}
				num = 1;
				if (num != 0)
				{
				}
				return 4;
			case 3:
				return 4;
			case 5:
				num = 4;
				num2 = num;
				break;
			case 4:
				if ((A_0[6] & 0xC0) == 0)
				{
					num = 3;
					num2 = num;
					break;
				}
				goto IL_00df;
			case 0:
				{
					return 7;
				}
				IL_00df:
				num = 1;
				num2 = num;
				break;
				end_IL_0047:
				break;
			}
		}
	}

	private void a(a A_0)
	{
		switch (0)
		{
		case 0:
			goto IL_0068;
		}
		goto IL_000a;
		IL_000a:
		int num = default(int);
		int num3 = default(int);
		short num2;
		while (true)
		{
			switch (num)
			{
			case 14:
				goto IL_00d2;
			case 18:
				num2 = 0;
				num = num2;
				continue;
			case 0:
				goto IL_010e;
			case 21:
				goto IL_012f;
			case 8:
				goto IL_0146;
			case 11:
				num2 = 0;
				_ = num2;
				num2 = 7;
				num = num2;
				continue;
			case 7:
				goto IL_01a7;
			case 17:
				num2 = 5;
				num = num2;
				continue;
			case 19:
				goto IL_0201;
			case 4:
				num2 = 6;
				num = num2;
				continue;
			case 6:
				goto IL_023e;
			case 13:
				num2 = 1;
				if (num2 != 0)
				{
				}
				num2 = 2;
				num = num2;
				continue;
			case 2:
				goto IL_02a0;
			case 9:
				num2 = 16;
				num = num2;
				continue;
			case 3:
				goto IL_02f9;
			case 10:
				num2 = 15;
				num = num2;
				continue;
			case 15:
				if (num3 == 4096)
				{
					num2 = 12;
					num = num2;
					continue;
				}
				goto case 5;
			case 12:
				num2 = 20;
				num = num2;
				continue;
			case 20:
				n((a(A_0.a) == 7) ? ("CONFIG" + this.m_i + "=MF_CLASSIC_4K_7B") : ("CONFIG" + this.m_i + "=MF_CLASSIC_4K"));
				return;
			case 5:
			case 16:
				num2 = 1;
				num = num2;
				continue;
			case 1:
				n((a(A_0.a) == 7) ? ("CONFIG" + this.m_i + "=MF_CLASSIC_1K_7B") : ("CONFIG" + this.m_i + "=MF_CLASSIC_1K"));
				return;
			}
			break;
			IL_02f9:
			if (num3 != 924)
			{
				num2 = 10;
				num = num2;
				continue;
			}
			n("CONFIG" + this.m_i + "=NTAG216");
			return;
			IL_010e:
			if (num3 != 64)
			{
				num2 = 21;
				num = num2;
				continue;
			}
			n("CONFIG" + this.m_i + "=MF_ULTRALIGHT");
			return;
			IL_0201:
			if (num3 <= 540)
			{
				num2 = 4;
				num = num2;
			}
			else
			{
				num2 = 3;
				num = num2;
			}
			continue;
			IL_02a0:
			if (num3 != 540)
			{
				num2 = 9;
				num = num2;
				continue;
			}
			n("CONFIG" + this.m_i + "=NTAG215");
			return;
			IL_00d2:
			if (num3 <= 164)
			{
				num2 = 18;
				num = num2;
			}
			else
			{
				num2 = 19;
				num = num2;
			}
			continue;
			IL_0146:
			if (num3 != 80)
			{
				num2 = 11;
				num = num2;
				continue;
			}
			n("CONFIG" + this.m_i + "=MF_ULTRALIGHT_EV1_80B");
			return;
			IL_023e:
			if (num3 != 180)
			{
				num2 = 13;
				num = num2;
				continue;
			}
			n("CONFIG" + this.m_i + "=NTAG213");
			return;
			IL_01a7:
			if (num3 != 164)
			{
				num2 = 17;
				num = num2;
				continue;
			}
			n("CONFIG" + this.m_i + "=MF_ULTRALIGHT_EV1_164B");
			return;
		}
		goto IL_0068;
		IL_0068:
		num3 = A_0.a.Length;
		num2 = -8443;
		short num4 = num2;
		num2 = -8443;
		switch (num4 == num2)
		{
		case false:
		case true:
			goto IL_012f;
		}
		num2 = 0;
		if (num2 != 0)
		{
		}
		num2 = 14;
		num = num2;
		goto IL_000a;
		IL_012f:
		num2 = 8;
		num = num2;
		goto IL_000a;
	}

	internal void s(string A_0)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			string value2 = default(string);
			int num3 = default(int);
			int result = default(int);
			switch (0)
			{
			default:
			{
				byte[] array2 = default(byte[]);
				byte[] array3 = default(byte[]);
				byte[] array = default(byte[]);
				string text = default(string);
				while (true)
				{
					switch (num2)
					{
					case 16:
						if (!string.IsNullOrEmpty(value2))
						{
							num = 21;
							num2 = num;
							continue;
						}
						goto case 24;
					case 0:
						num = 25;
						num2 = num;
						continue;
					case 25:
						if (array2.Length % 4 == 0)
						{
							goto IL_0130;
						}
						goto case 14;
					case 19:
						num = 28;
						num2 = num;
						continue;
					case 28:
						if (array2.Length != 320)
						{
							num = 0;
							num2 = num;
							continue;
						}
						goto case 14;
					case 20:
						num = 1;
						if (num != 0)
						{
						}
						n("DOWNLOAD" + this.m_i);
						array3 = k();
						num = 1;
						num2 = num;
						continue;
					case 1:
					{
						if (array3 != null)
						{
							num = 8;
							num2 = num;
							continue;
						}
						string text2 = "[!] Failed to save dump" + Environment.NewLine;
						MessageBox.Show(text2);
						this.m_ar.AppendText(text2);
						return;
					}
					case 9:
						num = 0;
						_ = num;
						array = new byte[num3];
						Array.Copy(array3.Skip(result).ToArray(), array, num3);
						num = 18;
						num2 = num;
						continue;
					case 14:
						num = 12;
						num2 = num;
						continue;
					case 12:
					{
						DumpStrategy dumpStrategy = DumpStrategyFactory.Create(A_0);
						if (dumpStrategy != null)
						{
							dumpStrategy.Save(array2);
							num = 11;
							num2 = num;
						}
						else
						{
							num = 22;
							num2 = num;
						}
						continue;
					}
					case 21:
						int.TryParse(value2, out result);
						num = 24;
						num2 = num;
						continue;
					case 24:
						text = m("CONFIG" + this.m_i + "?").ToString();
						num = 17;
						num2 = num;
						continue;
					case 17:
						if (!string.IsNullOrWhiteSpace(text))
						{
							num = 26;
							num2 = num;
							continue;
						}
						goto case 20;
					case 18:
						num = 7;
						num2 = num;
						continue;
					case 7:
						if (array2.Length < 1024)
						{
							num = 19;
							num2 = num;
							continue;
						}
						goto case 14;
					case 15:
						array2 = new byte[result];
						Array.Copy(array3, array2, array2.Length);
						num = 6;
						num2 = num;
						continue;
					case 6:
						if (array3.Length >= result + num3)
						{
							num = 9;
							num2 = num;
							continue;
						}
						goto case 18;
					case 8:
					{
						string value = "[+] File download from device ok" + Environment.NewLine;
						Console.WriteLine(value);
						this.m_ar.AppendText(value);
						array2 = array3;
						array = new byte[0];
						num = 13;
						num2 = num;
						continue;
					}
					case 13:
						if (array3.Length > result)
						{
							num = 15;
							num2 = num;
							continue;
						}
						goto case 18;
					case 4:
					{
						num3 = 52;
						num = 26182;
						short num4 = num;
						num = 26182;
						switch (num4 == num)
						{
						case false:
						case true:
							break;
						default:
							num = 0;
							if (num != 0)
							{
							}
							num = 20;
							num2 = num;
							continue;
						}
						goto IL_0130;
					}
					case 10:
						num = 5;
						num2 = num;
						continue;
					case 5:
						if (array.Length != 0)
						{
							num = 3;
							num2 = num;
							continue;
						}
						goto case 14;
					case 26:
						num = 23;
						num2 = num;
						continue;
					case 23:
						if (text.Contains("ULTRALIGHT_EV1"))
						{
							num = 2;
							num2 = num;
							continue;
						}
						goto case 20;
					case 3:
					{
						IEnumerable<byte> second = array.Skip(0).Take(12);
						IEnumerable<byte> first = array.Skip(12).Take(8);
						IEnumerable<byte> second2 = array.Skip(20).Take(32);
						byte[] second3 = new byte[1] { (byte)(array2.Length / 4 - 1) };
						array2 = first.Concat(Enumerable.Repeat((byte)0, 3)).Concat(second3).Concat(second2)
							.Concat(second)
							.Concat(array2)
							.ToArray();
						num = 14;
						num2 = num;
						continue;
					}
					case 2:
						num = 27;
						num2 = num;
						continue;
					case 27:
						if (result < 4069)
						{
							num = 4;
							num2 = num;
							continue;
						}
						goto case 20;
					case 11:
					case 22:
						{
							string value = "[+] File saved to " + A_0 + Environment.NewLine;
							Console.WriteLine(value);
							this.m_ar.AppendText(value);
							return;
						}
						IL_0130:
						num = 10;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				value2 = m("MEMSIZE" + this.m_i + "?").ToString();
				result = 4096;
				num3 = 0;
				num = 16;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private byte[] k()
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			MemoryStream memoryStream = default(MemoryStream);
			XMODEM xMODEM = default(XMODEM);
			byte[] array = default(byte[]);
			switch (0)
			{
			default:
				while (true)
				{
					switch (num2)
					{
					case 3:
						goto IL_00b8;
					case 2:
						num = 1;
						if (num != 0)
						{
						}
						num = 0;
						_ = num;
						goto case 1;
					case 0:
					{
						byte[] input = memoryStream.ToArray();
						input = xMODEM.TrimPaddingBytesFromEnd(input, 26);
						array = new byte[input.Length];
						Array.Copy(input, array, array.Length);
						num = 1;
						num2 = num;
						continue;
					}
					case 1:
						return array;
					}
					break;
					IL_00b8:
					if (xMODEM.Receive(memoryStream) == XMODEM.TerminationReasonEnum.EndOfFile)
					{
						num = 0;
						num2 = num;
						continue;
					}
					goto IL_00dc;
				}
				goto case 0;
			case 0:
				{
					num = 21255;
					short num3 = num;
					num = 21255;
					switch (num3 == num)
					{
					case false:
					case true:
						goto IL_00dc;
					}
					num = 0;
					if (num != 0)
					{
					}
					xMODEM = new XMODEM(this.m_a, XMODEM.Variants.XModemChecksum, 26, 4);
					memoryStream = new MemoryStream();
					num = 3;
					num2 = num;
					goto default;
				}
				IL_00dc:
				array = null;
				num = 2;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private void j()
	{
		int num = default(int);
		int result = default(int);
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
					if (!int.TryParse(d0.Text, out result))
					{
						num2 = -8277;
						short num3 = num2;
						num2 = -8277;
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
						goto case 0;
					}
					num2 = 0;
					num = num2;
					continue;
				}
				case 1:
					return;
				case 0:
				{
					short num2 = 1;
					if (num2 != 0)
					{
					}
					num2 = 0;
					_ = num2;
					this.m_j.Interval = ((result > 0) ? result : Settings.Default.KeepAliveInterval);
					this.m_j.Start();
					return;
				}
				}
				break;
			}
			goto case 0;
		case 0:
		{
			result = 0;
			this.m_j = new System.Windows.Forms.Timer();
			this.m_j.Tick += a7;
			short num2 = 2;
			num = num2;
			goto default;
		}
		}
	}

	private void d(HexBox A_0)
	{
		short num = 4;
		int num2 = num;
		Label label = default(Label);
		while (true)
		{
			switch (num2)
			{
			case 4:
				switch (0)
				{
				default:
					goto end_IL_001f;
				case 0:
					break;
				}
				goto default;
			default:
				if (A_0.ByteProvider == null)
				{
					num = 0;
					_ = num;
					num = 2;
					num2 = num;
				}
				else
				{
					num = 0;
					num2 = num;
				}
				break;
			case 2:
				num = 1;
				if (num == 0)
				{
				}
				return;
			case 1:
				try
				{
					num = 4;
					num2 = num;
					while (true)
					{
						switch (num2)
						{
						case 4:
						{
							num = -7845;
							short num3 = num;
							num = -7845;
							switch (num3 == num)
							{
							case false:
							case true:
								goto IL_013b;
							}
							num = 0;
							if (num != 0)
							{
							}
							switch (0)
							{
							default:
								goto end_IL_0117;
							case 0:
								break;
							}
							goto default;
						}
						default:
						{
							IByteProvider byteProvider = A_0.ByteProvider;
							if (byteProvider == null)
							{
								num = 0;
								num2 = num;
							}
							else
							{
								byteProvider.ApplyChanges();
								num = 3;
								num2 = num;
							}
							break;
						}
						case 0:
						case 3:
							goto IL_013b;
						case 2:
							this.m_ar.AppendText("[+] Saved file " + label?.Text + Environment.NewLine);
							num = 1;
							num2 = num;
							break;
						case 1:
							return;
							IL_013b:
							num = 2;
							num2 = num;
							break;
							end_IL_0117:
							break;
						}
					}
				}
				catch (Exception)
				{
					string text = "[!] Failed to save file " + label?.Text + Environment.NewLine;
					MessageBox.Show(text);
					this.m_ar.AppendText(text);
					return;
				}
			case 3:
				return;
			case 0:
				{
					if (!int.TryParse(A_0.Name.Substring(A_0.Name.Length - 1), out var result))
					{
						num = 3;
						num2 = num;
					}
					else
					{
						label = a<Label>(base.Controls, $"lbl_hbfilename{result}").FirstOrDefault();
						num = 1;
						num2 = num;
					}
					break;
				}
				end_IL_001f:
				break;
			}
		}
	}

	public void OpenFile(string fileName, HexBox hexBox)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 7;
			int num2 = num;
			bool flag = default(bool);
			long length = default(long);
			Label label = default(Label);
			FileInfo fileInfo = default(FileInfo);
			while (true)
			{
				switch (num2)
				{
				case 7:
					switch (0)
					{
					default:
						goto end_IL_003e;
					case 0:
						break;
					}
					goto default;
				default:
					if (!File.Exists(fileName))
					{
						num = 0;
						_ = num;
						num = 10;
						num2 = num;
					}
					else
					{
						num = 9;
						num2 = num;
					}
					break;
				case 6:
					ew.Checked = true;
					flag = true;
					num = 13;
					num2 = num;
					break;
				case 5:
					eu.Checked = true;
					flag = true;
					num = 4;
					num2 = num;
					break;
				case 11:
					num = 1;
					if (num == 0)
					{
					}
					return;
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
								case 7:
									if (!flag)
									{
										num = 10;
										num2 = num;
										continue;
									}
									goto case 8;
								case 10:
									length = hexBox.ByteProvider.Length;
									num = 13;
									num2 = num;
									continue;
								case 13:
									if (length != 320)
									{
										num = 4;
										num2 = num;
										continue;
									}
									goto case 11;
								case 6:
									num = 9;
									num2 = num;
									continue;
								case 9:
									if (length == 4096)
									{
										num = 11;
										num2 = num;
									}
									else
									{
										ew.Checked = true;
										num = 12;
										num2 = num;
									}
									continue;
								case 4:
									num = 1;
									num2 = num;
									continue;
								case 1:
									if (length != 1024)
									{
										num = 6;
										num2 = num;
										continue;
									}
									goto case 11;
								case 11:
									eu.Checked = true;
									num = 8;
									num2 = num;
									continue;
								case 5:
									label.Text = $"{fileInfo.Name} ({fileInfo.Length} bytes)";
									num = 2;
									num2 = num;
									continue;
								case 8:
								case 12:
								{
									int num4 = int.Parse(hexBox.Name.Substring(hexBox.Name.Length - 1));
									label = a<Label>(base.Controls, $"lbl_hbfilename{num4}").FirstOrDefault();
									num = 3;
									num2 = num;
									continue;
								}
								case 3:
								{
									num = -24356;
									short num3 = num;
									num = -24356;
									switch (num3 == num)
									{
									case false:
									case true:
										break;
									default:
										goto IL_039b;
									}
									goto case 7;
								}
								case 2:
								{
									this.m_v = true;
									e7.SelectedIndex = 0;
									this.m_v = false;
									i();
									string text = "[!] Loaded '" + fileInfo.Name + "' " + Environment.NewLine;
									this.m_ar.AppendText(text);
									num = 0;
									num2 = num;
									continue;
								}
								case 0:
									return;
									IL_039b:
									num = 0;
									if (num != 0)
									{
									}
									if (label != null)
									{
										num = 5;
										num2 = num;
										continue;
									}
									goto case 2;
								}
								break;
							}
							goto case 0;
						case 0:
							a(hexBox);
							hexBox.ByteProvider = new DumpFileByteProvider(fileInfo.FullName);
							num = 7;
							num2 = num;
							goto default;
						}
					}
					catch (IOException ex)
					{
						string text2 = "[!] Failed to open file" + Environment.NewLine + ex.Message + Environment.NewLine;
						MessageBox.Show(text2);
						this.m_ar.AppendText(text2);
						return;
					}
				case 9:
					if (c(hexBox) == DialogResult.Cancel)
					{
						num = 11;
						num2 = num;
						break;
					}
					fileInfo = new FileInfo(fileName);
					flag = false;
					ew.Checked = false;
					ev.Checked = false;
					eu.Checked = false;
					num = 12;
					num2 = num;
					break;
				case 1:
					if (fileName.ToLower().Contains("hf-mfu"))
					{
						num = 6;
						num2 = num;
						break;
					}
					goto case 4;
				case 0:
					ev.Checked = true;
					flag = true;
					num = 8;
					num2 = num;
					break;
				case 10:
				{
					string text3 = "[!] Failed to open - File does not exist" + Environment.NewLine;
					MessageBox.Show(text3);
					this.m_ar.AppendText(text3);
					return;
				}
				case 4:
				case 8:
				case 13:
					num = 2;
					num2 = num;
					break;
				case 3:
					if (!fileName.ToLower().Contains("hf-mf"))
					{
						num = 1;
						num2 = num;
					}
					else
					{
						num = 5;
						num2 = num;
					}
					break;
				case 12:
					{
						if (!fileName.ToLower().Contains("iclass"))
						{
							num = 3;
							num2 = num;
						}
						else
						{
							num = 0;
							num2 = num;
						}
						break;
					}
					end_IL_003e:
					break;
				}
			}
		}
		}
	}

	private DialogResult c(HexBox A_0)
	{
		short num = 8;
		int num2 = num;
		DialogResult dialogResult = default(DialogResult);
		while (true)
		{
			switch (num2)
			{
			case 8:
				switch (0)
				{
				default:
					continue;
				case 0:
					break;
				}
				goto default;
			default:
				if (A_0.ByteProvider == null)
				{
					num = 0;
					num2 = num;
				}
				else
				{
					num = 4;
					num2 = num;
				}
				continue;
			case 11:
				if (dialogResult == DialogResult.No)
				{
					num = 7;
					num2 = num;
					continue;
				}
				goto case 3;
			case 4:
				if (A_0.ByteProvider != null)
				{
					num = 6;
					num2 = num;
					continue;
				}
				break;
			case 3:
			case 9:
				return dialogResult;
			case 0:
				return DialogResult.OK;
			case 7:
				b(A_0);
				num = 3;
				num2 = num;
				continue;
			case 5:
				if (dialogResult != DialogResult.Yes)
				{
					num = 11;
					num2 = num;
				}
				else
				{
					num = 1;
					num2 = num;
				}
				continue;
			case 1:
				num = 0;
				_ = num;
				d(A_0);
				b(A_0);
				num = 9;
				num2 = num;
				continue;
			case 6:
				num = 10;
				num2 = num;
				continue;
			case 10:
				if (A_0.ByteProvider.HasChanges())
				{
					num = 2;
					num2 = num;
					continue;
				}
				break;
			case 2:
			{
				num = 1;
				if (num != 0)
				{
				}
				dialogResult = MessageBox.Show("There are unsaved changes. Do you want to save them?", "File changed", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
				num = -29556;
				short num3 = num;
				num = -29556;
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
					num = 5;
					num2 = num;
					continue;
				}
				goto case 7;
			}
			}
			break;
		}
		b(A_0);
		return DialogResult.OK;
	}

	private void b(HexBox A_0)
	{
		int num = default(int);
		Label label = default(Label);
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 0:
					if (label != null)
					{
						short num2 = 2;
						num = num2;
						continue;
					}
					return;
				case 2:
				{
					this.m_ar.AppendText("[+] Closed file " + label.Text + Environment.NewLine);
					label.Text = "N/A";
					short num2 = 0;
					_ = num2;
					num2 = 1;
					num = num2;
					continue;
				}
				case 1:
					return;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			a(A_0);
			int num3 = int.Parse(A_0.Name.Substring(A_0.Name.Length - 1));
			label = a<Label>(base.Controls, $"lbl_hbfilename{num3}").FirstOrDefault();
			short num2 = 1;
			if (num2 != 0)
			{
			}
			num2 = -8373;
			short num4 = num2;
			num2 = -8373;
			switch (num4 == num2)
			{
			case false:
			case true:
				return;
			}
			num2 = 0;
			if (num2 != 0)
			{
			}
			num2 = 0;
			num = num2;
			goto default;
		}
		}
	}

	private void a(HexBox A_0)
	{
		short num = 0;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 0:
			{
				num = 1750;
				short num3 = num;
				num = 1750;
				switch (num3 == num)
				{
				case false:
				case true:
					goto IL_0138;
				}
				num = 0;
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
			}
			default:
				if (A_0.ByteProvider == null)
				{
					num = 2;
					num2 = num;
				}
				else
				{
					num = 4;
					num2 = num;
				}
				continue;
			case 2:
				return;
			case 4:
			{
				IDisposable obj = A_0.ByteProvider as IDisposable;
				if (obj == null)
				{
					num = 1;
					if (num != 0)
					{
					}
					num = 1;
					num2 = num;
					continue;
				}
				obj.Dispose();
				goto IL_0138;
			}
			case 1:
				num = 0;
				_ = num;
				break;
			case 3:
				break;
				IL_0138:
				num = 3;
				num2 = num;
				continue;
			}
			break;
		}
		A_0.ByteProvider = null;
	}

	private void i()
	{
		int num = default(int);
		switch (0)
		{
		default:
		{
			long num6 = default(long);
			int num5 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num)
				{
				case 6:
					if (d9.ByteProvider != null)
					{
						short num2 = 11;
						num = num2;
						continue;
					}
					goto case 13;
				case 12:
					if (d9.ByteProvider.Length <= d8.ByteProvider.Length)
					{
						num6 = d9.ByteProvider.Length;
						d8.AddHighlight(num6, d8.ByteProvider.Length - num6, Color.Red, Color.LightGreen);
						short num2 = 8;
						num = num2;
					}
					else
					{
						short num2 = 0;
						num = num2;
					}
					continue;
				case 15:
				{
					num5 = 0;
					short num2 = 5;
					num = num2;
					continue;
				}
				case 1:
				{
					short num2 = 2;
					num = num2;
					continue;
				}
				case 2:
					if (d9.ByteProvider.Length != d8.ByteProvider.Length)
					{
						num6 = 0L;
						short num2 = 12;
						num = num2;
					}
					else
					{
						short num2 = 15;
						num = num2;
					}
					continue;
				case 0:
				{
					num6 = d8.ByteProvider.Length;
					d9.AddHighlight(num6, d9.ByteProvider.Length - num6, Color.Blue, Color.LightGreen);
					short num2 = 14;
					num = num2;
					continue;
				}
				case 7:
				case 9:
				{
					short num2 = 18;
					num = num2;
					continue;
				}
				case 18:
					if (num3 < num6)
					{
						a(num3);
						num3++;
						short num2 = 9;
						num = num2;
					}
					else
					{
						short num2 = 16;
						num = num2;
					}
					continue;
				case 4:
				case 5:
				{
					short num2 = 17;
					num = num2;
					continue;
				}
				case 17:
				{
					short num2;
					if (num5 >= d9.ByteProvider.Length)
					{
						num2 = 3;
						num = num2;
						continue;
					}
					a(num5);
					num5++;
					num2 = 4;
					num = num2;
					continue;
				}
				case 11:
				{
					short num2 = 10;
					num = num2;
					continue;
				}
				case 10:
					if (d8.ByteProvider != null)
					{
						short num2 = 1;
						num = num2;
						continue;
					}
					goto case 13;
				case 8:
				case 14:
				{
					num3 = 0;
					short num2 = -4730;
					short num4 = num2;
					num2 = -4730;
					switch (num4 == num2)
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
						num2 = 7;
						num = num2;
						continue;
					}
					break;
				}
				case 3:
				{
					short num2 = 13;
					num = num2;
					continue;
				}
				case 13:
				case 16:
					d9.Invalidate();
					d8.Invalidate();
					return;
				}
				break;
			}
			goto case 0;
		}
		case 0:
		{
			d9.ClearHighlights();
			d8.ClearHighlights();
			short num2 = 6;
			num = num2;
			goto default;
		}
		}
	}

	private void a(int A_0)
	{
		short num = 0;
		int num2 = num;
		while (true)
		{
			num = -24059;
			short num3 = num;
			num = -24059;
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
				switch (num2)
				{
				case 0:
					num = 0;
					_ = num;
					switch (0)
					{
					default:
						goto end_IL_006b;
					case 0:
						break;
					}
					goto default;
				default:
					if (d9.ByteProvider.ReadByte(A_0) != d8.ByteProvider.ReadByte(A_0))
					{
						num = 2;
						num2 = num;
						goto end_IL_006b;
					}
					return;
				case 2:
					break;
				case 1:
					return;
				}
				d9.AddHighlight(A_0, 1L, Color.Blue, Color.LightGreen);
				d8.AddHighlight(A_0, 1L, Color.Red, Color.LightGreen);
				goto case false;
			case false:
			case true:
				{
					num = 1;
					num2 = num;
					break;
				}
				end_IL_006b:
				break;
			}
		}
	}

	public static Control FindControlAtPoint(Control container, Point pos)
	{
		short num = -4023;
		short num2 = num;
		num = -4023;
		int num3 = default(int);
		switch (num2 == num)
		{
		default:
			num = 0;
			_ = num;
			goto case true;
		case true:
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
		IEnumerator enumerator = container.Controls.GetEnumerator();
		Control result = default(Control);
		try
		{
			num = 3;
			num3 = num;
			Rectangle bounds = default(Rectangle);
			Control control2 = default(Control);
			while (true)
			{
				Control control;
				switch (num3)
				{
				case 8:
					break;
				case 3:
					switch (0)
					{
					default:
						continue;
					case 0:
						break;
					}
					goto default;
				case 6:
					bounds = control2.Bounds;
					num = 4;
					num3 = num;
					continue;
				case 4:
					if (bounds.Contains(pos))
					{
						num = 2;
						num3 = num;
						continue;
					}
					goto default;
				case 2:
					num = 0;
					num3 = num;
					continue;
				case 0:
					control = FindControlAtPoint(control2, new Point(pos.X - control2.Left, pos.Y - control2.Top));
					if (control == null)
					{
						num = 5;
						num3 = num;
						continue;
					}
					goto IL_0225;
				default:
					num = 7;
					num3 = num;
					continue;
				case 7:
					if (!enumerator.MoveNext())
					{
						num = 10;
						num3 = num;
					}
					else
					{
						control2 = (Control)enumerator.Current;
						num = 9;
						num3 = num;
					}
					continue;
				case 9:
					if (control2.Visible)
					{
						num = 6;
						num3 = num;
						continue;
					}
					goto default;
				case 5:
					control = control2;
					goto IL_0225;
				case 1:
					goto end_IL_00a2;
				case 10:
					{
						num = 8;
						num3 = num;
						continue;
					}
					IL_0225:
					result = control;
					num = 1;
					num3 = num;
					continue;
				}
				break;
			}
			goto IL_00a0;
			end_IL_00a2:;
		}
		finally
		{
			IDisposable disposable = default(IDisposable);
			switch (0)
			{
			default:
				while (true)
				{
					switch (num3)
					{
					case 0:
						if (disposable != null)
						{
							num = 2;
							num3 = num;
							continue;
						}
						goto end_IL_026b;
					case 2:
						disposable.Dispose();
						num = 1;
						num3 = num;
						continue;
					case 1:
						goto end_IL_026b;
					}
					goto case 0;
					continue;
					end_IL_026b:
					break;
				}
				break;
			case 0:
				disposable = enumerator as IDisposable;
				num = 0;
				num3 = num;
				goto default;
			}
		}
		num = 1;
		if (num != 0)
		{
		}
		return result;
		IL_00a0:
		return null;
	}

	private static List<a> a<a>(ICollection A_0, string A_1) where a : Control
	{
		short num = 0;
		int num2 = num;
		List<a> list = default(List<a>);
		Control control = default(Control);
		IEnumerator enumerator = default(IEnumerator);
		IDisposable disposable = default(IDisposable);
		switch (num2)
		{
		default:
			{
				switch (0)
				{
				case 0:
					goto IL_0075;
				}
				goto IL_003f;
			}
			IL_003f:
			while (true)
			{
				num = 0;
				_ = num;
				switch (num2)
				{
				case 0:
				{
					if (A_0 == null)
					{
						goto case 5;
					}
					num = 29892;
					short num3 = num;
					num = 29892;
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
					goto case 3;
				}
				case 4:
					return list;
				case 5:
					return list;
				case 2:
					num = 6;
					num2 = num;
					continue;
				case 6:
					if (A_0.Count == 0)
					{
						num = 5;
						num2 = num;
					}
					else
					{
						num = 1;
						num2 = num;
					}
					continue;
				case 3:
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
									goto end_IL_0188;
								case 0:
									break;
								}
								goto default;
							case 3:
								if (control.Name.ToLower().StartsWith(A_1))
								{
									num = 0;
									num2 = num;
									break;
								}
								goto default;
							case 6:
								if (control.HasChildren)
								{
									num = 4;
									num2 = num;
									break;
								}
								goto IL_01ba;
							default:
								num = 9;
								num2 = num;
								break;
							case 9:
								if (enumerator.MoveNext())
								{
									control = (Control)enumerator.Current;
									num = 6;
									num2 = num;
								}
								else
								{
									num = 8;
									num2 = num;
								}
								break;
							case 0:
								list.Add(control as a);
								num = 1;
								num2 = num;
								break;
							case 4:
								list.AddRange(a<a>(control.Controls, A_1));
								num = 5;
								num2 = num;
								break;
							case 5:
								num = 1;
								if (num == 0)
								{
								}
								goto IL_01ba;
							case 8:
								num = 7;
								num2 = num;
								break;
							case 7:
								{
									return list;
								}
								IL_01ba:
								num = 3;
								num2 = num;
								break;
								end_IL_0188:
								break;
							}
						}
					}
					finally
					{
						switch (0)
						{
						default:
							while (true)
							{
								switch (num2)
								{
								case 0:
									if (disposable != null)
									{
										num = 2;
										num2 = num;
										continue;
									}
									goto end_IL_032c;
								case 2:
									disposable.Dispose();
									num = 1;
									num2 = num;
									continue;
								case 1:
									goto end_IL_032c;
								}
								goto case 0;
								continue;
								end_IL_032c:
								break;
							}
							break;
						case 0:
							disposable = enumerator as IDisposable;
							num = 0;
							num2 = num;
							goto default;
						}
					}
				case 1:
					if (!string.IsNullOrWhiteSpace(A_1))
					{
						A_1 = A_1.ToLower();
						enumerator = A_0.GetEnumerator();
						num = 3;
						num2 = num;
					}
					else
					{
						num = 4;
						num2 = num;
					}
					continue;
				}
				break;
			}
			goto IL_0075;
			IL_0075:
			list = new List<a>();
			num = 0;
			num2 = num;
			goto IL_003f;
		}
	}

	public static void ApplyAll(Control c, Action<Control> action)
	{
		short num = 0;
		int num2 = num;
		IEnumerator enumerator = default(IEnumerator);
		IDisposable disposable = default(IDisposable);
		while (true)
		{
			num = 31348;
			short num3 = num;
			num = 31348;
			switch (num3 == num)
			{
			case false:
			case true:
				return;
			}
			num = 0;
			if (num != 0)
			{
			}
			switch (num2)
			{
			case 0:
				switch (0)
				{
				default:
					goto end_IL_006d;
				case 0:
					break;
				}
				goto default;
			default:
				if (c == null)
				{
					num = 2;
					num2 = num;
					break;
				}
				action(c);
				num = 1;
				if (num != 0)
				{
				}
				num = 4;
				num2 = num;
				break;
			case 2:
				return;
			case 3:
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
								goto end_IL_00c9;
							case 0:
								break;
							}
							goto default;
						default:
							num = 2;
							num2 = num;
							break;
						case 2:
							if (!enumerator.MoveNext())
							{
								num = 4;
								num2 = num;
							}
							else
							{
								ApplyAll((Control)enumerator.Current, action);
								num = 1;
								num2 = num;
							}
							break;
						case 4:
							num = 3;
							num2 = num;
							break;
						case 3:
							return;
							end_IL_00c9:
							break;
						}
					}
				}
				finally
				{
					switch (0)
					{
					default:
						while (true)
						{
							switch (num2)
							{
							case 0:
								if (disposable != null)
								{
									num = 2;
									num2 = num;
									continue;
								}
								goto end_IL_0166;
							case 2:
								disposable.Dispose();
								num = 1;
								num2 = num;
								continue;
							case 1:
								goto end_IL_0166;
							}
							goto case 0;
							continue;
							end_IL_0166:
							break;
						}
						break;
					case 0:
						disposable = enumerator as IDisposable;
						num = 0;
						num2 = num;
						goto default;
					}
				}
			case 1:
				return;
			case 4:
				{
					if (c.Controls.Count == 0)
					{
						num = 1;
						num2 = num;
						break;
					}
					num = 0;
					_ = num;
					enumerator = c.Controls.GetEnumerator();
					num = 3;
					num2 = num;
					break;
				}
				end_IL_006d:
				break;
			}
		}
	}

	private void h()
	{
		short num = 2;
		int num2 = num;
		int num4 = default(int);
		while (true)
		{
			num = -2791;
			short num3 = num;
			num = -2791;
			switch (num3 == num)
			{
			default:
				num = 0;
				if (num != 0)
				{
				}
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
					a<ComboBox>(this.m_a4.Controls, "cb_Rbutton").ForEach(delegate(ComboBox A_0)
					{
						short num5 = 1;
						if (num5 != 0)
						{
						}
						num5 = -23080;
						short num6 = num5;
						num5 = -23080;
						switch (num6 == num5)
						{
						default:
							num5 = 0;
							if (num5 != 0)
							{
							}
							num5 = 0;
							_ = num5;
							ApplyAll(A_0, delegate(Control control)
							{
								short num7 = 1;
								if (num7 != 0)
								{
								}
								num7 = -26106;
								short num8 = num7;
								num7 = -26106;
								switch (num8 == num7)
								{
								default:
									num7 = 0;
									if (num7 != 0)
									{
									}
									num7 = 0;
									_ = num7;
									control.Visible = false;
									break;
								}
							});
							break;
						}
					});
					num = 3;
					num2 = num;
					continue;
				case 3:
					break;
				case 0:
					a<ComboBox>(this.m_a4.Controls, "cb_Rbuttonlong").ForEach(delegate(ComboBox A_0)
					{
						short num5 = 31327;
						short num6 = num5;
						num5 = 31327;
						switch (num6 == num5)
						{
						default:
							num5 = 1;
							if (num5 != 0)
							{
							}
							num5 = 0;
							if (num5 != 0)
							{
							}
							num5 = 0;
							_ = num5;
							ApplyAll(A_0, delegate(Control control)
							{
								short num7 = 16593;
								short num8 = num7;
								num7 = 16593;
								switch (num8 == num7)
								{
								default:
									num7 = 1;
									if (num7 != 0)
									{
									}
									num7 = 0;
									if (num7 != 0)
									{
									}
									num7 = 0;
									_ = num7;
									control.Visible = false;
									break;
								}
							});
							break;
						}
					});
					num = 6;
					num2 = num;
					continue;
				case 6:
					a<ComboBox>(this.m_a4.Controls, "cb_Lbuttonlong").ForEach(delegate(ComboBox A_0)
					{
						short num5 = 1;
						if (num5 != 0)
						{
						}
						num5 = 26858;
						short num6 = num5;
						num5 = 26858;
						switch (num6 == num5)
						{
						default:
							num5 = 0;
							if (num5 != 0)
							{
							}
							num5 = 0;
							_ = num5;
							ApplyAll(A_0, delegate(Control control)
							{
								short num7 = 1;
								if (num7 != 0)
								{
								}
								num7 = 6515;
								short num8 = num7;
								num7 = 6515;
								switch (num8 == num7)
								{
								default:
									num7 = 0;
									if (num7 != 0)
									{
									}
									num7 = 0;
									_ = num7;
									control.Visible = true;
									control.Enabled = false;
									control.Width = 175;
									break;
								}
							});
							break;
						}
					});
					num = 4;
					num2 = num;
					continue;
				case 4:
					a<ComboBox>(this.m_a4.Controls, "cb_ledgreen").ForEach(delegate(ComboBox A_0)
					{
						short num5 = 1;
						if (num5 != 0)
						{
						}
						num5 = -3263;
						short num6 = num5;
						num5 = -3263;
						switch (num6 == num5)
						{
						default:
							num5 = 0;
							if (num5 != 0)
							{
							}
							num5 = 0;
							_ = num5;
							ApplyAll(A_0, delegate(Control control)
							{
								short num7 = -12362;
								short num8 = num7;
								num7 = -12362;
								switch (num8 == num7)
								{
								default:
									num7 = 1;
									if (num7 != 0)
									{
									}
									num7 = 0;
									if (num7 != 0)
									{
									}
									num7 = 0;
									_ = num7;
									control.Visible = false;
									control.Enabled = false;
									break;
								}
							});
							break;
						}
					});
					num = 9;
					num2 = num;
					continue;
				case 9:
					a<ComboBox>(this.m_a4.Controls, "cb_ledred").ForEach(delegate(ComboBox A_0)
					{
						short num5 = 14953;
						short num6 = num5;
						num5 = 14953;
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
							num5 = 0;
							_ = num5;
							ApplyAll(A_0, delegate(Control control)
							{
								short num7 = -9297;
								short num8 = num7;
								num7 = -9297;
								switch (num8 == num7)
								{
								default:
									num7 = 1;
									if (num7 != 0)
									{
									}
									num7 = 0;
									if (num7 != 0)
									{
									}
									num7 = 0;
									_ = num7;
									control.Visible = false;
									control.Enabled = false;
									break;
								}
							});
							break;
						}
					});
					g8.Visible = false;
					this.m_bg.Visible = true;
					num4 = 1;
					num = 8;
					num2 = num;
					continue;
				case 1:
				case 8:
					num = 5;
					num2 = num;
					continue;
				case 5:
					if (num4 < 9)
					{
						GroupBox obj = (GroupBox)this.m_a4.Controls.Find($"gb_tagslot{num4}", searchAllChildren: true).First();
						TableLayoutPanel obj2 = (TableLayoutPanel)obj.Controls[$"tableLayoutPanel{num4}"];
						obj2.SetColumnSpan(obj2.Controls[$"cb_Lbutton{num4}"], 2);
						obj2.SetColumnSpan(obj2.Controls[$"cb_Lbuttonlong{num4}"], 2);
						obj2.RowStyles[4].Height = 0f;
						obj2.RowStyles[5].Height = 0f;
						obj.Size = new Size(278, 181);
						num4++;
						num = 1;
						num2 = num;
					}
					else
					{
						num = 7;
						num2 = num;
					}
					continue;
				case 7:
					num = 0;
					_ = num;
					return;
				}
				a<ComboBox>(this.m_a4.Controls, "cb_Lbutton").ForEach(delegate(ComboBox A_0)
				{
					short num5 = -8135;
					short num6 = num5;
					num5 = -8135;
					switch (num6 == num5)
					{
					default:
						num5 = 1;
						if (num5 != 0)
						{
						}
						num5 = 0;
						if (num5 != 0)
						{
						}
						num5 = 0;
						_ = num5;
						ApplyAll(A_0, delegate(Control control)
						{
							short num7 = -1372;
							short num8 = num7;
							num7 = -1372;
							switch (num8 == num7)
							{
							default:
								num7 = 1;
								if (num7 != 0)
								{
								}
								num7 = 0;
								if (num7 != 0)
								{
								}
								num7 = 0;
								_ = num7;
								control.Visible = true;
								control.Width = 175;
								break;
							}
						});
						break;
					}
				});
				break;
			case false:
			case true:
				break;
			}
			num = 1;
			if (num != 0)
			{
			}
			num = 0;
			num2 = num;
		}
	}

	private void g()
	{
		short num = 2;
		int num2 = num;
		int num4 = default(int);
		while (true)
		{
			num = -30946;
			short num3 = num;
			num = -30946;
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
					a<ComboBox>(this.m_a4.Controls, "cb_Rbutton").ForEach(delegate(ComboBox A_0)
					{
						short num5 = 1;
						if (num5 != 0)
						{
						}
						num5 = 19119;
						short num6 = num5;
						num5 = 19119;
						switch (num6 == num5)
						{
						default:
							num5 = 0;
							if (num5 != 0)
							{
							}
							num5 = 0;
							_ = num5;
							ApplyAll(A_0, delegate(Control control)
							{
								short num7 = 1;
								if (num7 != 0)
								{
								}
								num7 = 24568;
								short num8 = num7;
								num7 = 24568;
								switch (num8 == num7)
								{
								default:
									num7 = 0;
									if (num7 != 0)
									{
									}
									num7 = 0;
									_ = num7;
									control.Visible = true;
									control.Width = 80;
									control.Enabled = true;
									break;
								}
							});
							break;
						}
					});
					num = 3;
					num2 = num;
					continue;
				case 3:
					break;
				case 0:
					a<ComboBox>(this.m_a4.Controls, "cb_Rbuttonlong").ForEach(delegate(ComboBox A_0)
					{
						short num5 = -20261;
						short num6 = num5;
						num5 = -20261;
						switch (num6 == num5)
						{
						default:
							num5 = 1;
							if (num5 != 0)
							{
							}
							num5 = 0;
							if (num5 != 0)
							{
							}
							num5 = 0;
							_ = num5;
							ApplyAll(A_0, delegate(Control control)
							{
								short num7 = 20146;
								short num8 = num7;
								num7 = 20146;
								switch (num8 == num7)
								{
								default:
									num7 = 1;
									if (num7 != 0)
									{
									}
									num7 = 0;
									if (num7 != 0)
									{
									}
									num7 = 0;
									_ = num7;
									control.Visible = true;
									control.Width = 80;
									break;
								}
							});
							break;
						}
					});
					num = 6;
					num2 = num;
					continue;
				case 6:
					a<ComboBox>(this.m_a4.Controls, "cb_Lbuttonlong").ForEach(delegate(ComboBox A_0)
					{
						short num5 = 1;
						if (num5 != 0)
						{
						}
						num5 = 13006;
						short num6 = num5;
						num5 = 13006;
						switch (num6 == num5)
						{
						default:
							num5 = 0;
							if (num5 != 0)
							{
							}
							num5 = 0;
							_ = num5;
							ApplyAll(A_0, delegate(Control control)
							{
								short num7 = -7497;
								short num8 = num7;
								num7 = -7497;
								switch (num8 == num7)
								{
								default:
									num7 = 1;
									if (num7 != 0)
									{
									}
									num7 = 0;
									if (num7 != 0)
									{
									}
									num7 = 0;
									_ = num7;
									control.Visible = true;
									control.Width = 80;
									break;
								}
							});
							break;
						}
					});
					num = 4;
					num2 = num;
					continue;
				case 4:
					a<ComboBox>(this.m_a4.Controls, "cb_ledgreen").ForEach(delegate(ComboBox A_0)
					{
						short num5 = -2701;
						short num6 = num5;
						num5 = -2701;
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
							num5 = 0;
							_ = num5;
							ApplyAll(A_0, delegate(Control control)
							{
								short num7 = 10616;
								short num8 = num7;
								num7 = 10616;
								switch (num8 == num7)
								{
								default:
									num7 = 1;
									if (num7 != 0)
									{
									}
									num7 = 0;
									if (num7 != 0)
									{
									}
									num7 = 0;
									_ = num7;
									control.Visible = false;
									control.Enabled = false;
									break;
								}
							});
							break;
						}
					});
					num = 9;
					num2 = num;
					continue;
				case 9:
					a<ComboBox>(this.m_a4.Controls, "cb_ledred").ForEach(delegate(ComboBox A_0)
					{
						short num5 = 1;
						if (num5 != 0)
						{
						}
						num5 = -30164;
						short num6 = num5;
						num5 = -30164;
						switch (num6 == num5)
						{
						default:
							num5 = 0;
							if (num5 != 0)
							{
							}
							num5 = 0;
							_ = num5;
							ApplyAll(A_0, delegate(Control control)
							{
								short num7 = -2877;
								short num8 = num7;
								num7 = -2877;
								switch (num8 == num7)
								{
								default:
									num7 = 1;
									if (num7 != 0)
									{
									}
									num7 = 0;
									if (num7 != 0)
									{
									}
									num7 = 0;
									_ = num7;
									control.Visible = false;
									control.Enabled = false;
									break;
								}
							});
							break;
						}
					});
					g8.Visible = true;
					this.m_bg.Visible = true;
					num4 = 1;
					num = 8;
					num2 = num;
					continue;
				case 1:
				case 8:
					num = 5;
					num2 = num;
					continue;
				case 5:
					if (num4 < 9)
					{
						GroupBox obj = (GroupBox)this.m_a4.Controls.Find($"gb_tagslot{num4}", searchAllChildren: true).First();
						TableLayoutPanel obj2 = (TableLayoutPanel)obj.Controls[$"tableLayoutPanel{num4}"];
						obj2.SetColumnSpan(obj2.Controls[$"cb_Lbutton{num4}"], 1);
						obj2.SetColumnSpan(obj2.Controls[$"cb_Lbuttonlong{num4}"], 1);
						obj2.RowStyles[4].Height = 0f;
						obj2.RowStyles[5].Height = 0f;
						obj.Size = new Size(278, 181);
						num4++;
						num = 1;
						num2 = num;
					}
					else
					{
						num = 7;
						num2 = num;
					}
					continue;
				case 7:
					num = 0;
					_ = num;
					return;
				}
				a<ComboBox>(this.m_a4.Controls, "cb_Lbutton").ForEach(delegate(ComboBox A_0)
				{
					short num5 = -27927;
					short num6 = num5;
					num5 = -27927;
					switch (num6 == num5)
					{
					default:
						num5 = 1;
						if (num5 != 0)
						{
						}
						num5 = 0;
						if (num5 != 0)
						{
						}
						num5 = 0;
						_ = num5;
						ApplyAll(A_0, delegate(Control control)
						{
							short num7 = 16853;
							short num8 = num7;
							num7 = 16853;
							switch (num8 == num7)
							{
							default:
								num7 = 1;
								if (num7 != 0)
								{
								}
								num7 = 0;
								if (num7 != 0)
								{
								}
								num7 = 0;
								_ = num7;
								control.Visible = true;
								control.Width = 80;
								control.Enabled = true;
								break;
							}
						});
						break;
					}
				});
				break;
			case false:
			case true:
				break;
			}
			num = 0;
			num2 = num;
		}
	}

	private void f()
	{
		List<global::c>.Enumerator enumerator = a<global::c>(this.m_a4.Controls, "gb_tagslot").GetEnumerator();
		short num;
		try
		{
			num = 2;
			int num2 = num;
			global::c current = default(global::c);
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
				case 8:
					num = 3;
					num2 = num;
					continue;
				case 3:
					if (current.Name.ToLower().StartsWith($"gb_tagslot{this.m_x}"))
					{
						num = 0;
						num2 = num;
						continue;
					}
					current.e(SystemColors.ControlLight);
					current.f(SystemColors.ControlLightLight);
					num = 1;
					num2 = num;
					continue;
				default:
					num = 6;
					num2 = num;
					continue;
				case 6:
					if (!enumerator.MoveNext())
					{
						num = 4;
						num2 = num;
						continue;
					}
					current = enumerator.Current;
					goto IL_010d;
				case 9:
					if (int.Parse(current.Name.Substring(current.Name.Length - 1)) > 0)
					{
						num = 8;
						num2 = num;
						continue;
					}
					goto default;
				case 0:
					current.e(Color.Green);
					current.f(Color.AntiqueWhite);
					num = 5;
					num2 = num;
					continue;
				case 5:
				{
					num = -11123;
					short num3 = num;
					num = -11123;
					switch (num3 == num)
					{
					case false:
					case true:
						break;
					default:
						goto IL_01fa;
					}
					goto IL_010d;
				}
				case 4:
					num = 7;
					num2 = num;
					continue;
				case 7:
					break;
					IL_01fa:
					num = 0;
					if (num == 0)
					{
					}
					goto default;
					IL_010d:
					num = 9;
					num2 = num;
					continue;
				}
				break;
			}
		}
		finally
		{
			num = 1;
			if (num != 0)
			{
			}
			((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
		}
		num = 0;
		_ = num;
		global::c.e(this.m_a4);
	}

	private bool e()
	{
		int num = default(int);
		string text = default(string);
		short num2;
		switch (0)
		{
		default:
		{
			int result = default(int);
			while (true)
			{
				switch (num)
				{
				case 2:
					goto IL_00f3;
				case 0:
					this.m_x = result + this.m_p;
					return true;
				case 1:
					goto IL_013c;
				case 3:
					return false;
				}
				break;
				IL_013c:
				if (!int.TryParse(text.Substring(text.Length - 1), out result))
				{
					goto end_IL_0001;
				}
				num2 = 0;
				num = num2;
				continue;
				IL_00f3:
				if (text.Length <= 0)
				{
					num2 = 3;
					num = num2;
				}
				else
				{
					num2 = 1;
					num = num2;
				}
			}
			goto case 0;
		}
		case 0:
			{
				text = m("SETTING" + this.m_i + "?").ToString();
				num2 = -18591;
				short num3 = num2;
				num2 = -18591;
				switch (num3 == num2)
				{
				default:
					num2 = 0;
					_ = num2;
					goto case true;
				case true:
					num2 = 1;
					if (num2 == 0)
					{
					}
					goto IL_00c4;
				case false:
				case true:
					break;
				}
				break;
			}
			IL_00c4:
			num2 = 0;
			if (num2 != 0)
			{
			}
			num2 = 2;
			num = num2;
			goto default;
			end_IL_0001:
			break;
		}
		return false;
	}

	private void d()
	{
		short num = 4;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 4:
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
				num = 14682;
				short num3 = num;
				num = 14682;
				switch (num3 == num)
				{
				case false:
				case true:
					goto IL_0170;
				}
				num = 0;
				if (num != 0)
				{
				}
				if (this.m_x < this.m_p)
				{
					num = 1;
					if (num != 0)
					{
					}
					num = 0;
					num2 = num;
					continue;
				}
				goto case 2;
			}
			case 2:
				num = 1;
				num2 = num;
				continue;
			case 1:
				if (this.m_x > this.m_p + 8)
				{
					num = 3;
					num2 = num;
					continue;
				}
				break;
			case 3:
				num = 0;
				_ = num;
				this.m_x = this.m_p + 8;
				num = 5;
				num2 = num;
				continue;
			case 0:
				goto IL_0170;
			case 5:
				break;
				IL_0170:
				this.m_x = this.m_p;
				num = 2;
				num2 = num;
				continue;
			}
			break;
		}
		n($"SETTING{this.m_i}={this.m_x - this.m_p}");
		f();
	}

	private void c()
	{
		short num = 5;
		int num2 = num;
		while (true)
		{
			switch (num2)
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
				if (!this.m_k)
				{
					num = 2;
					num2 = num;
				}
				else
				{
					num = 4;
					num2 = num;
				}
				continue;
			case 2:
				return;
			case 3:
				num = 6;
				num2 = num;
				continue;
			case 6:
				num = 0;
				_ = num;
				num = 1;
				if (num != 0)
				{
				}
				if (this.m_a.IsOpen)
				{
					num = 0;
					num2 = num;
					continue;
				}
				break;
			case 0:
			{
				num = -2068;
				short num3 = num;
				num = -2068;
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
					try
					{
						this.m_a.Close();
					}
					catch
					{
					}
					this.m_a = null;
					this.m_l = true;
					num = 1;
					num2 = num;
					continue;
				}
				goto default;
			}
			case 4:
				if (this.m_a != null)
				{
					num = 3;
					num2 = num;
					continue;
				}
				break;
			case 1:
				break;
			}
			break;
		}
		s();
	}

	private void ad(object A_0, EventArgs A_1)
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
				num = 0;
				_ = num;
				if (this.m_k)
				{
					num = 2;
					num2 = num;
					continue;
				}
				goto case 0;
			case 2:
				break;
			case 0:
			{
				num = -7557;
				short num3 = num;
				num = -7557;
				switch (num3 == num)
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
					z(A_0, A_1);
					return;
				}
				break;
			}
			}
			o("SETTING" + this.m_i + "=9");
			c();
			num = 0;
			num2 = num;
		}
	}

	private void ac(object A_0, EventArgs A_1)
	{
		if (!this.m_k)
		{
			short num = -27601;
			short num2 = num;
			num = -27601;
			switch (num2 == num)
			{
			case false:
			case true:
				break;
			default:
				num = 0;
				_ = num;
				goto case true;
			case true:
				num = 1;
				if (num != 0)
				{
				}
				num = 0;
				if (num != 0)
				{
				}
				ay(A_0, A_1);
				dk.SelectedTab = this.m_a4;
				return;
			}
		}
		dk.SelectedTab = this.m_a4;
	}

	private void ab(object A_0, EventArgs A_1)
	{
		short num;
		if (!this.m_k)
		{
			num = 0;
			_ = num;
			num = -5523;
			short num2 = num;
			num = -5523;
			switch (num2 == num)
			{
			case false:
			case true:
				break;
			default:
				num = 0;
				if (num != 0)
				{
				}
				ay(A_0, A_1);
				hu.Text = "断开设备";
				return;
			}
		}
		num = 1;
		if (num != 0)
		{
		}
		c();
		hu.Text = "连接设备";
		this.m_an = false;
	}

	private void aa(object A_0, EventArgs A_1)
	{
		short num = -24995;
		short num2 = num;
		num = -24995;
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

	private void a(string A_0)
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
					if (A_0.Equals("rfidfans_com_pcr532_com_copyright"))
					{
						num = 3;
						num2 = num;
					}
					else
					{
						this.m_ar.AppendText(A_0);
						num = 4;
						num2 = num;
					}
					continue;
				case 5:
					this.m_ar.Clear();
					this.m_ao = 0;
					num = 7;
					num2 = num;
					continue;
				case 4:
					this.m_ar.AppendText(Environment.NewLine ?? "");
					this.m_ar.ScrollToCaret();
					this.m_ao++;
					num = 2;
					num2 = num;
					continue;
				case 3:
					this.m_ar.AppendText("..");
					num = 0;
					num2 = num;
					continue;
				case 2:
				{
					num = 17381;
					short num3 = num;
					num = 17381;
					switch (num3 == num)
					{
					default:
						num = 0;
						if (num != 0)
						{
						}
						if (this.m_ao <= 400)
						{
							break;
						}
						goto case false;
					case false:
					case true:
						num = 5;
						num2 = num;
						continue;
					}
					break;
				}
				case 0:
				case 7:
					break;
				case 1:
					goto end_IL_0020;
				}
				num = 1;
				num2 = num;
				continue;
				end_IL_0020:
				break;
			}
		}
		catch (Exception)
		{
		}
		num = 1;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
	}

	private bool b()
	{
		short num = 0;
		int num2 = num;
		int num5 = default(int);
		byte[] array = default(byte[]);
		SerialPort serialPort = default(SerialPort);
		int num4 = default(int);
		int num7 = default(int);
		byte[] array2 = default(byte[]);
		string text2 = default(string);
		string text3 = default(string);
		string[] array3 = default(string[]);
		string text = default(string);
		byte[] buffer = default(byte[]);
		int num3 = default(int);
		switch (num2)
		{
		default:
			{
				switch (0)
				{
				case 0:
					goto IL_00b3;
				}
				goto IL_0028;
			}
			IL_0028:
			while (true)
			{
				switch (num2)
				{
				case 27:
					if (File.Exists("config/libnfc.conf"))
					{
						num = 7;
						num2 = num;
						continue;
					}
					a("设备配置错误！");
					return false;
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
								case 2:
								case 3:
									num = 4;
									num2 = num;
									continue;
								case 4:
									if (num5 >= 15)
									{
										num = 0;
										num2 = num;
										continue;
									}
									array[num5] = (byte)serialPort.ReadByte();
									num5++;
									num = 2;
									num2 = num;
									continue;
								case 0:
									num = 1;
									num2 = num;
									continue;
								case 1:
									goto end_IL_010d;
								}
								goto case 0;
								continue;
								end_IL_010d:
								break;
							}
							break;
						case 0:
							{
								num5 = 0;
								num = 7116;
								short num6 = num;
								num = 7116;
								switch (num6 == num)
								{
								default:
									num = 0;
									if (num != 0)
									{
									}
									num = 3;
									num2 = num;
									break;
								case false:
								case true:
									goto end_IL_0104;
								}
								goto default;
							}
							end_IL_0104:
							break;
						}
					}
					catch (Exception ex3)
					{
						Console.Write(ex3.Message);
						num3++;
					}
					num4 = 0;
					num = 1;
					num2 = num;
					continue;
				case 31:
					if (num3 == 0)
					{
						num = 23;
						num2 = num;
						continue;
					}
					return false;
				case 26:
					num3++;
					num = 30;
					num2 = num;
					continue;
				case 14:
					num7++;
					num = 4;
					num2 = num;
					continue;
				case 21:
					num = 0;
					_ = num;
					array = new byte[15];
					array2 = new byte[15]
					{
						0, 0, 255, 0, 255, 0, 0, 0, 255, 2,
						254, 213, 21, 22, 0
					};
					num = 22;
					num2 = num;
					continue;
				case 5:
					num = 2;
					num2 = num;
					continue;
				case 25:
					num3 = 0;
					serialPort = new SerialPort();
					serialPort.PortName = text2;
					serialPort.BaudRate = int.Parse(text3);
					serialPort.DataBits = 8;
					serialPort.StopBits = StopBits.One;
					serialPort.Parity = Parity.None;
					serialPort.ReadTimeout = 500;
					num = 10;
					num2 = num;
					continue;
				case 10:
					if (serialPort.IsOpen)
					{
						num = 18;
						num2 = num;
					}
					else
					{
						num = 24;
						num2 = num;
					}
					continue;
				case 1:
				case 16:
					num = 8;
					num2 = num;
					continue;
				case 8:
					if (num4 >= 15)
					{
						num = 5;
						num2 = num;
					}
					else
					{
						num = 13;
						num2 = num;
					}
					continue;
				case 2:
					serialPort.Close();
					return true;
				case 32:
					if (serialPort != null)
					{
						num = 19;
						num2 = num;
						continue;
					}
					goto IL_0224;
				case 7:
					array3 = File.ReadAllLines("config/libnfc.conf");
					num7 = 0;
					num = 3;
					num2 = num;
					continue;
				case 0:
					num = 25;
					num2 = num;
					continue;
				case 3:
				case 4:
					num = 11;
					num2 = num;
					continue;
				case 11:
					if (num7 >= array3.Length)
					{
						num = 0;
						num2 = num;
					}
					else
					{
						text = array3[num7];
						num = 9;
						num2 = num;
					}
					continue;
				case 30:
					num4++;
					num = 16;
					num2 = num;
					continue;
				case 19:
					num = 29;
					num2 = num;
					continue;
				case 29:
					if (serialPort.IsOpen)
					{
						num = 20;
						num2 = num;
						continue;
					}
					goto IL_0224;
				case 20:
					num = 1;
					if (num != 0)
					{
					}
					buffer = new byte[24]
					{
						85, 85, 0, 0, 0, 0, 0, 0, 0, 0,
						0, 0, 0, 0, 0, 0, 255, 3, 253, 212,
						20, 1, 23, 0
					};
					num = 12;
					num2 = num;
					continue;
				case 28:
					num = 17;
					num2 = num;
					continue;
				case 17:
					if (serialPort.IsOpen)
					{
						num = 21;
						num2 = num;
						continue;
					}
					goto case 2;
				case 24:
					try
					{
						serialPort.Open();
					}
					catch (Exception ex2)
					{
						Console.Write(ex2.Message);
						num3++;
						return false;
					}
					num = 32;
					num2 = num;
					continue;
				case 6:
					text2 = text.Replace("device.connstring = \"pn532_uart", "").Replace("\"", "").Split(':')[1];
					text3 = text.Replace("device.connstring = \"pn532_uart:" + text2 + ":", "").Replace("\"", "");
					num = 14;
					num2 = num;
					continue;
				case 13:
					if (array[num4] != array2[num4])
					{
						num = 26;
						num2 = num;
						continue;
					}
					goto case 30;
				case 18:
					serialPort.Close();
					return false;
				case 12:
					try
					{
						serialPort.Write(buffer, 0, 24);
					}
					catch (Exception ex)
					{
						Console.Write(ex.Message);
						num3++;
					}
					goto IL_0224;
				case 9:
					if (text.StartsWith("device.connstring = \"pn532_uart:"))
					{
						num = 6;
						num2 = num;
						continue;
					}
					goto case 14;
				case 23:
					num = 15;
					num2 = num;
					continue;
				case 15:
					{
						if (serialPort != null)
						{
							num = 28;
							num2 = num;
							continue;
						}
						goto case 2;
					}
					IL_0224:
					num = 31;
					num2 = num;
					continue;
				}
				break;
			}
			goto IL_00b3;
			IL_00b3:
			text2 = "";
			text3 = "";
			num = 27;
			num2 = num;
			goto IL_0028;
		}
	}

	private void a(string A_0, bool A_1 = true, bool A_2 = false)
	{
		short num = -27679;
		short num2 = num;
		num = -27679;
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
		string text = "allow_autoscan = " + (A_1 ? "true" : "false") + "\n";
		text = text + "allow_intrusive_scan = " + (A_2 ? "true" : "false") + "\n";
		text += "device.name = \"NFC-Device\"\n";
		text = text + "device.connstring = \"" + A_0 + "\"";
		File.WriteAllText("config/libnfc.conf", text);
		File.WriteAllText("libnfc.conf", text);
	}

	private void z(object A_0, EventArgs A_1)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 40;
			int num2 = num;
			short num4 = default(short);
			SerialPort serialPort = default(SerialPort);
			byte[] buffer = default(byte[]);
			short num3 = default(short);
			byte[] array3 = default(byte[]);
			byte[] array4 = default(byte[]);
			byte[] buffer2 = default(byte[]);
			byte[] array = default(byte[]);
			byte[] array2 = default(byte[]);
			while (true)
			{
				switch (num2)
				{
				case 40:
					switch (0)
					{
					default:
						goto end_IL_0040;
					case 0:
						break;
					}
					goto default;
				default:
					if (this.m_aa)
					{
						num = 44;
						num2 = num;
					}
					else
					{
						num4 = 0;
						num = 0;
						num2 = num;
					}
					break;
				case 14:
					try
					{
						serialPort.Write(buffer, 0, 24);
					}
					catch (Exception ex4)
					{
						MessageBox.Show(ex4.Message);
						num4++;
					}
					goto IL_09b6;
				case 27:
					serialPort.Close();
					num = 36;
					num2 = num;
					break;
				case 22:
					num = 43;
					num2 = num;
					break;
				case 43:
					if (serialPort != null)
					{
						num = 21;
						num2 = num;
						break;
					}
					goto IL_060d;
				case 5:
					serialPort.Close();
					num = 22;
					num2 = num;
					break;
				case 6:
					num = 50;
					num2 = num;
					break;
				case 50:
					if (serialPort.IsOpen)
					{
						num = 38;
						num2 = num;
						break;
					}
					goto IL_09b6;
				case 18:
					num3++;
					num = 47;
					num2 = num;
					break;
				case 23:
					if (serialPort.IsOpen)
					{
						num = 27;
						num2 = num;
					}
					else
					{
						num = 48;
						num2 = num;
					}
					break;
				case 24:
					if (array3[num3] != array4[num3])
					{
						num = 41;
						num2 = num;
						break;
					}
					goto case 18;
				case 3:
					MessageBox.Show("发现NFC设备", "连接成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					a("pn532_uart:" + hl.SelectedItem.ToString() + ":115200", A_1: true, A_2: false);
					return;
				case 44:
					MessageBox.Show("有任务运行中_不可执行", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				case 11:
					try
					{
						serialPort.Write(buffer2, 0, 24);
					}
					catch (Exception ex2)
					{
						MessageBox.Show(ex2.Message);
						num4++;
					}
					goto IL_060d;
				case 41:
					num4++;
					num = 18;
					num2 = num;
					break;
				case 31:
					num = 51;
					num2 = num;
					break;
				case 51:
					if (serialPort.IsOpen)
					{
						num = 12;
						num2 = num;
						break;
					}
					goto case 13;
				case 37:
					if (array[num3] != array2[num3])
					{
						num = 2;
						num2 = num;
						break;
					}
					goto case 32;
				case 19:
					num = 35;
					num2 = num;
					break;
				case 35:
					if (serialPort.IsOpen)
					{
						num = 9;
						num2 = num;
						break;
					}
					goto case 20;
				case 21:
					num = 7;
					num2 = num;
					break;
				case 7:
					if (serialPort.IsOpen)
					{
						num = 26;
						num2 = num;
						break;
					}
					goto IL_060d;
				case 26:
				{
					num = -1181;
					short num5 = num;
					num = -1181;
					switch (num5 == num)
					{
					case false:
					case true:
						break;
					default:
						num = 0;
						if (num != 0)
						{
						}
						buffer2 = new byte[24]
						{
							85, 85, 0, 0, 0, 0, 0, 0, 0, 0,
							0, 0, 0, 0, 0, 0, 255, 3, 253, 212,
							20, 1, 23, 0
						};
						num = 11;
						num2 = num;
						goto end_IL_0040;
					}
					goto case 27;
				}
				case 49:
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
								case 2:
									num = 0;
									num2 = num;
									continue;
								case 0:
									if (num3 < 15)
									{
										array3[num3] = (byte)serialPort.ReadByte();
										num3++;
										num = 2;
										num2 = num;
									}
									else
									{
										num = 4;
										num2 = num;
									}
									continue;
								case 4:
									num = 3;
									num2 = num;
									continue;
								case 3:
									goto end_IL_0548;
								}
								goto case 0;
								continue;
								end_IL_0548:
								break;
							}
							break;
						case 0:
							num3 = 0;
							num = 1;
							num2 = num;
							goto default;
						}
					}
					catch (Exception ex6)
					{
						MessageBox.Show(ex6.Message);
						num4++;
					}
					serialPort.Close();
					num3 = 0;
					num = 28;
					num2 = num;
					break;
				case 8:
					if (serialPort != null)
					{
						num = 19;
						num2 = num;
						break;
					}
					goto case 20;
				case 29:
					try
					{
						serialPort.Open();
					}
					catch (Exception)
					{
						MessageBox.Show("请插入设备或者请安装驱动", "连接设备错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					goto case 22;
				case 46:
					MessageBox.Show("发现NFC设备", "连接成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					a("pn532_uart:" + hl.SelectedItem.ToString() + ":" + this.m_ae, A_1: true, A_2: false);
					return;
				case 0:
					if (this.m_ae == "921600")
					{
						num = 39;
						num2 = num;
						break;
					}
					goto case 33;
				case 20:
					num = 25;
					num2 = num;
					break;
				case 25:
					if (num4 != 0)
					{
						serialPort.BaudRate = 115200;
						num = 23;
						num2 = num;
					}
					else
					{
						num = 46;
						num2 = num;
					}
					break;
				case 2:
					num4++;
					num = 32;
					num2 = num;
					break;
				case 12:
					array3 = new byte[15];
					array4 = new byte[15]
					{
						0, 0, 255, 0, 255, 0, 0, 0, 255, 2,
						254, 213, 21, 22, 0
					};
					num = 49;
					num2 = num;
					break;
				case 32:
					num3++;
					num = 45;
					num2 = num;
					break;
				case 28:
				case 47:
					num = 15;
					num2 = num;
					break;
				case 15:
					if (num3 < 15)
					{
						num = 24;
						num2 = num;
					}
					else
					{
						num = 13;
						num2 = num;
					}
					break;
				case 17:
					MessageBox.Show("请插入设备或者请安装驱动", "连接设备错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				case 39:
					b();
					num = 33;
					num2 = num;
					break;
				case 13:
					num = 4;
					num2 = num;
					break;
				case 4:
					if (num4 == 0)
					{
						num = 3;
						num2 = num;
					}
					else
					{
						MessageBox.Show("连接失败,该端口不存在pn532,换个端口或者重新插拔一下设备！", "连接失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						num = 34;
						num2 = num;
					}
					break;
				case 10:
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
								case 2:
									num = 0;
									num2 = num;
									continue;
								case 0:
									if (num3 < 15)
									{
										array[num3] = (byte)serialPort.ReadByte();
										num3++;
										num = 2;
										num2 = num;
									}
									else
									{
										num = 4;
										num2 = num;
									}
									continue;
								case 4:
									num = 3;
									num2 = num;
									continue;
								case 3:
									goto end_IL_086c;
								}
								goto case 0;
								continue;
								end_IL_086c:
								break;
							}
							break;
						case 0:
							num3 = 0;
							num = 1;
							num2 = num;
							goto default;
						}
					}
					catch (Exception)
					{
						num4++;
					}
					serialPort.Close();
					num3 = 0;
					num = 42;
					num2 = num;
					break;
				case 53:
					if (!serialPort.IsOpen)
					{
						num = 29;
						num2 = num;
					}
					else
					{
						num = 5;
						num2 = num;
					}
					break;
				case 52:
					if (serialPort != null)
					{
						num = 31;
						num2 = num;
						break;
					}
					goto case 13;
				case 33:
					num = 1;
					num2 = num;
					break;
				case 1:
					if (!string.IsNullOrEmpty(hl.Text))
					{
						int baudRate = int.Parse(this.m_ae);
						serialPort = new SerialPort();
						serialPort.PortName = hl.SelectedItem.ToString();
						serialPort.BaudRate = baudRate;
						serialPort.DataBits = 8;
						serialPort.StopBits = StopBits.One;
						serialPort.Parity = Parity.None;
						serialPort.ReadTimeout = 1000;
						num = 53;
						num2 = num;
					}
					else
					{
						num = 1;
						if (num != 0)
						{
						}
						num = 17;
						num2 = num;
					}
					break;
				case 42:
				case 45:
					num = 16;
					num2 = num;
					break;
				case 16:
					if (num3 < 15)
					{
						num = 37;
						num2 = num;
					}
					else
					{
						num = 20;
						num2 = num;
					}
					break;
				case 38:
					buffer = new byte[24]
					{
						85, 85, 0, 0, 0, 0, 0, 0, 0, 0,
						0, 0, 0, 0, 0, 0, 255, 3, 253, 212,
						20, 1, 23, 0
					};
					num = 14;
					num2 = num;
					break;
				case 34:
					return;
				case 36:
					num = 30;
					num2 = num;
					break;
				case 30:
					if (serialPort != null)
					{
						num = 6;
						num2 = num;
						break;
					}
					goto IL_09b6;
				case 9:
					array = new byte[15];
					array2 = new byte[15]
					{
						0, 0, 255, 0, 255, 0, 0, 0, 255, 2,
						254, 213, 21, 22, 0
					};
					num = 0;
					_ = num;
					num = 10;
					num2 = num;
					break;
				case 48:
					{
						try
						{
							serialPort.Open();
						}
						catch (Exception)
						{
							MessageBox.Show("请插入设备或者请安装驱动", "连接设备错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							return;
						}
						goto case 36;
					}
					IL_09b6:
					num = 52;
					num2 = num;
					break;
					IL_060d:
					num = 8;
					num2 = num;
					break;
					end_IL_0040:
					break;
				}
			}
		}
		}
	}

	private void y(object A_0, EventArgs A_1)
	{
		int num = default(int);
		string[] portNames = default(string[]);
		switch (0)
		{
		default:
			while (true)
			{
				short num2;
				switch (num)
				{
				case 5:
					if (portNames == null)
					{
						goto IL_005b;
					}
					goto IL_011e;
				case 1:
					num2 = 1;
					if (num2 != 0)
					{
					}
					num2 = 8;
					num = num2;
					continue;
				case 2:
					num2 = 6;
					num = num2;
					continue;
				case 6:
				{
					num2 = -20861;
					short num3 = num2;
					num2 = -20861;
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
						if (portNames.Length != 0)
						{
							num2 = 4;
							num = num2;
							continue;
						}
						return;
					}
					goto IL_005b;
				}
				case 3:
					if (portNames != null)
					{
						num2 = 2;
						num = num2;
						continue;
					}
					return;
				case 8:
					if (portNames.Length == 0)
					{
						num2 = 0;
						num = num2;
						continue;
					}
					goto IL_011e;
				case 4:
				{
					Array.Sort(portNames);
					new List<string>(portNames);
					hl.Items.Clear();
					ComboBox.ObjectCollection items = hl.Items;
					object[] items2 = portNames;
					items.AddRange(items2);
					hl.SelectedIndex = 0;
					hk.Enabled = true;
					num2 = 7;
					num = num2;
					continue;
				}
				case 7:
					return;
				case 0:
					{
						num2 = 0;
						_ = num2;
						return;
					}
					IL_005b:
					num2 = 1;
					num = num2;
					continue;
					IL_011e:
					num2 = 3;
					num = num2;
					continue;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			new SerialPort();
			portNames = SerialPort.GetPortNames();
			short num2 = 5;
			num = num2;
			goto default;
		}
		}
	}

	private void a(object A_0, ProgressChangedEventArgs A_1)
	{
		short num = 0;
		switch (num)
		{
		}
		num = 36;
		int num2 = num;
		SaveFileDialog saveFileDialog = default(SaveFileDialog);
		string text = default(string);
		string text2 = default(string);
		while (true)
		{
			short num3;
			switch (num2)
			{
			case 36:
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
				if (A_1.ProgressPercentage == 100)
				{
					num = 40;
					num2 = num;
				}
				else
				{
					num = 14;
					num2 = num;
				}
				continue;
			case 20:
				File.Delete(saveFileDialog.FileName);
				num = 12;
				num2 = num;
				continue;
			case 18:
				if (!this.m_ah)
				{
					break;
				}
				goto IL_01d7;
			case 4:
			case 8:
			case 21:
			case 39:
				this.m_ai = "";
				a("");
				num = 46;
				num2 = num;
				continue;
			case 30:
				num = 43;
				num2 = num;
				continue;
			case 43:
				if (this.m_ag)
				{
					num = 2;
					num2 = num;
					continue;
				}
				goto IL_01b4;
			case 32:
				num = 23;
				num2 = num;
				continue;
			case 23:
				if (File.Exists(saveFileDialog.FileName))
				{
					num = 20;
					num2 = num;
					continue;
				}
				goto case 12;
			case 35:
				this.m_ar.Clear();
				a("请检查设备连接，或者暂时不支持您的设备，请联系您的设备供应商！\n");
				Text = "运行完毕";
				num = 37;
				num2 = num;
				continue;
			case 6:
				this.m_ar.Clear();
				this.m_ah = false;
				a("读取卡号后直接侦测\n");
				num = 27;
				num2 = num;
				continue;
			case 27:
				if (MessageBox.Show("变色龙设置界面，读取卡号后直接侦测！", "全加密卡", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
				{
					num = 38;
					num2 = num;
					continue;
				}
				break;
			case 38:
				return;
			case 34:
				a("######################################");
				a("######################################");
				a("##       Format card finish.     #####");
				a("######################################");
				a("######################################");
				Text = "运行完毕";
				num = 16;
				num2 = num;
				continue;
			case 1:
				a(text);
				num = 26;
				num2 = num;
				continue;
			case 0:
				num = 47;
				num2 = num;
				continue;
			case 47:
				if (new FileInfo(this.m_ai).Length > 1)
				{
					num = 33;
					num2 = num;
					continue;
				}
				goto IL_09c9;
			case 40:
				_ = (string)A_1.UserState;
				a((string)A_1.UserState);
				a("");
				num = 11;
				num2 = num;
				continue;
			case 11:
				if (this.m_af)
				{
					num = 31;
					num2 = num;
					continue;
				}
				goto case 30;
			case 22:
				return;
			case 2:
				this.m_ar.Clear();
				this.m_ag = false;
				a("请使用PCR532专业版直接解卡");
				num = 15;
				num2 = num;
				continue;
			case 15:
				if (MessageBox.Show("发现无漏洞卡，请使用PCR532专业版直接解卡", "无漏洞卡", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
				{
					num = 22;
					num2 = num;
					continue;
				}
				goto IL_01b4;
			case 14:
				if (A_1.ProgressPercentage == 101)
				{
					num = 5;
					num2 = num;
				}
				else
				{
					num = 41;
					num2 = num;
				}
				continue;
			case 3:
				if (A_1.ProgressPercentage == 107)
				{
					num = 35;
					num2 = num;
				}
				else
				{
					text = (string)A_1.UserState;
					num = 25;
					num2 = num;
				}
				continue;
			case 33:
				Directory.CreateDirectory("nfc-data\\dumpfiles");
				text2 = "nfc-data\\dumpfiles\\" + this.m_aj + "_" + DateTime.Now.ToString().Replace("/", "-").Replace(" ", "_")
					.Replace(":", "-") + ".dump";
				num = 42;
				num2 = num;
				continue;
			case 42:
				if (File.Exists(text2))
				{
					num = 24;
					num2 = num;
					continue;
				}
				goto case 13;
			case 24:
				File.Delete(text2);
				num = 13;
				num2 = num;
				continue;
			case 44:
				num = 45;
				num2 = num;
				continue;
			case 45:
				if (new FileInfo(this.m_ai).Length > 1)
				{
					num = 7;
					num2 = num;
					continue;
				}
				goto IL_0779;
			case 5:
				a((string)A_1.UserState);
				num = 29;
				num2 = num;
				continue;
			case 29:
				if (this.m_aj != "")
				{
					num = 9;
					num2 = num;
					continue;
				}
				break;
			case 9:
				num = 49;
				num2 = num;
				continue;
			case 49:
				if (File.Exists(this.m_ai))
				{
					num = 0;
					num2 = num;
					continue;
				}
				goto IL_09c9;
			case 13:
			{
				File.Copy(this.m_ai, text2);
				this.m_ac = text2;
				a("####################################");
				a("####################################");
				a("#############解卡结束###############");
				a("####文件已保存在：" + text2);
				a("####################################");
				a("####################################");
				a("解卡成功，数据已经加载到A窗口，请及时保存数据，以便后续使用");
				StreamWriter streamWriter = new StreamWriter("auto_keys/history.db", append: true);
				streamWriter.WriteLine(text2);
				streamWriter.Close();
				OpenFile(text2, d9);
				List<IlegendItem> legendItems = new List<IlegendItem>();
				Templating templating = new Templating();
				templating.LoadTemplate(d9, "MIfare-S50-1k-Black.txt", legendItems);
				templating.LoadTemplate(d8, "MIfare-S50-1k-Black.txt", legendItems);
				num = 48;
				num2 = num;
				continue;
			}
			case 7:
				num = 17;
				num2 = num;
				continue;
			case 17:
				if (saveFileDialog.ShowDialog() != DialogResult.OK)
				{
					File.Delete(this.m_ai);
					a("未保存");
					num = 4;
					num2 = num;
				}
				else
				{
					num = 32;
					num2 = num;
				}
				continue;
			case 31:
				this.m_af = false;
				a("你可以用Hardneseted破解来解密此卡，点击Hardneset破解\n");
				num = 10;
				num2 = num;
				continue;
			case 10:
				if (MessageBox.Show("发现国产兼容卡，该卡在此模式下无法解卡\n你可以使用专业版PCR532软件用Hardneset破解来解密此卡\n也可以继续直接读卡，继续侦测\n按确定键可以查看Hardnested破解教程", "Hardnested 教程", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.Cancel)
				{
					Process.Start("http://www.rfidfans.com/thread/19");
					num = 30;
					num2 = num;
				}
				else
				{
					num = 28;
					num2 = num;
				}
				continue;
			case 28:
				return;
			case 19:
				if (!File.Exists(this.m_ai))
				{
					goto IL_0779;
				}
				num = 44;
				num2 = num;
				continue;
			case 48:
				try
				{
					Text = "运行完毕";
				}
				catch (Exception)
				{
				}
				this.m_aj = "";
				num = 39;
				num2 = num;
				continue;
			case 41:
				if (A_1.ProgressPercentage != 105)
				{
					num = 3;
					num2 = num;
				}
				else
				{
					num = 34;
					num2 = num;
				}
				continue;
			case 12:
				File.Move(this.m_ai, saveFileDialog.FileName);
				a("已保存" + saveFileDialog.FileName + "##");
				num = 8;
				num2 = num;
				continue;
			case 25:
				if (text != null)
				{
					num = 1;
					num2 = num;
					continue;
				}
				break;
			case 16:
			case 26:
			case 37:
			case 46:
				break;
				IL_01d7:
				num = 6;
				num2 = num;
				continue;
				IL_09c9:
				saveFileDialog = new SaveFileDialog();
				saveFileDialog.AddExtension = true;
				saveFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "dumpfiles");
				saveFileDialog.Title = "请选择MFD文件保存位置及文件名";
				saveFileDialog.OverwritePrompt = true;
				saveFileDialog.Filter = "*.dump";
				num = 19;
				num2 = num;
				continue;
				IL_0779:
				num = 0;
				_ = num;
				num = -29372;
				num3 = num;
				num = -29372;
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
					File.Delete(this.m_ai);
					a("缓存文件异常");
					num = 21;
					num2 = num;
					continue;
				}
				goto IL_01d7;
				IL_01b4:
				num = 18;
				num2 = num;
				continue;
			}
			break;
		}
		Application.DoEvents();
	}

	private void x(object A_0, EventArgs A_1)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 0;
			int num2 = num;
			string text = default(string);
			string text2 = default(string);
			int num3 = default(int);
			string[] array = default(string[]);
			string text3 = default(string);
			string pattern = default(string);
			while (true)
			{
				switch (num2)
				{
				case 0:
					switch (0)
					{
					default:
						goto end_IL_003f;
					case 0:
						break;
					}
					goto default;
				default:
					if (this.m_aa)
					{
						num = -29595;
						short num4 = num;
						num = -29595;
						switch (num4 == num)
						{
						default:
							num = 0;
							_ = num;
							num = 0;
							if (num != 0)
							{
							}
							num = 12;
							num2 = num;
							goto end_IL_003f;
						case false:
						case true:
							break;
						}
						goto case 5;
					}
					this.m_ar.Clear();
					Text = "PCR532变色龙GP运行中";
					text = "./nfc-data/tmp/Mfoc.tmp";
					text2 = "";
					num = 11;
					num2 = num;
					break;
				case 1:
				case 7:
					num = 6;
					num2 = num;
					break;
				case 6:
					if (num3 >= array.Length)
					{
						num = 1;
						if (num != 0)
						{
						}
						num = 4;
						num2 = num;
					}
					else
					{
						text3 = array[num3];
						pattern = "[0-9A-Fa-f]{12}";
						num = 9;
						num2 = num;
					}
					break;
				case 10:
					text2 = text2 + "-k " + text3.Substring(0, 12) + " ";
					num = 5;
					num2 = num;
					break;
				case 11:
					if (File.Exists("./auto_keys/h.dic"))
					{
						num = 2;
						num2 = num;
					}
					else
					{
						File.Create("auto_keys/h.dic").Dispose();
						num = 3;
						num2 = num;
					}
					break;
				case 4:
					num = 8;
					num2 = num;
					break;
				case 12:
					MessageBox.Show("有任务运行中_不可执行", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				case 5:
					num3++;
					num = 7;
					num2 = num;
					break;
				case 9:
					if (Regex.IsMatch(text3, pattern))
					{
						num = 10;
						num2 = num;
						break;
					}
					goto case 5;
				case 2:
					array = File.ReadAllLines("./auto_keys/h.dic");
					num3 = 0;
					num = 1;
					num2 = num;
					break;
				case 3:
				case 8:
					{
						BackgroundWorker backgroundWorker = new BackgroundWorker();
						backgroundWorker.DoWork += f;
						backgroundWorker.WorkerReportsProgress = true;
						backgroundWorker.ProgressChanged += a;
						backgroundWorker.RunWorkerAsync(new string[2] { text, text2 });
						this.m_ai = text;
						return;
					}
					end_IL_003f:
					break;
				}
			}
		}
		}
	}

	private void f(object A_0, DoWorkEventArgs A_1)
	{
		int num = default(int);
		string[] array = default(string[]);
		h h = default(h);
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 3:
				{
					short num2;
					if (this.m_aa)
					{
						num2 = 1;
						if (num2 != 0)
						{
						}
						num2 = 2;
						num = num2;
						continue;
					}
					this.m_af = false;
					this.m_ag = false;
					this.m_ah = false;
					ProcessStartInfo processStartInfo = new ProcessStartInfo("nfc-bin/mfoc.exe");
					processStartInfo.Arguments = array[1] + " -O \"" + array[0] + "\" -x 3 \"";
					processStartInfo.CreateNoWindow = true;
					processStartInfo.UseShellExecute = false;
					processStartInfo.RedirectStandardOutput = true;
					processStartInfo.RedirectStandardError = true;
					this.m_aa = true;
					this.m_z = Process.Start(processStartInfo);
					h.a.ReportProgress(0, "************MFOC START***********");
					this.m_ab = true;
					h.c = "auto_keys/h.dic";
					this.m_z.OutputDataReceived += h.d;
					this.m_z.ErrorDataReceived += h.e;
					this.m_z.BeginOutputReadLine();
					this.m_z.BeginErrorReadLine();
					this.m_z.WaitForExit();
					this.m_aa = false;
					this.m_ab = false;
					num2 = 1;
					num = num2;
					continue;
				}
				case 2:
					return;
				case 0:
					h.a.ReportProgress(101, "运行完毕");
					return;
				case 1:
				{
					short num2 = 0;
					_ = num2;
					if (this.m_z.ExitCode == 0)
					{
						num2 = 0;
						num = num2;
						continue;
					}
					num2 = -13739;
					short num3 = num2;
					num2 = -13739;
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
						h.a.ReportProgress(100, "运行出错");
						File.Delete(array[0]);
						return;
					}
					break;
				}
				}
				break;
			}
			goto case 0;
		case 0:
		{
			h = new h();
			h.b = this;
			array = (string[])A_1.Argument;
			h.a = (BackgroundWorker)A_0;
			short num2 = 3;
			num = num2;
			goto default;
		}
		}
	}

	private void w(object A_0, EventArgs A_1)
	{
		short num = 1501;
		short num2 = num;
		num = 1501;
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
		string arguments = "auto_keys/h.dic";
		Process.Start("NOTEPAD.exe", arguments);
	}

	private void v(object A_0, EventArgs A_1)
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
				if (this.m_k)
				{
					num = 0;
					num2 = num;
					continue;
				}
				goto case 1;
			case 0:
				break;
			case 1:
			{
				num = 25826;
				short num3 = num;
				num = 25826;
				switch (num3 == num)
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
					x(A_0, A_1);
					return;
				}
				break;
			}
			}
			o("SETTING" + this.m_i + "=9");
			c();
			num = 1;
			num2 = num;
		}
	}

	private void u(object A_0, EventArgs A_1)
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
					goto end_IL_001f;
				case 0:
					break;
				}
				goto default;
			default:
				num = 1;
				if (num != 0)
				{
				}
				num = 0;
				_ = num;
				if (this.m_aa)
				{
					num = 1;
					num2 = num;
				}
				else
				{
					num = 4;
					num2 = num;
				}
				break;
			case 5:
				if (File.Exists("auto_keys/h.dic"))
				{
					num = 2;
					num2 = num;
					break;
				}
				goto case 3;
			case 0:
				return;
			case 1:
				MessageBox.Show("有任务运行中_不可执行", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			case 2:
				File.Delete("auto_keys/h.dic");
				a("历史密钥删除成功\n");
				File.Create("auto_keys/h.dic").Dispose();
				num = 3;
				num2 = num;
				break;
			case 4:
				if (MessageBox.Show("将删除历史密钥，谨慎操作！", "危险操作警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.Cancel)
				{
					num = 5;
					num2 = num;
				}
				else
				{
					num = 0;
					num2 = num;
				}
				break;
			case 3:
				{
					num = -19520;
					short num3 = num;
					num = -19520;
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
					goto default;
				}
				end_IL_001f:
				break;
			}
		}
	}

	private void t(object A_0, EventArgs A_1)
	{
		short num = -27316;
		short num2 = num;
		num = -27316;
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
		Process.Start("http://120.24.245.232/app/pcr532.apk");
	}

	private void s(object A_0, EventArgs A_1)
	{
		short num = 10;
		int num2 = num;
		string text = default(string);
		OpenFileDialog openFileDialog = default(OpenFileDialog);
		while (true)
		{
			switch (num2)
			{
			case 10:
				switch (0)
				{
				default:
					goto end_IL_0020;
				case 0:
					break;
				}
				goto default;
			default:
				if (this.m_aa)
				{
					num = 4;
					num2 = num;
					break;
				}
				Text = "PCR532变色龙GP运行中";
				text = "";
				num = 5;
				num2 = num;
				break;
			case 4:
				num = 0;
				_ = num;
				MessageBox.Show("有任务运行中_不可执行", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			case 9:
				openFileDialog = new OpenFileDialog();
				openFileDialog.CheckFileExists = true;
				openFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "dumpfiles");
				openFileDialog.Filter = "MFD文件|*.mfd;*.dump;*.bin;*";
				openFileDialog.Title = "请选择需要写入的dump文件";
				openFileDialog.Multiselect = false;
				num = 3;
				num2 = num;
				break;
			case 3:
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					num = 2;
					num2 = num;
					break;
				}
				return;
			case 8:
			{
				num = -22549;
				short num3 = num;
				num = -22549;
				switch (num3 == num)
				{
				default:
					num = 0;
					if (num != 0)
					{
					}
					o("SETTING" + this.m_i + "=9");
					c();
					num = 9;
					num2 = num;
					goto end_IL_0020;
				case false:
				case true:
					break;
				}
				goto case 6;
			}
			case 5:
				if (File.Exists(this.m_ap))
				{
					num = 6;
					num2 = num;
					break;
				}
				goto case 0;
			case 2:
			{
				File.Copy(openFileDialog.FileName, this.m_ap);
				text = this.m_ap;
				OpenFile(this.m_ap, d8);
				List<IlegendItem> legendItems = new List<IlegendItem>();
				Templating templating = new Templating();
				templating.LoadTemplate(d9, "MIfare-S50-1k-Black.txt", legendItems);
				templating.LoadTemplate(d8, "MIfare-S50-1k-Black.txt", legendItems);
				num = 1;
				num2 = num;
				break;
			}
			case 0:
				num = 7;
				num2 = num;
				break;
			case 7:
				num = 1;
				if (num != 0)
				{
				}
				if (this.m_k)
				{
					num = 8;
					num2 = num;
					break;
				}
				goto case 9;
			case 6:
				File.Delete(this.m_ap);
				num = 0;
				num2 = num;
				break;
			case 1:
				{
					BackgroundWorker backgroundWorker = new BackgroundWorker();
					backgroundWorker.DoWork += e;
					backgroundWorker.WorkerReportsProgress = true;
					backgroundWorker.ProgressChanged += a;
					backgroundWorker.RunWorkerAsync(new string[1] { text });
					return;
				}
				end_IL_0020:
				break;
			}
		}
	}

	private void e(object A_0, DoWorkEventArgs A_1)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			i i = default(i);
			string text = default(string);
			string text3 = default(string);
			string[] array = default(string[]);
			switch (0)
			{
			default:
			{
				int num4 = default(int);
				string[] array2 = default(string[]);
				string text2 = default(string);
				string pattern = default(string);
				while (true)
				{
					switch (num2)
					{
					case 10:
						num = 0;
						_ = num;
						if (File.Exists("./auto_keys/h.dic"))
						{
							num = 1;
							if (num != 0)
							{
							}
							num = 4;
							num2 = num;
							continue;
						}
						goto case 2;
					case 1:
					case 9:
						num = 3;
						num2 = num;
						continue;
					case 3:
						if (num4 >= array2.Length)
						{
							num = 2;
							num2 = num;
							continue;
						}
						text2 = array2[num4];
						pattern = "[0-9A-Fa-f]{12}";
						num = 5;
						num2 = num;
						continue;
					case 0:
						num4++;
						num = 9;
						num2 = num;
						continue;
					case 5:
						if (Regex.IsMatch(text2, pattern))
						{
							num = 6;
							num2 = num;
							continue;
						}
						goto case 0;
					case 8:
						i.a.ReportProgress(106, "运行完毕");
						MessageBox.Show("写卡完成", "写卡结束", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					case 4:
						array2 = File.ReadAllLines("./auto_keys/h.dic");
						num4 = 0;
						num = 1;
						num2 = num;
						continue;
					case 2:
					{
						i.a = (BackgroundWorker)A_0;
						ProcessStartInfo processStartInfo = new ProcessStartInfo("nfc-bin/mfoc.exe");
						processStartInfo.Arguments = text + " -O \"" + text3 + "\" -x 3 -Z 1 -W " + array[0] + "\"";
						processStartInfo.CreateNoWindow = true;
						processStartInfo.UseShellExecute = false;
						processStartInfo.RedirectStandardOutput = true;
						processStartInfo.RedirectStandardError = true;
						this.m_aa = true;
						this.m_z = Process.Start(processStartInfo);
						i.a.ReportProgress(0, "*****************一键写卡*****************");
						this.m_ab = true;
						this.m_z.OutputDataReceived += i.c;
						this.m_z.ErrorDataReceived += i.d;
						this.m_z.BeginOutputReadLine();
						this.m_z.BeginErrorReadLine();
						this.m_z.WaitForExit();
						this.m_aa = false;
						this.m_ab = false;
						num = 7;
						num2 = num;
						continue;
					}
					case 7:
						if (this.m_z.ExitCode == 0)
						{
							num = 8;
							num2 = num;
							continue;
						}
						i.a.ReportProgress(100, "运行出错");
						a("运行出错");
						File.Delete(text3);
						return;
					case 6:
					{
						num = 27515;
						short num3 = num;
						num = 27515;
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
							text = text + "-k " + text2.Substring(0, 12) + " ";
							num = 0;
							num2 = num;
							continue;
						}
						goto case 0;
					}
					}
					break;
				}
				goto case 0;
			}
			case 0:
				i = new i();
				i.b = this;
				array = (string[])A_1.Argument;
				text3 = "nfc-data/tmp/tmp.dump";
				text = "";
				num = 10;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private void r(object A_0, EventArgs A_1)
	{
		short num = -9;
		short num2 = num;
		num = -9;
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
		this.m_ar.Clear();
	}

	private void q(object A_0, EventArgs A_1)
	{
		short num = -5974;
		short num2 = num;
		num = -5974;
		switch (num2 == num)
		{
		default:
		{
			num = 0;
			if (num != 0)
			{
			}
			num = 3;
			int num3 = num;
			while (true)
			{
				switch (num3)
				{
				case 3:
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
					if (this.m_w != global::b.c)
					{
						num = 2;
						num3 = num;
						continue;
					}
					num = 0;
					_ = num;
					n("PCRDETECTION" + this.m_i + "=0");
					num = 1;
					num3 = num;
					continue;
				case 2:
					n("DETECTION" + this.m_i + "=0");
					num = 0;
					num3 = num;
					continue;
				case 0:
				case 1:
					break;
				}
				break;
			}
			break;
		}
		case false:
		case true:
			break;
		}
		a("清除侦测记录完成" + Environment.NewLine);
		a("Clear all detection Record" + Environment.NewLine);
	}

	private void p(object A_0, EventArgs A_1)
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = 0;
		switch (num)
		{
		}
		num = 1;
		int num2 = num;
		string text2 = default(string);
		string text3 = default(string);
		string[] array = default(string[]);
		int num3 = default(int);
		string pattern = default(string);
		string text = default(string);
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
				if (this.m_aa)
				{
					num = 13;
					num2 = num;
				}
				else
				{
					this.m_ar.Clear();
					num = 6;
					num2 = num;
				}
				continue;
			case 9:
			{
				num = -9257;
				short num4 = num;
				num = -9257;
				switch (num4 == num)
				{
				default:
					num = 0;
					if (num != 0)
					{
					}
					text2 = text2 + "-k " + text3.Substring(0, 12) + " ";
					num = 7;
					num2 = num;
					continue;
				case false:
				case true:
					break;
				}
				break;
			}
			case 11:
				array = File.ReadAllLines("./auto_keys/h.dic");
				num3 = 0;
				num = 3;
				num2 = num;
				continue;
			case 6:
				if (this.m_k)
				{
					num = 10;
					num2 = num;
					continue;
				}
				goto case 0;
			case 7:
				num3++;
				num = 12;
				num2 = num;
				continue;
			case 13:
				MessageBox.Show("有任务运行中_不可执行", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			case 2:
				if (Regex.IsMatch(text3, pattern))
				{
					num = 9;
					num2 = num;
					continue;
				}
				goto case 7;
			case 3:
			case 12:
				num = 8;
				num2 = num;
				continue;
			case 8:
				if (num3 < array.Length)
				{
					text3 = array[num3];
					pattern = "[0-9A-Fa-f]{12}";
					num = 2;
					num2 = num;
				}
				else
				{
					num = 4;
					num2 = num;
				}
				continue;
			case 0:
				Text = "PCR532变色龙GP运行中";
				text = "nfc-bin/blank.db";
				text2 = "";
				num = 5;
				num2 = num;
				continue;
			case 5:
				if (File.Exists("./auto_keys/h.dic"))
				{
					num = 11;
					num2 = num;
					continue;
				}
				break;
			case 10:
				o("SETTING" + this.m_i + "=9");
				c();
				num = 0;
				num2 = num;
				continue;
			case 4:
				break;
			}
			break;
		}
		num = 0;
		_ = num;
		BackgroundWorker backgroundWorker = new BackgroundWorker();
		backgroundWorker.DoWork += d;
		backgroundWorker.WorkerReportsProgress = true;
		backgroundWorker.ProgressChanged += a;
		backgroundWorker.RunWorkerAsync(new string[2] { text, text2 });
	}

	private void d(object A_0, DoWorkEventArgs A_1)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			j j = default(j);
			string text = default(string);
			string text3 = default(string);
			switch (0)
			{
			default:
			{
				int num3 = default(int);
				string[] array = default(string[]);
				string text2 = default(string);
				string pattern = default(string);
				while (true)
				{
					switch (num2)
					{
					case 8:
						if (File.Exists("./auto_keys/h.dic"))
						{
							num = 2;
							num2 = num;
							continue;
						}
						goto case 1;
					case 4:
					case 6:
						num = 0;
						num2 = num;
						continue;
					case 0:
						if (num3 >= array.Length)
						{
							num = -28479;
							short num4 = num;
							num = -28479;
							switch (num4 == num)
							{
							case false:
							case true:
								break;
							default:
								num = 0;
								if (num != 0)
								{
								}
								num = 1;
								num2 = num;
								continue;
							}
							goto case 4;
						}
						text2 = array[num3];
						pattern = "[0-9A-Fa-f]{12}";
						num = 7;
						num2 = num;
						continue;
					case 10:
						num3++;
						num = 6;
						num2 = num;
						continue;
					case 7:
						if (Regex.IsMatch(text2, pattern))
						{
							num = 3;
							num2 = num;
							continue;
						}
						goto case 10;
					case 5:
						num = 1;
						if (num != 0)
						{
						}
						j.a.ReportProgress(105, "格式化结束");
						MessageBox.Show("格式化完成", "格式结束", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					case 2:
						array = File.ReadAllLines("./auto_keys/h.dic");
						num3 = 0;
						num = 4;
						num2 = num;
						continue;
					case 1:
					{
						text += " -W nfc-bin/blank.db ";
						j.a = (BackgroundWorker)A_0;
						ProcessStartInfo processStartInfo = new ProcessStartInfo("nfc-bin/mfoc.exe");
						processStartInfo.Arguments = text + " -O \"" + text3 + "\" -x 3 \"";
						processStartInfo.CreateNoWindow = true;
						processStartInfo.UseShellExecute = false;
						processStartInfo.RedirectStandardOutput = true;
						processStartInfo.RedirectStandardError = true;
						this.m_aa = true;
						this.m_z = Process.Start(processStartInfo);
						j.a.ReportProgress(0, "*****************格式化*****************");
						this.m_ab = true;
						this.m_z.OutputDataReceived += j.c;
						this.m_z.ErrorDataReceived += j.d;
						this.m_z.BeginOutputReadLine();
						this.m_z.BeginErrorReadLine();
						this.m_z.WaitForExit();
						this.m_aa = false;
						this.m_ab = false;
						num = 9;
						num2 = num;
						continue;
					}
					case 9:
						if (this.m_z.ExitCode == 0)
						{
							num = 5;
							num2 = num;
							continue;
						}
						j.a.ReportProgress(100, "运行出错");
						a("运行出错");
						File.Delete(text3);
						return;
					case 3:
						text = text + "-k " + text2.Substring(0, 12) + " ";
						num = 10;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				j = new j();
				j.b = this;
				_ = (string[])A_1.Argument;
				text3 = "nfc-data/tmp/tmp.dump";
				text = "";
				num = 0;
				_ = num;
				num = 8;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private void c(object A_0, DoWorkEventArgs A_1)
	{
		while (this.m_aa)
		{
			short num = 0;
			_ = num;
			num = 3195;
			short num2 = num;
			num = 3195;
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
			num = 1;
			if (num == 0)
			{
			}
			return;
		}
		ProcessStartInfo processStartInfo = new ProcessStartInfo("nfc-bin/mfoc.exe");
		processStartInfo.Arguments = " -O nfc-data/tmp/tmp.dump -x 3 -U \"";
		processStartInfo.CreateNoWindow = true;
		processStartInfo.UseShellExecute = false;
		processStartInfo.RedirectStandardOutput = true;
		processStartInfo.RedirectStandardError = true;
		this.m_aa = true;
		BackgroundWorker a = (BackgroundWorker)A_0;
		this.m_z = Process.Start(processStartInfo);
		a.ReportProgress(0, "**********开始执行UFUID卡片锁定**********");
		this.m_ab = true;
		this.m_z.OutputDataReceived += delegate(object obj, DataReceivedEventArgs e)
		{
			int num3 = default(int);
			switch (0)
			{
			default:
			{
				string pattern2 = default(string);
				string pattern = default(string);
				while (true)
				{
					switch (num3)
					{
					case 1:
					{
						short num4 = 32000;
						short num5 = num4;
						num4 = 32000;
						switch (num5 == num4)
						{
						default:
							num4 = 0;
							if (num4 != 0)
							{
							}
							if (string.IsNullOrEmpty(e.Data))
							{
								return;
							}
							num4 = 4;
							num3 = num4;
							break;
						case false:
						case true:
							return;
						}
						continue;
					}
					case 10:
					{
						short num4 = 6;
						num3 = num4;
						continue;
					}
					case 6:
						if (Regex.IsMatch(e.Data, this.m_ad))
						{
							short num4 = 2;
							num3 = num4;
							continue;
						}
						return;
					case 3:
					{
						pattern2 = "No\\sNFC\\sdevice\\sfound";
						short num4 = 9;
						num3 = num4;
						continue;
					}
					case 9:
						if (Regex.IsMatch(e.Data, pattern2))
						{
							short num4 = 5;
							num3 = num4;
							continue;
						}
						goto case 10;
					case 4:
					{
						pattern = "UID\\s\\(NFCID1\\)\\: ([0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2}\\s\\s[0-9A-Fa-f]{2})";
						short num4 = 7;
						num3 = num4;
						continue;
					}
					case 7:
						if (Regex.IsMatch(e.Data, pattern))
						{
							short num4 = 8;
							num3 = num4;
							continue;
						}
						goto case 3;
					case 8:
					{
						short num4 = 1;
						if (num4 != 0)
						{
						}
						this.m_aj = Regex.Match(e.Data, pattern).Captures[0].Value.Replace(" ", "").Replace("UID(NFCID1):", "");
						num4 = 0;
						_ = num4;
						num4 = 3;
						num3 = num4;
						continue;
					}
					case 2:
					{
						a.ReportProgress(107, "运行出错");
						short num4 = 0;
						num3 = num4;
						continue;
					}
					case 0:
						return;
					case 5:
					{
						a.ReportProgress(107, "运行出错");
						short num4 = 10;
						num3 = num4;
						continue;
					}
					}
					break;
				}
				goto case 0;
			}
			case 0:
			{
				a.ReportProgress(0, e.Data);
				short num4 = 1;
				num3 = num4;
				goto default;
			}
			}
		};
		this.m_z.ErrorDataReceived += delegate(object obj, DataReceivedEventArgs e)
		{
			int num3 = default(int);
			switch (0)
			{
			default:
			{
				string pattern = default(string);
				while (true)
				{
					switch (num3)
					{
					case 0:
					{
						if (string.IsNullOrEmpty(e.Data))
						{
							return;
						}
						short num4 = 29953;
						short num5 = num4;
						num4 = 29953;
						switch (num5 == num4)
						{
						default:
							num4 = 0;
							if (num4 != 0)
							{
							}
							num4 = 2;
							num3 = num4;
							continue;
						case false:
						case true:
							break;
						}
						goto case 2;
					}
					case 5:
						if (Regex.IsMatch(e.Data, this.m_ad))
						{
							short num4 = 3;
							num3 = num4;
							continue;
						}
						return;
					case 1:
					{
						short num4 = 1;
						if (num4 != 0)
						{
						}
						a.ReportProgress(107, "运行出错");
						return;
					}
					case 2:
					{
						pattern = "No\\sNFC\\sdevice\\sfound";
						short num4 = 0;
						_ = num4;
						num4 = 4;
						num3 = num4;
						continue;
					}
					case 4:
						if (!Regex.IsMatch(e.Data, pattern))
						{
							short num4 = 5;
							num3 = num4;
						}
						else
						{
							short num4 = 1;
							num3 = num4;
						}
						continue;
					case 3:
					{
						a.ReportProgress(107, "运行出错");
						short num4 = 6;
						num3 = num4;
						continue;
					}
					case 6:
						return;
					}
					break;
				}
				goto case 0;
			}
			case 0:
			{
				a.ReportProgress(0, e.Data);
				short num4 = 0;
				num3 = num4;
				goto default;
			}
			}
		};
		this.m_z.BeginOutputReadLine();
		this.m_z.BeginErrorReadLine();
		this.m_z.WaitForExit();
		this.m_aa = false;
		this.m_ab = false;
		a.ReportProgress(100, "运行完毕");
	}

	private void o(object A_0, EventArgs A_1)
	{
		short num = 4;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 4:
				switch (0)
				{
				default:
					goto end_IL_001f;
				case 0:
					break;
				}
				goto default;
			default:
				num = 1;
				if (num != 0)
				{
				}
				if (this.m_aa)
				{
					num = -23818;
					short num3 = num;
					num = -23818;
					switch (num3 == num)
					{
					default:
						num = 0;
						if (num != 0)
						{
						}
						num = 2;
						num2 = num;
						goto end_IL_001f;
					case false:
					case true:
						break;
					}
					goto IL_01ac;
				}
				this.m_ar.Clear();
				num = 5;
				num2 = num;
				break;
			case 1:
				num = 3;
				num2 = num;
				break;
			case 3:
			{
				if (MessageBox.Show("该操作将会锁死UFUID卡片_锁死后不可恢复_无法再次更改", "危险操作警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
				{
					num = 0;
					num2 = num;
					break;
				}
				Text = "PCR532变色龙GP运行中";
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.DoWork += c;
				backgroundWorker.WorkerReportsProgress = true;
				backgroundWorker.ProgressChanged += a;
				backgroundWorker.RunWorkerAsync();
				return;
			}
			case 2:
				MessageBox.Show("有任务运行中_不可执行", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			case 0:
				Text = "已取消";
				return;
			case 5:
				if (!this.m_k)
				{
					goto case 1;
				}
				goto IL_01ac;
			case 6:
				{
					num = 0;
					_ = num;
					o("SETTING" + this.m_i + "=9");
					c();
					num = 1;
					num2 = num;
					break;
				}
				IL_01ac:
				num = 6;
				num2 = num;
				break;
				end_IL_001f:
				break;
			}
		}
	}

	private void n(object A_0, EventArgs A_1)
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
					goto end_IL_001f;
				case 0:
					break;
				}
				goto default;
			default:
				if (this.m_aa)
				{
					num = 1;
					num2 = num;
					break;
				}
				this.m_ar.Clear();
				num = 0;
				_ = num;
				num = 3;
				num2 = num;
				break;
			case 4:
			{
				string obj = m("abcdefgh" + this.m_i + "?").ToString();
				string text = obj.Substring(obj.Length - 16, 16);
				int.Parse(text, NumberStyles.HexNumber);
				m("ijklmno" + this.m_i + "=" + text).ToString();
				num = 0;
				num2 = num;
				break;
			}
			case 0:
			{
				num = -30581;
				short num3 = num;
				num = -30581;
				switch (num3 == num)
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
					if (num == 0)
					{
					}
					return;
				}
				goto case 4;
			}
			case 3:
				if (this.m_k)
				{
					num = 4;
					num2 = num;
					break;
				}
				return;
			case 1:
				{
					MessageBox.Show("有任务运行中_不可执行", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				end_IL_001f:
				break;
			}
		}
	}

	private void b(object A_0, DoWorkEventArgs A_1)
	{
		int num = default(int);
		l l = default(l);
		short num2;
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 1:
					goto IL_00bb;
				case 0:
					return;
				case 3:
					l.a.ReportProgress(100, "#########Read card id sucessful ,current card is：" + this.m_aj + "#########");
					l.a.ReportProgress(100, "#########读取卡号成功，当前的卡号为：" + this.m_aj + "      ##########");
					l.a.ReportProgress(100, "你可以复制该卡号到侦测卡位进行侦测");
					return;
				case 2:
					goto IL_023a;
				}
				break;
				IL_00bb:
				if (this.m_aa)
				{
					num2 = 0;
					num = num2;
					continue;
				}
				ProcessStartInfo processStartInfo = new ProcessStartInfo("nfc-bin/mfoc.exe");
				processStartInfo.Arguments = " -O nfc-data/tmp/tmp.dump -x 3 -e \"";
				processStartInfo.CreateNoWindow = true;
				processStartInfo.UseShellExecute = false;
				processStartInfo.RedirectStandardOutput = true;
				processStartInfo.RedirectStandardError = true;
				this.m_aa = true;
				l.a = (BackgroundWorker)A_0;
				this.m_z = Process.Start(processStartInfo);
				l.a.ReportProgress(0, "************开始执行读取卡号************");
				this.m_ab = true;
				this.m_z.OutputDataReceived += l.c;
				this.m_z.ErrorDataReceived += l.d;
				this.m_z.BeginOutputReadLine();
				this.m_z.BeginErrorReadLine();
				this.m_z.WaitForExit();
				this.m_aa = false;
				this.m_ab = false;
				num2 = 1;
				if (num2 != 0)
				{
				}
				num2 = 2;
				num = num2;
			}
			goto case 0;
		case 0:
			{
				l = new l();
				l.b = this;
				num2 = 0;
				_ = num2;
				num2 = 14622;
				short num3 = num2;
				num2 = 14622;
				switch (num3 == num2)
				{
				case false:
				case true:
					goto IL_0247;
				}
				num2 = 0;
				if (num2 != 0)
				{
				}
				num2 = 1;
				num = num2;
				goto default;
			}
			IL_023a:
			if (this.m_z.ExitCode != 0)
			{
				l.a.ReportProgress(100, "\n#########读取卡号失败#########");
				break;
			}
			goto IL_0247;
			IL_0247:
			num2 = 3;
			num = num2;
			goto default;
		}
	}

	private void m(object A_0, EventArgs A_1)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 13;
			int num2 = num;
			int num3 = default(int);
			string text3 = default(string);
			string pattern = default(string);
			string[] array = default(string[]);
			string text2 = default(string);
			string text = default(string);
			while (true)
			{
				switch (num2)
				{
				case 13:
					switch (0)
					{
					default:
						goto end_IL_003f;
					case 0:
						break;
					}
					goto default;
				default:
					if (this.m_aa)
					{
						num = 8;
						num2 = num;
					}
					else
					{
						this.m_ar.Clear();
						num = 5;
						num2 = num;
					}
					break;
				case 14:
					num3++;
					num = 4;
					num2 = num;
					break;
				case 6:
					if (Regex.IsMatch(text3, pattern))
					{
						num = 7;
						num2 = num;
						break;
					}
					goto case 14;
				case 5:
					if (this.m_k)
					{
						num = 1;
						num2 = num;
						break;
					}
					goto case 2;
				case 12:
					num = 11;
					num2 = num;
					break;
				case 8:
					MessageBox.Show("有任务运行中_不可执行", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				case 3:
				case 4:
					num = 0;
					num2 = num;
					break;
				case 0:
					if (num3 < array.Length)
					{
						num = 17072;
						short num4 = num;
						num = 17072;
						switch (num4 == num)
						{
						default:
							num = 0;
							if (num != 0)
							{
							}
							text3 = array[num3];
							pattern = "[0-9A-Fa-f]{12}";
							num = 6;
							num2 = num;
							goto end_IL_003f;
						case false:
						case true:
							break;
						}
						goto case 7;
					}
					num = 0;
					_ = num;
					num = 12;
					num2 = num;
					break;
				case 10:
					array = File.ReadAllLines("./auto_keys/h.dic");
					num3 = 0;
					num = 1;
					if (num != 0)
					{
					}
					num = 3;
					num2 = num;
					break;
				case 1:
					o("SETTING" + this.m_i + "=9");
					c();
					num = 2;
					num2 = num;
					break;
				case 7:
					text2 = text2 + "-k " + text3.Substring(0, 12) + " ";
					num = 14;
					num2 = num;
					break;
				case 2:
					a("直接读卡：直接忽视加密的扇区，只读取已知密钥区域，未知区域用空白来替代！");
					text = "./nfc-data/tmp/Mfoc.tmp";
					text2 = "";
					num = 15;
					num2 = num;
					break;
				case 15:
					if (!File.Exists("./auto_keys/h.dic"))
					{
						File.Create("auto_keys/h.dic").Dispose();
						num = 9;
						num2 = num;
					}
					else
					{
						num = 10;
						num2 = num;
					}
					break;
				case 9:
				case 11:
					{
						BackgroundWorker backgroundWorker = new BackgroundWorker();
						backgroundWorker.DoWork += a;
						backgroundWorker.WorkerReportsProgress = true;
						backgroundWorker.ProgressChanged += a;
						backgroundWorker.RunWorkerAsync(new string[2] { text, text2 });
						this.m_ai = text;
						return;
					}
					end_IL_003f:
					break;
				}
			}
		}
		}
	}

	private void a(object A_0, DoWorkEventArgs A_1)
	{
		int num = default(int);
		m m = default(m);
		string[] array = default(string[]);
		short num2;
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 1:
					goto IL_00d2;
				case 0:
					return;
				case 3:
					m.a.ReportProgress(101, "运行完毕");
					MessageBox.Show("如果还存在加密区域或者模拟卡无效，请点击上传数据文件后继续侦测其他密钥", "读卡结束", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				case 2:
					goto IL_0213;
				}
				break;
				IL_00d2:
				if (this.m_aa)
				{
					num2 = 0;
					num = num2;
					continue;
				}
				this.m_af = false;
				this.m_ag = false;
				this.m_ah = false;
				ProcessStartInfo processStartInfo = new ProcessStartInfo("nfc-bin/mfoc.exe");
				processStartInfo.Arguments = array[1] + " -O \"" + array[0] + "\" -x 3 -j 1 \"";
				processStartInfo.CreateNoWindow = true;
				processStartInfo.UseShellExecute = false;
				processStartInfo.RedirectStandardOutput = true;
				processStartInfo.RedirectStandardError = true;
				this.m_aa = true;
				this.m_z = Process.Start(processStartInfo);
				m.a.ReportProgress(0, "************MFOC START***********");
				this.m_ab = true;
				this.m_z.OutputDataReceived += m.c;
				this.m_z.ErrorDataReceived += m.d;
				this.m_z.BeginOutputReadLine();
				this.m_z.BeginErrorReadLine();
				this.m_z.WaitForExit();
				this.m_aa = false;
				this.m_ab = false;
				num2 = 2;
				num = num2;
			}
			goto case 0;
		case 0:
			{
				m = new m();
				m.b = this;
				array = (string[])A_1.Argument;
				m.a = (BackgroundWorker)A_0;
				num2 = 0;
				_ = num2;
				num2 = -22165;
				short num3 = num2;
				num2 = -22165;
				switch (num3 == num2)
				{
				case false:
				case true:
					goto IL_0246;
				}
				num2 = 0;
				if (num2 != 0)
				{
				}
				num2 = 1;
				num = num2;
				goto default;
			}
			IL_0213:
			num2 = 1;
			if (num2 != 0)
			{
			}
			if (this.m_z.ExitCode != 0)
			{
				m.a.ReportProgress(100, "运行出错");
				File.Delete(array[0]);
				break;
			}
			goto IL_0246;
			IL_0246:
			num2 = 3;
			num = num2;
			goto default;
		}
	}

	private void l(object A_0, EventArgs A_1)
	{
		short num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				num = 1;
				if (num != 0)
				{
				}
				switch (0)
				{
				default:
					goto end_IL_0048;
				case 0:
					break;
				}
				goto default;
			default:
				if (!this.m_aa)
				{
					return;
				}
				goto IL_006c;
			case 4:
			{
				this.m_z.Kill();
				Text = "已终止";
				a("程序已被强制停止");
				num = 0;
				_ = num;
				num = 21823;
				short num3 = num;
				num = 21823;
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
					goto end_IL_0048;
				}
				goto IL_006c;
			}
			case 0:
				return;
			case 1:
				num = 3;
				num2 = num;
				break;
			case 3:
				{
					if (!this.m_z.HasExited)
					{
						num = 4;
						num2 = num;
						break;
					}
					return;
				}
				IL_006c:
				num = 1;
				num2 = num;
				break;
				end_IL_0048:
				break;
			}
		}
	}

	private void k(object A_0, EventArgs A_1)
	{
		short num = 2219;
		short num2 = num;
		num = 2219;
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
		l(A_0, A_1);
	}

	private void j(object A_0, EventArgs A_1)
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = -3267;
		short num2 = num;
		num = -3267;
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
		string arguments = "auto_keys/h.dic";
		Process.Start("NOTEPAD.exe", arguments);
	}

	private void i(object A_0, EventArgs A_1)
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
					goto end_IL_0020;
				case 0:
					break;
				}
				goto default;
			default:
				if (this.m_y)
				{
					num = 0;
					_ = num;
					num = 0;
					num2 = num;
				}
				else
				{
					num = 2;
					num2 = num;
				}
				break;
			case 0:
				return;
			case 2:
				if (h4.Checked)
				{
					num = 3;
					num2 = num;
					break;
				}
				n("SAKMODE" + this.m_i + "=0");
				a("SAK模式取消成功，该模式为单卡模式");
				return;
			case 3:
				{
					num = 1;
					if (num != 0)
					{
					}
					num = -21460;
					short num3 = num;
					num = -21460;
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
						n("SAKMODE" + this.m_i + "=1");
						a("SAK模式设置成功，该模式为单卡模式");
						return;
					}
					goto default;
				}
				end_IL_0020:
				break;
			}
		}
	}

	private void h(object A_0, EventArgs A_1)
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
					goto end_IL_0020;
				case 0:
					break;
				}
				goto default;
			default:
				if (this.m_y)
				{
					num = 0;
					_ = num;
					num = 0;
					num2 = num;
				}
				else
				{
					num = 2;
					num2 = num;
				}
				break;
			case 0:
				return;
			case 3:
			{
				num = -12367;
				short num3 = num;
				num = -12367;
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
					num = 1;
					if (num != 0)
					{
					}
					n("UIDMODE" + this.m_i + "=1");
					a("UID模式设置成功，该模式为全局模式");
					return;
				}
				goto default;
			}
			case 2:
				{
					if (h3.Checked)
					{
						num = 3;
						num2 = num;
						break;
					}
					n("UIDMODE" + this.m_i + "=0");
					a("UID模式取消成功，该模式为全局模式");
					return;
				}
				end_IL_0020:
				break;
			}
		}
	}

	private void g(object A_0, EventArgs A_1)
	{
		short num = 0;
		int num2 = num;
		while (true)
		{
			num = 1;
			if (num != 0)
			{
			}
			num = -29826;
			short num3 = num;
			num = -29826;
			switch (num3 == num)
			{
			case false:
			case true:
				switch (0)
				{
				default:
					continue;
				case 0:
					break;
				}
				goto IL_00b8;
			default:
				{
					num = 0;
					if (num != 0)
					{
					}
					switch (num2)
					{
					case 0:
						break;
					default:
						goto IL_00b8;
					case 1:
						goto IL_00ec;
					case 2:
						goto end_IL_006a;
					}
					goto case false;
				}
				IL_00b8:
				num = 0;
				_ = num;
				if (this.m_k)
				{
					num = 1;
					num2 = num;
					continue;
				}
				break;
				IL_00ec:
				o("SETTING" + this.m_i + "=9");
				c();
				num = 2;
				num2 = num;
				continue;
				end_IL_006a:
				break;
			}
			break;
		}
		dk.SelectedTab = d7;
	}

	private void f(object A_0, EventArgs A_1)
	{
		int num = default(int);
		string[] portNames = default(string[]);
		switch (0)
		{
		default:
			while (true)
			{
				short num2;
				switch (num)
				{
				case 6:
					if (portNames == null)
					{
						goto IL_0057;
					}
					goto IL_00a7;
				case 2:
					num2 = 1;
					num = num2;
					continue;
				case 1:
					if (portNames.Length != 0)
					{
						num2 = 4;
						num = num2;
						continue;
					}
					return;
				case 5:
					num2 = 1;
					if (num2 != 0)
					{
					}
					if (portNames != null)
					{
						num2 = 2;
						num = num2;
						continue;
					}
					return;
				case 0:
					num2 = 3;
					num = num2;
					continue;
				case 3:
				{
					num2 = 9232;
					short num3 = num2;
					num2 = 9232;
					switch (num3 == num2)
					{
					case false:
					case true:
						break;
					default:
						goto IL_0169;
					}
					goto IL_0057;
				}
				case 7:
					return;
				case 4:
				{
					Array.Sort(portNames);
					new List<string>(portNames);
					h6.Items.Clear();
					ComboBox.ObjectCollection items = h6.Items;
					object[] items2 = portNames;
					items.AddRange(items2);
					h6.SelectedIndex = 0;
					num2 = 8;
					num = num2;
					continue;
				}
				case 8:
					return;
					IL_0169:
					num2 = 0;
					_ = num2;
					num2 = 0;
					if (num2 != 0)
					{
					}
					if (portNames.Length == 0)
					{
						num2 = 7;
						num = num2;
						continue;
					}
					goto IL_00a7;
					IL_00a7:
					num2 = 5;
					num = num2;
					continue;
					IL_0057:
					num2 = 0;
					num = num2;
					continue;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			new SerialPort();
			portNames = SerialPort.GetPortNames();
			short num2 = 6;
			num = num2;
			goto default;
		}
		}
	}

	private void e(object A_0, EventArgs A_1)
	{
		short num = 19157;
		short num2 = num;
		num = 19157;
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

	private void d(object A_0, EventArgs A_1)
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
					goto end_IL_0020;
				case 0:
					break;
				}
				goto default;
			default:
				if (this.m_y)
				{
					num = 0;
					_ = num;
					num = 0;
					num2 = num;
				}
				else
				{
					num = 2;
					num2 = num;
				}
				break;
			case 0:
				return;
			case 3:
			{
				num = 31705;
				short num3 = num;
				num = 31705;
				switch (num3 == num)
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
					n("GDMMODE" + this.m_i + "=1");
					a("滚动码模式设置成功，该模式为单卡模式");
					return;
				}
				goto default;
			}
			case 2:
				{
					if (h9.Checked)
					{
						num = 3;
						num2 = num;
						break;
					}
					n("GDMMODE" + this.m_i + "=0");
					a("滚动码模式取消成功，该模式为单卡模式");
					return;
				}
				end_IL_0020:
				break;
			}
		}
	}

	private void c(object A_0, EventArgs A_1)
	{
		short num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				num = 1;
				if (num != 0)
				{
				}
				switch (0)
				{
				default:
					goto end_IL_0046;
				case 0:
					break;
				}
				goto default;
			default:
				num = 0;
				_ = num;
				if (this.m_y)
				{
					num = 0;
					num2 = num;
				}
				else
				{
					num = 2;
					num2 = num;
				}
				break;
			case 0:
				return;
			case 3:
			{
				num = -19287;
				short num3 = num;
				num = -19287;
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
					n("AUTOCHANGEMODE" + this.m_i + "=1");
					a("智闪卡模式设置成功，该模式为全局模式");
					return;
				}
				goto default;
			}
			case 2:
				{
					if (h8.Checked)
					{
						num = 3;
						num2 = num;
						break;
					}
					n("AUTOCHANGEMODE" + this.m_i + "=0");
					a("智闪卡模式取消成功，该模式为全局模式");
					return;
				}
				end_IL_0046:
				break;
			}
		}
	}

	private void b(object A_0, EventArgs A_1)
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
					goto end_IL_001f;
				case 0:
					break;
				}
				goto default;
			default:
				if (this.m_y)
				{
					num = 0;
					_ = num;
					num = 0;
					num2 = num;
				}
				else
				{
					num = 2;
					num2 = num;
				}
				break;
			case 0:
				return;
			case 3:
			{
				num = -25659;
				short num3 = num;
				num = -25659;
				switch (num3 == num)
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
					n("FIREWALLMODE" + this.m_i + "=1");
					a("穿越防火墙模式设置成功，该模式为全局模式");
					return;
				}
				goto default;
			}
			case 2:
				{
					if (h7.Checked)
					{
						num = 3;
						num2 = num;
						break;
					}
					n("FIREWALLMODE" + this.m_i + "=0");
					a("穿越防火墙模式取消成功，该模式为全局模式");
					return;
				}
				end_IL_001f:
				break;
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
			switch (0)
			{
			default:
			{
				byte[] array2 = default(byte[]);
				int num7 = default(int);
				int num5 = default(int);
				string path = default(string);
				List<string> list3 = default(List<string>);
				string[] array4 = default(string[]);
				int num6 = default(int);
				StreamWriter streamWriter = default(StreamWriter);
				List<MyKey> list4 = default(List<MyKey>);
				byte b2 = default(byte);
				byte b = default(byte);
				MyKey myKey3 = default(MyKey);
				string text2 = default(string);
				MyKey myKey4 = default(MyKey);
				List<MyKey> list = default(List<MyKey>);
				List<MyKey> list2 = default(List<MyKey>);
				int num10 = default(int);
				int num9 = default(int);
				int num11 = default(int);
				MyKey myKey6 = default(MyKey);
				int num12 = default(int);
				MyKey myKey7 = default(MyKey);
				MyKey myKey5 = default(MyKey);
				int num3 = default(int);
				MyKey myKey = default(MyKey);
				MyKey myKey2 = default(MyKey);
				string text = default(string);
				while (true)
				{
					int num4;
					switch (num2)
					{
					case 24:
						if (this.m_w == global::b.b)
						{
							num = 62;
							num2 = num;
						}
						else
						{
							num = 4;
							num2 = num;
						}
						continue;
					case 62:
						num = 87;
						num2 = num;
						continue;
					case 87:
					{
						ParallelQuery<string> values = a<CheckBox>(this.m_a4.Controls, "checkBox").Where(delegate(CheckBox checkBox)
						{
							short num13 = 32512;
							short num14 = num13;
							num13 = 32512;
							switch (num14 == num13)
							{
							default:
								num13 = 1;
								if (num13 != 0)
								{
								}
								num13 = 0;
								if (num13 != 0)
								{
								}
								num13 = 0;
								_ = num13;
								return checkBox.Checked;
							}
						}).Select(delegate(CheckBox checkBox)
						{
							short num13 = -30796;
							short num14 = num13;
							num13 = -30796;
							switch (num14 == num13)
							{
							default:
								num13 = 0;
								_ = num13;
								break;
							case true:
								break;
							}
							num13 = 0;
							if (num13 != 0)
							{
							}
							num13 = 1;
							if (num13 != 0)
							{
							}
							int num15 = int.Parse(checkBox.Name.Substring(checkBox.Name.Length - 1));
							n($"SETTING{this.m_i}={num15 - this.m_p}");
							byte[] value = m("DETECTION" + this.m_i + "?") as byte[];
							return new KeyValuePair<int, byte[]>(num15, value);
						}).OrderBy(delegate(KeyValuePair<int, byte[]> keyValuePair)
						{
							short num13 = 28521;
							short num14 = num13;
							num13 = 28521;
							switch (num14 == num13)
							{
							default:
								num13 = 0;
								if (num13 != 0)
								{
								}
								num13 = 1;
								if (num13 != 0)
								{
								}
								num13 = 0;
								_ = num13;
								return keyValuePair.Key;
							}
						})
							.AsParallel()
							.AsOrdered()
							.Select(delegate(KeyValuePair<int, byte[]> keyValuePair)
							{
								int num13 = default(int);
								string text3 = default(string);
								switch (0)
								{
								default:
									while (true)
									{
										switch (num13)
										{
										case 4:
											if (keyValuePair.Value.Length < 208)
											{
												short num14 = 1;
												if (num14 != 0)
												{
												}
												num14 = 2;
												num13 = num14;
											}
											else
											{
												text3 = MfKeyAttacks.Attack(keyValuePair.Value);
												short num14 = 3;
												num13 = num14;
											}
											continue;
										case 3:
										{
											short num14 = 5;
											num13 = num14;
											continue;
										}
										case 5:
											if (string.IsNullOrWhiteSpace(text3))
											{
												short num14 = 0;
												num13 = num14;
												continue;
											}
											goto case 1;
										case 2:
										{
											text3 = "";
											short num14 = 6;
											num13 = num14;
											continue;
										}
										case 6:
										{
											short num14 = 0;
											_ = num14;
											goto case 3;
										}
										case 0:
										{
											text3 = "mfkey32 attack failed, no keys found" + Environment.NewLine;
											short num14 = 1;
											num13 = num14;
											continue;
										}
										case 1:
											return $"[Tag slot {keyValuePair.Key}]{Environment.NewLine}" + text3;
										}
										break;
									}
									goto case 0;
								case 0:
								{
									short num14 = -11691;
									short num15 = num14;
									num14 = -11691;
									switch (num15 == num14)
									{
									case false:
									case true:
										break;
									default:
										num14 = 0;
										if (num14 != 0)
										{
										}
										text3 = "";
										num14 = 4;
										num13 = num14;
										break;
									}
									goto default;
								}
								}
							});
						this.m_ar.AppendText(string.Join(string.Empty, values));
						num = 71;
						num2 = num;
						continue;
					}
					case 4:
						num = 0;
						_ = num;
						if (this.m_w == global::b.c)
						{
							num = 55;
							num2 = num;
							continue;
						}
						goto case 60;
					case 55:
						n("PCRDETECTION" + this.m_i + "?");
						array2 = k();
						num7 = array2.Length;
						num4 = 0;
						num = 93;
						num2 = num;
						continue;
					case 93:
						if (num7 > 4096)
						{
							num = 45;
							num2 = num;
						}
						else
						{
							num = 1;
							num2 = num;
						}
						continue;
					case 45:
						n("PCRDETECTION" + this.m_i + "=0");
						a("还没有任何侦测数据");
						num = 74;
						num2 = num;
						continue;
					case 1:
						if (num7 >= 2)
						{
							num = 14;
							num2 = num;
							continue;
						}
						goto case 12;
					case 14:
					{
						byte[] array = new byte[2]
						{
							array2[num4++],
							array2[num4++]
						};
						num5 = (array[1] << 8) | array[0];
						path = "auto_keys/h.dic";
						string[] array3 = File.ReadAllLines("auto_keys/h.dic");
						list3 = new List<string>
						{
							"ffffffffffff", "d3f7d3f7d3f7", "000000000000", "b0b1b2b3b4b5", "4d3a99c351dd", "1a982c7e459a", "aabbccddeeff", "714c5c886e97", "587ee5f9350f", "a0478cc39091",
							"533cb6c723f6", "8fd0a4f256e9"
						};
						array4 = array3;
						num6 = 0;
						num = 61;
						num2 = num;
						continue;
					}
					case 57:
					case 61:
						num = 44;
						num2 = num;
						continue;
					case 44:
						if (num6 < array4.Length)
						{
							string item = array4[num6];
							list3.Add(item);
							num6++;
							num = 57;
							num2 = num;
						}
						else
						{
							num = 28;
							num2 = num;
						}
						continue;
					case 28:
						streamWriter = new StreamWriter(path, append: true);
						a("记录一共有" + num5 + "个字节侦测数据\n");
						list4 = new List<MyKey>();
						num = 95;
						num2 = num;
						continue;
					case 2:
						if (num4 + 4 <= num5)
						{
							num = 59;
							num2 = num;
							continue;
						}
						goto case 20;
					case 59:
						b2 = array2[num4++];
						b = array2[num4++];
						num = 96;
						num2 = num;
						continue;
					case 96:
						if (b2 != 192)
						{
							num = 51;
							num2 = num;
							continue;
						}
						goto case 82;
					case 51:
						num = 91;
						num2 = num;
						continue;
					case 91:
						if (b2 == 161)
						{
							num = 82;
							num2 = num;
							continue;
						}
						goto case 17;
					case 82:
						num = 92;
						num2 = num;
						continue;
					case 92:
						if (b > 0)
						{
							num = 58;
							num2 = num;
							continue;
						}
						goto case 33;
					case 58:
						num = 78;
						num2 = num;
						continue;
					case 78:
						if (num4 + b <= num5)
						{
							num = 69;
							num2 = num;
							continue;
						}
						goto case 33;
					case 69:
					{
						num = 1;
						if (num != 0)
						{
						}
						byte[] array5 = new byte[b];
						Array.Copy(array2, num4, array5, 0, b);
						myKey3 = new MyKey
						{
							KeyType = array5[0],
							Block = array5[1],
							UID = MfKeyAttacks.ToUInt32(array5, 2),
							nt0 = MfKeyAttacks.ToUInt32(array5, 6),
							nr0 = MfKeyAttacks.ToUInt32(array5, 10),
							ar0 = MfKeyAttacks.ToUInt32(array5, 14),
							ar1 = MfKeyAttacks.ToUInt32(array5, 18)
						};
						myKey3.Sector = MfKeyAttacks.ToSector(myKey3.Block);
						num = 15;
						num2 = num;
						continue;
					}
					case 15:
						if (myKey3.ar1 != 0)
						{
							num = 98;
							num2 = num;
							continue;
						}
						goto IL_0a88;
					case 98:
					{
						num = -14962;
						short num8 = num;
						num = -14962;
						switch (num8 == num)
						{
						case false:
						case true:
							break;
						default:
							num = 0;
							if (num != 0)
							{
							}
							num = 22;
							num2 = num;
							continue;
						}
						goto case 28;
					}
					case 22:
						if (myKey3.UID != 0)
						{
							num = 46;
							num2 = num;
							continue;
						}
						goto IL_0a88;
					case 46:
						num = 32;
						num2 = num;
						continue;
					case 32:
						if (myKey3.nt0 != 0)
						{
							num = 79;
							num2 = num;
							continue;
						}
						goto IL_0a88;
					case 79:
						try
						{
							myKey3.key = MfKey.MfKey64(myKey3.UID, myKey3.nt0, myKey3.nr0, myKey3.ar0, myKey3.ar1);
							myKey3.Found = myKey3.key != ulong.MaxValue;
						}
						catch (Exception)
						{
						}
						num = 89;
						num2 = num;
						continue;
					case 89:
						if (myKey3.Found)
						{
							num = 27;
							num2 = num;
							continue;
						}
						goto case 9;
					case 27:
					{
						a("认证成功的key:");
						string a_2 = $"[Sector{myKey3.Sector}/Block{myKey3.Block}]  Key found [{myKey3.key:x12}]  UID [{myKey3.UID:x8}]  ";
						a(a_2);
						text2 = $"{myKey3.key:x12}";
						num = 49;
						num2 = num;
						continue;
					}
					case 49:
						if (!list3.Contains(text2))
						{
							num = 52;
							num2 = num;
							continue;
						}
						goto case 9;
					case 52:
						streamWriter.WriteLine(text2);
						list3.Add(text2);
						a("已经添加到历史密钥");
						num = 9;
						num2 = num;
						continue;
					case 9:
						num4 += b;
						num = 17;
						num2 = num;
						continue;
					case 85:
						if (myKey3.Sector != byte.MaxValue)
						{
							num = 16;
							num2 = num;
							continue;
						}
						goto case 33;
					case 16:
						list4.Add(myKey3);
						num = 33;
						num2 = num;
						continue;
					case 33:
						num4 += b;
						num = 67;
						num2 = num;
						continue;
					case 17:
					case 67:
					case 95:
						num = 70;
						num2 = num;
						continue;
					case 70:
						if (num4 <= num5)
						{
							num = 2;
							num2 = num;
						}
						else
						{
							num = 20;
							num2 = num;
						}
						continue;
					case 20:
						num = 83;
						num2 = num;
						continue;
					case 83:
						if (!list4.Any())
						{
							num = 42;
							num2 = num;
						}
						else
						{
							num = 26;
							num2 = num;
						}
						continue;
					case 42:
						d();
						Cursor = Cursors.Default;
						this.m_ar.AppendText(Environment.NewLine + "Didn't find any nonces for mfkey32" + Environment.NewLine);
						streamWriter.Close();
						return;
					case 26:
						if (list4.Count > 40)
						{
							num = 11;
							num2 = num;
						}
						else
						{
							this.m_ar.AppendText($"{Environment.NewLine}Starting mfkey32 with {list4.Count} nonces {Environment.NewLine}");
							num = 43;
							num2 = num;
						}
						continue;
					case 11:
						this.m_ar.AppendText($"{Environment.NewLine}Starting mfkey32 with {list4.Count} nonces {Environment.NewLine}{Environment.NewLine}数据量太大，计算时间超过10分钟，请耐心等待，下次请侦测前清除侦测数据/记录，或者侦测时刷的次数不要太多。 {Environment.NewLine}{Environment.NewLine}{Environment.NewLine}");
						num = 56;
						num2 = num;
						continue;
					case 43:
					case 56:
						new KeyCompareruid();
						new KeyComparer();
						a("正在计算侦测的key，耐心等待");
						myKey4 = new MyKey();
						list = new List<MyKey>();
						list2 = new List<MyKey>();
						num10 = 0;
						num = 90;
						num2 = num;
						continue;
					case 90:
						if (list4.Count() - 6 > 0)
						{
							num = 84;
							num2 = num;
						}
						else
						{
							num10 = 0;
							num = 35;
							num2 = num;
						}
						continue;
					case 84:
						num10 = list4.Count() - 6;
						num = 50;
						num2 = num;
						continue;
					case 35:
					case 50:
						num9 = list4.Count() - 1;
						num = 86;
						num2 = num;
						continue;
					case 97:
						if (num11 <= 5)
						{
							num = 72;
							num2 = num;
							continue;
						}
						goto case 7;
					case 72:
						myKey6 = list4[num12];
						myKey7 = myKey5;
						num = 63;
						num2 = num;
						continue;
					case 63:
						if (myKey6.Block == myKey7.Block)
						{
							num = 3;
							num2 = num;
							continue;
						}
						goto case 53;
					case 3:
						num = 23;
						num2 = num;
						continue;
					case 23:
						if (myKey6.Sector == myKey7.Sector)
						{
							num = 38;
							num2 = num;
							continue;
						}
						goto case 53;
					case 38:
						num = 88;
						num2 = num;
						continue;
					case 88:
						if (myKey6.KeyType == myKey7.KeyType)
						{
							num = 36;
							num2 = num;
							continue;
						}
						goto case 53;
					case 36:
						num = 0;
						num2 = num;
						continue;
					case 0:
						if (myKey6.UID == myKey7.UID)
						{
							num = 40;
							num2 = num;
							continue;
						}
						goto case 53;
					case 40:
						list.Add(myKey6);
						list2.Add(myKey7);
						num11++;
						num = 53;
						num2 = num;
						continue;
					case 53:
						num12--;
						num = 37;
						num2 = num;
						continue;
					case 37:
					case 39:
						num = 21;
						num2 = num;
						continue;
					case 21:
						if (num12 > 0)
						{
							num = 97;
							num2 = num;
						}
						else
						{
							num = 7;
							num2 = num;
						}
						continue;
					case 7:
						num9--;
						num = 41;
						num2 = num;
						continue;
					case 41:
					case 86:
						num = 80;
						num2 = num;
						continue;
					case 80:
						if (num9 > num10)
						{
							myKey5 = list4[num9];
							num11 = 0;
							num12 = num9 - 1;
							num = 39;
							num2 = num;
						}
						else
						{
							num = 30;
							num2 = num;
						}
						continue;
					case 30:
						num6 = list.Count;
						a("配对结束共有" + num6 + "组\n");
						num3 = 0;
						num = 25;
						num2 = num;
						continue;
					case 10:
						if (myKey.Sector == myKey2.Sector)
						{
							num = 75;
							num2 = num;
							continue;
						}
						goto case 31;
					case 75:
						num = 5;
						num2 = num;
						continue;
					case 5:
						if (myKey.UID == myKey2.UID)
						{
							num = 47;
							num2 = num;
							continue;
						}
						goto case 66;
					case 47:
						num = 6;
						num2 = num;
						continue;
					case 6:
						if (myKey.Sector == myKey2.Sector)
						{
							num = 76;
							num2 = num;
							continue;
						}
						goto case 66;
					case 76:
						num = 64;
						num2 = num;
						continue;
					case 64:
						if (myKey.KeyType == myKey2.KeyType)
						{
							num = 54;
							num2 = num;
							continue;
						}
						goto case 66;
					case 54:
						num = 8;
						num2 = num;
						continue;
					case 8:
						try
						{
							a("正在计算，请稍后,第" + num3 + "组....\n");
							myKey.key = MfKey.MfKey32(myKey.UID, myKey.nt0, myKey.nr0, myKey.ar0, myKey2.nt0, myKey2.nr0, myKey2.ar0);
							myKey.Found = myKey.key != ulong.MaxValue;
						}
						catch (Exception)
						{
						}
						num = 94;
						num2 = num;
						continue;
					case 94:
						if (myKey.Found)
						{
							num = 19;
							num2 = num;
							continue;
						}
						goto case 66;
					case 19:
						num = 77;
						num2 = num;
						continue;
					case 77:
						if (myKey4.KeyType == myKey.KeyType)
						{
							num = 73;
							num2 = num;
							continue;
						}
						goto case 68;
					case 73:
						num = 65;
						num2 = num;
						continue;
					case 65:
						if (myKey4.UID == myKey.UID)
						{
							num = 18;
							num2 = num;
							continue;
						}
						goto case 68;
					case 18:
						num = 48;
						num2 = num;
						continue;
					case 48:
						if (myKey4.Sector != myKey.Sector)
						{
							num = 68;
							num2 = num;
							continue;
						}
						goto case 66;
					case 68:
					{
						string a_ = $"[Sector/扇区{myKey.Sector}/Block{myKey.Block}]  Key found/发现密钥 [{myKey.key:x12}]   UID卡号 [{myKey.UID:x8}]  ";
						a(a_);
						text = $"{myKey.key:x12}";
						num = 29;
						num2 = num;
						continue;
					}
					case 29:
						if (!list3.Contains(text))
						{
							num = 34;
							num2 = num;
							continue;
						}
						goto case 66;
					case 34:
						streamWriter.WriteLine(text);
						list3.Add(text);
						a("已经添加到历史密钥");
						num = 66;
						num2 = num;
						continue;
					case 66:
						num3++;
						num = 13;
						num2 = num;
						continue;
					case 13:
					case 25:
						num = 81;
						num2 = num;
						continue;
					case 81:
						if (num3 < list.Count())
						{
							myKey = list[num3];
							myKey2 = list2[num3];
							num = 10;
							num2 = num;
						}
						else
						{
							num = 31;
							num2 = num;
						}
						continue;
					case 31:
						streamWriter.Close();
						Cursor = Cursors.Default;
						num = 12;
						num2 = num;
						continue;
					case 12:
					case 74:
						d();
						Cursor = Cursors.Default;
						num = 60;
						num2 = num;
						continue;
					case 60:
					case 71:
						{
							d();
							Cursor = Cursors.Default;
							return;
						}
						IL_0a88:
						num = 85;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				Cursor = Cursors.WaitCursor;
				e();
				num = 24;
				num2 = num;
				goto default;
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		short num = 3323;
		short num2 = num;
		num = 3323;
		int num3;
		switch (num2 == num)
		{
		default:
			num = 0;
			if (num != 0)
			{
			}
			num = 0;
			_ = num;
			num = 4;
			num3 = num;
			goto IL_0093;
		case false:
		case true:
			{
				num = 1;
				num3 = num;
				goto IL_0093;
			}
			IL_0093:
			while (true)
			{
				switch (num3)
				{
				case 4:
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
						num3 = num;
						continue;
					}
					goto case 2;
				case 1:
					this.m_aq.Dispose();
					num = 2;
					num3 = num;
					continue;
				case 0:
					num = 3;
					num3 = num;
					continue;
				case 3:
					if (this.m_aq != null)
					{
						break;
					}
					goto case 2;
				case 2:
					num = 1;
					if (num != 0)
					{
					}
					base.Dispose(disposing);
					return;
				}
				break;
			}
			goto case false;
		}
	}

	private void a()
	{
		short num = -28376;
		short num2 = num;
		num = -28376;
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
		this.m_aq = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frm_main));
		this.m_ar = new TextBox();
		this.m_as = new OpenFileDialog();
		this.m_at = new SaveFileDialog();
		this.m_au = new GroupBox();
		e4 = new ComboBox();
		e5 = new BindingSource(this.m_aq);
		this.m_av = new TabPage();
		e6 = new GroupBox();
		e9 = new Button();
		dx = new GroupBox();
		dz = new Button();
		d0 = new TextBox();
		d1 = new Label();
		d2 = new CheckBox();
		dy = new GroupBox();
		h6 = new ComboBox();
		ft = new Label();
		e1 = new PictureBox();
		d6 = new TextBox();
		d3 = new TextBox();
		d4 = new Button();
		d5 = new Button();
		dl = new GroupBox();
		dt = new Label();
		du = new Label();
		ds = new Button();
		dm = new Label();
		dn = new Button();
		dp = new Button();
		this.m_aw = new GroupBox();
		this.m_ax = new Label();
		this.m_ay = new TextBox();
		this.m_az = new Button();
		this.m_a0 = new GroupBox();
		this.m_a1 = new Button();
		this.m_a2 = new TextBox();
		this.m_a3 = new Label();
		this.m_a4 = new TabPage();
		this.m_a5 = new CheckBox();
		this.m_bd = new GroupBox();
		ia = new Button();
		h7 = new CheckBox();
		h8 = new CheckBox();
		h9 = new CheckBox();
		h5 = new Button();
		h4 = new CheckBox();
		h2 = new Button();
		h3 = new CheckBox();
		h1 = new Button();
		hz = new Button();
		hx = new Button();
		hw = new Button();
		hv = new Button();
		hu = new Button();
		g8 = new Button();
		dv = new Button();
		dr = new Button();
		dq = new Button();
		this.m_be = new Button();
		this.m_bf = new Button();
		this.m_bg = new Button();
		this.m_bh = new Button();
		this.m_bi = new Button();
		this.m_bj = new Button();
		this.m_a6 = new CheckBox();
		this.m_a7 = new CheckBox();
		this.m_a8 = new CheckBox();
		this.m_a9 = new CheckBox();
		this.m_ba = new CheckBox();
		this.m_bb = new CheckBox();
		this.m_bc = new CheckBox();
		bk = new global::c();
		he = new TableLayoutPanel();
		br = new Label();
		f2 = new ComboBox();
		ge = new ComboBox();
		f3 = new ComboBox();
		bs = new ComboBox();
		bl = new TextBox();
		gf = new ComboBox();
		bq = new Label();
		gg = new Label();
		bo = new Label();
		ee = new ComboBox();
		gh = new Label();
		ef = new Label();
		bn = new ComboBox();
		bm = new Label();
		bp = new TextBox();
		bt = new global::c();
		g9 = new TableLayoutPanel();
		bz = new Label();
		bw = new TextBox();
		ga = new ComboBox();
		b0 = new Label();
		gb = new ComboBox();
		fu = new ComboBox();
		eg = new ComboBox();
		gc = new Label();
		fv = new ComboBox();
		by = new ComboBox();
		eh = new Label();
		gd = new Label();
		bx = new Label();
		bv = new ComboBox();
		bu = new Label();
		b1 = new TextBox();
		b2 = new global::c();
		ha = new TableLayoutPanel();
		b9 = new Label();
		fw = new ComboBox();
		gj = new ComboBox();
		fx = new ComboBox();
		gi = new ComboBox();
		b5 = new ComboBox();
		ei = new ComboBox();
		ca = new ComboBox();
		b8 = new Label();
		gk = new Label();
		b7 = new TextBox();
		gl = new Label();
		b3 = new TextBox();
		b6 = new Label();
		b4 = new Label();
		ej = new Label();
		cb = new global::c();
		hc = new TableLayoutPanel();
		ci = new Label();
		f0 = new ComboBox();
		gm = new ComboBox();
		f1 = new ComboBox();
		ch = new Label();
		cc = new TextBox();
		gn = new ComboBox();
		cf = new Label();
		go = new Label();
		el = new Label();
		ek = new ComboBox();
		gp = new Label();
		cd = new Label();
		ce = new ComboBox();
		cj = new ComboBox();
		cg = new TextBox();
		ck = new global::c();
		hb = new TableLayoutPanel();
		cr = new Label();
		fy = new ComboBox();
		gq = new ComboBox();
		fz = new ComboBox();
		cq = new Label();
		cl = new TextBox();
		gr = new ComboBox();
		co = new Label();
		gs = new Label();
		en = new Label();
		em = new ComboBox();
		gt = new Label();
		cm = new Label();
		cn = new ComboBox();
		cs = new ComboBox();
		cp = new TextBox();
		ct = new global::c();
		hd = new TableLayoutPanel();
		c0 = new Label();
		f8 = new ComboBox();
		gu = new ComboBox();
		f9 = new ComboBox();
		cz = new Label();
		cu = new TextBox();
		gv = new ComboBox();
		cx = new Label();
		gw = new Label();
		ep = new Label();
		eo = new ComboBox();
		gx = new Label();
		cv = new Label();
		cw = new ComboBox();
		c1 = new ComboBox();
		cy = new TextBox();
		c2 = new global::c();
		hf = new TableLayoutPanel();
		c9 = new Label();
		f4 = new ComboBox();
		gy = new ComboBox();
		f5 = new ComboBox();
		c8 = new Label();
		c3 = new TextBox();
		gz = new ComboBox();
		c6 = new Label();
		g0 = new Label();
		er = new Label();
		eq = new ComboBox();
		g1 = new Label();
		c4 = new Label();
		c5 = new ComboBox();
		da = new ComboBox();
		c7 = new TextBox();
		db = new global::c();
		hg = new TableLayoutPanel();
		di = new Label();
		f6 = new ComboBox();
		g2 = new ComboBox();
		f7 = new ComboBox();
		dh = new Label();
		dc = new TextBox();
		g3 = new ComboBox();
		df = new Label();
		g4 = new Label();
		et = new Label();
		es = new ComboBox();
		g5 = new Label();
		dd = new Label();
		de = new ComboBox();
		dj = new ComboBox();
		dg = new TextBox();
		dk = new TabControl();
		d7 = new TabPage();
		e2 = new ContextMenuStrip(this.m_aq);
		e3 = new ToolStripMenuItem();
		fr = new ToolStripMenuItem();
		hm = new GroupBox();
		h0 = new Button();
		hy = new Button();
		ht = new Button();
		hs = new Button();
		hk = new Button();
		hl = new ComboBox();
		hj = new Button();
		hi = new Button();
		hn = new LinkLabel();
		ho = new Button();
		hp = new Button();
		hq = new Button();
		hr = new Button();
		fo = new UcLegend();
		fp = new Button();
		fq = new Button();
		fa = new Label();
		e7 = new ComboBox();
		e8 = new BindingSource(this.m_aq);
		e0 = new CheckBox();
		ey = new Label();
		ez = new Label();
		eu = new RadioButton();
		ev = new RadioButton();
		ew = new RadioButton();
		ex = new Label();
		ea = new Button();
		eb = new Button();
		ec = new Button();
		ed = new Button();
		d8 = new HexBox();
		d9 = new HexBox();
		fb = new TabPage();
		fm = new FlowLayoutPanel();
		ff = new GroupBox();
		g7 = new UcTextFlow();
		fh = new LinkLabel();
		fg = new LinkLabel();
		fl = new GroupBox();
		fn = new Button();
		fd = new TextBox();
		fe = new Button();
		fc = new RichTextBox();
		fi = new ContextMenuStrip(this.m_aq);
		hh = new ToolStripMenuItem();
		fj = new ToolStripMenuItem();
		fk = new ToolStripMenuItem();
		dw = new FolderBrowserDialog();
		fs = new OpenFileDialog();
		g6 = new ToolTip(this.m_aq);
		this.m_au.SuspendLayout();
		((ISupportInitialize)e5).BeginInit();
		this.m_av.SuspendLayout();
		e6.SuspendLayout();
		dx.SuspendLayout();
		dy.SuspendLayout();
		((ISupportInitialize)e1).BeginInit();
		dl.SuspendLayout();
		this.m_aw.SuspendLayout();
		this.m_a0.SuspendLayout();
		this.m_a4.SuspendLayout();
		this.m_bd.SuspendLayout();
		bk.SuspendLayout();
		he.SuspendLayout();
		bt.SuspendLayout();
		g9.SuspendLayout();
		b2.SuspendLayout();
		ha.SuspendLayout();
		cb.SuspendLayout();
		hc.SuspendLayout();
		ck.SuspendLayout();
		hb.SuspendLayout();
		ct.SuspendLayout();
		hd.SuspendLayout();
		c2.SuspendLayout();
		hf.SuspendLayout();
		db.SuspendLayout();
		hg.SuspendLayout();
		dk.SuspendLayout();
		d7.SuspendLayout();
		e2.SuspendLayout();
		hm.SuspendLayout();
		((ISupportInitialize)e8).BeginInit();
		fb.SuspendLayout();
		fm.SuspendLayout();
		ff.SuspendLayout();
		fl.SuspendLayout();
		fi.SuspendLayout();
		SuspendLayout();
		this.m_ar.Dock = DockStyle.Fill;
		this.m_ar.Location = new Point(3, 17);
		this.m_ar.Multiline = true;
		this.m_ar.Name = "txt_output";
		this.m_ar.ScrollBars = ScrollBars.Vertical;
		this.m_ar.Size = new Size(1165, 140);
		this.m_ar.TabIndex = 6;
		this.m_ar.Text = " ";
		this.m_ar.VisibleChanged += ae;
		this.m_as.Filter = "Dump files| *.bin; *.dump; *.mfd; *.hex; *.json; *.eml; *.mct|All files| *.*";
		this.m_at.Filter = "Dump files| *.bin; *.dump; *.mfd; *.hex|JSON file|*.json|EML file|*.eml|MCT file|*.mct";
		this.m_au.Controls.Add(this.m_ar);
		this.m_au.Location = new Point(8, 545);
		this.m_au.Name = "gb_output";
		this.m_au.Size = new Size(1171, 160);
		this.m_au.TabIndex = 7;
		this.m_au.TabStop = false;
		this.m_au.Text = "Output";
		e4.DataSource = e5;
		e4.FormattingEnabled = true;
		e4.Location = new Point(27, 37);
		e4.Name = "cb_languages";
		e4.Size = new Size(121, 20);
		e4.TabIndex = 7;
		e4.SelectedIndexChanged += bi;
		this.m_av.Controls.Add(e6);
		this.m_av.Controls.Add(dx);
		this.m_av.Controls.Add(dy);
		this.m_av.Controls.Add(dl);
		this.m_av.Controls.Add(this.m_aw);
		this.m_av.Controls.Add(this.m_a0);
		this.m_av.Location = new Point(4, 22);
		this.m_av.Name = "tpSettings";
		this.m_av.Size = new Size(1160, 506);
		this.m_av.TabIndex = 3;
		this.m_av.Text = "Settings";
		this.m_av.UseVisualStyleBackColor = true;
		e6.Controls.Add(e9);
		e6.Controls.Add(e4);
		e6.Location = new Point(526, 25);
		e6.Name = "gb_language";
		e6.Size = new Size(179, 111);
		e6.TabIndex = 8;
		e6.TabStop = false;
		e6.Text = "Languages && Templates";
		e9.Location = new Point(27, 62);
		e9.Name = "btnStartlocation";
		e9.Size = new Size(121, 21);
		e9.TabIndex = 8;
		e9.Text = "Open Location";
		e9.UseVisualStyleBackColor = true;
		e9.Click += ao;
		dx.Controls.Add(dz);
		dx.Controls.Add(d0);
		dx.Controls.Add(d1);
		dx.Controls.Add(d2);
		dx.Location = new Point(526, 158);
		dx.Name = "gb_keepalive";
		dx.Size = new Size(424, 153);
		dx.TabIndex = 4;
		dx.TabStop = false;
		dx.Text = "Keep Alive";
		dx.Visible = false;
		dz.Enabled = false;
		dz.Location = new Point(260, 81);
		dz.Name = "btn_setInterval";
		dz.Size = new Size(97, 28);
		dz.TabIndex = 3;
		dz.Text = "Set";
		dz.UseVisualStyleBackColor = true;
		dz.Click += a0;
		d0.Location = new Point(25, 87);
		d0.Name = "txt_interval";
		d0.Size = new Size(69, 21);
		d0.TabIndex = 2;
		d1.AutoSize = true;
		d1.Location = new Point(100, 90);
		d1.Name = "lbl_interval";
		d1.Size = new Size(83, 12);
		d1.TabIndex = 1;
		d1.Text = "Interval (ms)";
		d2.AutoSize = true;
		d2.Location = new Point(25, 39);
		d2.Name = "chk_keepalive";
		d2.Size = new Size(222, 16);
		d2.TabIndex = 0;
		d2.Text = "Send keep-alive (VERSION command)";
		d2.UseVisualStyleBackColor = true;
		dy.Controls.Add(h6);
		dy.Controls.Add(ft);
		dy.Controls.Add(e1);
		dy.Controls.Add(d6);
		dy.Controls.Add(d3);
		dy.Controls.Add(d4);
		dy.Controls.Add(d5);
		dy.Location = new Point(39, 25);
		dy.Name = "gb_connectionSettings";
		dy.Size = new Size(481, 153);
		dy.TabIndex = 3;
		dy.TabStop = false;
		dy.Text = "Connection status";
		h6.BackColor = SystemColors.ButtonFace;
		h6.DropDownStyle = ComboBoxStyle.DropDownList;
		h6.FormattingEnabled = true;
		h6.ItemHeight = 12;
		h6.Location = new Point(165, 32);
		h6.Name = "CB1";
		h6.Size = new Size(90, 20);
		h6.TabIndex = 41;
		h6.DropDown += f;
		h6.SelectedIndexChanged += e;
		ft.AutoSize = true;
		ft.Location = new Point(163, 109);
		ft.Name = "label1";
		ft.Size = new Size(101, 12);
		ft.TabIndex = 7;
		ft.Text = "Firmware version";
		e1.BackgroundImageLayout = ImageLayout.Stretch;
		e1.BorderStyle = BorderStyle.FixedSingle;
		e1.Image = Resources.usbWarning;
		e1.InitialImage = Resources.usbWarning;
		e1.Location = new Point(25, 25);
		e1.Name = "pb_device";
		e1.Size = new Size(128, 118);
		e1.TabIndex = 5;
		e1.TabStop = false;
		d6.Enabled = false;
		d6.Location = new Point(166, 124);
		d6.Name = "tb_firmware";
		d6.ReadOnly = true;
		d6.Size = new Size(297, 21);
		d6.TabIndex = 6;
		d3.Location = new Point(166, 65);
		d3.Margin = new Padding(8, 7, 8, 7);
		d3.Name = "txt_constatus";
		d3.ReadOnly = true;
		d3.Size = new Size(297, 21);
		d3.TabIndex = 5;
		d3.TextAlign = HorizontalAlignment.Center;
		d4.Enabled = false;
		d4.Location = new Point(375, 27);
		d4.Name = "btn_disconnect";
		d4.Size = new Size(85, 28);
		d4.TabIndex = 1;
		d4.Text = "Disconnect";
		d4.UseVisualStyleBackColor = true;
		d4.Click += az;
		d5.Location = new Point(270, 27);
		d5.Name = "btn_connect";
		d5.Size = new Size(85, 28);
		d5.TabIndex = 0;
		d5.Text = "Connect";
		d5.UseVisualStyleBackColor = true;
		d5.Click += ay;
		dl.Controls.Add(dt);
		dl.Controls.Add(du);
		dl.Controls.Add(ds);
		dl.Controls.Add(dm);
		dl.Controls.Add(dn);
		dl.Controls.Add(dp);
		dl.Location = new Point(39, 317);
		dl.Name = "gb_bootloader";
		dl.Size = new Size(931, 126);
		dl.TabIndex = 2;
		dl.TabStop = false;
		dl.Text = "Reset && Bootloader options";
		dl.Visible = false;
		dt.AutoSize = true;
		dt.Location = new Point(245, 88);
		dt.Name = "lbl_defaults";
		dt.Size = new Size(569, 12);
		dt.TabIndex = 10;
		dt.Text = "Flashes the stock RevE rebooted firmware of the ChameleonMini. Needs to be in bootloader mode.";
		du.AutoSize = true;
		du.Location = new Point(245, 34);
		du.Name = "lbl_reset";
		du.Size = new Size(407, 12);
		du.TabIndex = 9;
		du.Text = "Reboots the ChameleonMini, i.e., power down and subsequent power-up";
		ds.Enabled = false;
		ds.Location = new Point(75, 30);
		ds.Name = "btn_reset";
		ds.Size = new Size(135, 21);
		ds.TabIndex = 8;
		ds.Text = "Reset";
		ds.UseVisualStyleBackColor = true;
		ds.Click += a3;
		dm.AutoSize = true;
		dm.Location = new Point(245, 61);
		dm.Name = "lbl_upgrade";
		dm.Size = new Size(335, 12);
		dm.TabIndex = 7;
		dm.Text = "Sets the ChameleonMini into firmware upgrade mode (DFU)";
		dn.Enabled = false;
		dn.Location = new Point(75, 56);
		dn.Name = "btn_bootmode";
		dn.Size = new Size(135, 21);
		dn.TabIndex = 6;
		dn.Text = "Upgrade";
		dn.UseVisualStyleBackColor = true;
		dn.Click += bf;
		dp.Location = new Point(75, 83);
		dp.Name = "btn_exitboot";
		dp.Size = new Size(135, 21);
		dp.TabIndex = 5;
		dp.Text = "Load Defaults";
		dp.UseVisualStyleBackColor = true;
		dp.Click += be;
		this.m_aw.Controls.Add(this.m_ax);
		this.m_aw.Controls.Add(this.m_ay);
		this.m_aw.Controls.Add(this.m_az);
		this.m_aw.Location = new Point(39, 193);
		this.m_aw.Name = "gb_defaultdownload";
		this.m_aw.Size = new Size(434, 111);
		this.m_aw.TabIndex = 1;
		this.m_aw.TabStop = false;
		this.m_aw.Text = "Download Location";
		this.m_ax.AutoSize = true;
		this.m_ax.Location = new Point(15, 30);
		this.m_ax.Name = "lbl_defaultdownload";
		this.m_ax.Size = new Size(323, 12);
		this.m_ax.TabIndex = 2;
		this.m_ax.Text = "Choose the default directory for the downloaded dumps";
		this.m_ay.Location = new Point(18, 60);
		this.m_ay.Name = "txt_defaultdownload";
		this.m_ay.Size = new Size(337, 21);
		this.m_ay.TabIndex = 1;
		this.m_az.Location = new Point(375, 58);
		this.m_az.Name = "btn_browsedownloads";
		this.m_az.Size = new Size(33, 21);
		this.m_az.TabIndex = 0;
		this.m_az.Text = "...";
		this.m_az.UseVisualStyleBackColor = true;
		this.m_az.Click += a1;
		this.m_a0.Controls.Add(this.m_a1);
		this.m_a0.Controls.Add(this.m_a2);
		this.m_a0.Controls.Add(this.m_a3);
		this.m_a0.Location = new Point(711, 25);
		this.m_a0.Name = "gb_rssi";
		this.m_a0.Size = new Size(278, 111);
		this.m_a0.TabIndex = 0;
		this.m_a0.TabStop = false;
		this.m_a0.Text = "RSSI Voltage";
		this.m_a1.Enabled = false;
		this.m_a1.Location = new Point(167, 47);
		this.m_a1.Name = "btn_rssirefresh";
		this.m_a1.Size = new Size(83, 28);
		this.m_a1.TabIndex = 2;
		this.m_a1.Text = "Refresh";
		this.m_a1.UseVisualStyleBackColor = true;
		this.m_a1.Click += a2;
		this.m_a2.Location = new Point(21, 53);
		this.m_a2.Name = "txt_rssi";
		this.m_a2.Size = new Size(114, 21);
		this.m_a2.TabIndex = 1;
		this.m_a3.AutoSize = true;
		this.m_a3.Location = new Point(18, 32);
		this.m_a3.Name = "lbl_rssi";
		this.m_a3.Size = new Size(77, 12);
		this.m_a3.TabIndex = 0;
		this.m_a3.Text = "Current RSSI";
		this.m_a4.Controls.Add(this.m_a5);
		this.m_a4.Controls.Add(this.m_bd);
		this.m_a4.Controls.Add(this.m_a6);
		this.m_a4.Controls.Add(this.m_a7);
		this.m_a4.Controls.Add(this.m_a8);
		this.m_a4.Controls.Add(this.m_a9);
		this.m_a4.Controls.Add(this.m_ba);
		this.m_a4.Controls.Add(this.m_bb);
		this.m_a4.Controls.Add(this.m_bc);
		this.m_a4.Controls.Add(bk);
		this.m_a4.Controls.Add(bt);
		this.m_a4.Controls.Add(b2);
		this.m_a4.Controls.Add(cb);
		this.m_a4.Controls.Add(ck);
		this.m_a4.Controls.Add(ct);
		this.m_a4.Controls.Add(c2);
		this.m_a4.Controls.Add(db);
		this.m_a4.Location = new Point(4, 22);
		this.m_a4.Name = "tpOperation";
		this.m_a4.Padding = new Padding(3);
		this.m_a4.Size = new Size(1160, 506);
		this.m_a4.TabIndex = 0;
		this.m_a4.Text = "Operation";
		this.m_a4.UseVisualStyleBackColor = true;
		this.m_a5.AutoSize = true;
		this.m_a5.Enabled = false;
		this.m_a5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.m_a5.Location = new Point(885, 212);
		this.m_a5.Name = "checkBox8";
		this.m_a5.Size = new Size(59, 17);
		this.m_a5.TabIndex = 8;
		this.m_a5.Text = "Slot 8";
		this.m_a5.UseVisualStyleBackColor = true;
		this.m_a5.CheckedChanged += a4;
		this.m_bd.Controls.Add(ia);
		this.m_bd.Controls.Add(h7);
		this.m_bd.Controls.Add(h8);
		this.m_bd.Controls.Add(h9);
		this.m_bd.Controls.Add(h5);
		this.m_bd.Controls.Add(h4);
		this.m_bd.Controls.Add(h2);
		this.m_bd.Controls.Add(h3);
		this.m_bd.Controls.Add(h1);
		this.m_bd.Controls.Add(hz);
		this.m_bd.Controls.Add(hx);
		this.m_bd.Controls.Add(hw);
		this.m_bd.Controls.Add(hv);
		this.m_bd.Controls.Add(hu);
		this.m_bd.Controls.Add(g8);
		this.m_bd.Controls.Add(dv);
		this.m_bd.Controls.Add(dr);
		this.m_bd.Controls.Add(dq);
		this.m_bd.Controls.Add(this.m_be);
		this.m_bd.Controls.Add(this.m_bf);
		this.m_bd.Controls.Add(this.m_bg);
		this.m_bd.Controls.Add(this.m_bh);
		this.m_bd.Controls.Add(this.m_bi);
		this.m_bd.Controls.Add(this.m_bj);
		this.m_bd.Location = new Point(3, 414);
		this.m_bd.Name = "gb_actions";
		this.m_bd.Size = new Size(1151, 96);
		this.m_bd.TabIndex = 36;
		this.m_bd.TabStop = false;
		this.m_bd.Text = "Available Actions";
		ia.Font = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, 134);
		ia.Location = new Point(614, 20);
		ia.Name = "button15";
		ia.Size = new Size(126, 28);
		ia.TabIndex = 32;
		ia.Text = "Quick mfkey32";
		ia.UseVisualStyleBackColor = true;
		ia.Click += a;
		h7.AutoSize = true;
		h7.Enabled = false;
		h7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		h7.Location = new Point(1064, 30);
		h7.Name = "cxx9";
		h7.Size = new Size(91, 17);
		h7.TabIndex = 31;
		h7.Text = "穿越防火墙";
		h7.UseVisualStyleBackColor = true;
		h7.CheckedChanged += b;
		h8.AutoSize = true;
		h8.Enabled = false;
		h8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		h8.Location = new Point(993, 30);
		h8.Name = "cb10";
		h8.Size = new Size(65, 17);
		h8.TabIndex = 30;
		h8.Text = "智闪卡";
		h8.UseVisualStyleBackColor = true;
		h8.CheckedChanged += c;
		h9.AutoSize = true;
		h9.Enabled = false;
		h9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		h9.Location = new Point(901, 30);
		h9.Name = "cb9";
		h9.Size = new Size(91, 17);
		h9.TabIndex = 29;
		h9.Text = "滚动码测试";
		h9.UseVisualStyleBackColor = true;
		h9.CheckedChanged += d;
		h5.AutoSize = true;
		h5.Location = new Point(779, 58);
		h5.Name = "button14";
		h5.Size = new Size(111, 28);
		h5.TabIndex = 28;
		h5.Text = "Reader Mode";
		g6.SetToolTip(h5, "读卡器模式");
		h5.UseVisualStyleBackColor = true;
		h5.Click += g;
		h4.AutoSize = true;
		h4.Enabled = false;
		h4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		h4.Location = new Point(993, 30);
		h4.Name = "cx9";
		h4.Size = new Size(86, 17);
		h4.TabIndex = 26;
		h4.Text = "SAKMODE";
		h4.UseVisualStyleBackColor = true;
		h4.Visible = false;
		h4.CheckedChanged += i;
		h2.AutoSize = true;
		h2.Location = new Point(361, 58);
		h2.Name = "button12";
		h2.Size = new Size(111, 28);
		h2.TabIndex = 25;
		h2.Text = "Edit HistoryKey";
		h2.UseVisualStyleBackColor = true;
		h2.Click += j;
		h3.AutoSize = true;
		h3.Enabled = false;
		h3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		h3.Location = new Point(998, 30);
		h3.Name = "cx10";
		h3.Size = new Size(84, 17);
		h3.TabIndex = 27;
		h3.Text = "UIDMODE";
		h3.UseVisualStyleBackColor = true;
		h3.Visible = false;
		h3.CheckedChanged += h;
		h1.AutoSize = true;
		h1.Location = new Point(662, 58);
		h1.Name = "button11";
		h1.Size = new Size(111, 28);
		h1.TabIndex = 24;
		h1.Text = "Stop All";
		h1.UseVisualStyleBackColor = true;
		h1.Click += k;
		hz.AutoSize = true;
		hz.Location = new Point(915, 5);
		hz.Name = "button8";
		hz.Size = new Size(93, 22);
		hz.TabIndex = 23;
		hz.Text = "Read Card Num";
		hz.UseVisualStyleBackColor = true;
		hz.Visible = false;
		hz.Click += n;
		hx.AutoSize = true;
		hx.Location = new Point(478, 58);
		hx.Name = "button7";
		hx.Size = new Size(178, 28);
		hx.TabIndex = 22;
		hx.Text = "Direct Read Card";
		g6.SetToolTip(hx, "侦测先得到密钥，然后直接读卡，再侦测");
		hx.UseVisualStyleBackColor = true;
		hx.Click += m;
		hw.AutoSize = true;
		hw.Location = new Point(110, 58);
		hw.Name = "button6";
		hw.Size = new Size(111, 28);
		hw.TabIndex = 21;
		hw.Text = "Clear Record";
		hw.UseVisualStyleBackColor = true;
		hw.Click += q;
		hv.AutoSize = true;
		hv.Location = new Point(6, 58);
		hv.Name = "button4";
		hv.Size = new Size(95, 28);
		hv.TabIndex = 20;
		hv.Text = "Clear All";
		hv.UseVisualStyleBackColor = true;
		hv.Click += r;
		hu.Font = new Font("宋体", 10.5f, FontStyle.Bold, GraphicsUnit.Point, 134);
		hu.Location = new Point(746, 19);
		hu.Name = "discon";
		hu.Size = new Size(114, 29);
		hu.TabIndex = 19;
		hu.Text = "disconnect";
		g6.SetToolTip(hu, "断开变色龙连接");
		hu.UseVisualStyleBackColor = true;
		hu.Click += ab;
		g8.Location = new Point(245, 58);
		g8.Name = "btn_identify";
		g8.Size = new Size(111, 28);
		g8.TabIndex = 18;
		g8.Text = "Identify";
		g6.SetToolTip(g8, "Identify Card at Reader");
		g8.UseVisualStyleBackColor = true;
		g8.Click += ag;
		dv.Location = new Point(430, 27);
		dv.Name = "btn_setactive";
		dv.Size = new Size(86, 21);
		dv.TabIndex = 14;
		dv.Text = "Set Active";
		dv.UseVisualStyleBackColor = true;
		dv.Click += a8;
		dr.AutoSize = true;
		dr.Enabled = false;
		dr.Location = new Point(110, 27);
		dr.Name = "btn_selectnone";
		dr.Size = new Size(106, 22);
		dr.TabIndex = 10;
		dr.Text = "Select None";
		dr.UseVisualStyleBackColor = true;
		dr.Click += a5;
		dq.AutoSize = true;
		dq.Enabled = false;
		dq.Location = new Point(9, 27);
		dq.Name = "btn_selectall";
		dq.Size = new Size(95, 22);
		dq.TabIndex = 9;
		dq.Text = "Select All";
		dq.UseVisualStyleBackColor = true;
		dq.Click += a6;
		this.m_be.Location = new Point(338, 27);
		this.m_be.Name = "btn_refresh";
		this.m_be.Size = new Size(86, 21);
		this.m_be.TabIndex = 13;
		this.m_be.Text = "Refresh";
		this.m_be.UseVisualStyleBackColor = true;
		this.m_be.Click += a9;
		this.m_bf.Location = new Point(1014, 5);
		this.m_bf.Name = "btn_clear";
		this.m_bf.Size = new Size(86, 21);
		this.m_bf.TabIndex = 12;
		this.m_bf.Text = "Clear";
		this.m_bf.UseVisualStyleBackColor = true;
		this.m_bf.Visible = false;
		this.m_bf.Click += ba;
		this.m_bg.Location = new Point(522, 27);
		this.m_bg.Name = "btn_keycalc";
		this.m_bg.Size = new Size(86, 21);
		this.m_bg.TabIndex = 15;
		this.m_bg.Text = "mfkey32";
		this.m_bg.UseVisualStyleBackColor = true;
		this.m_bg.Click += bb;
		this.m_bh.Location = new Point(245, 27);
		this.m_bh.Name = "btn_apply";
		this.m_bh.Size = new Size(86, 21);
		this.m_bh.TabIndex = 11;
		this.m_bh.Text = "Apply";
		this.m_bh.UseVisualStyleBackColor = true;
		this.m_bh.Click += bg;
		this.m_bi.Location = new Point(1034, 58);
		this.m_bi.Name = "btn_download";
		this.m_bi.Size = new Size(111, 28);
		this.m_bi.TabIndex = 17;
		this.m_bi.Text = "Download Dump";
		this.m_bi.UseVisualStyleBackColor = true;
		this.m_bi.Click += bc;
		this.m_bj.Location = new Point(917, 58);
		this.m_bj.Name = "btn_upload";
		this.m_bj.Size = new Size(111, 28);
		this.m_bj.TabIndex = 16;
		this.m_bj.Text = "Upload Dump";
		this.m_bj.UseVisualStyleBackColor = true;
		this.m_bj.Click += bd;
		this.m_a6.AutoSize = true;
		this.m_a6.Enabled = false;
		this.m_a6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.m_a6.Location = new Point(594, 212);
		this.m_a6.Name = "checkBox7";
		this.m_a6.Size = new Size(59, 17);
		this.m_a6.TabIndex = 7;
		this.m_a6.Text = "Slot 7";
		this.m_a6.UseVisualStyleBackColor = true;
		this.m_a6.CheckedChanged += a4;
		this.m_a7.AutoSize = true;
		this.m_a7.Enabled = false;
		this.m_a7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.m_a7.Location = new Point(303, 212);
		this.m_a7.Name = "checkBox6";
		this.m_a7.Size = new Size(59, 17);
		this.m_a7.TabIndex = 6;
		this.m_a7.Text = "Slot 6";
		this.m_a7.UseVisualStyleBackColor = true;
		this.m_a7.CheckedChanged += a4;
		this.m_a8.AutoSize = true;
		this.m_a8.Enabled = false;
		this.m_a8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.m_a8.Location = new Point(12, 212);
		this.m_a8.Name = "checkBox5";
		this.m_a8.Size = new Size(59, 17);
		this.m_a8.TabIndex = 5;
		this.m_a8.Text = "Slot 5";
		this.m_a8.UseVisualStyleBackColor = true;
		this.m_a8.CheckedChanged += a4;
		this.m_a9.AutoSize = true;
		this.m_a9.Enabled = false;
		this.m_a9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.m_a9.Location = new Point(888, 5);
		this.m_a9.Name = "checkBox4";
		this.m_a9.Size = new Size(59, 17);
		this.m_a9.TabIndex = 4;
		this.m_a9.Text = "Slot 4";
		this.m_a9.UseVisualStyleBackColor = true;
		this.m_a9.CheckedChanged += a4;
		this.m_ba.AutoSize = true;
		this.m_ba.Enabled = false;
		this.m_ba.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.m_ba.Location = new Point(597, 5);
		this.m_ba.Name = "checkBox3";
		this.m_ba.Size = new Size(59, 17);
		this.m_ba.TabIndex = 3;
		this.m_ba.Text = "Slot 3";
		this.m_ba.UseVisualStyleBackColor = true;
		this.m_ba.CheckedChanged += a4;
		this.m_bb.AutoSize = true;
		this.m_bb.Enabled = false;
		this.m_bb.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.m_bb.Location = new Point(306, 5);
		this.m_bb.Name = "checkBox2";
		this.m_bb.Size = new Size(59, 17);
		this.m_bb.TabIndex = 2;
		this.m_bb.Text = "Slot 2";
		this.m_bb.UseVisualStyleBackColor = true;
		this.m_bb.CheckedChanged += a4;
		this.m_bc.AutoSize = true;
		this.m_bc.Checked = true;
		this.m_bc.CheckState = CheckState.Checked;
		this.m_bc.Enabled = false;
		this.m_bc.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		this.m_bc.Location = new Point(15, 5);
		this.m_bc.Name = "checkBox1";
		this.m_bc.Size = new Size(59, 17);
		this.m_bc.TabIndex = 1;
		this.m_bc.Text = "Slot 1";
		this.m_bc.UseVisualStyleBackColor = true;
		this.m_bc.CheckedChanged += a4;
		bk.e(SystemColors.ControlLight);
		bk.f(SystemColors.ControlLightLight);
		bk.e(5);
		bk.e(1f);
		bk.Controls.Add(he);
		bk.Location = new Point(294, 227);
		bk.Name = "gb_tagslot6";
		bk.Size = new Size(278, 181);
		bk.TabIndex = 26;
		bk.TabStop = false;
		he.AllowDrop = true;
		he.ColumnCount = 3;
		he.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
		he.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));
		he.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));
		he.Controls.Add(br, 0, 0);
		he.Controls.Add(f2, 2, 3);
		he.Controls.Add(ge, 1, 5);
		he.Controls.Add(f3, 2, 2);
		he.Controls.Add(bs, 1, 0);
		he.Controls.Add(bl, 1, 6);
		he.Controls.Add(gf, 1, 4);
		he.Controls.Add(bq, 0, 1);
		he.Controls.Add(gg, 0, 5);
		he.Controls.Add(bo, 0, 2);
		he.Controls.Add(ee, 1, 3);
		he.Controls.Add(gh, 0, 4);
		he.Controls.Add(ef, 0, 3);
		he.Controls.Add(bn, 1, 2);
		he.Controls.Add(bm, 0, 6);
		he.Controls.Add(bp, 1, 1);
		he.Location = new Point(9, 16);
		he.Name = "tableLayoutPanel6";
		he.RowCount = 7;
		he.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		he.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		he.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		he.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		he.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		he.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		he.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		he.Size = new Size(254, 197);
		he.TabIndex = 26;
		he.DragDrop += a;
		he.DragEnter += b;
		br.AutoSize = true;
		br.Location = new Point(3, 0);
		br.Name = "lbl_mode6";
		br.Size = new Size(29, 12);
		br.TabIndex = 1;
		br.Text = "Mode";
		f2.DropDownStyle = ComboBoxStyle.DropDownList;
		f2.DropDownWidth = 160;
		f2.FormattingEnabled = true;
		f2.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		f2.Location = new Point(167, 87);
		f2.Name = "cb_Rbuttonlong6";
		f2.Size = new Size(80, 20);
		f2.TabIndex = 21;
		he.SetColumnSpan(ge, 2);
		ge.DropDownStyle = ComboBoxStyle.DropDownList;
		ge.FormattingEnabled = true;
		ge.Items.AddRange(new object[16]
		{
			"NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER", "NONE", "MF_CLASSIC_1K",
			"MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER"
		});
		ge.Location = new Point(79, 143);
		ge.Name = "cb_ledred6";
		ge.Size = new Size(172, 20);
		ge.TabIndex = 25;
		f3.DropDownStyle = ComboBoxStyle.DropDownList;
		f3.DropDownWidth = 160;
		f3.FormattingEnabled = true;
		f3.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		f3.Location = new Point(167, 59);
		f3.Name = "cb_Rbutton6";
		f3.Size = new Size(80, 20);
		f3.TabIndex = 20;
		he.SetColumnSpan(bs, 2);
		bs.DropDownStyle = ComboBoxStyle.DropDownList;
		bs.FormattingEnabled = true;
		bs.Items.AddRange(new object[8] { "NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER" });
		bs.Location = new Point(79, 3);
		bs.Name = "cb_mode6";
		bs.Size = new Size(172, 20);
		bs.TabIndex = 0;
		he.SetColumnSpan(bl, 2);
		bl.Location = new Point(79, 171);
		bl.Name = "txt_size6";
		bl.ReadOnly = true;
		bl.Size = new Size(172, 21);
		bl.TabIndex = 15;
		he.SetColumnSpan(gf, 2);
		gf.DropDownStyle = ComboBoxStyle.DropDownList;
		gf.FormattingEnabled = true;
		gf.Items.AddRange(new object[16]
		{
			"NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER", "NONE", "MF_CLASSIC_1K",
			"MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER"
		});
		gf.Location = new Point(79, 115);
		gf.Name = "cb_ledgreen6";
		gf.Size = new Size(172, 20);
		gf.TabIndex = 24;
		bq.AutoSize = true;
		bq.Location = new Point(3, 28);
		bq.Name = "lbl_uid6";
		bq.Size = new Size(23, 12);
		bq.TabIndex = 2;
		bq.Text = "UID";
		gg.AutoSize = true;
		gg.Location = new Point(3, 140);
		gg.Name = "lb_ledledred6";
		gg.Size = new Size(41, 12);
		gg.TabIndex = 23;
		gg.Text = "LEDRed";
		bo.AutoSize = true;
		bo.Location = new Point(3, 56);
		bo.Name = "lbl_button6";
		bo.Size = new Size(41, 12);
		bo.TabIndex = 4;
		bo.Text = "Button";
		ee.DropDownStyle = ComboBoxStyle.DropDownList;
		ee.DropDownWidth = 160;
		ee.FormattingEnabled = true;
		ee.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		ee.Location = new Point(79, 87);
		ee.Name = "cb_Lbuttonlong6";
		ee.Size = new Size(80, 20);
		ee.TabIndex = 19;
		gh.AutoSize = true;
		gh.Location = new Point(3, 112);
		gh.Name = "lb_ledledgreen6";
		gh.Size = new Size(53, 12);
		gh.TabIndex = 22;
		gh.Text = "LEDGreen";
		ef.AutoSize = true;
		ef.Location = new Point(3, 84);
		ef.Name = "lbl_buttonlong6";
		ef.Size = new Size(47, 12);
		ef.TabIndex = 18;
		ef.Text = "BtnLong";
		bn.DropDownStyle = ComboBoxStyle.DropDownList;
		bn.DropDownWidth = 160;
		bn.FormattingEnabled = true;
		bn.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		bn.Location = new Point(79, 59);
		bn.Name = "cb_Lbutton6";
		bn.Size = new Size(80, 20);
		bn.TabIndex = 5;
		bm.AutoSize = true;
		bm.Location = new Point(3, 168);
		bm.Name = "lbl_size6";
		bm.Size = new Size(29, 12);
		bm.TabIndex = 14;
		bm.Text = "Size";
		he.SetColumnSpan(bp, 2);
		bp.Location = new Point(79, 31);
		bp.Name = "txt_uid6";
		bp.Size = new Size(172, 21);
		bp.TabIndex = 3;
		bt.BackColor = Color.Transparent;
		bt.e(SystemColors.ControlLight);
		bt.f(SystemColors.ControlLightLight);
		bt.e(5);
		bt.e(1f);
		bt.Controls.Add(g9);
		bt.Location = new Point(6, 23);
		bt.Name = "gb_tagslot1";
		bt.Size = new Size(278, 181);
		bt.TabIndex = 25;
		bt.TabStop = false;
		g9.AllowDrop = true;
		g9.ColumnCount = 3;
		g9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
		g9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));
		g9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));
		g9.Controls.Add(bz, 0, 1);
		g9.Controls.Add(bw, 1, 6);
		g9.Controls.Add(ga, 1, 5);
		g9.Controls.Add(b0, 0, 2);
		g9.Controls.Add(gb, 1, 4);
		g9.Controls.Add(fu, 2, 3);
		g9.Controls.Add(eg, 1, 3);
		g9.Controls.Add(gc, 0, 5);
		g9.Controls.Add(fv, 2, 2);
		g9.Controls.Add(by, 1, 2);
		g9.Controls.Add(eh, 0, 3);
		g9.Controls.Add(gd, 0, 4);
		g9.Controls.Add(bx, 0, 6);
		g9.Controls.Add(bv, 1, 0);
		g9.Controls.Add(bu, 0, 0);
		g9.Controls.Add(b1, 1, 1);
		g9.Location = new Point(9, 17);
		g9.Name = "tableLayoutPanel1";
		g9.RowCount = 7;
		g9.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		g9.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		g9.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		g9.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		g9.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		g9.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		g9.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		g9.Size = new Size(254, 197);
		g9.TabIndex = 37;
		g9.DragDrop += a;
		g9.DragEnter += b;
		bz.AutoSize = true;
		bz.Location = new Point(3, 28);
		bz.Name = "lbl_uid1";
		bz.Size = new Size(23, 12);
		bz.TabIndex = 2;
		bz.Text = "UID";
		g9.SetColumnSpan(bw, 2);
		bw.Location = new Point(79, 171);
		bw.Name = "txt_size1";
		bw.ReadOnly = true;
		bw.Size = new Size(172, 21);
		bw.TabIndex = 9;
		g9.SetColumnSpan(ga, 2);
		ga.DropDownStyle = ComboBoxStyle.DropDownList;
		ga.FormattingEnabled = true;
		ga.Items.AddRange(new object[16]
		{
			"NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER", "NONE", "MF_CLASSIC_1K",
			"MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER"
		});
		ga.Location = new Point(79, 143);
		ga.Name = "cb_ledred1";
		ga.Size = new Size(172, 20);
		ga.TabIndex = 17;
		b0.AutoSize = true;
		b0.Location = new Point(3, 56);
		b0.Name = "lbl_button1";
		b0.Size = new Size(41, 12);
		b0.TabIndex = 4;
		b0.Text = "Button";
		g9.SetColumnSpan(gb, 2);
		gb.DropDownStyle = ComboBoxStyle.DropDownList;
		gb.FormattingEnabled = true;
		gb.Items.AddRange(new object[16]
		{
			"NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER", "NONE", "MF_CLASSIC_1K",
			"MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER"
		});
		gb.Location = new Point(79, 115);
		gb.Name = "cb_ledgreen1";
		gb.Size = new Size(172, 20);
		gb.TabIndex = 16;
		fu.DropDownStyle = ComboBoxStyle.DropDownList;
		fu.DropDownWidth = 160;
		fu.FormattingEnabled = true;
		fu.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		fu.Location = new Point(167, 87);
		fu.Name = "cb_Rbuttonlong1";
		fu.Size = new Size(84, 20);
		fu.TabIndex = 13;
		eg.DropDownStyle = ComboBoxStyle.DropDownList;
		eg.DropDownWidth = 160;
		eg.FormattingEnabled = true;
		eg.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		eg.Location = new Point(79, 87);
		eg.Name = "cb_Lbuttonlong1";
		eg.Size = new Size(82, 20);
		eg.TabIndex = 11;
		gc.AutoSize = true;
		gc.Location = new Point(3, 140);
		gc.Name = "lb_ledledred1";
		gc.Size = new Size(41, 12);
		gc.TabIndex = 15;
		gc.Text = "LEDRed";
		fv.DropDownStyle = ComboBoxStyle.DropDownList;
		fv.DropDownWidth = 160;
		fv.FormattingEnabled = true;
		fv.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		fv.Location = new Point(167, 59);
		fv.Name = "cb_Rbutton1";
		fv.Size = new Size(84, 20);
		fv.TabIndex = 12;
		by.DropDownStyle = ComboBoxStyle.DropDownList;
		by.DropDownWidth = 160;
		by.FormattingEnabled = true;
		by.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		by.Location = new Point(79, 59);
		by.Name = "cb_Lbutton1";
		by.Size = new Size(82, 20);
		by.TabIndex = 5;
		eh.AutoSize = true;
		eh.Location = new Point(3, 84);
		eh.Name = "lbl_buttonlong1";
		eh.Size = new Size(47, 12);
		eh.TabIndex = 10;
		eh.Text = "BtnLong";
		gd.AutoSize = true;
		gd.Location = new Point(3, 112);
		gd.Name = "lb_ledledgreen1";
		gd.Size = new Size(53, 12);
		gd.TabIndex = 14;
		gd.Text = "LEDGreen";
		bx.AutoSize = true;
		bx.Location = new Point(3, 168);
		bx.Name = "lbl_size1";
		bx.Size = new Size(29, 12);
		bx.TabIndex = 8;
		bx.Text = "Size";
		g9.SetColumnSpan(bv, 2);
		bv.DropDownStyle = ComboBoxStyle.DropDownList;
		bv.FormattingEnabled = true;
		bv.Items.AddRange(new object[8] { "NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER" });
		bv.Location = new Point(79, 3);
		bv.Name = "cb_mode1";
		bv.Size = new Size(172, 20);
		bv.TabIndex = 0;
		bu.AutoSize = true;
		bu.Location = new Point(3, 0);
		bu.Name = "lbl_mode1";
		bu.Size = new Size(29, 12);
		bu.TabIndex = 1;
		bu.Text = "Mode";
		g9.SetColumnSpan(b1, 2);
		b1.Location = new Point(79, 31);
		b1.Name = "txt_uid1";
		b1.Size = new Size(172, 21);
		b1.TabIndex = 3;
		b2.e(SystemColors.ControlLight);
		b2.f(SystemColors.ControlLightLight);
		b2.e(5);
		b2.e(1f);
		b2.Controls.Add(ha);
		b2.Location = new Point(297, 23);
		b2.Name = "gb_tagslot2";
		b2.Size = new Size(278, 181);
		b2.TabIndex = 24;
		b2.TabStop = false;
		ha.AllowDrop = true;
		ha.ColumnCount = 3;
		ha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
		ha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));
		ha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));
		ha.Controls.Add(b9, 0, 0);
		ha.Controls.Add(fw, 2, 3);
		ha.Controls.Add(gj, 1, 4);
		ha.Controls.Add(fx, 2, 2);
		ha.Controls.Add(gi, 1, 5);
		ha.Controls.Add(b5, 1, 2);
		ha.Controls.Add(ei, 1, 3);
		ha.Controls.Add(ca, 1, 0);
		ha.Controls.Add(b8, 0, 1);
		ha.Controls.Add(gk, 0, 5);
		ha.Controls.Add(b7, 1, 1);
		ha.Controls.Add(gl, 0, 4);
		ha.Controls.Add(b3, 1, 6);
		ha.Controls.Add(b6, 0, 2);
		ha.Controls.Add(b4, 0, 6);
		ha.Controls.Add(ej, 0, 3);
		ha.Location = new Point(9, 17);
		ha.Name = "tableLayoutPanel2";
		ha.RowCount = 7;
		ha.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		ha.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		ha.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		ha.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		ha.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		ha.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		ha.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		ha.Size = new Size(254, 197);
		ha.TabIndex = 22;
		ha.DragDrop += a;
		ha.DragEnter += b;
		b9.AutoSize = true;
		b9.Location = new Point(3, 0);
		b9.Name = "lbl_mode2";
		b9.Size = new Size(29, 12);
		b9.TabIndex = 1;
		b9.Text = "Mode";
		fw.DropDownStyle = ComboBoxStyle.DropDownList;
		fw.DropDownWidth = 160;
		fw.FormattingEnabled = true;
		fw.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		fw.Location = new Point(167, 87);
		fw.Name = "cb_Rbuttonlong2";
		fw.Size = new Size(80, 20);
		fw.TabIndex = 15;
		ha.SetColumnSpan(gj, 2);
		gj.DropDownStyle = ComboBoxStyle.DropDownList;
		gj.FormattingEnabled = true;
		gj.Items.AddRange(new object[8] { "NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER" });
		gj.Location = new Point(79, 115);
		gj.Name = "cb_ledgreen2";
		gj.Size = new Size(172, 20);
		gj.TabIndex = 20;
		fx.DropDownStyle = ComboBoxStyle.DropDownList;
		fx.DropDownWidth = 160;
		fx.FormattingEnabled = true;
		fx.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		fx.Location = new Point(167, 59);
		fx.Name = "cb_Rbutton2";
		fx.Size = new Size(80, 20);
		fx.TabIndex = 14;
		ha.SetColumnSpan(gi, 2);
		gi.DropDownStyle = ComboBoxStyle.DropDownList;
		gi.FormattingEnabled = true;
		gi.Items.AddRange(new object[8] { "NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER" });
		gi.Location = new Point(79, 143);
		gi.Name = "cb_ledred2";
		gi.Size = new Size(172, 20);
		gi.TabIndex = 21;
		b5.DropDownStyle = ComboBoxStyle.DropDownList;
		b5.DropDownWidth = 160;
		b5.FormattingEnabled = true;
		b5.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		b5.Location = new Point(79, 59);
		b5.Name = "cb_Lbutton2";
		b5.Size = new Size(80, 20);
		b5.TabIndex = 5;
		ei.DropDownStyle = ComboBoxStyle.DropDownList;
		ei.DropDownWidth = 160;
		ei.FormattingEnabled = true;
		ei.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		ei.Location = new Point(79, 87);
		ei.Name = "cb_Lbuttonlong2";
		ei.Size = new Size(80, 20);
		ei.TabIndex = 13;
		ha.SetColumnSpan(ca, 2);
		ca.DropDownStyle = ComboBoxStyle.DropDownList;
		ca.FormattingEnabled = true;
		ca.Items.AddRange(new object[8] { "NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER" });
		ca.Location = new Point(79, 3);
		ca.Name = "cb_mode2";
		ca.Size = new Size(172, 20);
		ca.TabIndex = 0;
		b8.AutoSize = true;
		b8.Location = new Point(3, 28);
		b8.Name = "lbl_uid2";
		b8.Size = new Size(23, 12);
		b8.TabIndex = 2;
		b8.Text = "UID";
		gk.AutoSize = true;
		gk.Location = new Point(3, 140);
		gk.Name = "lb_ledledred2";
		gk.Size = new Size(41, 12);
		gk.TabIndex = 19;
		gk.Text = "LEDRed";
		ha.SetColumnSpan(b7, 2);
		b7.Location = new Point(79, 31);
		b7.Name = "txt_uid2";
		b7.Size = new Size(172, 21);
		b7.TabIndex = 3;
		gl.AutoSize = true;
		gl.Location = new Point(3, 112);
		gl.Name = "lb_ledledgreen2";
		gl.Size = new Size(53, 12);
		gl.TabIndex = 18;
		gl.Text = "LEDGreen";
		ha.SetColumnSpan(b3, 2);
		b3.Location = new Point(79, 171);
		b3.Name = "txt_size2";
		b3.ReadOnly = true;
		b3.Size = new Size(172, 21);
		b3.TabIndex = 7;
		b6.AutoSize = true;
		b6.Location = new Point(3, 56);
		b6.Name = "lbl_button2";
		b6.Size = new Size(41, 12);
		b6.TabIndex = 4;
		b6.Text = "Button";
		b4.AutoSize = true;
		b4.Location = new Point(3, 168);
		b4.Name = "lbl_size2";
		b4.Size = new Size(29, 12);
		b4.TabIndex = 6;
		b4.Text = "Size";
		ej.AutoSize = true;
		ej.Location = new Point(3, 84);
		ej.Name = "lbl_buttonlong2";
		ej.Size = new Size(47, 12);
		ej.TabIndex = 12;
		ej.Text = "BtnLong";
		cb.e(SystemColors.ControlLight);
		cb.f(SystemColors.ControlLightLight);
		cb.e(5);
		cb.e(1f);
		cb.Controls.Add(hc);
		cb.Location = new Point(876, 23);
		cb.Name = "gb_tagslot4";
		cb.Size = new Size(278, 181);
		cb.TabIndex = 23;
		cb.TabStop = false;
		hc.AllowDrop = true;
		hc.ColumnCount = 3;
		hc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
		hc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));
		hc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));
		hc.Controls.Add(ci, 0, 0);
		hc.Controls.Add(f0, 2, 3);
		hc.Controls.Add(gm, 1, 5);
		hc.Controls.Add(f1, 2, 2);
		hc.Controls.Add(ch, 0, 1);
		hc.Controls.Add(cc, 1, 6);
		hc.Controls.Add(gn, 1, 4);
		hc.Controls.Add(cf, 0, 2);
		hc.Controls.Add(go, 0, 5);
		hc.Controls.Add(el, 0, 3);
		hc.Controls.Add(ek, 1, 3);
		hc.Controls.Add(gp, 0, 4);
		hc.Controls.Add(cd, 0, 6);
		hc.Controls.Add(ce, 1, 2);
		hc.Controls.Add(cj, 1, 0);
		hc.Controls.Add(cg, 1, 1);
		hc.Location = new Point(9, 17);
		hc.Name = "tableLayoutPanel4";
		hc.RowCount = 7;
		hc.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hc.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hc.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hc.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hc.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hc.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hc.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hc.Size = new Size(254, 197);
		hc.TabIndex = 22;
		hc.DragDrop += a;
		hc.DragEnter += b;
		ci.AutoSize = true;
		ci.Location = new Point(3, 0);
		ci.Name = "lbl_mode4";
		ci.Size = new Size(29, 12);
		ci.TabIndex = 1;
		ci.Text = "Mode";
		f0.DropDownStyle = ComboBoxStyle.DropDownList;
		f0.DropDownWidth = 160;
		f0.FormattingEnabled = true;
		f0.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		f0.Location = new Point(167, 87);
		f0.Name = "cb_Rbuttonlong4";
		f0.Size = new Size(80, 20);
		f0.TabIndex = 17;
		hc.SetColumnSpan(gm, 2);
		gm.DropDownStyle = ComboBoxStyle.DropDownList;
		gm.FormattingEnabled = true;
		gm.Items.AddRange(new object[8] { "NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER" });
		gm.Location = new Point(79, 143);
		gm.Name = "cb_ledred4";
		gm.Size = new Size(172, 20);
		gm.TabIndex = 21;
		f1.DropDownStyle = ComboBoxStyle.DropDownList;
		f1.DropDownWidth = 160;
		f1.FormattingEnabled = true;
		f1.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		f1.Location = new Point(167, 59);
		f1.Name = "cb_Rbutton4";
		f1.Size = new Size(80, 20);
		f1.TabIndex = 16;
		ch.AutoSize = true;
		ch.Location = new Point(3, 28);
		ch.Name = "lbl_uid4";
		ch.Size = new Size(23, 12);
		ch.TabIndex = 2;
		ch.Text = "UID";
		hc.SetColumnSpan(cc, 2);
		cc.Location = new Point(79, 171);
		cc.Name = "txt_size4";
		cc.ReadOnly = true;
		cc.Size = new Size(172, 21);
		cc.TabIndex = 13;
		hc.SetColumnSpan(gn, 2);
		gn.DropDownStyle = ComboBoxStyle.DropDownList;
		gn.FormattingEnabled = true;
		gn.Items.AddRange(new object[8] { "NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER" });
		gn.Location = new Point(79, 115);
		gn.Name = "cb_ledgreen4";
		gn.Size = new Size(172, 20);
		gn.TabIndex = 20;
		cf.AutoSize = true;
		cf.Location = new Point(3, 56);
		cf.Name = "lbl_button4";
		cf.Size = new Size(41, 12);
		cf.TabIndex = 4;
		cf.Text = "Button";
		go.AutoSize = true;
		go.Location = new Point(3, 140);
		go.Name = "lb_ledledred4";
		go.Size = new Size(41, 12);
		go.TabIndex = 19;
		go.Text = "LEDRed";
		el.AutoSize = true;
		el.Location = new Point(3, 84);
		el.Name = "lbl_buttonlong4";
		el.Size = new Size(47, 12);
		el.TabIndex = 14;
		el.Text = "BtnLong";
		ek.DropDownStyle = ComboBoxStyle.DropDownList;
		ek.DropDownWidth = 160;
		ek.FormattingEnabled = true;
		ek.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		ek.Location = new Point(79, 87);
		ek.Name = "cb_Lbuttonlong4";
		ek.Size = new Size(80, 20);
		ek.TabIndex = 15;
		gp.AutoSize = true;
		gp.Location = new Point(3, 112);
		gp.Name = "lb_ledledgreen4";
		gp.Size = new Size(53, 12);
		gp.TabIndex = 18;
		gp.Text = "LEDGreen";
		cd.AutoSize = true;
		cd.Location = new Point(3, 168);
		cd.Name = "lbl_size4";
		cd.Size = new Size(29, 12);
		cd.TabIndex = 12;
		cd.Text = "Size";
		ce.DropDownStyle = ComboBoxStyle.DropDownList;
		ce.DropDownWidth = 160;
		ce.FormattingEnabled = true;
		ce.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		ce.Location = new Point(79, 59);
		ce.Name = "cb_Lbutton4";
		ce.Size = new Size(80, 20);
		ce.TabIndex = 5;
		hc.SetColumnSpan(cj, 2);
		cj.DropDownStyle = ComboBoxStyle.DropDownList;
		cj.FormattingEnabled = true;
		cj.Items.AddRange(new object[8] { "NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER" });
		cj.Location = new Point(79, 3);
		cj.Name = "cb_mode4";
		cj.Size = new Size(172, 20);
		cj.TabIndex = 0;
		hc.SetColumnSpan(cg, 2);
		cg.Location = new Point(79, 31);
		cg.Name = "txt_uid4";
		cg.Size = new Size(172, 21);
		cg.TabIndex = 3;
		ck.e(SystemColors.ControlLight);
		ck.f(SystemColors.ControlLightLight);
		ck.e(5);
		ck.e(1f);
		ck.Controls.Add(hb);
		ck.Location = new Point(588, 23);
		ck.Name = "gb_tagslot3";
		ck.Size = new Size(278, 181);
		ck.TabIndex = 22;
		ck.TabStop = false;
		hb.AllowDrop = true;
		hb.ColumnCount = 3;
		hb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
		hb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));
		hb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));
		hb.Controls.Add(cr, 0, 0);
		hb.Controls.Add(fy, 2, 3);
		hb.Controls.Add(gq, 1, 5);
		hb.Controls.Add(fz, 2, 2);
		hb.Controls.Add(cq, 0, 1);
		hb.Controls.Add(cl, 1, 6);
		hb.Controls.Add(gr, 1, 4);
		hb.Controls.Add(co, 0, 2);
		hb.Controls.Add(gs, 0, 5);
		hb.Controls.Add(en, 0, 3);
		hb.Controls.Add(em, 1, 3);
		hb.Controls.Add(gt, 0, 4);
		hb.Controls.Add(cm, 0, 6);
		hb.Controls.Add(cn, 1, 2);
		hb.Controls.Add(cs, 1, 0);
		hb.Controls.Add(cp, 1, 1);
		hb.Location = new Point(9, 17);
		hb.Name = "tableLayoutPanel3";
		hb.RowCount = 7;
		hb.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hb.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hb.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hb.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hb.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hb.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hb.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hb.Size = new Size(254, 197);
		hb.TabIndex = 22;
		hb.DragDrop += a;
		hb.DragEnter += b;
		cr.AutoSize = true;
		cr.Location = new Point(3, 0);
		cr.Name = "lbl_mode3";
		cr.Size = new Size(29, 12);
		cr.TabIndex = 1;
		cr.Text = "Mode";
		fy.DropDownStyle = ComboBoxStyle.DropDownList;
		fy.DropDownWidth = 160;
		fy.FormattingEnabled = true;
		fy.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		fy.Location = new Point(167, 87);
		fy.Name = "cb_Rbuttonlong3";
		fy.Size = new Size(80, 20);
		fy.TabIndex = 17;
		hb.SetColumnSpan(gq, 2);
		gq.DropDownStyle = ComboBoxStyle.DropDownList;
		gq.FormattingEnabled = true;
		gq.Items.AddRange(new object[8] { "NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER" });
		gq.Location = new Point(79, 143);
		gq.Name = "cb_ledred3";
		gq.Size = new Size(172, 20);
		gq.TabIndex = 21;
		fz.DropDownStyle = ComboBoxStyle.DropDownList;
		fz.DropDownWidth = 160;
		fz.FormattingEnabled = true;
		fz.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		fz.Location = new Point(167, 59);
		fz.Name = "cb_Rbutton3";
		fz.Size = new Size(80, 20);
		fz.TabIndex = 16;
		cq.AutoSize = true;
		cq.Location = new Point(3, 28);
		cq.Name = "lbl_uid3";
		cq.Size = new Size(23, 12);
		cq.TabIndex = 2;
		cq.Text = "UID";
		hb.SetColumnSpan(cl, 2);
		cl.Location = new Point(79, 171);
		cl.Name = "txt_size3";
		cl.ReadOnly = true;
		cl.Size = new Size(172, 21);
		cl.TabIndex = 11;
		hb.SetColumnSpan(gr, 2);
		gr.DropDownStyle = ComboBoxStyle.DropDownList;
		gr.FormattingEnabled = true;
		gr.Items.AddRange(new object[8] { "NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER" });
		gr.Location = new Point(79, 115);
		gr.Name = "cb_ledgreen3";
		gr.Size = new Size(172, 20);
		gr.TabIndex = 20;
		co.AutoSize = true;
		co.Location = new Point(3, 56);
		co.Name = "lbl_button3";
		co.Size = new Size(41, 12);
		co.TabIndex = 4;
		co.Text = "Button";
		gs.AutoSize = true;
		gs.Location = new Point(3, 140);
		gs.Name = "lb_ledledred3";
		gs.Size = new Size(41, 12);
		gs.TabIndex = 19;
		gs.Text = "LEDRed";
		en.AutoSize = true;
		en.Location = new Point(3, 84);
		en.Name = "lbl_buttonlong3";
		en.Size = new Size(47, 12);
		en.TabIndex = 14;
		en.Text = "BtnLong";
		em.DropDownStyle = ComboBoxStyle.DropDownList;
		em.DropDownWidth = 160;
		em.FormattingEnabled = true;
		em.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		em.Location = new Point(79, 87);
		em.Name = "cb_Lbuttonlong3";
		em.Size = new Size(80, 20);
		em.TabIndex = 15;
		gt.AutoSize = true;
		gt.Location = new Point(3, 112);
		gt.Name = "lb_ledledgreen3";
		gt.Size = new Size(53, 12);
		gt.TabIndex = 18;
		gt.Text = "LEDGreen";
		cm.AutoSize = true;
		cm.Location = new Point(3, 168);
		cm.Name = "lbl_size3";
		cm.Size = new Size(29, 12);
		cm.TabIndex = 10;
		cm.Text = "Size";
		cn.DropDownStyle = ComboBoxStyle.DropDownList;
		cn.DropDownWidth = 160;
		cn.FormattingEnabled = true;
		cn.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		cn.Location = new Point(79, 59);
		cn.Name = "cb_Lbutton3";
		cn.Size = new Size(80, 20);
		cn.TabIndex = 5;
		hb.SetColumnSpan(cs, 2);
		cs.DropDownStyle = ComboBoxStyle.DropDownList;
		cs.FormattingEnabled = true;
		cs.Items.AddRange(new object[8] { "NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER" });
		cs.Location = new Point(79, 3);
		cs.Name = "cb_mode3";
		cs.Size = new Size(172, 20);
		cs.TabIndex = 0;
		hb.SetColumnSpan(cp, 2);
		cp.Location = new Point(79, 31);
		cp.Name = "txt_uid3";
		cp.Size = new Size(172, 21);
		cp.TabIndex = 3;
		ct.e(SystemColors.ControlLight);
		ct.f(SystemColors.ControlLightLight);
		ct.e(5);
		ct.e(1f);
		ct.Controls.Add(hd);
		ct.Location = new Point(3, 227);
		ct.Name = "gb_tagslot5";
		ct.Size = new Size(278, 181);
		ct.TabIndex = 21;
		ct.TabStop = false;
		hd.AllowDrop = true;
		hd.ColumnCount = 3;
		hd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
		hd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));
		hd.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));
		hd.Controls.Add(c0, 0, 0);
		hd.Controls.Add(f8, 2, 3);
		hd.Controls.Add(gu, 1, 5);
		hd.Controls.Add(f9, 2, 2);
		hd.Controls.Add(cz, 0, 1);
		hd.Controls.Add(cu, 1, 6);
		hd.Controls.Add(gv, 1, 4);
		hd.Controls.Add(cx, 0, 2);
		hd.Controls.Add(gw, 0, 5);
		hd.Controls.Add(ep, 0, 3);
		hd.Controls.Add(eo, 1, 3);
		hd.Controls.Add(gx, 0, 4);
		hd.Controls.Add(cv, 0, 6);
		hd.Controls.Add(cw, 1, 2);
		hd.Controls.Add(c1, 1, 0);
		hd.Controls.Add(cy, 1, 1);
		hd.Location = new Point(9, 16);
		hd.Name = "tableLayoutPanel5";
		hd.RowCount = 7;
		hd.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hd.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hd.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hd.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hd.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hd.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hd.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hd.Size = new Size(254, 197);
		hd.TabIndex = 24;
		hd.DragDrop += a;
		hd.DragEnter += b;
		c0.AutoSize = true;
		c0.Location = new Point(3, 0);
		c0.Name = "lbl_mode5";
		c0.Size = new Size(29, 12);
		c0.TabIndex = 1;
		c0.Text = "Mode";
		f8.DropDownStyle = ComboBoxStyle.DropDownList;
		f8.DropDownWidth = 160;
		f8.FormattingEnabled = true;
		f8.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		f8.Location = new Point(167, 87);
		f8.Name = "cb_Rbuttonlong5";
		f8.Size = new Size(80, 20);
		f8.TabIndex = 19;
		hd.SetColumnSpan(gu, 2);
		gu.DropDownStyle = ComboBoxStyle.DropDownList;
		gu.FormattingEnabled = true;
		gu.Items.AddRange(new object[8] { "NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER" });
		gu.Location = new Point(79, 143);
		gu.Name = "cb_ledred5";
		gu.Size = new Size(172, 20);
		gu.TabIndex = 23;
		f9.DropDownStyle = ComboBoxStyle.DropDownList;
		f9.DropDownWidth = 160;
		f9.FormattingEnabled = true;
		f9.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		f9.Location = new Point(167, 59);
		f9.Name = "cb_Rbutton5";
		f9.Size = new Size(80, 20);
		f9.TabIndex = 18;
		cz.AutoSize = true;
		cz.Location = new Point(3, 28);
		cz.Name = "lbl_uid5";
		cz.Size = new Size(23, 12);
		cz.TabIndex = 2;
		cz.Text = "UID";
		hd.SetColumnSpan(cu, 2);
		cu.Location = new Point(79, 171);
		cu.Name = "txt_size5";
		cu.ReadOnly = true;
		cu.Size = new Size(172, 21);
		cu.TabIndex = 15;
		hd.SetColumnSpan(gv, 2);
		gv.DropDownStyle = ComboBoxStyle.DropDownList;
		gv.FormattingEnabled = true;
		gv.Items.AddRange(new object[8] { "NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER" });
		gv.Location = new Point(79, 115);
		gv.Name = "cb_ledgreen5";
		gv.Size = new Size(172, 20);
		gv.TabIndex = 22;
		cx.AutoSize = true;
		cx.Location = new Point(3, 56);
		cx.Name = "lbl_button5";
		cx.Size = new Size(41, 12);
		cx.TabIndex = 4;
		cx.Text = "Button";
		gw.AutoSize = true;
		gw.Location = new Point(3, 140);
		gw.Name = "lb_ledledred5";
		gw.Size = new Size(41, 12);
		gw.TabIndex = 21;
		gw.Text = "LEDRed";
		ep.AutoSize = true;
		ep.Location = new Point(3, 84);
		ep.Name = "lbl_buttonlong5";
		ep.Size = new Size(47, 12);
		ep.TabIndex = 16;
		ep.Text = "BtnLong";
		eo.DropDownStyle = ComboBoxStyle.DropDownList;
		eo.DropDownWidth = 160;
		eo.FormattingEnabled = true;
		eo.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		eo.Location = new Point(79, 87);
		eo.Name = "cb_Lbuttonlong5";
		eo.Size = new Size(80, 20);
		eo.TabIndex = 17;
		gx.AutoSize = true;
		gx.Location = new Point(3, 112);
		gx.Name = "lb_ledledgreen5";
		gx.Size = new Size(53, 12);
		gx.TabIndex = 20;
		gx.Text = "LEDGreen";
		cv.AutoSize = true;
		cv.Location = new Point(3, 168);
		cv.Name = "lbl_size5";
		cv.Size = new Size(29, 12);
		cv.TabIndex = 14;
		cv.Text = "Size";
		cw.DropDownStyle = ComboBoxStyle.DropDownList;
		cw.DropDownWidth = 160;
		cw.FormattingEnabled = true;
		cw.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		cw.Location = new Point(79, 59);
		cw.Name = "cb_Lbutton5";
		cw.Size = new Size(80, 20);
		cw.TabIndex = 5;
		hd.SetColumnSpan(c1, 2);
		c1.DropDownStyle = ComboBoxStyle.DropDownList;
		c1.FormattingEnabled = true;
		c1.Items.AddRange(new object[8] { "NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER" });
		c1.Location = new Point(79, 3);
		c1.Name = "cb_mode5";
		c1.Size = new Size(172, 20);
		c1.TabIndex = 0;
		hd.SetColumnSpan(cy, 2);
		cy.Location = new Point(79, 31);
		cy.Name = "txt_uid5";
		cy.Size = new Size(172, 21);
		cy.TabIndex = 3;
		c2.e(SystemColors.ControlLight);
		c2.f(SystemColors.ControlLightLight);
		c2.e(5);
		c2.e(1f);
		c2.Controls.Add(hf);
		c2.Location = new Point(585, 227);
		c2.Name = "gb_tagslot7";
		c2.Size = new Size(278, 181);
		c2.TabIndex = 27;
		c2.TabStop = false;
		hf.AllowDrop = true;
		hf.ColumnCount = 3;
		hf.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
		hf.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));
		hf.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));
		hf.Controls.Add(c9, 0, 0);
		hf.Controls.Add(f4, 2, 3);
		hf.Controls.Add(gy, 1, 5);
		hf.Controls.Add(f5, 2, 2);
		hf.Controls.Add(c8, 0, 1);
		hf.Controls.Add(c3, 1, 6);
		hf.Controls.Add(gz, 1, 4);
		hf.Controls.Add(c6, 0, 2);
		hf.Controls.Add(g0, 0, 5);
		hf.Controls.Add(er, 0, 3);
		hf.Controls.Add(eq, 1, 3);
		hf.Controls.Add(g1, 0, 4);
		hf.Controls.Add(c4, 0, 6);
		hf.Controls.Add(c5, 1, 2);
		hf.Controls.Add(da, 1, 0);
		hf.Controls.Add(c7, 1, 1);
		hf.Location = new Point(9, 16);
		hf.Name = "tableLayoutPanel7";
		hf.RowCount = 7;
		hf.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hf.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hf.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hf.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hf.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hf.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hf.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hf.Size = new Size(254, 197);
		hf.TabIndex = 26;
		hf.DragDrop += a;
		hf.DragEnter += b;
		c9.AutoSize = true;
		c9.Location = new Point(3, 0);
		c9.Name = "lbl_mode7";
		c9.Size = new Size(29, 12);
		c9.TabIndex = 1;
		c9.Text = "Mode";
		f4.DropDownStyle = ComboBoxStyle.DropDownList;
		f4.DropDownWidth = 160;
		f4.FormattingEnabled = true;
		f4.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		f4.Location = new Point(167, 87);
		f4.Name = "cb_Rbuttonlong7";
		f4.Size = new Size(80, 20);
		f4.TabIndex = 21;
		hf.SetColumnSpan(gy, 2);
		gy.DropDownStyle = ComboBoxStyle.DropDownList;
		gy.FormattingEnabled = true;
		gy.Items.AddRange(new object[8] { "NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER" });
		gy.Location = new Point(79, 143);
		gy.Name = "cb_ledred7";
		gy.Size = new Size(172, 20);
		gy.TabIndex = 25;
		f5.DropDownStyle = ComboBoxStyle.DropDownList;
		f5.DropDownWidth = 160;
		f5.FormattingEnabled = true;
		f5.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		f5.Location = new Point(167, 59);
		f5.Name = "cb_Rbutton7";
		f5.Size = new Size(80, 20);
		f5.TabIndex = 20;
		c8.AutoSize = true;
		c8.Location = new Point(3, 28);
		c8.Name = "lbl_uid7";
		c8.Size = new Size(23, 12);
		c8.TabIndex = 2;
		c8.Text = "UID";
		hf.SetColumnSpan(c3, 2);
		c3.Location = new Point(79, 171);
		c3.Name = "txt_size7";
		c3.ReadOnly = true;
		c3.Size = new Size(172, 21);
		c3.TabIndex = 15;
		hf.SetColumnSpan(gz, 2);
		gz.DropDownStyle = ComboBoxStyle.DropDownList;
		gz.FormattingEnabled = true;
		gz.Items.AddRange(new object[8] { "NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER" });
		gz.Location = new Point(79, 115);
		gz.Name = "cb_ledgreen7";
		gz.Size = new Size(172, 20);
		gz.TabIndex = 24;
		c6.AutoSize = true;
		c6.Location = new Point(3, 56);
		c6.Name = "lbl_button7";
		c6.Size = new Size(41, 12);
		c6.TabIndex = 4;
		c6.Text = "Button";
		g0.AutoSize = true;
		g0.Location = new Point(3, 140);
		g0.Name = "lb_ledledred7";
		g0.Size = new Size(41, 12);
		g0.TabIndex = 23;
		g0.Text = "LEDRed";
		er.AutoSize = true;
		er.Location = new Point(3, 84);
		er.Name = "lbl_buttonlong7";
		er.Size = new Size(47, 12);
		er.TabIndex = 18;
		er.Text = "BtnLong";
		eq.DropDownStyle = ComboBoxStyle.DropDownList;
		eq.DropDownWidth = 160;
		eq.FormattingEnabled = true;
		eq.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		eq.Location = new Point(79, 87);
		eq.Name = "cb_Lbuttonlong7";
		eq.Size = new Size(80, 20);
		eq.TabIndex = 19;
		g1.AutoSize = true;
		g1.Location = new Point(3, 112);
		g1.Name = "lb_ledledgreen7";
		g1.Size = new Size(53, 12);
		g1.TabIndex = 22;
		g1.Text = "LEDGreen";
		c4.AutoSize = true;
		c4.Location = new Point(3, 168);
		c4.Name = "lbl_size7";
		c4.Size = new Size(29, 12);
		c4.TabIndex = 14;
		c4.Text = "Size";
		c5.DropDownStyle = ComboBoxStyle.DropDownList;
		c5.DropDownWidth = 160;
		c5.FormattingEnabled = true;
		c5.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		c5.Location = new Point(79, 59);
		c5.Name = "cb_Lbutton7";
		c5.Size = new Size(80, 20);
		c5.TabIndex = 5;
		hf.SetColumnSpan(da, 2);
		da.DropDownStyle = ComboBoxStyle.DropDownList;
		da.FormattingEnabled = true;
		da.Items.AddRange(new object[8] { "NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER" });
		da.Location = new Point(79, 3);
		da.Name = "cb_mode7";
		da.Size = new Size(172, 20);
		da.TabIndex = 0;
		hf.SetColumnSpan(c7, 2);
		c7.Location = new Point(79, 31);
		c7.Name = "txt_uid7";
		c7.Size = new Size(172, 21);
		c7.TabIndex = 3;
		db.e(SystemColors.ControlLight);
		db.f(SystemColors.ControlLightLight);
		db.e(5);
		db.e(1f);
		db.Controls.Add(hg);
		db.Location = new Point(876, 227);
		db.Name = "gb_tagslot8";
		db.Size = new Size(278, 181);
		db.TabIndex = 20;
		db.TabStop = false;
		hg.AllowDrop = true;
		hg.ColumnCount = 3;
		hg.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
		hg.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));
		hg.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));
		hg.Controls.Add(di, 0, 0);
		hg.Controls.Add(f6, 2, 3);
		hg.Controls.Add(g2, 1, 5);
		hg.Controls.Add(f7, 2, 2);
		hg.Controls.Add(dh, 0, 1);
		hg.Controls.Add(dc, 1, 6);
		hg.Controls.Add(g3, 1, 4);
		hg.Controls.Add(df, 0, 2);
		hg.Controls.Add(g4, 0, 5);
		hg.Controls.Add(et, 0, 3);
		hg.Controls.Add(es, 1, 3);
		hg.Controls.Add(g5, 0, 4);
		hg.Controls.Add(dd, 0, 6);
		hg.Controls.Add(de, 1, 2);
		hg.Controls.Add(dj, 1, 0);
		hg.Controls.Add(dg, 1, 1);
		hg.Location = new Point(9, 16);
		hg.Name = "tableLayoutPanel8";
		hg.RowCount = 7;
		hg.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hg.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hg.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hg.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hg.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hg.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hg.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		hg.Size = new Size(254, 197);
		hg.TabIndex = 26;
		hg.DragDrop += a;
		hg.DragEnter += b;
		di.AutoSize = true;
		di.Location = new Point(3, 0);
		di.Name = "lbl_mode8";
		di.Size = new Size(29, 12);
		di.TabIndex = 1;
		di.Text = "Mode";
		f6.DropDownStyle = ComboBoxStyle.DropDownList;
		f6.DropDownWidth = 160;
		f6.FormattingEnabled = true;
		f6.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		f6.Location = new Point(167, 87);
		f6.Name = "cb_Rbuttonlong8";
		f6.Size = new Size(80, 20);
		f6.TabIndex = 21;
		hg.SetColumnSpan(g2, 2);
		g2.DropDownStyle = ComboBoxStyle.DropDownList;
		g2.FormattingEnabled = true;
		g2.Items.AddRange(new object[8] { "NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER" });
		g2.Location = new Point(79, 143);
		g2.Name = "cb_ledred8";
		g2.Size = new Size(172, 20);
		g2.TabIndex = 25;
		f7.DropDownStyle = ComboBoxStyle.DropDownList;
		f7.DropDownWidth = 160;
		f7.FormattingEnabled = true;
		f7.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		f7.Location = new Point(167, 59);
		f7.Name = "cb_Rbutton8";
		f7.Size = new Size(80, 20);
		f7.TabIndex = 20;
		dh.AutoSize = true;
		dh.Location = new Point(3, 28);
		dh.Name = "lbl_uid8";
		dh.Size = new Size(23, 12);
		dh.TabIndex = 2;
		dh.Text = "UID";
		hg.SetColumnSpan(dc, 2);
		dc.Location = new Point(79, 171);
		dc.Name = "txt_size8";
		dc.ReadOnly = true;
		dc.Size = new Size(172, 21);
		dc.TabIndex = 17;
		hg.SetColumnSpan(g3, 2);
		g3.DropDownStyle = ComboBoxStyle.DropDownList;
		g3.FormattingEnabled = true;
		g3.Items.AddRange(new object[8] { "NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER" });
		g3.Location = new Point(79, 115);
		g3.Name = "cb_ledgreen8";
		g3.Size = new Size(172, 20);
		g3.TabIndex = 24;
		df.AutoSize = true;
		df.Location = new Point(3, 56);
		df.Name = "lbl_button8";
		df.Size = new Size(41, 12);
		df.TabIndex = 4;
		df.Text = "Button";
		g4.AutoSize = true;
		g4.Location = new Point(3, 140);
		g4.Name = "lb_ledledred8";
		g4.Size = new Size(41, 12);
		g4.TabIndex = 23;
		g4.Text = "LEDRed";
		et.AutoSize = true;
		et.Location = new Point(3, 84);
		et.Name = "lbl_buttonlong8";
		et.Size = new Size(47, 12);
		et.TabIndex = 18;
		et.Text = "BtnLong";
		es.DropDownStyle = ComboBoxStyle.DropDownList;
		es.DropDownWidth = 160;
		es.FormattingEnabled = true;
		es.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		es.Location = new Point(79, 87);
		es.Name = "cb_Lbuttonlong8";
		es.Size = new Size(80, 20);
		es.TabIndex = 19;
		g5.AutoSize = true;
		g5.Location = new Point(3, 112);
		g5.Name = "lb_ledledgreen8";
		g5.Size = new Size(53, 12);
		g5.TabIndex = 22;
		g5.Text = "LEDGreen";
		dd.AutoSize = true;
		dd.Location = new Point(3, 168);
		dd.Name = "lbl_size8";
		dd.Size = new Size(29, 12);
		dd.TabIndex = 16;
		dd.Text = "Size";
		de.DropDownStyle = ComboBoxStyle.DropDownList;
		de.DropDownWidth = 160;
		de.FormattingEnabled = true;
		de.Items.AddRange(new object[12]
		{
			"NONE", "UID_RANDOM", "UID_LEFT_INCREMENT", "UID_RIGHT_INCREMENT", "UID_LEFT_DECREMENT", "UID_RIGHT_DECREMENT", "CYCLE_SETTINGS", "STORE_MEM", "RECALL_MEM", "TOGGLE_FIELD",
			"STORE_LOG", "CLONE"
		});
		de.Location = new Point(79, 59);
		de.Name = "cb_Lbutton8";
		de.Size = new Size(80, 20);
		de.TabIndex = 5;
		hg.SetColumnSpan(dj, 2);
		dj.DropDownStyle = ComboBoxStyle.DropDownList;
		dj.FormattingEnabled = true;
		dj.Items.AddRange(new object[8] { "NONE", "MF_CLASSIC_1K", "MF_CLASSIC_1K_7B", "MF_CLASSIC_4K", "MF_CLASSIC_4K_7B", "MF_ULTRALIGHT", "ISO14443A_SNIFF", "ISO14443A_READER" });
		dj.Location = new Point(79, 3);
		dj.Name = "cb_mode8";
		dj.Size = new Size(172, 20);
		dj.TabIndex = 0;
		hg.SetColumnSpan(dg, 2);
		dg.Location = new Point(79, 31);
		dg.Name = "txt_uid8";
		dg.Size = new Size(172, 21);
		dg.TabIndex = 3;
		dk.Controls.Add(d7);
		dk.Controls.Add(this.m_a4);
		dk.Controls.Add(fb);
		dk.Controls.Add(this.m_av);
		dk.Location = new Point(8, 11);
		dk.Name = "tabControl1";
		dk.SelectedIndex = 0;
		dk.Size = new Size(1168, 532);
		dk.TabIndex = 8;
		d7.AllowDrop = true;
		d7.ContextMenuStrip = e2;
		d7.Controls.Add(hm);
		d7.Controls.Add(fo);
		d7.Controls.Add(fp);
		d7.Controls.Add(fq);
		d7.Controls.Add(fa);
		d7.Controls.Add(e7);
		d7.Controls.Add(e0);
		d7.Controls.Add(ey);
		d7.Controls.Add(ez);
		d7.Controls.Add(eu);
		d7.Controls.Add(ev);
		d7.Controls.Add(ew);
		d7.Controls.Add(ex);
		d7.Controls.Add(ea);
		d7.Controls.Add(eb);
		d7.Controls.Add(ec);
		d7.Controls.Add(ed);
		d7.Controls.Add(d8);
		d7.Controls.Add(d9);
		d7.Location = new Point(4, 22);
		d7.Name = "tpDump";
		d7.Size = new Size(1160, 506);
		d7.TabIndex = 4;
		d7.Text = "Dump Management";
		d7.UseVisualStyleBackColor = true;
		d7.DragDrop += c;
		d7.DragEnter += d;
		d7.MouseEnter += ar;
		e2.ImageScalingSize = new Size(24, 24);
		e2.Items.AddRange(new ToolStripItem[2] { e3, fr });
		e2.Name = "menuScroll";
		e2.Size = new Size(184, 48);
		e2.ItemClicked += b;
		e3.Name = "toolStripMenuItem1";
		e3.Size = new Size(183, 22);
		e3.Text = "Toggle Sync Scroll";
		fr.Name = "toolStripMenuItem2";
		fr.Size = new Size(183, 22);
		fr.Text = "Close Files";
		hm.BackColor = Color.Transparent;
		hm.Controls.Add(h0);
		hm.Controls.Add(hy);
		hm.Controls.Add(ht);
		hm.Controls.Add(hs);
		hm.Controls.Add(hk);
		hm.Controls.Add(hl);
		hm.Controls.Add(hj);
		hm.Controls.Add(hi);
		hm.Controls.Add(hn);
		hm.Controls.Add(ho);
		hm.Controls.Add(hp);
		hm.Controls.Add(hq);
		hm.Controls.Add(hr);
		hm.Location = new Point(6, 6);
		hm.Name = "groupBox1";
		hm.Size = new Size(1148, 55);
		hm.TabIndex = 39;
		hm.TabStop = false;
		hm.Text = "读卡器操作区";
		h0.ImeMode = ImeMode.NoControl;
		h0.Location = new Point(573, 20);
		h0.Name = "button10";
		h0.Size = new Size(85, 25);
		h0.TabIndex = 44;
		h0.Text = "停止运行";
		h0.UseVisualStyleBackColor = true;
		h0.Click += l;
		hy.ImeMode = ImeMode.NoControl;
		hy.Location = new Point(770, 20);
		hy.Name = "button5";
		hy.Size = new Size(85, 25);
		hy.TabIndex = 43;
		hy.Text = "删除历史密钥";
		hy.UseVisualStyleBackColor = true;
		hy.Click += u;
		ht.ImeMode = ImeMode.NoControl;
		ht.Location = new Point(952, 20);
		ht.Name = "button3";
		ht.Size = new Size(97, 25);
		ht.TabIndex = 40;
		ht.Text = "PCR532专业版";
		ht.UseVisualStyleBackColor = true;
		hs.ForeColor = Color.Black;
		hs.ImeMode = ImeMode.NoControl;
		hs.Location = new Point(1055, 20);
		hs.Name = "button1";
		hs.Size = new Size(85, 25);
		hs.TabIndex = 42;
		hs.Text = "变色龙模式";
		hs.UseVisualStyleBackColor = true;
		hs.Click += ac;
		hk.BackColor = Color.Transparent;
		hk.ForeColor = Color.Black;
		hk.ImeMode = ImeMode.NoControl;
		hk.Location = new Point(101, 20);
		hk.Name = "button2";
		hk.Size = new Size(94, 25);
		hk.TabIndex = 41;
		hk.Text = "连接设备";
		hk.UseVisualStyleBackColor = false;
		hk.Click += ad;
		hl.BackColor = SystemColors.ButtonFace;
		hl.DropDownStyle = ComboBoxStyle.DropDownList;
		hl.FormattingEnabled = true;
		hl.ItemHeight = 12;
		hl.Location = new Point(9, 23);
		hl.Name = "CB_S2";
		hl.Size = new Size(90, 20);
		hl.TabIndex = 40;
		hl.DropDown += y;
		hl.SelectedIndexChanged += aa;
		hj.ImeMode = ImeMode.NoControl;
		hj.Location = new Point(861, 20);
		hj.Name = "appdownload";
		hj.Size = new Size(85, 25);
		hj.TabIndex = 25;
		hj.Text = "手机APP下载";
		hj.UseVisualStyleBackColor = true;
		hj.Click += t;
		hi.ImeMode = ImeMode.NoControl;
		hi.Location = new Point(679, 20);
		hi.Name = "clearhis";
		hi.Size = new Size(85, 25);
		hi.TabIndex = 39;
		hi.Text = "编辑历史密钥";
		hi.UseVisualStyleBackColor = true;
		hi.Click += w;
		hn.AutoSize = true;
		hn.ImeMode = ImeMode.NoControl;
		hn.Location = new Point(13, 20);
		hn.Name = "linkLabel7";
		hn.Size = new Size(0, 12);
		hn.TabIndex = 0;
		ho.ForeColor = Color.Black;
		ho.ImeMode = ImeMode.NoControl;
		ho.Location = new Point(213, 20);
		ho.Name = "button_OKEY";
		ho.Size = new Size(85, 25);
		ho.TabIndex = 20;
		ho.Text = "开始解卡";
		ho.UseVisualStyleBackColor = true;
		ho.Click += v;
		hp.ForeColor = Color.Black;
		hp.ImeMode = ImeMode.NoControl;
		hp.Location = new Point(303, 20);
		hp.Name = "ONE_KEY_WRITE";
		hp.Size = new Size(85, 25);
		hp.TabIndex = 23;
		hp.Text = "一键写卡";
		hp.UseVisualStyleBackColor = true;
		hp.Click += s;
		hq.ForeColor = Color.Black;
		hq.ImeMode = ImeMode.NoControl;
		hq.Location = new Point(393, 20);
		hq.Name = "button9";
		hq.Size = new Size(85, 25);
		hq.TabIndex = 24;
		hq.Text = "格式化";
		hq.UseVisualStyleBackColor = true;
		hq.Click += p;
		hr.ImeMode = ImeMode.NoControl;
		hr.Location = new Point(483, 20);
		hr.Name = "button13";
		hr.Size = new Size(85, 25);
		hr.TabIndex = 30;
		hr.Text = "锁UFUID";
		hr.UseVisualStyleBackColor = true;
		hr.Click += o;
		fo.AutoSize = true;
		fo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		fo.Expanded = false;
		fo.Items = null;
		fo.Location = new Point(958, 63);
		fo.Margin = new Padding(4, 5, 4, 5);
		fo.MaximumSize = new Size(180, 277);
		fo.Name = "ucLegend1";
		fo.Size = new Size(180, 41);
		fo.TabIndex = 22;
		fo.Title = "Legend";
		fp.Location = new Point(758, 89);
		fp.Name = "btn_close2";
		fp.Size = new Size(80, 21);
		fp.TabIndex = 24;
		fp.Text = "Close";
		fp.UseVisualStyleBackColor = true;
		fp.Click += ak;
		fq.Location = new Point(186, 89);
		fq.Name = "btn_close1";
		fq.Size = new Size(80, 21);
		fq.TabIndex = 23;
		fq.Text = "Close";
		fq.UseVisualStyleBackColor = true;
		fq.Click += al;
		fa.AutoSize = true;
		fa.Location = new Point(580, 66);
		fa.Name = "lbl_template";
		fa.Size = new Size(59, 12);
		fa.TabIndex = 21;
		fa.Text = "Template:";
		e7.DataSource = e8;
		e7.FormattingEnabled = true;
		e7.Location = new Point(640, 63);
		e7.Name = "cb_templateA";
		e7.Size = new Size(151, 20);
		e7.TabIndex = 20;
		e7.SelectedIndexChanged += bh;
		e0.AutoSize = true;
		e0.Location = new Point(356, 66);
		e0.Name = "chkSyncScroll";
		e0.Size = new Size(150, 16);
		e0.TabIndex = 18;
		e0.Text = "Synchronize scrolling";
		e0.UseVisualStyleBackColor = true;
		ey.AutoSize = true;
		ey.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		ey.Location = new Point(581, 483);
		ey.Name = "lbl_hbfilename2";
		ey.Size = new Size(30, 13);
		ey.TabIndex = 17;
		ey.Text = "N/A";
		ez.AutoSize = true;
		ez.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		ez.Location = new Point(7, 483);
		ez.Name = "lbl_hbfilename1";
		ez.Size = new Size(30, 13);
		ez.TabIndex = 15;
		ez.Text = "N/A";
		eu.AutoSize = true;
		eu.Location = new Point(259, 65);
		eu.Name = "rbtn_bytewidth16";
		eu.Size = new Size(65, 16);
		eu.TabIndex = 14;
		eu.Text = "16-byte";
		eu.UseVisualStyleBackColor = true;
		eu.CheckedChanged += at;
		ev.AutoSize = true;
		ev.Location = new Point(174, 65);
		ev.Name = "rbtn_bytewidth08";
		ev.Size = new Size(59, 16);
		ev.TabIndex = 13;
		ev.Text = "8-byte";
		ev.UseVisualStyleBackColor = true;
		ev.CheckedChanged += at;
		ew.AutoSize = true;
		ew.Checked = true;
		ew.Location = new Point(96, 67);
		ew.Name = "rbtn_bytewidth04";
		ew.Size = new Size(59, 16);
		ew.TabIndex = 12;
		ew.TabStop = true;
		ew.Text = "4-byte";
		ew.UseVisualStyleBackColor = true;
		ew.CheckedChanged += at;
		ex.AutoSize = true;
		ex.Location = new Point(19, 69);
		ex.Name = "lbl_bytewidth";
		ex.Size = new Size(71, 12);
		ex.TabIndex = 11;
		ex.Text = "Byte width:";
		ea.Location = new Point(672, 89);
		ea.Name = "btn_save2";
		ea.Size = new Size(80, 21);
		ea.TabIndex = 8;
		ea.Text = "Save";
		ea.UseVisualStyleBackColor = true;
		ea.Click += au;
		eb.Location = new Point(586, 89);
		eb.Name = "btn_open2";
		eb.Size = new Size(80, 21);
		eb.TabIndex = 7;
		eb.Text = "Open";
		eb.UseVisualStyleBackColor = true;
		eb.Click += av;
		ec.Location = new Point(100, 89);
		ec.Name = "btn_save1";
		ec.Size = new Size(80, 21);
		ec.TabIndex = 6;
		ec.Text = "Save";
		ec.UseVisualStyleBackColor = true;
		ec.Click += aw;
		ed.Location = new Point(14, 89);
		ed.Name = "btn_open1";
		ed.Size = new Size(80, 21);
		ed.TabIndex = 5;
		ed.Text = "Open";
		ed.UseVisualStyleBackColor = true;
		ed.Click += ax;
		d8.ColumnInfoVisible = true;
		d8.Font = new Font("Segoe UI", 9f);
		d8.GroupSeparatorVisible = true;
		d8.GroupSize = 8;
		d8.LineInfoVisible = true;
		d8.Location = new Point(584, 116);
		d8.Name = "hexBox2";
		d8.ShadowSelectionColor = Color.FromArgb(100, 60, 188, 255);
		d8.Size = new Size(570, 364);
		d8.StringViewVisible = true;
		d8.TabIndex = 2;
		d8.UseFixedBytesPerLine = true;
		d8.VScrollBarVisible = true;
		d8.ByteProviderWriteFinished += @as;
		d8.VScrollBarChanged += a;
		d8.ToggleSyncScrollPressed += aq;
		d8.MouseEnter += ap;
		d9.ColumnInfoVisible = true;
		d9.Font = new Font("Segoe UI", 9f);
		d9.GroupSeparatorVisible = true;
		d9.GroupSize = 8;
		d9.LineInfoVisible = true;
		d9.Location = new Point(10, 116);
		d9.Name = "hexBox1";
		d9.ShadowSelectionColor = Color.FromArgb(100, 60, 188, 255);
		d9.Size = new Size(570, 364);
		d9.StringViewVisible = true;
		d9.TabIndex = 1;
		d9.UseFixedBytesPerLine = true;
		d9.VScrollBarVisible = true;
		d9.ByteProviderWriteFinished += @as;
		d9.VScrollBarChanged += b;
		d9.ToggleSyncScrollPressed += aq;
		d9.MouseEnter += ap;
		fb.Controls.Add(fm);
		fb.Location = new Point(4, 22);
		fb.Name = "tpSerial";
		fb.Padding = new Padding(3);
		fb.Size = new Size(1160, 506);
		fb.TabIndex = 5;
		fb.Text = "Serial";
		fb.UseVisualStyleBackColor = true;
		fm.Controls.Add(ff);
		fm.Controls.Add(fl);
		fm.Dock = DockStyle.Fill;
		fm.Location = new Point(3, 3);
		fm.Name = "flowLayoutPanel1";
		fm.Padding = new Padding(10, 9, 10, 9);
		fm.Size = new Size(1154, 500);
		fm.TabIndex = 9;
		ff.Controls.Add(g7);
		ff.Controls.Add(fh);
		ff.Controls.Add(fg);
		ff.Location = new Point(13, 12);
		ff.Name = "gbAvailableCmds";
		ff.Size = new Size(190, 581);
		ff.TabIndex = 7;
		ff.TabStop = false;
		ff.Text = "Available commands";
		g6.SetToolTip(ff, "Did you know that you can click on the command below to copy it to the command textbox?");
		g7.AutoScroll = true;
		g7.AutoSize = true;
		g7.AvailableCommands = null;
		g7.BackColor = SystemColors.ControlLightLight;
		g7.Dock = DockStyle.Bottom;
		g7.Location = new Point(3, 78);
		g7.Name = "tfSerialHelp";
		g7.Size = new Size(184, 500);
		g7.TabIndex = 8;
		g7.TextClick += af;
		fh.AutoSize = true;
		fh.Location = new Point(14, 41);
		fh.Name = "linkRevG";
		fh.Size = new Size(119, 12);
		fh.TabIndex = 7;
		fh.TabStop = true;
		fh.Text = "Official Rev G Wiki";
		fh.LinkClicked += a;
		fg.AutoSize = true;
		fg.Location = new Point(14, 20);
		fg.Name = "linkRevE";
		fg.Size = new Size(119, 12);
		fg.TabIndex = 4;
		fg.TabStop = true;
		fg.Text = "Rev E rebooted Wiki";
		fg.LinkClicked += b;
		fl.Controls.Add(fn);
		fl.Controls.Add(fd);
		fl.Controls.Add(fe);
		fl.Controls.Add(fc);
		fl.Location = new Point(209, 12);
		fl.Name = "gbSerial_interface";
		fl.Size = new Size(811, 485);
		fl.TabIndex = 8;
		fl.TabStop = false;
		fl.Text = "Serial interface";
		fn.Enabled = false;
		fn.Location = new Point(252, 18);
		fn.Name = "btnSerialSend";
		fn.Size = new Size(75, 21);
		fn.TabIndex = 3;
		fn.Text = "Send";
		fn.UseVisualStyleBackColor = true;
		fn.Click += am;
		fd.Location = new Point(3, 20);
		fd.Name = "tbSerialCmd";
		fd.Size = new Size(229, 21);
		fd.TabIndex = 1;
		fd.KeyPress += a;
		fe.Location = new Point(465, 18);
		fe.Name = "btnClearCmd";
		fe.Size = new Size(75, 21);
		fe.TabIndex = 2;
		fe.Text = "Clear";
		fe.UseVisualStyleBackColor = true;
		fe.Click += an;
		fc.BackColor = Color.Gray;
		fc.ContextMenuStrip = fi;
		fc.Font = new Font("Courier New", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		fc.ForeColor = Color.White;
		fc.Location = new Point(3, 49);
		fc.Margin = new Padding(10, 9, 10, 9);
		fc.Name = "tbSerialOutput";
		fc.Size = new Size(806, 424);
		fc.TabIndex = 0;
		fc.Text = "";
		fi.ImageScalingSize = new Size(24, 24);
		fi.Items.AddRange(new ToolStripItem[3] { hh, fj, fk });
		fi.Name = "menuClear";
		fi.Size = new Size(129, 70);
		fi.ItemClicked += a;
		hh.Name = "tsmi_selectall";
		hh.Size = new Size(128, 22);
		hh.Text = "Select All";
		fj.Name = "tsmi_clear";
		fj.Size = new Size(128, 22);
		fj.Text = "Clear";
		fk.Name = "tsmi_copy";
		fk.Size = new Size(128, 22);
		fk.Text = "Copy";
		fs.FileName = "openFileDialog2";
		base.AutoScaleDimensions = new SizeF(6f, 12f);
		base.AutoScaleMode = AutoScaleMode.Font;
		AutoScroll = true;
		base.ClientSize = new Size(1184, 711);
		base.Controls.Add(dk);
		base.Controls.Add(this.m_au);
		DoubleBuffered = true;
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.MaximizeBox = false;
		MaximumSize = new Size(1200, 750);
		base.Name = "frm_main";
		base.TopMost = true;
		base.Activated += aj;
		base.FormClosed += a;
		base.Load += bj;
		base.ResizeBegin += ai;
		base.ResizeEnd += ah;
		this.m_au.ResumeLayout(performLayout: false);
		this.m_au.PerformLayout();
		((ISupportInitialize)e5).EndInit();
		this.m_av.ResumeLayout(performLayout: false);
		e6.ResumeLayout(performLayout: false);
		dx.ResumeLayout(performLayout: false);
		dx.PerformLayout();
		dy.ResumeLayout(performLayout: false);
		dy.PerformLayout();
		((ISupportInitialize)e1).EndInit();
		dl.ResumeLayout(performLayout: false);
		dl.PerformLayout();
		this.m_aw.ResumeLayout(performLayout: false);
		this.m_aw.PerformLayout();
		this.m_a0.ResumeLayout(performLayout: false);
		this.m_a0.PerformLayout();
		this.m_a4.ResumeLayout(performLayout: false);
		this.m_a4.PerformLayout();
		this.m_bd.ResumeLayout(performLayout: false);
		this.m_bd.PerformLayout();
		bk.ResumeLayout(performLayout: false);
		he.ResumeLayout(performLayout: false);
		he.PerformLayout();
		bt.ResumeLayout(performLayout: false);
		g9.ResumeLayout(performLayout: false);
		g9.PerformLayout();
		b2.ResumeLayout(performLayout: false);
		ha.ResumeLayout(performLayout: false);
		ha.PerformLayout();
		cb.ResumeLayout(performLayout: false);
		hc.ResumeLayout(performLayout: false);
		hc.PerformLayout();
		ck.ResumeLayout(performLayout: false);
		hb.ResumeLayout(performLayout: false);
		hb.PerformLayout();
		ct.ResumeLayout(performLayout: false);
		hd.ResumeLayout(performLayout: false);
		hd.PerformLayout();
		c2.ResumeLayout(performLayout: false);
		hf.ResumeLayout(performLayout: false);
		hf.PerformLayout();
		db.ResumeLayout(performLayout: false);
		hg.ResumeLayout(performLayout: false);
		hg.PerformLayout();
		dk.ResumeLayout(performLayout: false);
		d7.ResumeLayout(performLayout: false);
		d7.PerformLayout();
		e2.ResumeLayout(performLayout: false);
		hm.ResumeLayout(performLayout: false);
		hm.PerformLayout();
		((ISupportInitialize)e8).EndInit();
		fb.ResumeLayout(performLayout: false);
		fm.ResumeLayout(performLayout: false);
		ff.ResumeLayout(performLayout: false);
		ff.PerformLayout();
		fl.ResumeLayout(performLayout: false);
		fl.PerformLayout();
		fi.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private void m(ComboBox A_0)
	{
		short num = 12488;
		short num2 = num;
		num = 12488;
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
		n($"LBUTTON{this.m_i}={A_0.SelectedItem}");
	}

	[CompilerGenerated]
	private void l(ComboBox A_0)
	{
		short num = 31122;
		short num2 = num;
		num = 31122;
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
		n($"LBUTTON_LONG{this.m_i}={A_0.SelectedItem}");
	}

	[CompilerGenerated]
	private void k(ComboBox A_0)
	{
		short num = 24864;
		short num2 = num;
		num = 24864;
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
		n($"RBUTTON{this.m_i}={A_0.SelectedItem}");
	}

	[CompilerGenerated]
	private void j(ComboBox A_0)
	{
		short num = -10320;
		short num2 = num;
		num = -10320;
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
		n($"RBUTTON_LONG{this.m_i}={A_0.SelectedItem}");
	}

	[CompilerGenerated]
	private void i(ComboBox A_0)
	{
		short num = -5525;
		short num2 = num;
		num = -5525;
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
		n($"BUTTON{this.m_i}={A_0.SelectedItem}");
	}

	[CompilerGenerated]
	private void h(ComboBox A_0)
	{
		short num = 4066;
		short num2 = num;
		num = 4066;
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
		n($"BUTTON_LONG{this.m_i}={A_0.SelectedItem}");
	}

	[CompilerGenerated]
	private KeyValuePair<int, byte[]> b(CheckBox A_0)
	{
		short num = -14669;
		short num2 = num;
		num = -14669;
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
		int num3 = int.Parse(A_0.Name.Substring(A_0.Name.Length - 1));
		n($"SETTING{this.m_i}={num3 - this.m_p}");
		byte[] value = m("DETECTION" + this.m_i + "?") as byte[];
		return new KeyValuePair<int, byte[]>(num3, value);
	}

	[CompilerGenerated]
	private void g(ComboBox A_0)
	{
		short num = 24524;
		short num2 = num;
		num = 24524;
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
		n("CONFIG" + this.m_i + "=NONE");
	}

	[CompilerGenerated]
	private void f(ComboBox A_0)
	{
		short num = -8398;
		short num2 = num;
		num = -8398;
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
		n($"LBUTTON{this.m_i}={A_0.Items[0]}");
	}

	[CompilerGenerated]
	private void e(ComboBox A_0)
	{
		short num = 26897;
		short num2 = num;
		num = 26897;
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
		n($"LBUTTON_LONG{this.m_i}={A_0.Items[0]}");
	}

	[CompilerGenerated]
	private void d(ComboBox A_0)
	{
		short num = -18583;
		short num2 = num;
		num = -18583;
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
		n($"RBUTTON{this.m_i}={A_0.Items[0]}");
	}

	[CompilerGenerated]
	private void c(ComboBox A_0)
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
		num = 20656;
		short num2 = num;
		num = 20656;
		switch (num2 == num)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		n($"RBUTTON_LONG{this.m_i}={A_0.Items[0]}");
	}

	[CompilerGenerated]
	private void b(ComboBox A_0)
	{
		short num = 7189;
		short num2 = num;
		num = 7189;
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
		n($"LEDGREEN{this.m_i}={A_0.Items[0]}");
	}

	[CompilerGenerated]
	private void a(ComboBox A_0)
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
		num = 20922;
		short num2 = num;
		num = 20922;
		switch (num2 == num)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		n($"LEDRED{this.m_i}={A_0.Items[0]}");
	}

	[CompilerGenerated]
	private KeyValuePair<int, byte[]> a(CheckBox A_0)
	{
		short num = -30796;
		short num2 = num;
		num = -30796;
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
		int num3 = int.Parse(A_0.Name.Substring(A_0.Name.Length - 1));
		n($"SETTING{this.m_i}={num3 - this.m_p}");
		byte[] value = m("DETECTION" + this.m_i + "?") as byte[];
		return new KeyValuePair<int, byte[]>(num3, value);
	}
}
