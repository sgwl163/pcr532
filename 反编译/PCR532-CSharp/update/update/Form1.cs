using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace update;

public class Form1 : Form
{
	private IContainer components;

	private RichTextBox richTextBox1;

	public Form1()
	{
		base.StartPosition = FormStartPosition.CenterScreen;
		InitializeComponent();
		logAppend("PCR532即将进行升级，请稍后！");
		BackgroundWorker backgroundWorker = new BackgroundWorker();
		backgroundWorker.DoWork += Update_soft;
		backgroundWorker.WorkerReportsProgress = true;
		backgroundWorker.RunWorkerAsync(new string[1] { "newkey" });
	}

	private void logAppend(string msg)
	{
		richTextBox1.AppendText(msg + "\n");
		richTextBox1.ScrollToCaret();
		if (richTextBox1.Lines.Length > 200)
		{
			richTextBox1.Clear();
		}
	}

	[DllImport("kernel32.dll")]
	public static extern int WinExec(string exeName, int operType);

	private void Update_soft(object sender, DoWorkEventArgs e)
	{
		string text = "./nfc-data/tmp/update.zip";
		string text2 = "http://129.204.205.124/app/update.zip";
		string text3 = "http://www.pn532.com/app/update.zip";
		string text4 = "http://www.rfidfans.com/app/update.zip";
		string text5 = "http://120.24.245.232/app/update.zip";
		string text6 = new Random().Next(0, 3) switch
		{
			1 => text3, 
			2 => text4, 
			0 => text2, 
			3 => text5, 
			_ => text3, 
		};
		try
		{
			string path = "./Languages";
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			path = "./Templates";
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
		}
		catch (Exception ex)
		{
			Console.Write(ex.Message);
		}
		WebClient webClient = new WebClientto(20000);
		try
		{
			if (File.Exists(text))
			{
				File.Delete(text);
			}
			logAppend("正在下载.......");
			logAppend(text6);
			webClient.DownloadFile(text6, text);
			if (!File.Exists(text))
			{
				logAppend("下载失败，请重试！");
				return;
			}
			logAppend("下载完成，将要进行升级");
		}
		catch (Exception ex2)
		{
			logAppend(ex2.Message);
			logAppend("下载失败，请重试！");
			Console.Write(ex2.Message);
			return;
		}
		try
		{
			logAppend("开始解压升级包");
			string text7 = "./nfc-data/tmp/update";
			if (Directory.Exists(text7))
			{
				Directory.Delete(text7, recursive: true);
			}
			Directory.CreateDirectory(text7);
			ZipFile.ExtractToDirectory(text, text7);
			logAppend("解压完成，开始更新软件");
		}
		catch (Exception ex3)
		{
			logAppend(ex3.Message);
			Console.Write(ex3.Message);
		}
		string path2 = "./nfc-data/tmp/update/updatelist";
		if (!File.Exists(path2))
		{
			logAppend("文件损坏，升级失败");
			return;
		}
		string[] array = File.ReadAllLines(path2);
		List<string> list = new List<string>();
		string text8 = "./nfc-data/tmp/update/";
		string text9 = null;
		string[] array2 = array;
		foreach (string text10 in array2)
		{
			if (text10.Equals(""))
			{
				continue;
			}
			text9 = text8 + text10;
			try
			{
				if (File.Exists(text9))
				{
					logAppend("正在删除文件" + text10);
					File.Delete(text10);
					Thread.Sleep(500);
					logAppend("正在更新文件" + text10);
					File.Move(text9, text10);
				}
				else
				{
					logAppend("正在更新文件" + text10);
					File.Move(text9, text10);
				}
			}
			catch (Exception ex4)
			{
				logAppend(ex4.Message);
				list.Add(text10);
			}
		}
		for (int j = 0; j < 10; j++)
		{
			foreach (string item in list)
			{
				text9 = text8 + item;
				try
				{
					if (File.Exists(text9))
					{
						logAppend("正在删除文件" + item);
						File.Delete(item);
						Thread.Sleep(500);
						logAppend("正在更新文件" + item);
						File.Move(text9, item);
					}
					else
					{
						logAppend("正在更新文件" + item);
						File.Move(text9, item);
					}
					list.Remove(item);
				}
				catch (Exception ex5)
				{
					logAppend(ex5.Message);
					logAppend("请使用任务管理器关闭掉PN532CardReader.exe或者PCR532.exe");
					Thread.Sleep(500);
				}
			}
		}
		logAppend("更新完成，将启动软件");
		Thread.Sleep(1000);
		File.Delete(text);
		WinExec("PN532CardReader.exe", 5);
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(update.Form1));
		this.richTextBox1 = new System.Windows.Forms.RichTextBox();
		base.SuspendLayout();
		this.richTextBox1.BackColor = System.Drawing.Color.Black;
		this.richTextBox1.ForeColor = System.Drawing.Color.Aqua;
		this.richTextBox1.Location = new System.Drawing.Point(4, 12);
		this.richTextBox1.Name = "richTextBox1";
		this.richTextBox1.Size = new System.Drawing.Size(356, 209);
		this.richTextBox1.TabIndex = 2;
		this.richTextBox1.Text = "";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(368, 233);
		base.Controls.Add(this.richTextBox1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.Name = "Form1";
		this.Text = "PCR532 升级程序";
		base.ResumeLayout(false);
	}
}
