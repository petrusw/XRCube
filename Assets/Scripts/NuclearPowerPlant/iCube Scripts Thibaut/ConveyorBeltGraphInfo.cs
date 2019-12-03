//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using PetrusGames.NuclearPlant.Managers.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using ThibautPetit;
using UnityEngine;


namespace PetrusGames
{
    public class ConveyorBeltGraphInfo : BasicGraphInfo
    {
        #region SERIALIZED FIELDS
        [SerializeField] private ConveyorBeltFailCollider failCollider;

        #endregion

        #region PRIVATE FIELDS
        private float efficiencyLostPerConveyorBeltFail;
        private float efficiencyLostPerSecondOnBelt;
        private int elemOnBelt;
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
            efficiencyLostPerSecondOnBelt = DataManager.Instance.EfficiencyLostPerSecondOnBelt;
            FindObjectOfType<ConveyorBelt>().onBeltCollide += BeltCollideHandler;
        }

        private void BeltCollideHandler(bool obj)
        {
            if (obj)
                elemOnBelt++;
            else
                elemOnBelt--;
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

        public override void Update()
        {
            base.Update();
            currentEfficiency -= efficiencyLostPerSecondOnBelt * Time.deltaTime;
        }

        #endregion
    }
}
