using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public Transform prefabToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                float xpos = transform.position.x + i * 5;
                float zpos = transform.position.z + j * 5;
                Object instanceObj = Instantiate(prefabToSpawn, new Vector3(xpos, 0.85f, zpos), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
