using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Reflection;

public class setValueScript : MonoBehaviour
{
   public void SetValue()
    {
        string name = gameObject.transform.parent.GetComponentInChildren<Text>().text;

        object data = jsonDataObject.Instance.jsonDataClasses[0];
        FieldInfo[] fields = data.GetType().GetFields();

        foreach (FieldInfo field in fields)
        {
                
           if(field.Name == name)
            {
                field.SetValue(data, GetComponent<Slider>().value);
            }
        }


    }
}
