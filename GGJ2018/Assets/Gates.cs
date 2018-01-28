using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Gates : MonoBehaviour
{
    
    [SerializeField]
    private string ActivateGateA = "Fire1";
    [SerializeField]
    private string ActivateGateB = "Fire2";

    public Color ColorA = Color.blue;
    public Color ColorB = Color.red;
    public Color ColorDefault = Color.white;

    public Collider2D gate;
    public SpriteRenderer sprite;
    
    void Update()
    {
        if (Input.GetButton(ActivateGateA))
        {
            sprite.color = ColorA;
            gate.gameObject.layer = 8;
        }
        else if (Input.GetButton(ActivateGateB))
        {
            sprite.color = ColorB;
            gate.gameObject.layer = 9;
        }
        else
        {
            sprite.color = ColorDefault;
            gate.gameObject.layer = 0;
        }

    }
}
