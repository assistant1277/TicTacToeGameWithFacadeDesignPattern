using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGameWithFacade.Enums;

//Board class handles everything related to game board it manages marking cells and
//checking if cell is empty and displaying board to players

namespace TicTacToeGameWithFacade.Models
{
    public class Board
    {
        //list that holds all 9 cells on board
        private readonly List<Cell> _cells;

        public Board()
        {
            _cells = new List<Cell>(new Cell[9]);//initialize board with 9 empty cells
            for (int i = 0; i < 9; i++)
            {
                _cells[i] = new Cell(); //create empty cell for each position
            }
        }

        public bool IsCellEmpty(int index)
        {
            return _cells[index].Mark == SymbolType.EMPTY;//check if cell at this position is empty
        }

        public void MarkCell(int index, SymbolType mark)
        {
            _cells[index].PlaceMark(mark);//mark chosen cell with x or o
        }

        public List<SymbolType> GetMarks()
        {
            return _cells.Select(cell => cell.Mark).ToList();//get list of all marks on board
        }

        public List<string> GetBoardDisplay()
        {
            var display = new List<string>();
            Console.WriteLine();
            for (int i = 0; i < _cells.Count; i++)
            {
                //add current cell mark or its position if it is empty means
                //if cell is empty display cell number means 1-9 as string 
                //if cell is marked with x or o display the mark x or o instead and ToString() convert object to its string format
                display.Add(_cells[i].Mark == SymbolType.EMPTY ? (i + 1).ToString() : _cells[i].Mark.ToString());

                //check if it is end of row
                if ((i + 1) % 3 == 0)
                {
                    display.Add("\n"); //new line after each row
                    if (i < 8) //dont add horizontal line after last row
                    {
                        display.Add("---------\n"); //horizontal line between rows
                    }
                }
                else
                {
                    display.Add(" | "); //separator between cells
                }
            }
            return display;
        }

        public bool IsFull()
        {
            return _cells.All(cell => cell.Mark != SymbolType.EMPTY);//check if all cells are marked means board is full
        }
    }
}
