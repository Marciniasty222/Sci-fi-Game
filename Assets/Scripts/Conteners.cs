using UnityEngine;

public class Conteners : MonoBehaviour, IDestructable, IDamageable<float> {

    public float HP = 100f;

    public GameObject destroyedPrefabVersion;

    void Update()
    {
        if (HP <= 0f)
        {
            Destroy();   
        }
    }


    public void Destroy()
    {
        Instantiate(destroyedPrefabVersion, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }

    public void Damage(float damageTaken)
    {
        HP -= damageTaken;
    }
}
