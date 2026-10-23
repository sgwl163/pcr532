using System.Linq;
using System.Runtime.Serialization;

namespace ChameleonMiniGUI.Json;

[DataContract]
public class MifareClassicCardInfo : MifareCardInfo
{
	private MifareClassicModel mfc
	{
		get
		{
			short num = 0;
			_ = num;
			num = -24638;
			short num2 = num;
			num = -24638;
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
				return base.Mifare as MifareClassicModel;
			}
		}
	}

	[DataMember(Name = "UID", Order = 0)]
	public override string Uid
	{
		get
		{
			short num = 0;
			_ = num;
			num = -7451;
			short num2 = num;
			num = -7451;
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
				return MifareClassicModel.ByteArrayToString(mfc.Blocks[0].Take(4));
			}
		}
		set
		{
			short num = 0;
			_ = num;
			num = 1;
			if (num != 0)
			{
			}
			num = -3396;
			short num2 = num;
			num = -3396;
			switch (num2 == num)
			{
			}
			num = 0;
			if (num == 0)
			{
			}
		}
	}

	[DataMember(Name = "SAK", Order = 1)]
	public string Sak
	{
		get
		{
			short num = 0;
			_ = num;
			num = -2015;
			short num2 = num;
			num = -2015;
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
				return MifareClassicModel.ByteArrayToString(mfc.Blocks[0].Skip(5).Take(1));
			}
		}
		set
		{
			short num = 0;
			_ = num;
			num = -24674;
			short num2 = num;
			num = -24674;
			switch (num2 == num)
			{
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

	[DataMember(Name = "ATQA", Order = 2)]
	public string Atqa
	{
		get
		{
			short num = 0;
			_ = num;
			num = 8072;
			short num2 = num;
			num = 8072;
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
				return MifareClassicModel.ByteArrayToString(mfc.Blocks[0].Skip(6).Take(2));
			}
		}
		set
		{
			short num = 0;
			_ = num;
			num = -893;
			short num2 = num;
			num = -893;
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

	public MifareClassicCardInfo()
	{
	}

	public MifareClassicCardInfo(MifareClassicModel mfc)
	{
		base.Mifare = mfc;
	}
}
