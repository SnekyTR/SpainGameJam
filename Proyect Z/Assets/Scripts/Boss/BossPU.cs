using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPU : MonoBehaviour
{
    public List<GameObject> pu = new List<GameObject>();

    private float shootLoad;
    public float reload;

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

            int rnd02 = Random.Range(1, 100);

            if (rnd02 >= 75)
            {
                Instantiate(pu[0], transform.position, Quaternion.identity);
            }
            else if (rnd02 >= 50)
            {
                Instantiate(pu[1], transform.position, Quaternion.identity);
            }
            else if (rnd02 >= 25)
            {
                Instantiate(pu[2], transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(pu[2], transform.position, Quaternion.identity);
            }
        }
    }
}
