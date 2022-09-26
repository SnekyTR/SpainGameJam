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

    GameManager gm;

    void Start()
    {
        gunC = transform.GetComponentsInChildren<GunControl>();

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

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

        if (collision.transform.tag == "LifePart")
        {
            MoreLife();
            Destroy(collision.gameObject);
        }
    }

    private void MoreLife()
    {
        gm.MoreLifes();
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
        yield return new WaitForSeconds((12f * gm.extraTime));

        gunC[1].gameObject.SetActive(false);
        gunC[2].gameObject.SetActive(false);

        PUExit();
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

        if (weaponType == 4)
        {
            gunC[0].transform.rotation = Quaternion.Euler(0, 0, 0);
            gunC[1].transform.rotation = Quaternion.Euler(0, 0, 45);
        }

        foreach (PlayerGun gun in gunC[0].GetPlayerGun())
        {
            gun.SetShootLoad(0);
        }

        foreach (PlayerGun gun in gunC[1].GetPlayerGun())
        {
            gun.SetShootLoad(0);
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

        if (weaponType == 4)
        {
            gunC[0].transform.rotation = Quaternion.Euler(0, 0, 0);
            gunC[1].transform.rotation = Quaternion.Euler(0, 0, 30);
            gunC[2].transform.rotation = Quaternion.Euler(0, 0, 60);
        }

        foreach (PlayerGun gun in gunC[0].GetPlayerGun())
        {
            gun.SetShootLoad(0);
        }

        foreach (PlayerGun gun in gunC[1].GetPlayerGun())
        {
            gun.SetShootLoad(0);
        }

        foreach (PlayerGun gun in gunC[2].GetPlayerGun())
        {
            gun.SetShootLoad(0);
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
