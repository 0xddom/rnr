using System;
using RnR.Systems.D20.Base.FloorElements;
using Lain;
using Microsoft.Xna.Framework;
using Lain.Geometry;

namespace RnR.Systems.D20.FloorElements
{
	public class Stair : OnStepListener, Drawable, Positionable
	{
		public StairDirection Direction { get; private set; }

		public Stair (StairDirection direction, Point2D pos)
		{
			Direction = direction;
			Position = pos;
		}

		#region Drawable implementation

		public SadConsole.CellAppearance Appearance ()
		{
			int glyphIndex = Direction == StairDirection.DOWN ? 242 : 94;
			return new SadConsole.CellAppearance (Color.DarkGray, Color.Transparent, glyphIndex);
		}

		#endregion

		#region OnStepListener implementation

		public RnR.Systems.D20.Base.Actors.GameActor OnStep (RnR.Systems.D20.Base.Actors.GameActor target)
		{
			throw new NotImplementedException ();
		}

		#endregion

		#region Positionable implementation

		public Lain.Geometry.Point2D Position {
			get;
			set;
		}

		#endregion
	}
}

