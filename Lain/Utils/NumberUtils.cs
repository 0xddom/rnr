using System;

namespace Lain.Utils
{
	public class NumberUtils
	{
		public NumberUtils ()
		{
		}

		// Naive implementation. Don't check for overflows
		public static float Map(float src, float src_from, float src_to, float dst_from, float dst_to) {
			return dst_from + (dst_to - dst_from) * ((src - src_from) / (src_to - src_from));
		}
	}
}

