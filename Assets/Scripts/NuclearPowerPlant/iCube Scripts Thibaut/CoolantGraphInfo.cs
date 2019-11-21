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


namespace PetrusGames
{
    public class CoolantGraphInfo : BasicGraphInfo
    {
        #region SERIALIZED FIELDS
        [SerializeField] private List<HeatInfo> heatInfos = new List<HeatInfo>();
        [SerializeField] private float efficiencyLostPerOverheatTick;
        #endregion

        #region PRIVATE FIELDS
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS
        public override void OnEnable()
        {
            base.OnEnable();
            elemPos.onPlayer1ElemDestroyed += ElemDestroyedHandler;
            foreach (var info in heatInfos)
            {
                info.overHeatEvent += OverHeatHandler;
            }
        }

        private void OverHeatHandler()
        {
            currentEfficiency -= efficiencyLostPerOverheatTick;
        }

        public override void OnDisable()
        {
            base.OnDisable();
            elemPos.onPlayer1ElemDestroyed -= ElemDestroyedHandler;
            foreach (var info in heatInfos)
            {
                info.overHeatEvent -= OverHeatHandler;
            }
        }
        #endregion


    }
}
