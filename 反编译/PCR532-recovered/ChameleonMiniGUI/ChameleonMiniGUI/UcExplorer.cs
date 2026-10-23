using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ChameleonMiniGUI.Dump;
using ChameleonMiniGUI.Properties;

namespace ChameleonMiniGUI;

public class UcExplorer : UserControl
{
	private static ImageList m_a;

	private IContainer m_b;

	private SplitContainer c;

	private ImageList m_d;

	private TreeView e;

	private ListView f;

	private ColumnHeader g;

	private ColumnHeader h;

	private ColumnHeader i;

	private ContextMenuStrip j;

	private ColumnHeader k;

	private static ImageList TreeImages
	{
		get
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
					if (UcExplorer.m_a == null)
					{
						num = 0;
						num2 = num;
						continue;
					}
					break;
				case 0:
					while (true)
					{
						UcExplorer.m_a = new ImageList();
						UcExplorer.m_a.Images.Add("Harddrive", Resources.hardDrive);
						UcExplorer.m_a.Images.Add("CDrom", Resources.cdrom);
						UcExplorer.m_a.Images.Add("Networkdrive", Resources.networkDrive);
						UcExplorer.m_a.Images.Add("Folderopen", Resources.folderOpen);
						UcExplorer.m_a.Images.Add("Folderclose", Resources.folderClose);
						UcExplorer.m_a.Images.Add("Warning", Resources.warning);
						num = 7541;
						short num3 = num;
						num = 7541;
						switch (num3 == num)
						{
						case false:
						case true:
							continue;
						}
						break;
					}
					num = 0;
					if (num != 0)
					{
					}
					num = 2;
					num2 = num;
					continue;
				case 2:
					num = 1;
					if (num == 0)
					{
					}
					break;
				}
				break;
			}
			num = 0;
			_ = num;
			return UcExplorer.m_a;
		}
	}

	public UcExplorer()
	{
		a();
		d();
	}

	private void d()
	{
		short num = 0;
		_ = num;
		num = 10039;
		short num2 = num;
		num = 10039;
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
		e.ImageList = TreeImages;
		a(e);
		b();
	}

	private void a(DirectoryInfo[] A_0, TreeNode A_1)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			int num4 = default(int);
			DirectoryInfo[] array = default(DirectoryInfo[]);
			switch (0)
			{
			default:
			{
				DirectoryInfo directoryInfo = default(DirectoryInfo);
				TreeNode treeNode = default(TreeNode);
				DirectoryInfo[] directories = default(DirectoryInfo[]);
				while (true)
				{
					switch (num2)
					{
					case 2:
						num = 0;
						_ = num;
						goto case 4;
					case 4:
						num = 0;
						num2 = num;
						continue;
					case 0:
						if (num4 < array.Length)
						{
							directoryInfo = array[num4];
							treeNode = new TreeNode(directoryInfo.Name, 0, 0)
							{
								Tag = directoryInfo,
								ImageIndex = 3,
								SelectedImageIndex = 4
							};
							num = 1;
							num2 = num;
						}
						else
						{
							num = 3;
							num2 = num;
						}
						continue;
					case 3:
						return;
					case 1:
						try
						{
							switch (0)
							{
							default:
								while (true)
								{
									switch (num2)
									{
									case 3:
										if (directories.Length != 0)
										{
											num = 1;
											num2 = num;
											continue;
										}
										goto IL_021d;
									case 1:
										num = 1;
										if (num != 0)
										{
										}
										a(directories, treeNode);
										num = 0;
										num2 = num;
										continue;
									case 0:
										goto IL_021d;
									case 2:
										goto end_IL_012b;
									}
									break;
								}
								goto case 0;
							case 0:
								{
									num = 19554;
									short num3 = num;
									num = 19554;
									switch (num3 == num)
									{
									case false:
									case true:
										goto IL_021d;
									}
									num = 0;
									if (num != 0)
									{
									}
									directories = directoryInfo.GetDirectories();
									num = 3;
									num2 = num;
									goto default;
								}
								IL_021d:
								num = 2;
								num2 = num;
								goto default;
								end_IL_012b:
								break;
							}
						}
						catch (UnauthorizedAccessException)
						{
							treeNode.ImageIndex = 5;
							treeNode.SelectedImageIndex = 5;
						}
						finally
						{
							A_1.Nodes.Add(treeNode);
						}
						num4++;
						num = 2;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				array = A_0;
				num4 = 0;
				num = 4;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private void a(string A_0, TreeView A_1)
	{
		short num = 4;
		int num2 = num;
		DirectoryInfo directoryInfo = default(DirectoryInfo);
		TreeNode treeNode = default(TreeNode);
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
				num = 0;
				_ = num;
				num = 1;
				if (num != 0)
				{
				}
				if (string.IsNullOrWhiteSpace(A_0))
				{
					num = 2;
					num2 = num;
					continue;
				}
				goto IL_00de;
			case 2:
				return;
			case 0:
				if (directoryInfo.GetDirectories().Any())
				{
					num = 3;
					num2 = num;
					continue;
				}
				break;
			case 3:
			{
				num = 22079;
				short num3 = num;
				num = 22079;
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
					treeNode.Nodes.Add(null, "...", 5, 5);
					num = 1;
					num2 = num;
					continue;
				}
				goto IL_00de;
			}
			case 1:
				break;
				IL_00de:
				directoryInfo = new DirectoryInfo(A_0);
				treeNode = new TreeNode(directoryInfo.Name, 3, 4)
				{
					Tag = directoryInfo
				};
				num = 0;
				num2 = num;
				continue;
			}
			break;
		}
		A_1.Nodes.Add(treeNode);
	}

	private void a(TreeView A_0)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			int num3 = default(int);
			string[] logicalDrives = default(string[]);
			switch (0)
			{
			default:
			{
				TreeNode treeNode = default(TreeNode);
				string text = default(string);
				int imageIndex = default(int);
				int selectedImageIndex = default(int);
				DriveInfo driveInfo = default(DriveInfo);
				DriveType driveType = default(DriveType);
				while (true)
				{
					short num4;
					switch (num2)
					{
					case 2:
					case 4:
					case 5:
					case 6:
					case 9:
						treeNode = new TreeNode(text.Substring(0, 1), imageIndex, selectedImageIndex)
						{
							Tag = driveInfo
						};
						num = 13;
						num2 = num;
						continue;
					case 13:
						if (driveInfo.IsReady)
						{
							num = 8;
							num2 = num;
							continue;
						}
						goto IL_014d;
					case 3:
						num = 1;
						num2 = num;
						continue;
					case 12:
						switch (driveType)
						{
						case DriveType.Unknown:
							break;
						default:
							goto IL_01c8;
						case DriveType.NoRootDirectory:
							goto IL_02a8;
						case DriveType.CDRom:
							goto IL_0317;
						case DriveType.Removable:
						case DriveType.Fixed:
							goto IL_033b;
						case DriveType.Network:
							goto IL_035e;
						}
						imageIndex = 5;
						selectedImageIndex = 5;
						num = 4;
						num2 = num;
						continue;
					case 8:
						treeNode.Nodes.Add("...");
						num = 0;
						num2 = num;
						continue;
					case 0:
						num = 1;
						if (num == 0)
						{
						}
						goto IL_014d;
					case 7:
					case 14:
						num = 0;
						_ = num;
						num = 10;
						num2 = num;
						continue;
					case 10:
						if (num3 < logicalDrives.Length)
						{
							text = logicalDrives[num3];
							driveInfo = new DriveInfo(text);
							driveType = driveInfo.DriveType;
							num = 12;
							num2 = num;
						}
						else
						{
							num = 11;
							num2 = num;
						}
						continue;
					case 11:
						return;
					case 1:
						goto IL_033b;
						IL_035e:
						imageIndex = 2;
						selectedImageIndex = 2;
						num = 9;
						num2 = num;
						continue;
						IL_033b:
						imageIndex = 0;
						selectedImageIndex = 0;
						goto IL_0341;
						IL_0317:
						imageIndex = 1;
						selectedImageIndex = 1;
						num = 2;
						num2 = num;
						continue;
						IL_02a8:
						imageIndex = 4;
						selectedImageIndex = 3;
						num = 24001;
						num4 = num;
						num = 24001;
						switch (num4 == num)
						{
						default:
							num = 0;
							if (num != 0)
							{
							}
							num = 5;
							num2 = num;
							continue;
						case false:
						case true:
							break;
						}
						goto IL_0341;
						IL_0341:
						num = 6;
						num2 = num;
						continue;
						IL_01c8:
						num = 3;
						num2 = num;
						continue;
						IL_014d:
						A_0.Nodes.Add(treeNode);
						num3++;
						num = 7;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				a("../..", A_0);
				a(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), A_0);
				a(Environment.GetFolderPath(Environment.SpecialFolder.Personal), A_0);
				logicalDrives = Environment.GetLogicalDrives();
				num3 = 0;
				num = 14;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private void b()
	{
		short num = 6454;
		short num2 = num;
		num = 6454;
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
		f.ContextMenuStrip = j;
	}

	private void a(TreeNode A_0)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			DriveInfo driveInfo = default(DriveInfo);
			switch (0)
			{
			default:
			{
				DirectoryInfo directoryInfo = default(DirectoryInfo);
				FileInfo[] files = default(FileInfo[]);
				int num4 = default(int);
				DirectoryInfo[] directories = default(DirectoryInfo[]);
				while (true)
				{
					switch (num2)
					{
					case 11:
						if (driveInfo != null)
						{
							num = 5;
							num2 = num;
						}
						else
						{
							directoryInfo = A_0.Tag as DirectoryInfo;
							num = 9;
							num2 = num;
						}
						continue;
					case 2:
						files = directoryInfo.GetFiles();
						num4 = 0;
						num = 0;
						num2 = num;
						continue;
					case 6:
					case 10:
						num = 4;
						num2 = num;
						continue;
					case 4:
						if (num4 >= directories.Length)
						{
							num = 1;
							if (num != 0)
							{
							}
							num = 2;
							num2 = num;
						}
						else
						{
							DirectoryInfo directoryInfo2 = directories[num4];
							ListViewItem listViewItem = new ListViewItem(directoryInfo2.Name, 0);
							ListViewItem.ListViewSubItem[] items = new ListViewItem.ListViewSubItem[3]
							{
								new ListViewItem.ListViewSubItem(listViewItem, "Directory"),
								new ListViewItem.ListViewSubItem(listViewItem, ""),
								new ListViewItem.ListViewSubItem(listViewItem, directoryInfo2.LastAccessTime.ToShortDateString())
							};
							listViewItem.SubItems.AddRange(items);
							f.Items.Add(listViewItem);
							num4++;
							num = 6;
							num2 = num;
						}
						continue;
					case 0:
					case 1:
						num = 7;
						num2 = num;
						continue;
					case 7:
					{
						if (num4 >= files.Length)
						{
							num = 3;
							num2 = num;
							continue;
						}
						FileInfo fileInfo = files[num4];
						string text = $"{fileInfo.Length / 1024} kb";
						ListViewItem listViewItem = new ListViewItem(fileInfo.Name, 1)
						{
							Tag = fileInfo
						};
						ListViewItem.ListViewSubItem[] items = new ListViewItem.ListViewSubItem[3]
						{
							new ListViewItem.ListViewSubItem(listViewItem, "File"),
							new ListViewItem.ListViewSubItem(listViewItem, text),
							new ListViewItem.ListViewSubItem(listViewItem, fileInfo.LastAccessTime.ToShortDateString())
						};
						listViewItem.SubItems.AddRange(items);
						f.Items.Add(listViewItem);
						num4++;
						num = 1;
						num2 = num;
						continue;
					}
					case 5:
						directoryInfo = driveInfo.RootDirectory;
						num = 8;
						num2 = num;
						continue;
					case 8:
					{
						num = 7871;
						short num3 = num;
						num = 7871;
						switch (num3 == num)
						{
						case false:
						case true:
							break;
						default:
							goto IL_0200;
						}
						goto case 4;
					}
					case 9:
						directories = directoryInfo.GetDirectories();
						num4 = 0;
						num = 0;
						_ = num;
						num = 10;
						num2 = num;
						continue;
					case 3:
						{
							f.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
							return;
						}
						IL_0200:
						num = 0;
						if (num == 0)
						{
						}
						goto case 9;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				f.Items.Clear();
				driveInfo = A_0.Tag as DriveInfo;
				num = 11;
				num2 = num;
				goto default;
			}
		}
		}
	}

	private void a(object A_0, TreeNodeMouseClickEventArgs A_1)
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = 25567;
		short num2 = num;
		num = 25567;
		switch (num2 == num)
		{
		}
		num = 0;
		_ = num;
		num = 0;
		if (num != 0)
		{
		}
		a(A_1.Node);
	}

	private void a(object A_0, TreeViewCancelEventArgs A_1)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 10;
			int num2 = num;
			DirectoryInfo directoryInfo = default(DirectoryInfo);
			TreeNode treeNode = default(TreeNode);
			int num3 = default(int);
			string[] directories = default(string[]);
			while (true)
			{
				num = 0;
				_ = num;
				switch (num2)
				{
				case 10:
					switch (0)
					{
					default:
						goto end_IL_0068;
					case 0:
						break;
					}
					goto default;
				default:
					if (A_1.Node.Nodes.Count > 0)
					{
						num = 4;
						num2 = num;
						break;
					}
					return;
				case 5:
					try
					{
						switch (0)
						{
						default:
							while (true)
							{
								switch (num2)
								{
								case 3:
									if (directoryInfo.GetDirectories().Any())
									{
										num = 1;
										num2 = num;
										continue;
									}
									goto IL_01ab;
								case 1:
									treeNode.Nodes.Add(null, "...", 4, 3);
									num = 0;
									num2 = num;
									continue;
								case 0:
									goto IL_01ab;
								case 2:
									goto end_IL_00cd;
								}
								break;
							}
							goto case 0;
						case 0:
							{
								num = 16232;
								short num4 = num;
								num = 16232;
								switch (num4 == num)
								{
								case false:
								case true:
									goto IL_01ab;
								}
								num = 0;
								if (num != 0)
								{
								}
								treeNode.Tag = directoryInfo;
								num = 3;
								num2 = num;
								goto default;
							}
							IL_01ab:
							num = 2;
							num2 = num;
							goto default;
							end_IL_00cd:
							break;
						}
					}
					catch (UnauthorizedAccessException)
					{
						treeNode.ImageIndex = 4;
						treeNode.SelectedImageIndex = 4;
					}
					catch (Exception ex2)
					{
						MessageBox.Show(ex2.Message, "DirectoryLister", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					finally
					{
						A_1.Node.Nodes.Add(treeNode);
					}
					num3++;
					num = 0;
					num2 = num;
					break;
				case 7:
					num = 3;
					num2 = num;
					break;
				case 3:
					if (A_1.Node.Nodes[0].Tag == null)
					{
						num = 1;
						num2 = num;
						break;
					}
					return;
				case 0:
				case 9:
					num = 8;
					num2 = num;
					break;
				case 8:
					if (num3 >= directories.Length)
					{
						num = 6;
						num2 = num;
						break;
					}
					num = 1;
					if (num != 0)
					{
					}
					directoryInfo = new DirectoryInfo(directories[num3]);
					treeNode = new TreeNode(directoryInfo.Name, 4, 3);
					num = 5;
					num2 = num;
					break;
				case 6:
					return;
				case 4:
					num = 2;
					num2 = num;
					break;
				case 2:
					if (A_1.Node.Nodes[0].Text == "...")
					{
						num = 7;
						num2 = num;
						break;
					}
					return;
				case 1:
					{
						A_1.Node.Nodes.Clear();
						directories = Directory.GetDirectories(A_1.Node.Tag.ToString());
						num3 = 0;
						num = 9;
						num2 = num;
						break;
					}
					end_IL_0068:
					break;
				}
			}
		}
		}
	}

	private void a(object A_0, ToolStripItemClickedEventArgs A_1)
	{
		short num = -18978;
		short num2 = num;
		num = -18978;
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
		DumpType a_ = (DumpType)A_1.ClickedItem.Tag;
		a((FileInfo)f.FocusedItem.Tag, a_);
		a(e.SelectedNode);
	}

	private void a(object A_0, CancelEventArgs A_1)
	{
		short num = 0;
		switch (num)
		{
		default:
		{
			num = 10;
			int num2 = num;
			ToolStripMenuItem toolStripMenuItem = default(ToolStripMenuItem);
			ToolStripMenuItem toolStripMenuItem2 = default(ToolStripMenuItem);
			ToolStripMenuItem toolStripMenuItem4 = default(ToolStripMenuItem);
			ToolStripMenuItem toolStripMenuItem3 = default(ToolStripMenuItem);
			string text = default(string);
			while (true)
			{
				switch (num2)
				{
				case 10:
					switch (0)
					{
					default:
						goto end_IL_0040;
					case 0:
						break;
					}
					goto default;
				default:
				{
					if (f.FocusedItem.SubItems[1].Text == "Directory")
					{
						num = 4;
						num2 = num;
						break;
					}
					toolStripMenuItem = new ToolStripMenuItem
					{
						Text = "To BIN",
						Tag = DumpType.Bin
					};
					toolStripMenuItem2 = new ToolStripMenuItem
					{
						Text = "To JSON",
						Tag = DumpType.Json
					};
					toolStripMenuItem4 = new ToolStripMenuItem
					{
						Text = "To EML",
						Tag = DumpType.Eml
					};
					toolStripMenuItem3 = new ToolStripMenuItem
					{
						Text = "To MCT",
						Tag = DumpType.Mct
					};
					j.Items.Clear();
					j.Items.AddRange(new ToolStripItem[4] { toolStripMenuItem, toolStripMenuItem2, toolStripMenuItem4, toolStripMenuItem3 });
					text = f.FocusedItem.Text.ToLowerInvariant();
					num = -19516;
					short num3 = num;
					num = -19516;
					switch (num3 == num)
					{
					default:
						num = 0;
						if (num != 0)
						{
						}
						num = 3;
						num2 = num;
						goto end_IL_0040;
					case false:
					case true:
						break;
					}
					goto case 2;
				}
				case 4:
					return;
				case 7:
					j.Items.Remove(toolStripMenuItem4);
					return;
				case 9:
					j.Items.Remove(toolStripMenuItem2);
					return;
				case 3:
					if (text.Contains(".bin"))
					{
						num = 1;
						num2 = num;
					}
					else
					{
						num = 5;
						num2 = num;
					}
					break;
				case 8:
					num = 1;
					if (num != 0)
					{
					}
					if (text.Contains(".mct"))
					{
						num = 6;
						num2 = num;
						break;
					}
					return;
				case 2:
					if (!text.Contains(".eml"))
					{
						num = 0;
						_ = num;
						num = 8;
						num2 = num;
					}
					else
					{
						num = 7;
						num2 = num;
					}
					break;
				case 6:
					j.Items.Remove(toolStripMenuItem3);
					num = 0;
					num2 = num;
					break;
				case 0:
					return;
				case 5:
					if (!text.Contains(".json"))
					{
						num = 2;
						num2 = num;
					}
					else
					{
						num = 9;
						num2 = num;
					}
					break;
				case 1:
					{
						j.Items.Remove(toolStripMenuItem);
						return;
					}
					end_IL_0040:
					break;
				}
			}
		}
		}
	}

	private void a(FileInfo A_0, DumpType A_1)
	{
		short num;
		if (A_0 == null)
		{
			while (true)
			{
				num = 0;
				_ = num;
				num = -26409;
				short num2 = num;
				num = -26409;
				switch (num2 == num)
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
			}
		}
		num = 1;
		if (num != 0)
		{
		}
		DumpStrategy dumpStrategy = DumpStrategyFactory.Create(A_0.FullName);
		DumpStrategy dumpStrategy2 = DumpStrategyFactory.Create(A_1);
		dumpStrategy2.FileName = Path.ChangeExtension(A_0.FullName, dumpStrategy2.Extension);
		byte[] data = dumpStrategy.Read();
		dumpStrategy2.Save(data);
	}

	protected override void Dispose(bool disposing)
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
			{
				num = -30501;
				short num3 = num;
				num = -30501;
				switch (num3 == num)
				{
				case false:
				case true:
					goto IL_00ee;
				}
				num = 0;
				if (num != 0)
				{
				}
				if (disposing)
				{
					num = 2;
					num2 = num;
					continue;
				}
				break;
			}
			case 3:
				this.m_b.Dispose();
				num = 0;
				_ = num;
				num = 1;
				num2 = num;
				continue;
			case 2:
				goto IL_00ee;
			case 0:
				num = 1;
				if (num != 0)
				{
				}
				if (this.m_b != null)
				{
					num = 3;
					num2 = num;
					continue;
				}
				break;
			case 1:
				break;
				IL_00ee:
				num = 0;
				num2 = num;
				continue;
			}
			break;
		}
		base.Dispose(disposing);
	}

	private void a()
	{
		short num = 11000;
		short num2 = num;
		num = 11000;
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
		this.m_b = new Container();
		c = new SplitContainer();
		e = new TreeView();
		this.m_d = new ImageList(this.m_b);
		f = new ListView();
		g = new ColumnHeader();
		h = new ColumnHeader();
		k = new ColumnHeader();
		i = new ColumnHeader();
		j = new ContextMenuStrip(this.m_b);
		((ISupportInitialize)c).BeginInit();
		c.Panel1.SuspendLayout();
		c.Panel2.SuspendLayout();
		c.SuspendLayout();
		SuspendLayout();
		c.Dock = DockStyle.Fill;
		c.Location = new Point(0, 0);
		c.Name = "splitContainer1";
		c.Panel1.Controls.Add(e);
		c.Panel2.Controls.Add(f);
		c.Size = new Size(490, 467);
		c.SplitterDistance = 163;
		c.TabIndex = 0;
		e.Dock = DockStyle.Fill;
		e.ImageIndex = 0;
		e.ImageList = this.m_d;
		e.Location = new Point(0, 0);
		e.Name = "treeView1";
		e.SelectedImageIndex = 0;
		e.Size = new Size(163, 467);
		e.TabIndex = 0;
		e.BeforeExpand += a;
		e.NodeMouseClick += a;
		this.m_d.ColorDepth = ColorDepth.Depth8Bit;
		this.m_d.ImageSize = new Size(16, 16);
		this.m_d.TransparentColor = Color.Transparent;
		f.Columns.AddRange(new ColumnHeader[4] { g, h, k, i });
		f.Dock = DockStyle.Fill;
		f.Location = new Point(0, 0);
		f.Name = "listView1";
		f.Size = new Size(323, 467);
		f.SmallImageList = this.m_d;
		f.TabIndex = 0;
		f.UseCompatibleStateImageBehavior = false;
		f.View = View.Details;
		g.Text = "Name";
		h.Text = "Type";
		k.Text = "Size";
		i.Text = "Last modified";
		j.Name = "contextMenuStrip1";
		j.Size = new Size(61, 4);
		j.Opening += a;
		j.ItemClicked += a;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(c);
		base.Name = "UcExplorer";
		base.Size = new Size(490, 467);
		c.Panel1.ResumeLayout(performLayout: false);
		c.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)c).EndInit();
		c.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}
}
