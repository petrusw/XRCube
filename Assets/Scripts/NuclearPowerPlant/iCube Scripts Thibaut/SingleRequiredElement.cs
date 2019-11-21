//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using PetrusGames.NuclearPlant.Managers.Data;
using System.Collections.Generic;
using ThibautPetit;
using UnityEngine;


namespace PetrusGames
{
    public class SingleRequiredElement : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private List<ReceiverIDCheck> idChecks;
        #endregion

        #region PRIVATE FIELDS
        private float timeToResetElement;
        private float currentTimer;

        #endregion

        #region PUBLIC PROPERTIES
        public float CurrentTimer { get => currentTimer; private set => currentTimer = value; }
        public float TimeToResetElement { get => timeToResetElement; set => timeToResetElement = value; }
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

        private void OnEnable()
        {
            foreach (var idCheck in idChecks)
            {
                idCheck.CorrectElementDetected += CorretElementHandler;
                idCheck.WrongElementDetected += WrongElementHandler;
            }
        }

        private void OnDisable()
        {
            foreach (var idCheck in idChecks)
            {
                idCheck.CorrectElementDetected -= CorretElementHandler;
                idCheck.WrongElementDetected -= WrongElementHandler;
            }
        }

        private void WrongElementHandler()
        {
            ResetRequiredID();
        }

        private void CorretElementHandler()
        {
            ResetRequiredID();
        }

        private void Start()
        {
            TimeToResetElement = DataManager.Instance.TimeToResetElement;
            CurrentTimer = TimeToResetElement;
            Invoke("ResetRequiredID", 0.5f);
        }

        private void Update()
        {
            UpdateRequiredID();
        }

        private void UpdateRequiredID()
        {
            CurrentTimer -= Time.deltaTime;
            if (CurrentTimer <= 0)
            {
                ResetRequiredID();
            }
        }

        private void ResetRequiredID()
        {
            int random = Random.Range(0, idChecks.Count);

            for (int i = 0; i < idChecks.Count; i++)
            {
                if (i == random)
                {
                    idChecks[i].ResetRequiredID();
                    idChecks[i].RequiresElement = true;
                }
                else
                {
                    idChecks[i].RequiresElement = false;
                }
            }

            CurrentTimer = TimeToResetElement;
        }

        #endregion


    }
}
