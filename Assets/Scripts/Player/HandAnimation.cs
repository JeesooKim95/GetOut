using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandAnimation : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    private InputDevice playerDevice;

    public GameObject handModel;
    private GameObject spawnedHandModel;

    private Animator handAnimator;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            playerDevice = devices[0];

            spawnedHandModel = Instantiate(handModel, transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }
    }

    void UpdateHandAnimation()
    {
        if(playerDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (playerDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    void Update()
    {
        /*if (playerDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        {
            Debug.Log("pressing primary button");
        }

        if (playerDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
        {
            Debug.Log("pressing trigger" + triggerValue);
        }
               
        if (playerDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
        {
            Debug.Log("Primary touchpad used" + primary2DAxisValue);
        }
        */


        //spawnedHandModel.SetActive(true);

        if (!playerDevice.isValid)
        {
            Init();
        }
        else
        {
            UpdateHandAnimation();
        }
    }
}
