using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace ChameleonMiniGUI.Json;

[DataContract]
public class MifareClassicSectorKey
{
	private MifareClassicModel m_a;

	[CompilerGenerated]
	private int b;

	private static readonly Dictionary<byte, string> c;

	private static readonly Dictionary<byte, string> d;

	public int SectorNumber
	{
		[CompilerGenerated]
		get
		{
			short num = 9637;
			short num2 = num;
			num = 9637;
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
			return b;
		}
		[CompilerGenerated]
		set
		{
			short num = -8994;
			short num2 = num;
			num = -8994;
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
			b = value;
		}
	}

	public int FirstBlockNumber
	{
		get
		{
			if (SectorNumber < 32)
			{
				while (true)
				{
					short num = 1;
					if (num != 0)
					{
					}
					num = 0;
					_ = num;
					num = 29488;
					short num2 = num;
					num = 29488;
					switch (num2 == num)
					{
					case false:
					case true:
						break;
					default:
						num = 0;
						if (num != 0)
						{
						}
						return SectorNumber * 4;
					}
				}
			}
			return 128 + (SectorNumber - 32) * 16;
		}
	}

	private int KeyBlockNumber
	{
		get
		{
			if (SectorNumber < 32)
			{
				while (true)
				{
					short num = 0;
					_ = num;
					num = 31661;
					short num2 = num;
					num = 31661;
					switch (num2 == num)
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
						return SectorNumber * 4 + 3;
					}
				}
			}
			return 128 + (SectorNumber - 32) * 16 + 15;
		}
	}

	public int BlockCount
	{
		get
		{
			if (SectorNumber >= 32)
			{
				while (true)
				{
					short num = 0;
					_ = num;
					num = -9281;
					short num2 = num;
					num = -9281;
					switch (num2 == num)
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
						return 16;
					}
				}
			}
			return 4;
		}
	}

	[DataMember(Order = 0)]
	public string KeyA
	{
		get
		{
			short num = -7970;
			short num2 = num;
			num = -7970;
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
			return MifareClassicModel.ByteArrayToString(this.m_a.Blocks[KeyBlockNumber].Take(6));
		}
		set
		{
			short num = -1390;
			short num2 = num;
			num = -1390;
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
			if (num == 0)
			{
			}
		}
	}

	[DataMember(Order = 1)]
	public string KeyB
	{
		get
		{
			short num = -30952;
			short num2 = num;
			num = -30952;
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
			return MifareClassicModel.ByteArrayToString(this.m_a.Blocks[KeyBlockNumber].Skip(10).Take(6));
		}
		set
		{
			short num = 7076;
			short num2 = num;
			num = 7076;
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
	public string AccessConditions
	{
		get
		{
			short num = 1;
			if (num != 0)
			{
			}
			num = 0;
			_ = num;
			num = 9962;
			short num2 = num;
			num = 9962;
			switch (num2 == num)
			{
			default:
				num = 0;
				if (num != 0)
				{
				}
				return MifareClassicModel.ByteArrayToString(this.m_a.Blocks[KeyBlockNumber].Skip(6).Take(4));
			}
		}
		set
		{
			short num = -30721;
			short num2 = num;
			num = -30721;
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

	[DataMember(Order = 3)]
	public Dictionary<string, string> AccessConditionsText
	{
		get
		{
			short num = -6945;
			short num2 = num;
			num = -6945;
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
			byte[] source = this.m_a.Blocks[KeyBlockNumber];
			byte[] a_ = source.Skip(6).Take(4).ToArray();
			return new Dictionary<string, string>
			{
				[a(0)] = a(0, a_),
				[a(1)] = a(1, a_),
				[a(2)] = a(2, a_),
				["block" + KeyBlockNumber] = a(3, a_),
				["UserData"] = MifareClassicModel.ByteArrayToString(source.Skip(9).Take(1))
			};
		}
		set
		{
			short num = -15144;
			short num2 = num;
			num = -15144;
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

	public MifareClassicSectorKey()
	{
	}

	public MifareClassicSectorKey(MifareClassicModel mfc, int sector)
	{
		this.m_a = mfc;
		SectorNumber = sector;
	}

	private string a(int A_0)
	{
		int firstBlockNumber = FirstBlockNumber;
		if (SectorNumber < 32)
		{
			while (true)
			{
				short num = 0;
				_ = num;
				num = 1;
				if (num != 0)
				{
				}
				num = 28287;
				short num2 = num;
				num = 28287;
				switch (num2 == num)
				{
				case false:
				case true:
					break;
				default:
					num = 0;
					if (num != 0)
					{
					}
					return "block" + (firstBlockNumber + A_0);
				}
			}
		}
		return $"block{firstBlockNumber + A_0 * 5}~block{firstBlockNumber + A_0 * 5 + 4}";
	}

	private static string a(int A_0, byte[] A_1)
	{
		switch (0)
		{
		case 0:
			goto IL_0028;
		}
		goto IL_000a;
		IL_000a:
		int num = default(int);
		byte key = default(byte);
		short num2;
		while (true)
		{
			switch (num)
			{
			case 4:
				if (A_0 == 3)
				{
					num2 = 0;
					num = num2;
				}
				else
				{
					num2 = 3;
					num = num2;
				}
				continue;
			case 0:
			{
				num2 = 2080;
				short num3 = num2;
				num2 = 2080;
				switch (num3 == num2)
				{
				default:
					num2 = 0;
					if (num2 != 0)
					{
					}
					num2 = 2;
					num = num2;
					continue;
				case false:
				case true:
					break;
				}
				goto case 3;
			}
			case 3:
				if (c.ContainsKey(key))
				{
					num2 = 0;
					_ = num2;
					num2 = 1;
					num = num2;
					continue;
				}
				goto IL_01cb;
			case 2:
				if (d.ContainsKey(key))
				{
					num2 = 5;
					num = num2;
					continue;
				}
				goto IL_01cb;
			case 5:
				num2 = 1;
				if (num2 != 0)
				{
				}
				return d[key];
			case 1:
				{
					return c[key];
				}
				IL_01cb:
				return "none";
			}
			break;
		}
		goto IL_0028;
		IL_0028:
		byte num4 = (byte)(((A_1[1] >> 4) & 0xF) >> A_0);
		byte b = (byte)((A_1[2] & 0xF) >> A_0);
		byte b2 = (byte)(((A_1[2] >> 4) & 0xF) >> A_0);
		key = (byte)(((num4 & 1) << 2) | ((b & 1) << 1) | (b2 & 1));
		num2 = 4;
		num = num2;
		goto IL_000a;
	}

	static MifareClassicSectorKey()
	{
		short num = -26471;
		short num2 = num;
		num = -26471;
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
		c = new Dictionary<byte, string>
		{
			[0] = "rdAB wrAB incAB dectrAB",
			[1] = "rdAB dectrAB",
			[2] = "rdAB",
			[3] = "rdB wrB",
			[4] = "rdAB wrB",
			[5] = "rdB",
			[6] = "rdAB wrB incB dectrAB",
			[7] = "none"
		};
		d = new Dictionary<byte, string>
		{
			[0] = "rdAbyA rdCbyA rdBbyA wrBbyA",
			[1] = "wrAbyA rdCbyA wrCbyA rdBbyA wrBbyA",
			[2] = "rdCbyA rdBbyA",
			[3] = "wrAbyB rdCbyAB wrCbyB wrBbyB",
			[4] = "wrAbyB rdCbyAB wrBbyB",
			[5] = "rdCbyAB wrCbyB",
			[6] = "rdCbyAB",
			[7] = "rdCbyAB"
		};
	}
}
