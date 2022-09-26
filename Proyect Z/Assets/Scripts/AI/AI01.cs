using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI01 : MonoBehaviour
{
    public AIBullet bullet;

    public Transform gun;
    private Vector2 direction;

    private float shootLoad;
    public float reload;

    public float moveSpeed;

    private float multi = -1f;

    private AudioSource audioS;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        ShootAI();

        MoveAI();
    }

    private void MoveAI()
    {
        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime * multi;
        Vector2 move = Vector2.zero;

        move.y += moveAmount;

        pos += move;

        if (pos.y <= -4.4f)
        {
            multi = 1f;
        }

        if (pos.y >= 4.4f)
        {
            multi = -1f;
        }

        transform.position = pos;
    }

    private void ShootAI()
    {
        shootLoad += Time.fixedDeltaTime;

        if (shootLoad >= reload)
        {
            direction = (transform.rotation * Vector2.left).normalized;
            shootLoad = 0;

            audioS.Play();

            GameObject go = Instantiate(bullet.gameObject, gun.position, Quaternion.identity);
            AIBullet goBullet = go.GetComponent<AIBullet>();
            goBullet.direction = direction;
        }
    }
}
