using System.IO;

namespace ChameleonMiniGUI.Dump;

public class BinaryDumpStrategy : DumpStrategy
{
	public override string Extension
	{
		get
		{
			short num = 0;
			_ = num;
			num = 7633;
			short num2 = num;
			num = 7633;
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
				return ".bin";
			}
		}
	}

	public BinaryDumpStrategy(string fileName)
	{
		base.FileName = fileName;
	}

	public override byte[] Read()
	{
		short num = 0;
		_ = num;
		num = 30745;
		short num2 = num;
		num = 30745;
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
			return File.ReadAllBytes(base.FileName);
		}
	}

	public override void Save(byte[] data)
	{
		short num = 0;
		_ = num;
		num = 14245;
		short num2 = num;
		num = 14245;
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
		File.WriteAllBytes(base.FileName, data);
	}
}
