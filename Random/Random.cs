using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hibzz.Random
{
	public static partial class Random
	{
		private static System.Random Generator = new System.Random();
		private static int? Seed = null;

		/// <summary>
		/// Set the given seed as the random number's seed
		/// </summary>
		/// <param name="seed">The seed of the random number generator</param>
		/// <remarks>If null, reset's the generator to a random seed/remarks>
		public static void SetSeed(int? seed)
		{
			// set the seed value so it can be accessed else where
			Seed = seed;
			Generator = (Seed == null) ? new System.Random() : new System.Random(Seed.Value);
		}

		/// <summary>
		/// Reset the seed for the random number generator
		/// </summary>
		public static void ResetSeed()
		{
			SetSeed(null);
		}
	}
}
