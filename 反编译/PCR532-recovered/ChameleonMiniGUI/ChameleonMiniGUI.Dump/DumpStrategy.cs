using System.Runtime.CompilerServices;

namespace ChameleonMiniGUI.Dump;

public abstract class DumpStrategy
{
	[CompilerGenerated]
	private string a;

	public string FileName
	{
		[CompilerGenerated]
		get
		{
			short num = 0;
			_ = num;
			num = -11966;
			short num2 = num;
			num = -11966;
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
				return a;
			}
		}
		[CompilerGenerated]
		set
		{
			short num = 0;
			_ = num;
			num = 5357;
			short num2 = num;
			num = 5357;
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
			a = value;
		}
	}

	public abstract string Extension { get; }

	public abstract byte[] Read();

	public abstract void Save(byte[] data);
}
