using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public PlayerBullet bullet;
    Vector2 direction;
    [HideInInspector] public float reload;

    float shootLoad;

    public AudioSource audioS;

    public void Shoot()
    {
        shootLoad += Time.fixedDeltaTime;

        if(shootLoad >= reload)
        {
            direction = (transform.rotation * Vector2.right).normalized;
            shootLoad = 0;

            audioS.Play();

            GameObject go = Instantiate(bullet.gameObject, transform.position, transform.rotation);
            PlayerBullet goBullet = go.GetComponent<PlayerBullet>();
            goBullet.direction = direction;
        }
    }

    public void SetShootLoad(float e)
    {
        shootLoad = e;
    }

    public float GetShootLoad()
    {
        return shootLoad;
    }
}
