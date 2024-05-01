using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.VersionControl;
using Firebase.Database;
using System;
using Firebase.Auth;

public class FirebaseController : MonoBehaviour
{

    public GameObject loginPanel, signupPanel, profilePanel, forgotPassPanel, notifPanel;

    public InputField loginEmail, loginPassword, signupEmail, signupPassword, signupConfirm, signupIGN, forgetPassEmail;

    public Text notif_Text, profileEmail_Text, profileIGN_Text, loginEmailInput, loginPasswordInput, signupEmailInput, signupPasswordInput;

    public Toggle rememberMe;

    public void Login()
    {
        if (string.IsNullOrEmpty(loginEmail.text) || string.IsNullOrEmpty(loginPassword.text))
        {
            ShowNotif("One or more fields are empty");
            return;
        }

        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(loginEmailInput.text, loginPasswordInput.text)
        .ContinueWith((task =>
        {

            if (task.IsCanceled)
            {
                Firebase.FirebaseException e = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                GetErrorMessage((AuthError)e.ErrorCode);

                return;
            }

            if (task.IsFaulted)
            {
                Firebase.FirebaseException e = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                GetErrorMessage((AuthError)e.ErrorCode);

                return;
            }

            if (task.IsCompleted)
            {
                print("Log-in Complete!");
            }
        }));
    } // login

    // public void Anonymous()
    // {
            
    // }

    public void SignUp()
    {
        if (string.IsNullOrEmpty(signupEmail.text) || string.IsNullOrEmpty(signupPassword.text) || string.IsNullOrEmpty(signupConfirm.text) || string.IsNullOrEmpty(signupIGN.text))
        {
            ShowNotif("One or more fields are empty");
            return;
        }

        FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(signupEmailInput.text, signupPasswordInput.text)
        .ContinueWith((task => 
        {
            if(task.IsCanceled) 
            {
                Firebase.FirebaseException e = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                GetErrorMessage((AuthError)e.ErrorCode);

                return;
            }

            if(task.IsFaulted)
            {
                Firebase.FirebaseException e = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                GetErrorMessage((AuthError)e.ErrorCode);

                return;
            }

            if(task.IsCompleted)
            {
                print("Registration Complete!");
            }
        }));

    }

    public void LogOut()
    {
        profileEmail_Text.text = "";
        profileIGN_Text.text = "";
        //OpenLoginPanel();
    }

    void GetErrorMessage(AuthError errorCode)
    {

        string msg = "";
        msg = errorCode.ToString();

        print(msg);
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