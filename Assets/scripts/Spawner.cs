using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject suitcasePrefab;
    


    public void Spawn()
    {
        GameObject caseObject = Instantiate(suitcasePrefab);
        
        Vector3 startpos = transform.position;
        startpos.z = 0f;
        caseObject.transform.position = startpos;
    }
}
