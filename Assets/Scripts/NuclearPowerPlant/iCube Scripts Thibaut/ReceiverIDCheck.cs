using AftahGames.NuclearSimulator;
using PetrusGames;
using PetrusGames.NuclearPlant.Objects.Elements;
using System;
using System.Collections.Generic;
using UnityEngine;



namespace ThibautPetit
{
    public class ReceiverIDCheck : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private List<RequiredElementColorDisplay> colorDisplay;
        [SerializeField] private List<ElementsDisplay> textDisplay;
        [SerializeField] private ParticleSystem particle;
        #endregion

        #region PRIVATE FIELDS
        private float timeToResetElement;
        private elemID requiredID;
        private float currentTimer;
        private bool requiresElement = false;
        #endregion

        #region PUBLIC PROPERTIES
        public elemID RequiredID { get => requiredID; }
        public float CurrentTimer { get => currentTimer; private set => currentTimer = value; }
        public float TimeToResetElement { get => timeToResetElement; private set => timeToResetElement = value; }

        public bool RequiresElement
        {
            get { return requiresElement; }
            set
            {
                requiresElement = value;
                UpdateParticles();
            }
        }
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        public event Action CorrectElementDetected;
        public event Action WrongElementDetected;
        #endregion

        #region PRIVATE FUNCTIONS

        void Start()
        {
            //timeToResetElement = DataManager.Instance.TimeToResetElement;
            //Invoke( "ResetRequiredID",1f);
            //CurrentTimer = timeToResetElement;
        }

        private void Update()
        {
            //UpdateRequiredID();
        }

        //private void UpdateRequiredID()
        //{
        //    CurrentTimer -= Time.deltaTime;
        //    if (CurrentTimer <= 0)
        //    {
        //        ResetRequiredID();
        //    }
        //}

        public void ResetRequiredID()
        {
            requiredID = GetRandomRequiredID();

            foreach (var display in colorDisplay)
            {
                display.ChangeColor(requiredID);
            }

            foreach (var text in textDisplay)
            {
                text.DisplayText(requiredID);
            }

            //  CurrentTimer = timeToResetElement;
        }

        private elemID GetRandomRequiredID()
        {
            return (elemID)UnityEngine.Random.Range(0, Enum.GetNames(typeof(elemID)).Length);
        }

        private void CompareElements(Collider element)
        {
            elemID ElementID = element.GetComponent<ElementIDScript>().ElemID;
            if (RequiredID == ElementID && requiresElement)
            {
                CorrectElementDetected?.Invoke();
                SoundManager.Instance.PlaySound("GoodElement");  
            }
            else
            {
                WrongElementDetected?.Invoke();
                SoundManager.Instance.PlaySound("WrongElement");
            }

            element.gameObject.SetActive(false);
        }

        private void UpdateParticles()
        {
            particle.gameObject.SetActive(requiresElement);
            if (requiresElement)
                SoundManager.Instance.PlaySound("ReceiverEffectParticule");
           

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Element"))
            {
                if (requiresElement)
                    SoundManager.Instance.PlaySound("ReceiverElement");
                CompareElements(other);
                //ResetRequiredID();
            }
        }
        #endregion
    }
}
