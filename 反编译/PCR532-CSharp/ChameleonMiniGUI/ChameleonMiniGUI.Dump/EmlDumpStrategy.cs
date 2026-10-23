using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChameleonMiniGUI.Dump;

public class EmlDumpStrategy : DumpStrategy
{
	public override string Extension
	{
		get
		{
			short num = -31884;
			short num2 = num;
			num = -31884;
			switch (num2 == num)
			{
			default:
				num = 1;
				if (num != 0)
				{
				}
				num = 0;
				_ = num;
				num = 0;
				if (num != 0)
				{
				}
				return ".eml";
			}
		}
	}

	public EmlDumpStrategy(string fileName)
	{
		base.FileName = fileName;
	}

	public override byte[] Read()
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			num = 0;
			_ = num;
			string[] array = File.ReadAllLines(base.FileName);
			MemoryStream memoryStream = new MemoryStream();
			byte[] result = default(byte[]);
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				try
				{
					int num5 = default(int);
					string[] array3 = default(string[]);
					switch (0)
					{
					default:
					{
						int num4 = default(int);
						byte[] array2 = default(byte[]);
						string text = default(string);
						int num3 = default(int);
						while (true)
						{
							switch (num2)
							{
							case 4:
								num4 = 0;
								array2 = new byte[text.Length >> 1];
								num3 = 0;
								num = 10;
								num2 = num;
								continue;
							case 0:
								num5++;
								num = 11;
								num2 = num;
								continue;
							case 9:
								if (!string.IsNullOrWhiteSpace(text))
								{
									num = 4;
									num2 = num;
									continue;
								}
								goto case 0;
							case 6:
								binaryWriter.Write(array2);
								num = 0;
								num2 = num;
								continue;
							case 7:
							case 11:
								num = 2;
								num2 = num;
								continue;
							case 2:
								if (num5 < array3.Length)
								{
									num = -14415;
									short num6 = num;
									num = -14415;
									switch (num6 == num)
									{
									default:
										num = 0;
										if (num != 0)
										{
										}
										text = array3[num5].Replace(":", "").Replace(" ", "");
										num = 9;
										num2 = num;
										continue;
									case false:
									case true:
										break;
									}
									goto end_IL_006e;
								}
								num = 8;
								num2 = num;
								continue;
							case 1:
							case 10:
								num = 5;
								num2 = num;
								continue;
							case 5:
							{
								if (num3 >= text.Length)
								{
									num = 6;
									num2 = num;
									continue;
								}
								byte b = Convert.ToByte(text.Substring(num3, 2), 16);
								array2[num4++] = b;
								num3 += 2;
								num = 1;
								num2 = num;
								continue;
							}
							case 8:
								binaryWriter.Flush();
								result = memoryStream.ToArray();
								num = 3;
								num2 = num;
								continue;
							case 3:
								goto end_IL_006e;
							}
							goto case 0;
							continue;
							end_IL_006e:
							break;
						}
						break;
					}
					case 0:
						array3 = array;
						num5 = 0;
						num = 7;
						num2 = num;
						goto default;
					}
				}
				finally
				{
					num = 2;
					num2 = num;
					while (true)
					{
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
							if (binaryWriter != null)
							{
								num = 0;
								num2 = num;
								continue;
							}
							break;
						case 0:
							((IDisposable)binaryWriter).Dispose();
							num = 1;
							num2 = num;
							continue;
						case 1:
							break;
						}
						break;
					}
				}
			}
			finally
			{
				num = 2;
				num2 = num;
				while (true)
				{
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
						if (memoryStream != null)
						{
							num = 1;
							if (num != 0)
							{
							}
							num = 0;
							num2 = num;
							continue;
						}
						break;
					case 0:
						((IDisposable)memoryStream).Dispose();
						num = 1;
						num2 = num;
						continue;
					case 1:
						break;
					}
					break;
				}
			}
			return result;
		}
		}
	}

	public override void Save(byte[] data)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			int num4 = default(int);
			List<string> list = default(List<string>);
			int num6 = default(int);
			switch (0)
			{
			default:
				while (true)
				{
					switch (num2)
					{
					case 2:
					case 3:
						num = 0;
						_ = num;
						num = 0;
						num2 = num;
						continue;
					case 0:
					{
						num = -29631;
						short num3 = num;
						num = -29631;
						switch (num3 == num)
						{
						default:
						{
							num = 0;
							if (num != 0)
							{
							}
							if (num4 <= 0)
							{
								num = 1;
								num2 = num;
								continue;
							}
							int num5 = Math.Min(num4, 16);
							list.Add(BitConverter.ToString(data, num6, num5).Replace("-", " "));
							num6 += num5;
							num4 -= num5;
							num = 2;
							num2 = num;
							continue;
						}
						case false:
						case true:
							break;
						}
						goto case 1;
					}
					case 1:
						File.WriteAllLines(base.FileName, list, Encoding.ASCII);
						return;
					}
					break;
				}
				goto case 0;
			case 0:
				num = 1;
				if (num != 0)
				{
				}
				num4 = data.Length;
				num6 = 0;
				list = new List<string>();
				num = 3;
				num2 = num;
				goto default;
			}
		}
		}
	}
}
