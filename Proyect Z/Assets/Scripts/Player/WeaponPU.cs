using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPU : MonoBehaviour
{
    public int weaponType;

    GunControl[] gunC;
    public float reload;

    IEnumerator courutinePU;
    IEnumerator courutineCR;

    public List<PlayerBullet> newBullets; 

    void Start()
    {
        gunC = transform.GetComponentsInChildren<GunControl>();

        foreach (GunControl gun in gunC)
        {
            gun.ChangeReload(reload);
        }

        gunC[1].gameObject.SetActive(false);
        gunC[2].gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "PU01")
        {
            PowerUp01();
            Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "PU02")
        {
            PowerUp02();
            Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "CReloadx2")
        {
            ChangeReload(2);
            Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "CReloadx3")
        {
            ChangeReload(3);
            Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "CReloadx4")
        {
            ChangeReload(4);
            Destroy(collision.gameObject);
        }
    }

    public void PowerUp01()
    {
        if(courutinePU != null)
        {
            StopCoroutine(courutinePU);
            courutinePU = null;
        }

        courutinePU = NewPU(1);

        PUExtra01();

        gunC[1].gameObject.SetActive(true);
        gunC[2].gameObject.SetActive(false);

        StartCoroutine(courutinePU);
    }

    public void PowerUp02()
    {
        if (courutinePU != null)
        {
            StopCoroutine(courutinePU);
            courutinePU = null;
        }

        courutinePU = NewPU(2);

        PUExtra02();

        gunC[1].gameObject.SetActive(true);
        gunC[2].gameObject.SetActive(true);

        StartCoroutine(courutinePU);
    }

    public void ChangeReload(int e)
    {
        float newR = reload / e;

        foreach (GunControl gun in gunC)
        {
            gun.ChangeReload(newR);
        }

        if (courutineCR != null)
        {
            StopCoroutine(courutineCR);
            courutineCR = null;
        }

        courutineCR = NewCR();

        StartCoroutine(courutineCR);
    }

    private IEnumerator NewPU(int e)
    {
        yield return new WaitForSeconds(12f);

        gunC[1].gameObject.SetActive(false);
        gunC[2].gameObject.SetActive(false);
    }

    private IEnumerator NewCR()
    {
        yield return new WaitForSeconds(12f);

        foreach (GunControl gun in gunC)
        {
            gun.ChangeReload(reload);
        }
    }

    private void PUExtra01()
    {
        if(weaponType == 5)
        {
            foreach (PlayerGun gun in gunC[0].GetPlayerGun())
            {
                gun.bullet = newBullets[1];
            }

            foreach (PlayerGun gun in gunC[1].GetPlayerGun())
            {
                gun.bullet = newBullets[1];
            }
        }
    }

    private void PUExtra02()
    {
        if (weaponType == 5)
        {
            foreach (PlayerGun gun in gunC[0].GetPlayerGun())
            {
                gun.bullet = newBullets[2];
            }

            foreach (PlayerGun gun in gunC[1].GetPlayerGun())
            {
                gun.bullet = newBullets[2];
            }

            foreach (PlayerGun gun in gunC[2].GetPlayerGun())
            {
                gun.bullet = newBullets[2];
            }
        }
    }

    private void PUExit()
    {
        if (weaponType == 5)
        {
            foreach (PlayerGun gun in gunC[0].GetPlayerGun())
            {
                gun.bullet = newBullets[0];
            }

            foreach (PlayerGun gun in gunC[1].GetPlayerGun())
            {
                gun.bullet = newBullets[0];
            }

            foreach (PlayerGun gun in gunC[2].GetPlayerGun())
            {
                gun.bullet = newBullets[0];
            }
        }
    }
}
