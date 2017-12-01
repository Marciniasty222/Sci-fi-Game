using UnityEngine;
using UnityEngine.UI;

public class RifleShooting : MonoBehaviour
{
    public Text ammoCounter;

    Animator animator;

    public GameObject bullet;
    Transform bulletStartingPoint;

    GameObject firedBullet;

    public float bulletSpeed;
    public float dmg;

    public int ammo;
    public int maxAmmo;

    public float reloadTime;
    float isReloading = 0f;

    float fireRate;
    float shootInterval = 0f;

    void Start ()
    {
        bulletStartingPoint = gameObject.transform.Find("BulletStartingPoint");
        maxAmmo = GetComponent<GunProperties>().maxAmmo;
        ammo = GetComponent<GunProperties>().ammo;
        fireRate = GetComponent<GunProperties>().fireRate;
        dmg = GetComponent<GunProperties>().dmg;
        bulletSpeed = GetComponent<GunProperties>().bulletSpeed;

        animator = GetComponentInParent<Animator>();

        ammoCounter.text = ammo.ToString();

        reloadTime = GetComponent<GunProperties>().reloadTime;
    }


    void Update ()
    {
        shootInterval -= Time.deltaTime;

        if (Input.GetMouseButton(0) && isReloading <= 0f)
        {
            if (shootInterval <= 0.0f)
            {
                if (ammo > 0)
                {
                    animator.SetTrigger("RifleFire");

                    firedBullet = Instantiate(bullet, bulletStartingPoint.position, gameObject.transform.rotation);
                    firedBullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward.normalized * bulletSpeed);
                    firedBullet.GetComponent<Bullet>().bulletDMG = dmg;

                    ammo--;
                    ammoCounter.text = ammo.ToString();
                }
                shootInterval = fireRate;
            }
        }

            if (Input.GetKeyDown(KeyCode.R) && isReloading <= 0f && ammo!=maxAmmo)
        {
            Reload();
        }
        isReloading -= Time.deltaTime;
        
    }


    void Reload()
    {
        isReloading = reloadTime;
        ammo = maxAmmo;
        ammoCounter.text = ammo.ToString();
        animator.SetTrigger("Reload");
    }
}
