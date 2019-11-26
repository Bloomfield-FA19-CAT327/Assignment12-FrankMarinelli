using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameController : NetworkBehaviour

{
    public GameObject enemyPrefab;
    public GameObject bulletPrefab;

    private float spawnEnemyTime = 0;
    private float spawnEnemyBulletTIme = 0;
    public Rigidbody rb;

  


    void Update() //we only want a server to handle this!
    {
        if (isServer)
        {
            if (Time.fixedTime > spawnEnemyTime)
            {
                SpawnEnemy();
                SpawnBullet();
            }
        }
    }

    [Server]
    public void SpawnEnemy()
    {
        Vector3 position = new Vector3(Random.Range(-6.75f, 6.75f), Random.Range(1.0f, 8.0f), 4.5f);
        GameObject enemy = (GameObject)Instantiate(enemyPrefab, position, Quaternion.identity);
        NetworkServer.Spawn(enemy);
        spawnEnemyTime = Time.fixedTime + Random.Range(1, 4);
    }

    public void SpawnBullet()
    {
        Vector3 position = new Vector3(Random.Range(-6.75f, 6.75f), Random.Range(1.0f, 8.0f), 4.5f);
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, position, Quaternion.identity);
        NetworkServer.Spawn(bullet);
        spawnEnemyBulletTIme = Time.fixedTime + Random.Range(1, 4);
        bullet.GetComponent<Rigidbody>().velocity = Vector3.back * 25.5f;
        Destroy(bullet, 1.225f);
    }
}
