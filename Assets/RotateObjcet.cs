using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjcet : MonoBehaviour
{
    [SerializeField]
    float speed;

    float zRotation;

    // Update is called once per frame
    void Update()
    {
        zRotation += Time.deltaTime * speed;
        transform.rotation = Quaternion.Euler(0, 0, zRotation);
    }
}
