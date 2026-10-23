namespace ChameleonMiniGUI;

public class Crc
{
	public const ushort CRC16_14443_A = 25443;

	public const ushort CRC16_14443_B = ushort.MaxValue;

	private static ushort a(byte A_0, ushort A_1)
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = -23372;
		short num2 = num;
		num = -23372;
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
			byte b = (byte)(A_0 ^ (byte)(A_1 & 0xFF));
			b = (byte)(b ^ (b << 4));
			return (ushort)((A_1 >> 8) ^ (b << 8) ^ (b << 3) ^ (b >> 4));
		}
		}
	}

	public static void ComputeCrc14443(ushort crc_type, byte[] bytes, int len, out byte first, out byte second)
	{
		int num3 = default(int);
		switch (0)
		{
		default:
		{
			ushort num4 = default(ushort);
			int num5 = default(int);
			while (true)
			{
				short num = 9864;
				short num2 = num;
				num = 9864;
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
					switch (num3)
					{
					case 2:
						goto IL_00c4;
					case 8:
						num = 1;
						if (num == 0)
						{
						}
						return;
					case 0:
						goto IL_010b;
					case 3:
						if (crc_type == ushort.MaxValue)
						{
							goto IL_012e;
						}
						goto case 1;
					case 7:
						goto IL_0172;
					case 5:
					case 6:
						goto IL_01ae;
					case 4:
						goto IL_01c5;
					case 1:
						first = (byte)(num4 & 0xFF);
						second = (byte)((num4 >> 8) & 0xFF);
						return;
					}
					break;
				case false:
				case true:
					goto IL_010b;
					IL_012e:
					num = 7;
					num3 = num;
					continue;
					IL_01c5:
					if (num5 < len)
					{
						num4 = a(bytes[num5], num4);
						num5++;
						num = 6;
						num3 = num;
					}
					else
					{
						num = 0;
						num3 = num;
					}
					continue;
					IL_010b:
					num = 3;
					num3 = num;
					continue;
					IL_00c4:
					if (len < 2)
					{
						num = 8;
						num3 = num;
						continue;
					}
					num4 = crc_type;
					num5 = 0;
					num = 5;
					num3 = num;
					continue;
					IL_01ae:
					num = 4;
					num3 = num;
					continue;
					IL_0172:
					num4 = (ushort)(~num4);
					num = 1;
					num3 = num;
					continue;
				}
				break;
			}
			goto case 0;
		}
		case 0:
		{
			first = 0;
			second = 0;
			short num = 2;
			num3 = num;
			goto default;
		}
		}
	}

	public static bool CheckCrc14443(ushort crc_type, byte[] bytes, int len)
	{
		short num = 5;
		int num2 = num;
		byte first = default(byte);
		byte second = default(byte);
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
				if (len < 3)
				{
					num = 1;
					num2 = num;
				}
				else
				{
					ComputeCrc14443(crc_type, bytes, len - 2, out first, out second);
					num = 3;
					num2 = num;
				}
				continue;
			case 1:
				num = 1;
				if (num != 0)
				{
				}
				return false;
			case 0:
				num = 4;
				num2 = num;
				continue;
			case 4:
				if (second == bytes[len - 1])
				{
					num = 0;
					_ = num;
					num = 2;
					num2 = num;
					continue;
				}
				break;
			case 3:
			{
				num = -12942;
				short num3 = num;
				num = -12942;
				switch (num3 == num)
				{
				case false:
				case true:
					break;
				default:
					goto IL_0141;
				}
				goto default;
			}
			case 2:
				{
					return true;
				}
				IL_0141:
				num = 0;
				if (num != 0)
				{
				}
				if (first == bytes[len - 2])
				{
					num = 0;
					num2 = num;
					continue;
				}
				break;
			}
			break;
		}
		return false;
	}
}
