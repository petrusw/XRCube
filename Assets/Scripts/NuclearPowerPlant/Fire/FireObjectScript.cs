//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using AftahGames.NuclearSimulator;
using PetrusGames.HelperLibrary;
using System;
using System.Collections;
using UnityEngine;


namespace PetrusGames.NuclearPlant.Objects.Fire
{
    public class FireObjectScript : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [Header("Set Default Behavior for Fire")]
        [SerializeField] private bool IsLifeTimed;
        [SerializeField] private float time;
        [SerializeField] private GameObject parentObject, fireManager;
        [SerializeField] private ParticleSystem particle;
        [SerializeField] private GameObject dissolveEffect;
        [SerializeField] private BoxCollider boxCollider;
        [SerializeField] private GameObject sparks;
        [SerializeField] private GameObject flameObject;
        [SerializeField] private float timeBeforeFlames;
        #endregion

        #region PRIVATE FIELDS
        private float TempTime;
        private float tickTime = 1f;
        private ParticleSystem.EmissionModule psEmission;
        private ParticleSystem.MinMaxCurve baseCurve;
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

        private void Start()
        {
            TempTime = time;
            psEmission = particle.emission;
        }

        // Update is called once per frame
        void Update()
        {
            DisableAfterTime();
            CountDown();
        }

        private void CountDown()
        {
            tickTime -= Time.deltaTime;
            if (tickTime <= 0)
            {
                ExtinguishedFireInfo.instance.FireTick();
                tickTime = 1f;
            }
        }

        /// <summary>
        /// if IsLifeTimed is true then the fireobject will disactivate after the time is depleated
        /// </summary>
        private void DisableAfterTime()
        {
            if (IsLifeTimed == true)
            {
                TempTime -= Time.deltaTime;
                if (TempTime < 0)
                {
                    TempTime = time;
                    parentObject.SetActive(false);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Element"))
            {
                this.gameObject.SetActive(false);
                other.transform.position = Vector3.zero;
                other.gameObject.SetActive(false);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.gameObject.tag == "Exctinctor")
            {
                SoundManager.Instance.PlaySound("ShutDownFlames");
                StartCoroutine(ShutDownFlames());
                ObjectPoolingWithLinq.Instance.GetObjectFromPool(dissolveEffect, transform.position, true);
            }

            if (collision.gameObject.CompareTag("Element"))
            {
                this.gameObject.SetActive(false);
                collision.gameObject.transform.position = Vector3.zero;
                collision.gameObject.gameObject.SetActive(false);
            }
        }

        private void OnEnable()
        {
            FireManagerScript.Instance.TotalFireDamageAdd = 1;
            StartCoroutine("FireApparition");
        }
        private void OnDisable()
        {
            FireManagerScript.Instance.TotalFireDamageRemove = 1;
            sparks.SetActive(true);
            flameObject.SetActive(false);
            boxCollider.enabled = false;
        }

        private IEnumerator ShutDownFlames()
        {
            boxCollider.enabled = false;
            psEmission.enabled = false;
            yield return new WaitForSeconds(2);
            psEmission.enabled = true;
            boxCollider.enabled = true;
            gameObject.SetActive(false);
        }

        private IEnumerator FireApparition()
        {
            SoundManager.Instance.PlaySound("SparkFlame");
            yield return new WaitForSeconds(timeBeforeFlames);
            sparks.SetActive(false);
            flameObject.SetActive(true);
            SoundManager.Instance.PlaySound("Fire");
            boxCollider.enabled = true;
        }
        #endregion


    }
}
