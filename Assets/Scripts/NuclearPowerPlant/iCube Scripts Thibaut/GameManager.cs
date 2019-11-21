//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PetrusGames
{
    public class GameManager : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        #endregion

        #region PRIVATE FIELDS
        #endregion

        #region PUBLIC PROPERTIES
        public static GameManager instance;
        #endregion

        #region PUBLIC FUNCTIONS

        public void StartGame()
        {
            GameTimer.instance.StartTime();
        }

        public void EndGame()
        {

        }

        public void GameOver()
        {
            GameOverAnim.instance.ExplosionAnimation();
        }

        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

        private void Awake()
        {
            SetAsSingleton();
        }

        private void Start()
        {
            StartGame();
        }

        private void SetAsSingleton()
        {
            if (instance)
                Destroy(this);
            else
                instance = this;
        }

        #endregion


    }
}
