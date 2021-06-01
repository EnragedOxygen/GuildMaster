using System.Collections;
using System.Collections.Generic;
using Game.GameLogic;
using System.Linq;

public class AbstractDungeon
{
    public readonly string dungeonName="dungeonName";
    public enum DungeonClearResult
    {
        Fail = 0,
        Partial = 1,
        Normal = 2,
        Perfect = 3
    }
    
    private StatBlock m_DungeonStatBlock;
    private List<ScriptableAbility> m_DungeonRequiredAbilities= new List<ScriptableAbility>();

    public AbstractDungeon(StatBlock statBlock, List<ScriptableAbility> dungeonRequiredAbilities)
    {
        m_DungeonStatBlock.SetStats(statBlock);
        m_DungeonRequiredAbilities = dungeonRequiredAbilities;
    }

    public DungeonClearResult ClearDungeon(StatBlock partyStats, List<ScriptableAbility> partyAbilities)
    {
        var abilitiesCleared = m_DungeonRequiredAbilities.Except(partyAbilities).Any();
        var statsCleared = m_DungeonStatBlock.CompareStats(partyStats);
        
        if (statsCleared && abilitiesCleared) { return DungeonClearResult.Perfect; }
        if (statsCleared) { return DungeonClearResult.Normal; }
        if (abilitiesCleared) { return DungeonClearResult.Partial; }
        return DungeonClearResult.Fail;
    }
    
}
