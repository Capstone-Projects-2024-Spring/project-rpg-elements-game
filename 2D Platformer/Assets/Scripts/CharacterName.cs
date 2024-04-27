using Mirror;
using TMPro;
using UnityEngine;

public class CharacterName : NetworkBehaviour
{
    private string playerName = "";

    [SerializeField] private TMP_Text playerNameText = default;

    public void SetPlayerName(string newName)
    {
        playerName = newName;
        playerNameText.text = playerName;
    }
}
