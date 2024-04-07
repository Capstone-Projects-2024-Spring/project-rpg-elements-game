using UnityEngine;
using System.Collections;

public class AbilitiesUI : MonoBehaviour
{

    // this is the window for the exit yes button

    public bool AbilityWindowVisible = false;

    // This is the Exit Yes button

    public bool ButtonYes = false;

    Rect AbilityWindow;
    private GUIStyle currentStyle = null;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        // This will show the mouse cursor when you hit Escape key and open the ExitGameWindow.

        if (Input.GetKeyDown(KeyCode.Q))
        {
            AbilityWindowVisible = !AbilityWindowVisible;
            ButtonYes = !ButtonYes;
        }
    }


    private void InitStyles()
    {
        if (currentStyle == null)
        {
            currentStyle = new GUIStyle(GUI.skin.box);
            currentStyle.normal.background = MakeTex(2, 2, new Color(0,.3f,0,0.2f)); 
            currentStyle.normal.textColor = Color.black;
        }
    }

    
    // Void OnGUI() is the function for your Graphic user Interface (GUI)
    void OnGUI()
    {

        InitStyles();
        if (AbilityWindowVisible)
        {

            AbilityWindow = new Rect(0, 0, Screen.width, Screen.height);
            GUI.Box(AbilityWindow, "Select your abilities", currentStyle);
        }


        // Make a button that can be clicked on.
        // Debug.Log() creates text in your console.
        // Application.LoadLevel(); Takes you to what ever scene that you tell it to. scene number goes in () after LoadLevel.
        // if(ButtonYes) This will make it to where the yes button will not show when game is played.

        if (ButtonYes)
        {
            if (GUI.Button(new Rect(Screen.width / 8, Screen.height / 3, 200, 200), "1", currentStyle))
            {
                ; 
            }
            if (GUI.Button(new Rect(Screen.width / 8 + 200, Screen.height / 3, 200, 200), "2", currentStyle))
            {
                ;
            }
            if (GUI.Button(new Rect(Screen.width / 8 + 400, Screen.height / 3, 200, 200), "3", currentStyle))
            {
                ;
            }

        }



    }
    private Texture2D MakeTex( int width, int height, Color col )
{
    Color[] pix = new Color[width * height];
    for( int i = 0; i < pix.Length; ++i )
    {
        pix[ i ] = col;
    }
    Texture2D result = new Texture2D( width, height );
    result.SetPixels( pix );
    result.Apply();
    return result;
}
}
