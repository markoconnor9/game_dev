using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropItem : MonoBehaviour
{
    public  GameObject healthPotion;
    public GameObject incMaxHealth;
    public GameObject incMovementSpeed;
   
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public GameObject weapon4;
    public GameObject weapon5;
    public GameObject weapon6;
    public GameObject weapon7;

    private bool isQuitting;
    // Start is called before the first frame update

    void Start()
    {
        isQuitting = false;
    }

    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public void manualEnd()
    {
        isQuitting = true;
    }



  //  void OnDestroy()
   public void item(Transform enemyTransform)
    {

        if (!isQuitting)
        {
            //  Debug.Log("destroyed");
            float chanceOfItemDrop = UnityEngine.Random.Range(0.0f, 1.0f);
            //Debug.Log(temp);
            if ( chanceOfItemDrop > 0.10f && chanceOfItemDrop <= 0.40f)
            {
                float pickItem = UnityEngine.Random.Range(0.0f, 1.0f);
                if (pickItem < 0.33f)
                {
                    Instantiate(healthPotion, enemyTransform.position, Quaternion.identity);
                }
                else if (pickItem > 0.33 && pickItem < 0.66f)
                {
                    Instantiate(incMaxHealth, enemyTransform.position, Quaternion.identity);
                }
                else if (pickItem > 0.66 && pickItem < 1.0f)
                {
                    Instantiate(incMovementSpeed, enemyTransform.position, Quaternion.identity);
                }
            }
            else if (chanceOfItemDrop <= 0.10f)
            {
                float pickItem = UnityEngine.Random.Range(0.0f, 1.0f);
                if (pickItem < 0.10f)
                {
                    Instantiate(weapon1, enemyTransform.position, Quaternion.identity);
                }
                else if (pickItem > 0.11 && pickItem < 0.20f)
                {
                    Instantiate(weapon2, enemyTransform.position, Quaternion.identity);
                }
                else if (pickItem > 0.21 && pickItem < 0.30f)
                {
                    Instantiate(weapon3, enemyTransform.position, Quaternion.identity);
                }
                else if (pickItem > 0.31 && pickItem < 0.60f)
                {
                    Instantiate(weapon4, enemyTransform.position, Quaternion.identity);
                }
                else if (pickItem > 0.80f && pickItem < 1.0f)
                {
                    Instantiate(weapon5, enemyTransform.position, Quaternion.identity);
                }
                

            }
            }
    }
}
