﻿namespace TicTacToe.Players
{
    public class RandomPlayer : IPlayer
    {
        private Random random;

        public RandomPlayer()
        {
            random = new Random();
        }

        public Index Play(Board board, Symbol symbol)
        {
            var availablePositions = board.GetEmptyPositions().ToList();
            return availablePositions[random.Next(0, availablePositions.Count)];
        }
    }
}
