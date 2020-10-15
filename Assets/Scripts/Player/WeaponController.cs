using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    GameObject activeWeapon;

    public GameObject ActiveWeapon { get => activeWeapon; set => activeWeapon = value; }

    private void Start()
    {
        foreach(var gun in weapons)
        {
            if (gun.activeInHierarchy)
            {
                ActiveWeapon = gun;
                break;
            }
        }
    }

    public void SwapWeapon()
    {
        foreach(var gun in weapons)
        {
            if (gun.activeInHierarchy)
            {
                gun.SetActive(false);
            }

            else
            {
                gun.SetActive(true);
                ActiveWeapon = gun;
            }
        }
    }
}
