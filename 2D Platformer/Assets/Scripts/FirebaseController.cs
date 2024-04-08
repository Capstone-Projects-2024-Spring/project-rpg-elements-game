using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.VersionControl;

public class FirebaseController : MonoBehaviour
{
    public GameObject loginPanel, signupPanel, profilePanel, forgotPassPanel, notifPanel;

    public InputField loginEmail, loginPassword, signupEmail, signupPassword, signupConfirm, signupIGN, forgetPassEmail;

    public Text notif_Text;

    public Toggle rememberMe;

    public void OpenLoginPanel()
    {

        loginPanel.SetActive(true);
        signupPanel.SetActive(false);
        profilePanel.SetActive(false);
        forgotPassPanel.SetActive(false);
        notifPanel.SetActive(false);
    }

    public void OpenSignupPanel()
    {

        loginPanel.SetActive(false);
        signupPanel.SetActive(true);
        profilePanel.SetActive(false);
        forgotPassPanel.SetActive(false);
        notifPanel.SetActive(false);
    }

    public void OpenProfilePanel()
    {

        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        profilePanel.SetActive(true);
        forgotPassPanel.SetActive(false);
        notifPanel.SetActive(false);
    }

    public void OpenForgotPassPanel()
    {

        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        profilePanel.SetActive(false);
        forgotPassPanel.SetActive(true);
        notifPanel.SetActive(false);
        notifPanel.SetActive(false);
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
            ShowNotif("One or more fields are empty, please enter your account email and password");
            return;
        }

        // login code here
    }

    public void SignUp()
    {
        if (string.IsNullOrEmpty(signupEmail.text) && string.IsNullOrEmpty(signupPassword.text) && string.IsNullOrEmpty(signupConfirm.text) && string.IsNullOrEmpty(signupIGN.text))
        {
            ShowNotif("One or more fields are empty, please enter an email address, new password, and in-game name");
            return;
        }

        // signup code here

    }

    public void ForgotPassword()
    {
        if (string.IsNullOrEmpty(forgetPassEmail.text))
        {
            ShowNotif("No email entered");
            return;
        }
    }

    public void ShowNotif(string message)
    {
        notif_Text.text = "" + message;

        notifPanel.SetActive(true);
    }

    public void CloseNotif()
    {
        notif_Text.text = "";

        notifPanel.SetActive(false);
    }
}
