using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Mirror;

public class GameModeTests
{
    [UnityTest]
    public IEnumerator StartGame()
    {
        // Load the scene containing the script with the mode variable
        SceneManager.LoadScene("LevelGenerator");

        // Wait for the scene to load
        yield return new WaitForSeconds(1f); // Adjust this delay as needed

        // Check if the current network address is localhost
        bool isLocalhost = NetworkManager.singleton.networkAddress == "localhost";
        Assert.IsTrue(isLocalhost, "Network address is not localhost.");
    }
}
