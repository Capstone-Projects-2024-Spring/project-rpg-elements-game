using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AbilitiesUI : MonoBehaviour
{
    private bool UIOpen = false;
    private bool isInstantiated = false;
    [SerializeField] public GameObject mainUICanvas;
    private GameObject createdCanvas;

    private void Awake()
    {
        //mainUICanvas.GetComponent<Canvas>().enabled = false;
        //createdCanvas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!SceneManager.GetSceneByName("AbilitiesUI").isLoaded)
            {
                //SceneManager.LoadSceneAsync("AbilitiesUI", LoadSceneMode.Additive);
            }
            if (!isInstantiated)
            {
                createdCanvas = Instantiate(mainUICanvas);
                isInstantiated = true;
            }
            if (!UIOpen)
            {
                ////SceneManager.LoadSceneAsync("AbilitiesUI", LoadSceneMode.Additive);
                //childrenImages = this.gameObject.GetComponentsInChildren<Image>();
                //for (int i = 0; i < childrenImages.Length; i++)
                //{
                //    childrenImages[i].enabled = true;
                //}

                createdCanvas.SetActive(true);
                //mainUICanvas.GetComponent<Canvas>().enabled = true;
            }
            else
            {
                createdCanvas.SetActive(false);
                //mainUICanvas.GetComponent<Canvas>().enabled = false;


                ////SceneManager.UnloadSceneAsync("AbilitiesUI");
                //childrenImages = this.gameObject.
                //for (int i = 0; i < childrenImages.Length; i++)
                //{
                //    childrenImages[i].enabled = false;
                //}
            }
            UIOpen = !UIOpen;
        }
    }
}