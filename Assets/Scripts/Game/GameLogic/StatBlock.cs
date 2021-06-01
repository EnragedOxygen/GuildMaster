using System;
using System.Collections;
using System.Collections.Generic;
using Game.GameLogic;
using UnityEngine;


[Serializable] 
public class StatBlock 
{
    public int strength { get; set; }
    public int cunning { get; set; }
    public int magic { get; set; }
    public int faith { get; set; }
    public int speed { get; set; }

    public StatBlock()
    {
        
    }
    public StatBlock(StatBlock statBlock)
    {
        SetStats(statBlock);
    }

    public StatBlock(ScriptableCharacterTemplate characterTemplate) : this(characterTemplate.startStats)
    {
    }

    public void SetStats(StatBlock statBlock)
    {
        strength = statBlock.strength;
        cunning = statBlock.cunning;
        magic = statBlock.magic;
        faith = statBlock.faith;
        speed = statBlock.speed;
    }

    public void SetStats(ScriptableCharacterTemplate template)
    {
        SetStats(template.startStats);
    }

    public void AddStats(StatBlock statBlock)
    {
        strength += statBlock.strength;
        cunning += statBlock.cunning;
        magic += statBlock.magic;
        faith += statBlock.faith;
        speed += statBlock.speed;
    }
    
    public void RemoveStats(StatBlock statBlock)
    {
        strength -= statBlock.strength;
        cunning -= statBlock.cunning;
        magic -= statBlock.magic;
        faith -= statBlock.faith;
        speed -= statBlock.speed;
    }
    
/// <summary>
/// Check if every stat of argument is larger than or equal to this statBlock
/// </summary>
/// <param name="statBlock"></param>
/// <returns></returns>
    public bool CompareStats(StatBlock statBlock)
    {
        if (this.strength <= statBlock.strength &&
            this.cunning <= statBlock.cunning &&
            this.magic <= statBlock.magic &&
            this.faith <= statBlock.faith &&
            this.speed <= statBlock.speed)
            return true;
        else
            return false;
    }

}
