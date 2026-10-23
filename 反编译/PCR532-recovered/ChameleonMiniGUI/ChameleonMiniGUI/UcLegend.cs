using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ChameleonMiniGUI;

public class UcLegend : UserControl
{
	private IEnumerable<IlegendItem> m_a;

	[CompilerGenerated]
	private bool m_b;

	private IContainer c;

	private GroupBox d;

	private FlowLayoutPanel e;

	private Button f;

	private Panel g;

	public string Title
	{
		get
		{
			short num = 0;
			_ = num;
			num = -8849;
			short num2 = num;
			num = -8849;
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
				return d.Text;
			}
		}
		set
		{
			short num = 0;
			_ = num;
			num = 17040;
			short num2 = num;
			num = 17040;
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
			d.Text = value;
		}
	}

	public IEnumerable<IlegendItem> Items
	{
		get
		{
			short num = 0;
			_ = num;
			num = -32050;
			short num2 = num;
			num = -32050;
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
				return this.m_a;
			}
		}
		set
		{
			short num = 0;
			_ = num;
			num = 406;
			short num2 = num;
			num = 406;
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
			this.m_a = value;
			b();
		}
	}

	public bool Expanded
	{
		[CompilerGenerated]
		get
		{
			short num = 0;
			_ = num;
			num = 1;
			if (num != 0)
			{
			}
			num = 16088;
			short num2 = num;
			num = 16088;
			switch (num2 == num)
			{
			default:
				num = 0;
				if (num != 0)
				{
				}
				return this.m_b;
			}
		}
		[CompilerGenerated]
		set
		{
			short num = 0;
			_ = num;
			num = 7945;
			short num2 = num;
			num = 7945;
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
			this.m_b = value;
		}
	}

	public UcLegend()
	{
		a();
		Items = new List<IlegendItem>();
		Title = "Legend";
		Expanded = false;
		e.Visible = false;
		e.AutoScroll = false;
	}

	private void b()
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
			num = 0;
			_ = num;
			switch (0)
			{
			default:
			{
				IEnumerator<IlegendItem> enumerator = default(IEnumerator<IlegendItem>);
				int num3 = default(int);
				while (true)
				{
					switch (num2)
					{
					case 0:
						if (Items != null)
						{
							num = 3;
							num2 = num;
							continue;
						}
						return;
					case 4:
						try
						{
							num = 0;
							num2 = num;
							while (true)
							{
								switch (num2)
								{
								case 0:
									switch (0)
									{
									default:
										goto end_IL_0105;
									case 0:
										break;
									}
									goto default;
								default:
									num = 3;
									num2 = num;
									break;
								case 3:
								{
									if (!enumerator.MoveNext())
									{
										num = 4;
										num2 = num;
										break;
									}
									IlegendItem current = enumerator.Current;
									Label value = new Label
									{
										BackColor = Color.FromName(current.BackGroundColor),
										ForeColor = Color.FromName(current.ForeGroundColor),
										Text = current.Description,
										TextAlign = ContentAlignment.MiddleLeft,
										Margin = new Padding(0, 1, 1, 0),
										Width = num3
									};
									e.Controls.Add(value);
									num = 1;
									num2 = num;
									break;
								}
								case 4:
									num = 2;
									num2 = num;
									break;
								case 2:
									{
										num = 29618;
										short num4 = num;
										num = 29618;
										switch (num4 == num)
										{
										case false:
										case true:
											break;
										default:
											num = 0;
											if (num == 0)
											{
											}
											return;
										}
										goto case 4;
									}
									end_IL_0105:
									break;
								}
							}
						}
						finally
						{
							num = 1;
							num2 = num;
							while (true)
							{
								switch (num2)
								{
								case 1:
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
										num = 2;
										num2 = num;
										continue;
									}
									break;
								case 2:
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
					case 3:
						num = 1;
						num2 = num;
						continue;
					case 1:
						if (Items.Any())
						{
							num3 = d.ClientSize.Width;
							enumerator = Items.GetEnumerator();
							num = 4;
							num2 = num;
						}
						else
						{
							num = 2;
							num2 = num;
						}
						continue;
					case 2:
						return;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				e.Controls.Clear();
				num = 1;
				if (num != 0)
				{
				}
				num = 0;
				num2 = num;
				goto default;
			}
		}
	}

	private void a(object A_0, EventArgs A_1)
	{
		short num = 2;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 2:
				switch (0)
				{
				default:
					goto end_IL_0020;
				case 0:
					break;
				}
				goto default;
			default:
				if (Expanded)
				{
					num = 3;
					num2 = num;
					break;
				}
				num = 0;
				_ = num;
				e.Visible = true;
				e.BringToFront();
				f.Text = "-";
				num = 0;
				num2 = num;
				break;
			case 3:
				e.Visible = false;
				f.Text = "+";
				num = 1;
				num2 = num;
				break;
			case 1:
				num = 1;
				if (num == 0)
				{
				}
				goto case 0;
			case 0:
				{
					num = 29092;
					short num3 = num;
					num = 29092;
					switch (num3 == num)
					{
					case false:
					case true:
						break;
					default:
						num = 0;
						if (num != 0)
						{
						}
						Expanded = !Expanded;
						return;
					}
					goto case 1;
				}
				end_IL_0020:
				break;
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		short num = 0;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 0:
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
			default:
				if (!disposing)
				{
					break;
				}
				goto IL_0068;
			case 3:
			{
				num = 27889;
				short num3 = num;
				num = 27889;
				switch (num3 == num)
				{
				case false:
				case true:
					break;
				default:
					num = 0;
					if (num != 0)
					{
					}
					num = 1;
					num2 = num;
					continue;
				}
				goto IL_0068;
			}
			case 2:
				c.Dispose();
				num = 4;
				num2 = num;
				continue;
			case 4:
				num = 1;
				if (num == 0)
				{
				}
				break;
			case 1:
				{
					if (c != null)
					{
						num = 2;
						num2 = num;
						continue;
					}
					break;
				}
				IL_0068:
				num = 3;
				num2 = num;
				continue;
			}
			break;
		}
		base.Dispose(disposing);
	}

	private void a()
	{
		short num = 0;
		_ = num;
		num = -29208;
		short num2 = num;
		num = -29208;
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
		d = new GroupBox();
		e = new FlowLayoutPanel();
		g = new Panel();
		f = new Button();
		d.SuspendLayout();
		g.SuspendLayout();
		SuspendLayout();
		d.AutoSize = true;
		d.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		d.Controls.Add(e);
		d.Controls.Add(g);
		d.Dock = DockStyle.Fill;
		d.Location = new Point(0, 0);
		d.MaximumSize = new Size(180, 300);
		d.MinimumSize = new Size(180, 24);
		d.Name = "gpLegend";
		d.Size = new Size(180, 42);
		d.TabIndex = 0;
		d.TabStop = false;
		d.Text = "Color legend";
		e.AutoScroll = true;
		e.AutoSize = true;
		e.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		e.Dock = DockStyle.Fill;
		e.FlowDirection = FlowDirection.TopDown;
		e.Location = new Point(3, 39);
		e.Name = "flpLegend";
		e.Size = new Size(174, 0);
		e.TabIndex = 0;
		e.WrapContents = false;
		g.AutoSize = true;
		g.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		g.Controls.Add(f);
		g.Dock = DockStyle.Top;
		g.Location = new Point(3, 16);
		g.Name = "panel2";
		g.Size = new Size(174, 23);
		g.TabIndex = 2;
		f.Location = new Point(0, 0);
		f.Name = "btnToggle";
		f.Size = new Size(20, 20);
		f.TabIndex = 1;
		f.Tag = "280";
		f.Text = "+";
		f.UseVisualStyleBackColor = true;
		f.Click += a;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		AutoSize = true;
		base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		base.Controls.Add(d);
		DoubleBuffered = true;
		MaximumSize = new Size(180, 300);
		base.Name = "UcLegend";
		base.Size = new Size(180, 42);
		d.ResumeLayout(performLayout: false);
		d.PerformLayout();
		g.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
