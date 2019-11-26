//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using PetrusGames.NuclearPlant.Managers.Data;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace PetrusGames
{
    public class GraphDrawer : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] List<LineRenderer> lines = new List<LineRenderer>();
        [SerializeField] ScoreListsGetter scoreListsGetter;

        [SerializeField] private Transform zero;
        [SerializeField] private Transform ten;

        #endregion

        #region PRIVATE FIELDS
        private int maxScore;
        private int numberOfSections;
        private float deltaX;
        private float deltaY;
        List<List<float>> scoresList;

        private float timeToDraw;
        private float tempTimer;
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

        private void Start()
        {
            maxScore = Convert.ToInt32(DataManager.Instance.BaseEfficiency);
            timeToDraw = DataManager.Instance.TimeToDrawGraph;
            tempTimer = timeToDraw;
        }

        private void Update()
        {
            tempTimer -= Time.deltaTime;
            if (tempTimer <= 0)
            {
                DrawLines();
                tempTimer = 20f;
            }
        }

        private void DrawLines()
        {
            scoresList = scoreListsGetter.GetLists();

            numberOfSections = scoresList[0].Count;

            deltaX = ten.position.x - zero.position.x;
            deltaY = ten.position.y - zero.position.y;

            for (int i = 0; i < lines.Count; i++)
            {
                lines[i].positionCount = numberOfSections;
                for (int j = 0; j < numberOfSections; j++)
                {
                    lines[i].SetPosition(j, GetPosition(i, j, scoresList[i][j]));
                }
            }
        }

        private Vector3 GetPosition(int i, int j, float value)
        {
            if (j == 0)
            {
                float XPos = zero.position.x;
                float YPos = (value / maxScore * deltaY) + zero.position.y;
                return new Vector3(XPos, YPos, zero.position.z);
            }
            else
            {
                float XPos = zero.position.x + (deltaX / numberOfSections * (j + 1));
                float YPos = zero.position.y + (value / maxScore * deltaY);
                return new Vector3(XPos, YPos, zero.position.z);
            }


        }

        #endregion


    }
}
