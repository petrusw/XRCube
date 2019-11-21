//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PetrusGames
{
    public class ConveyorBeltFailCollider : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        #endregion

        #region PRIVATE FIELDS
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        public event Action onConveyorBeltFail;
        #endregion

        #region PRIVATE FUNCTIONS

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Element"))
                onConveyorBeltFail?.Invoke();
        }
        #endregion


    }
}
