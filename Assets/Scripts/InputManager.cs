using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Vector2 touchStartPosition;
    private SwipableObject touchedObject;
    private RaycastHit hit;

    private void Start()
    {
        touchedObject = null;
    }

    void Update()
    {
        if (Input.touchCount>0)
        {
            Debug.Log("touches : " + Input.touchCount);

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hit, 100, 1 << 8))
                {
                    if ((touchedObject = hit.collider.gameObject.GetComponent<SwipableObject>())!= null)
                    {
                        touchStartPosition = touch.position;
                    }
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                if (touchedObject!= null)
                {
                    touchedObject.Push(touch.position - touchStartPosition);
                    touchedObject = null;
                }
            }
        }
    }
}
