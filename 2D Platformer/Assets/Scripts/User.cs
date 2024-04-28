using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class User
{
    public string password;
    public string email;

    public User(string password, string email)
    {
        this.password = password;
        this.email = email;
    }
}

