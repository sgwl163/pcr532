using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ChameleonMiniGUI;

public class MultiLanguage
{
	[CompilerGenerated]
	private string m_a;

	public string DirectoryPath
	{
		[CompilerGenerated]
		get
		{
			short num = 0;
			_ = num;
			num = -18864;
			short num2 = num;
			num = -18864;
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
			num = 1;
			if (num != 0)
			{
			}
			num = 6795;
			short num2 = num;
			num = 6795;
			switch (num2 == num)
			{
			}
			num = 0;
			if (num != 0)
			{
			}
			this.m_a = value;
		}
	}

	public MultiLanguage()
	{
		DirectoryPath = Path.Combine(Application.StartupPath, "Languages");
	}

	private static IEnumerable<a> b<a>(ICollection A_0) where a : ToolStrip
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			num = 0;
			_ = num;
			List<a> list = default(List<a>);
			switch (0)
			{
			default:
			{
				Control control = default(Control);
				IEnumerator enumerator = default(IEnumerator);
				IDisposable disposable = default(IDisposable);
				while (true)
				{
					switch (num2)
					{
					case 0:
						if (A_0 != null)
						{
							num = 3;
							num2 = num;
							continue;
						}
						goto case 2;
					case 4:
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
									list.Add(control.ContextMenuStrip as a);
									num = 3;
									num2 = num;
									continue;
								default:
									num = 8;
									num2 = num;
									continue;
								case 8:
									if (enumerator.MoveNext())
									{
										control = (Control)enumerator.Current;
										num = 7;
										num2 = num;
										continue;
									}
									goto IL_0142;
								case 6:
									list.AddRange(b<a>(control.Controls));
									num = 9;
									num2 = num;
									continue;
								case 7:
									if (control.HasChildren)
									{
										num = 6;
										num2 = num;
										continue;
									}
									goto case 9;
								case 9:
									num = 0;
									num2 = num;
									continue;
								case 0:
									if (control.ContextMenuStrip != null)
									{
										num = 1;
										num2 = num;
										continue;
									}
									goto default;
								case 5:
									num = 2;
									num2 = num;
									continue;
								case 2:
									{
										num = 27087;
										short num3 = num;
										num = 27087;
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
											goto end_IL_00c8;
										}
										goto IL_0142;
									}
									IL_0142:
									num = 5;
									num2 = num;
									continue;
									end_IL_00c8:
									break;
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
									case 1:
										if (disposable != null)
										{
											num = 2;
											num2 = num;
											continue;
										}
										goto end_IL_0286;
									case 2:
										disposable.Dispose();
										num = 0;
										num2 = num;
										continue;
									case 0:
										goto end_IL_0286;
									}
									goto case 0;
									continue;
									end_IL_0286:
									break;
								}
								break;
							case 0:
								disposable = enumerator as IDisposable;
								num = 1;
								num2 = num;
								goto default;
							}
						}
						num = 1;
						if (num != 0)
						{
						}
						return list;
					case 3:
						num = 1;
						num2 = num;
						continue;
					case 1:
						if (A_0.Count != 0)
						{
							enumerator = A_0.GetEnumerator();
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
						return list;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				list = new List<a>();
				num = 0;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private static IEnumerable<a> a<a>(ICollection A_0) where a : Control
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			num = 0;
			_ = num;
			List<a> list = default(List<a>);
			switch (0)
			{
			default:
			{
				Control control = default(Control);
				IEnumerator enumerator = default(IEnumerator);
				IDisposable disposable = default(IDisposable);
				while (true)
				{
					switch (num2)
					{
					case 0:
						if (A_0 != null)
						{
							num = 3;
							num2 = num;
							continue;
						}
						goto case 2;
					case 4:
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
									list.Add(control as a);
									num = 3;
									num2 = num;
									continue;
								default:
									num = 8;
									num2 = num;
									continue;
								case 8:
									if (enumerator.MoveNext())
									{
										control = (Control)enumerator.Current;
										num = 7;
										num2 = num;
										continue;
									}
									goto IL_0167;
								case 6:
									list.AddRange(a<a>(control.Controls));
									num = 9;
									num2 = num;
									continue;
								case 7:
									if (control.HasChildren)
									{
										num = 6;
										num2 = num;
										continue;
									}
									goto case 9;
								case 9:
									num = 0;
									num2 = num;
									continue;
								case 0:
									if (!string.IsNullOrWhiteSpace(control.Text))
									{
										num = 1;
										num2 = num;
										continue;
									}
									goto default;
								case 5:
									num = 2;
									num2 = num;
									continue;
								case 2:
									{
										num = 2002;
										short num3 = num;
										num = 2002;
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
											goto end_IL_00f3;
										}
										goto IL_0167;
									}
									IL_0167:
									num = 5;
									num2 = num;
									continue;
									end_IL_00f3:
									break;
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
									case 1:
										if (disposable != null)
										{
											num = 2;
											num2 = num;
											continue;
										}
										goto end_IL_02b0;
									case 2:
										disposable.Dispose();
										num = 0;
										num2 = num;
										continue;
									case 0:
										goto end_IL_02b0;
									}
									goto case 0;
									continue;
									end_IL_02b0:
									break;
								}
								break;
							case 0:
								disposable = enumerator as IDisposable;
								num = 1;
								num2 = num;
								goto default;
							}
						}
						return list;
					case 3:
						num = 1;
						num2 = num;
						continue;
					case 1:
						if (A_0.Count != 0)
						{
							enumerator = A_0.GetEnumerator();
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
						return list;
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
				list = new List<a>();
				num = 0;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private static IEnumerable<a> a<a>(ICollection A_0, string A_1) where a : Control
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
					goto IL_004a;
				}
				goto IL_0027;
			}
			IL_0027:
			while (true)
			{
				switch (num2)
				{
				case 1:
					if (A_0 != null)
					{
						num = 5;
						num2 = num;
						continue;
					}
					goto case 3;
				case 4:
					return list;
				case 3:
					return list;
				case 5:
					num = 6;
					num2 = num;
					continue;
				case 6:
					if (A_0.Count == 0)
					{
						num = 1;
						if (num != 0)
						{
						}
						num = 3;
						num2 = num;
					}
					else
					{
						num = 2;
						num2 = num;
					}
					continue;
				case 0:
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
								num = 3;
								num2 = num;
								continue;
							case 3:
								if (control.Name.ToLowerInvariant().StartsWith(A_1))
								{
									num = 8;
									num2 = num;
									continue;
								}
								goto default;
							case 5:
								if (control.HasChildren)
								{
									num = 9;
									num2 = num;
									continue;
								}
								goto case 1;
							default:
								num = 7;
								num2 = num;
								continue;
							case 7:
								if (enumerator.MoveNext())
								{
									control = (Control)enumerator.Current;
									goto IL_01d7;
								}
								num = 6;
								num2 = num;
								continue;
							case 8:
								list.Add(control as a);
								num = 0;
								num2 = num;
								continue;
							case 9:
								list.AddRange(a<a>(control.Controls, A_1));
								num = 1;
								num2 = num;
								continue;
							case 6:
								num = 2;
								num2 = num;
								continue;
							case 2:
								{
									num = -24990;
									short num3 = num;
									num = -24990;
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
										goto end_IL_0155;
									}
									goto IL_01d7;
								}
								IL_01d7:
								num = 5;
								num2 = num;
								continue;
								end_IL_0155:
								break;
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
								case 1:
									if (disposable != null)
									{
										num = 2;
										num2 = num;
										continue;
									}
									goto end_IL_031c;
								case 2:
									disposable.Dispose();
									num = 0;
									num2 = num;
									continue;
								case 0:
									goto end_IL_031c;
								}
								goto case 0;
								continue;
								end_IL_031c:
								break;
							}
							break;
						case 0:
							disposable = enumerator as IDisposable;
							num = 1;
							num2 = num;
							goto default;
						}
					}
					return list;
				case 2:
					if (!string.IsNullOrWhiteSpace(A_1))
					{
						num = 0;
						_ = num;
						enumerator = A_0.GetEnumerator();
						num = 0;
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
			goto IL_004a;
			IL_004a:
			list = new List<a>();
			num = 1;
			num2 = num;
			goto IL_0027;
		}
	}

	public void GetText(ICollection ctrls)
	{
		IEnumerator<Control> enumerator = a<Control>(ctrls).GetEnumerator();
		short num;
		try
		{
			num = 2;
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
					num = 3;
					num2 = num;
					continue;
				case 3:
					if (enumerator.MoveNext())
					{
						Control current = enumerator.Current;
						Console.WriteLine(current.Name + "=" + current.Text);
						num = 9560;
						short num3 = num;
						num = 9560;
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
						num = 4;
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
					num2 = num;
					continue;
				case 0:
					break;
				}
				break;
			}
		}
		finally
		{
			num = 2;
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
					if (enumerator != null)
					{
						num = 1;
						num2 = num;
						continue;
					}
					break;
				case 1:
					enumerator.Dispose();
					num = 0;
					num2 = num;
					continue;
				case 0:
					break;
				}
				break;
			}
		}
		num = 1;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
	}

	public void LoadLanguage(ICollection ctrls, string lang)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			string path = default(string);
			switch (0)
			{
			default:
			{
				string[] array2 = default(string[]);
				int num4 = default(int);
				IEnumerator enumerator3 = default(IEnumerator);
				ToolStripMenuItem toolStripMenuItem = default(ToolStripMenuItem);
				string text2 = default(string);
				string text3 = default(string);
				IDisposable disposable = default(IDisposable);
				IEnumerator<ToolStrip> enumerator2 = default(IEnumerator<ToolStrip>);
				string text = default(string);
				IEnumerator<Control> enumerator = default(IEnumerator<Control>);
				while (true)
				{
					switch (num2)
					{
					case 8:
						if (!File.Exists(path))
						{
							num = 9;
							num2 = num;
							continue;
						}
						array2 = File.ReadAllLines(path);
						num4 = 0;
						num = 5;
						num2 = num;
						continue;
					case 9:
						return;
					case 2:
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
								case 4:
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
											default:
												num = 2;
												num2 = num;
												continue;
											case 2:
												if (!enumerator3.MoveNext())
												{
													num = 6;
													num2 = num;
												}
												else
												{
													toolStripMenuItem = (ToolStripMenuItem)enumerator3.Current;
													num = 5;
													num2 = num;
												}
												continue;
											case 3:
												toolStripMenuItem.Text = text2;
												num = 1;
												num2 = num;
												continue;
											case 5:
												if (toolStripMenuItem.Name.ToLowerInvariant().StartsWith(text3))
												{
													num = 3;
													num2 = num;
													continue;
												}
												goto default;
											case 6:
												num = 0;
												num2 = num;
												continue;
											case 0:
												break;
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
														num = 1;
														num2 = num;
														continue;
													}
													goto end_IL_022e;
												case 1:
													disposable.Dispose();
													num = 0;
													num2 = num;
													continue;
												case 0:
													goto end_IL_022e;
												}
												goto case 0;
												continue;
												end_IL_022e:
												break;
											}
											break;
										case 0:
											disposable = enumerator3 as IDisposable;
											num = 2;
											num2 = num;
											goto default;
										}
									}
									goto default;
								default:
									num = 3;
									num2 = num;
									continue;
								case 3:
									if (enumerator2.MoveNext())
									{
										enumerator3 = enumerator2.Current.Items.GetEnumerator();
										num = 4;
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
									num2 = num;
									continue;
								case 0:
									break;
								}
								break;
							}
						}
						finally
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
									if (enumerator2 != null)
									{
										num = 1;
										num2 = num;
										continue;
									}
									break;
								case 1:
									enumerator2.Dispose();
									num = 0;
									num2 = num;
									continue;
								case 0:
									break;
								}
								break;
							}
						}
						goto IL_03d1;
					case 4:
						if (!string.IsNullOrWhiteSpace(text))
						{
							num = 1;
							if (num != 0)
							{
							}
							num = 11;
							num2 = num;
							continue;
						}
						goto IL_03d1;
					case 1:
					case 5:
						num = 10;
						num2 = num;
						continue;
					case 10:
						if (num4 < array2.Length)
						{
							text = array2[num4];
							num = 4;
							num2 = num;
						}
						else
						{
							num = 6;
							num2 = num;
						}
						continue;
					case 6:
						return;
					case 7:
					{
						string[] array = text.Split('.');
						text2 = text.Split('=')[1];
						text3 = array[0].ToLowerInvariant();
						enumerator = a<Control>(ctrls, text3).GetEnumerator();
						num = 3;
						num2 = num;
						continue;
					}
					case 3:
						try
						{
							num = 2;
							num2 = num;
							while (true)
							{
								switch (num2)
								{
								case 0:
									break;
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
									num = 3;
									num2 = num;
									continue;
								case 3:
									if (enumerator.MoveNext())
									{
										enumerator.Current.Text = text2;
										num = -14728;
										short num3 = num;
										num = -14728;
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
										num = 4;
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
									num2 = num;
									continue;
								}
								break;
							}
						}
						finally
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
									if (enumerator != null)
									{
										num = 1;
										num2 = num;
										continue;
									}
									break;
								case 1:
									enumerator.Dispose();
									num = 0;
									num2 = num;
									continue;
								case 0:
									break;
								}
								break;
							}
						}
						num = 0;
						_ = num;
						enumerator2 = b<ToolStrip>(ctrls).GetEnumerator();
						num = 2;
						num2 = num;
						continue;
					case 11:
						num = 0;
						num2 = num;
						continue;
					case 0:
						{
							if (!text.StartsWith("#"))
							{
								num = 7;
								num2 = num;
								continue;
							}
							goto IL_03d1;
						}
						IL_03d1:
						num4++;
						num = 1;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				path = Path.Combine(DirectoryPath, lang);
				num = 8;
				num2 = num;
				goto default;
			}
		}
		}
	}

	public Dictionary<string, string> GetLanguages()
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			DirectoryInfo directoryInfo = default(DirectoryInfo);
			Dictionary<string, string> dictionary = default(Dictionary<string, string>);
			switch (0)
			{
			default:
			{
				IEnumerator<FileInfo> enumerator = default(IEnumerator<FileInfo>);
				while (true)
				{
					switch (num2)
					{
					case 1:
						num = 1;
						if (num != 0)
						{
						}
						if (!directoryInfo.Exists)
						{
							num = 3;
							num2 = num;
						}
						else
						{
							num = 2;
							num2 = num;
						}
						continue;
					case 3:
						return dictionary;
					case 2:
						enumerator = directoryInfo.GetFiles("*.txt").OrderBy(delegate(FileInfo A_0)
						{
							short num4 = 29288;
							short num5 = num4;
							num4 = 29288;
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
								num4 = 0;
								_ = num4;
								return A_0.Name;
							}
						}).GetEnumerator();
						num = 0;
						_ = num;
						num = 0;
						num2 = num;
						continue;
					case 0:
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
										goto end_IL_016a;
									case 0:
										break;
									}
									goto default;
								default:
									num = 3;
									num2 = num;
									break;
								case 3:
									if (enumerator.MoveNext())
									{
										FileInfo current = enumerator.Current;
										dictionary.Add(current.Name.Replace(current.Extension, ""), current.Name);
										num = -7253;
										short num3 = num;
										num = -7253;
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
											break;
										}
									}
									else
									{
										num = 1;
										num2 = num;
									}
									break;
								case 1:
									num = 0;
									num2 = num;
									break;
								case 0:
									{
										return dictionary;
									}
									end_IL_016a:
									break;
								}
							}
						}
						finally
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
									if (enumerator != null)
									{
										num = 1;
										num2 = num;
										continue;
									}
									break;
								case 1:
									enumerator.Dispose();
									num = 0;
									num2 = num;
									continue;
								case 0:
									break;
								}
								break;
							}
						}
					}
					break;
				}
				goto case 0;
			}
			case 0:
				dictionary = new Dictionary<string, string>();
				directoryInfo = new DirectoryInfo(DirectoryPath);
				num = 1;
				num2 = num;
				goto default;
			}
		}
		}
	}
}
