using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossExplosion : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.6f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.GetComponent<PlayerShip>().SetLife(-1);
        }
    }
}
