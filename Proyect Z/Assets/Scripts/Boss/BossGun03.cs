using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun03 : MonoBehaviour
{
    public AIBullet bullet;

    private Vector2 direction;

    private float shootLoad;
    public float reload;


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

            Quaternion newRot = Quaternion.Euler(new Vector3(0, 0, (transform.rotation.eulerAngles.z - 180)));

            GameObject go = Instantiate(bullet.gameObject, transform.position, newRot);
            AIBullet goBullet = go.GetComponent<AIBullet>();
            goBullet.direction = direction;
        }
    }
}
