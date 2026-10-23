using System.Collections.Generic;

namespace ChameleonMiniGUI;

public class KeyCompareruid : IComparer<MyKey>
{
	public int Compare(MyKey x, MyKey y)
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
		num = -17387;
		short num2 = num;
		num = -17387;
		switch (num2 == num)
		{
		case false:
		case true:
			goto IL_00de;
		}
		num = 0;
		if (num != 0)
		{
		}
		num = 0;
		int num3 = num;
		goto IL_00ba;
		IL_00de:
		num = 2;
		num3 = num;
		goto IL_00ba;
		IL_00ba:
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
				if (x.UID < y.UID)
				{
					num = 3;
					num3 = num;
					continue;
				}
				return 0;
			case 2:
				return 1;
			}
			if (x.UID > y.UID)
			{
				break;
			}
			num = 1;
			num3 = num;
		}
		goto IL_00de;
	}
}
