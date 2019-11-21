//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



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
        [SerializeField] private float baseEfficiency;
        [SerializeField] private float efficientyLostPerDestroyedElement;
        [SerializeField] private float efficiencyLostPerWrongElement;
        [SerializeField] private float efficiencyLostPerUnderchargeTick;
        [SerializeField] private int gameTimeInMinutes;

        private List<float> scores = new List<float>();
        private float timer = 5f;
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

        private void Start()
        {
            remainingTimer = timer;
            currentEfficiency = baseEfficiency;
            scores.Add(currentEfficiency);
        }

        private void Update()
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
            remainingTimer = timer;

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
