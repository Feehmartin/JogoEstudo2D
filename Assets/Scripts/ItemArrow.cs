using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemArrow : MonoBehaviour
{
    public int arrowsValue;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameController.instance.UpdateArrows(arrowsValue);
            Destroy(gameObject);
        }
    }
    
}
