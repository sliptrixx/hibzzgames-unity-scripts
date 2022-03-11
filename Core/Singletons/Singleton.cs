using UnityEngine;

namespace Hibzz.Core.Singletons
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = createNewInstance();
                }

                return instance;
            }
        }

        private static T createNewInstance()
        {
            T[] items = FindObjectsOfType(typeof(T)) as T[];
            if (items.Length == 0)
            {
                // no instance of the singleton found in the scene... so creating one
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name + "Object";
                return obj.AddComponent<T>();
            }
            else if (items.Length > 1)
            {
                // more than one instance found. So returning null
                Debug.LogError("Multiple instances of the singleton found. So, cant determine what's the singleton. Returning null.");
                return null;
            }

            // only one instance of type T found in the scene
            return items[0];
        }
    }
}
