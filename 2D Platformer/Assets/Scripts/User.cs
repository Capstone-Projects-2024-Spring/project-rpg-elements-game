using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class User
{
    public string ign;
    public string email;

    public User(string ign, string email)
    {
        this.ign = ign;
        this.email = email;
    }
}

