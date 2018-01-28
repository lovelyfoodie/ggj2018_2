using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyListener : MonoBehaviour
{
    public List<string> keys;
    public UnityEvent OnPress;

    void Update()
    {
        foreach (var item in keys)
        {
            if (Input.GetButton(item))
            {
                OnPress.Invoke();
            }
        }
    }
}
