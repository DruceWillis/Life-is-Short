using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealingSystem : MonoBehaviour
{
    public float weaponDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("I've just hit this guy for " + weaponDamage);    
    }

}
