using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletDMG;
	
	void Start () {
		
	}
	
	
	void Update () {
		
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

        Destroy(gameObject);
    }
}
