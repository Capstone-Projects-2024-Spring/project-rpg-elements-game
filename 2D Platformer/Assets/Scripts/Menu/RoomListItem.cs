using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] Text roomNameText;
    RoomInfo info;

    public void SetUp(RoomInfo _info)
    {
        info = _info;
        roomNameText.text = _info.Name;
    }

    public void onClick()
    {
        Launcher.instance.JoinRoom(info);
    }


}
