using SeaBattle.Domain.Entities;
using SeaBattle.Domain.Exceptions.ShipExceptions;
using SeaBattle.Domain.VewInterfaces;

namespace SeaBattle.Domain.Tests.ShipTests
{
    public class ShipTests
    {
        [Fact]
        public void Ship_CreateShipWithoutCoordinats()
        {
            var ship = new Ship(1);

            var expected = new List<Cell> { Cell.Empty };
            var actual = ship.Cells;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ship_ShipWithoutCoordinatsCallIsDestroyed()
        {
            var ship = new Ship(1);

            var expected = false;
            var actual = ship.isDestroyed;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ship_ShipWithoutCoordinatsCheckSize()
        {
            var ship = new Ship(1);

            var expected = 1;
            var actual = ship.Size;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ship_CreateShipWithoutCoordinatesAndNotCorrectSize()
        {
            Assert.Throws<NotCorrectShipSizeException>(() => new Ship(5));
        }

        [Fact]
        public void Ship_CreateShipWithNotCorrectCoordinates()
        {
            var cells = new List<ICell>
            {
                new Cell(1, 1),
                new Cell(1, 2),
                new Cell(1, 4)
            };

            Assert.Throws<NotCorrectShipPositionException>(() => new Ship(cells));
        }

        [Fact]
        public void Ship_CreateShipWithNotCorrectCoordinates2()
        {
            var cells = new List<ICell>
            {
                new Cell(1, 1),
                new Cell(2, 1),
                new Cell(4, 1)
            };

            Assert.Throws<NotCorrectShipPositionException>(() => new Ship(cells));
        }

        [Fact]
        public void Ship_CreateShipWithNotCorrectSize()
        {
            var cells = new List<ICell>
            {
                new Cell(1, 1),
                new Cell(1, 2),
                new Cell(1, 3),
                new Cell(1, 4),
                new Cell(1, 5),
            };

            Assert.Throws<NotCorrectShipSizeException>(() => new Ship(cells));
        }

        [Fact]
        public void Ship_CreateShipWithNotCorrectSize2()
        {
            var cells = new List<ICell>();

            Assert.Throws<NotCorrectShipSizeException>(() => new Ship(cells));
        }

        [Fact]  
        public void Ship_IsItShipCoordinate()
        {
            var cells = new List<ICell>
            {
                new Cell(1, 1),
                new Cell(1, 2),
                new Cell(1, 3),
                new Cell(1, 4),
            };

            var ship = new Ship(cells);

            var expected = true;
            var actual = ship.IsItShipCoordinate(new Cell(1, 1));

            Assert.Equal(expected, actual);
        }
    }
}
