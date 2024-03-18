using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirebaseController : MonoBehaviour
{
    public GameObject loginPanel,signupPanel;

    //public InputField loginEmail, loginPassword, signupEmail, signupPassword, signupConfirm;

    public void OpenLoginPanel() {

        loginPanel.SetActive(true);
        signupPanel.SetActive(false);
    }

    public void OpenSignupPanel() {

        loginPanel.SetActive(false);
        signupPanel.SetActive(true);
    }

    public void LastScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
