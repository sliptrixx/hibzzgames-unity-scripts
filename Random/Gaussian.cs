// Copyright (c) 2022 hibzz.games
//
// Author:       Hibnu Hishath (sliptrixx)
// Description:  A class that generates random numbers based on a gaussian curve
//               with a variable value
//
// License ID:   N/A
// License:      This script can only be used on projects made by Hibzz Games
//               or on projects that have a valid license ID. To request a
//               custom license and a license ID, please send an email to
//               support@hibzz.games with details about the project.
// 
//               THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY
//               KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//               WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
//               PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
//               COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//               LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//               ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE
//               USE OR OTHER DEALINGS IN THE SOFTWARE.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hibzz.Random
{
	public static partial class Random
	{
		public static class Gaussian
		{
			/// <summary>
			/// Generate a random number based on a gaussian curve given the 
			/// expected value and the standard deviation
			/// </summary>
			/// <param name="expected">The expected value of the random number</param>
			/// <param name="sd">The standard deviation(aka (+)or(-) this value from the expected value)</param>
			/// <returns>The generated value</returns>
			public static float Generate(float expected, float sd)
			{
				float u1 = (float)(1.0f - Generator.NextDouble());
				float u2 = (float)(1.0f - Generator.NextDouble());
				float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI * u2);

				return expected + sd * randStdNormal;
			}
		}
	}
}

