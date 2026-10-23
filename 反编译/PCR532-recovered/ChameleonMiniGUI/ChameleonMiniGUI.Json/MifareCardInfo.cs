using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace ChameleonMiniGUI.Json;

[DataContract]
public abstract class MifareCardInfo
{
	[CompilerGenerated]
	private MifareModel a;

	public MifareModel Mifare
	{
		[CompilerGenerated]
		get
		{
			short num = 0;
			_ = num;
			num = -7352;
			short num2 = num;
			num = -7352;
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
				return a;
			}
		}
		[CompilerGenerated]
		set
		{
			short num = 0;
			_ = num;
			num = 1;
			if (num != 0)
			{
			}
			num = 9036;
			short num2 = num;
			num = 9036;
			switch (num2 == num)
			{
			}
			num = 0;
			if (num != 0)
			{
			}
			a = value;
		}
	}

	[DataMember(Name = "UID", Order = 0)]
	public abstract string Uid { get; set; }
}
