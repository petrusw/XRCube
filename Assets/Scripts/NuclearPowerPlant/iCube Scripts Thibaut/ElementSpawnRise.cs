//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using UnityEngine;


namespace PetrusGames
{
    public class ElementSpawnRise : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private float distance;
        [SerializeField] private float speed;
        #endregion

        #region PRIVATE FIELDS
        private bool isRising = false;
        private Quaternion startRotation;
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

        private void Awake()
        {
            startRotation = gameObject.transform.rotation;
        }

        private void OnEnable()
        {
            gameObject.transform.rotation = startRotation;
            StartCoroutine("StartRising");
        }

        private void Update()
        {
            if (isRising)
                Rise();
        }

        private void Rise()
        {
            gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + distance, transform.position.z), speed);
            gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        private IEnumerator StartRising()
        {
            isRising = true;
            yield return new WaitForSeconds(distance);
            isRising = false;
        }

        #endregion


    }
}
