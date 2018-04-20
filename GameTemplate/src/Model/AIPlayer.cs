using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace MyGame
{
    public abstract class AIPlayer
    {
        protected class Location
        {
            private int _Row;
            private int _Column;

            public int Row
            {
                get
                {
                    return _Row;
                }
                set
                {
                    _Row = value;
                }
            }

            public int Column
            {
                get
                {
                    return _Column;
                }
                set
                {
                    _Column = value;
                }
            }

            public Location(int row, int column)
            {
                _Column = column;
                _Row = row;
            }

            public AIPlayer(int row, int column)
            {
                _Column = column;
                _Row = row;
            }
        }





        public AIPlayer(BattleShipsGame game) : base(game)
        {
        }

        protected override void GenerateCoords(ref int row, ref int column)
        {
        }


        protected override void ProcessShot(int row, int col, AttackResult result)
        {
        }


        public override AttackResult Attack()
        {
            AttackResult result;
            int row = 0;
            int column = 0;
            for (
            ; ((result.Value != ResultOfAttack.Miss)
                        && ((result.Value != ResultOfAttack.GameOver)
                        && !SwinGame.WindowCloseRequested));
            )
            {
                Delay();
                GenerateCoords(row, column);
                // generate coordinates for shot
                result = _game.Shoot(row, column);
                // take shot
                ProcessShot(row, column, result);
            }

            return result;
        }

        private void Delay()
        {
            int i;
            for (i = 0; (i <= 150); i++)
            {
                // Dont delay if window is closed
                if (SwinGame.WindowCloseRequested)
                {
                    return SwinGame.Delay(5);
                }

                SwinGame.ProcessEvents();
                SwinGame.RefreshScreen();
            }

        }
    }
}
