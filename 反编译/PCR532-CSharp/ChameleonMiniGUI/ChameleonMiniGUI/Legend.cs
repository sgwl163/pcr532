using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ChameleonMiniGUI;

public class Legend
{
	[CompilerGenerated]
	private string m_a;

	[CompilerGenerated]
	private bool b;

	[CompilerGenerated]
	private bool c;

	[CompilerGenerated]
	private Color d;

	[CompilerGenerated]
	private Color e;

	[CompilerGenerated]
	private Color f;

	[CompilerGenerated]
	private Font g;

	[CompilerGenerated]
	private Point h;

	private float i;

	public string Title
	{
		[CompilerGenerated]
		get
		{
			short num = 14815;
			short num2 = num;
			num = 14815;
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
				return this.m_a;
			}
		}
		[CompilerGenerated]
		set
		{
			short num = -11032;
			short num2 = num;
			num = -11032;
			switch (num2 == num)
			{
			}
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
			this.m_a = value;
		}
	}

	public bool IsLegendVisible
	{
		[CompilerGenerated]
		get
		{
			short num = 17956;
			short num2 = num;
			num = 17956;
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
				return b;
			}
		}
		[CompilerGenerated]
		set
		{
			short num = 6855;
			short num2 = num;
			num = 6855;
			switch (num2 == num)
			{
			}
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
			b = value;
		}
	}

	public bool IsBorderVisible
	{
		[CompilerGenerated]
		get
		{
			short num = 14931;
			short num2 = num;
			num = 14931;
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
				return c;
			}
		}
		[CompilerGenerated]
		set
		{
			short num = 3728;
			short num2 = num;
			num = 3728;
			switch (num2 == num)
			{
			}
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
			c = value;
		}
	}

	public Color LegendBackColor1
	{
		[CompilerGenerated]
		get
		{
			short num = 1;
			if (num != 0)
			{
			}
			num = -12367;
			short num2 = num;
			num = -12367;
			switch (num2 == num)
			{
			default:
				num = 0;
				_ = num;
				num = 0;
				if (num != 0)
				{
				}
				return d;
			}
		}
		[CompilerGenerated]
		set
		{
			short num = -27279;
			short num2 = num;
			num = -27279;
			switch (num2 == num)
			{
			}
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
			d = value;
		}
	}

	public Color LegendBackColor2
	{
		[CompilerGenerated]
		get
		{
			short num = 1;
			if (num != 0)
			{
			}
			num = 24935;
			short num2 = num;
			num = 24935;
			switch (num2 == num)
			{
			default:
				num = 0;
				_ = num;
				num = 0;
				if (num != 0)
				{
				}
				return e;
			}
		}
		[CompilerGenerated]
		set
		{
			short num = 25878;
			short num2 = num;
			num = 25878;
			switch (num2 == num)
			{
			}
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
			e = value;
		}
	}

	public Color LegendBorderColor
	{
		[CompilerGenerated]
		get
		{
			short num = 24724;
			short num2 = num;
			num = 24724;
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
				return f;
			}
		}
		[CompilerGenerated]
		set
		{
			short num = -18433;
			short num2 = num;
			num = -18433;
			switch (num2 == num)
			{
			}
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
			f = value;
		}
	}

	public Font Legendfont
	{
		[CompilerGenerated]
		get
		{
			short num = 24903;
			short num2 = num;
			num = 24903;
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
				return g;
			}
		}
		[CompilerGenerated]
		set
		{
			short num = -26746;
			short num2 = num;
			num = -26746;
			switch (num2 == num)
			{
			}
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
			g = value;
		}
	}

	public Point LegendPosition
	{
		[CompilerGenerated]
		get
		{
			short num = 23203;
			short num2 = num;
			num = 23203;
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
				return h;
			}
		}
		[CompilerGenerated]
		set
		{
			short num = 12041;
			short num2 = num;
			num = 12041;
			switch (num2 == num)
			{
			}
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
			h = value;
		}
	}

	public Legend()
	{
		Title = "Legend";
		LegendPosition = new Point(0, 0);
		Legendfont = SystemFonts.DefaultFont;
		LegendBackColor1 = Color.White;
		LegendBorderColor = Color.DarkGray;
	}

	public void AddLegend(Graphics g, List<IlegendItem> list)
	{
		short num = -17449;
		short num2 = num;
		num = -17449;
		switch (num2 == num)
		{
		}
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
		AddLegend(g, LegendPosition, list);
	}

	public void AddLegend(Graphics g, Point legendPos, List<IlegendItem> list)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 4;
			int num2 = num;
			List<IlegendItem>.Enumerator enumerator = default(List<IlegendItem>.Enumerator);
			SizeF sizeF = default(SizeF);
			float num3 = default(float);
			float num4 = default(float);
			while (true)
			{
				switch (num2)
				{
				case 4:
					switch (0)
					{
					default:
						goto end_IL_003e;
					case 0:
						break;
					}
					goto default;
				default:
					if (!IsLegendVisible)
					{
						num = 2;
						num2 = num;
					}
					else
					{
						num = 3;
						num2 = num;
					}
					break;
				case 2:
					return;
				case 1:
				{
					try
					{
						num = 4;
						num2 = num;
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
								num = 9;
								num2 = num;
								continue;
							case 9:
							{
								if (!enumerator.MoveNext())
								{
									num = 5;
									num2 = num;
									continue;
								}
								IlegendItem current = enumerator.Current;
								sizeF = g.MeasureString(current.Description, Legendfont);
								num = 8;
								num2 = num;
								continue;
							}
							case 1:
								num = 7;
								num2 = num;
								continue;
							case 7:
								if (num3 < sizeF.Height)
								{
									num = 3;
									num2 = num;
									continue;
								}
								goto default;
							case 8:
								if (num4 < sizeF.Width)
								{
									num = 2;
									num2 = num;
									continue;
								}
								goto case 1;
							case 3:
							{
								num3 = sizeF.Height;
								num = 29114;
								short num6 = num;
								num = 29114;
								switch (num6 == num)
								{
								default:
									num = 0;
									if (num != 0)
									{
									}
									num = 6;
									num2 = num;
									continue;
								case false:
								case true:
									break;
								}
								goto case 2;
							}
							case 2:
								num4 = sizeF.Width;
								num = 1;
								num2 = num;
								continue;
							case 5:
								num = 0;
								num2 = num;
								continue;
							case 0:
								break;
							}
							break;
						}
					}
					finally
					{
						((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
					}
					num4 += i + i;
					float num5 = (float)list.Count * num3 + 10f;
					num4 += 26f;
					float num7 = 16f;
					float pos_x = (float)legendPos.X + num7;
					float pos_y = legendPos.Y;
					DrawLegend(g, pos_x, pos_y, num4, num5, num3, list);
					return;
				}
				case 0:
					return;
				case 3:
					{
						num = 0;
						_ = num;
						num = 1;
						if (num != 0)
						{
						}
						if (!list.Any())
						{
							num = 0;
							num2 = num;
							break;
						}
						num3 = 0f;
						num4 = 0f;
						float num5 = 0f;
						enumerator = list.GetEnumerator();
						num = 1;
						num2 = num;
						break;
					}
					end_IL_003e:
					break;
				}
			}
		}
		}
	}

	public void DrawLegend(Graphics g, float pos_x, float pos_y, float legend_width, float legend_height, float lineHeight, List<IlegendItem> list)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 3;
			int num2 = num;
			Pen pen = default(Pen);
			SolidBrush solidBrush = default(SolidBrush);
			Rectangle rect = default(Rectangle);
			Brush brush = default(Brush);
			while (true)
			{
				switch (num2)
				{
				case 3:
					switch (0)
					{
					default:
						goto end_IL_003e;
					case 0:
						break;
					}
					goto default;
				default:
					num = 1;
					if (num != 0)
					{
					}
					if (!IsLegendVisible)
					{
						num = 2;
						num2 = num;
						break;
					}
					pen = new Pen(LegendBorderColor, 1f);
					solidBrush = null;
					num = 1;
					num2 = num;
					break;
				case 2:
					num = 0;
					_ = num;
					return;
				case 0:
					try
					{
						int num4 = (int)(i + lineHeight);
						int x = rect.X + (int)i;
						int y = rect.Y + num4;
						Rectangle rect2 = new Rectangle(x, y, (int)legend_width, num4);
						StringFormat format = new StringFormat
						{
							Alignment = StringAlignment.Near,
							Trimming = StringTrimming.EllipsisCharacter
						};
						using List<IlegendItem>.Enumerator enumerator = list.GetEnumerator();
						num = 4;
						num2 = num;
						while (true)
						{
							switch (num2)
							{
							case 4:
								switch (0)
								{
								default:
									goto end_IL_018b;
								case 0:
									break;
								}
								goto default;
							default:
								num = 2;
								num2 = num;
								break;
							case 2:
							{
								if (!enumerator.MoveNext())
								{
									num = 3;
									num2 = num;
									break;
								}
								IlegendItem current = enumerator.Current;
								brush = a(current.ForeGroundColor);
								DrawSquare(g, rect2, current.BackGroundColor);
								g.DrawString(current.Description, Legendfont, brush, rect2.X + 18, rect2.Y - 1, format);
								rect2.Y += (int)(lineHeight + i);
								num = 0;
								num2 = num;
								break;
							}
							case 3:
								num = 1;
								num2 = num;
								break;
							case 1:
								return;
								end_IL_018b:
								break;
							}
						}
					}
					finally
					{
						num = 2;
						num2 = num;
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
								if (brush != null)
								{
									num = 1;
									num2 = num;
									continue;
								}
								break;
							case 1:
								brush.Dispose();
								num = 0;
								num2 = num;
								continue;
							case 0:
								break;
							}
							break;
						}
					}
				case 1:
					{
						try
						{
							switch (0)
							{
							default:
								while (true)
								{
									switch (num2)
									{
									case 3:
										if (IsBorderVisible)
										{
											num = 2;
											num2 = num;
											continue;
										}
										goto case 0;
									case 2:
									{
										num = 7352;
										short num3 = num;
										num = 7352;
										switch (num3 == num)
										{
										default:
											num = 0;
											if (num != 0)
											{
											}
											g.DrawRectangle(pen, rect);
											break;
										case false:
										case true:
											break;
										}
										num = 0;
										num2 = num;
										continue;
									}
									case 0:
										num = 1;
										num2 = num;
										continue;
									case 1:
										goto end_IL_0309;
									}
									goto case 0;
									continue;
									end_IL_0309:
									break;
								}
								break;
							case 0:
								rect = new Rectangle((int)pos_x, (int)pos_y, (int)legend_width, (int)legend_height);
								solidBrush = new SolidBrush(LegendBackColor1);
								g.FillRectangle(solidBrush, rect);
								num = 3;
								num2 = num;
								goto default;
							}
						}
						finally
						{
							num = 2;
							num2 = num;
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
									if (solidBrush != null)
									{
										num = 1;
										num2 = num;
										continue;
									}
									break;
								case 1:
									solidBrush.Dispose();
									num = 0;
									num2 = num;
									continue;
								case 0:
									break;
								}
								break;
							}
						}
						brush = null;
						num = 0;
						num2 = num;
						break;
					}
					end_IL_003e:
					break;
				}
			}
		}
		}
	}

	public void DrawSquare(Graphics g, Rectangle rect, string color)
	{
		short num = 2;
		int num2 = num;
		while (true)
		{
			num = 0;
			_ = num;
			num = 1;
			if (num != 0)
			{
			}
			switch (num2)
			{
			case 2:
				switch (0)
				{
				default:
					goto end_IL_0071;
				case 0:
					break;
				}
				goto default;
			default:
				if (g == null)
				{
					num = 1;
					num2 = num;
					break;
				}
				while (true)
				{
					num = 16749;
					short num3 = num;
					num = 16749;
					switch (num3 == num)
					{
					case false:
					case true:
						continue;
					}
					break;
				}
				num = 0;
				if (num != 0)
				{
				}
				num = 0;
				num2 = num;
				break;
			case 1:
				return;
			case 0:
				{
					try
					{
						g.FillRectangle(a(color), rect);
						return;
					}
					catch (Exception)
					{
						return;
					}
				}
				end_IL_0071:
				break;
			}
		}
	}

	private Brush a(string A_0)
	{
		int num = default(int);
		Brush result = default(Brush);
		short num2;
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 2:
					if (!string.IsNullOrWhiteSpace(A_0))
					{
						num2 = 1;
						num = num2;
						continue;
					}
					goto end_IL_0001;
				case 1:
					result = new SolidBrush(Color.FromName(A_0));
					num2 = 0;
					num = num2;
					continue;
				case 0:
					goto end_IL_0001;
				}
				break;
			}
			goto case 0;
		case 0:
			{
				result = Brushes.Aqua;
				num2 = 1;
				if (num2 != 0)
				{
				}
				num2 = 17587;
				short num3 = num2;
				num2 = 17587;
				switch (num3 == num2)
				{
				default:
					num2 = 0;
					_ = num2;
					goto case true;
				case true:
					num2 = 0;
					if (num2 == 0)
					{
					}
					goto IL_00bc;
				case false:
				case true:
					break;
				}
				break;
			}
			IL_00bc:
			num2 = 2;
			num = num2;
			goto default;
			end_IL_0001:
			break;
		}
		return result;
	}

	public override string ToString()
	{
		short num = 0;
		_ = num;
		num = -28377;
		short num2 = num;
		num = -28377;
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
			return "Legend: " + Title;
		}
	}
}
