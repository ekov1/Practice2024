using TicTacToe.Players;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        public TicTacToeGame(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
            GameWinnerLogic = new GameWinnerLogic();
        }

        public IPlayer FirstPlayer { get; set; }
        public IPlayer SecondPlayer { get; set; }
        private GameWinnerLogic GameWinnerLogic { get; }

        public GameResult Play()
        {
            Board board = new Board();
            IPlayer currentPlayer = FirstPlayer;
            Symbol symbol = Symbol.X;

            while (!GameWinnerLogic.IsGameOver(board))
            {
                // Play round
                var move = currentPlayer.Play(board, symbol);
                board.PlaceSymbol(move, symbol);

                if (currentPlayer == FirstPlayer)
                {
                    currentPlayer = SecondPlayer;
                    symbol = Symbol.O;
                }
                else
                {
                    currentPlayer = FirstPlayer;
                    symbol = Symbol.X;
                }
            }

            var winner = GameWinnerLogic.GetWinner(board);

            return new GameResult(winner, board);
        }


    }
}
