using PetrusGames;
using PetrusGames.NuclearPlant.Managers.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ThibautPetit
{
    public class HeatInfo : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private ReceiverIDCheck iDCheck;
        [SerializeField] private EnergyInfo energyInfo;
        [SerializeField] private DifficultyIncrease difficultyIncrease;
        #endregion

        #region PRIVATE FIELDS
        private float currentHeat;
        private float maxHeat;
        private float heatThreshhold;
        private float heatGainPerSecond;
        private float heatGainPerEnergySurcharge;
        private float heatLossPerCoolDownTick;
        private float heatGainPerWrongElement;

        private bool isOverHeating = false;
        private float overHeatTick;

        private bool isCoolingDown = false;
        private float coolDownTick;
        #endregion

        #region PUBLIC PROPERTIES
        public float CurrentHeat
        {
            get { return currentHeat; }
            private set
            {
                currentHeat = value;
                HeatCheck();
                currentHeatUpdate?.Invoke(currentHeat);
            }
        }
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        public event Action<object> overHeatEvent;
        public event Action<object> stopOverHeatEvent;
        public event Action<float> currentHeatUpdate;
        #endregion

        #region PRIVATE FUNCTIONS

        private void OnEnable()
        {
            energyInfo.SurchargingUpdate += SurchargingHandler;
            iDCheck.WrongElementDetected += WrongElementDetectedHandler;
            difficultyIncrease.onDifficultyIncrease += DiffcultyIncreaseHandler;
            
        }


        private void OnDisable()
        {
            energyInfo.SurchargingUpdate -= SurchargingHandler;
            difficultyIncrease.onDifficultyIncrease -= DiffcultyIncreaseHandler;
            iDCheck.WrongElementDetected -= WrongElementDetectedHandler;
        }

        private void DiffcultyIncreaseHandler(BoostValues obj)
        {
            heatGainPerSecond += obj.heatIncreaseRateBoostValue;
        }

        private void WrongElementDetectedHandler()
        {
            CurrentHeat += heatGainPerWrongElement;
        }

        private void SurchargingHandler()
        {
            CurrentHeat += heatGainPerEnergySurcharge;
        }

        void Start()
        {
            maxHeat = DataManager.Instance.MaxHeat;
            heatThreshhold = DataManager.Instance.HeatThreshhold;
            heatGainPerSecond = DataManager.Instance.HeatGainPerSecond;
            heatGainPerEnergySurcharge = DataManager.Instance.HeatGainPerEnergySurcharge;
            heatLossPerCoolDownTick = DataManager.Instance.HeatLossPerCoolDownTick;
            heatGainPerWrongElement = DataManager.Instance.HeatGainPerWrongElement;
            coolDownTick = DataManager.Instance.CoolDownTick;
            overHeatTick = DataManager.Instance.OverHeatTick;
            StartCoroutine("GainHeat");
        }

        void Update()
        {
            if (isOverHeating)
                OverHeat();

            if (isCoolingDown)
                CoolDown();
        }

        private IEnumerator GainHeat()
        {
            CurrentHeat += heatGainPerSecond;
            yield return new WaitForSeconds(1);
            StartCoroutine("GainHeat");
        }

        private void HeatCheck()
        {
            if (currentHeat < 0)
                CurrentHeat = 0;
            else if (currentHeat > maxHeat)
                CurrentHeat = maxHeat;

            if (currentHeat >= heatThreshhold && !isOverHeating)
                isOverHeating = true;
            else if (currentHeat < heatThreshhold && isOverHeating)
            {
                isOverHeating = false;
                stopOverHeatEvent?.Invoke(this);
            }
        }

        private void OverHeat()
        {
            overHeatTick -= Time.deltaTime;
            if (overHeatTick <= 0)
            {
                overHeatEvent?.Invoke(this);
                overHeatTick = 1f;
            }
        }

        private void CoolDown()
        {
            coolDownTick -= Time.deltaTime;
            if (coolDownTick <= 0)
            {
                CurrentHeat -= heatLossPerCoolDownTick;
                coolDownTick = 1f;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Cooler"))
                isCoolingDown = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Cooler"))
                isCoolingDown = false;
        }
        #endregion
    }
}
