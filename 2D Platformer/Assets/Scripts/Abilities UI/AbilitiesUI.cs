using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AbilitiesUI : MonoBehaviour
{
    private bool UIOpen = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!UIOpen)
                SceneManager.LoadScene("AbilitiesUI", LoadSceneMode.Additive);
            else
            {
                SceneManager.UnloadSceneAsync("AbilitiesUI");
            }
            UIOpen = !UIOpen;
        }
    }
}