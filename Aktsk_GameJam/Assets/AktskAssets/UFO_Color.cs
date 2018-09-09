using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO_Color : MonoBehaviour
{
	
	public GameObject ufo_light;
	public GameObject ufo_minilight;
	Material lightMat;
	Material minilightMat;
	Color light = new Color (0.351384f, 0.45012f, 2.904f);

	// Use this for initialization
	void Start ()
	{
		lightMat = ufo_light.GetComponent<Renderer> ().material;
		minilightMat = ufo_minilight.GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update ()
	{
//		light *= ;
		lightMat.SetColor ("_Color", new Color (0.1f, 0.1f, 0.8f));
		lightMat.SetColor ("_EmissionColor", light * (Mathf.Sin (Time.time) + 1) / 2f);
		minilightMat.SetColor ("_Color", light);
	}
}
