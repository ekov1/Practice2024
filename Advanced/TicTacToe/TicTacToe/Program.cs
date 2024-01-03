using System.Runtime.CompilerServices;
using TicTacToe.Players;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = " TicTacToe";
            while (true)
            {
                Console.Clear();

                Console.WriteLine("==== TicTacToe  1.0 ====");
                Console.WriteLine("1. Player vs Player");
                Console.WriteLine("2. Player vs Random");
                Console.WriteLine("3. Player vs AI");
                Console.WriteLine("4. Random vs Random");
                Console.WriteLine("5. Random vs Random 10000");
                Console.WriteLine("5. Random vs AI 10000");


                while (true)
                {

                    Console.WriteLine("Please enter number [1-5]: ");
                    var line = Console.ReadLine();
                    if (line == "1")
                    {
                        PlayGame(new ConsolePlayer(), new ConsolePlayer());
                        break;
                    }
                    if (line == "2")
                    {
                        PlayGame(new ConsolePlayer(), new RandomPlayer());
                        break;
                    }
                    if (line == "3")
                    {
                        PlayGame(new ConsolePlayer(), new AiPlayer());
                        break;
                    }
                    if (line == "4")
                    {
                        PlayGame(new RandomPlayer(), new RandomPlayer());
                        break;
                    }
                    if (line == "5")
                    {
                        SimulateGame(new RandomPlayer(), new RandomPlayer(),10000);
                        break;
                    }
                    if (line == "6")
                    {
                        SimulateGame(new RandomPlayer(), new AiPlayer(), 1);
                        break;
                    }
                }

                Console.WriteLine("Press [enter] to play again");
                Console.ReadLine();
            }
        }

        static void SimulateGame(IPlayer player1, IPlayer player2, int count)
        {
            int x = 0;
            int o = 0;
            int draw = 0;
            int playerOne = 0;
            int playerTwo = 0;

            var first = player1;
            var second = player2;

            for (int i = 0; i < count; i++)
            {
                var game = new TicTacToeGame(first, second);
                var result = game.Play();

                if (result.Winner == Symbol.X && first == player1) playerOne++;
                if (result.Winner == Symbol.X && first == player2) playerTwo++;

                if (result.Winner == Symbol.O && second == player1) playerOne++;
                if (result.Winner == Symbol.O && second == player2) playerTwo++;

                if (result.Winner == Symbol.X) x++;
                if (result.Winner == Symbol.O) o++;
                if (result.Winner == Symbol.None) draw++;


                (first, second) = (second, first);
            }

            Console.WriteLine($"Games played {count}");
            Console.WriteLine($"Wins X {x}");
            Console.WriteLine($"Wins O {o}");
            Console.WriteLine($"Draws  {draw}");
            Console.WriteLine($"Player one wins {playerOne} {player1.GetType().Name}");
            Console.WriteLine($"Player two wins {playerTwo} {player2.GetType().Name}");

        }


        static void PlayGame(IPlayer playerOne, IPlayer playerTwo)
        {
            var game = new TicTacToeGame(playerOne, playerTwo);
            var result = game.Play();
            Console.WriteLine($"Winner: {result.Winner}");
            Console.WriteLine(result.Board.ToString());
            Console.WriteLine("Game Over!");
        }
    }
}