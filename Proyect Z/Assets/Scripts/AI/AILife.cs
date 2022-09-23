using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILife : MonoBehaviour
{
    public int health;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetLife(int e)
    {
        health += e;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
