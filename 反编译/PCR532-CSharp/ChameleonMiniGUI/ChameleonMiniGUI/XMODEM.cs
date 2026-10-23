using System;
using System.IO;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ChameleonMiniGUI;

public class XMODEM
{
	public enum Variants
	{
		XModemChecksum,
		XModemCRC,
		XModem1K
	}

	private enum a
	{
		a,
		b,
		c,
		d,
		e,
		f,
		g,
		h,
		i,
		j,
		k
	}

	public enum TerminationReasonEnum
	{
		TransferStillActiveNotTerminated,
		UserCancelled,
		EndOfFile,
		FileInitiationTimeout,
		CancelNotificationReceived,
		TooManyRetries,
		NoResponseFromReceiver
	}

	public delegate void PacketReceivedEventHandler(XMODEM sender, byte[] packet, bool endOfFileDetected);

	public int ReceiverFileInitiationRetryMillisec = 250;

	public int ReceiverFileInitiationMaxAttempts = 240;

	public bool ReceiverFallBackAllowed = true;

	public int ReceiverTimeoutMillisec = 10000;

	public int ReceiverMaxConsecutiveRetries = 10;

	private int m_a = 1;

	private int m_b = 5;

	public int MaxSenderRetries = 10;

	public int SenderPacketRetryTimeoutMillisec = 15000;

	public int SendInactivityTimeoutMillisec = 60000;

	public byte SOH = 1;

	public byte STX = 2;

	public byte ACK = 6;

	public byte NAK = 21;

	public byte C = 67;

	public byte EOT = 4;

	public byte SUB = 26;

	public byte CAN = 24;

	public byte EOF = 26;

	private int m_c = 1024;

	private int m_d = 128;

	private Variants m_e;

	private a m_f;

	public TerminationReasonEnum _TerminationReason;

	[CompilerGenerated]
	private PacketReceivedEventHandler m_g;

	public SerialPort Port;

	private ManualResetEvent m_h = new ManualResetEvent(initialState: false);

	private int m_i;

	private MemoryStream m_j;

	private byte k;

	private Timer l;

	private int m;

	private bool n;

	private Timer o;

	public int _ReceiverNumConsecutiveNAKSent;

	private int p;

	private byte q;

	private byte r;

	private bool s = true;

	private byte t = 1;

	private byte[] u;

	private byte[] v = new byte[0];

	private byte[] w;

	private int x;

	private byte[] y;

	private bool z;

	private ManualResetEvent aa = new ManualResetEvent(initialState: false);

	private Timer ab;

	private Timer ac;

	private byte[] ad;

	private byte[] ae;

	private bool af;

	private int ag;

	public byte PaddingByte;

	public byte EndOfFileByteToSend;

	private byte ah = 1;

	private int ai;

	private int aj;

	private bool ak;

	private bool al;

	private int am;

	private bool an;

	public int NumCancellationBytesRequired
	{
		get
		{
			short num = 9083;
			short num2 = num;
			num = 9083;
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
				return this.m_a;
			}
		}
		set
		{
			short num = 16552;
			short num2 = num;
			num = 16552;
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
			this.m_a = value;
		}
	}

	public int NumCancellationBytesToSend
	{
		get
		{
			short num = 1;
			if (num != 0)
			{
			}
			num = -13812;
			short num2 = num;
			num = -13812;
			switch (num2 == num)
			{
			default:
				num = 0;
				_ = num;
				num = 0;
				if (num != 0)
				{
				}
				return this.m_b;
			}
		}
		set
		{
			short num = 1;
			if (num != 0)
			{
			}
			num = 0;
			_ = num;
			if (value >= 0)
			{
				while (true)
				{
					num = 19081;
					short num2 = num;
					num = 19081;
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
						this.m_b = value;
						return;
					}
				}
			}
			NumCancellationBytesToSend = 5;
		}
	}

	public int Packet1024NominalSize
	{
		get
		{
			short num = 1;
			if (num != 0)
			{
			}
			num = -13246;
			short num2 = num;
			num = -13246;
			switch (num2 == num)
			{
			default:
				num = 0;
				_ = num;
				num = 0;
				if (num != 0)
				{
				}
				return this.m_c;
			}
		}
		set
		{
			short num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
					num = 1;
					if (num != 0)
					{
					}
					switch (0)
					{
					default:
						continue;
					case 0:
						break;
					}
					goto default;
				default:
					if (value > 0)
					{
						num = 0;
						_ = num;
						num = 0;
						num2 = num;
						continue;
					}
					break;
				case 0:
					this.m_c = value;
					d();
					num = 2;
					num2 = num;
					continue;
				case 2:
					break;
				}
				num = 29139;
				short num3 = num;
				num = 29139;
				switch (num3 == num)
				{
				case false:
				case true:
					continue;
				}
				num = 0;
				if (num == 0)
				{
				}
				return;
			}
		}
	}

	public int Packet128NominalSize
	{
		get
		{
			short num = 29269;
			short num2 = num;
			num = 29269;
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
				return this.m_d;
			}
		}
		set
		{
			short num = 1;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
					switch (0)
					{
					default:
						continue;
					case 0:
						break;
					}
					goto default;
				default:
					if (value > 0)
					{
						num = 0;
						num2 = num;
						continue;
					}
					break;
				case 0:
					num = 0;
					_ = num;
					num = 1;
					if (num != 0)
					{
					}
					this.m_d = value;
					d();
					num = 2;
					num2 = num;
					continue;
				case 2:
					break;
				}
				num = 1086;
				short num3 = num;
				num = 1086;
				switch (num3 == num)
				{
				case false:
				case true:
					continue;
				}
				num = 0;
				if (num == 0)
				{
				}
				return;
			}
		}
	}

	public Variants Variant
	{
		get
		{
			short num = -4964;
			short num2 = num;
			num = -4964;
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
				return this.m_e;
			}
		}
		set
		{
			short num = -2367;
			short num2 = num;
			num = -2367;
			switch (num2 == num)
			{
			}
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
			this.m_e = value;
			d();
		}
	}

	public TerminationReasonEnum TerminationReason
	{
		get
		{
			short num = 13059;
			short num2 = num;
			num = 13059;
			switch (num2 == num)
			{
			default:
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
				return _TerminationReason;
			}
		}
	}

	public int NumCancellationBytesReceived
	{
		get
		{
			short num = -32407;
			short num2 = num;
			num = -32407;
			switch (num2 == num)
			{
			default:
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
				return this.m_a;
			}
		}
	}

	public int NumFileInitiationBytesSent
	{
		get
		{
			short num = -23846;
			short num2 = num;
			num = -23846;
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
				return m;
			}
		}
		private set
		{
			int num = default(int);
			switch (0)
			{
			default:
				while (true)
				{
					short num2;
					switch (num)
					{
					case 4:
						if (m > ReceiverFileInitiationMaxAttempts)
						{
							num2 = 2;
							num = num2;
							continue;
						}
						return;
					case 1:
						k = NAK;
						m = 0;
						return;
					case 0:
						num2 = 5;
						num = num2;
						continue;
					case 5:
						if (ReceiverFallBackAllowed)
						{
							num2 = 1;
							num = num2;
							continue;
						}
						goto IL_01a3;
					case 2:
						num2 = 3;
						num = num2;
						continue;
					case 3:
						if (k == C)
						{
							num2 = 10502;
							short num3 = num2;
							num2 = 10502;
							switch (num3 == num2)
							{
							case false:
							case true:
								break;
							default:
								num2 = 0;
								_ = num2;
								num2 = 0;
								if (num2 != 0)
								{
								}
								num2 = 1;
								if (num2 != 0)
								{
								}
								num2 = 0;
								num = num2;
								continue;
							}
							goto case 1;
						}
						goto IL_01a3;
					case 6:
						return;
						IL_01a3:
						e();
						_TerminationReason = TerminationReasonEnum.FileInitiationTimeout;
						this.m_h.Set();
						num2 = 6;
						num = num2;
						continue;
					}
					break;
				}
				goto case 0;
			case 0:
			{
				m = value;
				short num2 = 4;
				num = num2;
				goto default;
			}
			}
		}
	}

	public int ReceiverNumConsecutiveNAKSent
	{
		get
		{
			short num = 12071;
			short num2 = num;
			num = 12071;
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
				return _ReceiverNumConsecutiveNAKSent;
			}
		}
		set
		{
			int num = default(int);
			short num2;
			switch (0)
			{
			default:
				while (true)
				{
					switch (num)
					{
					case 1:
						goto IL_0083;
					case 0:
						num2 = 1;
						if (num2 != 0)
						{
						}
						num2 = 0;
						_ = num2;
						e();
						_TerminationReason = TerminationReasonEnum.TooManyRetries;
						this.m_h.Set();
						num2 = 2;
						num = num2;
						continue;
					case 2:
						return;
					}
					break;
				}
				goto case 0;
			case 0:
				{
					num2 = -12074;
					short num3 = num2;
					num2 = -12074;
					switch (num3 == num2)
					{
					case false:
					case true:
						goto IL_0094;
					}
					num2 = 0;
					if (num2 != 0)
					{
					}
					_ReceiverNumConsecutiveNAKSent = value;
					num2 = 1;
					num = num2;
					goto default;
				}
				IL_0083:
				if (_ReceiverNumConsecutiveNAKSent < ReceiverMaxConsecutiveRetries)
				{
					break;
				}
				goto IL_0094;
				IL_0094:
				num2 = 0;
				num = num2;
				goto default;
			}
		}
	}

	public byte BlockNumToSend
	{
		get
		{
			short num = -13241;
			short num2 = num;
			num = -13241;
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
				return ah;
			}
		}
	}

	public int TotalUserDataBytesPacketized
	{
		get
		{
			short num = 2207;
			short num2 = num;
			num = 2207;
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
				return ai;
			}
		}
	}

	public int TotalUserDataBytesSent
	{
		get
		{
			short num = -27133;
			short num2 = num;
			num = -27133;
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
				return aj;
			}
		}
	}

	public int SenderConsecutiveRetryAttempts
	{
		get
		{
			short num = 2855;
			short num2 = num;
			num = 2855;
			switch (num2 == num)
			{
			default:
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
				return am;
			}
		}
	}

	public event PacketReceivedEventHandler PacketReceived
	{
		[CompilerGenerated]
		add
		{
			int num = default(int);
			PacketReceivedEventHandler packetReceivedEventHandler = default(PacketReceivedEventHandler);
			PacketReceivedEventHandler packetReceivedEventHandler2 = default(PacketReceivedEventHandler);
			PacketReceivedEventHandler value2;
			short num2;
			switch (0)
			{
			default:
				while (true)
				{
					switch (num)
					{
					case 1:
						goto IL_0086;
					case 0:
						num2 = 0;
						_ = num2;
						if ((object)packetReceivedEventHandler == packetReceivedEventHandler2)
						{
							num2 = 1;
							if (num2 != 0)
							{
							}
							num2 = 2;
							num = num2;
							continue;
						}
						goto IL_0086;
					case 2:
						return;
					}
					break;
				}
				goto case 0;
			case 0:
				{
					num2 = 2492;
					short num3 = num2;
					num2 = 2492;
					switch (num3 == num2)
					{
					case false:
					case true:
						goto IL_0086;
					}
					num2 = 0;
					if (num2 != 0)
					{
					}
					packetReceivedEventHandler = this.m_g;
					num2 = 1;
					num = num2;
					goto default;
				}
				IL_0086:
				packetReceivedEventHandler2 = packetReceivedEventHandler;
				value2 = (PacketReceivedEventHandler)Delegate.Combine(packetReceivedEventHandler2, value);
				packetReceivedEventHandler = Interlocked.CompareExchange(ref this.m_g, value2, packetReceivedEventHandler2);
				num2 = 0;
				num = num2;
				goto default;
			}
		}
		[CompilerGenerated]
		remove
		{
			int num = default(int);
			PacketReceivedEventHandler packetReceivedEventHandler = default(PacketReceivedEventHandler);
			PacketReceivedEventHandler packetReceivedEventHandler2 = default(PacketReceivedEventHandler);
			PacketReceivedEventHandler value2;
			short num2;
			switch (0)
			{
			default:
				while (true)
				{
					switch (num)
					{
					case 1:
						goto IL_0083;
					case 0:
						num2 = 0;
						_ = num2;
						if ((object)packetReceivedEventHandler == packetReceivedEventHandler2)
						{
							num2 = 1;
							if (num2 != 0)
							{
							}
							num2 = 2;
							num = num2;
							continue;
						}
						goto IL_0083;
					case 2:
						return;
					}
					break;
				}
				goto case 0;
			case 0:
				{
					num2 = -32092;
					short num3 = num2;
					num2 = -32092;
					switch (num3 == num2)
					{
					case false:
					case true:
						goto IL_0083;
					}
					num2 = 0;
					if (num2 != 0)
					{
					}
					packetReceivedEventHandler = this.m_g;
					num2 = 1;
					num = num2;
					goto default;
				}
				IL_0083:
				packetReceivedEventHandler2 = packetReceivedEventHandler;
				value2 = (PacketReceivedEventHandler)Delegate.Remove(packetReceivedEventHandler2, value);
				packetReceivedEventHandler = Interlocked.CompareExchange(ref this.m_g, value2, packetReceivedEventHandler2);
				num2 = 0;
				num = num2;
				goto default;
			}
		}
	}

	public XMODEM(SerialPort port, Variants variant, byte paddingByte = 26, byte endOfFileByteToSend = 4)
	{
		PaddingByte = paddingByte;
		EndOfFileByteToSend = endOfFileByteToSend;
		Port = port;
		Variant = variant;
	}

	public void CancelFileTransfer()
	{
		int num = default(int);
		int num2 = default(int);
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 1:
				{
					short num3 = 1641;
					short num4 = num3;
					num3 = 1641;
					switch (num4 == num3)
					{
					case false:
					case true:
						goto IL_013d;
					}
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
					goto case 3;
				}
				case 3:
				{
					short num3 = 2;
					num = num3;
					continue;
				}
				case 2:
				{
					short num3;
					if (num2 > this.m_b)
					{
						num3 = 0;
						num = num3;
						continue;
					}
					a(CAN);
					num2++;
					num3 = 3;
					num = num3;
					continue;
				}
				case 0:
					goto IL_013d;
					IL_013d:
					_TerminationReason = TerminationReasonEnum.UserCancelled;
					return;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			e();
			num2 = 1;
			short num3 = 1;
			num = num3;
			goto default;
		}
		}
	}

	public TerminationReasonEnum Receive(MemoryStream allDataReceivedBuffer = null)
	{
		int num = default(int);
		short num2;
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 8:
					goto IL_00e2;
				case 9:
					Port.DiscardInBuffer();
					Port.DiscardOutBuffer();
					this.m_j = allDataReceivedBuffer;
					Port.DataReceived += a;
					num2 = 0;
					num = num2;
					continue;
				case 0:
					goto IL_0156;
				case 6:
					Port.Open();
					num2 = 9;
					num = num2;
					continue;
				case 5:
					k = NAK;
					num2 = 4;
					num = num2;
					continue;
				case 2:
					l = new Timer(d, null, 0, ReceiverFileInitiationRetryMillisec);
					num2 = 7;
					num = num2;
					continue;
				case 1:
				case 4:
					goto IL_0261;
				case 10:
					num2 = 1;
					if (num2 != 0)
					{
					}
					if (!Port.IsOpen)
					{
						num2 = 6;
						num = num2;
						continue;
					}
					goto case 9;
				case 3:
				case 7:
					this.m_h.Reset();
					this.m_h.WaitOne();
					this.m_h.Reset();
					return TerminationReason;
				}
				break;
				IL_0156:
				if (l == null)
				{
					num2 = 2;
					num = num2;
				}
				else
				{
					l.Change(0, ReceiverFileInitiationRetryMillisec);
					num2 = 3;
					num = num2;
				}
				continue;
				IL_00e2:
				if (this.m_e == Variants.XModemChecksum)
				{
					num2 = 5;
					num = num2;
				}
				else
				{
					k = C;
					num2 = 1;
					num = num2;
				}
			}
			goto case 0;
		case 0:
			{
				num2 = 12412;
				short num3 = num2;
				num2 = 12412;
				switch (num3 == num2)
				{
				case false:
				case true:
					goto IL_0261;
				}
				num2 = 0;
				if (num2 != 0)
				{
				}
				_TerminationReason = TerminationReasonEnum.TransferStillActiveNotTerminated;
				z = false;
				t = 1;
				m = 0;
				this.m_i = 0;
				v = new byte[0];
				x = 0;
				s = true;
				n = false;
				num2 = 8;
				num = num2;
				goto default;
			}
			IL_0261:
			this.m_f = XMODEM.a.b;
			num2 = 0;
			_ = num2;
			num2 = 10;
			num = num2;
			goto default;
		}
	}

	private void d(object A_0)
	{
		short num = -5021;
		short num2 = num;
		num = -5021;
		switch (num2 == num)
		{
		}
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
		a(k);
		NumFileInitiationBytesSent++;
	}

	private void a(object A_0, SerialDataReceivedEventArgs A_1)
	{
		switch (0)
		{
		case 0:
			goto IL_00a0;
		}
		goto IL_000a;
		IL_000a:
		int num = default(int);
		int bytesToRead = default(int);
		byte[] array = default(byte[]);
		a a = default(a);
		short num2;
		while (true)
		{
			switch (num)
			{
			case 33:
				if (bytesToRead > 0)
				{
					num2 = 29;
					num = num2;
					continue;
				}
				goto case 13;
			case 27:
				if (!this.a(array))
				{
					num2 = 32;
					num = num2;
					continue;
				}
				goto case 13;
			case 18:
				Variant = Variants.XModem1K;
				num2 = 28;
				num = num2;
				continue;
			case 19:
				o = new Timer(c, null, ReceiverTimeoutMillisec, ReceiverTimeoutMillisec);
				num2 = 14;
				num = num2;
				continue;
			case 17:
				l.Change(-1, -1);
				num2 = 30;
				num = num2;
				continue;
			case 32:
				num2 = 6;
				num = num2;
				continue;
			case 6:
				if (Array.IndexOf(array, ACK) > -1)
				{
					num2 = 1;
					num = num2;
				}
				else
				{
					num2 = 21;
					num = num2;
				}
				continue;
			case 9:
				if (!this.a(array))
				{
					num2 = 20;
					num = num2;
					continue;
				}
				goto case 13;
			case 3:
				num2 = 10;
				num = num2;
				continue;
			case 10:
				if (Array.IndexOf(array, C) > -1)
				{
					num2 = 18;
					num = num2;
					continue;
				}
				goto case 28;
			case 16:
				an = true;
				e();
				num2 = 13;
				num = num2;
				continue;
			case 35:
				num2 = 15;
				num = num2;
				continue;
			case 15:
				num2 = 1;
				if (num2 != 0)
				{
				}
				if (Array.IndexOf(array, C) <= -1)
				{
					num2 = 34;
					num = num2;
					continue;
				}
				goto case 22;
			case 29:
				a = this.m_f;
				num2 = 5;
				num = num2;
				continue;
			case 5:
				switch (a)
				{
				case a.i:
					this.a();
					num2 = 27;
					num = num2;
					break;
				case a.k:
					this.a();
					num2 = 9;
					num = num2;
					break;
				case a.j:
					this.a();
					this.a(array);
					return;
				default:
					num2 = 2;
					num = num2;
					break;
				case a.c:
				case a.d:
				case a.e:
				case a.f:
				case a.g:
					j();
					c(array);
					return;
				case a.b:
					num2 = 12;
					num = num2;
					break;
				case a.h:
					this.a();
					num2 = 7;
					num = num2;
					break;
				}
				continue;
			case 2:
				return;
			case 30:
				num2 = 31;
				num = num2;
				continue;
			case 31:
				if (o != null)
				{
					o.Change(ReceiverTimeoutMillisec, ReceiverTimeoutMillisec);
					num2 = 0;
					num = num2;
				}
				else
				{
					num2 = 19;
					num = num2;
				}
				continue;
			case 0:
			case 14:
				this.m_f = a.c;
				c(array);
				return;
			case 21:
				if (Array.IndexOf(array, NAK) > -1)
				{
					num2 = 8;
					num = num2;
					continue;
				}
				goto case 13;
			case 8:
			{
				num2 = -23207;
				short num3 = num2;
				num2 = -23207;
				switch (num3 == num2)
				{
				default:
					num2 = 0;
					if (num2 != 0)
					{
					}
					b();
					am++;
					aa.Set();
					return;
				case false:
				case true:
					break;
				}
				goto IL_054a;
			}
			case 1:
				b();
				am = 0;
				al = true;
				ah++;
				aa.Set();
				return;
			case 34:
				num2 = 23;
				num = num2;
				continue;
			case 23:
				if (Array.IndexOf(array, NAK) > -1)
				{
					goto IL_054a;
				}
				goto case 13;
			case 22:
				num2 = 24;
				num = num2;
				continue;
			case 24:
				if (this.m_e == Variants.XModemChecksum)
				{
					num2 = 3;
					num = num2;
					continue;
				}
				goto case 28;
			case 25:
				Variant = Variants.XModemChecksum;
				num2 = 11;
				num = num2;
				continue;
			case 12:
				if (l != null)
				{
					num2 = 17;
					num = num2;
					continue;
				}
				goto case 30;
			case 7:
				if (!this.a(array))
				{
					num2 = 35;
					num = num2;
					continue;
				}
				goto case 13;
			case 20:
				num2 = 4;
				num = num2;
				continue;
			case 4:
				if (Array.IndexOf(array, ACK) > -1)
				{
					num2 = 16;
					num = num2;
					continue;
				}
				goto case 13;
			case 28:
				num2 = 26;
				num = num2;
				continue;
			case 26:
				if (Array.IndexOf(array, NAK) > -1)
				{
					num2 = 25;
					num = num2;
					continue;
				}
				goto case 11;
			case 11:
				this.m_f = a.j;
				aa.Set();
				return;
			case 13:
				{
					num2 = 0;
					_ = num2;
					return;
				}
				IL_054a:
				num2 = 22;
				num = num2;
				continue;
			}
			break;
		}
		goto IL_00a0;
		IL_00a0:
		SerialPort obj = A_0 as SerialPort;
		bytesToRead = obj.BytesToRead;
		array = new byte[bytesToRead];
		obj.Read(array, 0, bytesToRead);
		num2 = 33;
		num = num2;
		goto IL_000a;
	}

	private void j()
	{
		short num = 1;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 1:
				switch (0)
				{
				default:
					continue;
				case 0:
					break;
				}
				goto default;
			default:
				if (o != null)
				{
					num = 0;
					num2 = num;
					continue;
				}
				break;
			case 0:
				num = 0;
				_ = num;
				o.Change(ReceiverTimeoutMillisec, ReceiverTimeoutMillisec);
				num = 2;
				num2 = num;
				continue;
			case 2:
				break;
			}
			num = 8578;
			short num3 = num;
			num = 8578;
			switch (num3 == num)
			{
			case false:
			case true:
				continue;
			}
			num = 0;
			if (num != 0)
			{
			}
			num = 1;
			if (num != 0)
			{
			}
			ReceiverNumConsecutiveNAKSent = 0;
			return;
		}
	}

	private void c(object A_0)
	{
		short num = 12466;
		short num2 = num;
		num = 12466;
		switch (num2 == num)
		{
		}
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
		i();
	}

	private void i()
	{
		short num = -8217;
		short num2 = num;
		num = -8217;
		switch (num2 == num)
		{
		}
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
		a(NAK);
		ReceiverNumConsecutiveNAKSent++;
	}

	private void h()
	{
		short num = 28060;
		short num2 = num;
		num = 28060;
		switch (num2 == num)
		{
		}
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
		a(ACK);
		ReceiverNumConsecutiveNAKSent = 0;
	}

	private void c(byte[] A_0)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 47;
			int num2 = num;
			int num4 = default(int);
			int num3 = default(int);
			int num12 = default(int);
			int num11 = default(int);
			int num9 = default(int);
			int num8 = default(int);
			int num7 = default(int);
			int num10 = default(int);
			int num5 = default(int);
			while (true)
			{
				switch (num2)
				{
				case 47:
					switch (0)
					{
					default:
						goto end_IL_0040;
					case 0:
						break;
					}
					goto default;
				default:
					if (A_0.Length == 0)
					{
						num = 45;
						num2 = num;
						break;
					}
					goto IL_0b1f;
				case 45:
					return;
				case 66:
					r = u[num4];
					num = 85;
					num2 = num;
					break;
				case 85:
					if (r == 255 - q)
					{
						num = 36;
						num2 = num;
					}
					else
					{
						num = 71;
						num2 = num;
					}
					break;
				case 55:
					if (this.m_f == XMODEM.a.d)
					{
						num = 73;
						num2 = num;
					}
					else
					{
						num = 109;
						num2 = num;
					}
					break;
				case 80:
					if (this.m_g != null)
					{
						num = 121;
						num2 = num;
						break;
					}
					goto case 51;
				case 38:
					num = 92;
					num2 = num;
					break;
				case 92:
					if (this.m_e == Variants.XModem1K)
					{
						num = 107;
						num2 = num;
						break;
					}
					goto case 46;
				case 126:
					num = 89;
					num2 = num;
					break;
				case 89:
					if (u[num3] != EOF)
					{
						num = 80;
						num2 = num;
					}
					else
					{
						num = 99;
						num2 = num;
					}
					break;
				case 109:
					if (this.m_f == XMODEM.a.e)
					{
						num = 66;
						num2 = num;
					}
					else
					{
						num = 101;
						num2 = num;
					}
					break;
				case 8:
					num12 = num11;
					num = 48;
					num2 = num;
					break;
				case 73:
					q = u[num4];
					num = 20;
					num2 = num;
					break;
				case 20:
					if (this.m_e != Variants.XModemChecksum)
					{
						num = 15;
						num2 = num;
						break;
					}
					goto case 94;
				case 91:
					num = 61;
					num2 = num;
					break;
				case 61:
					if (w != null)
					{
						num = 116;
						num2 = num;
						break;
					}
					goto case 51;
				case 46:
				case 93:
					this.m_f = XMODEM.a.c;
					num = 3;
					num2 = num;
					break;
				case 106:
					y = new byte[1] { u[num4] };
					g();
					num3 = num4 + 1;
					this.m_f = XMODEM.a.c;
					num = 72;
					num2 = num;
					break;
				case 100:
					num9 = Array.IndexOf(u, STX, num3);
					num8 = Array.IndexOf(u, SOH, num3);
					num7 = 0;
					num = 128;
					num2 = num;
					break;
				case 128:
					if (num9 > -1)
					{
						num = 110;
						num2 = num;
						break;
					}
					goto IL_09cc;
				case 0:
					this.m_g(this, w, endOfFileDetected: true);
					num = 124;
					num2 = num;
					break;
				case 111:
					num = 70;
					num2 = num;
					break;
				case 70:
					if (n)
					{
						num = 127;
						num2 = num;
						break;
					}
					goto case 124;
				case 116:
					num = 123;
					num2 = num;
					break;
				case 123:
					if (w.Length != 0)
					{
						num = 83;
						num2 = num;
						break;
					}
					goto case 51;
				case 117:
					num10 = u.Length - num4;
					num11 = w.Length - x;
					num = 62;
					num2 = num;
					break;
				case 62:
					if (num10 >= num11)
					{
						num = 8;
						num2 = num;
					}
					else
					{
						num12 = num10;
						num = 39;
						num2 = num;
					}
					break;
				case 50:
					num = 52;
					num2 = num;
					break;
				case 52:
					if (q == SOH)
					{
						num = 129;
						num2 = num;
						break;
					}
					goto IL_0814;
				case 108:
					if (num5 > -1)
					{
						num = 26;
						num2 = num;
						break;
					}
					goto IL_02cc;
				case 26:
					num3 = num5 + 1;
					p = this.m_d;
					num4 = num5 + 1;
					this.m_f = XMODEM.a.d;
					num = 118;
					num2 = num;
					break;
				case 103:
					num = 82;
					num2 = num;
					break;
				case 82:
					if (q != SOH)
					{
						num = 44;
						num2 = num;
						break;
					}
					goto case 125;
				case 121:
					num = 40;
					num2 = num;
					break;
				case 40:
					if (n)
					{
						num = 91;
						num2 = num;
						break;
					}
					goto case 51;
				case 53:
					if (v.Length == 0)
					{
						num = 38;
						num2 = num;
						break;
					}
					goto case 9;
				case 79:
					this.m_i++;
					num = 59;
					num2 = num;
					break;
				case 59:
					if (this.m_i < this.m_a)
					{
						num3++;
						num = 1;
						num2 = num;
					}
					else
					{
						num = 90;
						num2 = num;
					}
					break;
				case 51:
					num = 1;
					if (num != 0)
					{
					}
					n = false;
					num = 86;
					num2 = num;
					break;
				case 86:
					if (this.m_a > 0)
					{
						num = 11;
						num2 = num;
						break;
					}
					goto case 74;
				case 83:
					this.m_g(this, w, endOfFileDetected: false);
					num = 51;
					num2 = num;
					break;
				case 35:
					if (num8 > -1)
					{
						num = 87;
						num2 = num;
						break;
					}
					return;
				case 54:
					num = 5;
					num2 = num;
					break;
				case 5:
					if (this.m_f == XMODEM.a.c)
					{
						num = 19;
						num2 = num;
						break;
					}
					goto IL_12c0;
				case 97:
					if (num9 <= -1)
					{
						num = 35;
						num2 = num;
					}
					else
					{
						num = 104;
						num2 = num;
					}
					break;
				case 17:
					num = 14;
					num2 = num;
					break;
				case 14:
					if (this.m_e == Variants.XModemCRC)
					{
						num = 77;
						num2 = num;
					}
					else
					{
						num = 98;
						num2 = num;
					}
					break;
				case 71:
					if (v.Length == 0)
					{
						num = 34;
						num2 = num;
						break;
					}
					goto case 129;
				case 4:
					return;
				case 9:
					v = a(v, new byte[1] { r });
					num = 46;
					num2 = num;
					break;
				case 99:
					h();
					e();
					_TerminationReason = TerminationReasonEnum.EndOfFile;
					num = 114;
					num2 = num;
					break;
				case 114:
					if (this.m_g != null)
					{
						num = 111;
						num2 = num;
						break;
					}
					goto case 124;
				case 120:
					if (v.Length != 0)
					{
						num = 54;
						num2 = num;
						break;
					}
					goto IL_12c0;
				case 39:
				case 48:
					Array.Copy(u, num4, w, x, num12);
					x += num12;
					num4 += num12;
					num = 112;
					num2 = num;
					break;
				case 112:
					if (x >= p)
					{
						num = 119;
						num2 = num;
						break;
					}
					goto case 1;
				case 11:
					num = 67;
					num2 = num;
					break;
				case 67:
					if (u[num3] == CAN)
					{
						num = 79;
						num2 = num;
					}
					else
					{
						this.m_i = 0;
						num = 74;
						num2 = num;
					}
					break;
				case 76:
					num = 60;
					num2 = num;
					break;
				case 60:
					if (u[num3] != EOT)
					{
						num = 126;
						num2 = num;
						break;
					}
					goto case 99;
				case 102:
					num = 56;
					num2 = num;
					break;
				case 56:
					if (this.m_e == Variants.XModemCRC)
					{
						num = 50;
						num2 = num;
						break;
					}
					goto IL_0814;
				case 88:
					if (this.m_f == XMODEM.a.c)
					{
						num = 27;
						num2 = num;
						break;
					}
					goto IL_02cc;
				case 6:
					num = 41;
					num2 = num;
					break;
				case 41:
					if (w.Length != 0)
					{
						num = 0;
						num2 = num;
						break;
					}
					goto case 124;
				case 7:
					if (this.m_e == Variants.XModem1K)
					{
						num = 103;
						num2 = num;
						break;
					}
					goto case 21;
				case 37:
					num = 24;
					num2 = num;
					break;
				case 24:
					if (q == STX)
					{
						num = 9;
						num2 = num;
						break;
					}
					goto case 46;
				case 12:
					w = new byte[p];
					x = 0;
					num4++;
					this.m_f = XMODEM.a.f;
					num = 28;
					num2 = num;
					break;
				case 107:
					num = 105;
					num2 = num;
					break;
				case 105:
					if (q != SOH)
					{
						num = 37;
						num2 = num;
						break;
					}
					goto case 9;
				case 124:
					this.m_h.Set();
					return;
				case 94:
					num = 23;
					num2 = num;
					break;
				case 23:
					if (q == SOH)
					{
						num = 95;
						num2 = num;
						break;
					}
					goto IL_0d30;
				case 98:
					if (this.m_e == Variants.XModem1K)
					{
						num = 100;
						num2 = num;
						break;
					}
					goto IL_02cc;
				case 32:
				case 33:
				case 49:
				case 84:
					num3 = num7 + 1;
					num4 = num7 + 1;
					this.m_f = XMODEM.a.d;
					num = 63;
					num2 = num;
					break;
				case 25:
					v = new byte[0];
					num = 76;
					num2 = num;
					break;
				case 16:
					v = new byte[0];
					num = 12;
					num2 = num;
					break;
				case 15:
					num = 64;
					num2 = num;
					break;
				case 64:
					if (this.m_e == Variants.XModemCRC)
					{
						num = 94;
						num2 = num;
						break;
					}
					goto IL_0d30;
				case 13:
					p = this.m_c;
					num7 = num9;
					num = 49;
					num2 = num;
					break;
				case 65:
					num = 68;
					num2 = num;
					break;
				case 68:
					if (num9 <= num8)
					{
						num = 13;
						num2 = num;
						break;
					}
					p = this.m_d;
					num7 = num8;
					num = 32;
					num2 = num;
					break;
				case 95:
					v = new byte[1] { q };
					num = 43;
					num2 = num;
					break;
				case 96:
					if (this.m_f == XMODEM.a.g)
					{
						num = 106;
						num2 = num;
						break;
					}
					goto case 1;
				case 104:
					p = this.m_c;
					num7 = num9;
					num = 84;
					num2 = num;
					break;
				case 110:
					num = 31;
					num2 = num;
					break;
				case 31:
					if (num8 > -1)
					{
						num = 65;
						num2 = num;
						break;
					}
					goto IL_09cc;
				case 125:
				{
					num = -30216;
					short num6 = num;
					num = -30216;
					switch (num6 == num)
					{
					case false:
					case true:
						break;
					default:
						num = 0;
						_ = num;
						num = 0;
						if (num != 0)
						{
						}
						v = new byte[1] { q };
						num = 21;
						num2 = num;
						goto end_IL_0040;
					}
					goto IL_0b1f;
				}
				case 129:
					v = a(v, new byte[1] { r });
					num = 93;
					num2 = num;
					break;
				case 44:
					num = 29;
					num2 = num;
					break;
				case 29:
					if (q == STX)
					{
						num = 125;
						num2 = num;
						break;
					}
					goto case 21;
				case 27:
					num = 75;
					num2 = num;
					break;
				case 75:
					if (v.Length != 0)
					{
						num = 25;
						num2 = num;
						break;
					}
					goto case 76;
				case 127:
					num = 81;
					num2 = num;
					break;
				case 81:
					if (w != null)
					{
						num = 6;
						num2 = num;
						break;
					}
					goto case 124;
				case 19:
					u = a(v, A_0);
					num = 18;
					num2 = num;
					break;
				case 90:
					e();
					_TerminationReason = TerminationReasonEnum.CancelNotificationReceived;
					this.m_h.Set();
					return;
				case 87:
					p = this.m_d;
					num7 = num8;
					num = 33;
					num2 = num;
					break;
				case 101:
					if (this.m_f != XMODEM.a.f)
					{
						num = 96;
						num2 = num;
					}
					else
					{
						num = 117;
						num2 = num;
					}
					break;
				case 34:
					num = 2;
					num2 = num;
					break;
				case 2:
					if (this.m_e != Variants.XModemChecksum)
					{
						num = 102;
						num2 = num;
						break;
					}
					goto case 50;
				case 36:
					num = 57;
					num2 = num;
					break;
				case 57:
					if (v.Length != 0)
					{
						num = 16;
						num2 = num;
						break;
					}
					goto case 12;
				case 77:
					num5 = Array.IndexOf(u, SOH, num3);
					num = 22;
					num2 = num;
					break;
				case 22:
					if (num5 != -1)
					{
						num = 108;
						num2 = num;
					}
					else
					{
						num = 4;
						num2 = num;
					}
					break;
				case 21:
				case 43:
					num4++;
					this.m_f = XMODEM.a.e;
					num = 58;
					num2 = num;
					break;
				case 1:
				case 3:
				case 28:
				case 58:
				case 63:
				case 72:
				case 113:
				case 118:
				case 122:
					num = 78;
					num2 = num;
					break;
				case 78:
					if (num4 < u.Length)
					{
						num = 42;
						num2 = num;
						break;
					}
					return;
				case 18:
				case 30:
					num3 = 0;
					num4 = 0;
					num = 122;
					num2 = num;
					break;
				case 74:
					num = 10;
					num2 = num;
					break;
				case 10:
					if (this.m_e != Variants.XModemChecksum)
					{
						num = 17;
						num2 = num;
						break;
					}
					goto case 77;
				case 119:
					this.m_f = XMODEM.a.g;
					y = new byte[0];
					num = 113;
					num2 = num;
					break;
				case 42:
					num = 115;
					num2 = num;
					break;
				case 115:
					if (num3 < u.Length)
					{
						num = 88;
						num2 = num;
					}
					else
					{
						num = 69;
						num2 = num;
					}
					break;
				case 69:
					return;
					IL_02cc:
					num = 55;
					num2 = num;
					break;
					IL_0814:
					num = 53;
					num2 = num;
					break;
					IL_0d30:
					num = 7;
					num2 = num;
					break;
					IL_09cc:
					num = 97;
					num2 = num;
					break;
					IL_12c0:
					u = A_0;
					num = 30;
					num2 = num;
					break;
					IL_0b1f:
					num = 120;
					num2 = num;
					break;
					end_IL_0040:
					break;
				}
			}
		}
		}
	}

	private void g()
	{
		short num = 6;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 6:
				switch (0)
				{
				default:
					continue;
				case 0:
					break;
				}
				goto default;
			default:
				if (q == t)
				{
					num = 5;
					num2 = num;
				}
				else
				{
					num = 1;
					num2 = num;
				}
				continue;
			case 1:
				if (!s)
				{
					num = 8;
					num2 = num;
					continue;
				}
				break;
			case 7:
				t++;
				s = false;
				num = 0;
				num2 = num;
				continue;
			case 0:
				if (this.m_j != null)
				{
					num = 4;
					num2 = num;
					continue;
				}
				goto case 3;
			case 2:
			{
				num = -27751;
				short num3 = num;
				num = -27751;
				switch (num3 == num)
				{
				default:
					num = 0;
					if (num != 0)
					{
					}
					h();
					n = false;
					return;
				case false:
				case true:
					break;
				}
				goto IL_025b;
			}
			case 5:
				num = 10;
				num2 = num;
				continue;
			case 10:
				if (!f())
				{
					i();
					n = false;
					return;
				}
				num = 7;
				num2 = num;
				continue;
			case 8:
				num = 9;
				num2 = num;
				continue;
			case 9:
				num = 1;
				if (num != 0)
				{
				}
				if (q == (byte)(t - 1))
				{
					num = 2;
					num2 = num;
					continue;
				}
				break;
			case 3:
				n = true;
				h();
				return;
			case 4:
				{
					this.m_j.Write(w, 0, w.Length);
					goto IL_025b;
				}
				IL_025b:
				num = 0;
				_ = num;
				num = 3;
				num2 = num;
				continue;
			}
			break;
		}
		i();
		n = false;
	}

	private bool f()
	{
		short num = 0;
		_ = num;
		num = 2;
		int num2 = num;
		while (true)
		{
			num = 1;
			if (num != 0)
			{
			}
			switch (num2)
			{
			case 2:
				switch (0)
				{
				default:
					goto end_IL_0071;
				case 0:
					break;
				}
				goto default;
			default:
				if (this.m_e == Variants.XModemChecksum)
				{
					num = 3;
					num2 = num;
					break;
				}
				return false;
			case 1:
				return true;
			case 3:
			{
				num = -15317;
				short num3 = num;
				num = -15317;
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
					num = 0;
					num2 = num;
					goto end_IL_0071;
				}
				goto IL_00a8;
			}
			case 0:
				{
					if (b(w) == y[0])
					{
						num = 1;
						num2 = num;
						break;
					}
					goto IL_00a8;
				}
				IL_00a8:
				return false;
				end_IL_0071:
				break;
			}
		}
	}

	private ushort a(byte A_0, byte A_1)
	{
		short num = -7655;
		short num2 = num;
		num = -7655;
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
			return (ushort)((A_0 << 8) + A_1);
		}
	}

	private byte[] a(ushort A_0)
	{
		short num = -31497;
		short num2 = num;
		num = -31497;
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
			byte b = (byte)(A_0 / 256);
			byte b2 = (byte)(A_0 % 256);
			return new byte[2] { b, b2 };
		}
		}
	}

	private byte b(byte[] A_0)
	{
		short num = 0;
		_ = num;
		int num2 = default(int);
		int num4 = default(int);
		byte b = default(byte);
		switch (0)
		{
		default:
			while (true)
			{
				switch (num2)
				{
				case 1:
				case 2:
					num = 3;
					num2 = num;
					continue;
				case 3:
					if (num4 >= A_0.Length)
					{
						num = 0;
						num2 = num;
						continue;
					}
					b += A_0[num4];
					num4++;
					num = 1;
					num2 = num;
					continue;
				case 0:
				{
					num = 14048;
					short num3 = num;
					num = 14048;
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
						num = 1;
						if (num != 0)
						{
						}
						return b;
					}
					goto case 3;
				}
				}
				break;
			}
			goto case 0;
		case 0:
			b = 0;
			num4 = 0;
			num = 2;
			num2 = num;
			goto default;
		}
	}

	private void e()
	{
		short num = 10189;
		short num2 = num;
		num = 10189;
		int num3 = default(int);
		switch (num2 == num)
		{
		default:
			num = 0;
			_ = num;
			num = 0;
			if (num != 0)
			{
			}
			switch (0)
			{
			case 0:
				goto IL_00b5;
			}
			goto IL_007f;
		case false:
		case true:
			goto IL_0294;
			IL_00b5:
			this.m_f = XMODEM.a.a;
			af = true;
			ak = false;
			z = true;
			Port.DataReceived -= a;
			aa.Set();
			num = 5;
			num3 = num;
			goto IL_007f;
			IL_007f:
			while (true)
			{
				switch (num3)
				{
				case 5:
					if (o != null)
					{
						num = 8;
						num3 = num;
						continue;
					}
					goto case 9;
				case 3:
					ab.Change(-1, -1);
					num = 10;
					num3 = num;
					continue;
				case 10:
					num = 1;
					if (num == 0)
					{
					}
					goto IL_0257;
				case 1:
					num = 4;
					num3 = num;
					continue;
				case 4:
					if (ab != null)
					{
						num = 3;
						num3 = num;
						continue;
					}
					goto IL_0257;
				case 9:
					num = 11;
					num3 = num;
					continue;
				case 11:
					if (l != null)
					{
						num = 7;
						num3 = num;
						continue;
					}
					goto case 1;
				case 2:
					ac.Change(-1, -1);
					num = 0;
					num3 = num;
					continue;
				case 8:
					o.Change(-1, -1);
					num = 9;
					num3 = num;
					continue;
				case 6:
					if (ac != null)
					{
						num = 2;
						num3 = num;
						continue;
					}
					goto case 0;
				case 7:
					goto IL_0294;
				case 0:
					{
						Port.DiscardInBuffer();
						Port.DiscardOutBuffer();
						return;
					}
					IL_0257:
					num = 6;
					num3 = num;
					continue;
				}
				break;
			}
			goto IL_00b5;
			IL_0294:
			l.Change(-1, -1);
			num = 1;
			num3 = num;
			goto IL_007f;
		}
	}

	private void d()
	{
		short num = 4;
		int num2 = num;
		int num4 = default(int);
		int num3 = default(int);
		while (true)
		{
			switch (num2)
			{
			case 4:
				switch (0)
				{
				default:
					goto end_IL_001f;
				case 0:
					break;
				}
				goto default;
			default:
				if (this.m_e == Variants.XModem1K)
				{
					num = 6;
					num2 = num;
					break;
				}
				num4 = this.m_d;
				goto IL_019a;
			case 2:
			case 3:
			{
				num = -2362;
				short num5 = num;
				num = -2362;
				switch (num5 == num)
				{
				default:
					num = 0;
					if (num != 0)
					{
					}
					ad = new byte[num4];
					num3 = 0;
					num = 0;
					_ = num;
					num = 7;
					num2 = num;
					goto end_IL_001f;
				case false:
				case true:
					break;
				}
				goto IL_019a;
			}
			case 6:
				num4 = this.m_c;
				num = 2;
				num2 = num;
				break;
			case 1:
			case 7:
				num = 5;
				num2 = num;
				break;
			case 5:
				if (num3 < ad.Length)
				{
					ad[num3] = PaddingByte;
					num3++;
					num = 1;
					num2 = num;
				}
				else
				{
					num = 0;
					num2 = num;
				}
				break;
			case 0:
				{
					num = 1;
					if (num == 0)
					{
					}
					return;
				}
				IL_019a:
				num = 3;
				num2 = num;
				break;
				end_IL_001f:
				break;
			}
		}
	}

	public int Send(byte[] dataToSend = null)
	{
		int num3 = default(int);
		switch (0)
		{
		default:
			while (true)
			{
				short num = -18563;
				short num2 = num;
				num = -18563;
				switch (num2 == num)
				{
				default:
					num = 0;
					if (num != 0)
					{
					}
					switch (num3)
					{
					case 1:
						goto IL_0129;
					case 9:
						goto IL_017d;
					case 14:
						goto IL_0195;
					case 16:
						goto IL_0202;
					case 10:
						goto IL_021a;
					case 5:
						goto IL_025b;
					case 15:
						goto IL_027f;
					case 17:
						goto IL_02ac;
					case 0:
						goto IL_02d4;
					case 8:
						goto IL_031a;
					case 3:
						return aj;
					case 2:
					case 4:
						goto IL_0343;
					case 13:
						goto IL_035a;
					case 11:
						goto IL_037e;
					case 12:
						goto IL_03a7;
					case 7:
						if (af)
						{
							goto case 3;
						}
						goto IL_03d1;
					case 6:
						goto IL_03ed;
					}
					break;
				case false:
				case true:
					goto IL_0202;
					IL_02d4:
					Port.DataReceived += a;
					aa.WaitOne();
					aa.Reset();
					num = 8;
					num3 = num;
					continue;
					IL_03ed:
					ab = new Timer(b, null, SenderPacketRetryTimeoutMillisec, SenderPacketRetryTimeoutMillisec);
					num = 0;
					num3 = num;
					continue;
					IL_03d1:
					num = 5;
					num3 = num;
					continue;
					IL_03a7:
					AddToOutboundPacket(dataToSend);
					num = 7;
					num3 = num;
					continue;
					IL_037e:
					Port.Open();
					num = 15;
					num3 = num;
					continue;
					IL_035a:
					if (ab != null)
					{
						ab.Change(SenderPacketRetryTimeoutMillisec, SenderPacketRetryTimeoutMillisec);
						num = 16;
						num3 = num;
					}
					else
					{
						num = 6;
						num3 = num;
					}
					continue;
					IL_0195:
					if (!z)
					{
						num = 12;
						num3 = num;
						continue;
					}
					goto IL_0462;
					IL_027f:
					Port.DiscardInBuffer();
					Port.DiscardOutBuffer();
					num = 17;
					num3 = num;
					continue;
					IL_0343:
					num = 13;
					num3 = num;
					continue;
					IL_031a:
					if (dataToSend != null)
					{
						num = 9;
						num3 = num;
						continue;
					}
					goto IL_0462;
					IL_0462:
					return 0;
					IL_02ac:
					if (ac == null)
					{
						num = 10;
						num3 = num;
					}
					else
					{
						ac.Change(SendInactivityTimeoutMillisec, SendInactivityTimeoutMillisec);
						num = 2;
						num3 = num;
					}
					continue;
					IL_017d:
					num = 14;
					num3 = num;
					continue;
					IL_0129:
					num = 1;
					if (num != 0)
					{
					}
					if (!Port.IsOpen)
					{
						num = 11;
						num3 = num;
						continue;
					}
					goto IL_027f;
					IL_025b:
					EndFile();
					num = 3;
					num3 = num;
					continue;
					IL_021a:
					ac = new Timer(a, null, SendInactivityTimeoutMillisec, SendInactivityTimeoutMillisec);
					num = 4;
					num3 = num;
					continue;
					IL_0202:
					num = 0;
					_ = num;
					goto IL_02d4;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			_TerminationReason = TerminationReasonEnum.TransferStillActiveNotTerminated;
			z = false;
			ah = 1;
			am = 0;
			al = false;
			ae = null;
			ag = 0;
			ai = 0;
			aj = 0;
			this.m_i = 0;
			af = false;
			an = false;
			ak = true;
			aa.Reset();
			this.m_f = XMODEM.a.h;
			short num = 1;
			num3 = num;
			goto default;
		}
		}
	}

	public int AddToOutboundPacket(byte[] dataToSend)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			int num6 = default(int);
			switch (0)
			{
			default:
			{
				int num3 = default(int);
				int num5 = default(int);
				int num8 = default(int);
				int num4 = default(int);
				while (true)
				{
					switch (num2)
					{
					case 0:
						if (!ak)
						{
							num = 0;
							_ = num;
							num = 6;
							num2 = num;
						}
						else
						{
							num3 = 0;
							num = 5;
							num2 = num;
						}
						continue;
					case 7:
						Thread.Sleep(10);
						c();
						num = 19;
						num2 = num;
						continue;
					case 19:
						if (al)
						{
							num = 22;
							num2 = num;
						}
						else
						{
							num = 16;
							num2 = num;
						}
						continue;
					case 2:
						num = 20;
						num2 = num;
						continue;
					case 20:
						if (this.m_e == Variants.XModem1K)
						{
							num = 24;
							num2 = num;
						}
						else
						{
							ae = new byte[this.m_d];
							num = 9;
							num2 = num;
						}
						continue;
					case 17:
						e();
						_TerminationReason = TerminationReasonEnum.TooManyRetries;
						num = 14;
						num2 = num;
						continue;
					case 22:
						aj += ag;
						num6 += ag;
						ag = 0;
						ae = null;
						num = 10;
						num2 = num;
						continue;
					case 5:
					case 10:
						num = 11;
						num2 = num;
						continue;
					case 11:
						if (num3 < dataToSend.Length)
						{
							num = 25;
							num2 = num;
							continue;
						}
						goto case 14;
					case 13:
						num5 = dataToSend.Length - num3;
						num8 = ae.Length - ag;
						num = 1;
						num2 = num;
						continue;
					case 1:
						if (num8 < num5)
						{
							num4 = num8;
							num = 4;
							num2 = num;
						}
						else
						{
							num = 12;
							num2 = num;
						}
						continue;
					case 24:
						ae = new byte[this.m_c];
						num = 18;
						num2 = num;
						continue;
					case 16:
						if (!af)
						{
							num = 17;
							num2 = num;
							continue;
						}
						goto case 5;
					case 25:
						num = 3;
						num2 = num;
						continue;
					case 3:
						if (af)
						{
							num = 21;
							num2 = num;
						}
						else
						{
							num = 23;
							num2 = num;
						}
						continue;
					case 6:
					{
						num = -8524;
						short num7 = num;
						num = -8524;
						switch (num7 == num)
						{
						case false:
						case true:
							break;
						default:
							num = 1;
							if (num != 0)
							{
							}
							num = 0;
							if (num != 0)
							{
							}
							throw new ArgumentException("The XMODEM.Send() method must first be called before XMODEM.AddToOutboundPacket() is used.");
						}
						goto case 5;
					}
					case 23:
						if (ae == null)
						{
							num = 2;
							num2 = num;
							continue;
						}
						goto case 13;
					case 9:
					case 18:
						Array.Copy(ad, ae, ae.Length);
						num = 13;
						num2 = num;
						continue;
					case 12:
						num4 = num5;
						num = 15;
						num2 = num;
						continue;
					case 4:
					case 15:
						Array.Copy(dataToSend, num3, ae, ag, num4);
						ag += num4;
						num3 += num4;
						ai += num4;
						num = 8;
						num2 = num;
						continue;
					case 8:
						if (ag >= ae.Length)
						{
							num = 7;
							num2 = num;
							continue;
						}
						goto case 5;
					case 14:
					case 21:
						return num6;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				num6 = 0;
				num = 0;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private void c()
	{
		short num = 32382;
		short num2 = num;
		num = 32382;
		byte[] array = default(byte[]);
		int num3 = default(int);
		byte a_ = default(byte);
		switch (num2 == num)
		{
		default:
			num = 0;
			_ = num;
			num = 0;
			if (num != 0)
			{
			}
			switch (0)
			{
			case 0:
				goto IL_00b3;
			}
			goto IL_007d;
		case false:
		case true:
			goto IL_022c;
			IL_00b3:
			array = new byte[1] { b(ae) };
			num = 5;
			num3 = num;
			goto IL_007d;
			IL_007d:
			while (true)
			{
				switch (num3)
				{
				case 5:
					goto IL_00dd;
				case 1:
				case 3:
					num = 10;
					num3 = num;
					continue;
				case 10:
					if (!al)
					{
						num = 4;
						num3 = num;
						continue;
					}
					return;
				case 2:
					goto IL_022c;
				case 7:
					goto IL_0244;
				case 0:
					return;
				case 8:
					a_ = STX;
					num = 9;
					num3 = num;
					continue;
				case 4:
					num = 6;
					num3 = num;
					continue;
				case 6:
					if (am < MaxSenderRetries)
					{
						num = 2;
						num3 = num;
						continue;
					}
					return;
				case 9:
				case 11:
					al = false;
					num = 1;
					num3 = num;
					continue;
				}
				break;
				IL_0244:
				if (!af)
				{
					num = 1;
					if (num != 0)
					{
					}
					a(a_);
					a(ah);
					a((byte)(255 - ah));
					Port.Write(ae, 0, ae.Length);
					aa.Reset();
					this.m_f = XMODEM.a.i;
					Port.Write(array, 0, array.Length);
					aa.WaitOne();
					aa.Reset();
					this.m_f = XMODEM.a.j;
					num = 3;
					num3 = num;
				}
				else
				{
					num = 0;
					num3 = num;
				}
				continue;
				IL_00dd:
				if (this.m_e == Variants.XModem1K)
				{
					num = 8;
					num3 = num;
				}
				else
				{
					a_ = SOH;
					num = 11;
					num3 = num;
				}
			}
			goto IL_00b3;
			IL_022c:
			num = 7;
			num3 = num;
			goto IL_007d;
		}
	}

	private bool a(byte[] A_0)
	{
		short num = 2;
		int num2 = num;
		int num3 = default(int);
		int num5 = default(int);
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
				if (NumCancellationBytesRequired > 0)
				{
					num = 12;
					num2 = num;
					continue;
				}
				break;
			case 8:
			case 13:
				num = 14;
				num2 = num;
				continue;
			case 14:
				if (this.m_i < NumCancellationBytesRequired)
				{
					num3++;
					num = 5;
					num2 = num;
				}
				else
				{
					num = 0;
					num2 = num;
				}
				continue;
			case 6:
				num3 = num5;
				num = 4;
				num2 = num;
				continue;
			case 12:
				num5 = Array.IndexOf(A_0, CAN);
				num = 7;
				num2 = num;
				continue;
			case 7:
				if (num5 > -1)
				{
					num = 1;
					if (num != 0)
					{
					}
					num = 6;
					num2 = num;
				}
				else
				{
					this.m_i = 0;
					num = 1;
					num2 = num;
				}
				continue;
			case 4:
			case 5:
				num = 3;
				num2 = num;
				continue;
			case 3:
				if (num3 >= A_0.Length)
				{
					num = 11;
					num2 = num;
				}
				else
				{
					num = 9;
					num2 = num;
				}
				continue;
			case 11:
				num = 0;
				_ = num;
				num = 15;
				num2 = num;
				continue;
			case 9:
			{
				if (A_0[num3] != CAN)
				{
					this.m_i = 0;
					num = 13;
					num2 = num;
					continue;
				}
				num = 8952;
				short num4 = num;
				num = 8952;
				switch (num4 == num)
				{
				case false:
				case true:
					break;
				default:
					num = 0;
					if (num != 0)
					{
					}
					num = 10;
					num2 = num;
					continue;
				}
				goto case 6;
			}
			case 0:
				e();
				_TerminationReason = TerminationReasonEnum.CancelNotificationReceived;
				return true;
			case 10:
				this.m_i++;
				num = 8;
				num2 = num;
				continue;
			case 1:
			case 15:
				break;
			}
			break;
		}
		return false;
	}

	public int EndFile()
	{
		int num3 = default(int);
		while (true)
		{
			short num = 4;
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 4:
					switch (0)
					{
					default:
						continue;
					case 0:
						break;
					}
					goto default;
				default:
					if (ag > 0)
					{
						num = 7;
						num2 = num;
						continue;
					}
					goto case 8;
				case 7:
					num = 1;
					if (num != 0)
					{
					}
					c();
					aj += ag;
					num = 8;
					num2 = num;
					continue;
				case 6:
					num = 9;
					num2 = num;
					continue;
				case 9:
					break;
				case 0:
				case 1:
					num = 10;
					num2 = num;
					continue;
				case 10:
					if (!an)
					{
						num = 6;
						num2 = num;
						continue;
					}
					goto case 2;
				case 8:
					this.m_f = XMODEM.a.k;
					num3 = 0;
					num = 1;
					num2 = num;
					continue;
				case 3:
					e();
					_TerminationReason = TerminationReasonEnum.EndOfFile;
					return ag;
				case 2:
					num = 5;
					num2 = num;
					continue;
				case 5:
					if (an)
					{
						num = 3;
						num2 = num;
						continue;
					}
					e();
					_TerminationReason = TerminationReasonEnum.TooManyRetries;
					return 0;
				}
				num = 0;
				_ = num;
				if (num3 > MaxSenderRetries)
				{
					num = 2;
					num2 = num;
					continue;
				}
				aa.Reset();
				a(EndOfFileByteToSend);
				num3++;
				aa.WaitOne();
				num = 5900;
				short num4 = num;
				num = 5900;
				switch (num4 == num)
				{
				case false:
				case true:
					break;
				default:
					num = 0;
					if (num != 0)
					{
					}
					num = 0;
					num2 = num;
					continue;
				}
				break;
			}
		}
	}

	private void b(object A_0)
	{
		short num = 0;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 0:
				num = 0;
				_ = num;
				switch (0)
				{
				default:
					goto end_IL_0049;
				case 0:
					break;
				}
				goto default;
			default:
				if (this.m_f == XMODEM.a.i)
				{
					num = 1;
					num2 = num;
					break;
				}
				return;
			case 1:
			{
				num = 24518;
				short num3 = num;
				num = 24518;
				switch (num3 == num)
				{
				default:
					num = 1;
					if (num != 0)
					{
					}
					num = 0;
					if (num == 0)
					{
					}
					break;
				case false:
				case true:
					break;
				}
				aa.Set();
				num = 2;
				num2 = num;
				break;
			}
			case 2:
				return;
				end_IL_0049:
				break;
			}
		}
	}

	private void b()
	{
		short num = 0;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 0:
				num = 0;
				_ = num;
				switch (0)
				{
				default:
					goto end_IL_0049;
				case 0:
					break;
				}
				goto default;
			default:
				if (ab != null)
				{
					num = 1;
					num2 = num;
					break;
				}
				return;
			case 1:
			{
				num = 24446;
				short num3 = num;
				num = 24446;
				switch (num3 == num)
				{
				default:
					num = 0;
					if (num != 0)
					{
					}
					num = 1;
					if (num == 0)
					{
					}
					break;
				case false:
				case true:
					break;
				}
				ab.Change(SenderPacketRetryTimeoutMillisec, SenderPacketRetryTimeoutMillisec);
				num = 2;
				num2 = num;
				break;
			}
			case 2:
				return;
				end_IL_0049:
				break;
			}
		}
	}

	private void a(object A_0)
	{
		short num = 10942;
		short num2 = num;
		num = 10942;
		switch (num2 == num)
		{
		}
		num = 0;
		_ = num;
		num = 0;
		if (num != 0)
		{
		}
		num = 1;
		if (num != 0)
		{
		}
		e();
		_TerminationReason = TerminationReasonEnum.NoResponseFromReceiver;
	}

	private void a()
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = 0;
		_ = num;
		num = 0;
		int num2 = num;
		while (true)
		{
			switch (num2)
			{
			case 0:
				switch (0)
				{
				default:
					goto end_IL_0070;
				case 0:
					break;
				}
				goto default;
			default:
				if (ac != null)
				{
					num = 1;
					num2 = num;
					break;
				}
				return;
			case 1:
			{
				num = 3961;
				short num3 = num;
				num = 3961;
				switch (num3 == num)
				{
				default:
					num = 0;
					if (num == 0)
					{
					}
					break;
				case false:
				case true:
					break;
				}
				ac.Change(SendInactivityTimeoutMillisec, SendInactivityTimeoutMillisec);
				num = 2;
				num2 = num;
				break;
			}
			case 2:
				return;
				end_IL_0070:
				break;
			}
		}
	}

	public byte[] TrimPaddingBytesFromEnd(byte[] input, byte paddingByteToRemove = 26)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			int num4 = default(int);
			int num3 = default(int);
			switch (0)
			{
			default:
				while (true)
				{
					switch (num2)
					{
					case 1:
					case 3:
						goto IL_00c8;
					case 2:
						goto IL_00f4;
					case 4:
						num4++;
						num3--;
						num = 1;
						num2 = num;
						continue;
					case 5:
						if (input[num3] == paddingByteToRemove)
						{
							num = 4;
							num2 = num;
							continue;
						}
						goto case 0;
					case 0:
					{
						int num5 = input.Length - num4;
						byte[] array = new byte[num5];
						Array.Copy(input, array, num5);
						return array;
					}
					}
					break;
					IL_00f4:
					num = 1;
					if (num != 0)
					{
					}
					if (num3 < 0)
					{
						num = 0;
						num2 = num;
					}
					else
					{
						num = 5;
						num2 = num;
					}
				}
				goto case 0;
			case 0:
				{
					num4 = 0;
					num3 = input.Length - 1;
					num = -25574;
					short num6 = num;
					num = -25574;
					switch (num6 == num)
					{
					case false:
					case true:
						goto IL_00c8;
					}
					num = 0;
					if (num != 0)
					{
					}
					num = 3;
					num2 = num;
					goto default;
				}
				IL_00c8:
				num = 0;
				_ = num;
				num = 2;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private void a(byte A_0)
	{
		short num = -7562;
		short num2 = num;
		num = -7562;
		switch (num2 == num)
		{
		}
		num = 0;
		_ = num;
		num = 1;
		if (num != 0)
		{
		}
		num = 0;
		if (num != 0)
		{
		}
		byte[] buffer = new byte[1] { A_0 };
		Port.Write(buffer, 0, 1);
	}

	private static byte[] a(byte[] A_0, byte[] A_1)
	{
		short num = 3820;
		short num2 = num;
		num = 3820;
		switch (num2 == num)
		{
		default:
		{
			num = 0;
			_ = num;
			num = 0;
			if (num != 0)
			{
			}
			num = 1;
			if (num != 0)
			{
			}
			byte[] array = new byte[A_0.Length + A_1.Length];
			Buffer.BlockCopy(A_0, 0, array, 0, A_0.Length);
			Buffer.BlockCopy(A_1, 0, array, A_0.Length, A_1.Length);
			return array;
		}
		}
	}
}
