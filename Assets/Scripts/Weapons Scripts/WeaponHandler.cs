using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponAim
{
    NONE,
    SELF_AIM,
    AIM
}

public enum WeaponFireType
{
    SINGLE,
    MULTIPLE
}

public enum WeaponBulletType
{
    BULLET
}

public class WeaponHandler : MonoBehaviour
{
    private Animator anim;

    public WeaponAim weapon_Aim;

    [SerializeField]
    private GameObject muzzleFlash;

    [SerializeField]
    private AudioSource shoot_Sound, reload_Sound;

    public WeaponFireType fireType;

    public WeaponBulletType bulletType;

    public GameObject attack_Point;


    /// <Lateradded>
    [SerializeField]
    public static int current_Bullets;

    [SerializeField]
    public static int bullets_Per_Mag;

    [SerializeField]
    public static int bullets_Left;

    [SerializeField]
    public static int bullets_Total;

    [SerializeField]
    public static int bullets_To_Load;

    /// </Lateradded>

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (bullets_Left >= 0)
        {
            current_Bullets = bullets_Left;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
           // Play_Reload(); // work only for the shotgun
            bullets_To_Load = bullets_Per_Mag - current_Bullets;
            bullets_Total = bullets_Total - bullets_To_Load;
            bullets_Left = bullets_Left + bullets_To_Load;
            
        }
        
    }
    public void ShootAnimation()
    {
        // later changed
        if(current_Bullets >0)
        {
            anim.SetTrigger(AnimationTags.SHOOT_TRIGGER); //make the animator trigger active

        }

        if (current_Bullets <= 0 && bullets_Total !=0)
        {
            bullets_Total = bullets_Total - bullets_Per_Mag;

            if(bullets_Total >= bullets_Per_Mag)
            {
                bullets_Left = bullets_Per_Mag;
            }
            if(bullets_Total < bullets_Per_Mag)
            {
                bullets_Left = bullets_Total;
            }
            
        }

        if (bullets_Total < 0)
        {
            bullets_Total = 0;
            
        }
    }

    public void Aim(bool canAim)
    {
        anim.SetBool(AnimationTags.AIM_PARAMETER, canAim);
    }

    void Turn_On_MuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        //print("MuzzleFlash On");
    }

    void Turn_Off_MuzzleFlash()
    {
        muzzleFlash.SetActive(false);
        //print("MuzzleFlash Off");
    }

    void Play_ShootSound()
    {
        if (current_Bullets > 0)

        {
            shoot_Sound.Play();
            bullets_Left--;
         
        }
        
    }

    void Play_Reload()
    {
        reload_Sound.Play();
    }
    void Turn_On_AttackPoint()
    {
        attack_Point.SetActive(true);
    }

    void Turn_Off_AttackPoint()
    {
        if(attack_Point.activeInHierarchy)
        {
            attack_Point.SetActive(false);
        }
    }
}
 