using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private enum State
    {
        Pace,
        Follow,
    }

    [SerializeField]
    GameObject[] route;
    GameObject target;
    int routeIndex = 0;

    float speed = 1.0f;

    private State currentState = State.Pace;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //creates switch case (more efficient than an if statement)
        switch (currentState)
        {
            case State.Pace:
                OnPace();
                break;
            case State.Follow:
                OnFollow();
                break;
        }
    }

    void OnPace()
    {
        //what do we do when pacing
        print("I'm Pacin' it");
        target = route[routeIndex];

        MoveTo(target);

        if (Vector3.Distance(transform.position, target.transform.position) < 0.1)
        {
            routeIndex += 1;

            if (routeIndex >= route.Length)
            {
                routeIndex = 0;
            }
        }

        //on what condition do we switch states?

        GameObject obstacle = CheckForward();
        
        if (obstacle != null)
        {
            target = obstacle;
            currentState = State.Follow;
        }
    }

    void OnFollow()
    {
        //what do we do when following
        print("I'm Followin' it");
        MoveTo(target);

        GameObject obstacle = CheckForward();

        if (obstacle != null)
        {
            currentState = State.Pace;
        }
    }

    void MoveTo(GameObject t)
    {
        transform.position = Vector3.MoveTowards(transform.position, t.transform.position, speed * Time.deltaTime);
        transform.LookAt(t.transform, Vector3.up);
    }

    GameObject CheckForward()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 10, Color.green);
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
        {
            PlayerMovement player = hit.transform.gameObject.GetComponent<PlayerMovement>();
           
            if (player != null)
            {
                print(hit.transform.gameObject.name);
                return hit.transform.gameObject;
            }
        }
        return null;
    }
}
