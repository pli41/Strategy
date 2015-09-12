using UnityEngine;
using System.Collections;

public class GameSystem : MonoBehaviour {

	public GameObject selectedMinion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		detectSelected ();
	}


	void detectSelected(){
		if (Input.GetMouseButtonDown (0) && GUIUtility.hotControl == 0) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast( ray, out hit)){
				GameObject hitObject = hit.transform.gameObject;
				if(hitObject.tag == "Minion"){
					if(selectedMinion == null){
						moveOnMouseClick move = hitObject.GetComponent<moveOnMouseClick>();
						move.selected = true;
						selectedMinion = hitObject;
						highlightSelected(selectedMinion);
					}
					else {
						if(!selectedMinion.Equals(hitObject) ){
							Debug.Log("clicked on another minion");
							unHighlightAll();
							selectedMinion.GetComponent<moveOnMouseClick> ().selected = false;
							selectedMinion = hitObject;
							selectedMinion.GetComponent<moveOnMouseClick>().selected = true;
							highlightSelected(selectedMinion);
						}
					}
				}
			}
		}
		else if(Input.GetKeyDown(KeyCode.Space) && GUIUtility.hotControl == 0){
			GameObject[] minions = GameObject.FindGameObjectsWithTag("Minion");
			for(int i=0; i< minions.Length; i++){
				minions[i].GetComponent<moveOnMouseClick>().selected = false;
			}
			selectedMinion = null;
			unHighlightAll();
		}
	}
	
	void highlightSelected(GameObject gameObj){
		MeshRenderer mr = gameObj.GetComponent<MeshRenderer> ();
		Material mat = mr.material;
		mat.color = Color.white;
	}
	
	void unHighlightAll(){
		GameObject[] minions = GameObject.FindGameObjectsWithTag("Minion");
		for(int i=0; i< minions.Length; i++){
			MeshRenderer mr = minions[i].GetComponent<MeshRenderer> ();
			MinionSystem ms = minions[i].GetComponent<MinionSystem> ();
			Material mat = mr.material;
			
			switch(ms.type){
			case MinionSystem.minionType.INFANTRY:
					mat.color = Color.blue;
					break;
				case MinionSystem.minionType.ARCHER:
					mat.color = Color.yellow;
					break;
				case MinionSystem.minionType.CAVALRY:
					mat.color = Color.red;
					break;
				}

		}




		
		
	}



}
