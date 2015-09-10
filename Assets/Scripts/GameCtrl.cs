using UnityEngine;
using System.Collections;

public class GameCtrl : MonoBehaviour {

	public GameObject[] minions;

	// Use this for initialization
	void Start () {
		minions = GameObject.FindGameObjectsWithTag ("Minion");
	}
	
	// Update is called once per frame
	void Update () {

	}




}
