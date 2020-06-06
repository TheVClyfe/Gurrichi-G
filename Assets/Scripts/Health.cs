using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;
    
    public void DealDamage(float damage)
    {
        health -= damage;
        Debug.Log("Health is now: " + health.ToString());
        if(health <= 0)
        {
            Debug.Log("Gameobject destroy!");
            TriggerDeathVFX();
            Destroy(gameObject);            
        }
    }

    private void TriggerDeathVFX()
    {
        if(!deathVFX) { return; }
        var deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(deathVFXObject, 1f);
    }
}
