using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public float bulletDestroy;
    public Vector2 direction = new Vector2(1, 0);

    public int baseDmg;

    private Vector2 velocity;

    private int bulletDmg;

    public GameObject explObj;

    void Start()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        SetBulletDmg(gm.GetEnergy(), gm.extraDmg);

        Destroy(gameObject, bulletDestroy);
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
        if(collision.transform.tag == "Enemy")
        {
            if(explObj != null)
            {
                Instantiate(explObj, transform.position, Quaternion.identity);
            }

            collision.transform.GetComponent<AILife>().SetLife(-bulletDmg);
            Destroy(gameObject); 
        }
    }

    private void SetBulletDmg(int i, float e)
    {
        bulletDmg = (int)(baseDmg * (1 + (i/50)) * e);
    }
}
