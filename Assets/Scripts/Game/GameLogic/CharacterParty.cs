using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Game.GameLogic;

public class CharacterParty
{
    public readonly String partyName="partyName";
    public StatBlock partyStatBlock = new StatBlock();
    public List<ScriptableAbility> partyAbilities = new List<ScriptableAbility>();

    public CharacterParty(IReadOnlyCollection<Character> characters)
    {
        foreach (var character in characters)
        {
            partyStatBlock.AddStats(character.statBlock);
            partyAbilities.AddRange(character.Abilities);
        }
        // We get average of characters speeds to get party speed
        partyStatBlock.speed /= characters.Count;
    }
}
