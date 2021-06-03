using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurnBased
{
   void RegisterForTurns();
   void TurnStart();
   void TurnEnd();
}

public interface ISeasonBased
{
   void RegisterForSeasons();
   void SeasonStart();
   void SeasonEnd();
}
