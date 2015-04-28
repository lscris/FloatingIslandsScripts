using UnityEngine;
using System.Collections;

public class Hoverpad : MonoBehaviour {
	
	private bool launched = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		if (!launched && other.tag.Equals("Player")) {
			other.SendMessage ("FollowSpline");
			launched = true;
		}

		//Debug.Log ("enter");
	}

	void OnTriggerStay(Collider other) {
		//Debug.Log ("stay");
	}

	void OnTriggerExit(Collider other) {
		launched = false;
		//Debug.Log ("exit");
	}
}
