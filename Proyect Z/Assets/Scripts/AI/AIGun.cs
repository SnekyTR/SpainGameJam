using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGun : MonoBehaviour
{
    public AIBullet bullet;
    Vector2 direction;
    public float reload;

    float shootLoad;

    public AudioSource audioS;

    public void Shoot()
    {
        shootLoad += Time.fixedDeltaTime;

        if (shootLoad >= reload)
        {
            direction = (transform.rotation * Vector2.right).normalized;
            shootLoad = 0;

            audioS.Play();

            Quaternion newRot = Quaternion.Euler(new Vector3(0, 0, (transform.rotation.eulerAngles.z - 180)));

            GameObject go = Instantiate(bullet.gameObject, transform.position, newRot);
            AIBullet goBullet = go.GetComponent<AIBullet>();
            goBullet.direction = direction;
        }
    }

    private void FixedUpdate()
    {
        Shoot();
    }
}
