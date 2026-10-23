using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

internal class c : GroupBox
{
	private Color a;

	private Color b;

	private int m_c;

	private float d;

	[SpecialName]
	public Color e()
	{
		short num = 16056;
		short num2 = num;
		num = 16056;
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
			return a;
		}
	}

	[SpecialName]
	public void e(Color A_0)
	{
		short num = 19958;
		short num2 = num;
		num = 19958;
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
		num = 0;
		_ = num;
		a = A_0;
	}

	[SpecialName]
	public Color f()
	{
		short num = -18135;
		short num2 = num;
		num = -18135;
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
			num = 0;
			_ = num;
			return b;
		}
	}

	[SpecialName]
	public void f(Color A_0)
	{
		short num = 24491;
		short num2 = num;
		num = 24491;
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
		num = 0;
		_ = num;
		b = A_0;
	}

	[SpecialName]
	public int g()
	{
		short num = -10999;
		short num2 = num;
		num = -10999;
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
			return m_c;
		}
	}

	[SpecialName]
	public void e(int A_0)
	{
		short num = -19619;
		short num2 = num;
		num = -19619;
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
		num = 0;
		_ = num;
		m_c = A_0;
	}

	[SpecialName]
	public float h()
	{
		short num = -16146;
		short num2 = num;
		num = -16146;
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
			return d;
		}
	}

	[SpecialName]
	public void e(float A_0)
	{
		short num = -11313;
		short num2 = num;
		num = -11313;
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
		num = 0;
		_ = num;
		d = A_0;
	}

	public c()
	{
		a = SystemColors.ControlDarkDark;
		b = SystemColors.ControlLightLight;
		m_c = 5;
		d = 1f;
		DoubleBuffered = true;
		base.ResizeRedraw = true;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (Application.RenderWithVisualStyles)
		{
			short num = -8538;
			short num2 = num;
			num = -8538;
			switch (num2 == num)
			{
			case false:
			case true:
				break;
			default:
				num = 0;
				_ = num;
				goto case true;
			case true:
			{
				num = 1;
				if (num != 0)
				{
				}
				num = 0;
				if (num != 0)
				{
				}
				Size size = TextRenderer.MeasureText(Text, Font);
				Rectangle a_ = new Rectangle(0, size.Height / 2, base.ClientRectangle.Width - 1, base.ClientRectangle.Height - size.Height / 2 - 2);
				Rectangle a_2 = new Rectangle(1, a_.Y + 1, a_.Width - 2, a_.Height);
				GraphicsPath path = this.e(a_, m_c);
				GraphicsPath path2 = this.e(a_2, m_c);
				e.Graphics.FillPath(new SolidBrush(BackColor), path);
				e.Graphics.DrawPath(new Pen(b, d), path2);
				e.Graphics.DrawPath(new Pen(a, d), path);
				RectangleF rectangleF = e.ClipRectangle;
				rectangleF.X += 6f;
				rectangleF.Width = size.Width;
				rectangleF.Width += 5f;
				rectangleF.Height = size.Height;
				e.Graphics.FillRectangle(new SolidBrush(BackColor), rectangleF);
				e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), rectangleF);
				return;
			}
			}
		}
		base.OnPaint(e);
	}

	private GraphicsPath e(Rectangle A_0, int A_1)
	{
		short num = 25533;
		short num2 = num;
		num = 25533;
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
			return e(A_0.X, A_0.Y, A_0.Width, A_0.Height, A_1);
		}
	}

	private GraphicsPath e(int A_0, int A_1, int A_2, int A_3, int A_4)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 13;
			int num2 = num;
			bool flag = default(bool);
			bool flag2 = default(bool);
			bool flag3 = default(bool);
			int num7 = default(int);
			int num10 = default(int);
			int num6 = default(int);
			int num9 = default(int);
			int num12 = default(int);
			int num8 = default(int);
			int num4 = default(int);
			int num3 = default(int);
			int num5 = default(int);
			GraphicsPath graphicsPath = default(GraphicsPath);
			while (true)
			{
				switch (num2)
				{
				case 13:
					switch (0)
					{
					default:
						continue;
					case 0:
						break;
					}
					goto default;
				default:
					flag = true;
					flag2 = true;
					flag3 = true;
					num7 = A_0 + A_2;
					num10 = A_1 + A_3;
					num6 = num7 - A_4;
					num9 = num10 - A_4;
					num12 = A_0 + A_4;
					num8 = A_1 + A_4;
					num4 = A_4 * 2;
					num3 = num7 - num4;
					num5 = num10 - num4;
					graphicsPath = new GraphicsPath();
					graphicsPath.StartFigure();
					if (true)
					{
						num = 5;
						num2 = num;
						continue;
					}
					graphicsPath.AddLine(A_0, num8, A_0, A_1);
					graphicsPath.AddLine(A_0, A_1, num12, A_1);
					num = 2;
					num2 = num;
					continue;
				case 3:
				case 8:
					graphicsPath.AddLine(num7, num8, num7, num9);
					num = 12;
					num2 = num;
					continue;
				case 12:
					if (!flag2)
					{
						graphicsPath.AddLine(num7, num9, num7, num10);
						graphicsPath.AddLine(num7, num10, num6, num10);
						num = 14;
						num2 = num;
					}
					else
					{
						num = 15;
						num2 = num;
					}
					continue;
				case 2:
					num = 1;
					if (num == 0)
					{
					}
					goto case 11;
				case 0:
					graphicsPath.AddArc(A_0, num5, num4, num4, 90f, 90f);
					goto IL_01e8;
				case 5:
					graphicsPath.AddArc(A_0, A_1, num4, num4, 180f, 90f);
					num = 11;
					num2 = num;
					continue;
				case 6:
				case 14:
					graphicsPath.AddLine(num6, num10, num12, num10);
					num = 7;
					num2 = num;
					continue;
				case 7:
					if (flag3)
					{
						num = 0;
						num2 = num;
						continue;
					}
					graphicsPath.AddLine(num12, num10, A_0, num10);
					graphicsPath.AddLine(A_0, num10, A_0, num9);
					num = 10;
					num2 = num;
					continue;
				case 10:
				{
					num = -31505;
					short num11 = num;
					num = -31505;
					switch (num11 == num)
					{
					case false:
					case true:
						break;
					default:
						goto IL_02eb;
					}
					goto IL_01e8;
				}
				case 11:
					graphicsPath.AddLine(num12, A_1, num6, A_1);
					num = 9;
					num2 = num;
					continue;
				case 9:
					num = 0;
					_ = num;
					if (!flag)
					{
						graphicsPath.AddLine(num6, A_1, num7, A_1);
						graphicsPath.AddLine(num7, A_1, num7, num8);
						num = 3;
						num2 = num;
					}
					else
					{
						num = 4;
						num2 = num;
					}
					continue;
				case 15:
					graphicsPath.AddArc(num3, num5, num4, num4, 0f, 90f);
					num = 6;
					num2 = num;
					continue;
				case 4:
					graphicsPath.AddArc(num3, A_1, num4, num4, 270f, 90f);
					num = 8;
					num2 = num;
					continue;
				case 1:
					break;
					IL_02eb:
					num = 0;
					if (num == 0)
					{
					}
					break;
					IL_01e8:
					num = 1;
					num2 = num;
					continue;
				}
				break;
			}
			graphicsPath.AddLine(A_0, num9, A_0, num8);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}
		}
	}

	public static void e(Control A_0)
	{
		IEnumerator<Control> enumerator = A_0.Controls.Cast<Control>().Where(delegate(Control control)
		{
			short num4 = -3888;
			short num5 = num4;
			num4 = -3888;
			switch (num5 == num4)
			{
			default:
				num4 = 0;
				if (num4 != 0)
				{
				}
				num4 = 0;
				_ = num4;
				num4 = 1;
				if (num4 != 0)
				{
				}
				return control.GetType() == typeof(c);
			}
		}).GetEnumerator();
		short num;
		try
		{
			num = 4;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 4:
					switch (0)
					{
					default:
						continue;
					case 0:
						break;
					}
					goto default;
				default:
					num = 1;
					if (num != 0)
					{
					}
					num = 3;
					num2 = num;
					continue;
				case 3:
				{
					if (enumerator.MoveNext())
					{
						((c)enumerator.Current).Invalidate();
						num = 2;
						num2 = num;
						continue;
					}
					num = -20710;
					short num3 = num;
					num = -20710;
					switch (num3 == num)
					{
					default:
						num = 0;
						if (num != 0)
						{
						}
						num = 0;
						num2 = num;
						continue;
					case false:
					case true:
						break;
					}
					break;
				}
				case 0:
					num = 1;
					num2 = num;
					continue;
				case 1:
					break;
				}
				break;
			}
		}
		finally
		{
			num = 2;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 2:
					switch (0)
					{
					default:
						continue;
					case 0:
						break;
					}
					goto default;
				default:
					if (enumerator != null)
					{
						num = 1;
						num2 = num;
						continue;
					}
					break;
				case 1:
					enumerator.Dispose();
					num = 0;
					num2 = num;
					continue;
				case 0:
					break;
				}
				break;
			}
		}
		num = 0;
		_ = num;
	}
}
