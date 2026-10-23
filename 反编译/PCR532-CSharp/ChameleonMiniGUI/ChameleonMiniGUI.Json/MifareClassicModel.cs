using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace ChameleonMiniGUI.Json;

[DataContract]
[KnownType(typeof(MifareClassicCardInfo))]
public class MifareClassicModel : MifareModel
{
	[CompilerGenerated]
	private sealed class a
	{
		public string a;

		internal byte b(int A_0)
		{
			short num = -1840;
			short num2 = num;
			num = -1840;
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
			return Convert.ToByte(a.Substring(A_0, 2), 16);
		}
	}

	[CompilerGenerated]
	private sealed class b
	{
		public byte[] a;

		public int b;

		internal byte[] c(int A_0)
		{
			short num = -14614;
			short num2 = num;
			num = -14614;
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
			return a.Skip(A_0 * b).Take(b).ToArray();
		}
	}

	[CompilerGenerated]
	private byte[][] m_a;

	[DataMember(Order = 1)]
	public override string FileType
	{
		get
		{
			short num = 0;
			_ = num;
			num = -6723;
			short num2 = num;
			num = -6723;
			switch (num2 == num)
			{
			default:
				num = 0;
				if (num != 0)
				{
				}
				num = 1;
				if (num != 0)
				{
				}
				return "mfcard";
			}
		}
		set
		{
			short num = 0;
			_ = num;
			num = 6281;
			short num2 = num;
			num = 6281;
			switch (num2 == num)
			{
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

	[DataMember(Name = "blocks", Order = 2)]
	public byte[][] Blocks
	{
		[CompilerGenerated]
		get
		{
			short num = 0;
			_ = num;
			num = -6385;
			short num2 = num;
			num = -6385;
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
				return this.m_a;
			}
		}
		[CompilerGenerated]
		set
		{
			short num = 0;
			_ = num;
			num = 29467;
			short num2 = num;
			num = 29467;
			switch (num2 == num)
			{
			}
			num = 0;
			if (num != 0)
			{
			}
			num = 1;
			if (num != 0)
			{
			}
			this.m_a = value;
		}
	}

	[DataMember(Order = 3)]
	public MifareClassicCardInfo Card
	{
		get
		{
			short num = 0;
			_ = num;
			num = 19651;
			short num2 = num;
			num = 19651;
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
				return new MifareClassicCardInfo(this);
			}
		}
		set
		{
			short num = 0;
			_ = num;
			num = 20978;
			short num2 = num;
			num = 20978;
			switch (num2 == num)
			{
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

	[DataMember(Order = 4)]
	public Dictionary<string, MifareClassicSectorKey> SectorKeys
	{
		get
		{
			short num = 0;
			_ = num;
			num = -17243;
			short num2 = num;
			num = -17243;
			switch (num2 == num)
			{
			default:
				num = 0;
				if (num != 0)
				{
				}
				num = 1;
				if (num != 0)
				{
				}
				return Enumerable.Range(0, (Blocks.Length <= 128) ? (Blocks.Length / 4) : (32 + (Blocks.Length - 128) / 16)).ToDictionary(delegate(int A_0)
				{
					short num3 = 11671;
					short num4 = num3;
					num3 = 11671;
					switch (num4 == num3)
					{
					default:
						num3 = 0;
						_ = num3;
						break;
					case true:
						break;
					}
					num3 = 1;
					if (num3 != 0)
					{
					}
					num3 = 0;
					if (num3 != 0)
					{
					}
					return A_0.ToString();
				}, delegate(int A_0)
				{
					short num3 = 14863;
					short num4 = num3;
					num3 = 14863;
					switch (num4 == num3)
					{
					default:
						num3 = 0;
						_ = num3;
						break;
					case true:
						break;
					}
					num3 = 1;
					if (num3 != 0)
					{
					}
					num3 = 0;
					if (num3 != 0)
					{
					}
					return new MifareClassicSectorKey(this, A_0);
				});
			}
		}
		set
		{
			short num = 0;
			_ = num;
			num = 2796;
			short num2 = num;
			num = 2796;
			switch (num2 == num)
			{
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

	public override byte[] ToByteArray()
	{
		short num = 0;
		_ = num;
		num = 1;
		if (num != 0)
		{
		}
		num = -9951;
		short num2 = num;
		num = -9951;
		switch (num2 == num)
		{
		default:
			num = 0;
			if (num != 0)
			{
			}
			return Blocks.SelectMany(delegate(byte[] A_0)
			{
				short num3 = -29996;
				short num4 = num3;
				num3 = -29996;
				switch (num4 == num3)
				{
				default:
					num3 = 0;
					_ = num3;
					break;
				case true:
					break;
				}
				num3 = 0;
				if (num3 != 0)
				{
				}
				num3 = 1;
				if (num3 != 0)
				{
				}
				return A_0;
			}).ToArray();
		}
	}

	public static byte[] StringToByteArray(string hex)
	{
		short num = 0;
		_ = num;
		num = 1;
		if (num != 0)
		{
		}
		num = -8032;
		short num2 = num;
		num = -8032;
		switch (num2 == num)
		{
		default:
			num = 0;
			if (num != 0)
			{
			}
			return Enumerable.Range(0, hex.Length).Where(delegate(int A_0)
			{
				short num3 = 2993;
				short num4 = num3;
				num3 = 2993;
				switch (num4 == num3)
				{
				default:
					num3 = 0;
					_ = num3;
					break;
				case true:
					break;
				}
				num3 = 1;
				if (num3 != 0)
				{
				}
				num3 = 0;
				if (num3 != 0)
				{
				}
				return A_0 % 2 == 0;
			}).Select(delegate(int A_0)
			{
				short num3 = -1840;
				short num4 = num3;
				num3 = -1840;
				switch (num4 == num3)
				{
				default:
					num3 = 0;
					_ = num3;
					break;
				case true:
					break;
				}
				num3 = 1;
				if (num3 != 0)
				{
				}
				num3 = 0;
				if (num3 != 0)
				{
				}
				return Convert.ToByte(hex.Substring(A_0, 2), 16);
			})
				.ToArray();
		}
	}

	public static string ByteArrayToString(IEnumerable<byte> bytes)
	{
		short num = 20051;
		short num2 = num;
		num = 20051;
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
		return string.Join("", bytes.Select(delegate(byte A_0)
		{
			short num3 = -3178;
			short num4 = num3;
			num3 = -3178;
			switch (num4 == num3)
			{
			default:
				num3 = 0;
				_ = num3;
				break;
			case true:
				break;
			}
			num3 = 1;
			if (num3 != 0)
			{
			}
			num3 = 0;
			if (num3 != 0)
			{
			}
			return A_0.ToString("X2");
		}));
	}

	public static byte[][] ToNestedByteArray(byte[] data, int blockSize = 16)
	{
		short num = 5882;
		short num2 = num;
		num = 5882;
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
		return Enumerable.Range(0, data.Length / blockSize).Select(delegate(int A_0)
		{
			short num3 = -14614;
			short num4 = num3;
			num3 = -14614;
			switch (num4 == num3)
			{
			default:
				num3 = 0;
				_ = num3;
				break;
			case true:
				break;
			}
			num3 = 1;
			if (num3 != 0)
			{
			}
			num3 = 0;
			if (num3 != 0)
			{
			}
			return data.Skip(A_0 * blockSize).Take(blockSize).ToArray();
		}).ToArray();
	}

	[CompilerGenerated]
	private MifareClassicSectorKey a(int A_0)
	{
		short num = 14863;
		short num2 = num;
		num = 14863;
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
		return new MifareClassicSectorKey(this, A_0);
	}
}
