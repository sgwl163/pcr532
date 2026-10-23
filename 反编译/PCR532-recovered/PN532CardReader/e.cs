using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using MifareOneTool.Properties;

internal class e
{
	private byte[][] a = new byte[4][]
	{
		new byte[16],
		new byte[16],
		new byte[16],
		new byte[16]
	};

	private bool b;

	[SpecialName]
	public byte[][] f()
	{
		short num = 7239;
		short num2 = num;
		num = 7239;
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
			return a;
		}
	}

	[SpecialName]
	public void f(byte[][] A_0)
	{
		short num = -12301;
		short num2 = num;
		num = -12301;
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
		a = A_0;
	}

	[SpecialName]
	public bool g()
	{
		short num = -19132;
		short num2 = num;
		num = -19132;
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
			return b;
		}
	}

	[SpecialName]
	public void f(bool A_0)
	{
		short num = -18050;
		short num2 = num;
		num = -18050;
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
		b = A_0;
	}

	public void h()
	{
		int num3 = default(int);
		byte[] array = default(byte[]);
		switch (0)
		{
		default:
			while (true)
			{
				short num = -19300;
				short num2 = num;
				num = -19300;
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
					switch (num3)
					{
					case 1:
						goto IL_00ef;
					case 2:
						goto IL_0111;
					case 0:
						goto IL_0148;
					}
					break;
				case false:
				case true:
					goto IL_0148;
					IL_00ef:
					if (b)
					{
						num = 2;
						num3 = num;
						continue;
					}
					goto IL_0148;
					IL_0148:
					num = 0;
					_ = num;
					return;
					IL_0111:
					a[0] = array;
					num = 0;
					num3 = num;
					continue;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			array = a[0];
			a = new byte[4][]
			{
				new byte[16],
				new byte[16],
				new byte[16],
				new byte[16]
				{
					255, 255, 255, 255, 255, 255, 255, 7, 128, 105,
					255, 255, 255, 255, 255, 255
				}
			};
			short num = 1;
			num3 = num;
			goto default;
		}
		}
	}

	public e(bool A_0 = false)
	{
		b = A_0;
		h();
		if (A_0)
		{
			RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
			byte[] array = new byte[4];
			rNGCryptoServiceProvider.GetNonZeroBytes(array);
			byte b2 = (byte)(array[0] ^ array[1] ^ array[2] ^ array[3]);
			byte[][] array2 = a;
			byte[] obj = new byte[16]
			{
				0, 0, 0, 0, 0, 8, 4, 0, 98, 99,
				100, 101, 102, 103, 104, 105
			};
			obj[0] = array[0];
			obj[1] = array[1];
			obj[2] = array[2];
			obj[3] = array[3];
			obj[4] = b2;
			array2[0] = obj;
		}
	}

	public e(byte[] A_0)
	{
		if (A_0.Length != 4)
		{
			throw new Exception(Resources.不恰当的4字节UID长度);
		}
		b = true;
		h();
		byte b2 = (byte)(A_0[0] ^ A_0[1] ^ A_0[2] ^ A_0[3]);
		byte[][] array = a;
		byte[] obj = new byte[16]
		{
			0, 0, 0, 0, 0, 8, 4, 0, 98, 99,
			100, 101, 102, 103, 104, 105
		};
		obj[0] = A_0[0];
		obj[1] = A_0[1];
		obj[2] = A_0[2];
		obj[3] = A_0[3];
		obj[4] = b2;
		array[0] = obj;
	}

	public int i()
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			int num4 = default(int);
			switch (0)
			{
			default:
			{
				byte[] array2 = default(byte[]);
				byte[] array = default(byte[]);
				int num3 = default(int);
				byte[] second = default(byte[]);
				while (true)
				{
					switch (num2)
					{
					case 11:
					{
						num = -5718;
						short num5 = num;
						num = -5718;
						switch (num5 == num)
						{
						case false:
						case true:
							goto IL_012a;
						}
						num = 0;
						if (num != 0)
						{
						}
						if (b)
						{
							num = 8;
							num2 = num;
							continue;
						}
						goto case 9;
					}
					case 7:
						num4 |= 2;
						num = 13;
						num2 = num;
						continue;
					case 13:
						goto IL_012a;
					case 5:
						array2 = array;
						num3 = 0;
						num = 4;
						num2 = num;
						continue;
					case 1:
						num4 |= 1;
						num = 9;
						num2 = num;
						continue;
					case 8:
						num = 0;
						num2 = num;
						continue;
					case 0:
						if ((byte)(a[0][0] ^ a[0][1] ^ a[0][2] ^ a[0][3] ^ a[0][4]) != 0)
						{
							num = 1;
							num2 = num;
							continue;
						}
						goto case 9;
					case 6:
						if (array2[num3] <= 8)
						{
							num3++;
							num = 12;
							num2 = num;
						}
						else
						{
							num = 7;
							num2 = num;
						}
						continue;
					case 4:
					case 12:
						num = 14;
						num2 = num;
						continue;
					case 14:
						if (num3 < array2.Length)
						{
							num = 6;
							num2 = num;
						}
						else
						{
							num = 3;
							num2 = num;
						}
						continue;
					case 10:
						num4 |= 4;
						num = 5;
						num2 = num;
						continue;
					case 9:
					{
						byte[] a_ = new byte[4]
						{
							a[3][6],
							a[3][7],
							a[3][8],
							a[3][9]
						};
						array = global::b.c(a_);
						second = global::b.b(a_);
						num = 2;
						num2 = num;
						continue;
					}
					case 2:
						if (!array.SequenceEqual(second))
						{
							num = 10;
							num2 = num;
							continue;
						}
						goto case 5;
					case 3:
						{
							num = 1;
							if (num != 0)
							{
							}
							return num4;
						}
						IL_012a:
						num = 0;
						_ = num;
						goto case 3;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				num4 = 0;
				num = 11;
				num2 = num;
				goto default;
			}
		}
		}
	}

	public string f(int A_0)
	{
		int num = default(int);
		string text = default(string);
		switch (0)
		{
		default:
			while (true)
			{
				short num2;
				switch (num)
				{
				case 7:
					if (new byte[16].SequenceEqual(a[0]))
					{
						goto IL_007d;
					}
					goto IL_0253;
				case 2:
				case 4:
					num2 = 5;
					num = num2;
					continue;
				case 5:
					if (i() != 0)
					{
						num2 = 8;
						num = num2;
						continue;
					}
					goto case 10;
				case 1:
					text += Resources._空扇区;
					num2 = 2;
					num = num2;
					continue;
				case 9:
					num2 = 3;
					num = num2;
					continue;
				case 3:
					if (new byte[16].SequenceEqual(a[1]))
					{
						num2 = 6;
						num = num2;
						continue;
					}
					goto IL_0253;
				case 8:
				{
					text += Resources._有错误;
					num2 = 32493;
					short num3 = num2;
					num2 = 32493;
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
						num2 = 10;
						num = num2;
						continue;
					}
					goto IL_007d;
				}
				case 6:
					num2 = 0;
					num = num2;
					continue;
				case 0:
					num2 = 0;
					_ = num2;
					if (new byte[16].SequenceEqual(a[2]))
					{
						num2 = 1;
						num = num2;
						continue;
					}
					goto IL_0253;
				case 10:
					{
						return text;
					}
					IL_007d:
					num2 = 9;
					num = num2;
					continue;
					IL_0253:
					text += Resources._有数据;
					num2 = 4;
					num = num2;
					continue;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			text = Resources.扇区 + A_0;
			short num2 = 7;
			num = num2;
			goto default;
		}
		}
	}

	[SpecialName]
	public byte[] j()
	{
		short num = -15074;
		short num2 = num;
		num = -15074;
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
			return a[3].Skip(0).Take(6).ToArray();
		}
	}

	[SpecialName]
	public void f(byte[] A_0)
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
				case 2:
					num2 = 1;
					if (num2 == 0)
					{
					}
					goto IL_005f;
				case 0:
					while (true)
					{
						if (num3 >= 6)
						{
							num2 = 3;
							num = num2;
							break;
						}
						a[3][num3] = A_0[num3];
						num3++;
						num2 = -9217;
						short num4 = num2;
						num2 = -9217;
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
						num2 = 0;
						_ = num2;
						goto IL_005f;
					}
					IL_005f:
					num2 = 0;
					num = num2;
					continue;
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

	[SpecialName]
	public byte[] k()
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = 27263;
		short num2 = num;
		num = 27263;
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
		return a[3].Skip(10).Take(6).ToArray();
	}

	[SpecialName]
	public void g(byte[] A_0)
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
							num2 = 3;
							num = num2;
							break;
						}
						a[3][num3] = A_0[num3];
						num3++;
						num2 = -15758;
						short num4 = num2;
						num2 = -15758;
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
					short num2 = 1;
					if (num2 != 0)
					{
					}
					num2 = 0;
					_ = num2;
					goto case 2;
				}
				}
				break;
			}
			goto case 0;
		case 0:
		{
			num3 = 10;
			short num2 = 2;
			num = num2;
			goto default;
		}
		}
	}

	[SpecialName]
	public byte[] l()
	{
		short num = -12286;
		short num2 = num;
		num = -12286;
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
			return a[3].Skip(6).Take(4).ToArray();
		}
	}

	[SpecialName]
	public void h(byte[] A_0)
	{
		int num2 = default(int);
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
						if (num3 >= 10)
						{
							num = 3;
							num2 = num;
							break;
						}
						a[3][num3] = A_0[num3];
						num3++;
						num = 9014;
						short num4 = num;
						num = 9014;
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
						num = 1;
						num2 = num;
						break;
					}
					continue;
				case 3:
					return;
				case 1:
					num = 0;
					_ = num;
					goto case 2;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			num3 = 6;
			short num = 2;
			num2 = num;
			goto default;
		}
		}
	}
}
