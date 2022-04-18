### Hibzz.Core.Singletons
A set of classes that simplifies the creation and usage of singletons in Unity projects

### How to use?
```c#
// defining a singleton
using Hibzz.Core.Singletons;

class EnemyManager : Singleton<EnemyManager>
{
  public int EnemyCount = 0;
}
```

```c#
// accessing the singleton
int enemyCount = EnemyManager.Instance.EnemyCount;
```

### Variants
- Singleton - Based on MonoBehaviour
- NetworkSingleton - Based on NetworkBehavior

### Known issues
- The singleton doesn't recognize scene changes or when a singleton object is destroyed. So, when a scene change happens, the singleton still points to the old invalid object. 