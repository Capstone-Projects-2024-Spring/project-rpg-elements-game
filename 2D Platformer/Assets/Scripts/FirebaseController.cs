using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirebaseController : MonoBehaviour
{
    public GameObject loginPanel, signupPanel, profilePanel, forgotPassPanel;

    public InputField loginEmail, loginPassword, signupEmail, signupPassword, signupConfirm, signupIGN;

    public void OpenLoginPanel()
    {

        loginPanel.SetActive(true);
        signupPanel.SetActive(false);
        profilePanel.SetActive(false);
        forgotPassPanel.SetActive(false);
    }

    public void OpenSignupPanel()
    {

        loginPanel.SetActive(false);
        signupPanel.SetActive(true);
        profilePanel.SetActive(false);
        forgotPassPanel.SetActive(true);
    }

    public void OpenProfilePanel()
    {

        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        profilePanel.SetActive(true);
        forgotPassPanel.SetActive(true);
    }

    public void OpenForgotPassPanel()
    {

        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        profilePanel.SetActive(false);
        forgotPassPanel.SetActive(true);
    }

    public void LastScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Login()
    {
        if (string.IsNullOrEmpty(loginEmail.text) && string.IsNullOrEmpty(loginPassword.text))
        {
            return;
        }

        // login code here
    }

    public void Signup()
    {
        if (string.IsNullOrEmpty(signupEmail.text) && string.IsNullOrEmpty(signupPassword.text) && string.IsNullOrEmpty(signupConfirm.text) && string.IsNullOrEmpty(signupIGN.text))
        {
            return;
        }

        // signup code here

    }

    // public void forgotPassword()
    // {
    //     if (string.IsNullOrEmpty(forgetPassEmail.text))
    //     {
    //         return;
    //     }
    // }
}
