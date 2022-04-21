// Copyright (c) 2022 hibzz.games
//
// Author:       Hibnu Hishath (sliptrixx)
// Description:  An extension class for Unity's Transform class that adds a
//               bunch of helpful utility functions
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

using UnityEngine;

public static class TransformExtension
{
	/// <summary>
	/// Get the down vector of this transform
	/// </summary>
	public static Vector3 Down(this Transform transform)
	{
		return -transform.up;
	}

	/// <summary>
	/// Get the left vector of this transform
	/// </summary>
	public static Vector3 Left(this Transform transform)
	{
		return -transform.right;
	}

	/// <summary>
	/// Get the backward vector of this transform
	/// </summary>
	public static Vector3 Backward(this Transform transform)
	{
		return -transform.forward;
	}

	/// <summary>
	/// Set the X value of the transform's position
	/// </summary>
	public static void SetPositionX(this Transform transform, float x)
	{
		Vector3 pos = transform.position;
		pos.x = x;
		transform.position = pos;
	}

	/// <summary>
	/// Set the Y value of the transform's position
	/// </summary>
	public static void SetPositionY(this Transform transform, float y)
	{
		Vector3 pos = transform.position;
		pos.y = y;
		transform.position = pos;
	}

	/// <summary>
	/// Set the Z value of the transform's position
	/// </summary>
	public static void SetPositionZ(this Transform transform, float z)
	{
		Vector3 pos = transform.position;
		pos.z = z;
		transform.position = pos;
	}

	/// <summary>
	/// Set the X value of the transform's scale
	/// </summary>
	public static void SetScaleX(this Transform transform, float x)
	{
		Vector3 scale = transform.localScale;
		scale.x = x;
		transform.localScale = scale;
	}

	/// <summary>
	/// Set the Y value of the transform's scale
	/// </summary>
	public static void SetScaleY(this Transform transform, float y)
	{
		Vector3 scale = transform.localScale;
		scale.y = y;
		transform.localScale = scale;
	}

	/// <summary>
	/// Set the Z value of the transform's scale
	/// </summary>
	public static void SetScaleZ(this Transform transform, float z)
	{
		Vector3 scale = transform.localScale;
		scale.z = z;
		transform.localScale = scale;
	}

	/// <summary>
	/// Set the X value of the transform's rotation (in euler form)
	/// </summary>
	public static void SetRotationX(this Transform transform, float x)
	{
		Vector3 rot = transform.eulerAngles;
		rot.x = x;
		transform.eulerAngles = rot;
	}

	/// <summary>
	/// Set the Y value of the transform's rotation (in euler form)
	/// </summary>
	public static void SetRotationY(this Transform transform, float y)
	{
		Vector3 rot = transform.eulerAngles;
		rot.y = y;
		transform.eulerAngles = rot;
	}

	/// <summary>
	/// Set the Z value of the transform's rotation (in euler form)
	/// </summary>
	public static void SetRotationZ(this Transform transform, float z)
	{
		Vector3 rot = transform.eulerAngles;
		rot.z = z;
		transform.eulerAngles = rot;
	}

	/// <summary>
	/// Set the X value of the transform's rotation (in quaternion form)
	/// </summary>
	public static void SetQuaternionX(this Transform transform, float x)
	{
		Quaternion rot = transform.rotation;
		rot.x = x;
		transform.rotation = rot;
	}

	/// <summary>
	/// Set the Y value of the transform's rotation (in quaternion form)
	/// </summary>
	public static void SetQuaternionY(this Transform transform, float y)
	{
		Quaternion rot = transform.rotation;
		rot.y = y;
		transform.rotation = rot;
	}

	/// <summary>
	/// Set the Z value of the transform's rotation (in quaternion form)
	/// </summary>
	public static void SetQuaternionZ(this Transform transform, float z)
	{
		Quaternion rot = transform.rotation;
		rot.z = z;
		transform.rotation = rot;
	}

	/// <summary>
	/// Set the W value of the transform's rotation (in quaternion form)
	/// </summary>
	public static void SetQuaternionW(this Transform transform, float w)
	{
		Quaternion rot = transform.rotation;
		rot.w = w;
		transform.rotation = rot;
	}
}
