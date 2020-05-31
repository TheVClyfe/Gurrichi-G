﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(1f,5f)]
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] float projectileDamage = 50f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //reduce health
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
        //if the collider is one that is an attacker
        if (attacker && health)
        {
            health.DealDamage(projectileDamage);
            Destroy(gameObject);
        }        
    }
}
