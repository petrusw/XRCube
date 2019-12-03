//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using PetrusGames.NuclearPlant.Managers.Data;
using UnityEngine;



namespace PetrusGames
{
    public class GameTimer : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        private float gameTime;
        #endregion

        #region PRIVATE FIELDS
        private float remainingGameTime;
        private bool counting = false;
        #endregion

        #region PUBLIC PROPERTIES
        public static GameTimer instance;

        public float RemainingGameTime { get => remainingGameTime; private set => remainingGameTime = value; }
        #endregion

        #region PUBLIC FUNCTIONS

        public void StartTime()
        {
            counting = true;
        }

        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS
        private void Awake()
        {
            SetAsSingleton();
        }

        private void Start()
        {
            gameTime = DataManager.Instance.GameTime * 60;
            remainingGameTime = gameTime;         
        }

        private void Update()
        {
            if (counting)
                CountDown();
        }

        private void CountDown()
        {
            remainingGameTime -= Time.deltaTime;

            if (remainingGameTime <= 0)
            {                
                GameManager.instance.EndGame();
                counting = false;
            }
        }

        private void SetAsSingleton()
        {
            if (instance)
                Destroy(this);
            else
                instance = this;
        }
        #endregion


    }
}
