//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using UnityEngine;


namespace PetrusGames
{
    public class FlameOnLineRenderer : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField] private LineRenderer lineRenderer;
        #endregion

        #region PRIVATE FIELDS
        private int numberOfLines;
        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS
        public Vector3 GetPositionOnLine()
        {
            int randomNumber = UnityEngine.Random.Range(0, numberOfLines);
            Vector3 position = new Vector3(
                Random.Range(lineRenderer.GetPosition(randomNumber).x, lineRenderer.GetPosition(randomNumber + 1).x),
                Random.Range(lineRenderer.GetPosition(randomNumber).y, lineRenderer.GetPosition(randomNumber + 1).y),
                Random.Range(lineRenderer.GetPosition(randomNumber).z, lineRenderer.GetPosition(randomNumber + 1).z)
                );
            return position;
        }
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS
        private void Start()
        {
            numberOfLines = lineRenderer.positionCount - 1;
        }

        #endregion


    }
}
