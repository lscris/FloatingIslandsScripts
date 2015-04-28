using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// life
	public int maxLife = 100;
	public int damage = 10;
	private int life;

	// Use this for initialization
	void Start () {
		// life
		life = maxLife;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(Collision collision) {
		//Debug.Log ("enter: " +collision.gameObject.tag);
		if (collision.gameObject.tag.Equals ("Ammo")) {
			if (life > 0)
				life -= damage;

			Debug.Log (life);
		}
	}

	void OnCollisionStay(Collision collision) {
	}

	void OnCollisionExit(Collision collision) {

	}

	public void DieResetPosition() {
		life = maxLife;
		transform.position = new Vector3 (0, 295, 0);
	}
}
