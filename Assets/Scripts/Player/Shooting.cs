using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shooting : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]UnityEvent Shoot;

    bool isFiring = false;

    [SerializeField]
    WeaponController weaponController;

    ShootWeapon currentWeapon;

    float reloadDuration;

    Image ui;

    int colourCount = 0;

    private void Start()
    {
        weaponController = GetComponent<WeaponController>();
        ui = GetComponent<Image>();
        ui.color = Color.white;
    }

    void Update()
    {
        if (currentWeapon != null)
        {
            if (currentWeapon.Ammo > 0)
            {
                if(colourCount < 1)
                {
                    colourCount++;
                    Invoke("Reload", reloadDuration);
                }
            }

            else
            {
                ui.color = Color.red;
            }

            if (isFiring)
            {
                Shoot.Invoke();
            }

            Debug.Log(currentWeapon.Ammo.ToString());
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!isFiring)
        {
            currentWeapon = weaponController.ActiveWeapon.GetComponent<ShootWeapon>();
            reloadDuration = currentWeapon.ReloadDelay;

            isFiring = true;
        }

        if (currentWeapon.Ammo <= 0)
        {
            Shoot.AddListener(currentWeapon.Reload);
            Shoot.RemoveListener(currentWeapon.Shoot);
        }

        else
        {
            Shoot.AddListener(currentWeapon.Shoot);
            Shoot.RemoveListener(currentWeapon.Reload);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isFiring)
        {
            isFiring = false;
            Shoot.RemoveAllListeners();
        }
    }

    private void Reload()
    {
        ui.color = Color.white;
        colourCount = 0;
    }
}
