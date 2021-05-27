using System.Collections;
using System.Collections.Generic;
using Game.GameLogic;
using UnityEngine;
using UnityEngine.Serialization;

public class Character : MonoBehaviour
{
    public readonly string className = "ClassName";
    public readonly string characterName = "CharacterName";

    public int strength { get; private set; }
    public int cunning { get; private set; }
    public int magic { get; private set; }
    public int faith { get; private set; }
    public int speed { get; private set; }

    private int m_Experience;

    public int experience
    {
        get => m_Experience;
        private set
        {
            m_Experience += value;
            if (m_Experience < GameConfig.instance.XpToLevel[Level]) return;
            m_Experience -= GameConfig.instance.XpToLevel[Level];
            Level++;
        }
    }

    private int m_Level;

    public int Level
    {
        get => m_Level;
        private set
        {
            if (value > m_Level)
            {
                AddAbilitiesForLevel(value);
                AddStatsForLevel(value);
                m_Level = value;
            }
        }
    }

    public List<ScriptableAbilityTemplate> Abilities;
    
    ScriptableCharacterTemplate characterTemplate;

    public Character(ScriptableCharacterTemplate template)
    {
        experience = 0;
        Level = 1;
        strength = template.startStrength;
        cunning = template.startCunning;
        magic = template.startMagic;
        faith = template.startFaith;
        speed = template.startSpeed;
    }

    // Add character at certain level
    public Character(ScriptableCharacterTemplate template, int level)
    {
        experience = 0;
        Level = level;
        strength += template.startStrength;
        cunning += template.startCunning;
        magic += template.startMagic;
        faith += template.startFaith;
        speed += template.startSpeed;
    }

    private void AddStatsForLevel(int level)
    {
        for (var i = Level; i <= level; i++)
        {
            strength += characterTemplate.perLvlStrength;
            cunning += characterTemplate.perLvlCunning;
            magic += characterTemplate.perLvlMagic;
            faith += characterTemplate.perLvlFaith;
            speed += characterTemplate.perLvlSpeed;
        }
    }

    private void AddAbilitiesForLevel(int level)
    {
        for (var i = Level; i <= level; i++)
            if (characterTemplate.abilitiesAtLevels[level] != null)
                Abilities.Add(characterTemplate.abilitiesAtLevels[level]);
    }
}