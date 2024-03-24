using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string menuName;
    public bool isOpen;
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelGenerator");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //set menu to active so it can be used
    public void Open()
    {
        isOpen = true;
        gameObject.SetActive(true);
    }
    //set menu as inactive so we can display other elements
    public void Close()
    {
        isOpen = false;
        gameObject.SetActive(false);
    }
}