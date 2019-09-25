using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityAtoms;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    [SerializeField] private VoidEvent BlockHasFallen;

    [SerializeField] private LayerMask Ground_LayerMask;

    [SerializeField] private FloatVariable FallingDuration;

    private bool falling = false;
    
    public void LetBlockFall()
    {
        if(falling) return;
        falling = true;

        StartCoroutine(FallingCoroutine());

    }

    public void MoveBlocks(Vector3 move)
    {
        
    }

    IEnumerator FallingCoroutine()
    {
        if (NextPositionPossible())
        {
            transform.DOMove(transform.position + Vector3.down, FallingDuration.Value).SetEase(Ease.Linear);

            yield return new WaitForSeconds(FallingDuration.Value);
            
            StartCoroutine(FallingCoroutine());
        }
        else
        {
            AfterFall();
            
            BlockHasFallen.Raise();
            
        }
    }

    bool NextPositionPossible()
    {
        bool possible = true;
        
        foreach (Transform block in transform)
        {
            if (!NextPositionPossible(block))
                possible = false;
        }

        return possible;
    }
    
    bool NextPositionPossible(Transform block)
    {
        Collider[] intersecting = Physics.OverlapSphere(block.position + Vector3.down, 0, Ground_LayerMask);

        return intersecting.Length == 0;
    }

    void AfterFall()
    {
        //change physics layer to ground and unpack
        for (int bIndex = transform.childCount-1; bIndex >= 0; bIndex--)
        {
            transform.GetChild(bIndex).gameObject.layer = LayerMask.NameToLayer("Ground");

            transform.GetChild(bIndex).transform.SetParent(null);
        }
        
        /*
        foreach (Transform block in transform)
        {
            block.gameObject.layer = LayerMask.NameToLayer("Ground");

            block.transform.SetParent(null);
        }
        */
        
        Destroy(gameObject);
    }
}
