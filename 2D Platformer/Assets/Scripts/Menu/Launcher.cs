using ExitGames.Client.Photon;
using ExitGames.Client.Photon.StructWrapping;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

//MBPC: Class provides .photon view and callbacks/events that pun can call
public class Launcher : MonoBehaviourPunCallbacks
{

    public static Launcher instance;

    [SerializeField] InputField roomNameInputField;
    [SerializeField] Text roomNameText;
    [SerializeField] Text errorText;
    [SerializeField] Transform roomListContent;
    [SerializeField] GameObject roomListItemPrefab;    
    
    [SerializeField] Transform playerListContent;
    [SerializeField] GameObject playerListItemPrefab;
    public GameObject startButton;

    public void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Debug.Log("Connecting to Master");
        //connect using pun resource file settings
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;

    }

    public override void OnJoinedLobby()
    {
        
        Debug.Log("Joined Lobby");
        PhotonNetwork.NickName = "Player " + Random.Range(0, 10000).ToString("0000");
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

        //generate a random ID
        string playerId = GeneratePlayerId();


        // Set the player ID as a custom property for the local player
        Hashtable playerCustomProperties = new Hashtable
        {
            { "PlayerId", playerId },
            { "Port", 7777 }
        };
        PhotonNetwork.LocalPlayer.SetCustomProperties(playerCustomProperties);

        Player[] players = PhotonNetwork.PlayerList;

        //delete previous playerlist objects for this user
        foreach(Transform child in playerListContent)
        {
            Destroy(child.gameObject);
        }

        //Display each players username
        for(int i = 0; i < players.Count(); i++)
        {
            Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
        }

        //if it is the master client button start button will show
        startButton.SetActive(PhotonNetwork.IsMasterClient);
    }
    private string GeneratePlayerId()
    {
        // Generate a unique player ID based on your requirements
        // For example, you can combine username and timestamp
        string username = PhotonNetwork.NickName;
        string timestamp = System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
        return username + "_" + timestamp;
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        startButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnCreateRoomFailed(short returnCode, string errorMessage)
    {
        errorText.text = "Room Generation Unsuccessful" + errorMessage;
        MenuManager.instance.OpenMenu("ErrorMenu");
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.instance.OpenMenu("LoadingMenu");
    }

    public void StartGame()
    {
        int setPort = Random.Range(7777, 7796);

        // Iterate through the list of players
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            // Access player properties
            //object playerId, port;

            Hashtable playerCustomProperties = new Hashtable
            {
                { "Port", setPort }
            };
            player.SetCustomProperties(playerCustomProperties);

            //Debug.Log("Lobby Port: " + player.CustomProperties.TryGetValue("Port");   //TEST LINE


            //if (player.CustomProperties.TryGetValue("Port", out port))
            //{
            //    Debug.Log("Port: " + port);
            //}
            //else
            //{
            //    Debug.LogWarning("Player ID not found for player: " + player.NickName);
            //}


        }

        PhotonNetwork.LoadLevel("LevelGenerator");
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

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

        foreach(Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }


        //get all available rooms and instantiate with roomlistprefab
        for(int i = 0; i < roomList.Count; i++)
        {
            //rooms cannot be removed, but if it is disabled, we don't want to instantiate it again so we skip instantiation
            if (roomList[i].RemovedFromList)
                continue;
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);

    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
