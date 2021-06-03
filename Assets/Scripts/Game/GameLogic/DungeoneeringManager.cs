using System.Collections.Generic;
using System.Linq;
using Game.GameLogic;

public class DungeoneeringManager : ITurnBased
{
    private List<CharacterParty> m_ActiveParties = new List<CharacterParty>();
    private List<AbstractDungeon> m_Dungeons = new List<AbstractDungeon>();
    private List<Adventure> m_Adventures = new List<Adventure>();
    private List<Adventure> m_completedAdventures = new List<Adventure>();

    public DungeoneeringManager()
    {
        RegisterForTurns();
    }
    public void RegisterForTurns()
    {
        throw new System.NotImplementedException();
    }

    public void TurnStart()
    {
        foreach (var adventure in m_Adventures.Where(adventure => adventure.ProgressAdventure()))
        {
            m_completedAdventures.Add(adventure);
            m_Adventures.Remove(adventure);
        }
    }

    public void TurnEnd()
    {
        foreach (var adventure in m_completedAdventures)
        {
            adventure.ProgressAdventure();
        }
    }
}
