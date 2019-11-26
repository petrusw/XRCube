//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


using System;
using System.Collections;
using System.Collections.Generic;
using ThibautPetit;
using UnityEngine;


namespace PetrusGames.NuclearPlant.Managers.Data.Json
{
    [Serializable]
    public class JsonDataClass 
    {
        #region PUBLIC FIELDS
        //public List<GameObject> receiverIDCheckObjects;
        //public HeatInfo heathInfo;
        //public List<GameObject> gameObjectsFire;
        //public List<GameObject> gameObjectsWater;
        public float score;
        public float health;
        public float energyGainPerGoodElement;
        public float energyLossPerWrongElement;
        public float energyMaxThreshold;
        public float energyMinThreshold;
        public float energyLossPerSecond;
        public float maxEnergy;
        public float goodRangeTick = 1f;
        public float surchargeTick = 1f;
        public float maxHeat;
        public float heatThreshhold;
        public float heatGainPerSecond;
        public float heatGainPerEnergySurcharge;
        public float heatLossPerCoolDownTick;
        public float heatGainPerWrongElement;
        public float overHeatTick = 1f;
        public float coolDownTick = 1f;
        public float extinguisherSpeed;
        public float chargesCoolDown;
        public float converyorBeltSpeed;
        public float coolantSpeed;
        public float elementSpawnTimer;
        public float fireSpawnerTimerX;
        public float fireSpawnerTimerY;
        public float clawsPeed;
        public float damagePerElementExplosion;
        public float damagePerElementFall;
        public float damagePerOverheatTick;
        public float damagePerWrongElement;
        public float damagePerOverchargeTick;
        public float converyorBeltSpeedBoost;
        public float flameSpawnRateBoost;
        public float heatIncreaseRateBoost;
        public float difficultyIncreaseTimer;
        public float baseEfficiency;
        public float efficientyLostPerDestroyedElement;
        public float efficiencyLostPerWrongElement;
        public float efficiencyLostPerUnderchargeTick;
        public float efficiencyLostPerConveyorBeltFail;
        public float efficiencyLostPerFlameTick;
        public float efficiencyLostPerOverheatTick;
        public float timeToDrawGraph;
        public float timeToAddEfficiency;
        public float fireDamage;
        public float fireTick;
        public float gameTime;



        #endregion

    }
}
