//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections.Generic;
using UnityEngine;


namespace PetrusGames
{
    public class ElementTimerDisplay : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private List<Animator> anim;
        //[SerializeField] private ReceiverIDCheck idCheck;
        [SerializeField] private SingleRequiredElement requiredElement;
        #endregion

        #region PRIVATE FIELDS
        private float MaxTimer;
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

        private void Start()
        {
            //MaxTimer = idCheck.TimeToResetElement;
        }

        private void Update()
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            float timePercentage = 1 - (requiredElement.CurrentTimer / requiredElement.TimeToResetElement);

            foreach (var item in anim)
            {
                item.SetFloat("CurrentTime", timePercentage);
            }

        }
        #endregion


    }
}
