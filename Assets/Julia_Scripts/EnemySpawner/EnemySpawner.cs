using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int maxSpawns;
    GameObject enemyPrefab;
    public bool isDead;
    public bool isTarget;

    void Start()
    {
        
    }

    void SpawnEnemies()
    {
        for(int i = 0; i > maxSpawns; i++)
        {
            enemyPrefab.gameObject.SetActive(true);
        }
    }
}
