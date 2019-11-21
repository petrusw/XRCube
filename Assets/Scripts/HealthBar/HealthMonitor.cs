using System.Collections;
using UnityEngine;

public class HealthMonitor : MonoBehaviour
{

    [SerializeField] private float healthLenght = 200f;
    [SerializeField] private float healthPos = 120f;

    [SerializeField] private GameObject healthBar = null;
    [SerializeField] private float damageAmout;

    [SerializeField]
    private bool decreasingHealth = false;
    [SerializeField]
    private bool increasingHealth = false;
    [SerializeField]
    private float hitValue = 30;

    void Start()
    {

        StartCoroutine(HealthChange());

       
    }


    void Update()
    {

        healthBar.transform.position = new Vector2(healthPos, 30);
        healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(healthLenght, 30);

        if (decreasingHealth == true)
        {
            if (damageAmout >= hitValue)
            {
                decreasingHealth = false;
                damageAmout = 0;
            }
            else
            {
                damageAmout += 0.5f;
                healthLenght -= 0.5f;
                healthPos -= 0.25f;
            }
        }

        if (increasingHealth == true)
        {
            if (damageAmout >= hitValue * 2)
            {
                increasingHealth = false;
                damageAmout = 0;
            }
            else
            {
                damageAmout += 0.5f;
                healthLenght += 0.5f;
                healthPos += 0.25f;
            }
        }
    }

    private IEnumerator HealthChange()
    {

        yield return new WaitForSeconds(2f);
        decreasingHealth = true;
        yield return new WaitForSeconds(2f);
        decreasingHealth = true;

        yield return new WaitForSeconds(3f);
        decreasingHealth = true;
        yield return new WaitForSeconds(1f);
        decreasingHealth = true;
        yield return new WaitForSeconds(4f);
        increasingHealth = true;
        yield return new WaitForSeconds(1f);
        increasingHealth = true;



    }
}
