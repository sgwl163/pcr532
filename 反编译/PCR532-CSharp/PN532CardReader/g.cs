using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using MifareOneTool.Properties;

internal class g
{
	private List<e> m_a = new List<e>(17);

	[SpecialName]
	internal byte[] a()
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			byte[] array = default(byte[]);
			int num5 = default(int);
			switch (0)
			{
			default:
			{
				int num4 = default(int);
				int num6 = default(int);
				while (true)
				{
					num = 28022;
					short num3 = num;
					num = 28022;
					switch (num3 == num)
					{
					default:
						num = 0;
						if (num != 0)
						{
						}
						switch (num2)
						{
						case 0:
						case 6:
							goto IL_00d1;
						case 8:
							goto IL_00e9;
						case 7:
							goto IL_010c;
						case 2:
						case 4:
							goto IL_0148;
						case 5:
							goto IL_0160;
						case 1:
							goto IL_01a3;
						case 3:
							num = 9;
							num2 = num;
							continue;
						case 9:
							goto IL_01dc;
						case 10:
							num = 0;
							_ = num;
							goto case 3;
						case 11:
							num = 1;
							if (num != 0)
							{
							}
							return array;
						}
						break;
					case false:
					case true:
						goto IL_0160;
						IL_00d1:
						num = 8;
						num2 = num;
						continue;
						IL_01dc:
						if (num4 >= 16)
						{
							num = 7;
							num2 = num;
							continue;
						}
						array[num5 * 64 + num6 * 16 + num4] = this.m_a[num5].f()[num6][num4];
						num4++;
						num = 10;
						num2 = num;
						continue;
						IL_0148:
						num = 5;
						num2 = num;
						continue;
						IL_010c:
						num6++;
						num = 6;
						num2 = num;
						continue;
						IL_01a3:
						num5++;
						num = 2;
						num2 = num;
						continue;
						IL_0160:
						if (num5 >= 18)
						{
							num = 11;
							num2 = num;
						}
						else
						{
							num6 = 0;
							num = 0;
							num2 = num;
						}
						continue;
						IL_00e9:
						if (num6 >= 4)
						{
							num = 1;
							num2 = num;
						}
						else
						{
							num4 = 0;
							num = 3;
							num2 = num;
						}
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				array = new byte[1152];
				num5 = 0;
				num = 4;
				num2 = num;
				goto default;
			}
		}
		}
	}

	[SpecialName]
	internal void a(byte[] A_0)
	{
		int num = default(int);
		int num4 = default(int);
		switch (0)
		{
		default:
		{
			int num5 = default(int);
			int num2 = default(int);
			while (true)
			{
				short num3;
				switch (num)
				{
				case 6:
					num3 = 8;
					num = num3;
					continue;
				case 8:
					if (num5 >= 4)
					{
						num3 = 1;
						num = num3;
					}
					else
					{
						num2 = 0;
						num3 = 3;
						num = num3;
					}
					continue;
				case 7:
					num5++;
					num3 = 6;
					num = num3;
					continue;
				case 2:
				case 4:
					num3 = 5;
					num = num3;
					continue;
				case 5:
					if (num4 >= 18)
					{
						num3 = 11;
						num = num3;
					}
					else
					{
						num5 = 0;
						num3 = 0;
						num = num3;
					}
					continue;
				case 11:
					return;
				case 0:
				{
					num3 = -29602;
					short num6 = num3;
					num3 = -29602;
					switch (num6 == num3)
					{
					case false:
					case true:
						goto IL_01c4;
					}
					num3 = 0;
					if (num3 == 0)
					{
					}
					goto case 6;
				}
				case 1:
					goto IL_01c4;
				case 3:
				case 10:
					num3 = 9;
					num = num3;
					continue;
				case 9:
					{
						if (num2 >= 16)
						{
							num3 = 7;
							num = num3;
							continue;
						}
						this.m_a[num4].f()[num5][num2] = A_0[num4 * 64 + num5 * 16 + num2];
						num2++;
						num3 = 10;
						num = num3;
						continue;
					}
					IL_01c4:
					num4++;
					num3 = 2;
					num = num3;
					continue;
				}
				break;
			}
			goto case 0;
		}
		case 0:
		{
			num4 = 0;
			short num3 = 0;
			_ = num3;
			num3 = 1;
			if (num3 != 0)
			{
			}
			num3 = 4;
			num = num3;
			goto default;
		}
		}
	}

	[SpecialName]
	public List<e> c()
	{
		short num = -31096;
		short num2 = num;
		num = -31096;
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
		return this.m_a;
	}

	[SpecialName]
	public void a(List<e> A_0)
	{
		short num = 13905;
		short num2 = num;
		num = 13905;
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
		this.m_a = A_0;
	}

	public g()
	{
		this.m_a.Capacity = 18;
		for (int k = 0; k < 18; k++)
		{
			if (k != 0)
			{
				this.m_a.Add(new e());
			}
			else
			{
				this.m_a.Add(new e(A_0: true));
			}
		}
	}

	public g(byte[] A_0)
	{
		this.m_a.Capacity = 18;
		if (A_0.Length == 4)
		{
			for (int k = 0; k < 18; k++)
			{
				if (k != 0)
				{
					this.m_a.Add(new e());
				}
				else
				{
					this.m_a.Add(new e(A_0));
				}
			}
			return;
		}
		throw new Exception(Resources.不恰当的4字节UID长度);
	}

	public void d()
	{
		int num = default(int);
		int num3 = default(int);
		short num4;
		short num2;
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 0:
					num2 = 1;
					if (num2 == 0)
					{
					}
					goto case 1;
				case 1:
					num2 = 2;
					num = num2;
					continue;
				case 2:
					goto IL_00a3;
				case 3:
					goto IL_00f0;
				}
				break;
				IL_00a3:
				if (num3 >= 18)
				{
					num2 = 3;
					num = num2;
					continue;
				}
				this.m_a[num3].h();
				num3++;
				num2 = 1;
				num = num2;
			}
			goto case 0;
		case 0:
			{
				num2 = 0;
				_ = num2;
				num3 = 0;
				goto IL_004b;
			}
			IL_00f0:
			num2 = -2167;
			num4 = num2;
			num2 = -2167;
			switch (num4 == num2)
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
			goto IL_004b;
			IL_004b:
			num2 = 0;
			num = num2;
			goto default;
		}
	}

	public int[] e()
	{
		int num = default(int);
		int num3 = default(int);
		int[] array = default(int[]);
		int num4 = default(int);
		short num5;
		short num2;
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 0:
				case 1:
					num2 = 2;
					num = num2;
					continue;
				case 2:
					goto IL_007f;
				case 3:
					goto IL_00fe;
				}
				break;
				IL_007f:
				if (num3 >= 18)
				{
					num2 = 3;
					num = num2;
					continue;
				}
				num2 = 1;
				if (num2 != 0)
				{
				}
				array[num3] = this.m_a[num3].i();
				num4 += array[num3];
				num3++;
				num2 = 1;
				num = num2;
			}
			goto case 0;
		case 0:
			{
				num2 = 0;
				_ = num2;
				array = new int[18];
				num4 = 0;
				num3 = 0;
				goto IL_0054;
			}
			IL_00fe:
			num2 = 17479;
			num5 = num2;
			num2 = 17479;
			switch (num5 == num2)
			{
			case false:
			case true:
				break;
			default:
				num2 = 0;
				if (num2 != 0)
				{
				}
				array[16] = num4;
				return array;
			}
			goto IL_0054;
			IL_0054:
			num2 = 0;
			num = num2;
			goto default;
		}
	}

	public int a(int A_0)
	{
		short num = -24713;
		short num2 = num;
		num = -24713;
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
		return this.m_a[A_0].i();
	}

	public void a(string A_0)
	{
		short num = 2;
		int num2 = num;
		while (true)
		{
			num = 4617;
			short num3 = num;
			num = 4617;
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
					break;
				default:
					goto IL_00ac;
				case 3:
					goto IL_00d1;
				case 4:
					goto IL_00e9;
				case 0:
					goto IL_0130;
				case 1:
					num = 0;
					_ = num;
					throw new IOException(Resources.加载的文件不存在);
				case 5:
					throw new IOException(Resources.加载的S502卡文件大小异常);
				}
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
				goto IL_00ac;
			case false:
			case true:
				goto IL_0130;
				IL_00d1:
				num = 4;
				num2 = num;
				continue;
				IL_0130:
				if (new FileInfo(A_0).Length != 1088)
				{
					num = 3;
					num2 = num;
					continue;
				}
				break;
				IL_00ac:
				if (!File.Exists(A_0))
				{
					num = 1;
					num2 = num;
				}
				else
				{
					num = 0;
					num2 = num;
				}
				continue;
				IL_00e9:
				if (new FileInfo(A_0).Length != 1152)
				{
					num = 5;
					num2 = num;
					continue;
				}
				break;
			}
			break;
		}
		byte[] a_ = File.ReadAllBytes(A_0);
		d();
		a(a_);
	}

	public void c(string A_0)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 8;
			int num2 = num;
			long length = default(long);
			List<string> list2 = default(List<string>);
			List<string>.Enumerator enumerator = default(List<string>.Enumerator);
			int num3 = default(int);
			List<string> list = default(List<string>);
			string current = default(string);
			while (true)
			{
				switch (num2)
				{
				case 8:
					switch (0)
					{
					default:
						goto end_IL_003e;
					case 0:
						break;
					}
					goto default;
				default:
					if (!File.Exists(A_0))
					{
						num = 1;
						num2 = num;
						break;
					}
					num = 1;
					if (num != 0)
					{
					}
					length = new FileInfo(A_0).Length;
					num = 0;
					num2 = num;
					break;
				case 15:
					num = 12;
					num2 = num;
					break;
				case 12:
					if (list2.Count != 68)
					{
						num = 6;
						num2 = num;
						break;
					}
					goto IL_01be;
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
								num = 0;
								num2 = num;
								continue;
							case 0:
							{
								if (!enumerator.MoveNext())
								{
									num = 4;
									num2 = num;
									continue;
								}
								string current2 = enumerator.Current;
								list2.Remove(current2);
								num = 2;
								num2 = num;
								continue;
							}
							case 4:
								num = 3;
								num2 = num;
								continue;
							case 3:
								break;
							}
							break;
						}
					}
					finally
					{
						((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
					}
					num = 3;
					num2 = num;
					break;
				case 2:
					throw new IOException(Resources.加载的S502卡文件大小异常);
				case 0:
				{
					num = 28392;
					short num4 = num;
					num = 28392;
					switch (num4 == num)
					{
					case false:
					case true:
						break;
					default:
						goto IL_0266;
					}
					goto default;
				}
				case 3:
					if (list2.Count != 64)
					{
						num = 15;
						num2 = num;
						break;
					}
					goto IL_01be;
				case 5:
					num = 11;
					num2 = num;
					break;
				case 11:
					if (num3 >= list2.Count)
					{
						num = 4;
						num2 = num;
						break;
					}
					this.m_a[num3 / 4].f()[num3 % 4] = b.a(list2[num3], 16);
					num3++;
					num = 9;
					num2 = num;
					break;
				case 4:
					return;
				case 10:
					num = 13;
					num2 = num;
					break;
				case 13:
					if (length > 2500)
					{
						num = 2;
						num2 = num;
						break;
					}
					list2 = new List<string>(File.ReadAllLines(A_0));
					list = new List<string>();
					enumerator = list2.GetEnumerator();
					num = 14;
					num2 = num;
					break;
				case 9:
					num = 0;
					_ = num;
					goto case 5;
				case 6:
					throw new Exception(Resources.文件内不是含有64个块数据_可能不完整或不兼容);
				case 14:
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
							case 2:
								num = 5;
								num2 = num;
								continue;
							case 5:
								if (current.Length != 32)
								{
									num = 3;
									num2 = num;
									continue;
								}
								goto default;
							case 3:
								list.Add(current);
								num = 4;
								num2 = num;
								continue;
							default:
								num = 8;
								num2 = num;
								continue;
							case 8:
								if (!enumerator.MoveNext())
								{
									num = 0;
									num2 = num;
								}
								else
								{
									current = enumerator.Current;
									num = 6;
									num2 = num;
								}
								continue;
							case 6:
								if (Regex.IsMatch(current, "[0-9A-Fa-f]{32}"))
								{
									num = 2;
									num2 = num;
									continue;
								}
								goto case 3;
							case 0:
								num = 7;
								num2 = num;
								continue;
							case 7:
								break;
							}
							break;
						}
					}
					finally
					{
						((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
					}
					enumerator = list.GetEnumerator();
					num = 7;
					num2 = num;
					break;
				case 1:
					{
						throw new IOException(Resources.加载的文件不存在);
					}
					IL_0266:
					num = 0;
					if (num != 0)
					{
					}
					if (length >= 2200)
					{
						num = 10;
						num2 = num;
						break;
					}
					goto case 2;
					IL_01be:
					d();
					num3 = 0;
					num = 5;
					num2 = num;
					break;
					end_IL_003e:
					break;
				}
			}
		}
		}
	}

	public void d(string A_0)
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = 20539;
		short num2 = num;
		num = 20539;
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
		byte[] bytes = a();
		File.WriteAllBytes(A_0, bytes);
	}

	public void e(string A_0)
	{
		int num = default(int);
		int num2 = default(int);
		StringBuilder stringBuilder = default(StringBuilder);
		switch (0)
		{
		default:
		{
			int num3 = default(int);
			while (true)
			{
				short num4;
				switch (num)
				{
				case 4:
				{
					num2++;
					num4 = 576;
					short num5 = num4;
					num4 = 576;
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
						num4 = 6;
						num = num4;
						continue;
					case false:
					case true:
						break;
					}
					goto IL_0161;
				}
				case 3:
				case 7:
					num4 = 0;
					num = num4;
					continue;
				case 0:
					if (num3 >= 4)
					{
						num4 = 4;
						num = num4;
						continue;
					}
					stringBuilder.AppendLine(b.e(this.m_a[num2].f()[num3]));
					num3++;
					num4 = 7;
					num = num4;
					continue;
				case 5:
				case 6:
					num4 = 1;
					num = num4;
					continue;
				case 1:
					if (num2 < 18)
					{
						stringBuilder.AppendLine(Resources._Sector + num2);
						num3 = 0;
						goto IL_0161;
					}
					num4 = 2;
					num = num4;
					continue;
				case 2:
					{
						File.WriteAllText(A_0, stringBuilder.ToString());
						return;
					}
					IL_0161:
					num4 = 3;
					num = num4;
					continue;
				}
				break;
			}
			goto case 0;
		}
		case 0:
		{
			stringBuilder = new StringBuilder();
			num2 = 0;
			short num4 = 5;
			num = num4;
			goto default;
		}
		}
	}

	public List<byte[]> f()
	{
		short num = 20633;
		short num2 = num;
		num = 20633;
		List<byte[]> list = default(List<byte[]>);
		switch (num2 == num)
		{
		default:
		{
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
			list = new List<byte[]>();
			using (List<e>.Enumerator enumerator = this.m_a.GetEnumerator())
			{
				num = 2;
				int num3 = num;
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
						if (enumerator.MoveNext())
						{
							e current = enumerator.Current;
							list.Add(current.j());
							list.Add(current.k());
							num = 3;
							num3 = num;
						}
						else
						{
							num = 1;
							num3 = num;
						}
						continue;
					case 1:
						num = 4;
						num3 = num;
						continue;
					case 4:
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
		return list.Distinct().ToList();
	}

	public List<string> g()
	{
		short num = 13574;
		short num2 = num;
		num = 13574;
		List<string> list = default(List<string>);
		switch (num2 == num)
		{
		default:
		{
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
			list = new List<string>();
			using (List<e>.Enumerator enumerator = this.m_a.GetEnumerator())
			{
				num = 2;
				int num3 = num;
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
						if (enumerator.MoveNext())
						{
							e current = enumerator.Current;
							list.Add(b.e(current.j()));
							list.Add(b.e(current.k()));
							num = 3;
							num3 = num;
						}
						else
						{
							num = 1;
							num3 = num;
						}
						continue;
					case 1:
						num = 4;
						num3 = num;
						continue;
					case 4:
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
		return list.Distinct().ToList();
	}
}
