using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    private Vector3 distanceFromBall = new Vector3 (0, 1.5f, 0);

    // Start is called before the first frame update
    void Start()
    {
        offset = (transform.position - player.transform.position) + distanceFromBall;
    }

    // Late Update is called once per frame after all other items in the frame have loaded
    void LateUpdate()
    { 
        transform.position = (player.transform.position + offset * 0.2f *player.transform.localScale.magnitude);
    }
}
