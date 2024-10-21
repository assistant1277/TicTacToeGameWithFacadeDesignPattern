using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGameWithFacade.Enums;

//ResultAnalyzer class checks whether someone has won by comparing marks on board
//with possible winning combinations like rows,columns,diagonals

namespace TicTacToeGameWithFacade.Models
{
    public class ResultAnalyzer
    {
        private readonly List<int[]> _winningCombinations; //list of all winning combinations like rows,columns,diagonals

        public ResultAnalyzer()
        {
            //list of arrays where each array represents possible winning combination and
            //eg -> {0,1,2} means if player marks these positions first row they win
            //rows,columns,diagonals are covered as winning possibilities
            _winningCombinations = new List<int[]>
            {
                new[] { 0, 1, 2 },//1st row
                new[] { 3, 4, 5 },//2nd row
                new[] { 6, 7, 8 },//3rd row
                new[] { 0, 3, 6 },//1st column
                new[] { 1, 4, 7 },//2nd colum
                new[] { 2, 5, 8 },//3rd column
                new[] { 0, 4, 8 },//diagonal
                new[] { 2, 4, 6 }//diagonal
            };
        }


        //analyze -> method checks if current player has won
        //'marks' is list of all cell marks on board which are x,o or empty
        //'playerMark' is current player symbol x or o
        //method compares the player marks against winning combinations to see if there is match
        public ResultType Analyze(List<SymbolType> marks, SymbolType playerMark)
        {
            foreach (var combination in _winningCombinations)//check each winning combination
            {
                //if all 3 cells in combination are marked by current player they win
                if (marks[combination[0]] == playerMark &&
                    marks[combination[1]] == playerMark &&
                    marks[combination[2]] == playerMark)
                {
                    return ResultType.WIN;
                }
            }
            //if board is full and no one has won then it is draw means
            //if all cells are filled then it return ResultType.DRAW means tie game
            //if not all cells are filled then it returns ResultType.NONE means game is still ongoing
            return marks.All(mark => mark != SymbolType.EMPTY) ? ResultType.DRAW : ResultType.NONE;
        }
    }
}
