
///Later Added

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBulletsLeft : MonoBehaviour
{
    private Text bullets_Left;

    // Start is called before the first frame update
    void Awake()
    {
        bullets_Left = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        bullets_Left.text = WeaponHandler.current_Bullets.ToString() + "/" + WeaponHandler.bullets_Total.ToString();
    }
}
