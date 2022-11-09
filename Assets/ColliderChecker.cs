using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderChecker : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Stop Hitting Me " + other.gameObject.name);
        Destroy(gameObject);
    }
}
