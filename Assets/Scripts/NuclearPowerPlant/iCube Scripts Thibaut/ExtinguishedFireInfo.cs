//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System;
using UnityEngine;


namespace PetrusGames
{
    public class ExtinguishedFireInfo : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        public static ExtinguishedFireInfo instance;
        #endregion

        #region PRIVATE FIELDS
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS

        public void FireTick()
        {
            onFireTick?.Invoke();
        }

        #endregion

        #region EVENTS
        public event Action onFireTick;
        #endregion

        #region PRIVATE FUNCTIONS

        private void Awake()
        {
            if (instance)
                Destroy(this);
            else
                instance = this;
        }
        #endregion


    }
}
