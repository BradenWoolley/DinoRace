using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Shooting : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] UnityEvent Shoot;

    bool isFiring = false;
    [SerializeField]
    WeaponController weaponController;
    ShootWeapon currentWeapon;


    private void Start()
    {
        weaponController = GetComponent<WeaponController>();
    }

    void Update()
    {
        if (isFiring)
        {
            Shoot.Invoke();
        }
           
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        if(!isFiring)
        {
            currentWeapon = weaponController.ActiveWeapon.GetComponent<ShootWeapon>();
            Shoot.AddListener(currentWeapon.Shoot);
            isFiring = true;
        }
            
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isFiring)
        {
            isFiring = false;
            Shoot.RemoveListener(currentWeapon.Shoot);
        }
        
    }
}
