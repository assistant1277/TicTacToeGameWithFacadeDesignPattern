using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGameWithFacade.Enums;
using TicTacToeGameWithFacade.Exceptions;
using TicTacToeGameWithFacade.Models;

//Cell class represents single square on board means it keep track of whether it is empty then marked with x or marked with o 
//it also ensures no one can overwrite already marked cell

namespace TicTacToeGameWithFacade.Models
{
    public class Cell
    {
        //keeps track of what mark like x,o,empty is on cell
        public SymbolType Mark { get; private set; }

        public Cell()
        {
            Mark = SymbolType.EMPTY;//start with each cell empty
        }

        public void PlaceMark(SymbolType mark)
        {
            Mark = mark;//place mark x or o in cell
        }
    }
}
