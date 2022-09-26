using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOperation : MonoBehaviour
{
    private float shootLoad;
    public float reload;

    public GameObject oper;

    GameManager gm;

    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

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

            InstianteOperation();

        }
    }

    private void InstianteOperation()
    {
        GameObject operC = Instantiate(oper.gameObject, transform.position, Quaternion.identity);
        OperationCol op = operC.GetComponent<OperationCol>();

        int value01 = 0;

        if (gm.GetProgress() <= 30)
        {
            value01 = 4;
        }
        else if (gm.GetProgress() <= 60)
        {
            value01 = 5;
        }
        else if (gm.GetProgress() <= 120)
        {
            value01 = 6;
        }

        int rnd01 = Random.Range(1, value01);
        int rnd02 = Random.Range(1, 100);

        if (rnd02 >= 75)
        {
            rnd02 = 1;
        }
        else if (rnd02 >= 50)
        {
            rnd02 = 2;
        }
        else if (rnd02 >= 25)
        {
            rnd02 = 3;
        }
        else
        {
            rnd02 = 4;
        }

        op.SetValues(rnd01, rnd02);
    }

}
