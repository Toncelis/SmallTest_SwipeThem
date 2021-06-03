using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
[RequireComponent(typeof(Rigidbody))]
public class Car : MonoBehaviour
{
    [SerializeField] private float speed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.forward * speed;    
    }
}
#pragma warning restore 649
