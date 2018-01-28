using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Gates : MonoBehaviour
{
    public bool flipControls = false;

    [Header("Gate A")]
    [SerializeField]
    private string ActivateGateA = "Fire1";
    public Color ColorA = Color.blue;
    public int passLayerA = 8;
    public int blockLayerA = 12;

    [Header("Gate B")]
    [SerializeField]
    private string ActivateGateB = "Fire2";
    public Color ColorB = Color.red;
    public int passLayerB = 9;
    public int blockLayerB = 13;

    [Header("Default State")]
    public Color ColorDefault = Color.white;
    public int passLayerDefault = 0;
    public int blockLayerDefault = 14;

    [Header("GameObject Refs")]
    public Collider2D gate;
    public Collider2D blocker;
    public SpriteRenderer sprite;
    
    void Update()
    {
        var openGateA = flipControls ? Input.GetButton(ActivateGateB) : Input.GetButton(ActivateGateA);
        var openGateB = flipControls ? Input.GetButton(ActivateGateA) : Input.GetButton(ActivateGateB);

        if (openGateA)
        {
            sprite.color = ColorA;
            gate.gameObject.layer = passLayerA;
            blocker.gameObject.layer = blockLayerA;
        }
        else if (openGateB)
        {
            sprite.color = ColorB;
            gate.gameObject.layer = passLayerB;
            blocker.gameObject.layer = blockLayerB;
        }
        else
        {
            sprite.color = ColorDefault;
            gate.gameObject.layer = passLayerDefault;
            blocker.gameObject.layer = blockLayerDefault;
        }

    }
}
