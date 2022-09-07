using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Summer_Practice
{
	public partial class Form1 : Form
	{
		Map MAP = new Map();
		PictureBox[,] space = new PictureBox[Map.Width, Map.Height];
		public Form1()
		{
			InitializeComponent();

			for (int i = 0; i < Map.Width; i++)
			{
				for (int j = 0; j < Map.Height; j++)
				{
					space[i, j] = new PictureBox();
					space[i, j].Size = new System.Drawing.Size(58, 36);
					space[i, j].Location = new System.Drawing.Point(i * 58 + 195, j * 36 + 20);
					space[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
					space[i, j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
					space[i, j].Tag = i * 20 + j;
					space[i, j].BackColor = System.Drawing.SystemColors.ControlLightLight;
					space[i, j].MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
					space[i, j].MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
					space[i, j].BackColor = Color.Green;
					this.Controls.Add(space[i, j]);
				}
			}
			SpawnAnimals();
			Refresh();
		}
		public void Refresh() //���������� �������� ���� � ����� ��� �� �����
		{
			int count = 0; //����� ���-�� ������ � ������
			int[] type = { 0, 0, 0, 0 }; //���� ��������: ����, ��������, ������, ����������
			for (int i = 0; i < Map.Width; i++)
			{
				for (int j = 0; j < Map.Height; j++)
				{
					for (int k = 0; k < 4; k++) //��������� ��������� ����������
						type[k] = 0;
					count = 0;
					foreach (Animal animal in MAP.animalsList) //���� �� ������ ��������
					{
						if (animal.coordX == i && animal.coordY == j) //���� ���������� ��������� � ������ ���������
						{
							if (animal.GetType() == typeof(Rabbit)) //���� �������� - ��� ������
							{
								if (animal.age <= MAP.RabbitIsAdult) //���� ��� ����������
								{
									type[3]++;
									count++;
									continue;
								}
								type[2]++; //���� ��� ������
								count++;
							}
							else if (animal.GetType() == typeof(Wolf) || animal.GetType() == typeof(Shewolf)) //���� �������� - ��� ���� ��� �������
							{
								if (animal.age <= MAP.WolfIsAdult) //���� ��� ��������
								{
									type[1]++;
									count++;
									continue;
								}
								type[0]++; //���� ��� ����
								count++;
							}
						}
					}
					if (count > 0) //���� � ������ ���� ��������, ���������� �������� ��� ����������� � ������
					{
						if ((type[0] > 0 || type[1] > 0) && (type[2] > 0 || type[3] > 0)) //���� � ������ ������ ��������
						{
							space[i, j].Image = global::Summer_Practice.Properties.Resources.wolf_and_rabbit;
							continue;
						}
						else if (type[0] > 0) //���� � ������ ����� � �������� �������
						{
							space[i, j].Image = global::Summer_Practice.Properties.Resources.wolf;
							continue;
						}
						else if (type[1] > 0) //���� � ������ ������ �������
						{
							space[i, j].Image = global::Summer_Practice.Properties.Resources.lil_wolf;
							continue;
						}
						else if (type[2] > 0) //���� � ������ ������� � �������� ���������
						{
							space[i, j].Image = global::Summer_Practice.Properties.Resources.rabbit;
							continue;
						}
						else //���� � ������ ������ ���������
						{
							space[i, j].Image = global::Summer_Practice.Properties.Resources.lil_rabbit;
							continue;
						}
					}
					else
						space[i, j].Image = null; //���� � ������ ��� ��������, ��� ������������ ������
				}
			}
			//����� ��� ����� ������ ���������� �������� �� ������� ���� � ���������� ������� ���� �������� ��������
			int rabbits_count = 0, wolves_count = 0, shewolves_count = 0; //�������� ���������� ��� �������� ��������
			count = 0;
			foreach (Animal animal in MAP.animalsList)
			{
				count++; //��������� ����� ���������� ��������
				if (animal.GetType() == typeof(Rabbit)) //���������� ��������
					rabbits_count++;
				if (animal.GetType() == typeof(Wolf)) //���������� ������
					wolves_count++;
				if (animal.GetType() == typeof(Shewolf)) //���������� ������
					shewolves_count++;
			}
			label1.Text = "����� ���������� ��������: " + count + " \n��������: " + rabbits_count
				+ " \n������: " + wolves_count + " \n������: " + shewolves_count; //����� ���������� �� �����
			if (rabbits_count==0|| wolves_count==0|| shewolves_count==0)
			{
				TurningTimer.Enabled = !TurningTimer.Enabled;
			}
		}
		void SpawnAnimals() //��������� ��������
		{
			for (int i = 0; i < MAP.RabbitsStartCount; i++)
			{
				Rabbit t = new Rabbit(random.Next(Map.Height), random.Next(Map.Width)); //�������� ������� ������ "������" �� ���������� ������������
				t.age = MAP.RabbitIsAdult + 1; //���������� ��������
				MAP.animalsList.Add(t); //���������� � ����� ������ ��������
			}
			for (int i = 0; i < MAP.WolvesStartCount; i++)
			{
				Wolf t = new Wolf(random.Next(Map.Height), random.Next(Map.Width)); //�������� ������� ������ "����" �� ���������� ������������
				t.age = MAP.WolfIsAdult + 1; //���������� ��������
				MAP.animalsList.Add(t); //���������� � ����� ������ ��������
			}
			for (int i = 0; i < MAP.ShewolvesStartCount; i++)
			{
				Shewolf t = new Shewolf(random.Next(Map.Width), random.Next(Map.Height)); //�������� ������� ������ "�������" �� ���������� ������������
				t.age = MAP.WolfIsAdult + 1; //���������� ��������
				MAP.animalsList.Add(t); //���������� � ����� ������ ��������
			}
		}
		void Turn()
		{
			MAP.Turn();
			Refresh();
		}
		private void TurnButton_Click(object sender, EventArgs e)
		{
			if (TurningTimer.Enabled)
			{
				TurningTimer.Enabled = false;
			}
			else
			{
				Turn();
			}
		}

		private void StartStopButton_Click(object sender, EventArgs e)
		{
			TurningTimer.Enabled = !TurningTimer.Enabled;
		}

		private void RestartButton_Click(object sender, EventArgs e)
		{
			TurningTimer.Enabled = false;
			MAP.animalsList.Clear();
			SpawnAnimals();
			Refresh();
		}

		private void TurningTimer_Tick(object sender, EventArgs e)
		{
			Turn();
		}
		private void pictureBox_MouseEnter(object sender, EventArgs e)
		{
			if (!TurningTimer.Enabled)
			{
				PictureBox picturebox = sender as PictureBox;
				int x = (int)picturebox.Tag / Map.Height;
				int y = (int)picturebox.Tag % Map.Height;
				string line = "";
				int count = 0;
				foreach (Animal animal in MAP.animalsList)
				{
					if (animal.coordX == x && animal.coordY == y)
					{
						count++;
						if (animal.GetType() == typeof(Rabbit))
						{
							Rabbit? rabbit = animal as Rabbit;
							line += "  ������       �������: " + rabbit.age + "\n";
						}
						if (animal.GetType() == typeof(Wolf))
						{
							Wolf wolf = animal as Wolf;
							line += "  ����       �������: " + wolf.age + "   �������: " + wolf.hunger + "\n";
						}
						if (animal.GetType() == typeof(Shewolf))
						{
							Shewolf shewolf = animal as Shewolf;
							if (shewolf.pregnancy > 0)
								line += "  �������       �������: " + shewolf.age + "   �������: " + shewolf.hunger + "   ������������: " + shewolf.pregnancy + "\n";
							else
								line += "  �������       �������: " + shewolf.age + "   �������: " + shewolf.hunger + "   �� ���������" + "\n";
						}
					}
				}
				if (count == 0)
					toolTip1.SetToolTip(space[x, y], "� ���� ������ ��� ��������");
				else
					toolTip1.SetToolTip(space[x, y], "����� �������� � ������: " + count + " \n" + line);
			}
		}
		private void pictureBox_MouseClick(object sender, MouseEventArgs e)
		{
			PictureBox picturebox = sender as PictureBox;
			int x = (int)picturebox.Tag / Map.Height;
			int y = (int)picturebox.Tag % Map.Height;

			if (e.Button == MouseButtons.Left)
			{
				Rabbit t = new Rabbit(x, y);
				t.age = MAP.RabbitIsAdult + 1;
				MAP.animalsList.Add(t);
				Refresh();
			}
			else if (e.Button == MouseButtons.Right)
			{
				if (random.Next(2) == 0) //����� ���� ��������
				{
					Wolf t = new Wolf(x, y);
					t.age = MAP.WolfIsAdult + 1;
					MAP.animalsList.Add(t);
					Refresh();
				}
				else
				{
					Shewolf t = new Shewolf(x, y);
					t.age = MAP.WolfIsAdult + 1;
					MAP.animalsList.Add(t);
					Refresh();
				}
			}
		}

		//private void SettingsButton_Click(object sender, EventArgs e)
		//{
		//	TurningTimer.Enabled = false;
		//	Settings form = new Settings();
		//	form.textBox1.Text = MAP.RabbitsStartCount.ToString();
		//	form.textBox2.Text = MAP.WolvesStartCount.ToString();
		//	form.textBox3.Text = MAP.ShewolvesStartCount.ToString();
		//	form.textBox4.Text = MAP.RabbitIsAdult.ToString();
		//	form.textBox5.Text = MAP.WolfIsAdult.ToString();
		//	form.textBox6.Text = MAP.RabbitsDeath.ToString();
		//	form.textBox7.Text = MAP.WolvesDeath.ToString();
		//	if (form.ShowDialog() == DialogResult.OK)
		//	{
		//		try
		//		{
		//			MAP.RabbitsStartCount = int.Parse(form.textBox1.Text);
		//			MAP.WolvesStartCount = int.Parse(form.textBox2.Text);
		//			MAP.ShewolvesStartCount = int.Parse(form.textBox3.Text);
		//			MAP.RabbitIsAdult = int.Parse(form.textBox4.Text);
		//			MAP.WolfIsAdult = int.Parse(form.textBox5.Text);
		//			MAP.RabbitsDeath = int.Parse(form.textBox6.Text);
		//			MAP.WolvesDeath = int.Parse(form.textBox7.Text);

		//			RestartButton_Click(sender, e);
		//		}
		//		catch (Exception er)
		//		{
		//			MessageBox.Show(er.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
		//		}
		//	}
		//}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			TurningTimer.Enabled = !TurningTimer.Enabled;

		}





        //private void button2_Click(object sender, EventArgs e)
        //{
        //	TurningTimer.Enabled = false;
        //	Settings form = new Settings();
        //	form.textBox1.Text = MAP.RabbitsStartCount.ToString();
        //	form.textBox2.Text = MAP.WolvesStartCount.ToString();
        //	form.textBox3.Text = MAP.ShewolvesStartCount.ToString();
        //	form.textBox4.Text = MAP.RabbitIsAdult.ToString();
        //	form.textBox5.Text = MAP.WolfIsAdult.ToString();
        //	form.textBox6.Text = MAP.RabbitsDeath.ToString();
        //	form.textBox7.Text = MAP.WolvesDeath.ToString();
        //	if (form.ShowDialog() == DialogResult.OK)
        //	{
        //		try
        //		{
        //			MAP.RabbitsStartCount = int.Parse(form.textBox1.Text);
        //			MAP.WolvesStartCount = int.Parse(form.textBox2.Text);
        //			MAP.ShewolvesStartCount = int.Parse(form.textBox3.Text);
        //			MAP.RabbitIsAdult = int.Parse(form.textBox4.Text);
        //			MAP.WolfIsAdult = int.Parse(form.textBox5.Text);
        //			MAP.RabbitsDeath = int.Parse(form.textBox6.Text);
        //			MAP.WolvesDeath = int.Parse(form.textBox7.Text);

        //			RestartButton_Click(sender, e);
        //		}
        //		catch (Exception er)
        //		{
        //			MessageBox.Show(er.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //		}
        //	}

        //}
    }
}