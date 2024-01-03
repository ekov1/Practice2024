namespace TicTacToe.Tests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void TestSymbolWorksCorrectly()
        {
            var board = new Board(3, 3);

            board.PlaceSymbol(new Index(1, 1), Symbol.X);
            Assert.That(board.BoardState[1,1], Is.EqualTo(Symbol.X));
        }

        [Test]
        public void IsFullShouldReturnTrueForFullBoard()
        {
            var board = new Board(3, 3);
            Assert.IsFalse(board.IsFull());


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.IsFalse(board.IsFull());
                    board.PlaceSymbol(new Index(i, j), Symbol.X);
                }
            }

            Assert.IsTrue(board.IsFull());
        }

        [TestCase(Symbol.X)]
        [TestCase(Symbol.O)]
        public void GetRowSymbolShouldWorkCorrectly(Symbol symbol)
        {
            var board = new Board(4, 4);

            for (int i = 0; i < board.Columns; i++)
            {
                Assert.That(board.GetRowSymbol(2), Is.EqualTo(Symbol.None));
                board.PlaceSymbol(new Index(2, i), symbol);
            }

            Assert.That(board.GetRowSymbol(2), Is.EqualTo(symbol));
        }

        [TestCase(Symbol.X)]
        [TestCase(Symbol.O)]
        public void GetColumnSymbolShouldWorkCorrectly(Symbol symbol)
        {
            var board = new Board(4, 4);

            for (int i = 0; i < board.Rows; i++)
            {
                Assert.That(board.GetColumnSymbol(2), Is.EqualTo(Symbol.None));
                board.PlaceSymbol(new Index(i, 2), symbol);
            }

            Assert.That(board.GetColumnSymbol(2), Is.EqualTo(symbol));
        }

        [Test]
        public void GetEmptyPositionsShouldReturnAllPositionsForEmptyBoard()
        {
            var board = new Board(3, 3);
            var positions = board.GetEmptyPositions();
            Assert.That(positions.Count(), Is.EqualTo(3*3));
        }

        [Test]
        public void GetEmptyPositionsShouldReturnCorrectNumberOfPositions()
        {
            var board = new Board(3, 3);

            for (int i = 0; i < board.Rows; i++)
            {
                Assert.That(board.GetColumnSymbol(2), Is.EqualTo(Symbol.None));
                board.PlaceSymbol(new Index(i, 2), Symbol.X);
            }

            var positions = board.GetEmptyPositions();

            Assert.That(positions.Count(), Is.EqualTo(6));
        }
    }
}
