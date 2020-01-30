using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject player2;
    private Vector3 offset;
    private Vector3 offset1;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        offset1 = transform.position - player2.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        transform.position = player2.transform.position + offset1;
    }
}
