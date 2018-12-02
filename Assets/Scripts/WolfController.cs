using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class WolfController : MonoBehaviour
{

    public enum WolfState
    {
        idle,
        following,
        fighting,

    }

    private NavMeshAgent agent;
    private Transform[] waypoints;
    private SpriteRenderer spriteRenderer;
    private int currentWaypointIndex;
    private WolfState state = WolfState.idle;
    private SheepState followingSheep;
	private Animator animator;


    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        waypoints = FindObjectsOfType<WolfWaypoint>().Select(w => w.transform).ToArray();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        SetNextWaypoint();
    }

    void Update()
    {
        if (agent.remainingDistance <= Mathf.Abs(0.2f))
        {
            if (state == WolfState.idle)
            {
                SetNextWaypoint();
            }
            else if (state == WolfState.following)
            {
                StartFigth();
            }
        }

        if (followingSheep!=null && followingSheep.isDead)
        {
            StartIdle();
        }

        spriteRenderer.flipX = agent.velocity.x < 0;
    }

	void LateUpdate(){
		spriteRenderer.transform.rotation = Quaternion.Euler(45,0,0);
	}

    void SetNextWaypoint()
    {
        int c = currentWaypointIndex;
        while (currentWaypointIndex == c)
        {
            currentWaypointIndex = Random.Range(0, waypoints.Length);
        }
        agent.destination = waypoints[currentWaypointIndex].position;

		animator.SetBool("run",true);
    }

    public void FollowSheep(SheepState sheep)
    {
        state = WolfState.following;
        followingSheep = sheep;
        agent.destination = sheep.transform.position;
        agent.speed *= 10;
		animator.SetFloat("velMult",5);
    }

    public void StartFigth()
    {
        state = WolfState.fighting;
        animator.SetBool("invisible",true);
    }

    public void StartIdle()
    {
        state = WolfState.idle;
		agent.speed /= 10;
		followingSheep = null;
		animator.SetBool("invisible",false);
		animator.SetFloat("velMult",1);
    }
}
