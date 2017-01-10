using SadConsole.Consoles;
using RnR.World;
using RogueSharp;
using SadConsole;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Lain.Utils;
using Lain.Geometry;
using RnR.Systems.D20.FloorElements;

namespace RnR.Consoles
{
	public class DungeonFloorConsole : SadConsole.Consoles.Console
	{
		public DungeonFloor floor;
		int viewWidth;
		int viewHeight;
		CellAppearance[,] drawData;

		private Point2D center;

		public Point2D Center {
			set {
				center = value;
				UpdateMapData (value);
			}
			get { return center; }
		}

		public DungeonFloorConsole (DungeonFloor floor, int w, int h) 
			: base(Math.Max(floor.Width, w),Math.Max(floor.Height, h))
		{
			this.viewWidth = w;//Math.Min(floor.Width, w);
			this.viewHeight = h;//Math.Min(floor.Height, h);
			this.floor = floor;

			//System.Console.Write (floor.ToString ());

			//drawData = new CellAppearance[floor.Width, floor.Height];
			drawData = new CellAppearance[w, h];

			TextSurface.RenderArea = new Microsoft.Xna.Framework.Rectangle (0, 0, viewWidth, viewHeight);

			center = new Point2D (20, 10);

			System.Console.WriteLine ($"Floor has {floor.FloorElements.Count} elements");

			UpdateMapData (center);
		}

		public void UpdateMapData(Point2D center) {
			int xStart = center.X - viewWidth / 2;
			int yStart = center.Y - viewHeight / 2;

			int xEnd = center.X + viewWidth / 2;
			int yEnd = center.Y + viewHeight / 2;

			// XXX: There should be some math that optimizes this.
			while ((xEnd - xStart) < viewWidth)
				xEnd++;

			while ((yEnd - yStart) < viewHeight)
				yEnd++;

			for (int x = xStart, i = 0; x < xEnd; x++, i++) {
				for (int y = yStart, j = 0; y < yEnd; y++, j++) {
					if (x < 0 || y < 0 || x >= floor.Width || y >= floor.Height) {
						SetCellAppearance (i, j, DefaultCellAppearance ());
					} else {
						SetCellAppearance (i, j, GetAppearanceFromCell (floor.GetCell (x, y)));
					}
				}
			}
		}

		private void SetCellAppearance(int x, int y, CellAppearance appearance) {
			drawData [x, y] = appearance;
			drawData [x, y].CopyAppearanceTo (this [x, y]);
		}

		private CellAppearance DefaultCellAppearance() {
			return new CellAppearance (Color.Black, Color.Black, 0);
		}

		private bool StairIsAtCell(RogueSharp.Cell cell, Stair stair) {
			return stair.Position.X == cell.X && stair.Position.Y == cell.Y;
		}

		private CellAppearance GetAppearanceFromCell(RogueSharp.Cell cell) {
			if (floor.UpStair != null && StairIsAtCell (cell, floor.UpStair))
				return floor.UpStair.Appearance ();
			if (StairIsAtCell (cell, floor.DownStair))
				return floor.DownStair.Appearance ();
			if (cell.IsWalkable) {
				var p = new Point2D (cell.X, cell.Y);
				if (floor.FloorElements.ContainsKey (p)) {
					return floor.FloorElements [p].Appearance ();
				}
				return new CellAppearance (Color.DarkGray, Color.Transparent, 46);
			} else {
				if (CellHasWalkableNeighbour (cell))
					return new CellAppearance (Color.White, Color.Gray, 176);
				else
					return DefaultCellAppearance ();
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

		public override void Update ()
		{
			base.Update ();
			//UpdateMapData (center);
		}
	}
}

