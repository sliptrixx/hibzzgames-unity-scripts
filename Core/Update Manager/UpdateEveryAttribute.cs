// Copyright (c) 2022 hibzz.games
//
// Author:       Hibnu Hishath (sliptrixx)
// Description:  Helper Attribute for the UpdateManager
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

using System;

namespace Hibzz.Core.UpdateManager
{
	[AttributeUsage(AttributeTargets.Method)]
	public class UpdateEveryAttribute : Attribute
	{
		/// <summary>
		/// How frequently the update function is called
		/// </summary>
		public float Interval { get; protected set; }

		/// <summary>
		/// An attribute that adds the given function to the UpdateManager
		/// </summary>
		/// <param name="interval">How frequently the update function is called in seconds</param>
		public UpdateEveryAttribute(float interval)
		{
			Interval = interval;
		}
	}

	
}
