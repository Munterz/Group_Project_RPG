using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private List<Transform> path;

    [SerializeField]
    private float walkSpeed;

    [SerializeField]
    private Transform playerTransform;

    private int pathIndex;

    private bool startMoving;

    private void Start ()
    {

        startMoving = true;
        //animator.SetBool("WalkDown", true);

        //yield return new WaitForSeconds(10);

        //animator.SetBool("WalkDown", false);
        //animator.SetBool("WalkSideways", true);
    }

    private void Update ()
    {
        if (!startMoving) return;


        //transform.position = Vector2.MoveTowards(transform.position, path[pathIndex].transform.position, Time.smoothDeltaTime * walkSpeed);

        //if(Vector2.Distance(transform.position, path[pathIndex].position) < 0.1f)
        //{
        //    pathIndex++;
        //    if(pathIndex >= path.Count)
        //    {
        //        startMoving = false;
        //    }
        //}

        if(Vector2.Distance(transform.position, playerTransform.position) > 5)
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, Time.smoothDeltaTime * walkSpeed);

        // lerp, movetowards
    }
}
