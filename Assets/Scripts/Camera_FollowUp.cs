using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
public class Camera_FollowUp : MonoBehaviour
{
    [SerializeField] private Transform transformToFollow;

    private Vector3 deltaPosition;

    private void Start()
    {
        deltaPosition = transform.position - transformToFollow.position;
    }
    private void Update()
    {
        transform.position = transformToFollow.position + deltaPosition;
    }
}
#pragma warning restore 649
