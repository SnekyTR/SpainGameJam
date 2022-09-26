using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public float speed;
    public Vector2 direction = new Vector2(1, 0);

    public GameObject newBackground;
    public Transform pivot;

    private Vector2 velocity;
    private bool isInstiante = false;

    void Start()
    {
        Destroy(gameObject, 7.5f);
    }

    void Update()
    {
        velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;

        if (!isInstiante && transform.position.x <= 0)
        {
            isInstiante = true;
            Instantiate(newBackground, pivot.position, Quaternion.identity);
        }
    }
}
