using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using ChameleonMiniGUI.Json;

namespace ChameleonMiniGUI.Dump;

public class JsonDumpStrategy : DumpStrategy
{
	private static readonly DataContractJsonSerializerSettings a;

	public override string Extension
	{
		get
		{
			short num = -4614;
			short num2 = num;
			num = -4614;
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
				return ".json";
			}
		}
	}

	public JsonDumpStrategy(string fileName)
	{
		base.FileName = fileName;
	}

	public override byte[] Read()
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = -191;
			short num2 = num;
			num = -191;
			switch (num2 == num)
			{
			default:
			{
				num = 0;
				if (num != 0)
				{
				}
				num = 0;
				_ = num;
				num = 1;
				if (num != 0)
				{
				}
				FileStream fileStream = File.OpenRead(base.FileName);
				try
				{
					XmlDictionaryReader xmlDictionaryReader = JsonReaderWriterFactory.CreateJsonReader(fileStream, new XmlDictionaryReaderQuotas());
					try
					{
						XElement xElement = XElement.Load(xmlDictionaryReader);
						string value = xElement.Element("FileType").Value;
						Type typeFromHandle = typeof(MifareClassicModel);
						if (value == "mfu")
						{
							typeFromHandle = typeof(MifareUltralightModel);
						}
						DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeFromHandle, a);
						XmlReader xmlReader = xElement.CreateReader();
						try
						{
							return (dataContractJsonSerializer.ReadObject(xmlReader) as MifareModel).ToByteArray();
						}
						finally
						{
							num = 2;
							int num3 = num;
							while (true)
							{
								switch (num3)
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
									if (xmlReader != null)
									{
										num = 0;
										num3 = num;
										continue;
									}
									break;
								case 0:
									((IDisposable)xmlReader).Dispose();
									num = 1;
									num3 = num;
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
						int num3 = num;
						while (true)
						{
							switch (num3)
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
								if (xmlDictionaryReader != null)
								{
									num = 0;
									num3 = num;
									continue;
								}
								break;
							case 0:
								((IDisposable)xmlDictionaryReader).Dispose();
								num = 1;
								num3 = num;
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
					int num3 = num;
					while (true)
					{
						switch (num3)
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
							if (fileStream != null)
							{
								num = 0;
								num3 = num;
								continue;
							}
							break;
						case 0:
							((IDisposable)fileStream).Dispose();
							num = 1;
							num3 = num;
							continue;
						case 1:
							break;
						}
						break;
					}
				}
			}
			case false:
			case true:
			{
				byte[] result = default(byte[]);
				return result;
			}
			}
		}
		}
	}

	public override void Save(byte[] data)
	{
		MifareModel mifareModel = default(MifareModel);
		int num = default(int);
		short num2;
		switch (0)
		{
		default:
		{
			FileStream fileStream = default(FileStream);
			while (true)
			{
				switch (num)
				{
				case 5:
					goto IL_00b9;
				case 4:
					try
					{
						XmlDictionaryWriter xmlDictionaryWriter = JsonReaderWriterFactory.CreateJsonWriter(fileStream, Encoding.UTF8, ownsStream: true, indent: true, "  ");
						try
						{
							new DataContractJsonSerializer(mifareModel.GetType(), a).WriteObject(xmlDictionaryWriter, mifareModel);
							xmlDictionaryWriter.Flush();
						}
						finally
						{
							num2 = 2;
							num = num2;
							while (true)
							{
								switch (num)
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
									if (xmlDictionaryWriter != null)
									{
										num2 = 0;
										num = num2;
										continue;
									}
									break;
								case 0:
									((IDisposable)xmlDictionaryWriter).Dispose();
									num2 = 1;
									num = num2;
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
						num2 = 2;
						num = num2;
						while (true)
						{
							switch (num)
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
								if (fileStream != null)
								{
									num2 = 0;
									num = num2;
									continue;
								}
								break;
							case 0:
								((IDisposable)fileStream).Dispose();
								num2 = 1;
								num = num2;
								continue;
							case 1:
								break;
							}
							break;
						}
					}
					num2 = 1;
					if (num2 == 0)
					{
					}
					return;
				case 6:
					num2 = 3;
					num = num2;
					continue;
				case 3:
					goto IL_0239;
				case 0:
					mifareModel = MifareUltralightModel.Parse(data);
					num2 = 2;
					num = num2;
					continue;
				case 1:
				case 2:
					fileStream = File.Open(base.FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
					num2 = 4;
					num = num2;
					continue;
				}
				break;
				IL_0239:
				if (data.Length != 320)
				{
					num2 = 0;
					num = num2;
					continue;
				}
				goto IL_01e9;
				IL_01e9:
				mifareModel = new MifareClassicModel
				{
					Created = "ChameleonMiniGUI",
					Blocks = MifareClassicModel.ToNestedByteArray(data)
				};
				num2 = 1;
				num = num2;
				continue;
				IL_00b9:
				if (data.Length < 1024)
				{
					goto IL_00c6;
				}
				goto IL_01e9;
			}
			goto case 0;
		}
		case 0:
			{
				num2 = -3264;
				short num3 = num2;
				num2 = -3264;
				switch (num3 == num2)
				{
				case false:
				case true:
					goto IL_00c6;
				}
				num2 = 0;
				if (num2 != 0)
				{
				}
				mifareModel = null;
				num2 = 0;
				_ = num2;
				num2 = 5;
				num = num2;
				goto default;
			}
			IL_00c6:
			num2 = 6;
			num = num2;
			goto default;
		}
	}

	static JsonDumpStrategy()
	{
		short num = 25292;
		short num2 = num;
		num = 25292;
		switch (num2 == num)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
		num = 1;
		if (num != 0)
		{
		}
		a = new DataContractJsonSerializerSettings
		{
			DataContractSurrogate = new BlockSurrogate(),
			KnownTypes = new List<Type> { typeof(Dictionary<string, string>) },
			UseSimpleDictionaryFormat = true,
			EmitTypeInformation = EmitTypeInformation.Never,
			SerializeReadOnlyTypes = false
		};
	}
}
