using System;
using System.Collections.Generic;
using System.Linq;

namespace Lain
{
	/// <summary>
	/// Holds information about the frames per second in the game loop.
	/// </summary>
	public class FrameCounter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Lain.FrameCounter"/> class.
		/// </summary>
		public FrameCounter()
		{
		}

		/// <summary>
		/// Gets the total frames.
		/// </summary>
		/// <value>The total frames.</value>
		public long TotalFrames { get; private set; }

		/// <summary>
		/// Gets the total seconds.
		/// </summary>
		/// <value>The total seconds.</value>
		public float TotalSeconds { get; private set; }

		/// <summary>
		/// Gets the average frames per second.
		/// </summary>
		/// <value>The average frames per second.</value>
		public float AverageFramesPerSecond { get; private set; }

		/// <summary>
		/// Gets the current frames per second.
		/// </summary>
		/// <value>The current frames per second.</value>
		public float CurrentFramesPerSecond { get; private set; }

		/// <summary>
		/// The maximun number of samples to take.
		/// </summary>
		public const int MAXIMUM_SAMPLES = 100;

		/// <summary>
		/// The sample buffer.
		/// </summary>
		private Queue<float> _sampleBuffer = new Queue<float>();

		/// <summary>
		/// Update to the specified delta time.
		/// </summary>
		/// <param name="deltaTime">Delta time.</param>
		public bool Update(float deltaTime)
		{
			CurrentFramesPerSecond = 1.0f / deltaTime;

			_sampleBuffer.Enqueue(CurrentFramesPerSecond);

			if (_sampleBuffer.Count > MAXIMUM_SAMPLES)
			{
				_sampleBuffer.Dequeue();
				AverageFramesPerSecond = _sampleBuffer.Average(i => i);
			} 
			else
			{
				AverageFramesPerSecond = CurrentFramesPerSecond;
			}

			TotalFrames++;
			TotalSeconds += deltaTime;
			return true;
		}
	}
}

