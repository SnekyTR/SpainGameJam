using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBullet : MonoBehaviour
{
    public float speed;
    public Vector2 direction = new Vector2(1, 0);

    private Vector2 velocity;

    public int amount;
    public int operation;

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
            PlayerCollision();
            Destroy(gameObject);
        }
    }

    private void PlayerCollision()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (operation == 1)
        {
            int newValue = gm.GetEnergy() + amount;

            gm.SetEnergy(newValue);
        }
        else if(operation == 2)
        {

        }
        else if(operation == 3)
        {

        }
        else
        {

        }
    }
}
