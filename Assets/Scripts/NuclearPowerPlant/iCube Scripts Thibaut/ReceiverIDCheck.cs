using AftahGames.NuclearSimulator;
using PetrusGames;
using PetrusGames.NuclearPlant.Managers.Elements;
using PetrusGames.NuclearPlant.Objects.Elements;
using System;
using System.Collections;
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
        [SerializeField] private ParticleSystem goodParticle, badParticle;
        [SerializeField] private float particlesDuration;
        [SerializeField] private MeshRenderer border, tube;
        [SerializeField] private ElementSpawner spawner;
        #endregion

        #region PRIVATE FIELDS
        private float timeToResetElement;
        private elemID requiredID;
        private float currentTimer;
        private bool requiresElement = false;
        private Color baseTubeColor;
        private List<elemID> spawnablesElem = new List<elemID>();
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
            spawnablesElem = spawner.ElemIDs;
            border.material.color = Color.black;
            goodParticle.Stop(true);
            badParticle.Stop(true);
            baseTubeColor = tube.material.color;
        }

        public void ResetRequiredID()
        {
            requiredID = GetRandomRequiredID();

            while(spawnablesElem.Contains(requiredID))
            {
                requiredID = GetRandomRequiredID();
            }

            foreach (var display in colorDisplay)
            {
                display.ChangeColor(requiredID);
            }

            foreach (var text in textDisplay)
            {
                text.DisplayText(requiredID);
            }
        }

        private elemID GetRandomRequiredID()
        {
            elemID newID = (elemID)UnityEngine.Random.Range(0, Enum.GetNames(typeof(elemID)).Length);
            return newID;
        }

        private void CompareElements(Collider element)
        {
            elemID ElementID = element.GetComponent<ElementIDScript>().ElemID;
            if (RequiredID == ElementID && requiresElement)
            {
                SoundManager.Instance.PlaySound("ReceiverElement");
                SoundManager.Instance.PlaySound("GoodElement");
                StartCoroutine(ShowParticle(goodParticle, Color.green));
                CorrectElementDetected?.Invoke();
            }
            else
            {
                SoundManager.Instance.PlaySound("ReceiverElement");
                SoundManager.Instance.PlaySound("WrongElement");
                StartCoroutine(ShowParticle(badParticle, Color.red));
                WrongElementDetected?.Invoke();
            }

            element.gameObject.SetActive(false);
        }

        private void UpdateParticles()
        {
            particle.gameObject.SetActive(requiresElement);
            if (requiresElement)
                SoundManager.Instance.PlaySound("ReceiverEffectParticule");


        }

        private IEnumerator ShowParticle(ParticleSystem particle, Color newColor)
        {
            particle.Play(true);
            border.material.color = newColor;
            tube.material.color = new Color(newColor.r, newColor.g, newColor.b, 0.8f);
            yield return new WaitForSeconds(particlesDuration);
            particle.Stop(true);
            border.material.color = Color.black;
            tube.material.color = baseTubeColor;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Element"))
            {
                {
                    if (!other.GetComponent<ElementIDScript>().IsGrabbed)
                        CompareElements(other);
                }
            }
        }
        #endregion
    }
}
