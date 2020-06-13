﻿using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpawnDelay;
    [SerializeField] float maxSpawnDelay;
    [SerializeField] Attacker[] attackerPrefabs;

    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        var attacker = attackerPrefabs[Random.Range(0, attackerPrefabs.Length + 1)];
        Spawn(attacker);
    }

    private void Spawn(Attacker attackerPrefab)
    {
        Attacker newAttacker = Instantiate(attackerPrefab, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
