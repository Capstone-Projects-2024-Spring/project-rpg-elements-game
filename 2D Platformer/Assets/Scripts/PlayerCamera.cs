using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamera : MonoBehaviour
{
    private CinemachineVirtualCamera camObj;
    CinemachineFramingTransposer comp;
    // Start is called before the first frame update

    private void Awake()
    {
        camObj = GetComponent<CinemachineVirtualCamera>();
    }
    void Start()
    {
        comp = camObj.GetComponentInChildren<CinemachineFramingTransposer>();

        comp.m_TrackedObjectOffset.x = -3f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
