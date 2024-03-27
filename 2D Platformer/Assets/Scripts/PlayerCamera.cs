using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Mirror;


public class PlayerCamera : NetworkBehaviour
{
    private CinemachineVirtualCamera camObj;
    private Transform parentTransform;
    public float smoothing = 5f;
    CinemachineFramingTransposer comp;
    // Start is called before the first frame update

    private void Awake()
    {
        camObj = GetComponent<CinemachineVirtualCamera>();
        comp = camObj.GetComponentInChildren<CinemachineFramingTransposer>();
    }

    /** public override void OnStartLocalPlayer()
     {
         base.OnStartLocalPlayer();

         Transform parentTransform = transform.parent;

         camObj.Follow = parentTransform;
     }
    **/
    private void Start()
    {
        camObj = GetComponent<CinemachineVirtualCamera>();
    }


    public override void OnStartAuthority()
    {
        base.OnStartAuthority();
        if(camObj != null)
        {
            camObj.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;
        float horizontalInput = Input.GetAxis("Horizontal");
        float targetXOffset = Mathf.Lerp(comp.m_TrackedObjectOffset.x, horizontalInput * 3f, Time.deltaTime * smoothing);
        comp.m_TrackedObjectOffset.x = targetXOffset;
    }
}
