//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using PetrusGames.NuclearPlant.Managers.Data;
using UnityEngine;


namespace PetrusGames
{
    public class ExctinctorGraphInfo : BasicGraphInfo
    {
        #region SERIALIZED FIELDS
        [SerializeField] ExtinguishedFireInfo fireInfo;
        private float efficiencyLostPerFlameTick;
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
            efficiencyLostPerFlameTick = DataManager.Instance.EfficiencyLostPerFlameTick;
        }

        public override void OnEnable()
        {
            base.OnEnable();
            elemPos.onPlayer3ElemDestroyed += ElemDestroyedHandler;
            fireInfo.onFireTick += OnFireTickHandler;
        }

        public override void OnDisable()
        {
            base.OnDisable();
            elemPos.onPlayer3ElemDestroyed -= ElemDestroyedHandler;
            fireInfo.onFireTick -= OnFireTickHandler;
        }

        private void OnFireTickHandler()
        {
            currentEfficiency -= efficiencyLostPerFlameTick;
        }
        #endregion


    }
}
