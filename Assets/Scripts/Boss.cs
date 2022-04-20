using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : EnemyGuy
{
    private int maxHealth;
    public Image lifeImage;

    protected override void Start()
    {
        base.Start();
        maxHealth = health;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        
        if (walkRight) //Flipa a barra de vida se o personagem estiver flipado
        {
            lifeImage.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            lifeImage.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    //metodo para quando a flecha acertar de o dano e ative a anima�ao
    public override void Damage(int dmg)
    {      
        base.Damage(dmg);
        lifeImage.fillAmount = (float) health / maxHealth; //mudar o fill amount da barrinha de vida
    }
}