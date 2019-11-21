using PetrusGames.HelperLibrary.Json;
using PetrusGames.NuclearPlant.Managers.Data.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jsonDataObject : MonoBehaviour
{
    public string DataPath;
    public static jsonDataObject Instance = new jsonDataObject();
    public List<JsonDataClass> jsonDataClasses = new List<JsonDataClass>();
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        jsonDataClasses = JsonREadWriteData.Instance.ReadJsonItem(DataPath);
    }

   
}
