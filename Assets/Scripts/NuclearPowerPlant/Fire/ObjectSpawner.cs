//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using PetrusGames.NuclearPlant.Managers.Data;
using UnityEngine;


namespace PetrusGames.HelperLibrary.Utilities
{
    public class ObjectSpawner : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [Header("GameObject To Spawn")]
        [SerializeField] private GameObject GameObjectToSpawn;
        [Header("Use Pooling y/n")]
        [SerializeField] private bool IsPooled;
        [Header("If Pooled PoolingObject")]
        [SerializeField] private GameObject PoolingObject;
        [Header(" Spawn Randomly")]
        [SerializeField] private bool IsRandomized;
        [Header("X Min and Max position")]
        [Header("Use transform's or fixed positions not both!!!")]
        [Space(25)]
        [SerializeField] private Vector2 XminMaxPosition;
        [SerializeField] private Transform MinX, MaxX;
        [Header("Y Min and Max Position")]
        [SerializeField] private Vector2 YminMaxPosition;
        [SerializeField] private Transform MinY, MaxY;
        [Header("Z Min and Max Position")]
        [SerializeField] private Vector2 ZminMaxPosition;
        [SerializeField] private Transform PosZ;
        [Header("Fixed SpawnPosition")]
        [SerializeField] private Vector3 FixetSpawnPosition;
        [Header(" true if the object spawning is timed")]
        [SerializeField] private bool IsTimed;
        [Header("Timer ")]
        [SerializeField] private float TimeBetweenSpawns;
        [Header("DiffcultyIncrease")]
        [SerializeField] private DifficultyIncrease difficultyIncrease;
        [Header("SpawPositionOnLine")]
        [SerializeField] private FlameOnLineRenderer LineRendererPos;
        #endregion

        #region PRIVATE FIELDS
        private float TempTimer;
        private float spawnBuffTimer;
        private Vector3 TempPosition;
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        /// <summary>
        /// Spawns an object from pool if none is availeble in pool a new one will be added
        /// position is added in editor
        /// </summary>
        /// <param name="_gameObject"></param>
        public void SpawnObjectFromPool(GameObject _gameObject)
        {
            // get from pooling
            PoolingObject.GetComponent<ObjectPoolingWithLinq>().GetObjectFromPool(_gameObject, TempPosition, true);
        }
        /// <summary>
        /// Spawns an object from pool if none is availeble in pool a new one will be added.
        /// with position
        /// </summary>
        /// <param name="_gameObject"></param>
        /// <param name="position"></param>
        public void SpawnObjectFromPool(GameObject _gameObject, Vector3 position)
        {
            // get from pooling
            PoolingObject.GetComponent<ObjectPoolingWithLinq>().GetObjectFromPool(_gameObject, position, true);
        }
        /// <summary>
        /// Spawns an object from pool if none is availeble in pool a new one will be added
        /// with position and rotation
        /// </summary>
        /// <param name="_gameObject"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        public void SpawnObjectFromPool(GameObject _gameObject, Vector3 position, Quaternion rotation)
        {
            // get from pooling
            PoolingObject.GetComponent<ObjectPoolingWithLinq>().GetObjectFromPool(_gameObject, position, rotation, true);
        }
        /// <summary>
        /// Spawns an object from pool if none is availeble in pool a new one will be added
        /// randomized position
        /// </summary>
        /// <param name="_gameObject"></param>
        public void SpawnObjectFromPoolRandomizedPosition(GameObject _gameObject)
        {
            if (IsRandomized)
            {
                // set a random spawn position
                SetNewPosition();
            }
            // get from pooling
            PoolingObject.GetComponent<ObjectPoolingWithLinq>().GetObjectFromPool(_gameObject, TempPosition, true);
        }
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

        private void OnEnable()
        {
            difficultyIncrease.onDifficultyIncrease += DifficultyIncreaseHandler;
        }

        private void OnDisable()
        {
            difficultyIncrease.onDifficultyIncrease -= DifficultyIncreaseHandler;
        }

        private void DifficultyIncreaseHandler(BoostValues obj)
        {
            spawnBuffTimer += obj.flameSpawnRateBoostValue;
        }

        void Start()
        {

            // Set the timer to start value
            TimeBetweenSpawns = UnityEngine.Random.Range(DataManager.Instance.FireSpawnerTimer.x, DataManager.Instance.FireSpawnerTimer.y);
            TempTimer = TimeBetweenSpawns;

            if (IsRandomized)
            {
                // set a random spawn position
                SetNewPosition();
            }
            else
            {
                TempPosition = FixetSpawnPosition;
            }

        }

        void Update()
        {
            if (IsTimed)
            {
                // decrease the timer
                TempTimer -= Time.deltaTime;
                // look if timer is lower than zero
                if (TempTimer < 0)
                {
                    if (IsPooled)
                    {
                        //Get position on the line renderer
                        TempPosition = LineRendererPos.GetPositionOnLine();
                        // take a object from pool
                        IfPooled(GameObjectToSpawn);
                    }
                    else
                    {
                        if (IsRandomized)
                        {
                            // set a random spawn position
                            SetNewPosition();
                        }
                        else
                        {
                            TempPosition = LineRendererPos.GetPositionOnLine();
                        }
                        // instantiate a new object if pooling is not used
                        Instantiate(GameObjectToSpawn, TempPosition, Quaternion.identity);
                    }
                    // Reset the timer to original value
                    TimeBetweenSpawns = UnityEngine.Random.Range(DataManager.Instance.FireSpawnerTimer.x, DataManager.Instance.FireSpawnerTimer.y);
                    TempTimer = TimeBetweenSpawns - spawnBuffTimer;
                }
            }
        }

        private void SetNewPosition()
        {
            // Set a random spawn position
            if (PosZ != null && MinX != null && MaxX != null && MinY != null && MaxY != null)
            {
                TempPosition.z = PosZ.transform.position.z;
                TempPosition.x = UnityEngine.Random.Range(MinX.transform.position.x, MaxX.transform.position.x);
                TempPosition.y = UnityEngine.Random.Range(MinY.transform.position.y, MaxY.transform.position.y);
            }
            else
            {
                TempPosition.x = UnityEngine.Random.Range(XminMaxPosition.x, XminMaxPosition.y);
                TempPosition.y = UnityEngine.Random.Range(YminMaxPosition.x, YminMaxPosition.y);
                TempPosition.z = UnityEngine.Random.Range(ZminMaxPosition.x, ZminMaxPosition.y);
            }
        }

        private void IfPooled(GameObject _gameObjectToSpawn)
        {
            if (IsRandomized)
            {
                // set a random spawn position
                SetNewPosition();
            }
            // get from pooling
            PoolingObject.GetComponent<ObjectPoolingWithLinq>().GetObjectFromPool(_gameObjectToSpawn, TempPosition, true);
        }


        #endregion


    }
}
