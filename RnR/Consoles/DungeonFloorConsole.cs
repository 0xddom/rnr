using SadConsole.Consoles;
using RnR.World;
using RogueSharp;
using SadConsole;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Lain.Utils;

namespace RnR.Consoles
{
	public class DungeonFloorConsole : SadConsole.Consoles.Console
	{
		DungeonFloor floor;
		int viewWidth;
		int viewHeight;
		CellAppearance[,] drawData;

		public DungeonFloorConsole (DungeonFloor floor, int w, int h) 
			: base(Math.Max(floor.Width, w),Math.Max(floor.Height, h))
		{
			this.viewWidth = Math.Min(floor.Width, w);
			this.viewHeight = Math.Min(floor.Height, h);
			this.floor = floor;

			//System.Console.Write (floor.ToString ());

			drawData = new CellAppearance[floor.Width, floor.Height];

			TextSurface.RenderArea = new Microsoft.Xna.Framework.Rectangle (0, 0, viewWidth, viewHeight);

			DrawMapData ();
		}

		private void DrawMapData() {
			foreach (RogueSharp.Cell cell in floor.GetAllCells()) {
				drawData [cell.X, cell.Y] = GetAppearanceFromCell (cell);
				drawData [cell.X, cell.Y].CopyAppearanceTo (this [cell.X, cell.Y]);
			}
		}

		private CellAppearance GetAppearanceFromCell(RogueSharp.Cell cell) {
			if (cell.IsWalkable) {
				return new CellAppearance (Color.DarkGray, Color.Transparent, 46);
			} else {
				if (CellHasWalkableNeighbour (cell))
					return new CellAppearance (Color.White, Color.Gray, 176);
				else
					return new CellAppearance (Color.Black, Color.Black, 0);
			}
		}

		private Pair<int,int>[] GetNeighboursCoordinatesFromCell(RogueSharp.Cell cell) {
			return new Pair<int,int>[] {
				new Pair<int, int> (cell.X - 1, cell.Y - 1),
				new Pair<int, int> (cell.X - 1, cell.Y),
				new Pair<int, int> (cell.X - 1, cell.Y + 1),
				new Pair<int, int> (cell.X, cell.Y - 1),
				new Pair<int, int> (cell.X, cell.Y + 1),
				new Pair<int, int> (cell.X + 1, cell.Y - 1),
				new Pair<int, int> (cell.X + 1, cell.Y),
				new Pair<int, int> (cell.X + 1, cell.Y + 1)
			};
		}

		private bool PairIsInBounds(Pair<int,int> pair) {
			return pair.First >= 0 && pair.Second >= 0 && floor.Width > pair.First && floor.Height > pair.Second;
		}

		private bool CellHasWalkableNeighbour(RogueSharp.Cell cell) {
			return (new List<Pair<int,int>> (GetNeighboursCoordinatesFromCell (cell)))
				.Exists ((pair) => PairIsInBounds (pair)
				? floor.GetCell (pair.First, pair.Second).IsWalkable 
				: false);
		}
	}
}

