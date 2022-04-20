using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue;
    public bool endGame;

        private void OnTriggerEnter2D(Collider2D collision)
    {
       //se o player bater na moeda
        if (collision.gameObject.tag == "Player")
        {
            GameController.instance.UpdateScore(scoreValue);
            if (endGame)
            {
                GameController.instance.WinGame();
            }
            Destroy(gameObject);
        }
    }
}
