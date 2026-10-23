using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace ChameleonMiniGUI;

public class UcTextFlow : UserControl
{
	public delegate void ClickHandler(object sender, EventArgs e);

	[CompilerGenerated]
	private ClickHandler m_a;

	[CompilerGenerated]
	private List<string> m_b;

	private IContainer m_c;

	private FlowLayoutPanel d;

	public List<string> AvailableCommands
	{
		[CompilerGenerated]
		get
		{
			short num = 0;
			_ = num;
			num = -20312;
			short num2 = num;
			num = -20312;
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
				return this.m_b;
			}
		}
		[CompilerGenerated]
		set
		{
			short num = 0;
			_ = num;
			num = -12361;
			short num2 = num;
			num = -12361;
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
			this.m_b = value;
		}
	}

	public event ClickHandler TextClick
	{
		[CompilerGenerated]
		add
		{
			short num = 0;
			_ = num;
			int num3 = default(int);
			ClickHandler clickHandler2 = default(ClickHandler);
			switch (0)
			{
			default:
			{
				ClickHandler clickHandler = default(ClickHandler);
				while (true)
				{
					num = -26632;
					short num2 = num;
					num = -26632;
					ClickHandler value2;
					switch (num2 == num)
					{
					default:
						num = 0;
						if (num != 0)
						{
						}
						switch (num3)
						{
						case 1:
							goto IL_00ae;
						case 0:
							goto IL_010b;
						case 2:
							return;
						}
						break;
					case false:
					case true:
						{
							num = 2;
							num3 = num;
							continue;
						}
						IL_00ae:
						clickHandler = clickHandler2;
						value2 = (ClickHandler)Delegate.Combine(clickHandler, value);
						clickHandler2 = Interlocked.CompareExchange(ref this.m_a, value2, clickHandler);
						num = 1;
						if (num != 0)
						{
						}
						num = 0;
						num3 = num;
						continue;
						IL_010b:
						if ((object)clickHandler2 != clickHandler)
						{
							goto IL_00ae;
						}
						goto case false;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				clickHandler2 = this.m_a;
				num = 1;
				num3 = num;
				goto default;
			}
		}
		[CompilerGenerated]
		remove
		{
			short num = 0;
			_ = num;
			int num3 = default(int);
			ClickHandler clickHandler2 = default(ClickHandler);
			switch (0)
			{
			default:
			{
				ClickHandler clickHandler = default(ClickHandler);
				while (true)
				{
					num = 14524;
					short num2 = num;
					num = 14524;
					ClickHandler value2;
					switch (num2 == num)
					{
					default:
						num = 0;
						if (num != 0)
						{
						}
						switch (num3)
						{
						case 1:
							goto IL_00ae;
						case 0:
							goto IL_00e3;
						case 2:
							num = 1;
							if (num == 0)
							{
							}
							return;
						}
						break;
					case false:
					case true:
						{
							num = 2;
							num3 = num;
							continue;
						}
						IL_00ae:
						clickHandler = clickHandler2;
						value2 = (ClickHandler)Delegate.Remove(clickHandler, value);
						clickHandler2 = Interlocked.CompareExchange(ref this.m_a, value2, clickHandler);
						num = 0;
						num3 = num;
						continue;
						IL_00e3:
						if ((object)clickHandler2 != clickHandler)
						{
							goto IL_00ae;
						}
						goto case false;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				clickHandler2 = this.m_a;
				num = 1;
				num3 = num;
				goto default;
			}
		}
	}

	public UcTextFlow()
	{
		a();
		AutoScroll = true;
	}

	private void c(object A_0, EventArgs A_1)
	{
		int num = default(int);
		TextBox textBox = default(TextBox);
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 1:
					if (textBox == null)
					{
						short num2 = 2;
						num = num2;
					}
					else
					{
						short num2 = 3;
						num = num2;
					}
					continue;
				case 2:
					return;
				case 0:
				{
					short num2 = 1;
					if (num2 == 0)
					{
					}
					return;
				}
				case 3:
				{
					short num2 = 0;
					_ = num2;
					if (base.BackColor == Color.Transparent)
					{
						num2 = 0;
						num = num2;
						continue;
					}
					num2 = 8639;
					short num3 = num2;
					num2 = 8639;
					switch (num3 == num2)
					{
					case false:
					case true:
						break;
					default:
						num2 = 0;
						if (num2 != 0)
						{
						}
						textBox.BackColor = base.BackColor;
						textBox.Cursor = Cursors.Default;
						return;
					}
					break;
				}
				}
				break;
			}
			goto case 0;
		case 0:
		{
			textBox = A_0 as TextBox;
			short num2 = 1;
			num = num2;
			goto default;
		}
		}
	}

	private void b(object A_0, EventArgs A_1)
	{
		short num;
		while (A_0 is TextBox textBox)
		{
			num = -4157;
			short num2 = num;
			num = -4157;
			switch (num2 == num)
			{
			case false:
			case true:
				continue;
			}
			num = 1;
			if (num != 0)
			{
			}
			num = 0;
			if (num != 0)
			{
			}
			textBox.BackColor = SystemColors.ControlLight;
			textBox.Cursor = Cursors.Arrow;
			return;
		}
		num = 0;
		_ = num;
	}

	private void a(object A_0, EventArgs A_1)
	{
		short num = 0;
		_ = num;
		num = -2011;
		short num2 = num;
		num = -2011;
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
		this.m_a?.Invoke(A_0, A_1);
	}

	public void Addline(string noteText)
	{
		short num;
		while (true)
		{
			TextBox textBox = new TextBox
			{
				Multiline = true,
				Text = noteText,
				ReadOnly = true,
				BorderStyle = BorderStyle.None,
				TabStop = false,
				Margin = new Padding(1, 1, 1, 1)
			};
			Size size = TextRenderer.MeasureText(textBox.Text, textBox.Font);
			textBox.Width = size.Width;
			textBox.Height = size.Height;
			textBox.Click += a;
			textBox.MouseEnter += b;
			textBox.MouseLeave += c;
			d.Controls.Add(textBox);
			if (base.BackColor == Color.Transparent)
			{
				break;
			}
			num = -11604;
			short num2 = num;
			num = -11604;
			switch (num2 == num)
			{
			case false:
			case true:
				continue;
			}
			num = 0;
			if (num != 0)
			{
			}
			num = 1;
			if (num != 0)
			{
			}
			textBox.BackColor = base.BackColor;
			return;
		}
		num = 0;
		_ = num;
	}

	public void SetList()
	{
		int num = default(int);
		switch (0)
		{
		default:
			while (true)
			{
				short num3;
				short num2;
				switch (num)
				{
				case 1:
					if (AvailableCommands != null)
					{
						num2 = 2;
						num = num2;
						continue;
					}
					goto IL_00f9;
				case 2:
					num2 = 3;
					num = num2;
					continue;
				case 3:
					if (AvailableCommands.Any())
					{
						num2 = 0;
						num = num2;
						continue;
					}
					goto IL_00f9;
				case 0:
					{
						num2 = 1;
						if (num2 != 0)
						{
						}
						AvailableCommands.ForEach(Addline);
						return;
					}
					IL_00f9:
					num2 = 0;
					_ = num2;
					num2 = -8052;
					num3 = num2;
					num2 = -8052;
					switch (num3 == num2)
					{
					case false:
					case true:
						break;
					default:
						num2 = 0;
						if (num2 != 0)
						{
						}
						Addline("N/A");
						return;
					}
					goto case 0;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			d.Controls.Clear();
			short num2 = 1;
			num = num2;
			goto default;
		}
		}
	}

	protected override void Dispose(bool disposing)
	{
		short num = 0;
		int num2 = num;
		while (true)
		{
			num = 1;
			if (num != 0)
			{
			}
			switch (num2)
			{
			case 0:
				switch (0)
				{
				default:
					continue;
				case 0:
					break;
				}
				goto default;
			default:
				if (disposing)
				{
					num = 3;
					num2 = num;
					continue;
				}
				break;
			case 2:
				this.m_c.Dispose();
				num = 1;
				num2 = num;
				continue;
			case 3:
				num = 0;
				_ = num;
				num = 4;
				num2 = num;
				continue;
			case 4:
				if (this.m_c != null)
				{
					num = 2;
					num2 = num;
					continue;
				}
				break;
			case 1:
				break;
			}
			num = -21769;
			short num3 = num;
			num = -21769;
			switch (num3 == num)
			{
			case false:
			case true:
				continue;
			}
			num = 0;
			if (num != 0)
			{
			}
			base.Dispose(disposing);
			return;
		}
	}

	private void a()
	{
		short num = 0;
		_ = num;
		num = 31995;
		short num2 = num;
		num = 31995;
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
		d = new FlowLayoutPanel();
		SuspendLayout();
		d.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		d.AutoScroll = true;
		d.AutoSize = true;
		d.FlowDirection = FlowDirection.TopDown;
		d.Location = new Point(3, 3);
		d.Name = "fLPContainer";
		d.Size = new Size(64, 57);
		d.TabIndex = 0;
		AutoSize = true;
		base.Controls.Add(d);
		base.Name = "UcTextFlow";
		base.Size = new Size(73, 64);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
