using System.Collections;
using UnityEngine;


public class ShootWeapon : MonoBehaviour
{
    [SerializeField]
    float fireRate = 0.25f;

    [SerializeField]
    int damageAmount = 10;

    [SerializeField]
    float maxAmmo = 30;

    [SerializeField] GameObject crossHair;

    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private WaitForSeconds reloadDuration;

    [SerializeField]
    private float nextFire, reloadDelay = 0.2f;

    float ammo = 30;

    PlayerAnimation anim;

    AudioSource gunAudio;

    public float Ammo { get => ammo; set => ammo = value; }
    public float ReloadDelay { get => reloadDelay; set => reloadDelay = value; }

    private void Start()
    {
        ammo = maxAmmo;
        anim = GetComponentInParent<PlayerAnimation>();
        gunAudio=GetComponent<AudioSource>();
        reloadDuration = new WaitForSeconds(ReloadDelay);
    }

    public void Shoot()
    {
        if(Ammo > 0 && Time.time > nextFire)
        {
            Ammo--;
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

    public void Reload()
    {
        nextFire = Time.time + ReloadDelay;
        StartCoroutine(ReloadTime());

        //TODO: Add reload audioclip
    }

    private IEnumerator ReloadTime()
    {
        ammo = maxAmmo;
        yield return reloadDuration;
    }
}
