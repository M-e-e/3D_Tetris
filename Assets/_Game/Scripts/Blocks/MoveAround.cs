using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<InputManager>().onMovePressed += MoveBlocks;
    }

    void MoveBlocks(Vector3 moveDir)
    {
        transform.position += moveDir;
    }

    public void RemoveAfterFall()
    {
        FindObjectOfType<InputManager>().onMovePressed -= MoveBlocks;
        Destroy(this);
    }
}
