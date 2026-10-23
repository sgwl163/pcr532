using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ChameleonMiniGUI.Json;

namespace ChameleonMiniGUI.Dump;

public class MctDumpStrategy : DumpStrategy
{
	public override string Extension
	{
		get
		{
			short num = 3621;
			short num2 = num;
			num = 3621;
			switch (num2 == num)
			{
			default:
				num = 0;
				if (num != 0)
				{
				}
				num = 0;
				_ = num;
				num = 1;
				if (num != 0)
				{
				}
				return ".mct";
			}
		}
	}

	public MctDumpStrategy(string fileName)
	{
		base.FileName = fileName;
	}

	public override byte[] Read()
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = -17563;
		short num2 = num;
		num = -17563;
		switch (num2 == num)
		{
		default:
		{
			num = 0;
			_ = num;
			num = 0;
			if (num != 0)
			{
			}
			IEnumerable<string> values = File.ReadLines(base.FileName).Where(delegate(string A_0)
			{
				short num3 = -3299;
				short num4 = num3;
				num3 = -3299;
				switch (num4 == num3)
				{
				default:
					num3 = 0;
					if (num3 != 0)
					{
					}
					num3 = 0;
					_ = num3;
					num3 = 1;
					if (num3 != 0)
					{
					}
					return A_0.Length == 32;
				}
			}).Select(delegate(string A_0)
			{
				short num3 = 20005;
				short num4 = num3;
				num3 = 20005;
				switch (num4 == num3)
				{
				default:
					num3 = 1;
					if (num3 != 0)
					{
					}
					num3 = 0;
					_ = num3;
					num3 = 0;
					if (num3 != 0)
					{
					}
					return A_0.Replace('-', 'F');
				}
			});
			return MifareClassicModel.StringToByteArray(string.Join("", values));
		}
		}
	}

	public override void Save(byte[] data)
	{
		short num = 0;
		switch (num)
		{
		}
		num = 0;
		_ = num;
		num = 1;
		if (num != 0)
		{
		}
		MifareClassicModel mifareClassicModel = new MifareClassicModel();
		mifareClassicModel.Blocks = MifareClassicModel.ToNestedByteArray(data);
		List<string> list = new List<string>();
		using (Dictionary<string, MifareClassicSectorKey>.ValueCollection.Enumerator enumerator = mifareClassicModel.SectorKeys.Values.GetEnumerator())
		{
			num = 3;
			int num2 = num;
			int num3 = default(int);
			MifareClassicSectorKey current = default(MifareClassicSectorKey);
			while (true)
			{
				switch (num2)
				{
				case 3:
				{
					num = 7612;
					short num4 = num;
					num = 7612;
					switch (num4 == num)
					{
					case false:
					case true:
						goto IL_012c;
					}
					num = 0;
					if (num != 0)
					{
					}
					switch (0)
					{
					default:
						continue;
					case 0:
						break;
					}
					goto default;
				}
				default:
					num = 5;
					num2 = num;
					continue;
				case 5:
					if (!enumerator.MoveNext())
					{
						num = 4;
						num2 = num;
						continue;
					}
					goto IL_012c;
				case 1:
				case 7:
					num = 0;
					num2 = num;
					continue;
				case 0:
					if (num3 < current.BlockCount)
					{
						list.Add(MifareClassicModel.ByteArrayToString(mifareClassicModel.Blocks[current.FirstBlockNumber + num3]));
						num3++;
						num = 1;
						num2 = num;
					}
					else
					{
						num = 2;
						num2 = num;
					}
					continue;
				case 4:
					num = 6;
					num2 = num;
					continue;
				case 6:
					break;
					IL_012c:
					current = enumerator.Current;
					list.Add($"+Sector: {current.SectorNumber}");
					num3 = 0;
					num = 7;
					num2 = num;
					continue;
				}
				break;
			}
		}
		File.WriteAllText(base.FileName, string.Join("\n", list), Encoding.ASCII);
	}
}
