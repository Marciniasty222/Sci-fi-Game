using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour {

    public List<ItemAsset> items;
    public GameObject selected;

	void Start () {
		
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUpItem();
        }
    }

    void PickUpItem()
    {
        RaycastHit hit;

        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2.0f);
        selected = hit.transform.gameObject;
        items.Add(selected.GetComponent<OverworldItem>().itemAsset);
        Destroy(selected);
    }
}
