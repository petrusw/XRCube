//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using PetrusGames.NuclearPlant.Managers.Data;
using ThibautPetit;
using UnityEngine;


namespace PetrusGames
{
    public class HealthManager : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private ReceiverIDCheck[] idChecks = new ReceiverIDCheck[2];
        #endregion

        #region PRIVATE FIELDS     
        private float maxHealth;
        private float currentHealth;
        private float healthGainPerGoodElement;
        #endregion

        #region PUBLIC PROPERTIES
        public static HealthManager instance;

        public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

        public float CurrentHealth
        {
            get { return currentHealth; }
            set
            {
                currentHealth = value;
                HealthCheck();
                HealthDisplay.instance.UpdateHealth(currentHealth);
            }
        }

        #endregion

        #region PUBLIC FUNCTIONS
        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
        }

        public void GainHealth(float heal)
        {
            CurrentHealth += heal;
        }

        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }

        private void OnEnable()
        {
            foreach (var idCheck in idChecks)
            {
                idCheck.CorrectElementDetected += CorrectElementHandler;
            }
        }

        private void Start()
        {
            healthGainPerGoodElement = DataManager.Instance.HealthGainPerGoodElement;
            MaxHealth = DataManager.Instance.Health;
            CurrentHealth = MaxHealth;
        }

        private void OnDisable()
        {

            foreach (var idCheck in idChecks)
            {
                idCheck.CorrectElementDetected -= CorrectElementHandler;
            }
        }

        private void CorrectElementHandler()
        {
            GainHealth(healthGainPerGoodElement);
        }


        private void HealthCheck()
        {
            if (CurrentHealth <= 0)
            {
                currentHealth = 0;
                GameManager.instance.GameOver();                           
            }
        }
        #endregion


    }
}
