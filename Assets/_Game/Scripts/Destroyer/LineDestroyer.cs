using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using UnityAtoms;
using UnityEngine;

public class LineDestroyer : MonoBehaviour
{
    [SerializeField] private IntVariable FieldSize;
    [SerializeField] private IntVariable FieldHeight;

    [SerializeField] private LayerMask Targets_LayerMask;

    [SerializeField] private BoolVariable DebugModeOn;

    public delegate void MoveUpperRowsDown(List<int> DestroyedRows);
    public event MoveUpperRowsDown OnAllTetrisesChecked;
    
    public void CheckTetris()
    {
        List<int> DestroyedRows = new List<int>();
        
        for (int y=0; y < FieldHeight.Value; y++)
        {
            bool tetrisAchieved = true;
            
            for (int x=0; x < FieldSize.Value; x++)
            {
                
                RaycastHit[] hits = Physics.RaycastAll(transform.position + new Vector3(x,y), Vector3.forward * FieldSize.Value, Targets_LayerMask);

                if (hits.Length != FieldSize.Value)
                {
                    tetrisAchieved = false;
                    break;
                }

            }

            if(!tetrisAchieved) continue;
           
            Debug.Log("Tetris in Row: " + y);
            
            DestroyRow(y);
            
            DestroyedRows.Add(y);
        }

        if (DestroyedRows.Count > 0 && OnAllTetrisesChecked != null) OnAllTetrisesChecked(DestroyedRows);
    }

    private void Update()
    {
        if(!DebugModeOn) return;
        
        for (int y=0; y < FieldHeight.Value; y++)
        {
            for (int x=0; x < FieldSize.Value; x++)
            {

                Debug.DrawRay(transform.position + new Vector3(x,y), Vector3.forward * FieldSize.Value, Color.red);
              
            }    
        }
    }

    void DestroyRow(int y)
    {
        for (int x=0; x < FieldSize.Value; x++)
        {
            RaycastHit[] hits = Physics.RaycastAll(transform.position + new Vector3(x,y), Vector3.forward * FieldSize.Value, Targets_LayerMask);

            foreach (RaycastHit block in hits)
            {
                Destroy(block.transform.gameObject);
            }
        }
    }
}
