using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawfisSoftware.TicTacToeFramework
{
    public class PlayerConsoleUnsafe : IPlayer
    {
        private readonly CellState playerMark;
        private readonly IGameBoard<int, CellState> gameBoard;

        public PlayerConsoleUnsafe(CellState playerMark, IGameBoard<int,CellState> gameBoard)
        {
            this.playerMark = playerMark;
            this.gameBoard = gameBoard;
        }

        public void TakeTurn()
        {
            bool goBack = true;
            while (goBack)
            {
                Console.Write("Player {0}'s turn. Enter cellID (1-9):  ", playerMark);
                var input = Console.ReadLine();
                int cellID = int.Parse(input) - 1;
                if (cellID < 0 || cellID > 8)
                {
                    Console.WriteLine("The value you entered is either too low or too high, please enter again");
                }
                else
                {
                    gameBoard.ChangeCellAttempt(cellID, playerMark);
                    goBack = false;
                }
            }
        }
    }
}
