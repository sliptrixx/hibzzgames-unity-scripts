// Copyright (c) 2022 hibzz.games
//
// Author:       Hibnu Hishath (sliptrixx)
// Description:  An extension class for Unity's Vector2 and Vector3 structs
//               that adds a bunch of helpful utility functions
//
// License ID:   N/A
// License:      This script can only be used on projects made by Hibzz Games
//				 or on projects that have a valid license ID. To request a
//				 custom license and a license ID, please send an email to
//				 support@hibzz.games with details about the project.
// 
//               THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY
//               KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//               WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
//               PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
//               COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//               LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//               ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE
//               USE OR OTHER DEALINGS IN THE SOFTWARE.

using UnityEngine;

public static class VectorExtension
{
	/// <summary>
	/// Get the angle between two vector2 points in degrees
	/// </summary>
	public static float Angle(this Vector2 from, Vector2 to)
	{
		Vector2 dir = to - from;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		if (angle < 0.0f) angle += 360.0f;
		return angle;
	}

	/// <summary>
	/// Get the normalized direction between two vector3 points
	/// </summary>
	public static Vector3 Direction(this Vector3 from, Vector3 to)
	{
		return (to - from).normalized;
	}

	/// <summary>
	/// Get the normalized direction between two vector2 points
	/// </summary>
	public static Vector2 Direction(this Vector2 from, Vector2 to)
	{
		return (to - from).normalized;
	}

	/// <summary>
	/// Get a vector 2 representing XY
	/// </summary>
	public static Vector2 XY(this Vector3 vector)
	{
		return new Vector2(vector.x, vector.y);
	}

	/// <summary>
	/// Get a vector2 representing XZ
	/// </summary>
	public static Vector2 XZ(this Vector3 vector)
	{
		return new Vector2(vector.x, vector.z);
	}

	/// <summary>
	/// Get a vector2 representing YX
	/// </summary>
	public static Vector2 YX(this Vector3 vector)
	{
		return new Vector2(vector.y, vector.x);
	}

	/// <summary>
	/// Get a vector2 representing YZ
	/// </summary>
	public static Vector2 YZ(this Vector3 vector)
	{
		return new Vector2(vector.y, vector.z);
	}

	/// <summary>
	/// Get a vector2 representing ZX
	/// </summary>
	public static Vector2 ZX(this Vector3 vector)
	{
		return new Vector2(vector.z, vector.x);
	}

	/// <summary>
	/// Get a vector2 representing ZY
	/// </summary>
	public static Vector2 ZY(this Vector3 vector)
	{
		return new Vector2(vector.z, vector.y);
	}
}
