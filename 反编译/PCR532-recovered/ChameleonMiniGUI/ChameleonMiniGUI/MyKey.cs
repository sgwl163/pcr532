namespace ChameleonMiniGUI;

public class MyKey
{
	public uint UID;

	public uint nt0;

	public uint nt1;

	public uint nr0;

	public uint nr1;

	public uint ar0;

	public uint ar1;

	public ulong key;

	public byte Sector;

	public byte Block;

	public byte KeyType;

	public bool Found;

	public const ulong DoNotDecryptCanary = 5928239340301921844uL;

	public const int DoNotDecryptCanaryOffset = 8;

	public const int DoNotDecryptCanarySize = 8;
}
