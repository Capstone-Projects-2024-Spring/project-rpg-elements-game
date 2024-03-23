using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public string menuName;
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
        gameObject.SetActive(true);
    }    
    //set menu as inactive so we can display other elements
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
