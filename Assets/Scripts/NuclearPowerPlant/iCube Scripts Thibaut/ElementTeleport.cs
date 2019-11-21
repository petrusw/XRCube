//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using UnityEngine;


namespace PetrusGames
{
    public class ElementTeleport : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private Transform teleportPos;
        #endregion

        #region PRIVATE FIELDS
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Element"))
                other.transform.position = teleportPos.position;
        }
        #endregion


    }
}
