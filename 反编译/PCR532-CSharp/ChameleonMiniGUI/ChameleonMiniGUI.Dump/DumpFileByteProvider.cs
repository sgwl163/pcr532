using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Be.Windows.Forms;

namespace ChameleonMiniGUI.Dump;

public class DumpFileByteProvider : IByteProvider
{
	private byte[] m_a;

	private bool m_b;

	private DumpStrategy c;

	[CompilerGenerated]
	private EventHandler d;

	[CompilerGenerated]
	private EventHandler e;

	[CompilerGenerated]
	private EventHandler f;

	public long Length
	{
		get
		{
			short num = 7546;
			short num2 = num;
			num = 7546;
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
				return this.m_a.LongLength;
			}
		}
	}

	public event EventHandler LengthChanged
	{
		[CompilerGenerated]
		add
		{
			short num = 1;
			if (num != 0)
			{
			}
			int num2 = default(int);
			EventHandler eventHandler = default(EventHandler);
			switch (0)
			{
			default:
			{
				EventHandler eventHandler2 = default(EventHandler);
				while (true)
				{
					EventHandler value2;
					switch (num2)
					{
					case 2:
					{
						num = 32263;
						short num3 = num;
						num = 32263;
						switch (num3 == num)
						{
						default:
							num = 0;
							if (num != 0)
							{
							}
							num = 0;
							_ = num;
							break;
						case false:
						case true:
							break;
						}
						goto IL_00d3;
					}
					case 0:
						if ((object)eventHandler == eventHandler2)
						{
							num = 1;
							num2 = num;
							continue;
						}
						goto IL_00d3;
					case 1:
						return;
						IL_00d3:
						eventHandler2 = eventHandler;
						value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
						eventHandler = Interlocked.CompareExchange(ref d, value2, eventHandler2);
						num = 0;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				eventHandler = d;
				num = 2;
				num2 = num;
				goto default;
			}
		}
		[CompilerGenerated]
		remove
		{
			int num = default(int);
			EventHandler eventHandler = default(EventHandler);
			switch (0)
			{
			default:
			{
				EventHandler eventHandler2 = default(EventHandler);
				while (true)
				{
					EventHandler value2;
					short num2;
					switch (num)
					{
					case 2:
					{
						num2 = 12683;
						short num3 = num2;
						num2 = 12683;
						switch (num3 == num2)
						{
						default:
							num2 = 0;
							if (num2 == 0)
							{
							}
							break;
						case false:
						case true:
							break;
						}
						goto IL_009c;
					}
					case 0:
						if ((object)eventHandler != eventHandler2)
						{
							goto IL_009c;
						}
						num2 = 1;
						num = num2;
						continue;
					case 1:
						{
							num2 = 1;
							if (num2 == 0)
							{
							}
							return;
						}
						IL_009c:
						num2 = 0;
						_ = num2;
						eventHandler2 = eventHandler;
						value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
						eventHandler = Interlocked.CompareExchange(ref d, value2, eventHandler2);
						num2 = 0;
						num = num2;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
			{
				eventHandler = d;
				short num2 = 2;
				num = num2;
				goto default;
			}
			}
		}
	}

	public event EventHandler Changed
	{
		[CompilerGenerated]
		add
		{
			int num2 = default(int);
			EventHandler eventHandler = default(EventHandler);
			switch (0)
			{
			default:
			{
				EventHandler eventHandler2 = default(EventHandler);
				while (true)
				{
					short num = 1;
					if (num != 0)
					{
					}
					EventHandler value2;
					switch (num2)
					{
					case 2:
					{
						num = 13314;
						short num3 = num;
						num = 13314;
						switch (num3 == num)
						{
						default:
							num = 0;
							if (num != 0)
							{
							}
							num = 0;
							_ = num;
							break;
						case false:
						case true:
							break;
						}
						goto IL_00d4;
					}
					case 0:
						if ((object)eventHandler == eventHandler2)
						{
							num = 1;
							num2 = num;
							continue;
						}
						goto IL_00d4;
					case 1:
						return;
						IL_00d4:
						eventHandler2 = eventHandler;
						value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
						eventHandler = Interlocked.CompareExchange(ref e, value2, eventHandler2);
						num = 0;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
			{
				eventHandler = e;
				short num = 2;
				num2 = num;
				goto default;
			}
			}
		}
		[CompilerGenerated]
		remove
		{
			int num = default(int);
			EventHandler eventHandler = default(EventHandler);
			switch (0)
			{
			default:
			{
				EventHandler eventHandler2 = default(EventHandler);
				while (true)
				{
					EventHandler value2;
					short num2;
					switch (num)
					{
					case 2:
					{
						num2 = 14194;
						short num3 = num2;
						num2 = 14194;
						switch (num3 == num2)
						{
						default:
							num2 = 1;
							if (num2 != 0)
							{
							}
							num2 = 0;
							if (num2 != 0)
							{
							}
							num2 = 0;
							_ = num2;
							break;
						case false:
						case true:
							break;
						}
						goto IL_00d4;
					}
					case 0:
						if ((object)eventHandler == eventHandler2)
						{
							num2 = 1;
							num = num2;
							continue;
						}
						goto IL_00d4;
					case 1:
						return;
						IL_00d4:
						eventHandler2 = eventHandler;
						value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
						eventHandler = Interlocked.CompareExchange(ref e, value2, eventHandler2);
						num2 = 0;
						num = num2;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
			{
				eventHandler = e;
				short num2 = 2;
				num = num2;
				goto default;
			}
			}
		}
	}

	public event EventHandler WriteFinished
	{
		[CompilerGenerated]
		add
		{
			int num = default(int);
			EventHandler eventHandler = default(EventHandler);
			switch (0)
			{
			default:
			{
				EventHandler eventHandler2 = default(EventHandler);
				while (true)
				{
					EventHandler value2;
					short num2;
					switch (num)
					{
					case 2:
					{
						num2 = -8915;
						short num3 = num2;
						num2 = -8915;
						switch (num3 == num2)
						{
						default:
							num2 = 0;
							if (num2 != 0)
							{
							}
							num2 = 0;
							_ = num2;
							break;
						case false:
						case true:
							break;
						}
						goto IL_00d6;
					}
					case 0:
						if ((object)eventHandler == eventHandler2)
						{
							num2 = 1;
							num = num2;
							continue;
						}
						goto IL_00d6;
					case 1:
						return;
						IL_00d6:
						eventHandler2 = eventHandler;
						value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
						eventHandler = Interlocked.CompareExchange(ref f, value2, eventHandler2);
						num2 = 0;
						num = num2;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
			{
				short num2 = 1;
				if (num2 != 0)
				{
				}
				eventHandler = f;
				num2 = 2;
				num = num2;
				goto default;
			}
			}
		}
		[CompilerGenerated]
		remove
		{
			short num = -25749;
			short num2 = num;
			num = -25749;
			switch (num2 == num)
			{
			default:
				num = 0;
				_ = num;
				break;
			case true:
				break;
			case false:
			case true:
				return;
			}
			num = 0;
			if (num != 0)
			{
			}
			int num3 = default(int);
			EventHandler eventHandler = default(EventHandler);
			switch (0)
			{
			default:
			{
				EventHandler eventHandler2 = default(EventHandler);
				while (true)
				{
					switch (num3)
					{
					case 0:
					{
						eventHandler2 = eventHandler;
						EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
						eventHandler = Interlocked.CompareExchange(ref f, value2, eventHandler2);
						num = 1;
						if (num != 0)
						{
						}
						num = 2;
						num3 = num;
						continue;
					}
					case 2:
						if ((object)eventHandler == eventHandler2)
						{
							num = 1;
							num3 = num;
							continue;
						}
						goto case 0;
					case 1:
						return;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				eventHandler = f;
				num = 0;
				num3 = num;
				goto default;
			}
		}
	}

	public DumpFileByteProvider(string fileName)
	{
		c = DumpStrategyFactory.Create(fileName);
		this.m_a = c.Read();
	}

	private void b(EventArgs A_0)
	{
		short num = -32549;
		short num2 = num;
		num = -32549;
		switch (num2 == num)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		num = 1;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
		e?.Invoke(this, A_0);
	}

	private void a(EventArgs A_0)
	{
		short num = 14398;
		short num2 = num;
		num = 14398;
		switch (num2 == num)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		num = 1;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
		f?.Invoke(this, A_0);
	}

	public void ApplyChanges()
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = 8985;
		short num2 = num;
		num = 8985;
		switch (num2 == num)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
		c.Save(this.m_a);
		this.m_b = false;
	}

	public void DeleteBytes(long index, long length)
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = 6489;
		short num2 = num;
		num = 6489;
		switch (num2 == num)
		{
		default:
			num = 0;
			if (num != 0)
			{
			}
			num = 0;
			_ = num;
			throw new NotImplementedException();
		}
	}

	public bool HasChanges()
	{
		short num = -27747;
		short num2 = num;
		num = -27747;
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
			num = 0;
			_ = num;
			return this.m_b;
		}
	}

	public void InsertBytes(long index, byte[] bs)
	{
		short num = 11358;
		short num2 = num;
		num = 11358;
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
			num = 0;
			_ = num;
			throw new NotImplementedException();
		}
	}

	public byte ReadByte(long index)
	{
		short num = -22459;
		short num2 = num;
		num = -22459;
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
			num = 0;
			_ = num;
			return this.m_a[index];
		}
	}

	public bool SupportsDeleteBytes()
	{
		short num = 19856;
		short num2 = num;
		num = 19856;
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
			num = 0;
			_ = num;
			return false;
		}
	}

	public bool SupportsInsertBytes()
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = 8003;
		short num2 = num;
		num = 8003;
		switch (num2 == num)
		{
		default:
			num = 0;
			if (num != 0)
			{
			}
			num = 0;
			_ = num;
			return false;
		}
	}

	public bool SupportsWriteByte()
	{
		short num = 13376;
		short num2 = num;
		num = 13376;
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
			num = 0;
			_ = num;
			return true;
		}
	}

	public void WriteByte(long index, byte value)
	{
		short num = -31203;
		short num2 = num;
		num = -31203;
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
		num = 0;
		_ = num;
		this.m_a[index] = value;
		this.m_b = true;
		b(EventArgs.Empty);
		a(EventArgs.Empty);
	}
}
