using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class grab : MonoBehaviour {

	public GameObject right;
	public GameObject left;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		right.SetActive(true);
		left.SetActive(true);
	}
}
