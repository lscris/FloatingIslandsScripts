using UnityEngine;
using System.Collections;

public class TurretAI : MonoBehaviour {

	private Transform target;
	public Transform guns;
	public float range = 5;
	public bool aiming = true;

	public Transform ammoPrefab;
	public float delay;
	public float destroyBulletDelay = 2.0F;

	private Collider[] targets;

	private float nextTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// reset the target
		target = transform;

		FindTargets ();
		DetermineTarget ();
		SHOOT ();

		if(aiming)
			LookAtTarget ();
	}

	void LookAtTarget() {
		transform.LookAt (target.transform.position);

		// prevents rotation on x and z axes
		//transform.eulerAngles.x = 0;
		//transform.eulerAngles.z = 0;

		guns.transform.LookAt (target.transform.position);
	}

	void FindTargets() {
		targets = Physics.OverlapSphere (transform.position, range);
	}

	void DetermineTarget() {

		for (int i=0; i<targets.Length; i++) {
			if(targets[i].tag.Equals("Target") || targets[i].tag.Equals("Player")) {
				if(target == transform)
					target = targets[i].transform;
				else {
					if( Vector3.Distance(targets[i].transform.position, transform.position) <= Vector3.Distance(target.transform.position, transform.position) )
						target = targets[i].transform;
				}
			}
		}
	}

	void SHOOT() {
		if (Time.time > nextTime && target != transform) {
			Transform ammo = (Transform)Instantiate (ammoPrefab, transform.Find ("shooter").transform.position, Quaternion.identity);
			ammo.GetComponent<Rigidbody> ().AddForce (transform.forward * 1000);
			nextTime = Time.time + delay;

			Destroy(ammo.gameObject, destroyBulletDelay);
		}
	}
}
