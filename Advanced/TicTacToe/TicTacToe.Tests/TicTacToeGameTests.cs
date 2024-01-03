using Moq;
using TicTacToe.Players;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class TicTacToeGameTests
    {
        [Test]
        public void PlayShouldReturnValue()
        {
            var player = new Mock<IPlayer>();
            player.Setup(x => x.Play(It.IsAny<Board>(), It.IsAny<Symbol>()))
                .Returns((Board board) =>
                {
                    return board.GetEmptyPositions().First();
                });


            var game = new TicTacToeGame(player.Object, player.Object);
            var winner = game.Play();
            Assert.IsNotNull(winner);
        }


        [Test]
        public void PlayShouldReturnCorrectWinner()
        {
            var playerOne = new Mock<IPlayer>();
            playerOne.Setup(x => x.Play(It.IsAny<Board>(), It.IsAny<Symbol>()))
                .Returns((Board board, Symbol symbol) =>
                {
                    return board.GetEmptyPositions().First();
                });

            var playerTwo = new Mock<IPlayer>();
            playerTwo.Setup(x => x.Play(It.IsAny<Board>(), It.IsAny<Symbol>()))
                .Returns((Board board, Symbol symbol) =>
                {
                    return board.GetEmptyPositions().First();
                });

            var game = new TicTacToeGame(playerOne.Object, playerTwo.Object);
            var winner = game.Play();
            Assert.That(winner, Is.EqualTo(Symbol.X));
        }
    }
}
