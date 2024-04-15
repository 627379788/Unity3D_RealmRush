using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] [Range(0.1f, 30f)] float spawnTime = 3f;
    [SerializeField] [Range(0, 50)] int poolSize = 5;
    GameObject[] pool;
    
    void Awake() {
        PupolatePool();
    }

    void Start() {
        StartCoroutine(SpawnEnemy());
    }
    void PupolatePool() {
        pool = new GameObject[poolSize];

        for(int i = 0; i < poolSize; i++) {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);
        }
    }
    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    void EnableObjectInPool()
    {
        foreach(GameObject enemy in pool) {
            if(!enemy.activeInHierarchy) {
                enemy.SetActive(true);
                return;
            }
        }
    }
}
