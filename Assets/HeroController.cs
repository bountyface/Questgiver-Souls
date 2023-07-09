using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    Animator animator;
    public Transform startPoint;
    public Transform endPoint;
    public Transform destination;
    public float movementSpeed = 2f;

    public GameObject DialogueBox;

    private float t = 0f;

    public bool allowMoving = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", true);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // MoveToEndPoint();
        if (allowMoving)
        {


            transform.position = Vector3.Lerp(transform.position, destination.position, Time.deltaTime * movementSpeed);
            var dist = Vector3.Distance(transform.position, destination.position);
            print(dist);
            if (dist <= 1)
            {
                allowMoving = false;
                animator.SetBool("isWalking", allowMoving);
                DialogueBox.SetActive(true);
                // Changes position
                if (destination == startPoint)
                {
                    destination = endPoint;
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    destination = startPoint;
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }

            }
        }
    }

    void MoveToStartPoint()
    {
        animator.SetBool("isWalking", true);
        // Move the NPC from start to end point
        t += Time.deltaTime * movementSpeed;
        transform.position = Vector3.Lerp(transform.position, startPoint.position, t);
    }
    void MoveToEndPoint()
    {
        animator.SetBool("isWalking", true);
        // Move the NPC from start to end point
        t += Time.deltaTime * movementSpeed;
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, t);

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        if (collision.gameObject.CompareTag("Conversation Spot"))
        {
            print("Conversation Spot");
            // MoveToStartPoint();
            // Handle collision with the boundary here
            // For example, you can reset the player's position or apply some other behavior
        }
    }
}
