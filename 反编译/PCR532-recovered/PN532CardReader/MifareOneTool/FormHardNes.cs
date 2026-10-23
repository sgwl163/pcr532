using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MifareOneTool.Properties;

namespace MifareOneTool;

public class FormHardNes : Form
{
	private IContainer m_a;

	private Button m_b;

	private Button c;

	private GroupBox d;

	private Label e;

	private Label f;

	private RadioButton g;

	private RadioButton h;

	private Label i;

	private Label j;

	private TextBox k;

	private RadioButton l;

	private RadioButton m;

	private Label n;

	private Label o;

	private GroupBox p;

	private TextBox q;

	private TextBox r;

	private CheckBox s;

	private TableLayoutPanel t;

	private TableLayoutPanel u;

	private TableLayoutPanel v;

	private TableLayoutPanel w;

	private TableLayoutPanel x;

	private FlowLayoutPanel y;

	public FormHardNes()
	{
		base.StartPosition = FormStartPosition.CenterScreen;
		a();
		k.Text = Settings.Default.hard_kown_key;
		r.Text = Settings.Default.hard_kown_sec;
		if (!Settings.Default.hard_kown_dumpab.Equals("A"))
		{
			g.Checked = true;
		}
		else
		{
			h.Checked = true;
		}
		q.Text = Settings.Default.hard_unkown_sec;
		if (Settings.Default.hard_unkown_dumpab.Equals("A"))
		{
			m.Checked = true;
		}
		else
		{
			l.Checked = true;
		}
	}

	private static int a(int A_0)
	{
		int num = default(int);
		int result = default(int);
		switch (0)
		{
		default:
			while (true)
			{
				switch (num)
				{
				case 1:
				{
					short num2;
					if (A_0 < 32)
					{
						num2 = 3;
						num = num2;
						continue;
					}
					result = 128 + 16 * (A_0 - 32) + 15;
					num2 = -31989;
					short num3 = num2;
					num2 = -31989;
					switch (num3 == num2)
					{
					default:
						num2 = 0;
						if (num2 != 0)
						{
						}
						num2 = 0;
						num = num2;
						continue;
					case false:
					case true:
						break;
					}
					goto case 3;
				}
				case 3:
				{
					short num2 = 1;
					if (num2 != 0)
					{
					}
					result = A_0 * 4 + 3;
					num2 = 2;
					num = num2;
					continue;
				}
				case 0:
				case 2:
					return result;
				}
				break;
			}
			goto case 0;
		case 0:
		{
			result = 0;
			short num2 = 0;
			_ = num2;
			num2 = 1;
			num = num2;
			goto default;
		}
		}
	}

	public string GetArg()
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = 25517;
		short num2 = num;
		num = 25517;
		switch (num2 == num)
		{
		default:
			num = 0;
			_ = num;
			num = 0;
			if (num != 0)
			{
			}
			return string.Concat(string.Concat(string.Concat(string.Concat("" + k.Text.ToUpper() + " ", a(Convert.ToInt32(r.Text.Trim())).ToString(), " "), h.Checked ? "A" : "B", " "), a(Convert.ToInt32(q.Text.Trim())).ToString(), " "), m.Checked ? "A" : "B");
		}
	}

	public string GetFileAfter()
	{
		short num = 1;
		if (num != 0)
		{
		}
		num = -17723;
		short num2 = num;
		num = -17723;
		switch (num2 == num)
		{
		default:
			num = 0;
			_ = num;
			num = 0;
			if (num != 0)
			{
			}
			return string.Concat(string.Concat("_" + $"{a(Convert.ToInt32(q.Text.Trim())):D3}", (!m.Checked) ? "B" : "A"), ".txt");
		}
	}

	public bool collectOnly()
	{
		short num = 13873;
		short num2 = num;
		num = 13873;
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
			return s.Checked;
		}
	}

	private void b(object A_0, EventArgs A_1)
	{
		short num = 9890;
		short num2 = num;
		num = 9890;
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
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void a(object A_0, EventArgs A_1)
	{
		short num = 0;
		int num2 = num;
		switch (num2)
		{
		default:
		{
			string text = default(string);
			bool flag = default(bool);
			TextBox textBox = default(TextBox);
			switch (0)
			{
			default:
			{
				int result2 = default(int);
				int result = default(int);
				while (true)
				{
					switch (num2)
					{
					case 19:
						if (Regex.IsMatch(text, "[0-9A-Fa-f]{12}"))
						{
							num = 2;
							num2 = num;
							continue;
						}
						goto case 12;
					case 18:
						if (result2 >= 0)
						{
							num = 6;
							num2 = num;
							continue;
						}
						q.BackColor = Color.Tomato;
						flag = true;
						num = 9;
						num2 = num;
						continue;
					case 7:
					case 11:
						num = 8;
						num2 = num;
						continue;
					case 8:
						if (int.TryParse(q.Text, out result2))
						{
							num = 18;
							num2 = num;
						}
						else
						{
							num = 5;
							num2 = num;
						}
						continue;
					case 21:
						num = 1;
						if (num == 0)
						{
						}
						goto case 14;
					case 12:
						textBox.BackColor = Color.Tomato;
						flag = true;
						num = 14;
						num2 = num;
						continue;
					case 5:
						q.BackColor = Color.Tomato;
						flag = true;
						num = 20;
						num2 = num;
						continue;
					case 1:
						MessageBox.Show(Resources.设置错误_请修改);
						return;
					case 3:
						r.BackColor = Color.Aquamarine;
						num = 10;
						num2 = num;
						continue;
					case 10:
						num = 0;
						_ = num;
						goto case 7;
					case 14:
						num = 0;
						num2 = num;
						continue;
					case 0:
						if (!int.TryParse(r.Text, out result))
						{
							num = 13;
							num2 = num;
						}
						else
						{
							num = 17;
							num2 = num;
						}
						continue;
					case 9:
					case 15:
					case 20:
						num = 4;
						num2 = num;
						continue;
					case 4:
						if (flag)
						{
							num = 1;
							num2 = num;
							continue;
						}
						base.DialogResult = DialogResult.Yes;
						Close();
						return;
					case 6:
						q.BackColor = Color.Aquamarine;
						num = 15;
						num2 = num;
						continue;
					case 13:
						r.BackColor = Color.Tomato;
						flag = true;
						num = 7;
						num2 = num;
						continue;
					case 2:
						num = 16;
						num2 = num;
						continue;
					case 16:
						if (text.Length == 12)
						{
							num = 393;
							short num3 = num;
							num = 393;
							switch (num3 == num)
							{
							default:
								num = 0;
								if (num != 0)
								{
								}
								textBox.BackColor = Color.Aquamarine;
								textBox.Text = text;
								num = 21;
								num2 = num;
								continue;
							case false:
							case true:
								break;
							}
							goto case 17;
						}
						num = 12;
						num2 = num;
						continue;
					case 17:
						if (result >= 0)
						{
							num = 3;
							num2 = num;
							continue;
						}
						r.BackColor = Color.Tomato;
						flag = true;
						num = 11;
						num2 = num;
						continue;
					}
					break;
				}
				goto case 0;
			}
			case 0:
				flag = false;
				textBox = k;
				text = textBox.Text.Trim();
				num = 19;
				num2 = num;
				goto default;
			}
		}
		}
	}

	protected override void Dispose(bool disposing)
	{
		short num = 2;
		int num2 = num;
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
				num = 0;
				_ = num;
				if (disposing)
				{
					num = 1;
					if (num != 0)
					{
					}
					num = 4;
					num2 = num;
					continue;
				}
				break;
			case 3:
				this.m_a.Dispose();
				num = 1;
				num2 = num;
				continue;
			case 1:
			{
				num = 12601;
				short num3 = num;
				num = 12601;
				switch (num3 == num)
				{
				case false:
				case true:
					break;
				default:
					goto IL_00ff;
				}
				goto case 3;
			}
			case 4:
				num = 0;
				num2 = num;
				continue;
			case 0:
				{
					if (this.m_a != null)
					{
						num = 3;
						num2 = num;
						continue;
					}
					break;
				}
				IL_00ff:
				num = 0;
				if (num == 0)
				{
				}
				break;
			}
			break;
		}
		base.Dispose(disposing);
	}

	private void a()
	{
		short num = 4605;
		short num2 = num;
		num = 4605;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormHardNes));
		this.m_b = new Button();
		c = new Button();
		d = new GroupBox();
		g = new RadioButton();
		h = new RadioButton();
		i = new Label();
		j = new Label();
		r = new TextBox();
		k = new TextBox();
		e = new Label();
		f = new Label();
		l = new RadioButton();
		m = new RadioButton();
		n = new Label();
		o = new Label();
		p = new GroupBox();
		s = new CheckBox();
		q = new TextBox();
		t = new TableLayoutPanel();
		u = new TableLayoutPanel();
		v = new TableLayoutPanel();
		w = new TableLayoutPanel();
		x = new TableLayoutPanel();
		y = new FlowLayoutPanel();
		d.SuspendLayout();
		p.SuspendLayout();
		t.SuspendLayout();
		u.SuspendLayout();
		v.SuspendLayout();
		w.SuspendLayout();
		x.SuspendLayout();
		y.SuspendLayout();
		SuspendLayout();
		componentResourceManager.ApplyResources(this.m_b, "button1");
		this.m_b.Name = "button1";
		this.m_b.UseVisualStyleBackColor = true;
		this.m_b.Click += a;
		componentResourceManager.ApplyResources(c, "button2");
		c.DialogResult = DialogResult.Cancel;
		c.Name = "button2";
		c.UseVisualStyleBackColor = true;
		c.Click += b;
		componentResourceManager.ApplyResources(d, "groupBox1");
		d.Controls.Add(t);
		d.Name = "groupBox1";
		d.TabStop = false;
		componentResourceManager.ApplyResources(g, "radioKey1B");
		g.Name = "radioKey1B";
		g.UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(h, "radioKey1A");
		h.Checked = true;
		h.Name = "radioKey1A";
		h.TabStop = true;
		h.UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(i, "label4");
		i.Name = "label4";
		componentResourceManager.ApplyResources(j, "label3");
		j.Name = "label3";
		componentResourceManager.ApplyResources(r, "sector1");
		r.Name = "sector1";
		componentResourceManager.ApplyResources(k, "keyEdit");
		k.Name = "keyEdit";
		componentResourceManager.ApplyResources(e, "label2");
		e.Name = "label2";
		componentResourceManager.ApplyResources(f, "label1");
		f.ForeColor = Color.Blue;
		f.Name = "label1";
		componentResourceManager.ApplyResources(l, "radioKey2B");
		l.Name = "radioKey2B";
		l.UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(m, "radioKey2A");
		m.Checked = true;
		m.Name = "radioKey2A";
		m.TabStop = true;
		m.UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(n, "label5");
		n.Name = "label5";
		componentResourceManager.ApplyResources(o, "label6");
		o.Name = "label6";
		componentResourceManager.ApplyResources(p, "groupBox2");
		p.Controls.Add(w);
		p.Name = "groupBox2";
		p.TabStop = false;
		componentResourceManager.ApplyResources(s, "checkBoxColOnly");
		s.Name = "checkBoxColOnly";
		s.UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(q, "sector2");
		q.Name = "sector2";
		componentResourceManager.ApplyResources(t, "tableLayoutPanel1");
		t.Controls.Add(g, 3, 1);
		t.Controls.Add(e, 0, 0);
		t.Controls.Add(h, 2, 1);
		t.Controls.Add(k, 0, 1);
		t.Controls.Add(i, 2, 0);
		t.Controls.Add(j, 1, 0);
		t.Controls.Add(r, 1, 1);
		t.Name = "tableLayoutPanel1";
		componentResourceManager.ApplyResources(u, "tableLayoutPanel2");
		u.Controls.Add(l, 3, 1);
		u.Controls.Add(m, 2, 1);
		u.Controls.Add(o, 1, 0);
		u.Controls.Add(n, 2, 0);
		u.Controls.Add(q, 1, 1);
		u.Name = "tableLayoutPanel2";
		componentResourceManager.ApplyResources(v, "tableLayoutPanel3");
		v.Controls.Add(d, 0, 0);
		v.Controls.Add(y, 0, 2);
		v.Controls.Add(p, 0, 1);
		v.Name = "tableLayoutPanel3";
		componentResourceManager.ApplyResources(w, "tableLayoutPanel4");
		w.Controls.Add(u, 1, 0);
		w.Controls.Add(s, 0, 0);
		w.Name = "tableLayoutPanel4";
		componentResourceManager.ApplyResources(x, "tableLayoutPanel5");
		x.Controls.Add(c, 0, 0);
		x.Controls.Add(this.m_b, 1, 0);
		x.Name = "tableLayoutPanel5";
		componentResourceManager.ApplyResources(y, "flowLayoutPanel1");
		y.Controls.Add(f);
		y.Controls.Add(x);
		y.Name = "flowLayoutPanel1";
		base.AcceptButton = this.m_b;
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = c;
		base.ControlBox = false;
		base.Controls.Add(v);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormHardNes";
		d.ResumeLayout(performLayout: false);
		d.PerformLayout();
		p.ResumeLayout(performLayout: false);
		p.PerformLayout();
		t.ResumeLayout(performLayout: false);
		t.PerformLayout();
		u.ResumeLayout(performLayout: false);
		u.PerformLayout();
		v.ResumeLayout(performLayout: false);
		v.PerformLayout();
		w.ResumeLayout(performLayout: false);
		w.PerformLayout();
		x.ResumeLayout(performLayout: false);
		x.PerformLayout();
		y.ResumeLayout(performLayout: false);
		y.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
