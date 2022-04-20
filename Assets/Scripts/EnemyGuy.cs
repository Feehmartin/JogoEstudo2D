using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyGuy : MonoBehaviour
{
    public float speed;
    public float walkTime;

    public int health; //variavel da vida do inimigo
    public int damage = 1;

    public GameObject explosionPrefab;

    private float timer;
    protected bool walkRight;


    private Animator anim;
    private Rigidbody2D rig;


    protected virtual void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
    }

    
    protected virtual void FixedUpdate()
    {
        //colocando timer na movimentacao para o personagem virar
        timer += Time.deltaTime;

        if (timer >= walkTime)
        {


            walkRight = !walkRight;
            timer = 0f;
        }
        
        if (walkRight)
        {
            //rotacao do personagem
            transform.eulerAngles = new Vector2(0, 0);

            
            
            
            //logica para andar
            rig.velocity = Vector2.left * speed;
        }
        

        else
        {
            //rotacao do personagem
            transform.eulerAngles = new Vector2(0, 180);

            //logica para andar
            rig.velocity = Vector2.right * speed;
        }


       
    
   } 

    //metodo para quando a flecha acertar de o dano e ative a anima�ao
    public virtual void Damage(int dmg)
    {       
         health -= dmg; //dano  
        anim.SetTrigger("Hit");

        if (health <= 0)
        {
            //dentroi o inimigo
            Instantiate(explosionPrefab, transform.position, quaternion.identity);
            Destroy(gameObject);
        }
    }

    //chamando o metodo que empurra o player 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Damage(damage, collision.gameObject.transform.position - transform.position);
        }
    }



}
