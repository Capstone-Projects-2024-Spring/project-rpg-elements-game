using Photon.Pun;
using UnityEngine;

public class QuickMatchExample : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        // Initialize Photon
        PhotonNetwork.ConnectUsingSettings();
    }

    public void QuickMatch()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    // Callbacks for Photon networking events
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon server");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No random room available, creating a new one");
        PhotonNetwork.CreateRoom(null); // Create a room with default parameters
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room successfully");
    }
}
