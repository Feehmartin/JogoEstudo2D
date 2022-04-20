using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;


    public int damage;

    public bool isRight;
    void Start()
    {
        //colocamos o destroy para as flechas não ficarem pesando no processamento do game 
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }

    
    void FixedUpdate()  
    {
       //para mostrar em quao direçao a flecha tem que ir 
       if (isRight)
        {
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            rig.velocity = Vector2.left * speed;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyGuy>().Damage(damage);
            Destroy(gameObject);
        }
    }




}
