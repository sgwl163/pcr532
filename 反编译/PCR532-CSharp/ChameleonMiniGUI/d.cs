using System;
using System.Windows.Forms;
using ChameleonMiniGUI;

internal static class d
{
	[STAThread]
	private static void a()
	{
		short num = 0;
		_ = num;
		num = -10382;
		short num2 = num;
		num = -10382;
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
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.Run(new frm_main());
	}
}
