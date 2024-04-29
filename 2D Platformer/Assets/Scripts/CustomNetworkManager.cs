using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class CustomNetworkManager : NetworkManager
{
    public override void OnStopClient()
    {
        base.OnStopClient();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}