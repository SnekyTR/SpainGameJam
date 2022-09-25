using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet05 : MonoBehaviour
{
    private int bulletDmg;
    public int baseDmg;

    void Start()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        SetBulletDmg(gm.GetEnergy());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.transform.GetComponent<AILife>().SetLife(-bulletDmg);
        }
    }

    private void SetBulletDmg(int i)
    {
        bulletDmg = (int)(baseDmg * (1 + (i / 50)));
    }
}
