using System;
using System.Windows.Forms;

namespace ChameleonMiniGUI;

public static class SuspendUpdate
{
	private const int a = 11;

	public static void Suspend(Control control)
	{
		short num = 0;
		_ = num;
		num = 1;
		if (num != 0)
		{
		}
		num = 18617;
		short num2 = num;
		num = 18617;
		switch (num2 == num)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		Message m = Message.Create(control.Handle, 11, IntPtr.Zero, IntPtr.Zero);
		NativeWindow.FromHandle(control.Handle).DefWndProc(ref m);
	}

	public static void Resume(Control control)
	{
		short num = 0;
		_ = num;
		num = 20008;
		short num2 = num;
		num = 20008;
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
		Message m = Message.Create(wparam: new IntPtr(1), hWnd: control.Handle, msg: 11, lparam: IntPtr.Zero);
		NativeWindow.FromHandle(control.Handle).DefWndProc(ref m);
		control.Invalidate(invalidateChildren: true);
		control.Update();
	}
}
