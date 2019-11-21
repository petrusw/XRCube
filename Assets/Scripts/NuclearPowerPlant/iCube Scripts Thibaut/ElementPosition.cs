//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PetrusGames
{
    public class ElementPosition : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private List<Transform> positions;
        #endregion

        #region PRIVATE FIELDS
        private List<float> XPos = new List<float>();
        #endregion

        #region PUBLIC PROPERTIES
        public static ElementPosition instance;
        #endregion

        #region PUBLIC FUNCTIONS

        public void ElementDestroyed(Vector3 position)
        {
            float elemX = position.x;

            if (elemX > XPos[0] && elemX < XPos[1])
            {
                onPlayer1ElemDestroyed?.Invoke();
            }
            else if (elemX > XPos[1] && elemX < XPos[2])
            {
                onPlayer2ElemDestroyed?.Invoke();
            }
            else if (elemX > XPos[2] && elemX < XPos[3])
            {
                onPlayer3ElemDestroyed?.Invoke();
            }
        }

        #endregion

        #region EVENTS
        public event Action onPlayer1ElemDestroyed;
        public event Action onPlayer2ElemDestroyed;
        public event Action onPlayer3ElemDestroyed;

        #endregion

        #region PRIVATE FUNCTIONS

        private void Awake()
        {
            if (instance)
                Destroy(this);
            else
                instance = this;
        }

        private void Start()
        {
            foreach (var pos in positions)
            {
                XPos.Add(pos.transform.position.x);
            }            
        }
        #endregion


    }
}
