//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|																						  By Petrus Ward                                                                                  | 
//|                                                                                     XRCube Experience                                                                                 |
//|                                                                                 Copyright Petrus-Games 2019                                                                           | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Reflection;


namespace PetrusGames
{
    public class GetSetDataToBjectScript : MonoBehaviour
    {
        #region SERIALIZED FIELDS
       
        [SerializeField] private List<GameObject> Sliders;
        [SerializeField] private GameObject slider , canvas;
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

          // Start is called before the first frame update
    void Start()
    {
            object data = jsonDataObject.Instance.jsonDataClasses[0];
            FieldInfo[] fields = data.GetType().GetFields();
           
            foreach (FieldInfo field in fields)
            {
                var sliderItem = Instantiate(slider, canvas.transform);
                sliderItem.GetComponentInChildren<Text>().text = field.Name;
                string st = string.Empty;
                st = field.GetValue(data).ToString();
                sliderItem.GetComponentInChildren<Slider>().value = float.Parse(st);
                Sliders.Add(sliderItem);
            }

        }

    // Update is called once per frame
    void Update()
    {
        
    }
        #endregion


    }
}
