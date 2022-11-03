using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerMovement : MonoBehaviour
{
    public XRNode inputSource;
    public int speed = 3;
    public float gravity = -9.81f;
    public LayerMask groundLayer;
    public float syncHeight = 0.2f;

    private float fallSpeed;
    private XROrigin origin;
    private Vector2 inputAxis;
    private CharacterController character;

    private void Start()
    {
        character = GetComponent<CharacterController>();
        origin = GetComponent<XROrigin>();
    }

    private void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        SyncWithHeadset();

        Quaternion headDir = Quaternion.Euler(0, origin.Camera.gameObject.transform.eulerAngles.y, 0);
        Vector3 dir = headDir * new Vector3(inputAxis.x, 0, inputAxis.y);

        //move the player
        character.Move(dir * Time.fixedDeltaTime * speed);

        //apply gravity when in air
        bool isGround = CheckGround();
        if(isGround)
        {
            fallSpeed = 0.0f;
        }
        else
        {
            fallSpeed += gravity * Time.fixedDeltaTime;
        }
        character.Move(Vector3.up * fallSpeed * Time.fixedDeltaTime);    
    }

    private void SyncWithHeadset()
    {
        character.height = origin.CameraInOriginSpaceHeight + syncHeight;
        Vector3 characterCenter = transform.InverseTransformPoint(origin.Camera.gameObject.transform.position);
        character.center = new Vector3(characterCenter.x, characterCenter.y / 2 + character.skinWidth, characterCenter.z);
    }

    private bool CheckGround()
    {
        Vector3 rayOrigin = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;
        bool isHit = Physics.SphereCast(rayOrigin, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
        return isHit;
    }
    
    public void IncreaseSpeed(int amount)
    {
        speed += amount; 
    }

    public int GetSpeed()
    {
        return speed;
    }
}
