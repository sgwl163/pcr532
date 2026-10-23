using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

[CompilerGenerated]
internal sealed class a<a, b, c, d>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly a m_a;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly b b;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly c c;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly d d;

	public a UID
	{
		get
		{
			short num = -31521;
			short num2 = num;
			num = -31521;
			switch (num2 == num)
			{
			default:
				num = 1;
				if (num != 0)
				{
				}
				num = 0;
				_ = num;
				num = 0;
				if (num != 0)
				{
				}
				return this.a;
			}
		}
	}

	public b Sector
	{
		get
		{
			short num = 23871;
			short num2 = num;
			num = 23871;
			switch (num2 == num)
			{
			default:
				num = 1;
				if (num != 0)
				{
				}
				num = 0;
				_ = num;
				num = 0;
				if (num != 0)
				{
				}
				return this.b;
			}
		}
	}

	public c Block
	{
		get
		{
			short num = 8073;
			short num2 = num;
			num = 8073;
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
				return this.c;
			}
		}
	}

	public d KeyType
	{
		get
		{
			short num = 16760;
			short num2 = num;
			num = 16760;
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
				return this.d;
			}
		}
	}

	[DebuggerHidden]
	public a(a A_0, b A_1, c A_2, d A_3)
	{
		this.a = A_0;
		this.b = A_1;
		this.c = A_2;
		this.d = A_3;
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		switch (0)
		{
		case 0:
			goto IL_0038;
		}
		goto IL_000a;
		IL_000a:
		int num = default(int);
		global::a<a, b, c, d> a2 = default(global::a<a, b, c, d>);
		short num2;
		while (true)
		{
			switch (num)
			{
			case 2:
				if (this != a2)
				{
					num2 = 21260;
					short num3 = num2;
					num2 = 21260;
					switch (num3 == num2)
					{
					default:
						num2 = 0;
						if (num2 != 0)
						{
						}
						num2 = 1;
						num = num2;
						continue;
					case false:
					case true:
						break;
					}
					goto case 3;
				}
				return true;
			case 9:
				num2 = 6;
				num = num2;
				continue;
			case 6:
				if (EqualityComparer<b>.Default.Equals(this.b, a2.b))
				{
					num2 = 7;
					num = num2;
					continue;
				}
				goto IL_0157;
			case 1:
				num2 = 0;
				num = num2;
				continue;
			case 0:
				if (a2 != null)
				{
					num2 = 3;
					num = num2;
					continue;
				}
				goto IL_0157;
			case 3:
				num2 = 8;
				num = num2;
				continue;
			case 8:
				if (EqualityComparer<a>.Default.Equals(this.a, a2.a))
				{
					num2 = 9;
					num = num2;
					continue;
				}
				goto IL_0157;
			case 7:
				num2 = 4;
				num = num2;
				continue;
			case 4:
				if (EqualityComparer<c>.Default.Equals(this.c, a2.c))
				{
					num2 = 5;
					num = num2;
					continue;
				}
				goto IL_0157;
			case 5:
				{
					num2 = 0;
					_ = num2;
					return EqualityComparer<d>.Default.Equals(this.d, a2.d);
				}
				IL_0157:
				num2 = 1;
				if (num2 != 0)
				{
				}
				return false;
			}
			break;
		}
		goto IL_0038;
		IL_0038:
		a2 = value as global::a<a, b, c, d>;
		num2 = 2;
		num = num2;
		goto IL_000a;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		short num = 28098;
		short num2 = num;
		num = 28098;
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
			num = 0;
			_ = num;
			return (((94184230 * -1521134295 + EqualityComparer<a>.Default.GetHashCode(this.a)) * -1521134295 + EqualityComparer<b>.Default.GetHashCode(this.b)) * -1521134295 + EqualityComparer<c>.Default.GetHashCode(this.c)) * -1521134295 + EqualityComparer<d>.Default.GetHashCode(this.d);
		}
	}

	[DebuggerHidden]
	public override string ToString()
	{
		short num = -26508;
		short num2 = num;
		num = -26508;
		switch (num2 == num)
		{
		default:
		{
			num = 0;
			if (num != 0)
			{
			}
			num = 1;
			if (num != 0)
			{
			}
			num = 0;
			_ = num;
			object[] array = new object[4];
			a val = this.a;
			array[0] = ((val != null) ? val.ToString() : null);
			b val2 = this.b;
			array[1] = ((val2 != null) ? val2.ToString() : null);
			c val3 = this.c;
			array[2] = ((val3 != null) ? val3.ToString() : null);
			d val4 = this.d;
			array[3] = ((val4 != null) ? val4.ToString() : null);
			return string.Format(null, "{{ UID = {0}, Sector = {1}, Block = {2}, KeyType = {3} }}", array);
		}
		}
	}
}
