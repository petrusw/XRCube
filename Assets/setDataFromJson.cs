using PetrusGames.HelperLibrary.Json;
using PetrusGames.NuclearPlant.Managers.Data;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class setDataFromJson : MonoBehaviour
{
    [SerializeField] private DataManager dataManager;
    [SerializeField] private string JsonPath;
    // Start is called before the first frame update
    void Awake()
    {
        var jsonDataObjects =  JsonREadWriteData.Instance.ReadJsonItem(JsonPath);


        
        dataManager.Health = jsonDataObjects[0].health;
        dataManager.ChargesCoolDown = jsonDataObjects[0].chargesCoolDown;
        dataManager.ClawSpeed = jsonDataObjects[0].clawsPeed;
        dataManager.ConveryorBeltSpeed = jsonDataObjects[0].converyorBeltSpeed;
        dataManager.ConveryorBeltSpeedBoost = jsonDataObjects[0].converyorBeltSpeedBoost;
        dataManager.CoolantSpeed = jsonDataObjects[0].coolantSpeed;
        dataManager.CoolDownTick = jsonDataObjects[0].coolDownTick;
        dataManager.DamagePerElementExplosion = jsonDataObjects[0].damagePerElementExplosion;
        dataManager.DamagePerElementFall = jsonDataObjects[0].damagePerElementFall;
        dataManager.DamagePerWrongElement = jsonDataObjects[0].damagePerWrongElement;
        dataManager.DamagePerOverheatTick = jsonDataObjects[0].damagePerOverheatTick;
        dataManager.DifficultyIncreaseTimer = jsonDataObjects[0].difficultyIncreaseTimer;
        dataManager.ElementSpawnTimer = jsonDataObjects[0].elementSpawnTimer;
        dataManager.EnergyGainPerGoodElement = jsonDataObjects[0].energyGainPerGoodElement;
        dataManager.EnergyLossPerSecond = jsonDataObjects[0].energyLossPerSecond;
        dataManager.EnergyLossPerWrongElement = jsonDataObjects[0].energyLossPerWrongElement;
        dataManager.EnergyMaxThreshold = jsonDataObjects[0].energyMaxThreshold;
        dataManager.EnergyMinThreshold = jsonDataObjects[0].energyMinThreshold;
        dataManager.ExtinguisherSpeed = jsonDataObjects[0].extinguisherSpeed;
        dataManager.FireSpawnerTimer = new Vector2(jsonDataObjects[0].fireSpawnerTimerX, jsonDataObjects[0].fireSpawnerTimerY);
        dataManager.FlameSpawnRateBoost = jsonDataObjects[0].flameSpawnRateBoost;
        dataManager.GoodRangeTick = jsonDataObjects[0].goodRangeTick;
        dataManager.HeatGainPerEnergySurcharge = jsonDataObjects[0].heatGainPerEnergySurcharge;
        dataManager.HeatGainPerSecond = jsonDataObjects[0].heatGainPerSecond;
        dataManager.HeatGainPerWrongElement = jsonDataObjects[0].heatGainPerWrongElement;
        dataManager.HeatIncreaseRateBoost = jsonDataObjects[0].heatIncreaseRateBoost;
        dataManager.HeatLossPerCoolDownTick = jsonDataObjects[0].heatLossPerCoolDownTick;
        dataManager.HeatThreshhold = jsonDataObjects[0].heatThreshhold;
        dataManager.MaxEnergy = jsonDataObjects[0].maxEnergy;
        dataManager.MaxHeat = jsonDataObjects[0].maxHeat;
        dataManager.OverHeatTick = jsonDataObjects[0].overHeatTick;
        dataManager.SurchargeTick = jsonDataObjects[0].surchargeTick;
        dataManager.BaseEfficiency = jsonDataObjects[0].baseEfficiency;
        dataManager.EfficiencyLostPerConveyorBeltFail = jsonDataObjects[0].efficiencyLostPerConveyorBeltFail;
        dataManager.EfficiencyLostPerFlameTick = jsonDataObjects[0].efficiencyLostPerFlameTick;
        dataManager.EfficiencyLostPerOverheatTick = jsonDataObjects[0].efficiencyLostPerOverheatTick;
        dataManager.EfficiencyLostPerUnderchargeTick = jsonDataObjects[0].efficiencyLostPerUnderchargeTick;
        dataManager.EfficiencyLostPerWrongElement = jsonDataObjects[0].efficiencyLostPerWrongElement;
        dataManager.EfficientyLostPerDestroyedElement = jsonDataObjects[0].efficientyLostPerDestroyedElement;
        dataManager.TimeToAddEfficiency = jsonDataObjects[0].timeToAddEfficiency;
        dataManager.TimeToDrawGraph = jsonDataObjects[0].timeToDrawGraph;
        dataManager.FireDamage = jsonDataObjects[0].fireDamage;
        dataManager.FireTick = jsonDataObjects[0].fireTick;
        dataManager.GameTime = jsonDataObjects[0].gameTime;

    }
}
