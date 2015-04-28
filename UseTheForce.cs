using UnityEngine;
using System.Collections;

public class UseTheForce : MonoBehaviour {

	// FORCE == mana
	public int FORCE = 100;
	public int hitCost = 10;
	public int gainPerSecond = 5;

	float radius = 5;
	float power = 1000;
	//float coneAngle = 90;

	void Start() {
		InvokeRepeating("ReloadFORCE", 0f, 1.0f);
	}

	// Use this for initialization
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			if(FORCE > 0) {
				FireGun();
				FORCE -= hitCost;
			}
		}

		Debug.Log ("FORCE: " + FORCE);
	}

	void ReloadFORCE() {
		if (FORCE < 100) {
			FORCE += gainPerSecond;
		}
	}
	
	void FireGun () {
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);

		//Debug.Log (colliders.Length);

		foreach (Collider hit in colliders) {
			//Debug.Log(hit.tag);
			if (hit.GetComponent<Rigidbody>() != null && hit.tag.Equals("Mob") ) {
				hit.GetComponent<Rigidbody>().AddForce(transform.forward * power);

				hit.SendMessage("DestroyObj");
			}
		}
	}
}
