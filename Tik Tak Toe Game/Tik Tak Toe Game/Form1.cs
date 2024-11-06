using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tik_Tak_Toe_Game
{
    public partial class Form1 : Form
    {


        public enum Player
        {
            X , O
        }


        Player currentPlayer;
        Random r = new Random();
        int playerWinCount = 0;
        int CPUWinCount = 0;
        List<Button> buttons;



        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void CPUmove(object sender, EventArgs e)
        {
            if(buttons.Count > 0 && currentPlayer == Player.O)
            {
                int index = r.Next(buttons.Count);
                buttons[index].Enabled = false;
                currentPlayer = Player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = Color.DarkSalmon;
                buttons.RemoveAt(index);
                CheckGame();
                currentPlayer = Player.X;
                CPUTimer.Stop();

            }
        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            if (currentPlayer == Player.X)
            {
                var button = (Button)sender;

                
                button.Text = currentPlayer.ToString();
                button.Enabled = false;
                button.BackColor = Color.Cyan;
                buttons.Remove(button);
                CheckGame();
                currentPlayer = Player.O;
                CPUTimer.Start();
            }
        }

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void RestartGame()
        {
            buttons = new List<Button> {button1 , button2 , button3 , button4 , button5 , button6 , button7 ,
                button8 , button9 };

            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;


            }

            currentPlayer = Player.X;
        } 


        private void CheckGame()
        {

            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
               || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
               || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
               || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
               || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
               || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
               || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
               || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                CPUTimer.Stop();
                MessageBox.Show("Player Wins", "SONUÇ");
                playerWinCount++;
                label1.Text = "Player Wins: " + playerWinCount;
                RestartGame();
            }



            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
            || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
            || button7.Text == "O" && button9.Text == "O" && button8.Text == "O"
            || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
            || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
            || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
            || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
            || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {

                CPUTimer.Stop();
                MessageBox.Show("CPU Wins", "SONUÇ");
                CPUWinCount++;
                label2.Text = "CPU Wins: " + CPUWinCount;
                RestartGame();

            }

            else if (buttons.Count == 0)
            {
                CPUTimer.Stop();
                MessageBox.Show("BERABERE", "SONUÇ");
                RestartGame();
            }




        }
    }
}
