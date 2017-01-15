using RnR.World;
using SadConsole;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Lain.Utils;
using Lain.Geometry;
using RnR.Systems.D20.FloorElements;
using RnR.Systems.D20;

namespace RnR.Consoles
{
	/// <summary>
	/// This class draws the map of the current floor.
	/// 
	/// The code is ugly as hell as drawing code usually is. You have been warned.
	/// </summary>
	public class DungeonFloorConsole : SadConsole.Consoles.Console
	{
		/// <summary>
		/// Gets or sets the floor.
		/// </summary>
		/// <value>The floor.</value>
		public DungeonFloor Floor { get; set; }

		public Party Party { get; set; }

		/// <summary>
		/// The width of the view.
		/// </summary>
		int viewWidth;

		/// <summary>
		/// The height of the view.
		/// </summary>
		int viewHeight;

		/// <summary>
		/// The draw data.
		/// </summary>
		CellAppearance [,] drawData;

		/// <summary>
		/// The center appearance.
		/// </summary>
		private CellAppearance CenterAppearance;

		/// <summary>
		/// The center.
		/// </summary>
		//private Point2D center;

		/// <summary>
		/// Gets or sets the center.
		/// </summary>
		/// <value>The center.</value>
		public Point2D Center {
			set {
				Party.Leader.Position = value;
				UpdateMapData (value);
			}
			get { return Party.Leader.Position; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:RnR.Consoles.DungeonFloorConsole"/> class.
		/// </summary>
		/// <param name="floor">Floor.</param>
		/// <param name="w">The width.</param>
		/// <param name="h">The height.</param>
		public DungeonFloorConsole (DungeonFloor floor, Party party, int w, int h)
			: base (Math.Max (floor.Width, w), Math.Max (floor.Height, h))
		{
			viewWidth = w;
			viewHeight = h;
			Floor = floor;
			Party = party;

			drawData = new CellAppearance [w, h];

			TextSurface.RenderArea = new Microsoft.Xna.Framework.Rectangle (0, 0, viewWidth, viewHeight);

			foreach (RogueSharp.Cell cell in Floor.GetAllCells ()) {
				if (cell.IsWalkable) {
					Party.Leader.Position = new Point2D (cell.X, cell.Y);
					break;
				}
			}

			CenterAppearance = new CellAppearance (Color.Blue, Color.Transparent, 64);
		}

		/// <summary>
		/// Updates the map data.
		/// </summary>
		/// <param name="center">Center.</param>
		public void UpdateMapData (Point2D center)
		{
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

		/// <summary>
		/// Sets the cell appearance.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="appearance">Appearance.</param>
		void SetCellAppearance (int x, int y, CellAppearance appearance)
		{
			drawData [x, y] = appearance;
			drawData [x, y].CopyAppearanceTo (this [x, y]);
		}

		/// <summary>
		/// Defaults the cell appearance.
		/// </summary>
		/// <returns>The cell appearance.</returns>
		CellAppearance DefaultCellAppearance ()
		{
			return new CellAppearance (Color.Black, Color.Black, 0);
		}

		/// <summary>
		/// Stairs the is at cell.
		/// </summary>
		/// <returns><c>true</c>, if is at cell was staired, <c>false</c> otherwise.</returns>
		/// <param name="cell">Cell.</param>
		/// <param name="stair">Stair.</param>
		bool StairIsAtCell (RogueSharp.Cell cell, Stair stair)
		{
			return stair.Position.X == cell.X && stair.Position.Y == cell.Y;
		}

		/// <summary>
		/// Gets the appearance of a given cell.
		/// </summary>
		/// <returns>The appearance of the cell.</returns>
		/// <param name="cell">Cell.</param>
		CellAppearance GetAppearanceFromCell (RogueSharp.Cell cell)
		{
			if (Center.X == cell.X && Center.Y == cell.Y)
				return Party.Leader.Appearance(true);

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
					return new FloorAppearance ();
				}
				if (CellHasWalkableNeighbour (cell)) {
					if (cell.IsInFov)
						return new WallInFovAppearance ();
					return new WallAppearance ();
				}
				return DefaultCellAppearance ();
			}
			return DefaultCellAppearance ();
		}

		/// <summary>
		/// Gets the neighbours coordinates from cell.
		/// </summary>
		/// <returns>The neighbours coordinates from cell.</returns>
		/// <param name="cell">Cell.</param>
		Pair<int, int> [] GetNeighboursCoordinatesFromCell (RogueSharp.Cell cell)
		{
			return new Pair<int, int> [] {
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

		/// <summary>
		/// Check if the pair is in bounds.
		/// </summary>
		/// <returns><c>true</c>, if the pair is in bounds, <c>false</c> otherwise.</returns>
		/// <param name="pair">Pair.</param>
		bool PairIsInBounds (Pair<int, int> pair)
		{
			return pair.First >= 0 && pair.Second >= 0 && Floor.Width > pair.First && Floor.Height > pair.Second;
		}

		/// <summary>
		/// The cell has a walkable neighbour.
		/// </summary>
		/// <returns><c>true</c>, if has walkable neighbour was celled, <c>false</c> otherwise.</returns>
		/// <param name="cell">Cell.</param>
		bool CellHasWalkableNeighbour (RogueSharp.Cell cell)
		{
			return (new List<Pair<int, int>> (GetNeighboursCoordinatesFromCell (cell)))
				.Exists ((pair) => PairIsInBounds (pair) && Floor.GetCell (pair.First, pair.Second).IsWalkable);
		}

		/// <summary>
		/// Called during the update step in the game loop.
		/// </summary>
		public override void Update ()
		{
			base.Update ();
			UpdateMapData (Party.Leader.Position);
		}
	}
}

