//------------------------------------------------------------------------------
// Copyright © 2018 alchemedium LLC. All Rights Reserved.
// Author: Ryan Brolley
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    public float checkFrequency = 0.1f;
    public float spawnVarianceRadius = 0.5f;
    public List<CellType> cellTypeData;
    public List<GameObject> spawnLocations;

    private void Start()
    {
        StartCoroutine(StartSpawner());
    }

    private IEnumerator StartSpawner()
    {
        while (true)
        {
            Check();
            yield return new WaitForSeconds(checkFrequency);
        }
    }

    private void Check()
    {
        for (int i = 0; i < cellTypeData.Count; i++)
        {
            var data = cellTypeData[i];
            if (data.Cells.Count < data.size)
            {
                var go = Instantiate(data.prefab);
                go.transform.position = GetSpawnLocation();
                data.Cells.Add(go);
            }
        }
    }

    private Vector3 GetSpawnLocation()
    {
        var index = Random.Range(0, spawnLocations.Count);
        return spawnLocations[index].transform.position + (Vector3)(Random.insideUnitCircle * spawnVarianceRadius);
    }

    void OnDrawGizmos()
    {
        // Draw spawn radius.
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        foreach (var spawn in spawnLocations)
        {
            Gizmos.DrawSphere(spawn.transform.position, spawnVarianceRadius);
        }
    }
}

[System.Serializable]
public class CellType
{
    public int size = 10;
    public GameObject prefab;

    public List<GameObject> Cells {  get { return _cells; } }

    private List<GameObject> _cells = new List<GameObject>();
}
