using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = offset + target.position;
    }
}
