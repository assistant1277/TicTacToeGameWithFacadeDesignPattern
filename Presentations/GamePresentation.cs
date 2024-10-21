using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGameWithFacade.Enums;
using TicTacToeGameWithFacade.Exceptions;
using TicTacToeGameWithFacade.Services;

//GamePresentation class handles all interactions with player
//it shows board then ask players for their moves and announces result it also makes sure input is valid

namespace TicTacToeGameWithFacade.Presentations
{
    public class GamePresentation
    {
        private GameService _gameService;

        public static void StartGame()
        {
            Console.WriteLine("***** Welcome to tic tac toe game with Facade *****\n");
            while (true)
            {
                Console.Write("Enter name for player 1 and will get symbol [X]-> ");
                string player1Name = Console.ReadLine();

                Console.Write("Enter name for player 2 and will get symbol [O]-> ");
                string player2Name = Console.ReadLine();

                GamePresentation gameUI = new GamePresentation();//create new instance of GamePresentation
                gameUI._gameService = new GameService(player1Name, player2Name);//initialize game with player names
                gameUI.Run();

                Console.Write("\nDo you want to play again if yes press 'y' if no then 'n' (y/n) -> ");
                string playAgain = Console.ReadLine();
                if (playAgain?.ToLower() != "y") //if answer is not 'y' then break loop and stop game
                {
                    Console.WriteLine("\nThanks for playing");
                    break;
                }
            }
        }

        private void Run()
        {
            while (true)
            {
                DisplayBoard();
                Console.Write($"\n{_gameService.GetCurrentPlayerName()} turn choose cell [1-9] -> ");
                int cellNumber = GetPlayerMove();
                try
                {
                    if (_gameService.PlayTurn(cellNumber))
                    {
                        var gameResult = _gameService.CheckGameStatus();
                        if (gameResult == ResultType.WIN)
                        {
                            Console.WriteLine($"\nCongratulations {_gameService.GetCurrentPlayerName()} win");
                            break; 
                        }
                        else if (gameResult == ResultType.DRAW)
                        {
                            Console.WriteLine("\nIt is draw");
                            break; 
                        }

                        _gameService.SwitchPlayer();
                    }
                }
                catch (InvalidCellSelectionException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            DisplayBoard();
        }

        private void DisplayBoard()
        {
            var boardDisplay = _gameService.GetBoardDisplay(); //get current state of board from GameService
            foreach (var line in boardDisplay)
            {
                Console.Write(line);
            }
        }

        private int GetPlayerMove()
        {
            int choice;

            //int.TryParse -> tries to convert input to integer if successful then stores result in choice then
            //if conversion is successful input is valid number it returns true and converted number is stored in choice using out keyword
            //if conversion fails input is not valid number it returns false
            //out choice -> choice gets converted number if valid and no need to initialize before
            //condition will checks if choice is within range 1 to 9
            //loop here repeats until user enters valid number between 1 and 9
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 9)
            {
                Console.Write("\nInvalid input enter number between 1-9 -> ");
            }
            return choice;
        }
    }
}
