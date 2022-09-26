using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePU : MonoBehaviour
{
    Vector2 velocity;

    public float speed;
    private float multi = 1f;
    public Vector2 direction;
    [HideInInspector] public float initialPos;

    private void Start()
    {
        Destroy(gameObject, 12);
    }

    void Update()
    {
        velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        float moveAmount = speed * Time.fixedDeltaTime * multi;
        Vector2 move = Vector2.zero;

        move.y += moveAmount;

        pos += move;

        if (pos.y <= (initialPos - 1.2f))
        {
            multi = 1f;
        }

        if (pos.y >= (initialPos + 1.2f))
        {
            multi = -1f;
        }

        transform.position = pos;
    }
}
