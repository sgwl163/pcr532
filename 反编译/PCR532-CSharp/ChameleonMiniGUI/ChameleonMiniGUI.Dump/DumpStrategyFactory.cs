using System.IO;

namespace ChameleonMiniGUI.Dump;

public static class DumpStrategyFactory
{
	public static DumpStrategy Create(DumpType type, string fileName = null)
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
					goto end_IL_001f;
				case 0:
					break;
				}
				goto default;
			default:
				switch (type)
				{
				default:
					num = 2;
					num2 = num;
					break;
				case DumpType.Eml:
					return new EmlDumpStrategy(fileName);
				case DumpType.Json:
					num = 0;
					_ = num;
					return new JsonDumpStrategy(fileName);
				case DumpType.Mct:
					return new MctDumpStrategy(fileName);
				case DumpType.Bin:
					return new BinaryDumpStrategy(fileName);
				}
				break;
			case 2:
				num = 1;
				num2 = num;
				break;
			case 1:
				{
					num = -15469;
					short num3 = num;
					num = -15469;
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
						return new BinaryDumpStrategy(fileName);
					}
					goto case 0;
				}
				end_IL_001f:
				break;
			}
		}
	}

	public static DumpStrategy Create(string fileName)
	{
		switch (0)
		{
		case 0:
			goto IL_00b4;
		}
		goto IL_000a;
		IL_000a:
		int num = default(int);
		uint num3 = default(uint);
		string text = default(string);
		short num2;
		while (true)
		{
			switch (num)
			{
			case 5:
				if (num3 <= 2017334923)
				{
					num2 = 27;
					num = num2;
				}
				else
				{
					num2 = 24;
					num = num2;
				}
				continue;
			case 0:
				num2 = 12;
				num = num2;
				continue;
			case 35:
				num2 = 4;
				num = num2;
				continue;
			case 7:
				num2 = 6;
				num = num2;
				continue;
			case 6:
				if (num3 != 2358395718u)
				{
					num2 = 31;
					num = num2;
				}
				else
				{
					num2 = 34;
					num = num2;
				}
				continue;
			case 30:
				num2 = 11;
				num = num2;
				continue;
			case 33:
				num2 = 19;
				num = num2;
				continue;
			case 19:
			{
				num2 = 16350;
				short num4 = num2;
				num2 = 16350;
				switch (num4 == num2)
				{
				case false:
				case true:
					break;
				default:
					goto IL_01e8;
				}
				goto case 0;
			}
			case 14:
				if (!(text == ".json"))
				{
					num2 = 0;
					num = num2;
					continue;
				}
				return new JsonDumpStrategy(fileName);
			case 36:
				if (!(text == ".mfd"))
				{
					num2 = 35;
					num = num2;
					continue;
				}
				goto IL_02ca;
			case 31:
				num2 = 20;
				num = num2;
				continue;
			case 20:
				if (num3 != 3464679027u)
				{
					num2 = 21;
					num = num2;
				}
				else
				{
					num2 = 8;
					num = num2;
				}
				continue;
			case 2:
				num2 = 40;
				num = num2;
				continue;
			case 40:
				if (!(text == ".bin"))
				{
					num2 = 15;
					num = num2;
					continue;
				}
				goto IL_02ca;
			case 27:
				num2 = 16;
				num = num2;
				continue;
			case 16:
				if (num3 != 1632560637)
				{
					num2 = 28;
					num = num2;
				}
				else
				{
					num2 = 13;
					num = num2;
				}
				continue;
			case 24:
				if (num3 <= 3464679027u)
				{
					num2 = 7;
					num = num2;
					continue;
				}
				num2 = 1;
				if (num2 != 0)
				{
				}
				num2 = 17;
				num = num2;
				continue;
			case 21:
				num2 = 29;
				num = num2;
				continue;
			case 17:
				if (num3 == 3765837526u)
				{
					num2 = 36;
					num = num2;
				}
				else
				{
					num2 = 37;
					num = num2;
				}
				continue;
			case 8:
				if (text == ".mct")
				{
					return new MctDumpStrategy(fileName);
				}
				num2 = 30;
				num = num2;
				continue;
			case 13:
				if (!(text == ".eml"))
				{
					num2 = 26;
					num = num2;
					continue;
				}
				return new EmlDumpStrategy(fileName);
			case 15:
				num2 = 22;
				num = num2;
				continue;
			case 3:
				if (!(text == ".dump"))
				{
					num2 = 39;
					num = num2;
					continue;
				}
				goto IL_02ca;
			case 23:
				num2 = 18;
				num = num2;
				continue;
			case 37:
				num2 = 25;
				num = num2;
				continue;
			case 25:
				if (num3 == 4033737770u)
				{
					num2 = 2;
					num = num2;
					continue;
				}
				goto case 4;
			case 32:
				num2 = 9;
				num = num2;
				continue;
			case 9:
				if (num3 == 2017334923)
				{
					num2 = 3;
					num = num2;
				}
				else
				{
					num2 = 33;
					num = num2;
				}
				continue;
			case 39:
				num2 = 38;
				num = num2;
				continue;
			case 28:
				num2 = 1;
				num = num2;
				continue;
			case 1:
				if (num3 == 1861662575)
				{
					num2 = 14;
					num = num2;
					continue;
				}
				num2 = 0;
				_ = num2;
				num2 = 32;
				num = num2;
				continue;
			case 34:
				if (!(text == ".hex"))
				{
					num2 = 23;
					num = num2;
					continue;
				}
				goto IL_02ca;
			case 26:
				num2 = 10;
				num = num2;
				continue;
			case 4:
			case 10:
			case 11:
			case 12:
			case 18:
			case 22:
			case 29:
			case 38:
				{
					return new BinaryDumpStrategy(fileName);
				}
				IL_02ca:
				return new BinaryDumpStrategy(fileName);
				IL_01e8:
				num2 = 0;
				if (num2 == 0)
				{
				}
				goto case 4;
			}
			break;
		}
		goto IL_00b4;
		IL_00b4:
		text = Path.GetExtension(fileName).ToLower();
		num3 = f.a(text);
		num2 = 5;
		num = num2;
		goto IL_000a;
	}
}
