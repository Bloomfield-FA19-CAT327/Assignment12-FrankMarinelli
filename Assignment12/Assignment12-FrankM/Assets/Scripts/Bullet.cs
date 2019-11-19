﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Bullet : NetworkBehaviour
{
    [SyncVar]
    public Color color;

    public override void OnStartClient()
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
