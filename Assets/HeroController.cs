using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    Animator animator;
    public Transform startPoint;
    public Transform endPoint;
    public float movementSpeed = 2f;

    private float t = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveToEndPoint();
    }

    void MoveToStartPoint()
    {

    }
    void MoveToEndPoint()
    {
        animator.SetBool("isWalking", true);
        // Move the NPC from start to end point
        t += Time.deltaTime / movementSpeed;
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, 0.05f);
        print(t);
        // If the NPC has reached the end point, reverse the direction
        if (t >= 1f)
        {
            var temp = startPoint;
            startPoint = endPoint;
            endPoint = temp;
            t = 0f;
        }
    }
}
