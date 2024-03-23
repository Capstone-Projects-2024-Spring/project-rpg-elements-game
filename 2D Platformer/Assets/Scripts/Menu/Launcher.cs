using Photon.Pun;
using UnityEngine;

//MBPC: Class provides .photon view and callbacks/events that pun can call
public class Launcher : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        Debug.Log("Connecting to Master");
        //connect using pun resource file settings
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        OnJoinedLobby();
    }

    public override void OnJoinedLobby()
    {
        MenuManager.instance.OpenMenu("MainMenu");
        Debug.Log("Joined Lobby");
    }
}
