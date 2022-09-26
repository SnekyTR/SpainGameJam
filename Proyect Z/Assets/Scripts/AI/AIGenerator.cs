using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGenerator : MonoBehaviour
{
    public List<Transform> positions01;
    public List<Transform> positions02;
    public List<Transform> positions03;

    public List<GameObject> IAs;

    private float shootLoad;
    public float reload;

    GameManager gm;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        AI01();
    }

    private void FixedUpdate()
    {
        Generate();
    }

    private void Generate()
    {
        shootLoad += Time.fixedDeltaTime;

        if (shootLoad >= (reload / (1 + (gm.GetProgress() / 75))))
        {
            shootLoad = 0;

            int rnd = Random.Range(1, 100);

            if (rnd >= 75)
            {
                AI03();
            }
            else if (rnd >= 50)
            {
                AI02();
            }
            else
            {
                AI01();
            }
        }
    }

    private void AI01()
    {
        int rnd = Random.Range(1, 100);

        Transform pos = positions01[0];

        if (rnd >= 75)
        {
            pos = positions01[0];
        }
        else if (rnd >= 50)
        {
            pos = positions01[1];
        }
        else
        {
            pos = positions01[2];
        }

        if (rnd >= 50)
        {
            Instantiate(IAs[0], pos.position, Quaternion.identity);
        }
        else
        {
            Instantiate(IAs[1], pos.position, Quaternion.identity);
        }
    }

    private void AI02()
    {
        int rnd = Random.Range(1, 100);

        Transform pos = positions02[0];

        if (rnd >= 75)
        {
            pos = positions02[0];
        }
        else if (rnd >= 50)
        {
            pos = positions02[1];
        }
        else
        {
            pos = positions02[2];
        }

        if (rnd >= 50)
        {
            Instantiate(IAs[2], pos.position, Quaternion.identity);
        }
        else
        {
            Instantiate(IAs[3], pos.position, Quaternion.identity);
        }
    }

    private void AI03()
    {
        int rnd = Random.Range(1, 100);

        Transform pos = positions03[0];

        if (rnd >= 50)
        {
            Instantiate(IAs[4], pos.position, Quaternion.identity);
        }
        else
        {
            Instantiate(IAs[5], pos.position, Quaternion.identity);
        }
    }
}
