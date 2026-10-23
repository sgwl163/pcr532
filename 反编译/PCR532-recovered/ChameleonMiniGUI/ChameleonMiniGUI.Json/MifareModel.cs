using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace ChameleonMiniGUI.Json;

[DataContract]
public abstract class MifareModel
{
	[CompilerGenerated]
	private string a;

	[CompilerGenerated]
	private string b;

	[DataMember(Order = 0)]
	public string Created
	{
		[CompilerGenerated]
		get
		{
			short num = 10058;
			short num2 = num;
			num = 10058;
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
			short num = 29981;
			short num2 = num;
			num = 29981;
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
			a = value;
		}
	}

	[DataMember(Order = 1)]
	public virtual string FileType
	{
		[CompilerGenerated]
		get
		{
			short num = -30811;
			short num2 = num;
			num = -30811;
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
			return b;
		}
		[CompilerGenerated]
		set
		{
			short num = -7580;
			short num2 = num;
			num = -7580;
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

	public abstract byte[] ToByteArray();
}
