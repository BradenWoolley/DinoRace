using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class WeaponController : MonoBehaviour/*, IPointerDownHandler, IPointerUpHandler*/
{
    [SerializeField] UnityEvent Shoot;

    //Get equipped weapon for firerate
    [SerializeField] GameObject[] weapons;
    GameObject activeWeapon;

    private void Start()
    {
        foreach(var gun in weapons)
        {
            if (gun.activeInHierarchy)
            {
                activeWeapon = gun;
                break;
            }
        }
    }


    //bool isFiring = false;

    /*void Update()
    {
        if (isFiring)
        {
            //if(Time.time > activeWeapon.GetComponent<ShootWeapon>().fire)
        }
    }*/

    /*public void OnPointerDown(PointerEventData eventData)
    {
        isFiring = true;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isFiring = false;
    }*/
}
