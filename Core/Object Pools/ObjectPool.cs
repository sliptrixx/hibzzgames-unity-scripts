// Copyright (c) 2022 hibzz.games
//
// Author:       Hibnu Hishath (sliptrixx)
// Description:  A generic object pooling class with a lot of flexibility
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

namespace Hibzz.Core.ObjectPools
{
	/// <summary>
	/// Creates an reusable object pool
	/// </summary>
	/// <typeparam name="T"> Typename T </typeparam>
	[System.Serializable]
	public class ObjectPool<T> : IEnumerable<T>
	{
		/// <summary>
		/// This delegate is used construct new objects
		/// </summary>
		/// <returns> The newly created object </returns>
		public delegate T CreateNewItemDelegate();

		/// <summary>
		/// If this delegate is specified, it'll call this function just before 
		/// removing it from the active list
		/// </summary>
		/// <param name="item"> The item to perform the callback on</param>
		public delegate void OnRemoveCallbackDelegate(T item);

		/// <summary>
		/// If this delegate is specified, this function will be called when an item gets added to the active list
		/// </summary>
		/// <param name="item"> The item to perform the operation on </param>
		public delegate void OnAddToActiveCallbackDelegate(T item);

		/// <summary>
		/// If this delegate is specified, this function will be called when item is actually destroyed
		/// </summary>
		/// <param name="item"> The item to perform the operation on </param>
		public delegate void OnDestroyCallbackDelegate(T item);

		/// <summary>
		/// A private global variable used to store the createNewItemDelegate 
		/// specified in the constructor
		/// </summary>
		public CreateNewItemDelegate CreateNewItem;

		/// <summary>
		/// If this delegate is specified, it'll call this function just before removing from the active list
		/// </summary>
		public OnRemoveCallbackDelegate OnRemoveCallback = null;

		/// <summary>
		/// If this delegate is specified, it'll call this function when an item gets added to the active list
		/// </summary>
		public OnAddToActiveCallbackDelegate OnAddToActiveCallback = null;

		/// <summary>
		/// If this delegate is specified, it'll call this function when an item get's actually destroyed
		/// </summary>
		public OnDestroyCallbackDelegate OnDestroyCallback = null;

		/// <summary>
		/// A list of active objects in the object pool
		/// </summary>
		/// <remarks> Note: Use it for reading purposes only. Don't modify this list directly </remarks>
		private List<T> ActiveObjects = new List<T>();

		/// <summary>
		/// A list of "removed" objects in the object pool
		/// </summary>
		private List<T> InactiveObjects = new List<T>();

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <remarks>
		/// This system doesn't work if user doesn't define how to create a new item. I mean, the 
		/// object pool doesn't really know how to create new items of type T.
		/// </remarks>
		/// <param name="createNewItemDelegate"> The delegate used to construct new objects </param>
		public ObjectPool(CreateNewItemDelegate createNewItemDelegate)
		{
			// cache from the constructor to the global variables
			CreateNewItem = createNewItemDelegate;
		}

		/// <summary>
		/// Finalizer (aka destructor) that's called upon destruction
		/// </summary>
		~ObjectPool()
		{
			AbsoluteDelete();
		}

		/// <summary>
		/// Get a new item from the object pool
		/// </summary>
		/// <returns></returns>
		public T NewItem()
		{
			// if there are any inactive object, re-use it
			if (InactiveObjects.Count > 0)
			{
				// get the first item
				T item = InactiveObjects[0];

				// call the on add to active callback
				OnAddToActiveCallback?.Invoke(item);

				// Add the item to active object, and remove from inactive objects
				ActiveObjects.Add(item);
				InactiveObjects.Remove(item);

				return item;
			}

			// if there are no items to reuse, create a new object using the
			// CreateNewItemDelegate specified in the constructor. Then call the add to
			// active list callback before adding to the active list.
			T newItem = CreateNewItem.Invoke();
			OnAddToActiveCallback?.Invoke(newItem);
			ActiveObjects.Add(newItem);

			// return the newly created item
			return newItem;
		}

		/// <summary>
		/// Remove the item from the active objects list
		/// </summary>
		/// <param name="item"> The item to remove </param>
		public void Remove(T item)
		{
			// if the object is found in the active objects list, then move it to the inactive objects list
			if (ActiveObjects.Contains(item))
			{
				OnRemoveCallback?.Invoke(item);
				InactiveObjects.Add(item);
				ActiveObjects.Remove(item);
			}
			else
			{
				Debug.LogWarning("The item (" + item + ") not found");
			}
		}

		/// <summary>
		/// Remove item from the object pool based on a predicate
		/// </summary>
		/// <param name="predicate"> The predicate based on which to remove items </param>
		public void RemoveAll(System.Predicate<T> predicate)
		{
			// get a list of items that matches the predicate
			List<T> items = ActiveObjects.FindAll(predicate);

			// if a remove callback is specified, then pass each of the matching
			// items to the remove callback
			if (OnRemoveCallback != null)
			{
				foreach (T item in items)
				{
					OnRemoveCallback.Invoke(item);
				}
			}

			// add the matching items to the inactive list, and the remove those items from the active list
			InactiveObjects.AddRange(items);
			ActiveObjects.RemoveAll(predicate);
		}

		/// <summary>
		/// Remove items from the object pool
		/// </summary>
		public void Clear()
		{
			// first call OnRemove function on all active objects
			if (OnRemoveCallback != null)
			{
				foreach (T item in ActiveObjects)
				{
					OnRemoveCallback.Invoke(item);
				}
			}

			// copy all the items from active list to the inactive one and clear the inactive list
			InactiveObjects.AddRange(ActiveObjects);
			ActiveObjects.Clear();
		}

		/// <summary>
		/// Remove all inactive objects from the object pool
		/// </summary>
		public void DeleteInactiveObjects()
		{
			// if OnDestroyCallback is specified, then invoke the function on each of the object
			if (OnDestroyCallback != null)
			{
				foreach (T item in InactiveObjects)
				{
					OnDestroyCallback.Invoke(item);
				}
			}

			// remove all the inactive objects
			InactiveObjects.Clear();
		}

		/// <summary>
		/// Perform an absolute delete, deleting all active and inactive objects
		/// </summary>
		public void AbsoluteDelete()
		{
			// Could be a bit more efficient if we directly apply the process on both the active
			// and inactive list. But for now, we clear the object pool, which moves all objects
			// from the active list to inactive list, and then we delete all the inactive objects
			Clear();
			DeleteInactiveObjects();
		}

		/// <summary>
		/// Implementaion for IEnumerable that make sures that for each loops through the active objects list
		/// </summary>
		/// <returns> Item as we loop through ActiveObjects </returns>
		public IEnumerator<T> GetEnumerator()
		{
			foreach (T item in ActiveObjects)
			{
				yield return item;
			}
		}

		/// <summary>
		/// Get the enumerator
		/// </summary>
		/// <returns> The enumerator </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
