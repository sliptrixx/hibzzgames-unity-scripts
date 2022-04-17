// Copyright (c) 2022 hibzz.games
//
// Author:       Hibnu Hishath (sliptrixx)
// Description:  An extension class for Unity's new Input System that adds
//               features similar to the old input system and input guestures
// Requirements: com.unity.inputsystem
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

#if ENABLE_INPUT_SYSTEM
using UnityEngine;
using UnityEngine.InputSystem;

public static class InputActionExtension
{
	/// <summary>
	/// Equivalent to Input.GetKey()
	/// </summary>
	public static bool IsPressed(this InputAction action)
    {
		return action.ReadValue<float>() > 0;
    }

	/// <summary>
	/// Equivalent to Input.GetKeyDown()
	/// </summary>
	public static bool WasPressedThisFrame(this InputAction action)
    {
		return action.triggered && action.ReadValue<float>() > 0;
    }

	/// <summary>
	/// Equivalent to Input.GetKeyUp()
	/// </summary>
	public static bool WasReleasedThisFrame(this InputAction action)
    {
		return action.triggered && action.ReadValue<float>() == 0;
    }

	/// <summary>
	/// Gets the X value of Vector2 InputAction
	/// </summary>
	public static float GetVectorX(this InputAction action)
    {
		return action.ReadValue<Vector2>().x;
    }

	/// <summary>
	/// Gets the Y value of Vector2 InputAction
	/// </summary>
	public static float GetVectorY(this InputAction action)
    {
		return action.ReadValue<Vector2>().y;
    }

    /// <summary>
	/// Gets the vector2 value from InputAction
	/// </summary>
    public static Vector2 GetVector(this InputAction action)
    {
        return action.ReadValue<Vector2>();
    }
}
#endif
