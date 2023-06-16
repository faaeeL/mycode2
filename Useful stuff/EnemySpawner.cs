using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private float _spawnRate;
    [SerializeField] private bool _canSpawn = true;
    [SerializeField] private Transform _spawnPosition;
    private void Start(){
        StartCoroutine(_Spawner());
    }
    private IEnumerator _Spawner(){
        WaitForSeconds wait = new WaitForSeconds(_spawnRate);
        while (_canSpawn)
        {
            yield return wait;
            int rand = Random.Range(0, _enemyPrefab.Length);
            GameObject enemyToSpawn = _enemyPrefab[rand];
            Instantiate(enemyToSpawn, _spawnPosition.position, Quaternion.identity);
        }
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            StopCoroutine(_Spawner());
        }
    }
    
}
