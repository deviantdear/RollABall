using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpSpawner2 : MonoBehaviour
{
    public Transform prefabToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if(!((i==1 || i==2) && (j==2 || j==1)))
                {
                    float xpos = transform.position.x + i * 13.25f;
                    float zpos = transform.position.z + j * 13.25f;
                    Object instanceObj = Instantiate(prefabToSpawn, new Vector3(xpos, 4.85f, zpos), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
