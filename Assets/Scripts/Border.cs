using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            other.GetComponent<SwipableObject>().enabled = false;
            LevelManager.GetInstance().RaiseScore();
        }
    }
}
