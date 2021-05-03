using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public List<Transform> wayPoints;
   public GameManager gm;
    public bool canAdd;
    private Coroutine MoveIE;
    // Start is called before the first frame update
    void Start()
    {
        canAdd = false; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        //StartCoroutine(moveObject());

        //transform.position = Vector3.MoveTowards(transform.position, wayPoints[1000].position, 30f * Time.deltaTime);

        transform.position = wayPoints[1400].position;





    }

    public void AddPoints(List<Transform> wayPoints)
    {
        if (canAdd)
        {
            this.wayPoints = wayPoints;
            canAdd = false;
        }
    }

    IEnumerator moveObject()
    {
        for (int i = 0; i < wayPoints.Count; i++)
        {
            MoveIE = StartCoroutine(Moving(i));
            yield return MoveIE;
        }
    }

    IEnumerator Moving(int currentPosition)
    {
        while (transform.position != wayPoints[currentPosition].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentPosition].position, 30f * Time.deltaTime);
            yield return null;
        }

    }
}
