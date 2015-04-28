using UnityEngine;
using System.Collections;

public class MobGenerator : MonoBehaviour {

	public GameObject unit;	
	public float spawnTime = .1f;
	public int maxSpawn;

	public int maxMobsOnScene = 20;

	private float spawnTimeLeft = .1f;

	private GameObject[] mobsOnScene;


	void Start() {

	}
	
	// Update is called once per frame
	void Update () {

		mobsOnScene = GameObject.FindGameObjectsWithTag("Mob");

		if(spawnTimeLeft <= 0 && mobsOnScene.Length < maxMobsOnScene) {
			GameObject go = (GameObject)Instantiate(unit, transform.position, transform.rotation);
			spawnTimeLeft = spawnTime;
		}
		else {
			spawnTimeLeft -= Time.deltaTime;
		}
	}
}