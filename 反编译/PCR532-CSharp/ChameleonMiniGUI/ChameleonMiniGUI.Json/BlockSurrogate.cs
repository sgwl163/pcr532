using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace ChameleonMiniGUI.Json;

public class BlockSurrogate : IDataContractSurrogate
{
	[CompilerGenerated]
	private sealed class a
	{
		public string a;

		internal byte b(int A_0)
		{
			short num = 0;
			_ = num;
			num = -9857;
			short num2 = num;
			num = -9857;
			switch (num2 == num)
			{
			default:
				num = 0;
				if (num != 0)
				{
				}
				num = 1;
				if (num != 0)
				{
				}
				return Convert.ToByte(a.Substring(A_0, 2), 16);
			}
		}
	}

	public Type GetDataContractType(Type type)
	{
		short num = 0;
		_ = num;
		num = 1128;
		short num2 = num;
		num = 1128;
		switch (num2 == num)
		{
		default:
			num = 0;
			if (num != 0)
			{
			}
			if (type == typeof(byte[][]))
			{
				num = 1;
				if (num != 0)
				{
				}
				return typeof(Dictionary<string, string>);
			}
			break;
		case false:
		case true:
			break;
		}
		return type;
	}

	private static byte[] a(string A_0)
	{
		short num = 0;
		_ = num;
		num = 1;
		if (num != 0)
		{
		}
		num = -16036;
		short num2 = num;
		num = -16036;
		switch (num2 == num)
		{
		default:
			num = 0;
			if (num != 0)
			{
			}
			return Enumerable.Range(0, A_0.Length).Where(delegate(int num5)
			{
				short num3 = 0;
				_ = num3;
				num3 = -21458;
				short num4 = num3;
				num3 = -21458;
				switch (num4 == num3)
				{
				default:
					num3 = 0;
					if (num3 != 0)
					{
					}
					num3 = 1;
					if (num3 != 0)
					{
					}
					return num5 % 2 == 0;
				}
			}).Select(delegate(int startIndex)
			{
				short num3 = 0;
				_ = num3;
				num3 = -9857;
				short num4 = num3;
				num3 = -9857;
				switch (num4 == num3)
				{
				default:
					num3 = 0;
					if (num3 != 0)
					{
					}
					num3 = 1;
					if (num3 != 0)
					{
					}
					return Convert.ToByte(A_0.Substring(startIndex, 2), 16);
				}
			})
				.ToArray();
		}
	}

	private static string a(byte[] A_0)
	{
		short num = 0;
		_ = num;
		num = 1;
		if (num != 0)
		{
		}
		num = -4643;
		short num2 = num;
		num = -4643;
		switch (num2 == num)
		{
		default:
			num = 0;
			if (num != 0)
			{
			}
			return string.Join("", A_0.Select(delegate(byte b)
			{
				short num3 = 0;
				_ = num3;
				num3 = 1;
				if (num3 != 0)
				{
				}
				num3 = 31392;
				short num4 = num3;
				num3 = 31392;
				switch (num4 == num3)
				{
				default:
					num3 = 0;
					if (num3 != 0)
					{
					}
					return b.ToString("X2");
				}
			}));
		}
	}

	public object GetDeserializedObject(object obj, Type targetType)
	{
		short num = 0;
		_ = num;
		num = 0;
		int num2 = num;
		int num3 = default(int);
		Dictionary<string, string> dictionary = default(Dictionary<string, string>);
		byte[][] array = default(byte[][]);
		while (true)
		{
			switch (num2)
			{
			case 0:
				switch (0)
				{
				default:
					continue;
				case 0:
					break;
				}
				goto default;
			default:
				if (obj.GetType() == typeof(Dictionary<string, string>))
				{
					num = 2;
					num2 = num;
					continue;
				}
				break;
			case 3:
			case 4:
				num = 6;
				num2 = num;
				continue;
			case 6:
				if (num3 >= dictionary.Count)
				{
					num = 5;
					num2 = num;
					continue;
				}
				array[num3] = a(dictionary[num3.ToString()]);
				num3++;
				goto IL_0166;
			case 5:
			{
				num = -20189;
				short num4 = num;
				num = -20189;
				switch (num4 == num)
				{
				default:
					num = 0;
					if (num != 0)
					{
					}
					num = 1;
					if (num != 0)
					{
					}
					return array;
				case false:
				case true:
					break;
				}
				goto IL_0166;
			}
			case 2:
				num = 7;
				num2 = num;
				continue;
			case 7:
				if (targetType == typeof(byte[][]))
				{
					num = 1;
					num2 = num;
					continue;
				}
				break;
			case 1:
				{
					dictionary = obj as Dictionary<string, string>;
					array = new byte[dictionary.Count][];
					num3 = 0;
					num = 4;
					num2 = num;
					continue;
				}
				IL_0166:
				num = 3;
				num2 = num;
				continue;
			}
			break;
		}
		return obj;
	}

	public object GetObjectToSerialize(object obj, Type targetType)
	{
		short num = 0;
		_ = num;
		num = 0;
		int num2 = num;
		int num3 = default(int);
		byte[][] array = default(byte[][]);
		Dictionary<string, string> dictionary = default(Dictionary<string, string>);
		while (true)
		{
			switch (num2)
			{
			case 0:
				switch (0)
				{
				default:
					continue;
				case 0:
					break;
				}
				goto default;
			default:
				if (obj.GetType() == typeof(byte[][]))
				{
					num = 2;
					num2 = num;
					continue;
				}
				break;
			case 2:
				num = 1;
				if (num != 0)
				{
				}
				num = 7;
				num2 = num;
				continue;
			case 3:
			case 4:
				num = 6;
				num2 = num;
				continue;
			case 6:
				if (num3 >= array.Length)
				{
					num = 5;
					num2 = num;
					continue;
				}
				dictionary[num3.ToString()] = a(array[num3]);
				num3++;
				goto IL_0163;
			case 5:
			{
				num = -19138;
				short num4 = num;
				num = -19138;
				switch (num4 == num)
				{
				default:
					num = 0;
					if (num != 0)
					{
					}
					return dictionary;
				case false:
				case true:
					break;
				}
				goto IL_0163;
			}
			case 7:
				if (targetType == typeof(Dictionary<string, string>))
				{
					num = 1;
					num2 = num;
					continue;
				}
				break;
			case 1:
				{
					array = obj as byte[][];
					dictionary = new Dictionary<string, string>();
					num3 = 0;
					num = 4;
					num2 = num;
					continue;
				}
				IL_0163:
				num = 3;
				num2 = num;
				continue;
			}
			break;
		}
		return obj;
	}

	public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
	{
		short num = 0;
		_ = num;
		num = 6301;
		short num2 = num;
		num = 6301;
		switch (num2 == num)
		{
		default:
			num = 1;
			if (num != 0)
			{
			}
			num = 0;
			if (num != 0)
			{
			}
			throw new NotImplementedException();
		}
	}

	public object GetCustomDataToExport(Type clrType, Type dataContractType)
	{
		short num = 0;
		_ = num;
		num = 29709;
		short num2 = num;
		num = 29709;
		switch (num2 == num)
		{
		default:
			num = 0;
			if (num != 0)
			{
			}
			num = 1;
			if (num != 0)
			{
			}
			throw new NotImplementedException();
		}
	}

	public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
	{
		short num = 0;
		_ = num;
		num = -14577;
		short num2 = num;
		num = -14577;
		switch (num2 == num)
		{
		default:
			num = 1;
			if (num != 0)
			{
			}
			num = 0;
			if (num != 0)
			{
			}
			throw new NotImplementedException();
		}
	}

	public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
	{
		short num = 0;
		_ = num;
		num = 17483;
		short num2 = num;
		num = 17483;
		switch (num2 == num)
		{
		default:
			num = 0;
			if (num != 0)
			{
			}
			num = 1;
			if (num != 0)
			{
			}
			throw new NotImplementedException();
		}
	}

	public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
	{
		short num = 0;
		_ = num;
		num = 1;
		if (num != 0)
		{
		}
		num = -4784;
		short num2 = num;
		num = -4784;
		switch (num2 == num)
		{
		default:
			num = 0;
			if (num != 0)
			{
			}
			throw new NotImplementedException();
		}
	}
}
