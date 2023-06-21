using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2, 6));
            Vector3 randPos = new Vector3(Random.Range(-13, 13), 0, Random.Range(-13, 13));
            Instantiate(Enemy, randPos, Quaternion.identity);
        }
    }

}
