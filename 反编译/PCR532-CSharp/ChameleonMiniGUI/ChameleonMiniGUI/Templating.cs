using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Be.Windows.Forms;
using DynamicExpresso;

namespace ChameleonMiniGUI;

public class Templating
{
	[CompilerGenerated]
	private sealed class a
	{
		public string a;

		public string b;

		public string c;

		internal bool d(IlegendItem A_0)
		{
			short num = 1;
			int num2 = num;
			while (true)
			{
				num = -22345;
				short num3 = num;
				num = -22345;
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
					goto IL_007e;
				default:
					{
						num = 0;
						if (num != 0)
						{
						}
						switch (num2)
						{
						case 1:
							break;
						default:
							goto IL_007e;
						case 2:
							goto IL_00bf;
						case 3:
							goto IL_00d7;
						case 0:
							num = 1;
							if (num != 0)
							{
							}
							return A_0.Description == c;
						}
						goto case false;
					}
					IL_00d7:
					if (A_0.ForeGroundColor == b)
					{
						num = 0;
						_ = num;
						num = 0;
						num2 = num;
						continue;
					}
					break;
					IL_007e:
					if (A_0.BackGroundColor == a)
					{
						num = 2;
						num2 = num;
						continue;
					}
					break;
					IL_00bf:
					num = 3;
					num2 = num;
					continue;
				}
				break;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private string m_a;

	public string DirectoryPath
	{
		[CompilerGenerated]
		get
		{
			short num = 0;
			_ = num;
			num = 11337;
			short num2 = num;
			num = 11337;
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
				return this.m_a;
			}
		}
		[CompilerGenerated]
		set
		{
			short num = 0;
			_ = num;
			num = -15397;
			short num2 = num;
			num = -15397;
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
			this.m_a = value;
		}
	}

	public Templating()
	{
		DirectoryPath = Path.Combine(Application.StartupPath, "Templates");
	}

	public void LoadTemplate(HexBox hb, string template, List<IlegendItem> legendItems)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 3;
			int num2 = num;
			string path = default(string);
			Interpreter interpreter = default(Interpreter);
			string[] array = default(string[]);
			int result2 = default(int);
			LegendItem item = default(LegendItem);
			a a = default(a);
			Color foreColor = default(Color);
			Color backColor = default(Color);
			int result = default(int);
			string text = default(string);
			int num4 = default(int);
			string[] array3 = default(string[]);
			while (true)
			{
				switch (num2)
				{
				case 3:
					switch (0)
					{
					default:
						goto end_IL_003f;
					case 0:
						break;
					}
					goto default;
				default:
					if (hb.ByteProvider == null)
					{
						num = 13;
						num2 = num;
						break;
					}
					hb.ClearHighlights();
					path = Path.Combine(DirectoryPath, template);
					num = 16;
					num2 = num;
					break;
				case 13:
					return;
				case 12:
				{
					num = -29464;
					short num3 = num;
					num = -29464;
					switch (num3 == num)
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
									case 4:
										if (!int.TryParse(interpreter.Eval(array[0].Trim()).ToString(), out result2))
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
									case 13:
										num = 1;
										num2 = num;
										continue;
									case 1:
										goto end_IL_030b;
									case 11:
										legendItems.Add(item);
										num = 3;
										num2 = num;
										continue;
									case 5:
										num = 12;
										num2 = num;
										continue;
									case 12:
										goto end_IL_030b;
									case 10:
										a.c = ((array.Length == 5) ? array[4].Trim() : string.Empty);
										foreColor = Color.FromName(a.b);
										backColor = Color.FromName(a.a);
										num = 9;
										num2 = num;
										continue;
									case 9:
										if (hb.ByteProvider.Length < result2 + result)
										{
											num = 5;
											num2 = num;
											continue;
										}
										hb.AddHighlight(result2, result, foreColor, backColor);
										item = new LegendItem
										{
											BackGroundColor = a.a,
											ForeGroundColor = a.b,
											Description = a.c
										};
										num = 6;
										num2 = num;
										continue;
									case 7:
										if (int.TryParse(interpreter.Eval(array[1].Trim()).ToString(), out result))
										{
											a.b = array[2].Trim();
											a.a = array[3].Trim();
											num = 10;
											num2 = num;
										}
										else
										{
											num = 13;
											num2 = num;
										}
										continue;
									case 8:
										num = 2;
										num2 = num;
										continue;
									case 2:
										goto end_IL_030b;
									case 6:
										if (!legendItems.Any(a.d))
										{
											num = 11;
											num2 = num;
											continue;
										}
										goto case 3;
									case 3:
										num = 0;
										num2 = num;
										continue;
									case 0:
										goto end_IL_030b;
									}
									goto case 0;
									continue;
									end_IL_030b:
									break;
								}
								break;
							case 0:
								a = new a();
								num = 4;
								num2 = num;
								goto default;
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show("Template has errors" + Environment.NewLine + text + Environment.NewLine + ex.Message);
						}
						break;
					case false:
					case true:
						break;
					}
					goto case 11;
				}
				case 9:
					array = text.Split(';');
					num = 1;
					num2 = num;
					break;
				case 1:
					if (array.Length >= 4)
					{
						num = 12;
						num2 = num;
					}
					else
					{
						num = 7;
						num2 = num;
					}
					break;
				case 17:
					return;
				case 16:
					if (!File.Exists(path))
					{
						num = 0;
						_ = num;
						num = 17;
						num2 = num;
					}
					else
					{
						num = 10;
						num2 = num;
					}
					break;
				case 7:
					Console.WriteLine($"[-] Error, bad line in template file. {array}");
					num = 11;
					num2 = num;
					break;
				case 2:
				case 4:
					num = 15;
					num2 = num;
					break;
				case 15:
					if (num4 >= array3.Length)
					{
						num = 14;
						num2 = num;
					}
					else
					{
						text = array3[num4];
						num = 0;
						num2 = num;
					}
					break;
				case 0:
					if (!string.IsNullOrWhiteSpace(text))
					{
						num = 6;
						num2 = num;
						break;
					}
					goto case 11;
				case 10:
					if (legendItems == null)
					{
						num = 18;
						num2 = num;
						break;
					}
					goto case 8;
				case 11:
					num4++;
					num = 4;
					num2 = num;
					break;
				case 18:
					num = 1;
					if (num != 0)
					{
					}
					legendItems = new List<IlegendItem>();
					num = 8;
					num2 = num;
					break;
				case 8:
				{
					string[] array2 = File.ReadAllLines(path);
					interpreter = new Interpreter();
					array3 = array2;
					num4 = 0;
					num = 2;
					num2 = num;
					break;
				}
				case 6:
					num = 5;
					num2 = num;
					break;
				case 5:
					if (!text.StartsWith("#"))
					{
						num = 9;
						num2 = num;
						break;
					}
					goto case 11;
				case 14:
					{
						hb.Invalidate();
						return;
					}
					end_IL_003f:
					break;
				}
			}
		}
		}
	}

	public Dictionary<string, string> GetTemplates()
	{
		short num = 0;
		int num2 = num;
		Dictionary<string, string> dictionary = default(Dictionary<string, string>);
		DirectoryInfo directoryInfo = default(DirectoryInfo);
		IOrderedEnumerable<FileInfo> orderedEnumerable = default(IOrderedEnumerable<FileInfo>);
		IEnumerator<FileInfo> enumerator = default(IEnumerator<FileInfo>);
		switch (num2)
		{
		default:
			{
				num = 1;
				if (num != 0)
				{
				}
				switch (0)
				{
				case 0:
					goto IL_006c;
				}
				goto IL_004d;
			}
			IL_006c:
			dictionary = new Dictionary<string, string>();
			directoryInfo = new DirectoryInfo(DirectoryPath);
			num = 0;
			_ = num;
			num = 0;
			num2 = num;
			goto IL_004d;
			IL_004d:
			while (true)
			{
				switch (num2)
				{
				case 0:
					if (!directoryInfo.Exists)
					{
						num = 4;
						num2 = num;
					}
					else
					{
						num = 2;
						num2 = num;
					}
					continue;
				case 3:
				{
					num = -5619;
					short num3 = num;
					num = -5619;
					switch (num3 == num)
					{
					default:
						num = 0;
						if (num != 0)
						{
						}
						return dictionary;
					case false:
					case true:
						break;
					}
					goto IL_030c;
				}
				case 2:
					orderedEnumerable = directoryInfo.GetFiles("*.txt").OrderBy(delegate(FileInfo A_0)
					{
						short num4 = 0;
						_ = num4;
						num4 = 915;
						short num5 = num4;
						num4 = 915;
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
							return A_0.Name;
						}
					});
					num = 5;
					num2 = num;
					continue;
				case 4:
					return dictionary;
				case 1:
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
									goto end_IL_01bf;
								case 0:
									break;
								}
								goto default;
							default:
								num = 1;
								num2 = num;
								break;
							case 1:
								if (enumerator.MoveNext())
								{
									FileInfo current = enumerator.Current;
									dictionary.Add(current.Name.Replace(current.Extension, ""), current.Name);
									num = 3;
									num2 = num;
								}
								else
								{
									num = 4;
									num2 = num;
								}
								break;
							case 4:
								num = 2;
								num2 = num;
								break;
							case 2:
								{
									return dictionary;
								}
								end_IL_01bf:
								break;
							}
						}
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
								if (enumerator != null)
								{
									num = 0;
									num2 = num;
									continue;
								}
								break;
							case 0:
								enumerator.Dispose();
								num = 2;
								num2 = num;
								continue;
							case 2:
								break;
							}
							break;
						}
					}
				case 5:
					{
						if (orderedEnumerable.Any())
						{
							dictionary.Add("Not selected", "----------");
							enumerator = orderedEnumerable.GetEnumerator();
							num = 1;
							num2 = num;
							continue;
						}
						goto IL_030c;
					}
					IL_030c:
					num = 3;
					num2 = num;
					continue;
				}
				break;
			}
			goto IL_006c;
		}
	}
}
