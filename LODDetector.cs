using UnityEngine;
using System.Collections;

public class LODDetector : MonoBehaviour {

	private LODManager lodManager;

	// Use this for initialization
	void Start () {
		lodManager = GameObject.FindWithTag("GameConfigs").GetComponent<LODManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}	
	
	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals ("MainIsland")) {
			lodManager.setMainIslandIsHightRes (true);
			//Debug.Log (this.tag);
		}

		if (other.tag.Equals ("2ndIsland")) {
			lodManager.set2ndIslandIsHightRes (true);
			//Debug.Log (this.tag);
		}

		//Debug.Log (other.tag);
	}
	
	void OnTriggerStay(Collider other) {
		if (other.tag.Equals ("MainIsland")) {
			lodManager.setMainIslandIsHightRes (true);
			//Debug.Log (this.tag);
		}
		
		if (other.tag.Equals ("2ndIsland")) {
			lodManager.set2ndIslandIsHightRes (true);
			//Debug.Log (this.tag);
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.tag.Equals ("MainIsland")) {
			lodManager.setMainIslandIsHightRes (false);
			//Debug.Log ("exit from: " +other.tag);
		}

		if (other.tag.Equals ("2ndIsland")) {
			lodManager.set2ndIslandIsHightRes (false);
			//Debug.Log ("exit from: " +other.tag);
		}
	}
}
