using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<InputManager>().onRotatePressed += RotateBlocks;
    }

    void RotateBlocks(Vector3 rotationAxis)
    {
        transform.Rotate(rotationAxis, 90, Space.World);
    }

    public void RemoveAfterFall()
    {
        FindObjectOfType<InputManager>().onRotatePressed -= RotateBlocks;
        Destroy(this);
    }
}
