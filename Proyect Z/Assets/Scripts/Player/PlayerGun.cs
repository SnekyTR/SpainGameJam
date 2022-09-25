using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public PlayerBullet bullet;
    Vector2 direction;
    [HideInInspector] public float reload;

    float shootLoad;
    GameManager gm;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Shoot()
    {
        shootLoad += Time.fixedDeltaTime;

        if(shootLoad >= reload)
        {
            direction = (transform.rotation * Vector2.right).normalized;
            shootLoad = 0;

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
