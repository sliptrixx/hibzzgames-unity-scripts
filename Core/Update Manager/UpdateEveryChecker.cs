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

using System.Reflection;
using UnityEngine;

namespace Hibzz.Core.UpdateManager
{
	public class UpdateEveryChecker
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		static void CheckForMatchingAttribute()
		{
			// get all monobehaviors and check for a matching attribute
			var monos = Object.FindObjectsOfType<MonoBehaviour>();
			foreach(var mono in monos)
			{
				// get the public methods
				var methods = mono.GetType().GetMethods();
				CheckInsideMethodsHelper(methods, mono);

				// get the private/protected methods
				methods = mono.GetType().GetMethods(BindingFlags.NonPublic);
				CheckInsideMethodsHelper(methods, mono);
			}
		}

		// Helper method to look inside the list of methods passed
		static void CheckInsideMethodsHelper(MethodInfo[] methods, MonoBehaviour mono)
		{
			foreach (var method in methods)
			{
				var attributes = method.GetCustomAttributes(false);
				foreach (var attribute in attributes)
				{
					var updateEveryAttribute = attribute as UpdateEveryAttribute;
					if (updateEveryAttribute != null)
					{
						var updateDelegate = method.CreateDelegate(typeof(UpdateManager.UpdateDelegate), mono) as UpdateManager.UpdateDelegate;
						if (updateDelegate != null)
						{
							UpdateManager.Instance.Add(updateDelegate, updateEveryAttribute.Interval, true);
						}
						else
						{
							Debug.LogError($"'{method.Name}' on '{mono.GetType()}' incompatible with UpdateEvery.\n\n" +
								$"This feature is only compatible with function that take no parameters and returns void.");
						}
					}
				}
			}
		}
	}
}

