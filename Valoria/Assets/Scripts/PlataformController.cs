using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformController : MonoBehaviour
{
    public Rigidbody plataformRB;
    public Transform[] PlataformPositions;
    public float plataformSpeed;

    private int actualPosition = 0;
    private int nextPosition = 1;

    public bool moveToTheNext = true;
    public float waitTime;

    void Update()
    {
        MovePlataform();

    }

    void MovePlataform()
    {
        if (moveToTheNext)
        {
            StopCoroutine(waitForMove(0));
            plataformRB.MovePosition(Vector3.MoveTowards(plataformRB.position, PlataformPositions[nextPosition].position, plataformSpeed * Time.deltaTime));
        }

        if (Vector3.Distance(plataformRB.position, PlataformPositions[nextPosition].position) <= 0)
        {
            StartCoroutine(waitForMove(waitTime));
            actualPosition = nextPosition;
            nextPosition++;

            if(nextPosition > PlataformPositions.Length - 1)
            {
                nextPosition = 0;
            }
        }
    }

    IEnumerator waitForMove(float time)
    {
        moveToTheNext = false;
        yield return new WaitForSeconds(time);
        moveToTheNext = true;   
    }
}
