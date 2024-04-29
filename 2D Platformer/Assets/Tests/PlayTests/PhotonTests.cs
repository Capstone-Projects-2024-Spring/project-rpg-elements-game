using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Photon.Pun;

public class PhotonTests
{
    [UnityTest]
    public IEnumerator ConnectToMaster_Success()
    {
        // Load the MainMenu scene
        SceneManager.LoadScene("MainMenu");

        // Wait for the scene to load
        yield return new WaitForSeconds(1f); // Adjust this delay as needed

        // Wait for the connection to succeed or fail
        yield return new WaitUntil(() => PhotonNetwork.IsConnected || PhotonNetwork.NetworkingClient.State == Photon.Realtime.ClientState.Disconnected);

        // Assert
        bool connectedToMaster = PhotonNetwork.IsConnected && PhotonNetwork.InLobby;
        Assert.IsTrue(connectedToMaster, "Failed to connect to Photon Master Server.");
    }
}
