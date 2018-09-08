using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityChan;

public class RandomMatchmaker : MonoBehaviour {
	public GameObject photonObject;

	void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed()
	{
		PhotonNetwork.CreateRoom(null);
	}

	void OnJoinedRoom()
	{
		PhotonNetwork.Instantiate(
			photonObject.name,
			new Vector3(0f, 1f, 0f),
			Quaternion.identity, 0
		);

		GameObject mainCamera = 
			GameObject.FindWithTag("MainCamera");
		mainCamera.GetComponent<ThirdPersonCamera>().enabled = true;
	}

	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}
}