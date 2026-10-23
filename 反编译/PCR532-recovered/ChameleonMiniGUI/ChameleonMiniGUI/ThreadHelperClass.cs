using System.Windows.Forms;

namespace ChameleonMiniGUI;

public static class ThreadHelperClass
{
	private delegate void a(Form A_0, Control A_1, string A_2);

	public static void SetText(Form f, Control c, string text)
	{
		short num;
		while (!c.InvokeRequired)
		{
			num = -3885;
			short num2 = num;
			num = -3885;
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
			c.Text = text;
			return;
		}
		num = 0;
		_ = num;
		a method = SetText;
		f.Invoke(method, f, c, text);
	}
}
