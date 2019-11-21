//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace PetrusGames
{
    public class GameTimerDisplay : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private List<TextMeshPro> tmp;
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

        private void Update()
        {
            UpdateTimer();
        }

        private void UpdateTimer()
        {
            float currentTime = GameTimer.instance.RemainingGameTime;

            foreach (var text in tmp)
            {
                text.text = GetTime(currentTime);
            }

        }

        private string GetTime(float currentTime)
        {
            bool showZero = false;

            int seconds = Convert.ToInt32(currentTime % 60);
            int minutes = Convert.ToInt32((currentTime - seconds) / 60);

            if (seconds == 60)
            {
                minutes++;
                seconds = 0;
            }

            if (seconds < 10)
                showZero = true;

            if(minutes < 1)
            {
                foreach (var mesh in tmp)
                {
                    mesh.faceColor = Color.red;
                    mesh.outlineColor = Color.red;
                }
            }


            return  minutes + " : " + (showZero ? "0" : "") + seconds;
        }



        #endregion


    }
}
