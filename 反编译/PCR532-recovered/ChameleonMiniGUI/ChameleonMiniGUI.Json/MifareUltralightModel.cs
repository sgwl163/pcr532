using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace ChameleonMiniGUI.Json;

[DataContract]
public class MifareUltralightModel : MifareModel
{
	private MifareUltralightCardInfo a;

	[CompilerGenerated]
	private byte[][] b;

	[DataMember(Order = 1)]
	public override string FileType
	{
		get
		{
			short num = -8237;
			short num2 = num;
			num = -8237;
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
			return "mfu";
		}
		set
		{
			short num = 12826;
			short num2 = num;
			num = 12826;
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
			if (num == 0)
			{
			}
		}
	}

	[DataMember(Order = 2)]
	public MifareUltralightCardInfo Card
	{
		get
		{
			short num = 30006;
			short num2 = num;
			num = 30006;
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
			num = 1;
			if (num != 0)
			{
			}
			return a;
		}
		set
		{
			int num2 = default(int);
			while (true)
			{
				short num;
				switch (0)
				{
				default:
					while (true)
					{
						num = 1;
						if (num != 0)
						{
						}
						switch (num2)
						{
						case 0:
							goto IL_005e;
						case 2:
							goto IL_00a8;
						case 1:
							goto end_IL_0001;
						}
						break;
						IL_005e:
						if (a == null)
						{
							goto end_IL_0001;
						}
						num = 0;
						_ = num;
						num = 2;
						num2 = num;
						continue;
						IL_00a8:
						a.Mifare = this;
						num = 1;
						num2 = num;
					}
					goto case 0;
				case 0:
					{
						a = value;
						num = 0;
						num2 = num;
						goto default;
					}
					end_IL_0001:
					break;
				}
				num = -3620;
				short num3 = num;
				num = -3620;
				switch (num3 == num)
				{
				case false:
				case true:
					continue;
				}
				num = 0;
				if (num == 0)
				{
				}
				return;
			}
		}
	}

	[DataMember(Name = "blocks", Order = 3)]
	public byte[][] Blocks
	{
		[CompilerGenerated]
		get
		{
			short num = 0;
			_ = num;
			num = -27395;
			short num2 = num;
			num = -27395;
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
				return b;
			}
		}
		[CompilerGenerated]
		set
		{
			short num = 0;
			_ = num;
			num = -17243;
			short num2 = num;
			num = -17243;
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
			b = value;
		}
	}

	public override byte[] ToByteArray()
	{
		int num = default(int);
		Func<string, byte[]> func = default(Func<string, byte[]>);
		switch (0)
		{
		default:
		{
			byte[] second = default(byte[]);
			while (true)
			{
				short num2;
				switch (num)
				{
				case 2:
					if (a.Counter0 != null)
					{
						num2 = 3;
						num = num2;
						continue;
					}
					goto IL_0287;
				case 3:
					num2 = 7;
					num = num2;
					continue;
				case 7:
					if (a.Counter1 != null)
					{
						num2 = 26159;
						short num3 = num2;
						num2 = 26159;
						switch (num3 == num2)
						{
						default:
							num2 = 0;
							if (num2 != 0)
							{
							}
							num2 = 0;
							num = num2;
							continue;
						case false:
						case true:
							break;
						}
						goto case 0;
					}
					goto IL_0287;
				case 0:
					num2 = 1;
					num = num2;
					continue;
				case 1:
					if (a.Counter2 != null)
					{
						num2 = 6;
						num = num2;
						continue;
					}
					goto IL_0287;
				case 6:
					second = new byte[1] { (byte)(Blocks.Length - 1) };
					num2 = 5;
					num = num2;
					continue;
				case 5:
					return func(a.Version).Concat(func(a.TBO_0)).Concat(func(a.TBO_1)).Concat(second)
						.Concat(func(a.Signature))
						.Concat(func(a.Counter0))
						.Concat(func(a.Tearing0))
						.Concat(func(a.Counter1))
						.Concat(func(a.Tearing1))
						.Concat(func(a.Counter2))
						.Concat(func(a.Tearing2))
						.Concat(Blocks.SelectMany(delegate(byte[] A_0)
						{
							short num4 = 0;
							_ = num4;
							num4 = -9088;
							short num5 = num4;
							num4 = -9088;
							switch (num5 == num4)
							{
							default:
								num4 = 0;
								if (num4 != 0)
								{
								}
								num4 = 1;
								if (num4 != 0)
								{
								}
								return A_0;
							}
						}))
						.ToArray();
				case 4:
					{
						return Blocks.SelectMany(delegate(byte[] A_0)
						{
							short num4 = 0;
							_ = num4;
							num4 = -748;
							short num5 = num4;
							num4 = -748;
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
								return A_0;
							}
						}).ToArray();
					}
					IL_0287:
					num2 = 1;
					if (num2 != 0)
					{
					}
					num2 = 0;
					_ = num2;
					num2 = 4;
					num = num2;
					continue;
				}
				break;
			}
			goto case 0;
		}
		case 0:
		{
			func = MifareClassicModel.StringToByteArray;
			short num2 = 2;
			num = num2;
			goto default;
		}
		}
	}

	public static bool HasUltralightNewHeader(IReadOnlyList<byte> bytes)
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
					goto end_IL_0020;
				case 0:
					break;
				}
				goto default;
			default:
				if (bytes.Count % 4 == 0)
				{
					num = 5;
					num2 = num;
					break;
				}
				goto case 4;
			case 5:
				num = 1;
				if (num != 0)
				{
				}
				num = 6;
				num2 = num;
				break;
			case 9:
				return false;
			case 2:
				num = 1;
				num2 = num;
				break;
			case 1:
				if (bytes[9] != 0)
				{
					num = 9;
					num2 = num;
				}
				else
				{
					num = 8;
					num2 = num;
				}
				break;
			case 4:
				return false;
			case 7:
				return false;
			case 6:
				if (bytes.Count <= 56)
				{
					num = 4;
					num2 = num;
					break;
				}
				num = 0;
				_ = num;
				num = 3;
				num2 = num;
				break;
			case 8:
				if (bytes[10] != 0)
				{
					num = 7;
					num2 = num;
					break;
				}
				return (bytes.Count - 56) / 4 - 1 == bytes[11];
			case 3:
				{
					num = -13236;
					short num3 = num;
					num = -13236;
					switch (num3 == num)
					{
					case false:
					case true:
						break;
					default:
						goto IL_01c5;
					}
					goto case 2;
				}
				IL_01c5:
				num = 0;
				if (num != 0)
				{
				}
				if (bytes[8] == 0)
				{
					num = 2;
					num2 = num;
					break;
				}
				goto case 9;
				end_IL_0020:
				break;
			}
		}
	}

	public static bool HasUltralightHeader(IReadOnlyList<byte> bytes)
	{
		int num = default(int);
		byte[] second = default(byte[]);
		switch (0)
		{
		default:
		{
			double num4 = default(double);
			while (true)
			{
				short num2;
				switch (num)
				{
				case 8:
					if (bytes.SequenceEqual(second))
					{
						num2 = 6;
						num = num2;
					}
					else
					{
						num4 = 0.0;
						num2 = 13;
						num = num2;
					}
					continue;
				case 12:
					if (bytes[10] != 189)
					{
						num2 = 0;
						num = num2;
						continue;
					}
					goto case 3;
				case 9:
					num4 += 0.15;
					num2 = 17;
					num = num2;
					continue;
				case 7:
					num2 = 16;
					num = num2;
					continue;
				case 16:
					if (bytes[1] == 4)
					{
						num2 = 2;
						num = num2;
						continue;
					}
					goto case 20;
				case 5:
					num2 = 21;
					num = num2;
					continue;
				case 21:
					if (bytes[12] == 189)
					{
						num2 = 3;
						num = num2;
						continue;
					}
					goto case 1;
				case 13:
					if (bytes[0] == 0)
					{
						num2 = 7;
						num = num2;
						continue;
					}
					goto case 20;
				case 4:
					num4 += 0.15;
					num2 = 18;
					num = num2;
					continue;
				case 18:
					num2 = 0;
					_ = num2;
					goto IL_00ac;
				case 3:
					num4 += 0.35;
					num2 = 1;
					num = num2;
					continue;
				case 11:
					if (bytes[9] == 0)
					{
						num2 = 9;
						num = num2;
						continue;
					}
					goto case 17;
				case 2:
					num4 += 0.25;
					num2 = 20;
					num = num2;
					continue;
				case 0:
					num2 = 15;
					num = num2;
					continue;
				case 15:
					if (bytes[11] != 189)
					{
						num2 = 5;
						num = num2;
						continue;
					}
					goto case 3;
				case 17:
					num2 = 19;
					num = num2;
					continue;
				case 19:
					if (bytes[15] == 0)
					{
						num2 = 4;
						num = num2;
						continue;
					}
					goto IL_00ac;
				case 6:
					return true;
				case 20:
				{
					num2 = -31821;
					short num3 = num2;
					num2 = -31821;
					switch (num3 == num2)
					{
					case false:
					case true:
						break;
					default:
						num2 = 0;
						if (num2 != 0)
						{
						}
						num2 = 14;
						num = num2;
						continue;
					}
					goto IL_0267;
				}
				case 14:
					if (bytes[8] == 0)
					{
						num2 = 10;
						num = num2;
						continue;
					}
					goto case 17;
				case 10:
					num2 = 1;
					if (num2 == 0)
					{
					}
					goto IL_0267;
				case 1:
					{
						return num4 >= 0.5;
					}
					IL_0267:
					num2 = 11;
					num = num2;
					continue;
					IL_00ac:
					num2 = 12;
					num = num2;
					continue;
				}
				break;
			}
			goto case 0;
		}
		case 0:
		{
			second = new byte[48];
			short num2 = 8;
			num = num2;
			goto default;
		}
		}
	}

	public static MifareUltralightModel Parse(byte[] data)
	{
		short num = 0;
		int num2 = num;
		bool flag = default(bool);
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
			{
				bool num4 = HasUltralightNewHeader(data);
				flag = !num4 && HasUltralightHeader(data);
				if (num4)
				{
					num = 3;
					num2 = num;
				}
				else
				{
					num = 2;
					num2 = num;
				}
				break;
			}
			case 3:
				return new MifareUltralightModel
				{
					Created = "ChameleonMiniGUI",
					Card = new MifareUltralightCardInfo
					{
						Version = MifareClassicModel.ByteArrayToString(data.Take(8)),
						TBO_0 = MifareClassicModel.ByteArrayToString(data.Skip(8).Take(2)),
						Tearing0 = MifareClassicModel.ByteArrayToString(data.Skip(47).Take(1)),
						Tearing1 = MifareClassicModel.ByteArrayToString(data.Skip(51).Take(1)),
						Tearing2 = MifareClassicModel.ByteArrayToString(data.Skip(55).Take(1)),
						TBO_1 = MifareClassicModel.ByteArrayToString(data.Skip(10).Take(1)),
						Signature = MifareClassicModel.ByteArrayToString(data.Skip(12).Take(32)),
						Counter0 = MifareClassicModel.ByteArrayToString(data.Skip(44).Take(3)),
						Counter1 = MifareClassicModel.ByteArrayToString(data.Skip(48).Take(3)),
						Counter2 = MifareClassicModel.ByteArrayToString(data.Skip(52).Take(3))
					},
					Blocks = MifareClassicModel.ToNestedByteArray(data.Skip(56).ToArray(), 4)
				};
			case 1:
				num = 0;
				_ = num;
				return new MifareUltralightModel
				{
					Created = "ChameleonMiniGUI",
					Card = new MifareUltralightCardInfo
					{
						Version = MifareClassicModel.ByteArrayToString(data.Take(8)),
						TBO_0 = MifareClassicModel.ByteArrayToString(data.Skip(8).Take(2)),
						Tearing0 = MifareClassicModel.ByteArrayToString(data.Skip(10).Take(1)),
						Tearing1 = MifareClassicModel.ByteArrayToString(data.Skip(10).Take(1)),
						Tearing2 = MifareClassicModel.ByteArrayToString(data.Skip(10).Take(1)),
						TBO_1 = MifareClassicModel.ByteArrayToString(data.Skip(15).Take(1)),
						Signature = MifareClassicModel.ByteArrayToString(data.Skip(16).Take(32)),
						Counter0 = "000000",
						Counter1 = "000000",
						Counter2 = "000000"
					},
					Blocks = MifareClassicModel.ToNestedByteArray(data.Skip(48).ToArray(), 4)
				};
			case 2:
				{
					if (flag)
					{
						num = 1;
						num2 = num;
						break;
					}
					num = 16196;
					short num3 = num;
					num = 16196;
					switch (num3 == num)
					{
					case false:
					case true:
						break;
					default:
						num = 1;
						if (num != 0)
						{
						}
						num = 0;
						if (num != 0)
						{
						}
						return new MifareUltralightModel
						{
							Created = "ChameleonMiniGUI",
							Card = new MifareUltralightCardInfo
							{
								Version = null,
								TBO_0 = null,
								Tearing0 = null,
								Tearing1 = null,
								Tearing2 = null,
								TBO_1 = null,
								Signature = null,
								Counter0 = null,
								Counter1 = null,
								Counter2 = null
							},
							Blocks = MifareClassicModel.ToNestedByteArray(data.ToArray(), 4)
						};
					}
					goto case 0;
				}
				end_IL_001f:
				break;
			}
		}
	}
}
