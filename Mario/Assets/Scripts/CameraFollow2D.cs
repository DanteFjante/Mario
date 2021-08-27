using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow2D : MonoBehaviour
{
    public Transform followObject;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        if (transform == null)
        {
            gameObject.SetActive(false);
            Debug.LogError("No Transform to follow");
            return;
        }

        offset = followObject.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followObject.position - offset;
    }
}
