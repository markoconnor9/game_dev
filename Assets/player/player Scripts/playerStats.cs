using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{

    public float health;
    public float currentMaxHealth;
    public bool mage;
    public bool knight;
    public bool rouge;

    public Rigidbody2D knightPrimaryStartingWeapon;
    public Rigidbody2D knightSecondaryStartingWeapon;

    public Rigidbody2D rougePrimaryStartingWeapon;
    public Rigidbody2D rougeSecondaryStartingWeapon;

    public Rigidbody2D magePrimaryStartingWeapon;
    public Rigidbody2D mageSecondaryStartingWeapon;


    public Animator animator;
  /*  public SpriteRenderer spriteRenderer;
    public Sprite mageSprite;
    public Sprite soilderSprite;
    public Sprite warriorSprite;
    */
    // Start is called before the first frame update

   // void Awake()
    //{
       
    //}
    
    void Awake()
    {
        int temp = SceneManagerScript.classValue;
        Debug.Log(temp);
        if(temp == 1)
        {
            mage = true;
        }
        else if (temp == 2)
        {
            knight = true;
        }
        else if (temp == 3)
        {
            rouge = true;
        }



        animator = GetComponent<Animator>();
        if (knight)
        {
            currentMaxHealth = health + 50;
            health = health + 50;

           // this.GetComponent<playerMovement>().moveSpeed = this.GetComponent<playerMovement>().moveSpeed + 3;
            this.GetComponent<shoot>().meleeMultipler = 2;
            animator.SetBool("isKnight", true);
            this.GetComponent<shoot>().primaryWeapon = knightPrimaryStartingWeapon;
            this.GetComponent<shoot>().secondaryWeapon = knightSecondaryStartingWeapon;
        }
        if (rouge)
        {
            this.GetComponent<shoot>().rangeMultipler = 2;
            //       spriteRenderer.sprite = soilderSprite;            animator.SetBool("isKnight", true);
            animator.SetBool("isRouge", true);
            this.GetComponent<shoot>().primaryWeapon = rougePrimaryStartingWeapon;
            this.GetComponent<shoot>().secondaryWeapon = rougeSecondaryStartingWeapon;
            this.GetComponent<playerMovement>().moveSpeed = this.GetComponent<playerMovement>().moveSpeed + 2;
            this.GetComponent<shoot>().rangeMultipler = 2;
        }

        if (mage)
        {
            //     spriteRenderer.sprite = mageSprite;

            currentMaxHealth = health + 25;
            health = health + 25;

            animator.SetBool("isMage", true);
            this.GetComponent<shoot>().primaryWeapon = magePrimaryStartingWeapon;
            this.GetComponent<shoot>().secondaryWeapon = mageSecondaryStartingWeapon;
            this.GetComponent<shoot>().rangeMultipler = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
