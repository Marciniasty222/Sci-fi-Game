using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacEnemy : MonoBehaviour, IKillable, IDamageable<float> {

    public float HP = 100.0f;

	void Start () {
		
	}
	
	
	void Update () {
        if (HP <= 0.0f) Kill();
	}

    public void Kill()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }

    public void Damage(float damageTaken)
    {
        HP -= damageTaken;
    }
}
