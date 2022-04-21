### Hibzz.Core.Singletons
A set of classes that simplifies the creation, management and usage of singletons in Unity projects. The object gets created automatically when it's first accessed and whenever the object is destroyed, the reference to the instance get's cleared automatically (like in case of scene change, etc.)

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
