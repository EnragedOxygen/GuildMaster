using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObject {

    private static bool _hasInstance;
    public static bool HasInstance => _hasInstance;

    private static T _instance;
    public static T Instance {
        get {
            if (!_hasInstance) {
                if (Application.isEditor) {
                    _instance = Resources.LoadAll<T>("").First();
                }
                _hasInstance = _instance != null;
            }
            return _instance;
        }
    }
}
