using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    public Camera cam;
    public NavMeshAgent agent;
    public Animator animator;

    private int isWalkingHash;

    void Awake ()
    {
        isWalkingHash = Animator.StringToHash("isWalking");
    }

    // Update is called once per frame
    void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
                print(hit.point);
            }
        }

        HandleAnimaton();
    }

    void HandleAnimaton() {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool hasVelocity = Vector3.Distance(agent.velocity.normalized, Vector3.zero) > 0;

        if (hasVelocity && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        } else if (!hasVelocity && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }
    }
}