using System.Collections;
using UnityEngine;

public class SniperZoom : MonoBehaviour {               //naprawić błąd ze gdy za szybko się kliknie scope dwa razy bod rząd
                                                        //naprawić sortowanie UI
    public GameObject scopeOverlay;
    public float scopedFOV;
    float normalFOV = 60f;

    bool isScoped = false;

    GameObject weaponCamera;

    Animator animator;
    
	void Start () {
        weaponCamera = GameObject.Find("WeaponCamera");

        animator = GetComponentInParent<Animator>();
	}
	

	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            isScoped = !isScoped;
            animator.SetBool("Scoped", isScoped);
            if (isScoped)
            {
                StartCoroutine(ScopeIn());
            }
            else
            {                
                ScopeOut();
            }
        }
	}

    void ScopeOut()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);
        Camera.main.fieldOfView = normalFOV;

    }

    IEnumerator ScopeIn()
    {
        yield return new WaitForSeconds(0.1f);
        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);
        Camera.main.fieldOfView = scopedFOV;
    }
}
