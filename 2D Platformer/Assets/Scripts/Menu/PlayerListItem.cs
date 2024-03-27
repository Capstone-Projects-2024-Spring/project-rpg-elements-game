using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;


public class PlayerListItem : MonoBehaviourPunCallbacks
{
    public Text playerUsername;
    Player player;

    public void SetUp(Player _player) { 
        player = _player;
        playerUsername.text = _player.NickName;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if(player == otherPlayer)
        {
            Destroy(gameObject);
        }
    }
    public override void OnLeftRoom()
    {
        //when a player leaves the room it destroys the PlayerListItem 
        Destroy(gameObject);
    }
}
