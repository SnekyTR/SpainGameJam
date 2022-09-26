using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun02 : MonoBehaviour
{
    private float shootLoad;
    public float reload;

    public GameObject bullet;

    private void FixedUpdate()
    {
        ShootAI();
    }

    private void ShootAI()
    {
        shootLoad += Time.fixedDeltaTime;

        if (shootLoad >= reload)
        {
            shootLoad = 0;

            Destroy(Instantiate(bullet.gameObject, transform.position, Quaternion.identity), 8);

        }
    }
}
