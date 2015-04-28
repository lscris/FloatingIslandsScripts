using UnityEngine;
using System.Collections;

public class UnderwaterView : MonoBehaviour {

	// underwater
	private bool isUnderwater;
	private bool wasUnderwater;
	private Color normalFogColor;
	private Color underwaterFogColor;
	private float normalFogDensity;
	private float underwaterFogDensity;
	private float normalFogEndDistance;
	private float underwaterFogEndDistance;

	// Use this for initialization
	void Start () {
		// underwater
		isUnderwater = false;
		wasUnderwater = false;
		normalFogColor = RenderSettings.fogColor;
		normalFogDensity = RenderSettings.fogDensity;
		
		underwaterFogColor = new Color (0.22f, 0.65f, 0.77f, 0.5f);
		underwaterFogDensity = 0.3f;
		
		normalFogEndDistance = RenderSettings.fogEndDistance;
		underwaterFogEndDistance = 25;	
	}
	
	// Update is called once per frame
	void Update () {
		if (isUnderwater)
			SetUnderwater ();
		else if (!isUnderwater && wasUnderwater) {
			SetOutOfWater();
			wasUnderwater = false;
		}
		
		// i'm saving the player state. This way SetOutOfWater() will be called only when needed
		wasUnderwater = isUnderwater;
	}

	void SetUnderwater() {
		RenderSettings.fogColor = underwaterFogColor;
		RenderSettings.fogDensity = underwaterFogDensity;
		RenderSettings.fogEndDistance = underwaterFogEndDistance;
	}
	
	void SetOutOfWater() {
		RenderSettings.fogColor = normalFogColor;
		RenderSettings.fogDensity = normalFogDensity;
		RenderSettings.fogEndDistance = normalFogEndDistance;
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag.Equals("Water")) {
			isUnderwater = true;
		}
	}
	
	void OnTriggerStay(Collider other) {
		if(other.gameObject.tag.Equals("Water")) {
			isUnderwater = true;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag.Equals("Water") ) {
			isUnderwater = false;
		}
	}
}
