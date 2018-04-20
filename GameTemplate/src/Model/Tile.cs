using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// Tile knows its location on the grid, if it is a ship and if it has been shot before
namespace MyGame
{
    public class Tile
    {
        private readonly int _RowValue;         //the row value of the tile
        private readonly int _ColumnValue;      //the column value of the tile
        private Ship _Ship = null;              //the ship the tile belongs to
        private bool _Shot = false;             //the tile has been shot at

        //Has the tile been shot
        //<value>indicate if the tile has been shot</value>
        //<returns>true if the tile was shot</returns>
        public bool Shot
        {
            get
            {
                return _Shot;
            }
            set
            {
                _Shot = value;
            }
        }

        public int Row => _RowValue;

        public int Column => _ColumnValue;

        public Ship Ship
        {
            get
            {
                return _Ship;
            }
            set
            {
                if (_Ship == null)
                {
                    _Ship = value;
                    if (value != null)
                    {
                        _Ship.AddTile(this);
                    }
                }
                else
                {
                    throw new InvalidOperationException("There is already a ship at [" + Row + ", " + Column + "]");
                }
            }
        }
        // The tile constructor will know where it is on the grid, and is its a ship
        //<param name = "row" > the row on the grid</param>
        //<param name="col">the col on the grid</param>
        //<param name="ship">what ship it is</param>
        public Tile(int row, int col, Ship ship)
        {
            _RowValue = row;
            _ColumnValue = col;
            _Ship = ship;
        }

        public void ClearShip()
        {
            _Ship = null;
        }

        public TileView View
        {
            get
            {
                if (_Ship == null)
                {
                    if (_Shot)
                    {
                        return TileView.Miss;
                    }
                    else
                    {
                        return TileView.Sea;
                    }
                }
                else
                {
                    if ((_Shot))
                    {
                        return TileView.Hit;
                    }
                    else
                    {
                        return TileView.Ship;
                    }
                }
            }
        }
        /*Shoot allows a tile to be shot at, and if the tile has been hit before
        it will give an error*/
        internal void Shoot()
        {
            if ((false == Shot))
            {
                Shot = true;
                if (_Ship != null)
                {
                    _Ship.Hit();
                }
            }
            else
            {
                throw new ApplicationException("You have already shot this square");
            }
        }
    }
}
