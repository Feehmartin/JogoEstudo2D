using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightBt : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isRight;
    private Player player;
    public float movement;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    void Update()
    {

        if (Input.GetMouseButton(0) && isRight)
        {
            movement += Time.deltaTime;
            if (movement > 1f)
            {
                movement = 1f;
            }

        }

        player.movement = movement;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isRight = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        isRight = false;
        movement = 0f;
    }
}
