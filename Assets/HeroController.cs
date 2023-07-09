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

    public GameObject DialogueGameObject;
    public Dialogue Dialogue;

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
        if (allowMoving || Dialogue.dialogueHasEnded)
        {
            if (Dialogue.dialogueHasEnded)
            {
                MoveToStartPoint();
            }
            else
            {
                MoveToConversationSpot();
            }

        }
    }

    void MoveToStartPoint()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
        transform.position = Vector3.Lerp(transform.position, destination.position, Time.deltaTime * movementSpeed);
        // wild rotation
        var dist = Vector3.Distance(transform.position, destination.position);
        if (dist <= 1)
        {
            allowMoving = false;
            animator.SetBool("isRolling", true);
            destination = startPoint;
        }
    }
    void MoveToConversationSpot()
    {
        transform.position = Vector3.Lerp(transform.position, destination.position, Time.deltaTime * movementSpeed);
        transform.eulerAngles = new Vector3(0, 0, 0);
        var dist = Vector3.Distance(transform.position, destination.position);
        if (dist <= 1)
        {
            allowMoving = false;
            animator.SetBool("isWalking", false);
            DialogueGameObject.SetActive(true);
            destination = endPoint;


        }

    }
}
