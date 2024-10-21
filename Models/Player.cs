using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGameWithFacade.Enums;
using TicTacToeGameWithFacade.Models;

//player class stores each player name and symbol which is x or o

namespace TicTacToeGameWithFacade.Models
{
    public class Player
    {
        public string Name { get; }
        public SymbolType Mark { get; }

        public Player(string name, SymbolType mark)
        {
            Name = name;//setting player name
            Mark = mark;
        }
    }
}
