using AftahGames.NuclearSimulator;
using PetrusGames;
using PetrusGames.NuclearPlant.Managers.Data;
using PetrusGames.NuclearPlant.Objects.Elements;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ThibautPetit
{
    public class ConveyorBelt : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private PlayerAbility playerAbility;
        [SerializeField] private DifficultyIncrease difficultyIncrease;
        [SerializeField] private List<Animator> anims;

        #endregion

        #region PRIVATE FIELDS
        private float converyorBeltSpeed;
        private bool movingLeft;

        #endregion

        #region PUBLIC PROPERTIES
        public bool MovingLeft { get => movingLeft; }
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        public event Action<bool> onChangeDirection;
        #endregion

        #region PRIVATE FUNCTIONS

        private void Start()
        {
            converyorBeltSpeed = DataManager.Instance.ConveryorBeltSpeed;
        }

        private void OnEnable()
        {
            playerAbility.OnConveyorBelt += ConveyorBeltHandler;
            difficultyIncrease.onDifficultyIncrease += DifficultyIncreaseHandler;
        }


        private void OnDisable()
        {
            difficultyIncrease.onDifficultyIncrease -= DifficultyIncreaseHandler;
            playerAbility.OnConveyorBelt -= ConveyorBeltHandler;
        }

        private void ConveyorBeltHandler(bool obj)
        {
            StopAndRestart();
        }

        private void DifficultyIncreaseHandler(BoostValues obj)
        {
            converyorBeltSpeed += obj.converyorBeltSpeedBoostValue;
        }

        private void StopAndRestart()
        {
            movingLeft = !movingLeft;
            onChangeDirection?.Invoke(movingLeft);

            foreach (var anim in anims)
            {
                anim.SetFloat("speedMultiplier", anim.GetFloat("speedMultiplier") * -1);
            }
        }

        // aftah put ontrigger for sound
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Element"))
            {

                SoundManager.Instance.PlaySound("ElementOnBelt");
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Element"))
            {
                if (other.GetComponent<ElementIDScript>().IsGrabbed == false)
                {
                    MoveElement(other.gameObject);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Element"))
            {
               // other.GetComponent<Rigidbody>().useGravity = true;
                other.GetComponent<Rigidbody>().isKinematic = false;
                //aftah put the sound
                SoundManager.Instance.StopSound("ConveyorBeltLeft");
                SoundManager.Instance.StopSound("ConveyorBeltRight");
            }
        }

        private void MoveElement(GameObject elem)
        {
            elem.GetComponent<Rigidbody>().isKinematic = true;
            elem.GetComponent<BoxCollider>().isTrigger = true;
            //elem.GetComponent<Rigidbody>().useGravity = false;
            elem.transform.Translate((MovingLeft ? Vector3.left : Vector3.right) * converyorBeltSpeed * Time.deltaTime, Space.World);

            //aftah put the sound
            if (MovingLeft)
            {
                SoundManager.Instance.StopSound("ConveyorBeltRight");
                SoundManager.Instance.PlaySound("ConveyorBeltLeft");

            }
            else
            {
                SoundManager.Instance.StopSound("ConveyorBeltLeft");
                SoundManager.Instance.PlaySound("ConveyorBeltRight");
            }

        }
        #endregion
    }
}
