using System;
using System.Collections.Generic;
using System.Linq;
using Crapto1Sharp;

namespace ChameleonMiniGUI;

public class MfKeyAttacks
{
	public MfKeyAttacks()
	{
	}

	public MfKeyAttacks(bool doSelfTest)
	{
		if (doSelfTest)
		{
			a();
		}
	}

	private void a()
	{
		short num = 1;
		if (num != 0)
		{
		}
		int num2 = default(int);
		MyKey myKey = default(MyKey);
		switch (0)
		{
		default:
			while (true)
			{
				switch (num2)
				{
				case 3:
					if (myKey.Found)
					{
						num = 4;
						num2 = num;
						continue;
					}
					return;
				case 0:
					_ = $"[S{myKey.Sector}/B%d] Type {myKey.KeyType} Key found [{myKey.key:x12}] {Environment.NewLine} ";
					num = 1;
					num2 = num;
					continue;
				case 1:
					num = 0;
					_ = num;
					return;
				case 4:
				{
					num = -22962;
					short num3 = num;
					num = -22962;
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
						num = 2;
						num2 = num;
						continue;
					}
					goto case 0;
				}
				case 2:
					if (myKey.key == 176616078812325L)
					{
						num = 0;
						num2 = num;
						continue;
					}
					return;
				}
				break;
			}
			goto case 0;
		case 0:
			myKey = new MyKey
			{
				UID = 305419896u,
				nt0 = 450420523u,
				nr0 = 489775140u,
				ar0 = 1645146184u,
				nt1 = 819383047u,
				nr1 = 3307239394u,
				ar1 = 2205861402u
			};
			myKey.key = MfKey.MfKey32(myKey.UID, myKey.nt0, myKey.nr0, myKey.ar0, myKey.nt1, myKey.nr1, myKey.ar1);
			myKey.Found = myKey.key != ulong.MaxValue;
			num = 3;
			num2 = num;
			goto default;
		}
	}

	public static uint ToUInt32(byte[] data, int offset)
	{
		if (!BitConverter.IsLittleEndian)
		{
			short num = 1982;
			short num2 = num;
			num = 1982;
			switch (num2 == num)
			{
			case false:
			case true:
				break;
			default:
				num = 0;
				_ = num;
				goto case true;
			case true:
				num = 0;
				if (num != 0)
				{
				}
				num = 1;
				if (num != 0)
				{
				}
				return BitConverter.ToUInt32(data, offset);
			}
		}
		return BitConverter.ToUInt32(data.Skip(offset).Take(4).Reverse()
			.ToArray(), 0);
	}

	private static ulong a(byte[] A_0, int A_1)
	{
		short num = 1;
		if (num != 0)
		{
		}
		if (!BitConverter.IsLittleEndian)
		{
			num = 0;
			_ = num;
			num = -20303;
			short num2 = num;
			num = -20303;
			switch (num2 == num)
			{
			case false:
			case true:
				break;
			default:
				num = 0;
				if (num != 0)
				{
				}
				return BitConverter.ToUInt64(A_0, A_1);
			}
		}
		return BitConverter.ToUInt64(A_0.Skip(A_1).Take(8).Reverse()
			.ToArray(), 0);
	}

	public static string Attack(byte[] bytes)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 12;
			int num2 = num;
			List<MyKey> list = default(List<MyKey>);
			MyKey myKey = default(MyKey);
			int num3 = default(int);
			uint uID = default(uint);
			while (true)
			{
				switch (num2)
				{
				case 12:
					switch (0)
					{
					default:
						continue;
					case 0:
						break;
					}
					goto default;
				default:
					if (bytes != null)
					{
						num = 5;
						num2 = num;
						continue;
					}
					goto case 6;
				case 9:
					list.Add(myKey);
					num = 13;
					num2 = num;
					continue;
				case 11:
					if (myKey.Sector != byte.MaxValue)
					{
						num = 14;
						num2 = num;
						continue;
					}
					goto case 13;
				case 6:
					return "No data found on device" + Environment.NewLine;
				case 13:
					num3++;
					num = 4;
					num2 = num;
					continue;
				case 5:
				{
					num = 31839;
					short num4 = num;
					num = 31839;
					switch (num4 == num)
					{
					default:
						num = 0;
						_ = num;
						num = 0;
						if (num != 0)
						{
						}
						num = 10;
						num2 = num;
						continue;
					case false:
					case true:
						break;
					}
					break;
				}
				case 10:
					if (!bytes.Any())
					{
						num = 6;
						num2 = num;
						continue;
					}
					a(bytes, 8);
					_ = 5928239340301921844L;
					num = 3;
					num2 = num;
					continue;
				case 14:
					num = 2;
					num2 = num;
					continue;
				case 2:
					if (myKey.KeyType != byte.MaxValue)
					{
						num = 9;
						num2 = num;
						continue;
					}
					goto case 13;
				case 4:
				case 7:
					num = 0;
					num2 = num;
					continue;
				case 0:
					if (num3 < 12)
					{
						myKey = new MyKey
						{
							UID = uID,
							KeyType = bytes[(num3 + 1) * 16],
							Block = bytes[(num3 + 1) * 16 + 1],
							nt0 = ToUInt32(bytes, (num3 + 1) * 16 + 4),
							nr0 = ToUInt32(bytes, (num3 + 1) * 16 + 8),
							ar0 = ToUInt32(bytes, (num3 + 1) * 16 + 12)
						};
						myKey.Sector = ToSector(myKey.Block);
						num = 1;
						if (num != 0)
						{
						}
						num = 11;
						num2 = num;
					}
					else
					{
						num = 8;
						num2 = num;
					}
					continue;
				case 1:
					return "Data failed CRC check" + Environment.NewLine;
				case 3:
					if (!Crc.CheckCrc14443(25443, bytes, 210))
					{
						num = 1;
						num2 = num;
						continue;
					}
					uID = ToUInt32(bytes, 0);
					list = new List<MyKey>();
					num3 = 0;
					num = 7;
					num2 = num;
					continue;
				case 8:
					break;
				}
				break;
			}
			KeyCompareruid comparer = new KeyCompareruid();
			list.Sort(comparer);
			return KeyWorker(list);
		}
		}
	}

	public static byte ToSector(byte block)
	{
		short num;
		if (block >= 128)
		{
			num = 0;
			_ = num;
			num = 4058;
			short num2 = num;
			num = 4058;
			switch (num2 == num)
			{
			case false:
			case true:
				break;
			default:
				num = 0;
				if (num != 0)
				{
				}
				return (byte)(32 + (block - 128) / 16);
			}
		}
		num = 1;
		if (num != 0)
		{
		}
		return (byte)(block / 4);
	}

	public static string KeyWorker(List<MyKey> keys)
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = -5259;
		short num2 = num;
		num = -5259;
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
			List<string> list = keys.GroupBy(delegate(MyKey A_0)
			{
				short num3 = 1;
				if (num3 != 0)
				{
				}
				num3 = 28284;
				short num4 = num3;
				num3 = 28284;
				switch (num4 == num3)
				{
				default:
					num3 = 0;
					if (num3 != 0)
					{
					}
					num3 = 0;
					_ = num3;
					return new global::a<uint, byte, byte, byte>(A_0.UID, A_0.Sector, A_0.Block, A_0.KeyType);
				}
			}).AsParallel().AsOrdered()
				.Select(delegate(IGrouping<global::a<uint, byte, byte, byte>, MyKey> A_0)
				{
					short num3 = 0;
					switch (num3)
					{
					default:
					{
						num3 = 8;
						int num4 = num3;
						List<Nonce> list2 = default(List<Nonce>);
						ulong num7 = default(ulong);
						int num5 = default(int);
						IEnumerator<MyKey> enumerator = default(IEnumerator<MyKey>);
						string result = default(string);
						string text = default(string);
						while (true)
						{
							object obj;
							switch (num4)
							{
							case 8:
								num3 = 0;
								_ = num3;
								switch (0)
								{
								default:
									goto end_IL_0067;
								case 0:
									break;
								}
								goto default;
							default:
								list2 = A_0.Select(delegate(MyKey myKey)
								{
									short num8 = -6895;
									short num9 = num8;
									num8 = -6895;
									switch (num9 == num8)
									{
									default:
										num8 = 1;
										if (num8 != 0)
										{
										}
										num8 = 0;
										if (num8 != 0)
										{
										}
										num8 = 0;
										_ = num8;
										return new Nonce
										{
											Nt = myKey.nt0,
											Nr = myKey.nr0,
											Ar = myKey.ar0
										};
									}
								}).ToList();
								num3 = 2;
								num4 = num3;
								break;
							case 9:
								if (A_0.Key.KeyType != 96)
								{
									num3 = 7;
									num4 = num3;
								}
								else
								{
									num3 = 5;
									num4 = num3;
								}
								break;
							case 3:
								return (string)null;
							case 7:
								num3 = 10;
								num4 = num3;
								break;
							case 10:
								obj = "B";
								goto IL_0123;
							case 0:
								return (string)null;
							case 5:
								obj = "A";
								goto IL_0123;
							case 2:
								if (list2.Count >= 2)
								{
									num3 = 9;
									num4 = num3;
								}
								else
								{
									num3 = 3;
									num4 = num3;
								}
								break;
							case 1:
								num3 = 1;
								if (num3 != 0)
								{
								}
								try
								{
									switch (0)
									{
									default:
										while (true)
										{
											switch (num4)
											{
											case 3:
												if (num7 != ulong.MaxValue)
												{
													num3 = 4;
													num4 = num3;
												}
												else
												{
													num5 += list2.Count;
													num3 = 0;
													num4 = num3;
												}
												continue;
											case 4:
												enumerator = A_0.GetEnumerator();
												num3 = 1;
												num4 = num3;
												continue;
											case 1:
											{
												num3 = -23095;
												short num6 = num3;
												num3 = -23095;
												switch (num6 == num3)
												{
												case false:
												case true:
													break;
												default:
													num3 = 0;
													if (num3 != 0)
													{
													}
													try
													{
														num3 = 3;
														num4 = num3;
														while (true)
														{
															switch (num4)
															{
															case 3:
																switch (0)
																{
																default:
																	continue;
																case 0:
																	break;
																}
																goto default;
															default:
																num3 = 1;
																num4 = num3;
																continue;
															case 1:
																if (enumerator.MoveNext())
																{
																	MyKey current = enumerator.Current;
																	current.Found = true;
																	current.key = num7;
																	num3 = 4;
																	num4 = num3;
																}
																else
																{
																	num3 = 2;
																	num4 = num3;
																}
																continue;
															case 2:
																num3 = 0;
																num4 = num3;
																continue;
															case 0:
																break;
															}
															break;
														}
													}
													finally
													{
														num3 = 2;
														num4 = num3;
														while (true)
														{
															switch (num4)
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
																if (enumerator != null)
																{
																	num3 = 0;
																	num4 = num3;
																	continue;
																}
																break;
															case 0:
																enumerator.Dispose();
																num3 = 1;
																num4 = num3;
																continue;
															case 1:
																break;
															}
															break;
														}
													}
													result = $"[Sector{A_0.Key.Sector} / Block{A_0.Key.Block}] Key{text} [{num7:x12}] UID [{A_0.Key.UID:x8}]";
													num3 = 2;
													num4 = num3;
													continue;
												}
												goto case 4;
											}
											case 0:
												goto end_IL_016c;
											case 2:
												return result;
											}
											goto case 0;
											continue;
											end_IL_016c:
											break;
										}
										break;
									case 0:
										num7 = MfKey.MfKey32(A_0.Key.UID, list2);
										num3 = 3;
										num4 = num3;
										goto default;
									}
								}
								catch (OutOfMemoryException)
								{
								}
								goto case 6;
							case 6:
								num3 = 4;
								num4 = num3;
								break;
							case 4:
								{
									if (num5 + 2 <= list2.Count)
									{
										list2.GetRange(num5, 2);
										num3 = 1;
										num4 = num3;
									}
									else
									{
										num3 = 0;
										num4 = num3;
									}
									break;
								}
								IL_0123:
								text = (string)obj;
								num5 = 0;
								num3 = 6;
								num4 = num3;
								break;
								end_IL_0067:
								break;
							}
						}
					}
					}
				})
				.Where(delegate(string A_0)
				{
					short num3 = 21610;
					short num4 = num3;
					num3 = 21610;
					switch (num4 == num3)
					{
					default:
						num3 = 1;
						if (num3 != 0)
						{
						}
						num3 = 0;
						if (num3 != 0)
						{
						}
						num3 = 0;
						_ = num3;
						return A_0 != null;
					}
				})
				.ToList();
			list.Add(string.Empty);
			return string.Join(Environment.NewLine, list);
		}
		}
	}

	private static void a(byte[] A_0, uint A_1, int A_2)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			int num4 = default(int);
			byte[] array = default(byte[]);
			switch (0)
			{
			default:
				while (true)
				{
					num = 1;
					if (num != 0)
					{
					}
					int num5;
					long num6;
					switch (num2)
					{
					case 0:
					case 2:
						num = 3;
						num2 = num;
						continue;
					case 3:
						if (num4 >= A_2)
						{
							num = 1;
							num2 = num;
							continue;
						}
						goto IL_00d9;
					case 1:
						{
							num = 31651;
							short num3 = num;
							num = 31651;
							switch (num3 == num)
							{
							case false:
							case true:
								break;
							default:
								num = 0;
								if (num == 0)
								{
								}
								return;
							}
							goto IL_00d9;
						}
						IL_00d9:
						num = 0;
						_ = num;
						num5 = array[num4];
						num6 = (A_2 + A_1 + num4 - A_2 / A_1) ^ num5;
						A_0[num4] = (byte)num6;
						num4++;
						num = 0;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			case 0:
				array = new byte[A_2];
				Array.Copy(A_0, array, A_2);
				num4 = 0;
				num = 2;
				num2 = num;
				goto default;
			}
		}
		}
	}
}
