// Copyright (c) 2022 hibzz.games
//
// Author:       Hibnu Hishath (sliptrixx)
// Description:  A class that helps execute functions in specified fixed
//               intervals
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
using System.Reflection;
using UnityEngine;
using Hibzz.Core.Singletons;

namespace Hibzz.Core.UpdateManager
{
	public class UpdateManager : Singleton<UpdateManager>
	{
		// declaring the delegate
		public delegate void UpdateDelegate();

		// A list of UpdateData information
		private List<UpdateData> updates = new List<UpdateData>();

		/// <summary>
		/// Add a delegate to be executed every fixed interval
		/// </summary>
		/// <param name="updateDelegate"> The delegate to execute </param>
		/// <param name="interval"> how often to execute the interval </param>
		public void Add(UpdateDelegate updateDelegate, float interval, bool executeImmediately = true)
		{
			// initialize the data
			UpdateData data = new UpdateData
			{
				interval = interval,
				updateDelegate = updateDelegate,
				timer = executeImmediately ? Time.deltaTime : interval
			};

			updates.Add(data);
		}

		/// <summary>
		/// Remove all UpdateData with the matching delegate
		/// </summary>
		/// <param name="updateDelegate"> The delegate that needs to be removed </param>
		public void Remove(UpdateDelegate updateDelegate)
		{
			// remove all update data with a matching delegates
			updates.RemoveAll(
				(UpdateData data) => 
				{ 
					return data.updateDelegate == updateDelegate; 
				});
		}

		private void CheckForMatchingAttributes(MethodInfo[] methods, MonoBehaviour mono = null)
		{
			foreach (var method in methods)
			{
				var attributes = method.GetCustomAttributes(false);
				foreach(var attribute in attributes)
				{
					var updateEveryAttribute = attribute as UpdateEveryAttribute;
					if(updateEveryAttribute != null)
					{
						var updateDelegate = method.CreateDelegate(typeof(UpdateDelegate), mono) as UpdateDelegate;
						if (updateDelegate != null)
						{
							Add(updateDelegate, updateEveryAttribute.Interval, true);
						}
						else
						{
							Debug.LogError($"'{method.Name}' on '{mono.GetType()}' incompatible with UpdateEvery.\n\n" +
								$"This feature is only compatible with function that take no parameters and returns void");
						}
					}
				}
			}
		}

		// called once at the start of the frame
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private void Start()
		{
			var gameobjects = FindObjectsOfType<GameObject>();
			foreach(var gameobj in gameobjects)
			{
				var monos = gameobj.GetComponents<MonoBehaviour>();

				foreach(var mono in monos)
				{
					// look through public methods
					var methods = mono.GetType().GetMethods();
					CheckForMatchingAttributes(methods, mono);

					// look through private/protected methods
					methods = mono.GetType().GetMethods(BindingFlags.NonPublic);
					CheckForMatchingAttributes(methods, mono);
				}
			}
		}

		// Called once every frame
		private void Update()
		{
			// go through each of the update data and decrement the timer...
			// once the timer has elapsed, execute the function and reset the
			// timer
			foreach(UpdateData data in updates)
			{
				data.timer -= Time.deltaTime;
				if(data.timer <= 0)
				{
					data.timer += data.interval;
					data.updateDelegate?.Invoke();
				}
			}
		}

		// A struct representing the update data
		private class UpdateData
		{
			public float interval;
			public float timer;
			public UpdateDelegate updateDelegate;
		}
	}
}
