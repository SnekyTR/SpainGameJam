using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun01 : MonoBehaviour
{
    public AIBullet bullet;

    private Vector2 direction;

    private float shootLoad;
    public float reload;

    GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void FixedUpdate()
    {
        ShootAI();
    }

    private void ShootAI()
    {
        shootLoad += Time.fixedDeltaTime;

        if (shootLoad >= reload)
        {
            direction = (gm.player.transform.position - transform.position).normalized;

            Vector3 vecTarget = transform.position - gm.player.transform.position;

            float angle = Mathf.Atan2(vecTarget.y, vecTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

            shootLoad = 0;

            GameObject go = Instantiate(bullet.gameObject, transform.position, q);
            AIBullet goBullet = go.GetComponent<AIBullet>();
            goBullet.direction = direction;
        }
    }
}
