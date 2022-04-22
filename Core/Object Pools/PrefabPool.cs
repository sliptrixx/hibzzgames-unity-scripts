// Copyright (c) 2022 hibzz.games
//
// Author:       Hibnu Hishath (sliptrixx)
// Description:  A class that creates makes object pooling on prefabs easy
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
using UnityEngine;

namespace Hibzz.Core.ObjectPools
{
	/// <summary>
	/// A pool of prefabs
	/// </summary>
	public class PrefabPool
	{
		/// <summary>
		/// A dictionary of prefabs and instances of said prefabs
		/// </summary>
		private Dictionary<GameObject, ObjectPool<GameObject>> Pool = new Dictionary<GameObject, ObjectPool<GameObject>>();

		/// <summary>
		/// A predicate to remove all inactive objects
		/// </summary>
		private System.Predicate<GameObject> InactivePredicate =
			(GameObject item) => { return !item.activeSelf; };

		/// <summary>
		/// Used to internally initialize if the key doesn't exist
		/// </summary>
		/// <param name="key"> The key to use while initialize the new objectPool </param>
		private void Initialize(GameObject key)
		{
			// Configuring object pool to instantiate a new prefab of type "key" when NewItem is called
			ObjectPool<GameObject> visualpool = new ObjectPool<GameObject>(() => { return Object.Instantiate(key); });

			// when the item is added to the active list, the item will be set active
			visualpool.OnAddToActiveCallback = (GameObject item) => { item.SetActive(true); };

			// when the item is removed from the active list, the item will be set to inactive
			visualpool.OnRemoveCallback = (GameObject item) => { item.SetActive(false); };

			// when the item has to be destroyed, it actually destroys the object from the hierarchy view
			visualpool.OnDestroyCallback = (GameObject item) => { Object.Destroy(item); };

			// Link the key to the newly configured pool
			Pool.Add(key, visualpool);
		}

		/// <summary>
		/// Get the object pool with the requested key. If the key doesn't exist a new pool is created
		/// </summary>
		/// <param name="key"> The key to reference by </param>
		/// <returns> The object pool with the matching key </returns>
		public ObjectPool<GameObject> this[GameObject key]
		{
			get
			{
				// if the given key is null, then return null
				if (key == null) { return null; }

				// if the requested key doesn't exist, we initialize it appropriately
				if (!Pool.ContainsKey(key)) { Initialize(key); }

				// return the requested object pool
				return Pool[key];
			}
		}

		/// <summary>
		/// Update the pool to remove inactive items
		/// </summary>
		public void Update()
		{
			foreach (var pool in Pool)
			{
				pool.Value.RemoveAll(InactivePredicate);
			}
		}
	}
}