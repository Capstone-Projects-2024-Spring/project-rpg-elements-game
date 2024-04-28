using System.Collections;
using System.Collections.Generic;
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

    // private string userID;
    // private DatabaseReference dbReference;

    // void Start()
    // {
    //     userID = SystemInfo.deviceUniqueIdentifier;
    //     dbReference = FirebaseDatabase.DefaultInstance.RootReference;
    // }

    // public void CreateUser()
    // {
    //     User newUser = new User(signupPassword.text, signupEmail.text);
    //     string json = JsonUtility.ToJson(newUser);

    //     dbReference.Child("users").Child(userID).SetRawJsonValueAsync(json);
    // }

    // public IEnumerator GetName(Action<string> onCallBack)
    // {
    //     var userNameData = dbReference.Child("Users").;
    // }

    public void Login()
    {
        // if (string.IsNullOrEmpty(loginEmail.text) || string.IsNullOrEmpty(loginPassword.text))
        // {
        //     ShowNotif("One or more fields are empty");
        //     return;
        // }

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

    public void Anonymous()
    {

    }

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
                //ShowNotif("Account created! Please login to play!");
                //return;
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

        switch(errorCode)
        {
            case AuthError.AccountExistsWithDifferentCredentials:
                break;
            
            case AuthError.MissingPassword:
                break;
            
            case AuthError.WrongPassword:
                break;

            case AuthError.InvalidEmail:
                break;

            case AuthError.EmailAlreadyInUse:
                break;
        }
        print(msg);
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



    // public void OpenLoginPanel()
    // {

    //     loginPanel.SetActive(true);
    //     signupPanel.SetActive(false);
    //     profilePanel.SetActive(false);
    //     forgotPassPanel.SetActive(false);
    //     notifPanel.SetActive(false);
    // }

    // public void OpenSignupPanel()
    // {

    //     loginPanel.SetActive(false);
    //     signupPanel.SetActive(true);
    //     profilePanel.SetActive(false);
    //     forgotPassPanel.SetActive(false);
    //     notifPanel.SetActive(false);
    // }

    // public void OpenProfilePanel()
    // {

    //     loginPanel.SetActive(false);
    //     signupPanel.SetActive(false);
    //     profilePanel.SetActive(true);
    //     forgotPassPanel.SetActive(false);
    //     notifPanel.SetActive(false);
    // }

    // public void OpenForgotPassPanel()
    // {

    //     loginPanel.SetActive(false);
    //     signupPanel.SetActive(false);
    //     profilePanel.SetActive(false);
    //     forgotPassPanel.SetActive(true);
    //     notifPanel.SetActive(false);
    //     notifPanel.SetActive(false);
    // }

    // public void LastScene()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    // }

    // public void NextScene()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    // }
}