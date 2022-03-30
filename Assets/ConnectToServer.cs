using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        print("ConnectUsingSettings");
    }

    public override void OnConnectedToMaster()
    {
        print("OnConnectedToServer");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        print("OnJoinedLobby");
        SceneManager.LoadScene("Lobby");
    }
}
