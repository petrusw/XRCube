//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections.Generic;
using UnityEngine;


namespace PetrusGames
{
    public class ScoreListsGetter : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private List<BasicGraphInfo> graphInfos;
        #endregion

        #region PRIVATE FIELDS
        
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        public List<List<float>> GetLists()
        {
            List<List<float>> scoresList = new List<List<float>>();

            foreach (var info in graphInfos)
            {
                scoresList.Add(info.Scores);
            }

            return scoresList;
        }
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

        #endregion


    }
}
