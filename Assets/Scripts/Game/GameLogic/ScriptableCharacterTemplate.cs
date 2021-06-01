using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic
{
    [CreateAssetMenu(menuName = "Game/Gameplay/ClassTemplate")]
    public class ScriptableCharacterTemplate : ScriptableObject
    {
        public string className = "ClassName";
        public StatBlock startStats;
        public StatBlock perLvlStats;

        public AbilitiesPerLevelDictionary abilitiesAtLevels = new AbilitiesPerLevelDictionary();
    }
}
