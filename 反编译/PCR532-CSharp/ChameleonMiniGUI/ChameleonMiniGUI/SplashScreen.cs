using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ChameleonMiniGUI.Properties;

namespace ChameleonMiniGUI;

public class SplashScreen : Form
{
	private delegate void a();

	private static SplashScreen m_a;

	private IContainer m_b;

	private PictureBox m_c;

	private Label d;

	public SplashScreen()
	{
		a();
		d.Parent = this.m_c;
		d.Text = Settings.Default.version;
	}

	public static void ShowSplashScreen()
	{
		short num;
		while (SplashScreen.m_a == null)
		{
			num = 31119;
			short num2 = num;
			num = 31119;
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
			num = 0;
			_ = num;
			Thread thread = new Thread(c);
			thread.IsBackground = true;
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			return;
		}
		num = 1;
		if (num == 0)
		{
		}
	}

	private static void c()
	{
		short num = 808;
		short num2 = num;
		num = 808;
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
		SplashScreen.m_a = new SplashScreen();
		Application.Run(SplashScreen.m_a);
	}

	public static void CloseForm()
	{
		short num = -13073;
		short num2 = num;
		num = -13073;
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
		SplashScreen.m_a.Invoke(new a(b));
	}

	private static void b()
	{
		short num = 19922;
		short num2 = num;
		num = 19922;
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
		SplashScreen.m_a.Close();
		SplashScreen.m_a = null;
	}

	protected override void Dispose(bool disposing)
	{
		short num = 2;
		int num2 = num;
		while (true)
		{
			num = -23039;
			short num3 = num;
			num = -23039;
			switch (num3 == num)
			{
			default:
				num = 0;
				if (num != 0)
				{
				}
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
					if (disposing)
					{
						num = 4;
						num2 = num;
						continue;
					}
					goto case 3;
				case 4:
					num = 0;
					_ = num;
					num = 1;
					num2 = num;
					continue;
				case 0:
					break;
				case 1:
					if (this.m_b != null)
					{
						num = 0;
						num2 = num;
						continue;
					}
					goto case 3;
				case 3:
					num = 1;
					if (num != 0)
					{
					}
					base.Dispose(disposing);
					return;
				}
				break;
			case false:
			case true:
				break;
			}
			this.m_b.Dispose();
			num = 3;
			num2 = num;
		}
	}

	private void a()
	{
		short num = 0;
		_ = num;
		num = -27091;
		short num2 = num;
		num = -27091;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(SplashScreen));
		this.m_c = new PictureBox();
		d = new Label();
		((ISupportInitialize)this.m_c).BeginInit();
		SuspendLayout();
		this.m_c.BackgroundImage = Resources.chameleon;
		this.m_c.BackgroundImageLayout = ImageLayout.None;
		this.m_c.Location = new Point(0, 0);
		this.m_c.Name = "pictureBox1";
		this.m_c.Size = new Size(522, 304);
		this.m_c.TabIndex = 0;
		this.m_c.TabStop = false;
		d.AutoSize = true;
		d.BackColor = Color.Transparent;
		d.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 161);
		d.ForeColor = Color.White;
		d.Location = new Point(257, 224);
		d.Name = "label1";
		d.Size = new Size(60, 16);
		d.TabIndex = 1;
		d.Text = "v1.0.0.0";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.White;
		base.ClientSize = new Size(522, 304);
		base.Controls.Add(d);
		base.Controls.Add(this.m_c);
		base.FormBorderStyle = FormBorderStyle.None;
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "SplashScreen";
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "SplashScreen";
		((ISupportInitialize)this.m_c).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
