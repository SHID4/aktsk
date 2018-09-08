using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityChan;

public class RandomMatchmaker : MonoBehaviour
{
	public GameObject photonObjectHand;
	public GameObject photonObjectPlayer;
	private GameObject photonObject;

	void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");

		if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
		{
			PhotonNetwork.playerName = "Windows";
			photonObject = photonObjectHand;
			print("Windows");
		}
		else
		{
			PhotonNetwork.playerName = "else";
			photonObject = photonObjectPlayer;
			print(Application.platform);
		}
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
		//mainCamera.GetComponent<ThirdPersonCamera>().enabled = true;
	}

	// <summary>
	// リモートプレイヤーが入室した際にコールされる
	// </summary>
	public void OnPhotonPlayerConnected(PhotonPlayer player)
	{
		Debug.Log(player.name + " is joined.");
		UpdateMemberList();
	}

	// <summary>
	// リモートプレイヤーが退室した際にコールされる
	// </summary>
	public void OnPhotonPlayerDisconnected(PhotonPlayer player)
	{
		Debug.Log(player.name + " is left.");
		UpdateMemberList();
	}

	public void UpdateMemberList()
	{
		//joinedMembersText.text = "";
		foreach (var p in PhotonNetwork.playerList)
		{
			//joinedMembersText.text += p.name + "\n";
			print(p.name);
		}
	}

	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}
}