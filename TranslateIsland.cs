using UnityEngine;
using System.Collections;

public class TranslateIsland : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		target.SendMessage ("FollowSpline");
		Debug.Log ("click");
	}
}
