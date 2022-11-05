using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    private CharacterController _charController;

    public float speed = 6.0f;
    public float gravity = -9.8f;

    public const float baseSpeed = 6.0f;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    void Awake()
    {
        EventManager.StartListening(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void OnDestroy()
    {
        EventManager.StopListening(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }


    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }

    private void OnSpeedChanged(float value)
    {
        Debug.Log("OnSpeedChanged player speed: " + value);
        speed = baseSpeed * value;
    }
}
