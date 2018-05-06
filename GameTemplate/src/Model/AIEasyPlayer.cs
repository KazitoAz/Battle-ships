using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;


	/// <summary>
	/// The AIEasyPlayer is a type of AIPlayer where it will only do total random shooting
	/// </summary>
	public class AIEasyPlayer : AIPlayer
	{
		public AIEasyPlayer(BattleShipsGame controller) : base(controller)
		{
		}

		/// <summary>
		/// GenerateCoordinates will randomly generate shots within the grid as long as its not hit that tile already
		/// </summary>
		/// <param name="row">the generated row</param>
		/// <param name="column">the generated column</param>
		protected override void GenerateCoords(ref int row, ref int column)
		{
			_Random = new Random();
			row = _Random.Next(0, EnemyGrid.Height);
			column = _Random.Next(0, EnemyGrid.Width);
		}

		/// <summary>
		/// ProcessShot will be called uppon when a ship is found.
		/// As it is easy AI. There will be no process after shot
		/// </summary>
		/// <param name="row">the row it needs to process</param>
		/// <param name="col">the column it needs to process</param>
		/// <param name="result">the result og the last shot (should be hit)</param>

		protected override void ProcessShot(int row, int col, AttackResult result)
		{
		}
	}

