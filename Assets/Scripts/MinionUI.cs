using UnityEngine;
using System.Collections;

public class MinionUI : MonoBehaviour {

	public GameObject UI;
	public GameObject minion;
	private Camera mainCam;

	public MinionUI(GameObject UI, GameObject minion, Camera mainCam){
		this.UI = UI;
		this.minion = minion;
		this.mainCam = mainCam;
	}

	public void updateInfo(){
		//update UI pos
		Vector3 UIPos = mainCam.WorldToScreenPoint(minion.transform.position);
		UI.GetComponent<RectTransform> ().position = new Vector3 (UIPos.x, UIPos.y, 0);
	}
}
