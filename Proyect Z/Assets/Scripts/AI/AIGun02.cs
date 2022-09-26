using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGun02 : MonoBehaviour
{
    public AIBullet bullet;
    Vector2 direction;

    public void Shoot()
    {
        StartCoroutine(ShotIA());
    }


    private IEnumerator ShotIA()
    {
        yield return new WaitForSeconds(0.35f);
        direction = (transform.rotation * Vector2.right).normalized;

        Quaternion newRot = Quaternion.Euler(new Vector3(0, 0, (transform.rotation.eulerAngles.z - 180)));

        yield return new WaitForSeconds(0.12f);

        GameObject go = Instantiate(bullet.gameObject, transform.position, newRot);
        AIBullet goBullet = go.GetComponent<AIBullet>();
        goBullet.direction = direction;
        yield return new WaitForSeconds(0.12f);

        GameObject go1 = Instantiate(bullet.gameObject, transform.position, newRot);
        AIBullet goBullet1 = go1.GetComponent<AIBullet>();
        goBullet1.direction = direction;
        yield return new WaitForSeconds(0.12f);

        GameObject go2 = Instantiate(bullet.gameObject, transform.position, newRot);
        AIBullet goBullet2 = go2.GetComponent<AIBullet>();
        goBullet2.direction = direction;
    }
}
