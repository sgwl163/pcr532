using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using MifareOneTool.Properties;

internal class f
{
	private List<e> m_a = new List<e>(16);

	[SpecialName]
	internal byte[] a()
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			int num3 = default(int);
			byte[] array = default(byte[]);
			switch (0)
			{
			default:
			{
				int num4 = default(int);
				int num5 = default(int);
				while (true)
				{
					switch (num2)
					{
					case 6:
					case 7:
						num = 10;
						num2 = num;
						continue;
					case 10:
						goto IL_009b;
					case 1:
						goto IL_00bf;
					case 8:
					case 11:
						num = 3;
						num2 = num;
						continue;
					case 3:
						goto IL_018e;
					case 4:
						num3++;
						num = 11;
						num2 = num;
						continue;
					case 5:
					case 9:
						num = 2;
						num2 = num;
						continue;
					case 2:
						goto IL_0231;
					case 0:
						return array;
					}
					break;
					IL_0231:
					if (num4 >= 16)
					{
						num = 1;
						num2 = num;
						continue;
					}
					array[num3 * 64 + num5 * 16 + num4] = this.m_a[num3].f()[num5][num4];
					num4++;
					num = 5;
					num2 = num;
					continue;
					IL_009b:
					if (num5 >= 4)
					{
						num = 4;
						num2 = num;
					}
					else
					{
						num4 = 0;
						num = 9;
						num2 = num;
					}
					continue;
					IL_00bf:
					num = -22274;
					short num6 = num;
					num = -22274;
					switch (num6 == num)
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
						num5++;
						num = 6;
						num2 = num;
						continue;
					}
					goto IL_006b;
					IL_018e:
					num = 1;
					if (num != 0)
					{
					}
					if (num3 >= 16)
					{
						num = 0;
						num2 = num;
					}
					else
					{
						num5 = 0;
						num = 7;
						num2 = num;
					}
				}
				goto case 0;
			}
			case 0:
				{
					array = new byte[1024];
					num3 = 0;
					goto IL_006b;
				}
				IL_006b:
				num = 8;
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
		int num5 = default(int);
		switch (0)
		{
		default:
		{
			int num6 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num)
				{
				case 6:
				case 7:
				{
					short num2 = 10;
					num = num2;
					continue;
				}
				case 10:
					if (num6 >= 4)
					{
						short num2 = 4;
						num = num2;
					}
					else
					{
						num4 = 0;
						short num2 = 9;
						num = num2;
					}
					continue;
				case 1:
				{
					num6++;
					short num2 = 6;
					num = num2;
					continue;
				}
				case 8:
				case 11:
				{
					short num2 = 3;
					num = num2;
					continue;
				}
				case 3:
					if (num5 >= 16)
					{
						short num2 = 0;
						num = num2;
					}
					else
					{
						num6 = 0;
						short num2 = 7;
						num = num2;
					}
					continue;
				case 0:
					return;
				case 4:
				{
					num5++;
					short num2 = 11;
					num = num2;
					continue;
				}
				case 5:
				case 9:
				{
					short num2 = 2;
					num = num2;
					continue;
				}
				case 2:
				{
					short num2 = -22138;
					short num3 = num2;
					num2 = -22138;
					switch (num3 == num2)
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
						if (num4 >= 16)
						{
							num2 = 0;
							_ = num2;
							num2 = 1;
							num = num2;
						}
						else
						{
							this.m_a[num5].f()[num6][num4] = A_0[num5 * 64 + num6 * 16 + num4];
							num4++;
							num2 = 5;
							num = num2;
						}
						continue;
					}
					goto case 4;
				}
				}
				break;
			}
			goto case 0;
		}
		case 0:
		{
			num5 = 0;
			short num2 = 8;
			num = num2;
			goto default;
		}
		}
	}

	[SpecialName]
	public List<e> c()
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = -10032;
		short num2 = num;
		num = -10032;
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
		return this.m_a;
	}

	[SpecialName]
	public void a(List<e> A_0)
	{
		short num = -12407;
		short num2 = num;
		num = -12407;
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
		this.m_a = A_0;
	}

	public f()
	{
		this.m_a.Capacity = 16;
		for (int k = 0; k < 16; k++)
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

	public f(byte[] A_0)
	{
		this.m_a.Capacity = 16;
		if (A_0.Length == 4)
		{
			for (int k = 0; k < 16; k++)
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
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 2:
				{
					short num2 = 0;
					num = num2;
					continue;
				}
				case 0:
					while (true)
					{
						short num2;
						if (num3 >= 16)
						{
							num2 = 1;
							if (num2 != 0)
							{
							}
							num2 = 3;
							num = num2;
							break;
						}
						this.m_a[num3].h();
						num3++;
						num2 = -27549;
						short num4 = num2;
						num2 = -27549;
						switch (num4 == num2)
						{
						case false:
						case true:
							continue;
						}
						num2 = 0;
						if (num2 != 0)
						{
						}
						num2 = 1;
						num = num2;
						break;
					}
					continue;
				case 3:
					return;
				case 1:
				{
					short num2 = 0;
					_ = num2;
					goto case 2;
				}
				}
				break;
			}
			goto case 0;
		case 0:
		{
			num3 = 0;
			short num2 = 2;
			num = num2;
			goto default;
		}
		}
	}

	public int[] e()
	{
		int num2 = default(int);
		int num4 = default(int);
		int[] array = default(int[]);
		int num3 = default(int);
		switch (0)
		{
		default:
			while (true)
			{
				short num = 1;
				if (num != 0)
				{
				}
				switch (num2)
				{
				case 2:
					num = 0;
					num2 = num;
					continue;
				case 0:
					while (true)
					{
						if (num4 >= 16)
						{
							num = 3;
							num2 = num;
							break;
						}
						array[num4] = this.m_a[num4].i();
						num3 += array[num4];
						num4++;
						num = 11885;
						short num5 = num;
						num = 11885;
						switch (num5 == num)
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
						break;
					}
					continue;
				case 1:
					num = 0;
					_ = num;
					goto case 2;
				case 3:
					array[16] = num3;
					return array;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			array = new int[17];
			num3 = 0;
			num4 = 0;
			short num = 2;
			num2 = num;
			goto default;
		}
		}
	}

	public int a(int A_0)
	{
		short num = 14686;
		short num2 = num;
		num = 14686;
		switch (num2 == num)
		{
		default:
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
			return this.m_a[A_0].i();
		}
	}

	public void a(string A_0)
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
				if (!File.Exists(A_0))
				{
					num = 6;
					num2 = num;
				}
				else
				{
					num = 2;
					num2 = num;
				}
				continue;
			case 7:
				num = 5;
				num2 = num;
				continue;
			case 5:
				if (new FileInfo(A_0).Length != 1152)
				{
					num = 3;
					num2 = num;
					continue;
				}
				break;
			case 0:
				num = 0;
				_ = num;
				num = 1;
				num2 = num;
				continue;
			case 1:
			{
				if (new FileInfo(A_0).Length == 1088)
				{
					break;
				}
				num = -13607;
				short num3 = num;
				num = -13607;
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
					num = 7;
					num2 = num;
					continue;
				}
				goto case 7;
			}
			case 6:
				num = 1;
				if (num != 0)
				{
				}
				throw new IOException(Resources.加载的文件不存在);
			case 3:
				throw new IOException(Resources.加载的S50卡文件大小异常);
			case 2:
				if (new FileInfo(A_0).Length != 1024)
				{
					num = 0;
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
			num = 10;
			int num2 = num;
			long length = default(long);
			List<string> list2 = default(List<string>);
			int num3 = default(int);
			List<string>.Enumerator enumerator = default(List<string>.Enumerator);
			List<string> list = default(List<string>);
			string current = default(string);
			while (true)
			{
				switch (num2)
				{
				case 10:
					switch (0)
					{
					default:
						goto end_IL_003f;
					case 0:
						break;
					}
					goto default;
				default:
					if (!File.Exists(A_0))
					{
						num = 5;
						num2 = num;
					}
					else
					{
						length = new FileInfo(A_0).Length;
						num = 2;
						num2 = num;
					}
					break;
				case 12:
					if (list2.Count != 64)
					{
						num = 8;
						num2 = num;
						break;
					}
					d();
					num3 = 0;
					num = 3;
					num2 = num;
					break;
				case 8:
					num = 1;
					if (num != 0)
					{
					}
					throw new Exception(Resources.文件内不是含有64个块数据_可能不完整或不兼容);
				case 9:
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
									string current2 = enumerator.Current;
									list2.Remove(current2);
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
							{
								num = 15063;
								short num4 = num;
								num = 15063;
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
								goto default;
							}
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
					num = 12;
					num2 = num;
					break;
				case 6:
					num = 4;
					num2 = num;
					break;
				case 4:
					if (length > 2400)
					{
						num = 11;
						num2 = num;
						break;
					}
					list2 = new List<string>(File.ReadAllLines(A_0));
					list = new List<string>();
					enumerator = list2.GetEnumerator();
					num = 0;
					num2 = num;
					break;
				case 2:
					if (length >= 2000)
					{
						num = 6;
						num2 = num;
						break;
					}
					goto case 11;
				case 1:
				case 3:
					num = 13;
					num2 = num;
					break;
				case 13:
					if (num3 >= list2.Count)
					{
						num = 7;
						num2 = num;
						break;
					}
					this.m_a[num3 / 4].f()[num3 % 4] = b.a(list2[num3], 16);
					num3++;
					num = 0;
					_ = num;
					num = 1;
					num2 = num;
					break;
				case 7:
					return;
				case 11:
					throw new IOException(Resources.加载的S50卡文件大小异常);
				case 5:
					throw new IOException(Resources.加载的文件不存在);
				case 0:
					{
						try
						{
							num = 5;
							num2 = num;
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
									num = 7;
									num2 = num;
									continue;
								case 7:
									if (!enumerator.MoveNext())
									{
										num = 6;
										num2 = num;
									}
									else
									{
										current = enumerator.Current;
										num = 2;
										num2 = num;
									}
									continue;
								case 8:
									num = 1;
									num2 = num;
									continue;
								case 1:
									if (current.Length != 32)
									{
										num = 4;
										num2 = num;
										continue;
									}
									goto default;
								case 2:
									if (Regex.IsMatch(current, "[0-9A-Fa-f]{32}"))
									{
										num = 8;
										num2 = num;
										continue;
									}
									goto case 4;
								case 4:
									list.Add(current);
									num = 3;
									num2 = num;
									continue;
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
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
						enumerator = list.GetEnumerator();
						num = 9;
						num2 = num;
						break;
					}
					end_IL_003f:
					break;
				}
			}
		}
		}
	}

	public void d(string A_0)
	{
		short num = 9943;
		short num2 = num;
		num = 9943;
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
				switch (num)
				{
				case 6:
				{
					num2++;
					short num4 = 4;
					num = num4;
					continue;
				}
				case 2:
				case 7:
				{
					short num4 = 1;
					num = num4;
					continue;
				}
				case 1:
				{
					short num4;
					if (num3 >= 4)
					{
						num4 = 6;
						num = num4;
						continue;
					}
					stringBuilder.AppendLine(b.e(this.m_a[num2].f()[num3]));
					num3++;
					num4 = 2;
					num = num4;
					continue;
				}
				case 0:
				case 4:
				{
					short num4 = 5;
					num = num4;
					continue;
				}
				case 5:
				{
					short num4;
					if (num2 < 16)
					{
						stringBuilder.AppendLine(Resources._Sector + num2);
						num3 = 0;
						num4 = 7;
						num = num4;
						continue;
					}
					num4 = -1121;
					short num5 = num4;
					num4 = -1121;
					switch (num5 == num4)
					{
					case false:
					case true:
						break;
					default:
						num4 = 0;
						if (num4 != 0)
						{
						}
						num4 = 1;
						if (num4 != 0)
						{
						}
						num4 = 3;
						num = num4;
						continue;
					}
					goto case 0;
				}
				case 3:
					File.WriteAllText(A_0, stringBuilder.ToString());
					return;
				}
				break;
			}
			goto case 0;
		}
		case 0:
		{
			short num4 = 0;
			_ = num4;
			stringBuilder = new StringBuilder();
			num2 = 0;
			num4 = 0;
			num = num4;
			goto default;
		}
		}
	}

	public List<byte[]> f()
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = 8554;
		short num2 = num;
		num = 8554;
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
			list = new List<byte[]>();
			using (List<e>.Enumerator enumerator = this.m_a.GetEnumerator())
			{
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
						num = 4;
						num3 = num;
						continue;
					case 4:
						if (enumerator.MoveNext())
						{
							e current = enumerator.Current;
							list.Add(current.j());
							list.Add(current.k());
							num = 0;
							num3 = num;
						}
						else
						{
							num = 2;
							num3 = num;
						}
						continue;
					case 2:
						num = 3;
						num3 = num;
						continue;
					case 3:
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
		short num = 1;
		if (num != 0)
		{
		}
		num = -23637;
		short num2 = num;
		num = -23637;
		List<string> list = default(List<string>);
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
			list = new List<string>();
			using (List<e>.Enumerator enumerator = this.m_a.GetEnumerator())
			{
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
						num = 4;
						num3 = num;
						continue;
					case 4:
						if (enumerator.MoveNext())
						{
							e current = enumerator.Current;
							list.Add(b.e(current.j()));
							list.Add(b.e(current.k()));
							num = 0;
							num3 = num;
						}
						else
						{
							num = 2;
							num3 = num;
						}
						continue;
					case 2:
						num = 3;
						num3 = num;
						continue;
					case 3:
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
