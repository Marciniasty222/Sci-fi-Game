using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    GameObject bullet;
    public float bulletSpeed;

    public float dmg;

    public int ammo;
    public int maxAmmo;

    float shootFrequency;
    float shootInterval = 0.0f;

	void Start () {
        maxAmmo = GetComponent<GunProperties>().maxAmmo;
        ammo = GetComponent<GunProperties>().ammo;
        shootFrequency = GetComponent<GunProperties>().shootFrequency;
        dmg = GetComponent<GunProperties>().dmg;
        bulletSpeed = GetComponent<GunProperties>().bulletSpeed;
    }
	
	
	void Update () {
        shootInterval -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (shootInterval <= 0.0f)
            {
                if (ammo > 0)
                {
                    bullet = Instantiate((GameObject)Resources.Load("Bullet"), gameObject.transform.position, gameObject.transform.rotation);
                    bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward.normalized * bulletSpeed);
                    bullet.GetComponent<Bullet>().bulletDMG = dmg;

                    ammo--;
                }
                shootInterval = shootFrequency;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
	}

    void Reload()
    {
        ammo = maxAmmo;
    }
}
