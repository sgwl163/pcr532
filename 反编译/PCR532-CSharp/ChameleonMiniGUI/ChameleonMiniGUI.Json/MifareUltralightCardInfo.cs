using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace ChameleonMiniGUI.Json;

[DataContract]
public class MifareUltralightCardInfo : MifareCardInfo
{
	public const int PrefixLength = 48;

	public const int NewPrefixLength = 56;

	[CompilerGenerated]
	private string a;

	[CompilerGenerated]
	private string b;

	[CompilerGenerated]
	private string c;

	[CompilerGenerated]
	private string d;

	[CompilerGenerated]
	private string e;

	[CompilerGenerated]
	private string f;

	[CompilerGenerated]
	private string g;

	[CompilerGenerated]
	private string h;

	[CompilerGenerated]
	private string i;

	[CompilerGenerated]
	private string j;

	private MifareUltralightModel mfu
	{
		get
		{
			short num = 93;
			short num2 = num;
			num = 93;
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
			return base.Mifare as MifareUltralightModel;
		}
	}

	[DataMember(Name = "UID", Order = 0)]
	public override string Uid
	{
		get
		{
			short num = 30235;
			short num2 = num;
			num = 30235;
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
			return MifareClassicModel.ByteArrayToString(mfu.Blocks[0].Take(3).Concat(mfu.Blocks[1]));
		}
		set
		{
			short num = 24027;
			short num2 = num;
			num = 24027;
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

	[DataMember(Order = 1)]
	public string Version
	{
		[CompilerGenerated]
		get
		{
			short num = 25510;
			short num2 = num;
			num = 25510;
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
			return a;
		}
		[CompilerGenerated]
		set
		{
			short num = -22216;
			short num2 = num;
			num = -22216;
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
			a = value;
		}
	}

	[DataMember(Order = 2)]
	public string TBO_0
	{
		[CompilerGenerated]
		get
		{
			short num = 1;
			if (num != 0)
			{
			}
			num = 0;
			_ = num;
			num = 10575;
			short num2 = num;
			num = 10575;
			switch (num2 == num)
			{
			default:
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
			short num = 29227;
			short num2 = num;
			num = 29227;
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

	[DataMember(Order = 3)]
	public string TBO_1
	{
		[CompilerGenerated]
		get
		{
			short num = 22544;
			short num2 = num;
			num = 22544;
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
			return c;
		}
		[CompilerGenerated]
		set
		{
			short num = -6389;
			short num2 = num;
			num = -6389;
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
			c = value;
		}
	}

	[DataMember(Order = 4)]
	public string Signature
	{
		[CompilerGenerated]
		get
		{
			short num = 1162;
			short num2 = num;
			num = 1162;
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
			return d;
		}
		[CompilerGenerated]
		set
		{
			short num = -22835;
			short num2 = num;
			num = -22835;
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
			d = value;
		}
	}

	[DataMember(Order = 5)]
	public string Counter0
	{
		[CompilerGenerated]
		get
		{
			short num = 22686;
			short num2 = num;
			num = 22686;
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
			return e;
		}
		[CompilerGenerated]
		set
		{
			short num = -10530;
			short num2 = num;
			num = -10530;
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
			e = value;
		}
	}

	[DataMember(Order = 6)]
	public string Tearing0
	{
		[CompilerGenerated]
		get
		{
			short num = 2271;
			short num2 = num;
			num = 2271;
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
			return f;
		}
		[CompilerGenerated]
		set
		{
			short num = -23207;
			short num2 = num;
			num = -23207;
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
			f = value;
		}
	}

	[DataMember(Order = 7)]
	public string Counter1
	{
		[CompilerGenerated]
		get
		{
			short num = 27490;
			short num2 = num;
			num = 27490;
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
			return g;
		}
		[CompilerGenerated]
		set
		{
			short num = -26788;
			short num2 = num;
			num = -26788;
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
			g = value;
		}
	}

	[DataMember(Order = 8)]
	public string Tearing1
	{
		[CompilerGenerated]
		get
		{
			short num = 27621;
			short num2 = num;
			num = 27621;
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
			return h;
		}
		[CompilerGenerated]
		set
		{
			short num = 22368;
			short num2 = num;
			num = 22368;
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
			h = value;
		}
	}

	[DataMember(Order = 9)]
	public string Counter2
	{
		[CompilerGenerated]
		get
		{
			short num = 1;
			if (num != 0)
			{
			}
			num = 0;
			_ = num;
			num = 13708;
			short num2 = num;
			num = 13708;
			switch (num2 == num)
			{
			default:
				num = 0;
				if (num != 0)
				{
				}
				return i;
			}
		}
		[CompilerGenerated]
		set
		{
			short num = -4281;
			short num2 = num;
			num = -4281;
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
			i = value;
		}
	}

	[DataMember(Order = 10)]
	public string Tearing2
	{
		[CompilerGenerated]
		get
		{
			short num = 1;
			if (num != 0)
			{
			}
			num = 0;
			_ = num;
			num = -19913;
			short num2 = num;
			num = -19913;
			switch (num2 == num)
			{
			default:
				num = 0;
				if (num != 0)
				{
				}
				return j;
			}
		}
		[CompilerGenerated]
		set
		{
			short num = 22688;
			short num2 = num;
			num = 22688;
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
			j = value;
		}
	}
}
