// Copyright (c) 2022 hibzz.games
//
// Author:       Hibnu Hishath (sliptrixx)
// Description:  A class that allows parameters to be passed in between scenes
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

using System.Collections.Generic;

namespace Hibzz.Core.SceneManagement
{
	public static class SceneManager
	{
		// Scene parameters
		private static Dictionary<string, object> parameters;

		/// <summary>
		/// A flag that indicates whether the parameters need to be cleared on new scene load
		/// </summary>
		public static bool ClearParamsOnLoad = true;

		/// <summary>
		/// Load the scene with the given parameters 
		/// </summary>
		public static void Load(string scenename, params object[] paramslist)
		{
			// we clear params if requested
			if(ClearParamsOnLoad) { ClearParams(); }

			// Add the passed list of key value pairs to parameters list
			for(int i = 0; i < paramslist.Length; i += 2)
			{
				string key = (string)paramslist[i];
				object value = paramslist[i + 1];
				AddParam(key, value);
			}

			// load the scene using the given scenename
			UnityEngine.SceneManagement.SceneManager.LoadScene(scenename);
		}

		/// <summary>
		/// Get the value based on the given key
		/// </summary>
		public static T GetParam<T>(string key)
		{
			// when parameters is not initialized - return null
			if(parameters == null) { return default; }

			// when key is not found in the parameters - return null
			if(!parameters.ContainsKey(key)) { return default; }

			// a value exists, so return matching value
			return (T) parameters[key];
		}

		// Add a key value pair to the parameter list
		private static void AddParam(string key, object value)
		{
			// if list is not initialized, initialize the params list
			parameters ??= new Dictionary<string, object>();

			// if the key already exists, modify the value, else add it to list
			if(parameters.ContainsKey(key))
			{
				parameters[key] = value;
			}
			else
			{
				parameters.Add(key, value);
			}
		}

		// Clear all params
		private static void ClearParams()
		{
			if(parameters != null) { parameters.Clear(); }
		}
	}
}
