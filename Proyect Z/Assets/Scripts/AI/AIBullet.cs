using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBullet : MonoBehaviour
{
    public float speed;
    public Vector2 direction = new Vector2(1, 0);

    private Vector2 velocity;

    void Start()
    {
        Destroy(gameObject, 3);
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerShip>().SetLife(-1);
            Destroy(gameObject);
        }
    }
}
