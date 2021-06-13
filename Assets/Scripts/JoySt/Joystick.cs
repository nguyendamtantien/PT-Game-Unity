using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerScript player;
    public void OnPointerDown(PointerEventData eventData)
    {
        if(gameObject.name == "Left")
        {
            player.SetMoveLeft(true);
        }
        if(gameObject.name == "Right")
        {
            player.SetMoveLeft(false);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.StopMoving();
    }

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent <PlayerScript> ();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
