using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectRandomly : MonoBehaviour {
    ConstantForce cnstForce;
	// Use this for initialization
	void Start () {
        cnstForce = GetComponent<ConstantForce>();
	}
	
	void Update () {
        cnstForce.torque = new Vector3(Mathf.Clamp(cnstForce.torque.x / 10 + Random.Range(-3.5f, 3.5f), -10, 10), Mathf.Clamp(cnstForce.torque.y / 10 + Random.Range(-3.5f, 3.5f), -10, 10), Mathf.Clamp(cnstForce.torque.z / 10 + Random.Range(-3.5f, 3.5f), -10, 10)) * 10;
        transform.localScale = new Vector3(Mathf.Clamp(cnstForce.torque.x / 10 + Random.Range(-3.5f, 3.5f), -10, 10), Mathf.Clamp(cnstForce.torque.y / 10 + Random.Range(-3.5f, 3.5f), -10, 10), Mathf.Clamp(cnstForce.torque.z / 10 + Random.Range(-3.5f, 3.5f), -10, 10))/4;
    }
}
