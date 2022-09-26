using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI04 : MonoBehaviour
{
    private Vector2 direction;
    private Vector2 velocity;

    public int number;

    public float moveSpeed;
    GameManager gm;
    public GameObject explode;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        direction = (gm.player.transform.position - transform.position).normalized;

        Vector3 vecTarget = transform.position - gm.player.transform.position;

        float angle = Mathf.Atan2(vecTarget.y, vecTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = q;

        Destroy(gameObject, 6);
    }

    void Update()
    {
        velocity = direction * moveSpeed;
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
            int newNum = gm.GetEnergy() + number;
            gm.SetEnergy(newNum);
            Destroy(Instantiate(explode, transform.position, transform.rotation), 0.4f);
            Destroy(gameObject);
        }
    }
}
