using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic
{
    [CreateAssetMenu(menuName = "Game/Gameplay/ClassTemplate")]
    public class ScriptableCharacterTemplate : ScriptableObject
    {
        public string className = "ClassName";
        public int startStrength=0;
        public int startCunning=0;
        public int startMagic=0;
        public int startFaith=0;
        public int startSpeed = 0;

        public int perLvlStrength=0;
        public int perLvlCunning=0;
        public int perLvlMagic=0;
        public int perLvlFaith=0;
        public int perLvlSpeed = 0;

        public AbilitiesPerLevelDictionary abilitiesAtLevels = new AbilitiesPerLevelDictionary();
    }
}
