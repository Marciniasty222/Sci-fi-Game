using UnityEngine;
using UnityEngine.UI;

public class GunShooting : MonoBehaviour {

    public Text ammoCounter;

    Animator animator;

    public GameObject bullet;
    Transform bulletStartingPoint;

    GameObject firedBullet;

    public float bulletSpeed;
    public float dmg;

    public int ammo;
    public int maxAmmo;

    float fireRate;
    float shootInterval = 0.0f;

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
    }
	
	
	void Update ()
    {
        shootInterval -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (shootInterval <= 0.0f)
            {
                if (ammo > 0)
                {
                    animator.SetTrigger("PistolFire");
                    firedBullet = Instantiate(bullet, bulletStartingPoint.position, gameObject.transform.rotation);
                    firedBullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward.normalized * bulletSpeed);
                    firedBullet.GetComponent<Bullet>().bulletDMG = dmg;

                    ammo--;
                    ammoCounter.text = ammo.ToString();
                }
                shootInterval = fireRate;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
            ammoCounter.text = ammo.ToString();
        }
	}


    void Reload()
    {
        ammo = maxAmmo;
    }
}
