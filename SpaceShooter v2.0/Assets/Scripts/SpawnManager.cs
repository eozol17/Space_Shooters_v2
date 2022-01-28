using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    [SerializeField] 
    private GameObject enemy;
    [SerializeField] 
    private GameObject[] powerUps;
    [SerializeField]
    private int spawned = 0;
    [SerializeField]
    private GameObject enemyContainer;

    private bool Spawning = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
        StartCoroutine(spawnPowerUp());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator spawn()
    {

        while (Spawning == true)
        {
            Vector3 enemySpawnPoint = new Vector3(Random.Range(-9.3f, 9.3f), 7.5f, 0);
            if (spawned < 15)
            {
                GameObject newEnemy = Instantiate(enemy, enemySpawnPoint, Quaternion.identity);
                newEnemy.transform.parent = enemyContainer.transform;
                yield return new WaitForSeconds(2.0f);
                spawned++;
            }
            else
            {
                GameObject newEnemy =Instantiate(enemy, enemySpawnPoint, Quaternion.identity);
                newEnemy.transform.parent = enemyContainer.transform;
                yield return new WaitForSeconds(1.0f);
                spawned++;
            }
        }
    }

    IEnumerator spawnPowerUp()
    {

        while (Spawning == true)
        {
            Vector3 powerUpSpawnPoint = new Vector3(Random.Range(-9.3f, 9.3f), 7.5f, 0);
            int id = Random.Range(0, 3);
            GameObject newPu = Instantiate(powerUps[id], powerUpSpawnPoint, Quaternion.identity);
            newPu.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(Random.Range(9.3f, 12.3f));

        }
    }
    public void onPlayerDeath()
    {
        Spawning = false;
    }
}
