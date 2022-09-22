using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    public float rotation;

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, rotation) * Time.fixedDeltaTime);
    }
}
