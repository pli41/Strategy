using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UISystem : MonoBehaviour {

	public Transform canvas;
	public Camera mainCam;
	public GameSystem gameSys;
	public GameObject textUI;

	private GameObject createdUI;
	private ArrayList minionUIs;

	// Use this for initialization
	void Start () {
		minionUIs = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update () {

	}


	void OnGUI(){

		if(gameSys.selectedMinion){
			if(!checkExisted(gameSys.selectedMinion, minionUIs)){
				Vector2 uiPos = mainCam.WorldToScreenPoint(gameSys.selectedMinion.transform.position);
				createdUI = (GameObject)Instantiate(textUI);
				setupNewUI(createdUI, uiPos);
				MinionUI newminion = new MinionUI(createdUI, gameSys.selectedMinion, mainCam);
				minionUIs.Add(newminion);
				Debug.Log("UICreated");
			}
		}


		foreach (MinionUI UI in minionUIs) {
			if(UI.minion.GetComponent<moveOnMouseClick>().selected){
				UI.UI.SetActive(true);
				UI.updateInfo();
			}
			else{
				UI.UI.SetActive(false);
			}
		}

	}

	bool checkExisted(GameObject minion, ArrayList minionUIList){
		foreach (MinionUI UI in minionUIList) {
			if(UI.minion.Equals(minion)){
				return true;
			}
		}
		return false;
	}

	void setupNewUI(GameObject gameObj, Vector2 screenPos){
		gameObj.GetComponent<RectTransform> ().position = new Vector3 (screenPos.x, screenPos.y, 0f);
		gameObj.GetComponent<Text> ().text = gameSys.selectedMinion.GetComponent<MinionSystem>().type.ToString();
		gameObj.transform.SetParent (canvas);
	}

}
