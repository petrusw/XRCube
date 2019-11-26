//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|                                                                             This Library is made by Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using PetrusGames.NuclearPlant.Managers.Data.Json;

namespace PetrusGames.HelperLibrary.Json
{
    public class JsonREadWriteData : MonoBehaviour
    {
        public static JsonREadWriteData Instance = new JsonREadWriteData(); 
        #region SERIALIZED FIELDS
        [Header("Json File To Read Write")]
        [SerializeField] private string jsonFile;
        #endregion

        #region PRIVATE FIELDS
        private List<JsonDataClass> jsonItems = new List<JsonDataClass>();
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        /// <summary>
        /// Read the objects from the Json file and create a list of objects.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public List<JsonDataClass> ReadJsonItem(string Path)
        {
            List<JsonDataClass> items = new List<JsonDataClass>();

            string st = File.ReadAllText(Application.dataPath + Path);
            

            JsonDataClass[] jsonsData = PetrusGames.HelperLibrary.Json.JsonHelper.FromJson<JsonDataClass>(st);
          

            int nr = jsonsData.Length;
            for(var i = 0;i< nr; i++)
            {
                JsonDataClass item = new JsonDataClass();
                item.chargesCoolDown = jsonsData[i].chargesCoolDown;
                item.clawsPeed = jsonsData[i].clawsPeed;
                item.converyorBeltSpeed = jsonsData[i].converyorBeltSpeed;
                item.coolantSpeed = jsonsData[i].coolantSpeed;
                item.coolDownTick = jsonsData[i].coolDownTick;
                item.damagePerElementExplosion = jsonsData[i].damagePerElementExplosion;
                item.damagePerElementFall = jsonsData[i].damagePerElementFall;
                item.damagePerOverchargeTick = jsonsData[i].damagePerOverchargeTick;
                item.damagePerOverheatTick = jsonsData[i].damagePerOverheatTick;
                item.damagePerWrongElement = jsonsData[i].damagePerWrongElement;
                item.elementSpawnTimer = jsonsData[i].elementSpawnTimer;
                item.energyGainPerGoodElement = jsonsData[i].energyGainPerGoodElement;
                item.energyLossPerSecond = jsonsData[i].energyLossPerSecond;
                item.energyLossPerWrongElement = jsonsData[i].energyLossPerWrongElement;
                item.energyMaxThreshold = jsonsData[i].energyMaxThreshold;
                item.energyMinThreshold = jsonsData[i].energyMinThreshold;
                item.extinguisherSpeed = jsonsData[i].extinguisherSpeed;
                item.fireSpawnerTimerX = jsonsData[i].fireSpawnerTimerX;
                item.fireSpawnerTimerY = jsonsData[i].fireSpawnerTimerY;
                //item.gameObjectsFire = jsonsData[i].gameObjectsFire;
                //item.gameObjectsWater = jsonsData[i].gameObjectsWater;
                item.goodRangeTick = jsonsData[i].goodRangeTick;
                item.health = jsonsData[i].health;
                item.heatGainPerEnergySurcharge = jsonsData[i].heatGainPerEnergySurcharge;
                item.heatGainPerSecond = jsonsData[i].heatGainPerSecond;
                item.heatGainPerWrongElement = jsonsData[i].heatGainPerWrongElement;
                //item.heathInfo = jsonsData[i].heathInfo;
                item.heatLossPerCoolDownTick = jsonsData[i].heatLossPerCoolDownTick;
                item.heatThreshhold = jsonsData[i].heatThreshhold;
                item.maxEnergy = jsonsData[i].maxEnergy;
                item.maxHeat = jsonsData[i].maxHeat;
                item.overHeatTick = jsonsData[i].overHeatTick;
                //item.receiverIDCheckObjects = jsonsData[i].receiverIDCheckObjects;
                item.score = jsonsData[i].score;
                item.surchargeTick = jsonsData[i].surchargeTick;
                item.converyorBeltSpeedBoost = jsonsData[i].converyorBeltSpeedBoost;
                item.flameSpawnRateBoost = jsonsData[i].flameSpawnRateBoost;
                item.heatIncreaseRateBoost = jsonsData[i].heatIncreaseRateBoost;
                item.difficultyIncreaseTimer = jsonsData[i].difficultyIncreaseTimer;
                item.baseEfficiency = jsonsData[i].baseEfficiency;
                item.efficiencyLostPerConveyorBeltFail = jsonsData[i].efficiencyLostPerConveyorBeltFail;
                item.efficiencyLostPerFlameTick = jsonsData[i].efficiencyLostPerFlameTick;
                item.efficiencyLostPerOverheatTick = jsonsData[i].efficiencyLostPerOverheatTick;
                item.efficiencyLostPerUnderchargeTick = jsonsData[i].efficiencyLostPerUnderchargeTick;
                item.efficiencyLostPerWrongElement = jsonsData[i].efficiencyLostPerWrongElement;
                item.efficientyLostPerDestroyedElement = jsonsData[i].efficientyLostPerDestroyedElement;
                item.gameTime = jsonsData[i].gameTime;
                item.timeToDrawGraph = jsonsData[i].timeToDrawGraph;
                item.timeToAddEfficiency = jsonsData[i].timeToAddEfficiency;
                item.fireDamage = jsonsData[i].fireDamage;
                item.fireTick = jsonsData[i].fireTick;

                items.Add(item);
            }
            return items;
        }
        /// <summary>
        /// Write a list of json objects to a string that could be used to write to file. 
        /// </summary>
        /// <param name="jsonItems"></param>
        public string WriteJsonToString(List<JsonDataClass> jsonItems)
        {
            string tempJson = string.Empty;
            
            tempJson = "{";
            tempJson += '"';
            tempJson += "Items";
            tempJson += '"';
            tempJson += ':';
            tempJson += '[';

            int nr = 0;
            foreach (var item in jsonItems)
            {
               
                tempJson += JsonUtility.ToJson(item);
                if ( nr < jsonItems.Count -1 )
                {
                    tempJson += ",";
                }
                nr++;

            }
            tempJson += ']';

            tempJson += "}";
            //tempJson += JsonUtility.ToJson(jsonItems);
            return tempJson;
        }

        /// <summary>
        /// Write a json string to a json file in the Resources folder
        /// </summary>
        /// <param name="JasonString"></param>
        /// <param name="path"></param>
        public void WriteJsonStringToFile(string JasonString,string path)
        {
            using ( FileStream fs = new FileStream(Application.dataPath + path, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(fs))
                {
                    writer.Write(JasonString);
                }
            }

            #if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
            #endif
        }
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

          // Start is called before the first frame update
    void Start()
    {
        if(Instance != null)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        #endregion


    }
}
