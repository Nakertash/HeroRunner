using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneObject : BeatableObject
{
    private GameObject DestroyableObject;
    public override void TakeDamage(float damage)
    {
        Instantiate(DestroyableObject,this.transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
