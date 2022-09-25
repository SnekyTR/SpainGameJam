using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OperationCol : MonoBehaviour
{
    public int amount, operation;

    public Text txt;

    public void SetValues(int a, int b)
    {
        amount = a;
        operation = b;

        if(operation == 1)
        {
            a *= 5;
            txt.text = "+ " + a;
        }
        else if(operation == 2)
        {
            a *= 5;
            txt.text = "- " + a;
        }
        else if(operation == 3)
        {
            if (a == 1)
            {
                a += 1;
                txt.text = "x " + a;
            }
            else
            {
                txt.text = "x " + a;
            }
        }
        else if(operation == 4)
        {
            if (a == 1)
            {
                a += 1;
                txt.text = "/ " + a;
            }
            else
            {
                txt.text = "/ " + a;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            PlayerCollision();
            Destroy(gameObject);
        }
    }

    private void PlayerCollision()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (operation == 1)
        {
            amount *= 5;

            int newValue = gm.GetEnergy() + amount;

            gm.SetEnergy(newValue);
        }
        else if (operation == 2)
        {
            amount *= 5;

            int newValue = gm.GetEnergy() - amount;

            gm.SetEnergy(newValue);
        }
        else if (operation == 3)
        {
            if (amount == 1) amount += 1;

            int newValue = (int)(gm.GetEnergy() * amount);

            gm.SetEnergy(newValue);
        }
        else
        {
            if (amount == 1) amount += 1;

            int newValue = (int)(gm.GetEnergy() / amount);

            gm.SetEnergy(newValue);
        }
    }
}
