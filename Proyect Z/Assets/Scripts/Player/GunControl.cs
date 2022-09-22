using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public float reload;

    PlayerGun[] guns;

    bool shoot;

    void Start()
    {
        guns = transform.GetComponentsInChildren<PlayerGun>();

        ChangeReload(reload);
    }

    private void FixedUpdate()
    {
        shoot = Input.GetKey(KeyCode.Mouse0);

        if (shoot)
        {
            foreach (PlayerGun gun in guns)
            {
                gun.Shoot();
            }
        }
    }

    public void ChangeReload(float e)
    {
        foreach (PlayerGun gun in guns)
        {
            gun.reload = e;
        }
    }
}
