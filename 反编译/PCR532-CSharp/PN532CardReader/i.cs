using System;
using System.Threading;
using System.Windows.Forms;
using MifareOneTool;
using MifareOneTool.Properties;

internal static class i
{
	[STAThread]
	private static void a()
	{
		short num = 0;
		int num2 = num;
		Mutex mutex = default(Mutex);
		bool createdNew = default(bool);
		while (true)
		{
			num = 0;
			_ = num;
			switch (num2)
			{
			case 0:
				switch (0)
				{
				default:
					goto end_IL_0049;
				case 0:
					break;
				}
				goto default;
			default:
				if (Settings.Default.MultiMode)
				{
					num = 2;
					num2 = num;
				}
				else
				{
					mutex = new Mutex(initiallyOwned: true, Application.ProductName, out createdNew);
					num = 5;
					num2 = num;
				}
				break;
			case 1:
				if (MessageBox.Show(Resources.您已经运行了MifareOne_Tool_打开多个本程序可能, Resources.您正在试图重复运行, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
				{
					num = 1;
					if (num != 0)
					{
					}
					num = 4;
					num2 = num;
					break;
				}
				Application.Exit();
				return;
			case 3:
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(defaultValue: false);
				Application.Run(new Form1());
				mutex.ReleaseMutex();
				return;
			case 2:
			{
				num = -20954;
				short num3 = num;
				num = -20954;
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
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(defaultValue: false);
					Application.Run(new Form1());
					return;
				}
				goto case 0;
			}
			case 4:
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(defaultValue: false);
				Application.Run(new Form1());
				mutex.ReleaseMutex();
				return;
			case 5:
				{
					if (!createdNew)
					{
						num = 1;
						num2 = num;
					}
					else
					{
						num = 3;
						num2 = num;
					}
					break;
				}
				end_IL_0049:
				break;
			}
		}
	}
}
