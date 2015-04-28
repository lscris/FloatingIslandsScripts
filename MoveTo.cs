using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour {

	// this class refers to a single instance of a mob

	public Transform goal;
	private NavMeshAgent agent;
	
	public bool follow;			// mob MUST follow the player
	private bool following;		// mob is currently following the player
	
	void Start () {
		follow = false;
		following = false;
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update () {

		// if the mob have to follow, but is not following -> start following
		if (follow && !following) {
			agent.destination = goal.position;
			following = true;

			// if the agent was stopped
			agent.Resume();
		}

		// if the goal changes its position we have to update the agent's destination
		else if (following)
			agent.destination = goal.position;
	}

	public void SetFollow(bool value) {
		follow = value;

		if (value == false) {
			following = false;

			agent.Stop();
		}
	}
}