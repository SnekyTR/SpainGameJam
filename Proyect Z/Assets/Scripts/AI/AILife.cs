using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AILife : MonoBehaviour
{
    public int health;
    public OperationCol oper;
    public List<GameObject> puObj;
    public GameObject lifeObj;

    private GameManager gm;

    public Color dmgColor;

    public GameObject explode;

    private IEnumerator courutine01;

    public bool negative;

    public bool boss;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        health *= (int)(1 + (gm.GetProgress() / 75));
    }

    public void SetLife(int e)
    {
        if (health <= 0)
        {
            return;
        }

        health += e;

        if(health <= 0)
        {
            if (boss)
            {
                gm.FinishGame();

                return;
            }

            int value00 = 0;

            if (gm.GetProgress() <= 30)
            {
                value00 = 30;
            }
            else if (gm.GetProgress() <= 60)
            {
                value00 = 60;
            }
            else if (gm.GetProgress() <= 120)
            {
                value00 = 100;
            }

            int rnd01 = Random.Range(0, value00);

            if(rnd01 >= 5)
            {
                int rnd = Random.Range(0, 100);

                if (rnd <= 40)
                {
                    InstianteOperation();
                }
                else if (rnd <= 85)
                {
                    InstiantePU();
                }
                else if (rnd <= 100)
                {
                    InstianteLife();
                }
            }

            Destroy(Instantiate(explode, transform.position, transform.rotation), 0.4f);

            Destroy(gameObject);
        }
        else
        {
            if(courutine01 != null)
            {
                StopCoroutine(courutine01);
                courutine01 = null;
            }

            courutine01 = RecieveDmg();
            StartCoroutine(courutine01);
        }
    }

    private void InstianteOperation()
    {
        GameObject operC = Instantiate(oper.gameObject, transform.position, Quaternion.identity);
        OperationCol op = operC.GetComponent<OperationCol>();

        int value01 = 0;
        int value02 = 0;

        if(gm.GetProgress() <= 30)
        {
            value01 = 4;
            value02 = 3;
        }
        else if(gm.GetProgress() <= 60)
        {
            value01 = 5;
            value02 = 5;
        }
        else if (gm.GetProgress() <= 120)
        {
            value01 = 6;
            value02 = 5;
        }

        int rnd01 = Random.Range(1, value01);
        int rnd02 = Random.Range(1, 100);

        if (negative)
        {
            if (rnd02 >= 50)
            {
                rnd02 = 2;
            }
            else if (rnd02 < 50 && value02 >= 5)
            {
                rnd02 = 4;
            }
            else
            {
                rnd02 = 2;
            }
        }
        else
        {
            if (rnd02 >= 50)
            {
                rnd02 = 1;
            }
            else if (rnd02 < 50 && value02 >= 5)
            {
                rnd02 = 3;
            }
            else
            {
                rnd02 = 1;
            }
        }
        

        op.SetValues(rnd01, rnd02);
    }

    private void InstiantePU()
    {
        int value01 = 0;
        int value02 = 0;

        if (gm.GetProgress() <= 30)
        {
            value01 = 25;
            value02 = 25;
        }
        else if (gm.GetProgress() <= 60)
        {
            value01 = 75;
            value02 = 75;
        }
        else if (gm.GetProgress() <= 100)
        {
            value01 = 100;
            value02 = 100;
        }

        int rnd01 = Random.Range(0, value01);
        int rnd02 = Random.Range(0, value02);

        if(rnd01 > rnd02 || rnd01 == rnd02)
        {
            if (rnd01 <= 50)
            {
                Instantiate(puObj[3].gameObject, transform.position, Quaternion.identity);
            }
            else if (rnd01 <= 100)
            {
                Instantiate(puObj[4].gameObject, transform.position, Quaternion.identity);
            }
        }
        else if(rnd01 < rnd02)
        {
            if (rnd01 <= 20)
            {
                Instantiate(puObj[0].gameObject, transform.position, Quaternion.identity);
            }
            else if (rnd01 <= 50)
            {
                Instantiate(puObj[1].gameObject, transform.position, Quaternion.identity);
            }
            else if (rnd01 <= 100)
            {
                Instantiate(puObj[2].gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    private void InstianteLife()
    {
        Instantiate(lifeObj.gameObject, transform.position, Quaternion.identity);
    }

    private IEnumerator RecieveDmg()
    {
        GetComponent<SpriteRenderer>().color = dmgColor;

        yield return new WaitForSeconds(0.4f);

        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
