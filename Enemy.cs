using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private bool hitted;
	private float distToGround;

	// Use this for initialization
	void Start () {
		hitted = false;	
		distToGround = GetComponent<Collider>().bounds.extents.y;
	}

	bool IsGrounded() {
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1F);
	}
	
	// Update is called once per frame
	void Update () {
		if(!hitted)
			this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}

	public void DestroyObj() {
		hitted = true;
		Destroy(this.gameObject, 2.0F);
	}
}
