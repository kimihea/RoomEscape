using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject settingUi;
    public Transform PlayerCamera;
    private bool isMenuVisible = false;
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            ToggleSettingMenu();
        }
    }
    void ToggleSettingMenu()
    {
        isMenuVisible = !isMenuVisible;
        settingUi.SetActive(isMenuVisible);
        if (isMenuVisible) {
            settingUi.transform.position = PlayerCamera.transform.position + PlayerCamera.forward * 1.5f;
            settingUi.transform.rotation = Quaternion.LookRotation(PlayerCamera.forward);
    } }
}
