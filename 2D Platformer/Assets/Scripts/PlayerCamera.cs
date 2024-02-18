using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamera : MonoBehaviour
{
    private CinemachineVirtualCamera camObj;
    public float smoothing = 5f;
    CinemachineFramingTransposer comp;
    // Start is called before the first frame update

    private void Awake()
    {
        camObj = GetComponent<CinemachineVirtualCamera>();
        comp = camObj.GetComponentInChildren<CinemachineFramingTransposer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float targetXOffset = Mathf.Lerp(comp.m_TrackedObjectOffset.x, horizontalInput * 3f, Time.deltaTime * smoothing);
        comp.m_TrackedObjectOffset.x = targetXOffset;
    }
}
