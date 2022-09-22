using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI01 : MonoBehaviour
{
    public AIBullet bullet;

    private Vector2 direction;

    private float shootLoad;
    public float reload;

    void Start()
    {
        
    }

    void Update()
    {
        
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
            direction = (transform.rotation * Vector2.right).normalized;
            shootLoad = 0;

            GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
            AIBullet goBullet = go.GetComponent<AIBullet>();
            goBullet.direction = direction;
        }
    }
}
