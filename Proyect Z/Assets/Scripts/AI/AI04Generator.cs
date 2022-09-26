using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI04Generator : MonoBehaviour
{
    public List<Transform> positions;

    public GameObject ai04_B, ai04_R;

    private float shootLoad;
    public float reload;

    GameManager gm;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void FixedUpdate()
    {
        if(gm.GetEnergy() >= 80 && gm.GetEnergy() <= 120)
        {
            Generate();
        }
    }

    private void Generate()
    {
        shootLoad += Time.fixedDeltaTime;

        if (shootLoad >= reload)
        {
            shootLoad = 0;

            int rnd = Random.Range(1, 100);
            Transform pos = positions[0];

            if(rnd >= 75)
            {
                pos = positions[0];
            }
            else if(rnd >= 50)
            {
                pos = positions[1];
            }
            else if (rnd >= 25)
            {
                pos = positions[2];
            }
            else
            {
                pos = positions[3];
            }

            if (rnd >= 50)
            {
                Instantiate(ai04_R, pos.position, Quaternion.identity);
            }
            else
            {
                Instantiate(ai04_B, pos.position, Quaternion.identity);
            }
        }
    }
}
