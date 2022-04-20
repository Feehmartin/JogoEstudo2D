using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpBt : MonoBehaviour, IPointerDownHandler
{
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        player.touchJump = true;
    }

}
