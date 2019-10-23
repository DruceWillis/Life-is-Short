using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceivingSystem : MonoBehaviour
{
    GameObject weapon;
    float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        damage = FindObjectOfType<DamageDealingSystem>().weaponDamage;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject == GameObject.FindGameObjectWithTag("PlayerWeapon"))
            Debug.Log("I've received" + damage);
    }

}
