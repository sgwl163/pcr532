using System.Collections.Generic;

namespace ChameleonMiniGUI;

public class KeyComparer : IComparer<MyKey>
{
	public int Compare(MyKey x, MyKey y)
	{
		short num = 25847;
		short num2 = num;
		num = 25847;
		int num3;
		switch (num2 == num)
		{
		default:
			num = 0;
			_ = num;
			goto case true;
		case true:
			num = 0;
			if (num != 0)
			{
			}
			num = 0;
			num3 = num;
			goto IL_0091;
		case false:
		case true:
			{
				num = 1;
				if (num != 0)
				{
				}
				num = 2;
				num3 = num;
				goto IL_0091;
			}
			IL_0091:
			while (true)
			{
				switch (num3)
				{
				case 0:
					switch (0)
					{
					default:
						continue;
					case 0:
						break;
					}
					break;
				case 3:
					return -1;
				case 1:
					if (x.Block < y.Block)
					{
						num = 3;
						num3 = num;
						continue;
					}
					return 0;
				case 2:
					return 1;
				}
				if (x.Block > y.Block)
				{
					break;
				}
				num = 1;
				num3 = num;
			}
			goto case false;
		}
	}
}
