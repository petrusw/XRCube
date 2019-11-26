//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using PetrusGames.NuclearPlant.Managers.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PetrusGames
{
    public class ConveyorBeltGraphInfo : BasicGraphInfo
    {
        #region SERIALIZED FIELDS
        [SerializeField] private ConveyorBeltFailCollider failCollider;
        private float efficiencyLostPerConveyorBeltFail;
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

        public override void Start()
        {
            base.Start();
            efficiencyLostPerConveyorBeltFail = DataManager.Instance.EfficiencyLostPerConveyorBeltFail;
        }

        public override void OnEnable()
        {
            base.OnEnable();
            failCollider.onConveyorBeltFail += ConveyorBeltFailHandler;
            elemPos.onPlayer2ElemDestroyed += ElemDestroyedHandler;
        }

        private void ConveyorBeltFailHandler()
        {
            currentEfficiency -= efficiencyLostPerConveyorBeltFail;
        }

        public override void OnDisable()
        {
            base.OnDisable();
            failCollider.onConveyorBeltFail -= ConveyorBeltFailHandler;
            elemPos.onPlayer2ElemDestroyed -= ElemDestroyedHandler;
        }
        #endregion
    }
}
