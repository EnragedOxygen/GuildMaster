using System.Collections;
using System.Collections.Generic;
using Game.GameLogic;
using UnityEngine;
using UnityEngine.Serialization;

public class Character
{
    public readonly string className = "ClassName";
    public readonly string characterName = "CharacterName";

    public StatBlock statBlock;

    private int m_Experience;

    public int experience
    {
        get => m_Experience;
        set
        {
            m_Experience = value;
            if (m_Experience < GameConfig.instance.XpToLevel[level]) return;
            m_Experience -= GameConfig.instance.XpToLevel[level];
            LevelUp();
        }
    }
    public int level {  get; private set; }

    public List<ScriptableAbility> Abilities;
    
    ScriptableCharacterTemplate characterTemplate;

    public Character(ScriptableCharacterTemplate template)
    {
        experience = 0;
        level = 1;
        statBlock=new StatBlock(template);
        if (characterTemplate.abilitiesAtLevels[level] != null)
            Abilities.Add(characterTemplate.abilitiesAtLevels[level]);
    }

    // Add character at certain level
    public Character(ScriptableCharacterTemplate template, int level) : this(template)
    {
       for (int i = this.level; i<level ; i++)
           LevelUp();
    }

    public void LevelUp()
    {
        level++;
        statBlock.AddStats(characterTemplate.perLvlStats);
        if (characterTemplate.abilitiesAtLevels[level] != null)
            Abilities.Add(characterTemplate.abilitiesAtLevels[level]);
    }
}