using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject coinPrefab;
    public bool dropCoin;
    
    public void DestroyExplosion()
    {
        if (dropCoin)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }
}
