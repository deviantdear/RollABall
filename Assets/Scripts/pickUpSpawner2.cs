using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpSpawner2 : MonoBehaviour
{
    private float pick;
    public Transform prefabToSpawn_1;
    public Transform prefabToSpawn_2;
    public Transform prefabToSpawn_3;
    public Transform prefabToSpawn_4;

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
                    //Object instanceObj = Instantiate(prefabToSpawn, new Vector3(xpos, 4.85f, zpos), Quaternion.identity);

                    pick = Random.Range(0f, 4f);
                    Transform instanceObj;

                    if (pick < 1)
                    {
                        instanceObj = Instantiate(prefabToSpawn_1, new Vector3(xpos, 4.85f, zpos), Quaternion.identity);
                    }
                    else if ((pick >= 1) && (pick < 2))
                    {
                        instanceObj = Instantiate(prefabToSpawn_2, new Vector3(xpos, 4.85f, zpos), Quaternion.identity);
                    }
                    else if ((pick >= 2) && (pick < 3))
                    {
                        instanceObj = Instantiate(prefabToSpawn_3, new Vector3(xpos, 4.85f, zpos), Quaternion.identity);
                    }
                    else
                    {
                        instanceObj = Instantiate(prefabToSpawn_4, new Vector3(xpos, 4.85f, zpos), Quaternion.identity);
                    }
                    //Debug.Log(Random.Range(0f, 3f));
                    instanceObj.localScale = 2 * instanceObj.localScale;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
