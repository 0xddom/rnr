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
	/// <summary>
	/// This class draws the map of the current floor.
	/// 
	/// The code is ugly as hell as drawing code usually is. You have been warned.
	/// </summary>
	public class DungeonFloorConsole : SadConsole.Consoles.Console
	{
		public delegate DungeonFloor GetFloor();

		public DungeonFloor Floor { get; set; }
		int viewWidth;
		int viewHeight;
		CellAppearance[,] drawData;

		private CellAppearance CenterAppearance;

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
			this.Floor = floor;

			//System.Console.Write (floor.ToString ());

			//drawData = new CellAppearance[floor.Width, floor.Height];
			drawData = new CellAppearance[w, h];

			TextSurface.RenderArea = new Microsoft.Xna.Framework.Rectangle (0, 0, viewWidth, viewHeight);

			//center = new Point2D (20, 10);

			foreach (RogueSharp.Cell cell in Floor.GetAllCells ()) {
				if (cell.IsWalkable) {
					center = new Point2D (cell.X, cell.Y);
					break;
				}
			}

			CenterAppearance = new CellAppearance (Color.Blue, Color.Transparent, 64);

			//UpdateMapData (center);
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
					if (x < 0 || y < 0 || x >= Floor.Width || y >= Floor.Height) {
						SetCellAppearance (i, j, DefaultCellAppearance ());
					} else {
						SetCellAppearance (i, j, GetAppearanceFromCell (Floor.GetCell (x, y)));
					}
				}
			}
		}

		private void SetCellAppearance(int x, int y, CellAppearance appearance) {
			//System.Console.Write (appearance.GlyphIndex);
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
			//System.Console.Write (",");
			if (center.X == cell.X && center.Y == cell.Y)
				return CenterAppearance;

			if (cell.IsExplored) {
				if (Floor.UpStair != null && StairIsAtCell (cell, Floor.UpStair))
					return Floor.UpStair.Appearance (cell.IsInFov);

				if (StairIsAtCell (cell, Floor.DownStair))
					return Floor.DownStair.Appearance (cell.IsInFov);
			
				if (cell.IsWalkable) {
					var p = new Point2D (cell.X, cell.Y);
					if (Floor.FloorElements.ContainsKey (p)) {
						return Floor.FloorElements [p].Appearance (cell.IsInFov);
					}
					if (cell.IsInFov)
						return new FloorInFovAppearance ();
					else
						return new FloorAppearance ();
				} else {
					if (CellHasWalkableNeighbour (cell)) {
						if (cell.IsInFov)
							return new WallInFovAppearance ();
						else
							return new WallAppearance ();
					} else
						return DefaultCellAppearance ();
				}
			} else {
				//System.Console.Write (".");
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
			return pair.First >= 0 && pair.Second >= 0 && Floor.Width > pair.First && Floor.Height > pair.Second;
		}

		private bool CellHasWalkableNeighbour(RogueSharp.Cell cell) {
			return (new List<Pair<int,int>> (GetNeighboursCoordinatesFromCell (cell)))
				.Exists ((pair) => PairIsInBounds (pair)
					? Floor.GetCell (pair.First, pair.Second).IsWalkable 
				: false);
		}

		public override void Update ()
		{
			base.Update ();
			UpdateMapData (center);
		}
	}
}

