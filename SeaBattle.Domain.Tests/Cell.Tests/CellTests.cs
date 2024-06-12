using SeaBattle.Domain.Entities;
using SeaBattle.Domain.Exceptions.CellExceptions;

namespace SeaBattle.Domain.Tests.CellTests
{
    public class CellTests
    {
        [Fact]
        public void Cell_CellEqualsCell()
        {
            var cell = new Cell(1, 1);
            var cell2 = new Cell(1, 1);
                
            var expected = true;
            var actual = cell.Equals(cell2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Cell_CellNotEqualsCell()
        {
            var cell = new Cell(1, 1);
            var cell2 = new Cell(2, 1);

            var expected = false;
            var actual = cell.Equals(cell2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Cell_CellNotEqualsObj()
        {
            var cell = new Cell(1, 1);
            var cell2 = (2, 1);

            var expected = false;
            var actual = cell.Equals(cell2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Cell_CellToString()
        {
            var cell = new Cell(1, 1);

            var expected = "{1; 1}";
            var actual = cell.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Cell_CallEmptyCell()
        {
            var cell = Cell.Empty;

            Assert.Throws<CellEmptyException>(() => cell.X);
        }

        [Fact]
        public void Cell_EmptyCellToString()
        {
            var cell = Cell.Empty;

            var expected = "{Empty}";
            var actual = cell.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Cell_EmptyCellEqualsEmptyCell()
        {
            var cell = Cell.Empty;
            var cell2 = Cell.Empty;

            var expected = true;
            var actual = cell.Equals(cell2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Cell_EmptyCellSetCoordinates()
        {
            var cell = Cell.Empty;
            cell.SetCoordinates(new Cell(1, 2));

            var expected = "{1; 2}";
            var actual = cell.ToString();

            Assert.Equal(expected, actual);
        }
    }
}
