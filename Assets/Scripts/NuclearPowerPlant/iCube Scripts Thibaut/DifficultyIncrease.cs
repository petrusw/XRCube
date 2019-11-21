//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using PetrusGames.NuclearPlant.Managers.Data;
using System;
using UnityEngine;


namespace PetrusGames
{
    public class DifficultyIncrease : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        #endregion

        #region PRIVATE FIELDS
        private float converyorBeltSpeedBoost;
        private float flameSpawnRateBoost;
        private float heatIncreaseRateBoost;

        private float difficultyIncreaseTimer;
        private float remainingTime;

        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        public event Action<BoostValues> onDifficultyIncrease;
        #endregion

        #region PRIVATE FUNCTIONS

        private void Start()
        {
            converyorBeltSpeedBoost = DataManager.Instance.ConveryorBeltSpeedBoost;
            flameSpawnRateBoost = DataManager.Instance.FlameSpawnRateBoost;
            heatIncreaseRateBoost = DataManager.Instance.HeatIncreaseRateBoost;
            difficultyIncreaseTimer = DataManager.Instance.DifficultyIncreaseTimer;
            remainingTime = difficultyIncreaseTimer;
        }

        private void Update()
        {
            CountDown();
        }

        private void CountDown()
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0)
            {
                IncreaseDifficulty();
                remainingTime = difficultyIncreaseTimer;
            }
        }

        private void IncreaseDifficulty()
        {
            onDifficultyIncrease?.Invoke(new BoostValues()
            {
                converyorBeltSpeedBoostValue = converyorBeltSpeedBoost,
                flameSpawnRateBoostValue = flameSpawnRateBoost,
                heatIncreaseRateBoostValue = flameSpawnRateBoost
            });
        }
        #endregion
    }

    public class BoostValues
    {
        public float converyorBeltSpeedBoostValue;
        public float flameSpawnRateBoostValue;
        public float heatIncreaseRateBoostValue;
    }
}
