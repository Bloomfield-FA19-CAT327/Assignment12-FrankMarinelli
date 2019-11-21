using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemyHealth : NetworkBehaviour
{
    [SyncVar]
    public float enemyHealth = 100f;

    public void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindGameObjectWithTag("Bullet"))
        {
            enemyHealth--;
            if(enemyHealth >= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
