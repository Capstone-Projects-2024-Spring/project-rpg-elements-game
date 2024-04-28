using Mirror;
using TMPro;
using UnityEngine;

public class CharacterName : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnPlayerNameChanged))]
    private string playerName = "";

    [SerializeField] private TMP_Text playerNameText = default;

    private void OnPlayerNameChanged(string oldName, string newName)
    {
        playerNameText.text = newName;
    }

    [Server]
    public void SetPlayerName(string newName)
    {
        playerName = newName;
    }

    public override void OnStartClient()
    {
        playerNameText.text = playerName;
    }
}
