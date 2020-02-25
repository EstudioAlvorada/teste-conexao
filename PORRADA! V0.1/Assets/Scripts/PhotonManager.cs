using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private CinemachineVirtualCamera cameraJogador = null;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 4 }, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        var player = PhotonNetwork.Instantiate("Jogador", new Vector2(Random.Range(-8f, 8f) , transform.position.y), Quaternion.identity);
        cameraJogador.Follow = player.transform;
        //cameraJogador.LookAt = player.transform;
    }
}
