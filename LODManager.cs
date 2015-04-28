using UnityEngine;
using System.Collections;

public class LODManager : MonoBehaviour {

	//private GameObject[] mainIslandMeshes;
	//private GameObject[] secondIslandMeshes;

	private GameObject mainIslandMesh_LOD0;
	private GameObject mainIslandMesh_LOD2;
	private GameObject secondIslandMesh_LOD0;
	private GameObject secondIslandMesh_LOD2;

	private bool isMainIslandHighRes = true;
	private bool is2ndIslandHighRes = false;

	// Use this for initialization
	void Start () {
		//mainIslandMeshes = GameObject.FindGameObjectsWithTag ("MainIsland");
		//secondIslandMeshes = GameObject.FindGameObjectsWithTag ("2ndIsland");
		mainIslandMesh_LOD0 = GameObject.Find ("three_islands_IS1_LOD0");
		mainIslandMesh_LOD2 = GameObject.Find ("three_islands_IS1_LOD2");

		secondIslandMesh_LOD0 = GameObject.Find ("three_islands_IS2_LOD0");
		secondIslandMesh_LOD2 = GameObject.Find ("three_islands_IS2_LOD2");

		//for (int i=0; i< mainIslandMeshes.Length; i++) {
		//	mainIslandMeshes[i].SetActive(false);
		//}

		//for (int i=0; i< secondIslandMeshes.Length; i++) {
		//	secondIslandMeshes[i].SetActive(false);
		//}

		mainIslandMesh_LOD0.SetActive (false);
		mainIslandMesh_LOD2.SetActive (false);
		secondIslandMesh_LOD0.SetActive (false);
		secondIslandMesh_LOD2.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		// [0] -> low res
		// [1] -> high res

		if (isMainIslandHighRes) {
			mainIslandMesh_LOD0.SetActive(true);
			mainIslandMesh_LOD2.SetActive(false);
			//mainIslandMeshes [0].SetActive (true);
			//mainIslandMeshes [1].SetActive (false);
		} else {
			mainIslandMesh_LOD0.SetActive(false);
			mainIslandMesh_LOD2.SetActive(true);
			//mainIslandMeshes [0].SetActive (false);
			//mainIslandMeshes [1].SetActive (true);
		}

		if (is2ndIslandHighRes) {
			secondIslandMesh_LOD0.SetActive(true);
			secondIslandMesh_LOD2.SetActive(false);
			//secondIslandMeshes [0].SetActive (false);
			//secondIslandMeshes [1].SetActive (true);
		} else {
			secondIslandMesh_LOD0.SetActive(false);
			secondIslandMesh_LOD2.SetActive(true);
			//secondIslandMeshes [0].SetActive (true);
			//secondIslandMeshes [1].SetActive (false);
		}
		
	}

	public void setMainIslandIsHightRes(bool value) {
		isMainIslandHighRes = value;
	}

	public void set2ndIslandIsHightRes(bool value) {
		is2ndIslandHighRes = value;
	}
}
