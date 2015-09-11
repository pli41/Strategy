using UnityEngine;
using System.Collections;

public class GameSystem : MonoBehaviour {

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
					moveOnMouseClick move = hitObject.GetComponent<moveOnMouseClick>();
					move.selected = true;
					highlightSelected(hitObject);
				}
			}
		}
		else if(Input.GetKeyDown(KeyCode.Space) && GUIUtility.hotControl == 0){
			GameObject[] minions = GameObject.FindGameObjectsWithTag("Minion");
			for(int i=0; i< minions.Length; i++){
				minions[i].GetComponent<moveOnMouseClick>().selected = false;
			}
			unHighlightAll(minions);
		}
	}
	
	void highlightSelected(GameObject gameObj){
		MeshRenderer mr = gameObj.GetComponent<MeshRenderer> ();
		Material mat = mr.material;
		mat.color = Color.white;
	}
	
	void unHighlightAll(GameObject[] minions){

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
