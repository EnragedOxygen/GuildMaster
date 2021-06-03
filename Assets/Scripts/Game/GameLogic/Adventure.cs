using UnityEngine;

namespace Game.GameLogic
{
    public class Adventure
    {
        public enum AdventureProgress
        {
            TravelingToTheDungeon,
            ClearingTheDungeon,
            GoingHome
        }
        public CharacterParty party { get; private set;}
        public AbstractDungeon dungeon { get; private set;}
        public float estimatedTimeOfArrival { get; private set; }

        public AdventureProgress adventureProgress;
        
        public AbstractDungeon.DungeonClearResult result { get;}

        public Adventure(CharacterParty braveParty, AbstractDungeon evilDungeon)
        {
            party = braveParty;
            dungeon = evilDungeon;
            estimatedTimeOfArrival = Mathf.Min(party.partyStatBlock.speed / dungeon.dungeonStatBlock.speed,1);
        }

        public bool ProgressAdventure()
        {
            switch (adventureProgress)
            {
                case AdventureProgress.TravelingToTheDungeon:
                {
                    if (--estimatedTimeOfArrival<=0)
                    {
                        adventureProgress = AdventureProgress.ClearingTheDungeon;
                    }
                    break;
                }
                case AdventureProgress.ClearingTheDungeon:
                {
                    adventureProgress=AdventureProgress.GoingHome;
                    break;
                }
                case AdventureProgress.GoingHome:
                {
                    if (--estimatedTimeOfArrival<=0)
                    {
                        return true;
                    }
                    break;
                }
                default:
                    Debug.LogError("Unknown AdventureProgress Type");
                    break;
            }
            return false;
        }
    }
}