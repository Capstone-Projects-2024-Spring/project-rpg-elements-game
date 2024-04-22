using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mirror;

public class AbilitiesUI : NetworkBehaviour
{
    private bool UIOpen = false;
    private bool isInstantiated = false;
    [SerializeField] public GameObject mainUICanvas;
    private GameObject createdCanvas;
    public override void OnStartClient()
    {
        print("@@@@@@@@@@@@@@@@@@@");
        if (this.isLocalPlayer)
        {
            print("bruh"); 
            resetScene();
        }
    } 
    void resetScene()
    {
        Destroy(createdCanvas);
        createdCanvas = null;
        isInstantiated = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!isInstantiated)
            {
                createdCanvas = Instantiate(mainUICanvas);
                isInstantiated = true;
            }
            if (!UIOpen)
            {
                createdCanvas.SetActive(true);
            }
            else
            {
                createdCanvas.SetActive(false);
            }
            UIOpen = !UIOpen;
        }
    }
}