using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEnter : MonoBehaviour {

    public UnityEvent OnCollEnter;

    void OnCollisionEnter2D(Collision2D other)
    {
        OnCollEnter.Invoke();
    }
}
