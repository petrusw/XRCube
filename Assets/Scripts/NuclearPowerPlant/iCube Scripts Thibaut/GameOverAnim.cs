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
    public class GameOverAnim : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private List<GameObject> explosions;
        [SerializeField] private float timeBetweenExplosions;
        #endregion

        #region PRIVATE FIELDS
        #endregion

        #region PUBLIC PROPERTIES
        public static GameOverAnim instance;
        #endregion

        #region PUBLIC FUNCTIONS

        public void ExplosionAnimation()
        {
         
            StartCoroutine("Boom");
           
            
        }

        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS
        private void Awake()
        {
            SetAsSingleton();
        }

        private void SetAsSingleton()
        {
            if (instance)
                Destroy(this);
            else
                instance = this;
        }

        private IEnumerator Boom()
        {
            for (int i = 0; i < explosions.Count; i++)
            {
                explosions[i].SetActive(true);
                yield return new WaitForSeconds(timeBetweenExplosions);
            }
        }
        #endregion


    }
}
