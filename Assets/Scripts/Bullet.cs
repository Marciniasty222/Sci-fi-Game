using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletDMG;

    float bulletClearTime = 4f;
	
	void Start () {
		
	}
	
	
	void Update () {
        bulletClearTime -= Time.deltaTime;
        if (bulletClearTime <= 0f) Destroy(gameObject);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<IDamageable<float>>() != null)
            {
                collision.gameObject.GetComponent<IDamageable<float>>().Damage(bulletDMG);
            }
            
        }
        if(collision.gameObject.tag == "Container")
        {
            if (collision.gameObject.GetComponent<IDamageable<float>>() != null)
            {
                collision.gameObject.GetComponent<IDamageable<float>>().Damage(bulletDMG);
            }
        }

        Destroy(gameObject);
    }
}
