using System;
using System.Text;
using ChameleonMiniGUI.Log;

internal class e
{
	public static string a(byte[] A_0)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			int num3;
			string text = default(string);
			int num6 = default(int);
			switch (0)
			{
			default:
			{
				byte b2 = default(byte);
				int num4 = default(int);
				byte a_ = default(byte);
				while (true)
				{
					switch (num2)
					{
					case 6:
					{
						byte[] array2 = new byte[b2];
						Array.Copy(A_0, num3, array2, 0, b2);
						num3 += b2;
						text = text + "[" + num4 + "] " + a(a_, array2);
						num = 4;
						num2 = num;
						continue;
					}
					case 5:
						num = 2;
						num2 = num;
						continue;
					case 2:
						if (num3 + b2 <= num6)
						{
							num = 6;
							num2 = num;
							continue;
						}
						goto case 4;
					case 3:
						if (num3 + 4 <= num6)
						{
							num = 0;
							num2 = num;
							continue;
						}
						goto IL_02a1;
					case 4:
					case 7:
						num = 1;
						num2 = num;
						continue;
					case 1:
						if (num3 <= num6)
						{
							num = 3;
							num2 = num;
						}
						else
						{
							num = 9;
							num2 = num;
						}
						continue;
					case 9:
					{
						num = -32736;
						short num5 = num;
						num = -32736;
						switch (num5 == num)
						{
						case false:
						case true:
							break;
						default:
							goto IL_01d4;
						}
						goto case 5;
					}
					case 0:
					{
						a_ = A_0[num3++];
						b2 = A_0[num3++];
						byte[] array = new byte[2]
						{
							A_0[num3++],
							A_0[num3++]
						};
						num4 = (array[0] << 8) | array[1];
						num = 8;
						num2 = num;
						continue;
					}
					case 8:
						{
							if (b2 > 0)
							{
								num = 5;
								num2 = num;
								continue;
							}
							goto case 4;
						}
						IL_02a1:
						num = 0;
						_ = num;
						return text;
						IL_01d4:
						num = 0;
						if (num != 0)
						{
						}
						num = 1;
						if (num == 0)
						{
						}
						goto IL_02a1;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				text = "";
				num6 = A_0.Length;
				num3 = 0;
				num = 7;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private static string a(byte A_0, byte[] A_1)
	{
		short num = 5;
		int num2 = num;
		while (true)
		{
			LogEntryType logEntryType;
			switch (num2)
			{
			case 5:
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
				if ((uint)A_0 <= 129u)
				{
					num = 25;
					num2 = num;
				}
				else
				{
					num = 1;
					num2 = num;
				}
				break;
			case 14:
				num = 17;
				num2 = num;
				break;
			case 17:
				if (A_0 != byte.MaxValue)
				{
					num = 8;
					num2 = num;
					break;
				}
				goto IL_01f3;
			case 12:
				num = 15;
				num2 = num;
				break;
			case 10:
				num = 22;
				num2 = num;
				break;
			case 16:
				num = 21;
				num2 = num;
				break;
			case 21:
				if (A_0 != 32)
				{
					num = 10;
					num2 = num;
					break;
				}
				goto IL_01f3;
			case 26:
				num = 0;
				num2 = num;
				break;
			case 0:
				if ((uint)(A_0 - 192) > 2u)
				{
					num = 14;
					num2 = num;
					break;
				}
				logEntryType = (LogEntryType)A_0;
				return logEntryType.ToString().Replace("LOG_ERR_", "").Replace("_", " ") + ": " + BitConverter.ToString(A_1).Replace("-", " ") + Environment.NewLine;
			case 6:
				num = 9;
				num2 = num;
				break;
			case 9:
				if ((uint)(A_0 - 144) > 2u)
				{
					num = 12;
					num2 = num;
					break;
				}
				goto IL_01f3;
			case 11:
			{
				num = 3613;
				short num3 = num;
				num = 3613;
				switch (num3 == num)
				{
				case false:
				case true:
					break;
				default:
					goto IL_02d0;
				}
				goto case 10;
			}
			case 3:
				num = 24;
				num2 = num;
				break;
			case 25:
				num = 18;
				num2 = num;
				break;
			case 18:
				if ((uint)A_0 > 32u)
				{
					num = 11;
					num2 = num;
				}
				else
				{
					num = 20;
					num2 = num;
				}
				break;
			case 4:
				num = 19;
				num2 = num;
				break;
			case 19:
				if ((uint)(A_0 - 128) > 1u)
				{
					num = 3;
					num2 = num;
					break;
				}
				goto IL_01f3;
			case 20:
				num = 7;
				num2 = num;
				break;
			case 7:
				switch (A_0)
				{
				case 17:
				{
					string text = Encoding.ASCII.GetString(A_1);
					return "CONFIG SET: " + text + Environment.NewLine;
				}
				case 16:
				case 19:
					break;
				case 18:
					return "SETTING SET: " + (A_1[0] - 48) + Environment.NewLine;
				default:
					num = 16;
					num2 = num;
					goto end_IL_0049;
				}
				goto IL_01f3;
			case 1:
				if ((uint)A_0 <= 146u)
				{
					num = 27;
					num2 = num;
				}
				else
				{
					num = 2;
					num2 = num;
				}
				break;
			case 8:
				num = 13;
				num2 = num;
				break;
			case 2:
				if ((uint)(A_0 - 160) > 1u)
				{
					num = 26;
					num2 = num;
					break;
				}
				goto IL_01f3;
			case 27:
				num = 23;
				num2 = num;
				break;
			case 23:
				if ((uint)(A_0 - 132) > 3u)
				{
					num = 6;
					num2 = num;
					break;
				}
				goto IL_01f3;
			case 13:
			case 15:
			case 22:
			case 24:
				{
					num = 0;
					_ = num;
					return A_0.ToString("X2") + BitConverter.ToString(A_1).Replace(" -", " ") + Environment.NewLine;
				}
				IL_01f3:
				logEntryType = (LogEntryType)A_0;
				return logEntryType.ToString().Replace("LOG_INFO_", "").Replace("_", " ") + ": " + BitConverter.ToString(A_1).Replace("-", " ") + Environment.NewLine;
				IL_02d0:
				num = 0;
				if (num != 0)
				{
				}
				if ((uint)(A_0 - 64) > 7u)
				{
					num = 4;
					num2 = num;
					break;
				}
				goto IL_01f3;
				end_IL_0049:
				break;
			}
		}
	}
}
