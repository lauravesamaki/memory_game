using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace memory_game
{
	public partial class Form1 : Form
	{
		public Random random = new Random();

		public Form1()
		{
			InitializeComponent();
		}

		//list of numbers to be shuffled
		List<string> numbers = new List<string>()
		{
			"1", "1", "2", "2", "3", "3", "4", "4", "5", "5",
			"6", "6", "7", "7", "8", "8"
		};

		//list of buttons
		List<Button> buttons = new List<Button>();

		//list of clicked buttons
		List<Button> clickedButtons = new List<Button>();

		//click event for all buttons
		private void button_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			button.BackColor = Color.White;
			button.Enabled = false;

			if (clickedButtons.Count < 2)
			{
				clickedButtons.Add(button);

				if (clickedButtons.Count == 2)
				{
					//disable all other buttons
					foreach (Button b in buttons)
					{
						if (b != clickedButtons[0] && b != clickedButtons[1])
						{
							b.Enabled = false;
						}
					}

					if (clickedButtons[0].Text == clickedButtons[1].Text)
					{
						clickedButtons[0].BackColor = Color.Green;
						clickedButtons[1].BackColor = Color.Green;

						foreach (Button b in buttons)
						{
							if (b != clickedButtons[0] && b != clickedButtons[1])
							{
								b.Enabled = true;
							}
						}

						clickedButtons.Clear();
					}
					else
					{
						System.Timers.Timer timer = new System.Timers.Timer();
						timer.Interval = 1000;
						timer.Start();

						timer.Elapsed += (s, args) =>
						{
							clickedButtons[0].BackColor = Color.Black;
							clickedButtons[1].BackColor = Color.Black;
							clickedButtons[0].Enabled = true;
							clickedButtons[1].Enabled = true;

							foreach (Button b in buttons)
							{
								if (b != clickedButtons[0] && b != clickedButtons[1])
								{
									b.Enabled = true;
								}
							}

							clickedButtons.Clear();
							timer.Stop();
						};
					}
				}
			}
		}

		//button to start the game
		private void btnStartGame_Click(object sender, EventArgs e)
		{
			List<string> newOrderNumbers = new List<string>();

			for (int i = 0; i < numbers.Count; i++)
			{
				int index = random.Next(numbers.Count);
				
				//check if the number is already in the list twice
				if (newOrderNumbers.Count(x => x == numbers[index]) < 2)
				{
					newOrderNumbers.Add(numbers[index]);
				}
				else
				{
					i--;
				}
			}

			//find all buttons where text starts with "button" and add them to the list
			buttons = this.Controls.OfType<Button>().Where(x => x.Name.StartsWith("button")).ToList();

			for (int i = 0; i < buttons.Count; i++)
			{
				buttons[i].Text = newOrderNumbers[i];
				buttons[i].Enabled = true;
			}

			//add click event to all buttons
			foreach (Button b in buttons)
			{
				b.Click += button_Click;
			}

			//start timer
			timer1.Start();
		}

		//buttons for the numbers
		private void button1_Click(object sender, EventArgs e)
		{			
		}

		private void button2_Click(object sender, EventArgs e)
		{			
		}

		private void button3_Click(object sender, EventArgs e)
		{
		}

		private void button4_Click(object sender, EventArgs e)
		{
		}

		private void button5_Click(object sender, EventArgs e)
		{
		}

		private void button6_Click(object sender, EventArgs e)
		{
		}

		private void button7_Click(object sender, EventArgs e)
		{
		}

		private void button8_Click(object sender, EventArgs e)
		{
		}

		private void button9_Click(object sender, EventArgs e)
		{
		}

		private void button10_Click(object sender, EventArgs e)
		{
		}

		private void button11_Click(object sender, EventArgs e)
		{
		}

		private void button12_Click(object sender, EventArgs e)
		{
		}

		private void button13_Click(object sender, EventArgs e)
		{
		}

		private void button14_Click(object sender, EventArgs e)
		{
		}

		private void button15_Click(object sender, EventArgs e)
		{
		}

		private void button16_Click(object sender, EventArgs e)
		{
		}

		//button to start a new game
		private void btnNewGame_Click(object sender, EventArgs e)
		{
			//clear all buttons
			foreach (Button button in buttons)
			{
				button.Text = "";
				button.BackColor = Color.Black;
				button.Enabled = false;
			}
			time = 0;
			lblTimer.Text = "Time: 0 s";
		}

		public int time { get; private set; }

		//timer to count the time
		private void timer1_Tick(object sender, EventArgs e)
		{
			time++;

			int seconds = time / 10;
			lblTimer.Text = "Time: " + seconds.ToString() + " s";
		}

		//button to stop the timer
		private void btnStop_Click(object sender, EventArgs e)
		{
			//stop timer
			timer1.Stop();
		}
	}
}
