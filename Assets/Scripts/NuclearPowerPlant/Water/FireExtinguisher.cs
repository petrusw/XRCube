using AftahGames.NuclearSimulator;
using PetrusGames.NuclearPlant.Managers.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThibautPetit
{
    public class FireExtinguisher : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private float steamApparitionTime;
        [SerializeField] private List<GameObject> chargesDisplay = new List<GameObject>();
        [SerializeField] private Animator colliderAnim;
        [SerializeField] private Animator extinguisherAnim;
        [SerializeField] private PlayerAbility playerAbility;
        [SerializeField] private ParticleSystem particle1, particle2;
        [SerializeField] private float steamDuration = 0.6f;
        [SerializeField] private Transform teleportPos;
        [SerializeField] private bool movingLeft;
        #endregion

        #region PRIVATE FIELDS
        private float extinguisherSpeed;
        private float chargesCoolDown;
        private int numberOfCharges;
        #endregion

        #region PUBLIC PROPERTIES
        public int NumberOfCharges
        {
            get { return numberOfCharges; }
            set
            {
                numberOfCharges = value;
                UpdateDisplay();
            }
        }
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        private void OnEnable()
        {
            playerAbility.OnWaterGenerator += WaterGeneratorHandler;
        }

        private void OnDisable()
        {
            playerAbility.OnWaterGenerator -= WaterGeneratorHandler;
        }

        private void WaterGeneratorHandler(bool obj)
        {
            Shoot();
        }

        private void Start()
        {
            //aftah put sound
            SoundManager.Instance.PlaySound("ExtincteurMove");
            extinguisherSpeed = DataManager.Instance.ExtinguisherSpeed;
            chargesCoolDown = DataManager.Instance.ChargesCoolDown;
            numberOfCharges = chargesDisplay.Count;
            StartCoroutine("ChargesRegen");
            particle1.Stop();
            particle2.Stop();
        }

        #region PRIVATE FUNCTIONS
        private void Update()
        {
            Move();
        }


        private void Move()
        {
            gameObject.transform.Translate((movingLeft ? Vector3.left : Vector3.right) * extinguisherSpeed * Time.deltaTime);

        }

        private void Shoot()
        {
            if (NumberOfCharges > 0)
            {
                NumberOfCharges--;
                colliderAnim.SetTrigger("Exctinctor");
                StopCoroutine("ShowSteam");
                StartCoroutine("ShowSteam");
                extinguisherAnim.SetTrigger("Action");
                //Aftah put play sound
                SoundManager.Instance.PlaySound("Extincteur");
            }
        }

        private IEnumerator ShowSteam()
        {
            particle1.Play();
            particle2.Play();
            yield return new WaitForSeconds(steamDuration);
            particle1.Stop();
            particle2.Stop();
        }

        private IEnumerator ChargesRegen()
        {
            yield return new WaitForSeconds(chargesCoolDown);
            if (numberOfCharges < chargesDisplay.Count)
                NumberOfCharges++;
            StartCoroutine("ChargesRegen");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("MaxRange"))
            {
                gameObject.transform.position = new Vector3(teleportPos.position.x, transform.position.y, transform.position.z);
            }
        }

        private void UpdateDisplay()
        {
            for (int i = 0; i < chargesDisplay.Count; i++)
            {
                if (numberOfCharges > i)
                    chargesDisplay[i].SetActive(true);
                else
                    chargesDisplay[i].SetActive(false);
            }
        }
        #endregion
    }
}
