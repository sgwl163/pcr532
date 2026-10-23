using System;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.CSharp.RuntimeBinder;
using MifareOneTool.Properties;
using Newtonsoft.Json.Linq;

internal class h
{
	[CompilerGenerated]
	private static class a
	{
		public static CallSite<Func<CallSite, object, object>> a;

		public static CallSite<Func<CallSite, object, bool, object>> b;

		public static CallSite<Func<CallSite, object, bool>> c;

		public static CallSite<Func<CallSite, object, object>> d;

		public static CallSite<Func<CallSite, object, string>> e;
	}

	[CompilerGenerated]
	private static class b
	{
		public static CallSite<Func<CallSite, object, object>> a;

		public static CallSite<Func<CallSite, object, bool, object>> b;

		public static CallSite<Func<CallSite, object, bool>> c;

		public static CallSite<Func<CallSite, object, object>> d;

		public static CallSite<Func<CallSite, object, string>> e;
	}

	public Version a;

	public string b = Resources.未知;

	public void c(string A_0)
	{
		short num2;
		try
		{
			int num = default(int);
			string json = default(string);
			switch (0)
			{
			default:
			{
				dynamic val = default(dynamic);
				while (true)
				{
					switch (num)
					{
					case 10:
					{
						if (JObject.Parse(json).GetValue("message") == null)
						{
							num2 = 6;
							num = num2;
							continue;
						}
						num2 = 6583;
						short num3 = num2;
						num2 = 6583;
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
							Console.Error.WriteLine("GitHub更新失效");
							num2 = 1;
							num = num2;
							continue;
						}
						goto case 9;
					}
					case 6:
						val = JToken.Parse(json);
						num2 = 3;
						num = num2;
						continue;
					case 3:
						if (h.a.c == null)
						{
							num2 = 9;
							num = num2;
							continue;
						}
						goto case 8;
					case 9:
						h.a.c = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(h), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						num2 = 8;
						num = num2;
						continue;
					case 8:
						num2 = 2;
						num = num2;
						continue;
					case 2:
						if (h.a.c.Target(h.a.c, (object)(val.prerelease == false)))
						{
							num2 = 7;
							num = num2;
							continue;
						}
						goto case 1;
					case 7:
						num2 = 5;
						num = num2;
						continue;
					case 5:
						this.b = (string)val.tag_name;
						num2 = 4;
						num = num2;
						continue;
					case 1:
					case 4:
						num2 = 0;
						num = num2;
						continue;
					case 0:
						goto end_IL_000a;
					}
					goto case 0;
					continue;
					end_IL_000a:
					break;
				}
				break;
			}
			case 0:
				json = new StreamReader(((HttpWebResponse)((HttpWebRequest)WebRequest.Create("https://api.github.com/repos/" + A_0 + "/releases/latest")).GetResponse()).GetResponseStream()).ReadToEnd();
				num2 = 10;
				num = num2;
				goto default;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
		num2 = 1;
		if (num2 != 0)
		{
		}
		num2 = 0;
		_ = num2;
	}

	public h(string A_0)
	{
		this.a = Assembly.GetExecutingAssembly().GetName().Version;
		try
		{
			string json = new StreamReader(((HttpWebResponse)((HttpWebRequest)WebRequest.Create("https://api.github.com/repos/" + A_0 + "/releases/latest")).GetResponse()).GetResponseStream()).ReadToEnd();
			if (JObject.Parse(json).GetValue("message") == null)
			{
				dynamic val = JToken.Parse(json);
				if (val.prerelease == false)
				{
					this.b = (string)val.tag_name;
				}
			}
			else
			{
				Console.Error.WriteLine("GitHub更新失效");
			}
		}
		catch (Exception ex)
		{
			Console.Error.WriteLine(ex.Message);
		}
	}
}
