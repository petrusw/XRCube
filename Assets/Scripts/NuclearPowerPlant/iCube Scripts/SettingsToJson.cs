//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PetrusGames.HelperLibrary;

namespace PetrusGames.NuclearPlant
{
    public class SettingsToJson : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        
        #endregion

        #region PRIVATE FIELDS
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS

        public void SaveSettings()
        {

            var st = HelperLibrary.Json.JsonREadWriteData.Instance.WriteJsonToString(jsonDataObject.Instance.jsonDataClasses);

            HelperLibrary.Json.JsonREadWriteData.Instance.WriteJsonStringToFile(st, jsonDataObject.Instance.DataPath);
        }

        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

          // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        #endregion


    }
}
