using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootWeapon : MonoBehaviour
{
    [SerializeField]
    float fireRate = 0.25f;

    [SerializeField]
    int damageAmount = 10;

    [SerializeField]
    float ammo = 30;

    [SerializeField] GameObject crossHair;

    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);

    private float nextFire;

    PlayerAnimation anim;

    AudioSource gunAudio;
    private void Start()
    {
        anim = GetComponentInParent<PlayerAnimation>();
        gunAudio=GetComponent<AudioSource>();
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
                        damage.TakeDamage(damageAmount);
                }
            }
        }

        else
        {
            //TODO: Add out of ammo audio clip
        }
        
    }

    private IEnumerator ShotEffect()
    {
        gunAudio.Play();

        anim.OnShoot();
        yield return shotDuration;
    }
}
