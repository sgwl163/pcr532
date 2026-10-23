using System;
using System.Net;

namespace update;

public class WebClientto : WebClient
{
	public int Timeout { get; set; }

	public WebClientto(int timeout)
	{
		Timeout = timeout;
	}

	protected override WebRequest GetWebRequest(Uri address)
	{
		HttpWebRequest obj = (HttpWebRequest)base.GetWebRequest(address);
		obj.Timeout = Timeout;
		obj.ReadWriteTimeout = Timeout;
		return obj;
	}
}
