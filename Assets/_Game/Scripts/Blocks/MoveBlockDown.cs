using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityAtoms;

public class MoveBlockDown : MonoBehaviour
{
    
    [SerializeField] private FloatVariable FallingDuration;
    
    void Start()
    {
        FindObjectOfType<LineDestroyer>().OnAllTetrisesChecked += MoveDown;
    }

    void MoveDown(List<int> rowsDestroyed)
    {

        for (int i=rowsDestroyed.Count; i > 0; i--)
        {
            if (rowsDestroyed[i-1] < transform.position.y)
            {
                StartCoroutine(MoveDownCoroutine(i));
                return;
            }

        }
    }

    IEnumerator MoveDownCoroutine(int i)
    {
        while (i > 0)
        {
            transform.DOMove(transform.position + Vector3.down, FallingDuration.Value);

            yield return new WaitForSeconds(FallingDuration.Value);
            
            i--;
        }
    }
}
