using Mirror;
using UnityEngine;
using TMPro;

public class Player : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnNameChanged))]
    private string playerName;

    public TMP_Text playerNameText;

    public void SetName(string newName)
    {
        playerName = newName;
    }

    private void OnNameChanged(string oldName, string newName)
    {
        playerNameText.text = newName;
    }

}

