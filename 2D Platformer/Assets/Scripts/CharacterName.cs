using Mirror;
using TMPro;
using UnityEngine;

public class CharacterName : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnPlayerNameChanged))]
    private string playerName = "";

    [SerializeField] private TMP_Text playerNameText = default;

    public void SetPlayerName(string newName)
    {
        playerName = newName;
        playerNameText.text = playerName;
    }

    private void OnPlayerNameChanged(string oldName, string newName)
    {
        playerNameText.text = newName;
    }
}
