using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootWeapon : MonoBehaviour
{

    float fireRate = 0.25f;
    int damage = 10;
    float ammo = 30;
    [SerializeField] GameObject crossHair;

    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private float nextFire;

    PlayerAnimation anim;

    private void Start()
    {
        anim = GetComponentInParent<PlayerAnimation>();
    }

    public float FireRate
    {
        get { return fireRate; }
        set { fireRate = value; }
    }

    public void Shoot()
    {
        if(ammo > 0 && Time.time > nextFire)
        {
            //StartCoroutine("fireBullet", 0.5f);
            //Debug.LogWarning("Shot gun");
            ammo--;
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(crossHair.transform.position);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag.Equals("Dino"))
                {
                    ITakeDamage damage = hit.collider.GetComponent<ITakeDamage>();
                    if (damage != null)
                        damage.TakeDamage(10);
                }
            }
        }

        else
        {
            //Debug.LogWarning("Out of ammo");
        }
        
    }

    private IEnumerator ShotEffect()
    {
        //gunAudio.Play();

        anim.OnShoot();
        yield return shotDuration;
    }
}
