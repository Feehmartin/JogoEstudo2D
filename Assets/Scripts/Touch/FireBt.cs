using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBt : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Fire()
    {
        player.touchFire = true;
    }
}
