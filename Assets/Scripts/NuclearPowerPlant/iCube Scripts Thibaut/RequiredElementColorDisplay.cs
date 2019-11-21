//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using ThibautPetit;
using UnityEngine;


namespace PetrusGames
{
    public class RequiredElementColorDisplay : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private List<Material> mat = new List<Material>();
        [SerializeField] private MeshRenderer meshRenderer;
        #endregion

        #region PRIVATE FIELDS
        private Dictionary<elemID, Material> Materials = new Dictionary<elemID, Material>();
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        public void ChangeColor(elemID currentID)
        {
            meshRenderer.material = Materials[currentID];
        }
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS
        private void Start()
        {
            CreateDictionnary();
        }

        private void CreateDictionnary()
        {
            int nr = 0;
            foreach (elemID id in (elemID[])Enum.GetValues(typeof(elemID)))
            {
                try
                {
                    Materials.Add(id, mat[nr]);
                }
                catch { Debug.Log("no material was found "); }
                nr++;
            }
        }
        #endregion


    }
}
