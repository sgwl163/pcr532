using System.ComponentModel;

namespace MifareOneTool;

public class Component1 : Component
{
	private IContainer m_a;

	public Component1()
	{
		a();
	}

	public Component1(IContainer container)
	{
		container.Add(this);
		a();
	}

	protected override void Dispose(bool disposing)
	{
		while (true)
		{
			short num = 0;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 0:
				{
					num = -2729;
					short num3 = num;
					num = -2729;
					switch (num3 == num)
					{
					case false:
					case true:
						break;
					default:
						goto IL_004c;
					}
					break;
				}
				default:
					if (disposing)
					{
						num = 1;
						if (num != 0)
						{
						}
						num = 2;
						num2 = num;
						continue;
					}
					goto case 3;
				case 1:
					this.m_a.Dispose();
					num = 3;
					num2 = num;
					continue;
				case 2:
					num = 4;
					num2 = num;
					continue;
				case 4:
					if (this.m_a != null)
					{
						num = 1;
						num2 = num;
						continue;
					}
					goto case 3;
				case 3:
					{
						base.Dispose(disposing);
						return;
					}
					IL_004c:
					num = 0;
					if (num != 0)
					{
					}
					num = 0;
					_ = num;
					switch (0)
					{
					default:
						continue;
					case 0:
						break;
					}
					goto default;
				}
				break;
			}
		}
	}

	private void a()
	{
		short num = 0;
		_ = num;
		num = 23502;
		short num2 = num;
		num = 23502;
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
		this.m_a = new Container();
	}
}
