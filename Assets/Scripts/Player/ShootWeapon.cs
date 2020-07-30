using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWeapon : MonoBehaviour
{

    float fireRate;
    float ammo;
    [SerializeField] GameObject crossHair;

    public void OnShoot()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(crossHair.transform.position);

        if(Physics.Raycast(ray, out hit))
        {
            Debug.Log($"Hit {hit.collider.gameObject.name}");
        }
    }
}
