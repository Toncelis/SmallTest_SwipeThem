using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
[RequireComponent(typeof(Rigidbody))]
public class SwipableObject : MonoBehaviour
{
    [SerializeField] private float pushedSpeed;
    private Rigidbody myRb;

    private void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    public void Push (Vector3 direction)
    {
        myRb.velocity = direction.normalized * pushedSpeed;
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.transform.CompareTag("Player"))
        {
            LevelManager.GetInstance().Lose();
        }
    }
}
#pragma warning restore 649
