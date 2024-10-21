using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGameWithFacade.Enums;
using TicTacToeGameWithFacade.Exceptions;
using TicTacToeGameWithFacade.Models;

//GameService class is central piece that handles main game logic and it manages board,players,game status

namespace TicTacToeGameWithFacade.Services
{
    public class GameService
    {
        private readonly Board _board;//game board
        private readonly Player _player1; //player 1
        private readonly Player _player2;// player 2
        private readonly ResultAnalyzer _resultAnalyzer; //logic to check if someone has won or if it is draw
        private Player _currentPlayer;//keeps track of whose turn it is

        public GameService(string player1Name, string player2Name)
        {
            _board = new Board();//create new game board
            _resultAnalyzer = new ResultAnalyzer();
            _player1 = new Player(player1Name, SymbolType.X);//assign player 1 their name and x symbol
            _player2 = new Player(player2Name, SymbolType.O);//assign Player 2 their name and o symbol
            _currentPlayer = _player1;//player 1 start game
        }

        public bool PlayTurn(int cellNumber)
        {
            if (!_board.IsCellEmpty(cellNumber - 1))//check if cell is already marked
            {
                throw new InvalidCellSelectionException("\nCell is already occupied try again");
            }

            _board.MarkCell(cellNumber - 1, _currentPlayer.Mark);//mark selected cell with the current player symbol
            return true;//successful move
        }

        public ResultType CheckGameStatus()
        {
            //check if there is winner or draw
            return _resultAnalyzer.Analyze(_board.GetMarks(), _currentPlayer.Mark);
        }

        public void SwitchPlayer()
        {
            //swap between Player 1 and Player 2
            _currentPlayer = _currentPlayer == _player1 ? _player2 : _player1;
        }

        public string GetCurrentPlayerName()
        {
            return _currentPlayer.Name;
        }

        public List<string> GetBoardDisplay()
        {
            //get visual display of board
            return _board.GetBoardDisplay();
        }

        public bool IsBoardFull()
        {
            return _board.IsFull();//check if board is full means no more empty cell
        }
    }
}
