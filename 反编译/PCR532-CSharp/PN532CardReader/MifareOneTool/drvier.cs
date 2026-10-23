using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MifareOneTool;

public class drvier : Form
{
	private IContainer m_a;

	private Button m_b;

	private Button m_c;

	private Button d;

	public drvier()
	{
		a();
		base.StartPosition = FormStartPosition.CenterScreen;
		base.ShowIcon = true;
	}

	[DllImport("kernel32.dll")]
	public static extern int WinExec(string exeName, int operType);

	private void c(object A_0, EventArgs A_1)
	{
		short num = 0;
		_ = num;
		num = 1;
		if (num != 0)
		{
		}
		num = 30497;
		short num2 = num;
		num = 30497;
		switch (num2 == num)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		WinExec("driver/CH341SER.EXE", 5);
	}

	private void b(object A_0, EventArgs A_1)
	{
		short num = -4436;
		short num2 = num;
		num = -4436;
		int num3 = default(int);
		string currentDirectory = default(string);
		switch (num2 == num)
		{
		default:
			num = 0;
			_ = num;
			num = 0;
			if (num != 0)
			{
			}
			switch (0)
			{
			case 0:
				goto IL_0090;
			}
			goto case false;
		case false:
		case true:
			{
				while (true)
				{
					switch (num3)
					{
					case 0:
						if (File.Exists(currentDirectory + "./driver/cdc_com.exe"))
						{
							num = 1;
							num3 = num;
						}
						else
						{
							Process.Start("driver");
							num = 2;
							num3 = num;
						}
						continue;
					case 2:
						return;
					case 1:
						try
						{
							Process.Start(currentDirectory + "./driver/cdc_com.exe");
							return;
						}
						catch
						{
							Process.Start("driver");
							return;
						}
					}
					break;
				}
				goto IL_0090;
			}
			IL_0090:
			num = 1;
			if (num != 0)
			{
			}
			currentDirectory = Environment.CurrentDirectory;
			num = 0;
			num3 = num;
			goto case false;
		}
	}

	private void a(object A_0, EventArgs A_1)
	{
		short num = 0;
		_ = num;
		num = 21408;
		short num2 = num;
		num = 21408;
		switch (num2 == num)
		{
		case false:
		case true:
			return;
		}
		num = 0;
		if (num != 0)
		{
		}
		num = 1;
		if (num != 0)
		{
		}
		_ = Environment.CurrentDirectory;
		try
		{
			Process.Start("driver");
		}
		catch
		{
		}
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
					num = -15068;
					short num3 = num;
					num = -15068;
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
					num = 1;
					if (num != 0)
					{
					}
					if (disposing)
					{
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
		num = 1;
		if (num != 0)
		{
		}
		num = -7824;
		short num2 = num;
		num = -7824;
		switch (num2 == num)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(drvier));
		this.m_b = new Button();
		this.m_c = new Button();
		d = new Button();
		SuspendLayout();
		this.m_b.DialogResult = DialogResult.Cancel;
		this.m_b.Location = new Point(33, 43);
		this.m_b.Name = "button1";
		this.m_b.Size = new Size(258, 33);
		this.m_b.TabIndex = 0;
		this.m_b.Text = "CH340驱动(经典款，变色龙GP1,2,3代)";
		this.m_b.UseVisualStyleBackColor = true;
		this.m_b.Click += c;
		this.m_c.Location = new Point(33, 101);
		this.m_c.Name = "button2";
		this.m_c.Size = new Size(258, 33);
		this.m_c.TabIndex = 1;
		this.m_c.Text = "带U盘版本CDC驱动，win8以上免驱";
		this.m_c.UseVisualStyleBackColor = true;
		this.m_c.Click += b;
		d.Location = new Point(33, 155);
		d.Name = "button3";
		d.Size = new Size(258, 33);
		d.TabIndex = 2;
		d.Text = "打开驱动目录，自行安装";
		d.UseVisualStyleBackColor = true;
		d.Click += a;
		base.AutoScaleDimensions = new SizeF(6f, 12f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(322, 247);
		base.Controls.Add(d);
		base.Controls.Add(this.m_c);
		base.Controls.Add(this.m_b);
		base.FormBorderStyle = FormBorderStyle.Fixed3D;
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "drvier";
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "驱动安装";
		ResumeLayout(performLayout: false);
	}
}
