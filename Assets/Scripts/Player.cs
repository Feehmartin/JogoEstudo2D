using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int health = 3;

    public float speed;
    public float jumpForce;

    //intanciando a flecha
    public GameObject bow;
    //referenciar para saber da onde ta saindo o tiro
    public Transform firePoint;

    private bool isJumping;
    private bool doubleJump;
    private bool isFire;

    private Rigidbody2D rig;
    private Animator anim;

    public float movement;
    public bool isMobile;

    public bool touchJump;
    public bool touchFire;
    public float hitForce = 5;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        GameController.instance.UpdateLives(health);

    }


    void Update()
    {
        Jump();
        BowFire();
    }


    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //movimentacao do touch
        if (!isMobile)
        {
            //se nao pressionar nada valor �. Se pressionar ele da valor 1 oi -1     
            movement = Input.GetAxis("Horizontal");

        }


        // adiciona velocidade ao corpo do personagem no eixo x e y 
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);
        
        //andando para direita
        if (movement > 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 1);
            }

            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        //andando para esquqerda 
        if (movement < 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 1);
            }

            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        //movimentacao do personagem no iddle
        if (movement == 0 && !isJumping && !isFire)
        {
            anim.SetInteger("transition", 0);
        }


    }

    //para criar um double jump apenas add os codigos do double para pulo simples mantem os codigos sem o double 
    void Jump()
    {
        if (Input.GetButtonDown("Jump") || touchJump)
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 2);
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                isJumping = true;

            }
            else
            {
                if (doubleJump)
                {
                    anim.SetInteger("transition", 2);
                    rig.AddForce(new Vector2(0, jumpForce * 1), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }

            touchJump = false;

        }

    }
    //metoddo para atirar 
    void BowFire()
    {
        //chamando a corrotina para ser executada
        StartCoroutine("Fire");
    }

    // como declarar um corrotina, para o player atirar e depois voltar a anima��o normal 
    IEnumerator Fire()
    {
        if (GameController.instance.arrows > 0)
        {
            if (Input.GetKeyDown(KeyCode.E) || touchFire)
            {
            

                touchFire = false;
                isFire = true;
                anim.SetInteger("transition", 3);
                GameObject Bow = Instantiate(bow, firePoint.position, firePoint.rotation); // para atirar a flecha e firePoint que � de onde flecha vai sair 
                GameController.instance.UpdateArrows(-1);
                
                if (transform.rotation.y == 0)//para fazer a flecha ir para os dois lados do eixo
                {
                    Bow.GetComponent<Bow>().isRight = true;
                }


                if (transform.rotation.y == 180)
                {
                    Bow.GetComponent<Bow>().isRight = false;
                }


                yield return new WaitForSeconds(0.2f);
                isFire = false;
                anim.SetInteger("transition", 0);


            }
        }
    }

    //metodo da vida do player e o game over 

    public void Damage(int dmg, Vector3 hitDirection)

    {
        health -= dmg;
        GameController.instance.UpdateLives(health);
        anim.SetTrigger("hit");
        
        // para empurrar o player quando sofrer o dano
        hitDirection = new Vector3(hitDirection.x, 0, hitDirection.z);
        rig.AddForce(hitDirection * hitForce, ForceMode2D.Impulse);

        if (health <= 0)
        {
            //chamar gamer over
            GameController.instance.GameOver();
        }
    }

    //metodo para pegar o item e encher a vida 
    public void IncreaseLife(int value)
    {
        health += value;
        GameController.instance.UpdateLives(health);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = false;
        }

        if (collision.gameObject.layer == 7)
        {
            GameController.instance.GameOver();
        }


    }





}
