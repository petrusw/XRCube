using PetrusGames.HelperLibrary.TextUtilities;
using System.Collections;
using System.Collections.Generic;
using ThibautPetit;
using TMPro;
using UnityEngine;

public class ElementsDisplay : MonoBehaviour
{
    //[SerializeField] private ReceiverIDCheck receiver;
    [SerializeField] private TextMeshPro tmp;
    private DisplayTextCharacterTime characterTime = new DisplayTextCharacterTime();
    private string fuulString;
    private bool isComplete = true;
    private float time;
    public void DisplayText(elemID elemID)
    {
        fuulString = elemID.ToString();
        isComplete = false;
        time = 0;
        tmp.text = string.Empty;
    }
    
    private void Update()
    {
        if (isComplete == false)
        {
            time += Time.deltaTime;
            var a = characterTime.SetNewString(0.25f, time, fuulString);
            tmp.text = a.Item1;
            isComplete = a.Item3;
            time = a.Item2;
        }
        else
        {
            characterTime = new DisplayTextCharacterTime();
        }
    }
}
