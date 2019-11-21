//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                       | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using AftahGames.NuclearSimulator;
using PetrusGames.HelperLibrary;
using PetrusGames.NuclearPlant.Managers.Data;
using UnityEngine;


namespace PetrusGames.NuclearPlant.Objects.Elements
{
    public class ElementColideScript : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private GameObject explosion;
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

        private void OnCollisionEnter(Collision collision)
        {
            CollisionCheck(collision.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            CollisionCheck(other.gameObject);
        }

        private void CollisionCheck(GameObject collision)
        {
            if (collision.CompareTag("Ground"))
            {
                Explode();
                HealthManager.instance.TakeDamage(DataManager.Instance.DamagePerElementFall);

            }
            else if (collision.CompareTag("Fire"))
            {
                Explode();
                HealthManager.instance.TakeDamage(DataManager.Instance.DamagePerElementExplosion);
                collision.SetActive(false);
            }
        }

        private void Explode()
        {
            ObjectPoolingWithLinq.Instance.GetObjectFromPool(explosion, transform.position, true);
            SoundManager.Instance.PlaySound("Boum");
            ElementPosition.instance.ElementDestroyed(transform.position);
            gameObject.SetActive(false);
        }

        #endregion


    }
}
