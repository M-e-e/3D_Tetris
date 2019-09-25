using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Blocks;

    [SerializeField] private FloatVariable SpawnDelay;

    //[SerializeField] private VoidEvent BlockMoveable;
    
    public void SpawnBlock()
    {
        StartCoroutine(SpawnBlockCoroutine());
    }

    IEnumerator SpawnBlockCoroutine()
    {
        yield return new WaitForSeconds(SpawnDelay.Value);

        Instantiate(Blocks[Random.Range(0, Blocks.Length)], transform.position, Quaternion.identity);
    }
}
