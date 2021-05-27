using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Configs/Game Config")]
public class GameConfig : ScriptableSingleton<GameConfig>
{
    public List<int> XpToLevel = new List<int>();
    
}
