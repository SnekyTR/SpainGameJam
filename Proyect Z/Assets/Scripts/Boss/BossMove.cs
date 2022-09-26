using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public float moveSpeed;

    private float multi = -1f;

    bool firstMove;

    public GameObject shield01, shield02, explosion;

    void Start()
    {
        StartCoroutine(FirstMoveOff());
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!firstMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.5f,0,0), 2 * Time.fixedDeltaTime);
        }
        else
        {
            MoveAI();
        }
    }

    private void MoveAI()
    {
        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime * multi;
        Vector2 move = Vector2.zero;

        move.y += moveAmount;

        pos += move;

        if (pos.y <= -3f)
        {
            multi = 1f;

            int rnd = Random.Range(0, 100);

            if (rnd <= 10)
            {
                Instantiate(shield02, new Vector3(0, 0, 0), Quaternion.identity);
            }
            else if(rnd >= 80)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
            }
        }

        if (pos.y >= 3f)
        {
            multi = -1f;

            int rnd = Random.Range(0, 100);

            if(rnd <= 10)
            {
                Instantiate(shield01, new Vector3(0, 0, 0), Quaternion.identity);
            }
            else if (rnd >= 80)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
            }
        }

        transform.position = pos;
    }

    private IEnumerator FirstMoveOff()
    {
        yield return new WaitForSeconds(6f);

        firstMove = true;
    }
}
