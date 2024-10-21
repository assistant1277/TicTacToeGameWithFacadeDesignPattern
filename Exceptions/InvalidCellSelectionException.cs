using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGameWithFacade.Exceptions
{
    public class InvalidCellSelectionException:Exception
    {
        public InvalidCellSelectionException(string message) : base(message) { }
    }
}
