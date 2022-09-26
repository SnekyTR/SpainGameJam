using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBoss : MonoBehaviour
{
    public bool negative;

    GameManager gm;
    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.GetComponent<PlayerBullet>() || collision.transform.GetComponent<Bullet05>())
        {
            if (negative)
            {
                if(gm.GetEnergy() < 100)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Destroy(collision.gameObject);
                }
            }
            else
            {
                if (gm.GetEnergy() > 100)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<PlayerBullet>() || collision.transform.GetComponent<Bullet05>())
        {
            if (negative)
            {
                if (gm.GetEnergy() < 100)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Destroy(collision.gameObject);
                }
            }
            else
            {
                if (gm.GetEnergy() > 100)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
