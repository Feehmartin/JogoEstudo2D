using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{

    private Transform player;
    public float smooth; 
    
    void Start()
    {
       //para buscar alguma referencia ao player
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        //para camera nao ultrapassar a area do game
        if (player.position.x >= -1 && player.position.x <= 55)
        {
            //logica do movimento, posicao do personagem no x e posicao da camera no x e z 
            Vector3 following = new Vector3(player.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, following, smooth * Time.deltaTime);
        }
    }
}
