using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto : MonoBehaviour
{
    void Start()
    {
        if (!PlayerPrefs.HasKey("tutorialDone"))
        {
            PlayerPrefs.SetInt("tutorialDone", 1);

            Destroy(gameObject, 12f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -280, 0), 60 * Time.deltaTime);
    }
}
