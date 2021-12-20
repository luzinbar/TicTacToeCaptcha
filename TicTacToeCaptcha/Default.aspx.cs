using System;
using System.Web.UI;

namespace TicTacToeCaptcha
{
    public class Move
    {
        public int row, column;
    };

    public partial class _Default : Page
    {
        private const int board_size = 3;
        private static char[,] field = new char[board_size, board_size];
        private static int winner;
        private static int user = 1;
        private static int computer = 2;
        private static char userSign = 'O';
        private static char computerSign = 'X';
        private static String userImg = "";
        private static String computerImg = "";
        private static string[] img_opt = System.IO.File.ReadAllLines(@"C:\Users\inbar\images.txt");
        private static Boolean random = random_img();
        private static int numOfMoves;
        private static int currPressedButton;
        private static int computerSpot;
        //private static int playersSpot;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected static Boolean random_img()
        {
            Random rnd = new Random();
            int user_num = rnd.Next(0, img_opt.Length);
            int comp_num = rnd.Next(0, img_opt.Length);
            while (user_num == comp_num)
                comp_num = rnd.Next(1, img_opt.Length);
            userImg = img_opt[user_num];
            computerImg = img_opt[comp_num];
            return true;
        }
        // --------------- buttons ---------------
        protected void button_click_login(object sender, EventArgs e)
        {
            btn_login.Text = "finished";
        }
        /*
        protected void button_click_test(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.ImageButton btnImg = sender as System.Web.UI.WebControls.ImageButton;
            btnImg.ImageUrl = "https://cdn2.vectorstock.com/i/1000x1000/94/41/cartoon-robot-toy-object-for-small-children-vector-32859441.jpg";
            illegal_input.Text = "";

            currPressedButton = Int32.Parse(btnImg.AlternateText);
            playersSpot = Int32.Parse(btnImg.AlternateText);
            //System.Web.UI.WebControls.Content ct = this.Master.Master.FindControl("MainContent") as System.Web.UI.WebControls.Content;

            //System.Web.UI.WebControls.Button mybutton = ct.FindControl("Button1") as System.Web.UI.WebControls.Button;

            //System.Web.UI.WebControls.Button mybutton = (System.Web.UI.WebControls.Button)myControl1.Parent;
            System.Web.UI.WebControls.Button mybutton = this.FindControl("Button1") as System.Web.UI.WebControls.Button;
            mybutton.Text = "bla";
            playerPlay(sender, e);
        }
        */
        protected void button_click_general(object sender, EventArgs e)
        {
            illegal_input.Text = "";
            System.Web.UI.WebControls.ImageButton btnImg = sender as System.Web.UI.WebControls.ImageButton;
            currPressedButton = Int32.Parse(btnImg.AlternateText);
            playerPlay(sender, e, btnImg);
        }

        // --------------- game ---------------
        protected void playerPlay(object sender, EventArgs e, System.Web.UI.WebControls.ImageButton btnImg)
        {
            if (!Play(user))
            {
                illegal_input.Text = "illegal input";
                return;
            }
            illegal_input.Text = "";
            btnImg.ImageUrl = userImg;
            if (DoWeHaveAWinner())
                btn_login.Text = "log in";
            else
            {
                Play(computer);
                computer_button_to_change(sender, e);
            }
            if (DoWeHaveAWinner())
                btn_login.Text = "log in";
        }

        protected void computer_button_to_change(object sender, EventArgs e)
        {
            switch (computerSpot)
            {
                case 1:
                    imagebutton1.ImageUrl = computerImg;
                    break;
                case 2:
                    imagebutton2.ImageUrl = computerImg;
                    break;
                case 3:
                    imagebutton3.ImageUrl = computerImg;
                    break;
                case 4:
                    imagebutton4.ImageUrl = computerImg;
                    break;
                case 5:
                    imagebutton5.ImageUrl = computerImg;
                    break;
                case 6:
                    imagebutton6.ImageUrl = computerImg;
                    break;
                case 7:
                    imagebutton7.ImageUrl = computerImg;
                    break;
                case 8:
                    imagebutton8.ImageUrl = computerImg;
                    break;
                default: // case 9
                    imagebutton9.ImageUrl = computerImg;
                    break;
            }
        }

        public static bool Play(int player)
        {
            if (player == user)
            {
                int row = (currPressedButton - 1) / board_size;
                int column = (currPressedButton - 1) % board_size;
                if (field[row, column] != userSign && field[row, column] != computerSign) // Check if cell is empty
                    updateField(currPressedButton);
                else
                    return false;
            }
            else // computer's turn
            {
                Move bestMove = findBestMove();
                field[bestMove.row, bestMove.column] = computerSign;
                computerSpot = (bestMove.row * board_size) + bestMove.column + 1;
            }
            numOfMoves++;
            return true;
        }

        public static bool DoWeHaveAWinner()
        {
            return CheckRow() ? true : CheckColumn() ? true : CheckDiagonal() ? true : CheckNumOfMoves() ? true : false;
        }

        public static bool CheckNumOfMoves()
        {
            return numOfMoves == (board_size * board_size);
        }

        public static bool CheckRow()
        {
            for (int i = 0; i < board_size; i++)
            {
                char sign = field[i, 0];
                if (sign != userSign && sign != computerSign)
                    continue;
                if (field[i, 1] == sign && field[i, 2] == sign)
                {
                    winner = sign == userSign ? user : computer;
                    return true;
                }
            }
            return false;
        }

        public static bool CheckColumn()
        {
            for (int i = 0; i < board_size; i++)
            {
                char sign = field[0, i];
                if (sign != userSign && sign != computerSign)
                    continue;
                if (field[1, i] == sign && field[2, i] == sign)
                {
                    winner = sign == userSign ? user : computer;
                    return true;
                }
            }
            return false;
        }

        public static bool CheckDiagonal()
        {
            char sign = field[1, 1];
            if (sign != userSign && sign != computerSign)
                return false;
            if (field[0, 0] == sign && field[2, 2] == sign)
            {
                winner = sign == userSign ? user : computer;
                return true;
            }
            if (field[0, 2] == sign && field[2, 0] == sign)
            {
                winner = sign == userSign ? user : computer;
                return true;
            }
            return false;
        }

        public static void updateField(int spot)
        {
            int row = (spot - 1) / board_size;
            int column = (spot - 1) % board_size;
            field[row, column] = userSign;
        }

        // --------------- computer AI ---------------

        public static Move findBestMove()
        {
            int bestVal = -1000;
            Move bestMove = new Move();
            bestMove.row = -1;
            bestMove.column = -1;

            for (int i = 0; i < board_size; i++)
            {
                for (int j = 0; j < board_size; j++)
                {
                    if (field[i, j] != userSign && field[i, j] != computerSign) // Check if cell is empty
                    {
                        char currSign = field[i, j]; // saves the curr sign
                        field[i, j] = computerSign; // try that move
                        numOfMoves++;
                        int moveVal = minimax(0, false); // compute evaluation function for this move
                        field[i, j] = currSign; // Undo the move
                        numOfMoves--;

                        if (moveVal > bestVal) // updating the value for the best move
                        {
                            bestMove.row = i;
                            bestMove.column = j;
                            bestVal = moveVal;
                        }
                    }
                }
            }
            return bestMove;
        }

        // with minimax alporithem we cheack all the possibole ways to continue the game
        // the function returns the value of the field
        public static int minimax(int depth, Boolean isMax)
        {
            int score = evaluate();

            // if Maximizer has won the game return his evaluated score
            if (score == 10)
                return score;

            // if Minimizer has won the game return his evaluated score
            if (score == -10)
                return score;

            // it's a tie, no more moves to do
            if (CheckNumOfMoves())
                return 0;

            // none of them won yet, there are more moves to do

            // if this maximizer's move
            if (isMax)
            {
                int best = -1000;

                for (int i = 0; i < board_size; i++)
                {
                    for (int j = 0; j < board_size; j++)
                    {
                        if (field[i, j] != userSign && field[i, j] != computerSign) // Check if cell is empty
                        {
                            char currSign = field[i, j]; // saves the curr sign
                            field[i, j] = computerSign; // try that move                        
                            numOfMoves++;
                            best = Math.Max(best, minimax(depth + 1, !isMax)); // chose recursively the maximum value
                            int moveVal = minimax(0, false); // compute evaluation function for this move
                            field[i, j] = currSign; // Undo the move
                            numOfMoves--;
                        }
                    }
                }
                return best;
            }

            // If this minimizer's move
            else
            {
                int best = 1000;

                for (int i = 0; i < board_size; i++)
                {
                    for (int j = 0; j < board_size; j++)
                    {
                        if (field[i, j] != userSign && field[i, j] != computerSign) // Check if cell is empty
                        {
                            char currSign = field[i, j]; // saves the curr sign
                            field[i, j] = userSign; // try that move                        
                            numOfMoves++;
                            best = Math.Min(best, minimax(depth + 1, !isMax)); // chose recursively the manimum value
                            int moveVal = minimax(0, false); // compute evaluation function for this move
                            field[i, j] = currSign; // Undo the move
                            numOfMoves--;
                        }
                    }
                }
                return best;
            }
        }
        public static int evaluate()
        {
            if (CheckColumn())
            {
                if (winner == computer)
                    return +10;
                else
                    return -10;
            }

            if (CheckRow())
            {
                if (winner == computer)
                    return +10;
                else
                    return -10;
            }

            if (CheckDiagonal())
            {
                if (winner == computer)
                    return +10;
                else
                    return -10;
            }
            // if none of the players have won
            return 0;
        }


    }

}