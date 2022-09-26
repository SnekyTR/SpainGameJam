using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI02 : MonoBehaviour
{
    private List<Transform> positions = new List<Transform>();
    public float speed;

    public GameObject tpFX;

    AIGun02[] guns;

    void Start()
    {
        Transform chi = GameObject.Find("Grid").transform;

        guns = GetComponentsInChildren<AIGun02>();

        for (int i = 0; i < chi.childCount; i++)
        {
            positions.Add(chi.GetChild(i));
        }

        StartCoroutine(AsignateNewPos());
    }

    private IEnumerator AsignateNewPos()
    {
        yield return new WaitForSeconds(3f);
        Destroy(Instantiate(tpFX, transform.position, transform.rotation, transform), 0.4f);
        yield return new WaitForSeconds(0.2f);

        int rnd = Random.Range(0, positions.Count);

        transform.position = positions[rnd].position;

        foreach(AIGun02 gun in guns)
        {
            gun.Shoot();
        }

        StartCoroutine(AsignateNewPos());
    }
}
