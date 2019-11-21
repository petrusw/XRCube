﻿//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using ThibautPetit;
using UnityEngine;


namespace PetrusGames
{
    public class ConveyorBeltArrowDisplay : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private ConveyorBelt conveyorBelt;
        [SerializeField] private GameObject RightArrow;
        [SerializeField] private GameObject LeftArrow;
        #endregion

        #region PRIVATE FIELDS
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS
        private void OnEnable()
        {
            conveyorBelt.onChangeDirection += ChangeDirectionHandler;
        }

        private void OnDisable()
        {
            conveyorBelt.onChangeDirection -= ChangeDirectionHandler;
        }

        private void ChangeDirectionHandler(bool obj)
        {
            //gameObject.transform.rotation = Quaternion.Euler(new Vector3(180, 180, obj ? 180 : 0));
            if (obj)
            {
                LeftArrow.SetActive(true);
                RightArrow.SetActive(false);
            }
            else
            {
                LeftArrow.SetActive(false);
                RightArrow.SetActive(true);
            }
        }
        #endregion


    }
}
