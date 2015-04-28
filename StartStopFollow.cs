using UnityEngine;
using System.Collections;

public class StartStopFollow : MonoBehaviour {

	private bool following;
	void Start () {
		following = false;
	}
	
	void Update () {
	
		if (following)
			updateMobsBehavior (following);
	}

	void OnMouseDown() {
		if (!following) {
			updateMobsBehavior (true);

			following = true;
		} else {
			updateMobsBehavior (false);
			
			following = false;
		}
	}

	private void updateMobsBehavior(bool mustFollow) {
		GameObject[] mobs = GameObject.FindGameObjectsWithTag ("Mob");
		
		for (int i=0; i<mobs.Length; i++)
			((MoveTo)mobs [i].GetComponent ("MoveTo")).SetFollow (mustFollow);
	}
}
