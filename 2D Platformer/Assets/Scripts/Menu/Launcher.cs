using Codice.Client.BaseCommands;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

//MBPC: Class provides .photon view and callbacks/events that pun can call
public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField roomNameInputField;
    [SerializeField] Text roomNameText;
    [SerializeField] Text errorText;
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
    
    public void CreateRoom()
    {
        //if the roomname is null we return
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }

        //otherwise we create the room
        PhotonNetwork.CreateRoom(roomNameInputField.text);
        //show load menu
        MenuManager.instance.OpenMenu("LoadingMenu");
    }

    public override void OnJoinedRoom()
    {
        //open RoomMenu menu
        MenuManager.instance.OpenMenu("RoomMenu");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnCreateRoomFailed(short returnCode, string errorMessage)
    {
        errorText.text = "Room Generation Unsuccessful" + errorMessage;
        MenuManager.instance.OpenMenu("ErrorMenu");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.instance.OpenMenu("LoadingMenu");
    }

    public override void OnLeftRoom()
    {
        MenuManager.instance.OpenMenu("MainMenu");
    }
}
