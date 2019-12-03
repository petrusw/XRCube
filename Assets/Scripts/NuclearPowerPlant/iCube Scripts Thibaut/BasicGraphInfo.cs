//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using PetrusGames.NuclearPlant.Managers.Data;
using System.Collections.Generic;
using ThibautPetit;
using UnityEngine;


namespace PetrusGames
{
    public abstract class BasicGraphInfo : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private EnergyInfo energyInfo;
        [SerializeField] private ReceiverIDCheck idCheck;
        [SerializeField] protected ElementPosition elemPos;
        #endregion

        #region PRIVATE FIELDS
        private float baseEfficiency;
        private float efficientyLostPerDestroyedElement;
        private float efficiencyLostPerWrongElement;
        private float efficiencyLostPerUnderchargeTick;
        [SerializeField] private int gameTimeInMinutes;

        private List<float> scores = new List<float>();
        private float timeToAddEfficiency;
        private float remainingTimer;
        protected float currentEfficiency;
        private int minutesPassed = 0;

        private bool isCounting = true;

        public List<float> Scores { get => scores; private set => scores = value; }
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

        public virtual void OnEnable()
        {
            energyInfo.LowEnergyRangeUpdate += LowEnergyRangeHandler;
            idCheck.WrongElementDetected += WrongElementHandler;
        }

        private void WrongElementHandler()
        {
            currentEfficiency -= efficiencyLostPerWrongElement;
        }

        private void LowEnergyRangeHandler()
        {
            currentEfficiency -= efficiencyLostPerUnderchargeTick;
        }

        protected void ElemDestroyedHandler()
        {
            currentEfficiency -= efficientyLostPerDestroyedElement;
        }

        public virtual void OnDisable()
        {
            energyInfo.LowEnergyRangeUpdate -= LowEnergyRangeHandler;
            idCheck.WrongElementDetected += WrongElementHandler;
        }

        public virtual void Start()
        {
            timeToAddEfficiency = DataManager.Instance.TimeToAddEfficiency;
            baseEfficiency = DataManager.Instance.BaseEfficiency;
            efficientyLostPerDestroyedElement = DataManager.Instance.EfficientyLostPerDestroyedElement;
            efficiencyLostPerWrongElement = DataManager.Instance.EfficiencyLostPerWrongElement;
            efficiencyLostPerUnderchargeTick = DataManager.Instance.EfficiencyLostPerUnderchargeTick;
            remainingTimer = timeToAddEfficiency;
            currentEfficiency = baseEfficiency;
            scores.Add(currentEfficiency);
        }

        public virtual void Update()
        {
            if (isCounting)
                CountDown();
        }

        private void CountDown()
        {
            remainingTimer -= Time.deltaTime;
            if (remainingTimer <= 0)
            {
                ResetTimer();
            }
        }

        private void ResetTimer()
        {
            remainingTimer = timeToAddEfficiency;

            if (currentEfficiency <= 0)
                currentEfficiency = 0;

            Scores.Add(currentEfficiency);
            currentEfficiency = baseEfficiency;
            minutesPassed++;

            //if (minutesPassed >= gameTimeInMinutes)
            //    isCounting = false;
        }
        #endregion
    }
}
