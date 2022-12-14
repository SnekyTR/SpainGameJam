using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShip : MonoBehaviour
{
    public float moveSpeed = 2;

    bool moveUp;
    bool moveDown;
    bool moveRight;
    bool moveLeft;

    [SerializeField]
    private int life;
    private int maxLife;

    private GameManager gm;

    private IEnumerator courutine;

    void Start()
    {
        maxLife = life;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime * (1 + (gm.GetEnergy() / 150f)) * gm.extraVel;
        Vector2 move = Vector2.zero;

        if (moveUp) move.y += moveAmount;

        if (moveDown) move.y -= moveAmount;

        if (moveLeft) move.x -= moveAmount;

        if (moveRight) move.x += moveAmount;

        float moveMag = Mathf.Sqrt(move.x * move.x + move.y * move.y);

        if(moveMag > moveAmount)
        {
            float ratio = moveAmount / moveMag;
            move *= ratio;
        }

        pos += move;

        if (pos.x <= -8.2f) pos.x = -8.2f;

        if (pos.x >= 8.2f) pos.x = 8.2f;

        if (pos.y <= -4.4f) pos.y = -4.4f;

        if (pos.y >= 4.4f) pos.y = 4.4f;

        transform.position = pos;
    }

    public void SetLife(int i)
    {
        life += i;

        if (i < 0)
        {
            if(courutine != null)
            {
                StopCoroutine(courutine);
                courutine = null;
            }

            courutine = RecieveDmg();

            StartCoroutine(courutine);
        }
    }

    public void SetNewMaxLife(int e)
    {
        life += e;
        maxLife += e;
    }

    private IEnumerator RecieveDmg()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.4f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
