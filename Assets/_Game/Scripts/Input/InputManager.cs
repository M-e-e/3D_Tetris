using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms;

public class InputManager : MonoBehaviour
{
    [SerializeField] private VoidEvent LetBlockFall_Event;

    public delegate void MoveBlocks(Vector3 moveDir);
    public event MoveBlocks onMovePressed;

    public delegate void RotateBlocks(Vector3 rotationAxis);
    public event RotateBlocks onRotatePressed;
    
    void Update()
    {
        //let the block fall
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LetBlockFall_Event.Raise();
        }

        if (onMovePressed != null)
        {
            //Move
            if (Input.GetKeyDown(KeyCode.D))
            {
                //Right
                //MoveBlockRight_Event.Raise(Vector3.right);
                onMovePressed(Vector3.right);
            }
        
            if (Input.GetKeyDown(KeyCode.A))
            {
                //Left
                //MoveBlockLeft_Event.Raise(Vector3.left);
                onMovePressed(Vector3.left);
            }
        
            if (Input.GetKeyDown(KeyCode.W))
            {
                //Forward
                //MoveBlockForward_Event.Raise(Vector3.forward);
                onMovePressed(Vector3.forward);
            }
        
            if (Input.GetKeyDown(KeyCode.S))
            {
                //Back
                //MoveBlockBack_Event.Raise(Vector3.back);
                onMovePressed(Vector3.back);
            }
        }
        
        
        //Rotate
        if (onRotatePressed != null)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                onRotatePressed(Vector3.back);
            }
            
            if (Input.GetKeyDown(KeyCode.J))
            {
                onRotatePressed(Vector3.forward);
            }
            
            if (Input.GetKeyDown(KeyCode.I))
            {
                onRotatePressed(Vector3.right);
            }
            
            if (Input.GetKeyDown(KeyCode.K))
            {
                onRotatePressed(Vector3.left);
            }
        }
    }

}
