using System;
using System.Net;
using System.Runtime.CompilerServices;

namespace MifareOneTool;

public class WebClientto : WebClient
{
	[CompilerGenerated]
	private int a;

	public int Timeout
	{
		[CompilerGenerated]
		get
		{
			short num = 16508;
			short num2 = num;
			num = 16508;
			switch (num2 == num)
			{
			default:
				num = 0;
				_ = num;
				break;
			case true:
				break;
			}
			num = 1;
			if (num != 0)
			{
			}
			num = 0;
			if (num != 0)
			{
			}
			return a;
		}
		[CompilerGenerated]
		set
		{
			short num = 1;
			if (num != 0)
			{
			}
			num = 0;
			_ = num;
			num = -806;
			short num2 = num;
			num = -806;
			switch (num2 == num)
			{
			}
			num = 0;
			if (num != 0)
			{
			}
			a = value;
		}
	}

	public WebClientto(int timeout)
	{
		Timeout = timeout;
	}

	protected override WebRequest GetWebRequest(Uri address)
	{
		short num = -4431;
		short num2 = num;
		num = -4431;
		switch (num2 == num)
		{
		default:
			num = 0;
			_ = num;
			break;
		case true:
			break;
		}
		num = 1;
		if (num != 0)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		HttpWebRequest obj = (HttpWebRequest)base.GetWebRequest(address);
		obj.Timeout = Timeout;
		obj.ReadWriteTimeout = Timeout;
		return obj;
	}
}
