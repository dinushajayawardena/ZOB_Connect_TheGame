using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    private WeaponManager weapon_Manager;

    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;

    private Animator zoomCameraAnim;
    private bool zoomed;

    private Camera mainCam;

    private GameObject crosshair;

    public float hit_Score;

    public static float current_Score;

    public GameObject score_Shower;

    

    // Start is called before the first frame update
    void Awake()
    {
        weapon_Manager = GetComponent<WeaponManager>();
        zoomCameraAnim = transform.Find(Tags.LOOK_ROOT).transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();
        //get the animator component in FP camera - child in child component of the parent "Player"

        crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);//get the crosshair from the gameobjects

        mainCam = Camera.main; //set the main camera object to maincam camera type variable

        
    }


    private void Start()
    {
        current_Score = 0;
    }
    // Update is called once per frame
    void Update()
    {
        

        WeaponShoot();
        ZoomInAndOut();
        GetScore();
        
    }

    void WeaponShoot()
    {
        
        if (weapon_Manager.GetCurrentSelectedWeapon().fireType==WeaponFireType.MULTIPLE)//if player selected assault rifle
        {
            if(Input.GetMouseButton(0) && Time.time >nextTimeToFire) //check whether the player is press and hold the left mouse button & make fire continously
            {
                
                    nextTimeToFire = Time.time + 1f / fireRate;

                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                    BulletFired(); // call function to get the hit gameobject name
                
            }

            
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(weapon_Manager.GetCurrentSelectedWeapon().fireType == WeaponFireType.SINGLE)
                {
                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                }
                BulletFired(); //  call function to get the hit gameobject name
            }
        }

        
    }

    void ZoomInAndOut() //make zoom in and out
    {
        if(weapon_Manager.GetCurrentSelectedWeapon().weapon_Aim==WeaponAim.AIM)
        {
            if(Input.GetMouseButtonDown(1))
            {
                zoomCameraAnim.Play(AnimationTags.ZOOM_IN_ANIM);// play the zoom animation

                crosshair.SetActive(false);//deactive the crosshair
            }

            if (Input.GetMouseButtonUp(1))
            {
                zoomCameraAnim.Play(AnimationTags.ZOOM_OUT_ANIM);// play the zoom animation

                crosshair.SetActive(true);//active the crosshair
            }
        }
    }

    public float BulletFired() //detect the collision of gameobjects when fired
    {
        RaycastHit hit;
        current_Score += hit_Score;
        //Debug.Log(current_Score);

        score_Shower.GetComponent<Text>().text = current_Score.ToString(); 
        
        if(Physics.Raycast(mainCam.transform.position , mainCam.transform.forward, out hit))
        {
            if(hit.transform.gameObject.name == "ring0")
            {
                //print("ring0 get hitted");
                hit_Score = 5f;
                return hit_Score;
            }

            if (hit.transform.gameObject.name == "ring1")
            {
                //print("ring0 get hitted");
                hit_Score = 4f;
                return hit_Score;
            }

            if (hit.transform.gameObject.name == "ring2")
            {
                //print("ring0 get hitted");
                hit_Score = 3f;
                return hit_Score;
            }

            if (hit.transform.gameObject.name == "ring3")
            {
                //print("ring0 get hitted");
                hit_Score = 2f;
                return hit_Score;
            }

            if (hit.transform.gameObject.name == "ring4")
            {
                //print("ring0 get hitted");
                hit_Score = 1f;
                return hit_Score;
            }

            if (hit.transform.gameObject.name == "ring5")
            {
                //print("ring0 get hitted");
                hit_Score = 0.5f;
                return hit_Score;
            }

            //print("a bullet hits to: "+hit.transform.gameObject.name); //get the name of the hitted gameobject.
            hit_Score = 0f;
            return hit_Score;
        }
        hit_Score = 0f;
        return 0;

        
    }
    float GetScore()
    {
        return current_Score;
    }


}
