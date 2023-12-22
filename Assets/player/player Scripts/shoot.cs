// NOTE: If the box above this text note says anything
// other than Assembly-CSharp, autofill will NOT work.
// Unity functions and syntax can be tedious, and it is
// common to make mistakes in commands when there is no guide.

using System.Collections;
using System.Collections.Generic;
//using UnityEditor.AnimatedValues;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.GraphicsBuffer;

public class shoot : MonoBehaviour
{
    // The projectile prefab we are going to call.
    public Rigidbody2D primaryWeapon;
    public Rigidbody2D secondaryWeapon;
    public bool rangeAttack;
    public bool rangeSecondary;
    // Reference the Game Manager
    public GameObject gameManager;

    // The distance our projectile will travel
    public float dist;

    public float primaryCoolDown;
    public float secondaryCoolDown;
    public float coolDownLeft;
    public float secondaryCoolDownLeft;
    // Update is called once per frame
    public float rangeMultipler;
    public float meleeMultipler;

    private Animator attackAnimator;
    public GameObject weaponHold;
    void Start()
    {
        primaryCoolDown = primaryWeapon.GetComponent<weaponCollider>().cooldown;
        secondaryCoolDown = secondaryWeapon.GetComponent<weaponCollider>().cooldown;

        coolDownLeft = 0;
        secondaryCoolDownLeft = 0;


        rangeAttack = primaryWeapon.GetComponent<isRanged>().rangedWeapon;
        rangeSecondary = secondaryWeapon.GetComponent<isRanged>().rangedWeapon;


        //Animations
        attackAnimator = weaponHold.GetComponent<Animator>();

       // Debug.Log(projectile);
       if (primaryWeapon.ToString() == "bullet (UnityEngine.Rigidbody2D)")
        {
          //  attackAnimator.SetBool("isSword", false);
           // Debug.Log("bullet");
            //bool temp = projectile.GetComponent<rifleType>().isShotgun;
         //   Debug.Log(temp);
        }
    }

    void Update()
    {
        // The current position of the mouse on screen.
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(mousePos);

        // The vector that points from the center of our player
        // to the position of our mouse.
        Vector2 aimVector = mousePos - transform.position;



        Quaternion rotate = findRotation();


        coolDownLeft -= Time.deltaTime;
        secondaryCoolDownLeft -= Time.deltaTime;

        // IF the Fire1 Button is pressed...
        if (Input.GetButtonDown("Fire1"))
        {
            //  attackAnimator.SetBool("isSword", true);
         //   attackAnimator.SetTrigger("isSword");
            if (coolDownLeft <= 0f)
            {
         //       Debug.Log(rotate.ToString());
                // Set a temporary Rigidbody2D
                // Instantiate the projectile prefab and assign it to the temporary Rigidbody 
                //  Rigidbody2D clone = Instantiate(projectile, transform.position, transform.rotation);
                //  Rigidbody2D clone = Instantiate(projectile, transform.position, transform.rotation);

                Rigidbody2D clone = Instantiate(primaryWeapon, transform.position, rotate);

                // reference the game manager on the clone
                //clone.GetComponent<OnTriggerDestroyExample>().gameManager = gameManager;

                // Set the projectiles velocity in the calculated direction
                // multiplied by how far you want it to travel.
                // Normalizing a vector essentially just gives us the 
                // directional component of that vector.
                //clone.velocity = aimVector.normalized * dist;
                if (rangeAttack)
                {
                    rangeFire(clone, aimVector);

                }
                else
                {
                    meleeFire(clone, aimVector);
                }
               // rate = 0;
                coolDownLeft = primaryCoolDown;

                if (secondaryCoolDownLeft <= 0f)
                {
                    secondaryCoolDownLeft = 0.25f;
                }
                }

        }

        

        else if (Input.GetButton("Fire1"))
            {
            if (coolDownLeft <= 0f) { 

                
                    //Rigidbody2D clone = Instantiate(projectile, transform.position, transform.rotation);
                    Rigidbody2D clone = Instantiate(primaryWeapon, transform.position, rotate);

                    if (rangeAttack)
                    {
                    rangeFire(clone, aimVector);

                }
                else
                    {
                    meleeFire(clone, aimVector);
                }
                coolDownLeft = primaryCoolDown;
                if (secondaryCoolDownLeft <= 0f)
                {
                    secondaryCoolDownLeft = 0.25f;
                }


            }

        }


        //Secondary Attack
        else if (Input.GetButtonDown("Fire2"))
        {
            if (secondaryCoolDownLeft <= 0f)
            {
                //Debug.Log(rotate.ToString());
               
                Rigidbody2D clone = Instantiate(secondaryWeapon, transform.position, rotate);

                
                if (rangeSecondary)
                {
                    rangeFire(clone, aimVector);

                }
                else
                {

                    meleeFire(clone, aimVector);
                }
                // rate = 0;
                secondaryCoolDownLeft = secondaryCoolDown;
                if (coolDownLeft <= 0f)
                {
                    coolDownLeft = 0.25f;
                }

            }

        }



        else if (Input.GetButton("Fire2"))
        {
            if (secondaryCoolDownLeft <= 0f)
            {


                //Rigidbody2D clone = Instantiate(projectile, transform.position, transform.rotation);
                Rigidbody2D clone = Instantiate(secondaryWeapon, transform.position, rotate);

                if (rangeSecondary)
                {

                    rangeFire(clone, aimVector);
                }
                else
                {
                    meleeFire(clone, aimVector);
                }
                secondaryCoolDownLeft = secondaryCoolDown;
                if (coolDownLeft <= 0f)
                {
                    coolDownLeft = 0.25f;
                }


            }

        }

    }

    //
    void rangeFire(Rigidbody2D clone, Vector2 aimVector)
    {
        clone.GetComponent<weaponCollider>().damage = clone.GetComponent<weaponCollider>().damage * rangeMultipler;

        clone.velocity = aimVector.normalized * dist;
    }
    void meleeFire(Rigidbody2D clone, Vector2 aimVector)
    {
        clone.GetComponent<weaponCollider>().damage = clone.GetComponent<weaponCollider>().damage * meleeMultipler;




        if (clone.name == "swipe Attack(Clone)") {

            clone.velocity = new Vector2(0, 0);
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = Input.mousePosition - pos;
            // Debug.Log(dir);
            //clone.transform.position = clone.transform.position + new Vector3(0, 5, 0);
            clone.transform.position = clone.transform.position + (dir.normalized * 0.05f);



            // Debug.Log("correct name");
        }
        else if (clone.name == "hammer attack2(Clone)")
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 dir = Input.mousePosition;
            // Debug.Log(clone.name);


            Vector3 end = pos + new Vector3(0, 0, 10);
            Vector3 start = pos + new Vector3(0, 10, 10);

            // clone.transform.position = pos + new Vector3(0, 0, 10);

            clone.transform.rotation = (Quaternion.identity);
            // clone.transform.position = Vector3.Lerp(start, end, 0.3f);
            clone.transform.position = start;
            clone.velocity = new Vector3 (0, -20, 0);
            
            //     clone.transform.Rotate(0, 0, 0);
           
            
        }
    
        else
        {
            clone.velocity = aimVector.normalized * dist * 0.2f;
        }
        

  
      


       // clone.transform.position = mousePosition - playerPos;
    }

    //Rotation needed for meelee attacks to face the correct direction
    Quaternion findRotation()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotate = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        return rotate;
    }
}
