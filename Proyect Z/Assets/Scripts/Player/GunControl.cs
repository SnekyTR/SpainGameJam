using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    [HideInInspector] public float reload;

    PlayerGun[] guns;

    bool shoot;

    void Awake()
    {
        guns = transform.GetComponentsInChildren<PlayerGun>();
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

    public PlayerGun[] GetPlayerGun()
    {
        return guns;
    }
}
