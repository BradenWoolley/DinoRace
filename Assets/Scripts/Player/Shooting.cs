using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shooting : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    delegate void Shoot();
    Shoot shoot;

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
                shoot();
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
            shoot += currentWeapon.Reload;
            shoot -= currentWeapon.Shoot;
        }

        else
        {
            shoot += currentWeapon.Shoot;
            shoot -= currentWeapon.Reload;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isFiring)
        {
            isFiring = false;

            shoot -= currentWeapon.Shoot;
            shoot -= currentWeapon.Reload;
        }
    }

    private void Reload()
    {
        ui.color = Color.white;
        colourCount = 0;
    }
}
