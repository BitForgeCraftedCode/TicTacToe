using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Program
    {
        static char[,] gamePieces =
           {
                {'1','2','3' },
                {'4','5','6' },
                {'7','8','9' }
           };

        static char[,] originalPieces =
           {
                {'1','2','3' },
                {'4','5','6' },
                {'7','8','9' }
           };
        static int count = 0;
        static bool winner = false;
        public static void Main(string[] args)
        {
            
            int player = 1;    
            UserDirections();

            SetUpBoard(gamePieces);
            while (winner == false)
            {
                if (player == 1)
                {
                    Console.WriteLine("Player 1 Pick your tile");
                    //get player postion/choice
                    char position1 = GetPlayerPosition();
                    //check if tile/position has already been selected
                    bool tileOpen = CheckPosition(position1);
                    if (tileOpen)
                    {
                        //update game pieces
                        UpdateGamePieces(position1, gamePieces, player);
                        //update board
                        SetUpBoard(gamePieces);
                        //switch players
                        player = 2;
                        //check for win and display message
                        string checkWinner = CheckWinner(gamePieces);
                        WinnerMessage(checkWinner);                     
                    }
                    else
                    {
                        Console.WriteLine("Tile already selected please pick another space");
                        player = 1;
                    }
                }
                else if (player == 2)
                {
                    Console.WriteLine("Player 2 Pick your tile");
                    char position2 = GetPlayerPosition();
                    bool tileOpen = CheckPosition(position2);
                    if (tileOpen)
                    {                    
                        //update game pieces
                        UpdateGamePieces(position2, gamePieces, player);
                        //update board
                        SetUpBoard(gamePieces);
                        //switch players
                        player = 1;
                        //check for win and display message
                        string checkWinner = CheckWinner(gamePieces);
                        WinnerMessage(checkWinner);
                    }
                    else
                    {
                        Console.WriteLine("Tile already selected please pick another space");
                        player = 2;
                    }    
                }
            }
        }
        public static void PlayAgain()
        {
            //play again if yes reset tile board, count and winner vars. reset up board
            Console.WriteLine("Would you like to play again? Enter y for yes or press any other key to quit.");
            char playAgain = Console.ReadKey(true).KeyChar;
            if (playAgain == 'y')
            {
                gamePieces = originalPieces;
                winner = false;
                count = 0;
                SetUpBoard(gamePieces);
            }
            else
            {
                winner = true;
            }
        }
        public static void WinnerMessage(string checkWinner)
        {
            if (checkWinner == "player1")
            {
                Console.WriteLine("Player 1 has won the game");
                PlayAgain();
            }
            else if (checkWinner == "player2")
            {
                Console.WriteLine("Player2 has won the game");
                PlayAgain();
            }
            else if (checkWinner == "draw")
            {
                Console.WriteLine("Draw - No Winners");
                PlayAgain();
            }
        }
        public static string CheckWinner(char[,] gamePieces)
        {
            char[] playerChars = { 'X', 'O' };
            foreach (char c in playerChars)
            {       
                    //all accross
                if (((gamePieces[0, 0] == c) && (gamePieces[0, 1] == c) && (gamePieces[0, 2] == c))
                    || ((gamePieces[1, 0] == c) && (gamePieces[1, 1] == c) && (gamePieces[1, 2] == c))
                    || ((gamePieces[2, 0] == c) && (gamePieces[2, 1] == c) && (gamePieces[2, 2] == c))
                    //all down
                    || ((gamePieces[0, 0] == c) && (gamePieces[1, 0] == c) && (gamePieces[2, 0] == c))
                    || ((gamePieces[0, 1] == c) && (gamePieces[1, 1] == c) && (gamePieces[2, 1] == c))
                    || ((gamePieces[0, 2] == c) && (gamePieces[1, 2] == c) && (gamePieces[2, 2] == c))
                    //all diagonal
                    || ((gamePieces[0, 0] == c) && (gamePieces[1, 1] == c) && (gamePieces[2, 2] == c))
                    || ((gamePieces[0, 2] == c) && (gamePieces[1, 1] == c) && (gamePieces[2, 0] == c))
                   )
                {
                   if(c == 'O')
                    {
                        return "player1";
                    }
                   else
                    {
                        return "player2";
                    }
                }
                
            }
            //count 9 + 1 = 10 is a draw. 1 is the initial SetUpBoard call before players pick tiles
            if (count == 10)
            {
                return "draw";
            }
            return "noWin";
        }
        public static void UserDirections()
        {
            Console.WriteLine("Players input the number corresponding to where you would like to place your X or O.");
            Console.WriteLine("Player One = O");
            Console.WriteLine("Player Two = X");
            Console.WriteLine("________________________________");
            Console.WriteLine("Press any key to start the game.");
            Console.ReadKey();
        }
        public static void SetUpBoard(char[,] gamePieces)
        {
            //clear each time or else each board will be on screen
            Console.Clear();
            Console.WriteLine("Players input the number corresponding to where you would like to place your X or O.");
            Console.WriteLine("Player One = O");
            Console.WriteLine("Player Two = X");
            Console.WriteLine("__________________________");
            Console.WriteLine("|      |        |        |");
            Console.WriteLine("|  {0}   |   {1}    |    {2}   |", gamePieces[0, 0], gamePieces[0, 1], gamePieces[0, 2]);
            Console.WriteLine("|______|________|________|");
            Console.WriteLine("|      |        |        |");
            Console.WriteLine("|  {0}   |   {1}    |    {2}   |", gamePieces[1, 0], gamePieces[1, 1], gamePieces[1, 2]);
            Console.WriteLine("|______|________|________|");
            Console.WriteLine("|      |        |        |");
            Console.WriteLine("|  {0}   |   {1}    |    {2}   |", gamePieces[2, 0], gamePieces[2, 1], gamePieces[2, 2]);
            Console.WriteLine("|______|________|________|");
            //count 9 + 1 = 10 is a draw. 1 is the initial SetUpBoard call before players pick tiles
            count++;
        }
        public static char GetPlayerPosition()
        {
            char position = Console.ReadKey(true).KeyChar;
            return position;
        }
        public static bool CheckPosition(char position)
        {
            if (position == '1' && gamePieces[0,0] == '1')
            {
                return true;
            }
            else if (position == '2' && gamePieces[0,1] == '2')
            {
                return true;
            }
            else if (position == '3' && gamePieces[0, 2] == '3')
            {
                return true;
            }
            else if (position == '4' && gamePieces[1, 0] == '4')
            {
                return true;
            }
            else if (position == '5' && gamePieces[1, 1] == '5')
            {
                return true;
            }
            else if (position == '6' && gamePieces[1, 2] == '6')
            {
                return true;
            }
            else if (position == '7' && gamePieces[2, 0] == '7')
            {
                return true;
            }
            else if (position == '8' && gamePieces[2, 1] == '8')
            {
                return true;
            }
            else if (position == '9' && gamePieces[2, 2] == '9')
            {
                return true;
            }
            else
            {
                return false;   
            }
        }
        public static void UpdateGamePieces(char position, char[,] gamePieces, int player)
        {
            for (int i = 0; i < gamePieces.GetLength(0); i++)
            {
                for (int j = 0; j < gamePieces.GetLength(1); j++)
                {
                    if (gamePieces[i, j] == position)
                    {
                        if (player == 1)
                        {
                            gamePieces[i, j] = 'O';
                        }
                        else
                        {
                            gamePieces[i, j] = 'X';
                        }
                    }

                }
            }
        }
    }
}

