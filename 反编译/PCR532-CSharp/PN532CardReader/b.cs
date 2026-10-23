using System;
using System.Text;

internal class b
{
	public static string e(byte[] A_0)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			int num3 = default(int);
			byte[] array = default(byte[]);
			StringBuilder stringBuilder = default(StringBuilder);
			switch (0)
			{
			default:
				while (true)
				{
					switch (num2)
					{
					case 1:
					case 2:
						num = 3;
						num2 = num;
						continue;
					case 3:
						if (num3 >= array.Length)
						{
							num = 0;
							_ = num;
							num = -12760;
							short num4 = num;
							num = -12760;
							switch (num4 == num)
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
								num2 = num;
								continue;
							case false:
							case true:
								break;
							}
						}
						else
						{
							byte b2 = array[num3];
							stringBuilder.AppendFormat("{0:x2}", b2);
							num3++;
						}
						num = 2;
						num2 = num;
						continue;
					case 0:
						return stringBuilder.ToString();
					}
					break;
				}
				goto case 0;
			case 0:
				stringBuilder = new StringBuilder();
				array = A_0;
				num3 = 0;
				num = 1;
				num2 = num;
				goto default;
			}
		}
		}
	}

	public static string d(byte[] A_0)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			int num3 = default(int);
			byte[] array = default(byte[]);
			StringBuilder stringBuilder = default(StringBuilder);
			switch (0)
			{
			default:
				while (true)
				{
					switch (num2)
					{
					case 1:
					case 2:
						num = 3;
						num2 = num;
						continue;
					case 3:
						if (num3 >= array.Length)
						{
							num = 0;
							_ = num;
							num = 11096;
							short num4 = num;
							num = 11096;
							switch (num4 == num)
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
								num2 = num;
								continue;
							case false:
							case true:
								break;
							}
						}
						else
						{
							byte b2 = array[num3];
							stringBuilder.AppendFormat("{0:x2}", b2);
							stringBuilder.Append(" ");
							num3++;
						}
						num = 2;
						num2 = num;
						continue;
					case 0:
						return stringBuilder.ToString();
					}
					break;
				}
				goto case 0;
			case 0:
				stringBuilder = new StringBuilder();
				array = A_0;
				num3 = 0;
				num = 1;
				num2 = num;
				goto default;
			}
		}
		}
	}

	public static byte[] a(string A_0, int A_1)
	{
		int num = default(int);
		int num4 = default(int);
		byte[] array = default(byte[]);
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 1:
				{
					short num2 = 3;
					num = num2;
					continue;
				}
				case 3:
				{
					short num2;
					if (num4 >= A_1)
					{
						num2 = 0;
						num = num2;
						continue;
					}
					array[num4] = Convert.ToByte(A_0.Substring(num4 * 2, 2), 16);
					num4++;
					num2 = 2;
					num = num2;
					continue;
				}
				case 0:
				{
					short num2 = 1;
					if (num2 == 0)
					{
					}
					goto IL_0156;
				}
				case 2:
					{
						short num2 = 2948;
						short num3 = num2;
						num2 = 2948;
						switch (num3 == num2)
						{
						case false:
						case true:
							goto IL_0156;
						}
						num2 = 0;
						if (num2 != 0)
						{
						}
						num2 = 0;
						_ = num2;
						goto case 1;
					}
					IL_0156:
					return array;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			A_0 = A_0.Replace(" ", "");
			array = new byte[A_1];
			num4 = 0;
			short num2 = 1;
			num = num2;
			goto default;
		}
		}
	}

	public static byte[] c(byte[] A_0)
	{
		short num = 7450;
		short num2 = num;
		num = 7450;
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
			return new byte[4]
			{
				(byte)(((A_0[2] & 0x10) >> 4) + ((A_0[2] & 1) << 1) + ((A_0[1] & 0x10) >> 2)),
				(byte)(((A_0[2] & 0x20) >> 5) + (A_0[2] & 2) + ((A_0[1] & 0x20) >> 3)),
				(byte)(((A_0[2] & 0x40) >> 6) + ((A_0[2] & 4) >> 1) + ((A_0[1] & 0x40) >> 4)),
				(byte)(((A_0[2] & 0x80) >> 7) + ((A_0[2] & 8) >> 2) + ((A_0[1] & 0x80) >> 5))
			};
		}
	}

	public static byte[] b(byte[] A_0)
	{
		int num = default(int);
		int num4 = default(int);
		byte[] array = default(byte[]);
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 1:
				{
					short num2 = 3;
					num = num2;
					continue;
				}
				case 3:
				{
					short num2 = 1;
					if (num2 != 0)
					{
					}
					if (num4 >= A_0.Length)
					{
						num2 = 0;
						num = num2;
						continue;
					}
					A_0[num4] = (byte)(~A_0[num4]);
					num4++;
					num2 = 2;
					num = num2;
					continue;
				}
				case 2:
				{
					short num2 = -29441;
					short num3 = num2;
					num2 = -29441;
					switch (num3 == num2)
					{
					case false:
					case true:
						goto IL_013e;
					}
					num2 = 0;
					if (num2 != 0)
					{
					}
					num2 = 0;
					_ = num2;
					goto case 1;
				}
				case 0:
					goto IL_013e;
					IL_013e:
					array[0] = (byte)(((A_0[0] & 1) << 2) + ((A_0[0] & 0x10) >> 3) + (A_0[1] & 1));
					array[1] = (byte)(((A_0[0] & 2) << 1) + ((A_0[0] & 0x20) >> 4) + ((A_0[1] & 2) >> 1));
					array[2] = (byte)((A_0[0] & 4) + ((A_0[0] & 0x40) >> 5) + ((A_0[1] & 4) >> 2));
					array[3] = (byte)(((A_0[0] & 8) >> 1) + ((A_0[0] & 0x80) >> 6) + ((A_0[1] & 8) >> 3));
					return array;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			array = new byte[4];
			num4 = 0;
			short num2 = 1;
			num = num2;
			goto default;
		}
		}
	}

	public static byte[] a(byte[] A_0)
	{
		int num = default(int);
		int num4 = default(int);
		byte[] array = default(byte[]);
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 1:
				{
					short num2 = 3;
					num = num2;
					continue;
				}
				case 3:
				{
					short num2;
					if (num4 >= A_0.Length)
					{
						num2 = 0;
						num = num2;
						continue;
					}
					A_0[num4] = (byte)(~A_0[num4]);
					num4++;
					num2 = 2;
					num = num2;
					continue;
				}
				case 2:
				{
					short num2 = -28674;
					short num3 = num2;
					num2 = -28674;
					switch (num3 == num2)
					{
					case false:
					case true:
						goto IL_01b9;
					}
					num2 = 0;
					if (num2 != 0)
					{
					}
					num2 = 0;
					_ = num2;
					goto case 1;
				}
				case 0:
					goto IL_01b9;
					IL_01b9:
					array[1] = (byte)(array[1] | (A_0[0] & 1) | ((A_0[1] << 1) & 2) | ((A_0[2] << 2) & 4) | ((A_0[3] << 3) & 8));
					array[0] = (byte)(((A_0[0] >> 2) & 1) | ((A_0[1] >> 1) & 2) | (A_0[2] & 4) | ((A_0[3] << 1) & 8) | ((A_0[0] << 3) & 0x10) | ((A_0[1] << 4) & 0x20) | ((A_0[2] << 5) & 0x40) | ((A_0[3] << 6) & 0x80));
					return array;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			array = new byte[4];
			array[3] = 0;
			array[1] = (byte)(((A_0[0] << 2) & 0x10) | ((A_0[1] << 3) & 0x20) | ((A_0[2] << 4) & 0x40) | ((A_0[3] << 5) & 0x80));
			array[2] = (byte)(((A_0[0] >> 1) & 1) | (A_0[1] & 2) | ((A_0[2] << 1) & 4) | ((A_0[3] << 2) & 8) | ((A_0[0] << 4) & 0x10) | ((A_0[1] << 5) & 0x20) | ((A_0[2] << 6) & 0x40) | ((A_0[3] << 7) & 0x80));
			num4 = 0;
			short num2 = 1;
			if (num2 != 0)
			{
			}
			num2 = 1;
			num = num2;
			goto default;
		}
		}
	}
}
