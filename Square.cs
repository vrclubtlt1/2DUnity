using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{

	public Vector2 targetPosition;
	public float moveStep;
    public float speedFactor;
    public float scaleFactor;
    public int catchCount;
    Vector2 GetRandomPoint()
    {
        Vector2 randomVector = new Vector2();
        randomVector.x = Random.Range(-6, 6);
        randomVector.y = Random.Range(-3, 3);
        return randomVector;
    }
    void Start()
    {
        if (isTrap == false)
        {
            Player.squares.Add(this);
        }
        targetPosition = GetRandomPoint();
    }
    void Catch()
    {
        Player.score++;
        moveStep += speedFactor;
        transform.localScale = (Vector2)transform.localScale - new Vector2(scaleFactor, scaleFactor);
        transform.position = GetRandomPoint();
        catchCount--;

        if (catchCount == 0)
        {
            Player.squares.Remove(this);
            Destroy(gameObject);
        }
        else
        {
            moveStep += speedFactor;
            transform.localScale = (Vector2)transform.localScale - new Vector2(scaleFactor, scaleFactor);
            transform.position = GetRandomPoint();
        }
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveStep * Time.deltaTime);

        if ((Vector2)transform.position == targetPosition)
        {
            targetPosition = GetRandomPoint();
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveStep * Time.deltaTime);
    }
    public GameObject playerObj;
    public bool isTrap;
    void OnMouseDown()
    {
        if (isTrap)
        {
            Player.Defeat1();
        }
        else
        {
            Catch();
        }
    }
}
