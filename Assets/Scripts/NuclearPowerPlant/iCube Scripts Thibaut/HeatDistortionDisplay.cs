//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using AftahGames.NuclearSimulator;
using ThibautPetit;
using UnityEngine;


namespace PetrusGames
{
    public class HeatDistortionDisplay : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private HeatInfo heatInfo;
        [SerializeField] private GameObject heatDistortion;
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

        private void OnEnable()
        {
            heatInfo.overHeatEvent += OverHeatHandler;
            heatInfo.stopOverHeatEvent += StopOverHeatHandler;
        }

        private void OnDisable()
        {
            heatInfo.overHeatEvent -= OverHeatHandler;
            heatInfo.stopOverHeatEvent -= StopOverHeatHandler;
        }

        private void StopOverHeatHandler(object sender)
        {
            if (heatDistortion.activeSelf)
            {


                SoundManager.Instance.StopSound("EnergieDistorsion");

                heatDistortion.SetActive(false);
            }
        }

        private void OverHeatHandler(object sender)
        {
            if (!heatDistortion.activeSelf)
            {
                if (!sender.Equals(this))
                {
                    SoundManager.Instance.PlaySound("EnergieDistorsion");
                }
                heatDistortion.SetActive(true);
            }
        }
        #endregion
    }
}
