using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[CompilerGenerated]
internal sealed class f
{
	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 15)]
	private struct a
	{
	}

	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 24)]
	private struct b
	{
	}

	internal static readonly a a/* Not supported: data(00 00 FF 00 FF 00 00 00 FF 02 FE D5 15 16 00) */;

	internal static readonly b b/* Not supported: data(55 55 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF 03 FD D4 14 01 17 00) */;

	internal static uint a(string A_0)
	{
		short num = 2;
		int num2 = num;
		uint num5 = default(uint);
		int num4 = default(int);
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
				if (A_0 != null)
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
				num5 = 2166136261u;
				num4 = 0;
				num = 0;
				_ = num;
				num = 1;
				num2 = num;
				continue;
			case 1:
				num = 3;
				num2 = num;
				continue;
			case 3:
				if (num4 >= A_0.Length)
				{
					num = 5;
					num2 = num;
					continue;
				}
				num5 = (A_0[num4] ^ num5) * 16777619;
				num4++;
				num = 4;
				num2 = num;
				continue;
			case 4:
			{
				num = 8351;
				short num3 = num;
				num = 8351;
				switch (num3 == num)
				{
				case false:
				case true:
					break;
				default:
					goto IL_011c;
				}
				goto case 2;
			}
			case 5:
				break;
				IL_011c:
				num = 0;
				if (num == 0)
				{
				}
				goto case 1;
			}
			break;
		}
		return num5;
	}
}
