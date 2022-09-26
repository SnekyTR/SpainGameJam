using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI03 : MonoBehaviour
{
    private List<Transform> positions = new List<Transform>();
    public float speed;
    private Transform target;

    void Start()
    {
        Transform chi = GameObject.Find("Grid").transform;

        for (int i = 0; i < chi.childCount; i++)
        {
            positions.Add(chi.GetChild(i));
        }

        int rnd = Random.Range(0, positions.Count);

        target = positions[rnd];

        StartCoroutine(AsignateNewPos());
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
    }

    private IEnumerator AsignateNewPos()
    {
        yield return new WaitForSeconds(1.5f);

        int rnd = Random.Range(0, positions.Count);

        target = positions[rnd];

        StartCoroutine(AsignateNewPos());
    }
}
