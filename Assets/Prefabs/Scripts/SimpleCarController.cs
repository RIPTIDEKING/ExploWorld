using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarController : MonoBehaviour
{
    private float m_verticleInput;
    private float m_horizontalInput;
    private float m_steerAngle;
    public WheelCollider flwheel, frwheel;
    public WheelCollider rlwheel, rrwheel;
    public Transform fltrans, frtrans;
    public Transform rltrans, rrtrans;
    public float maxSteerAngle = 30.0f;
    public float motorForce = 50;

    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticleInput = Input.GetAxis("Vertical");
    }
    
    private void Steer()
    {
        m_steerAngle = maxSteerAngle * m_horizontalInput;
        flwheel.steerAngle = m_steerAngle;
        frwheel.steerAngle = m_steerAngle;
    }

    private void Accelerate()
    {
        flwheel.motorTorque = m_verticleInput * motorForce;
        frwheel.motorTorque = m_verticleInput * motorForce;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frwheel, frtrans);
        UpdateWheelPose(flwheel, fltrans);
        UpdateWheelPose(rrwheel, rrtrans);
        UpdateWheelPose(rlwheel, rltrans);
    }

    private void UpdateWheelPose(WheelCollider _collider,Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }
    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }
}
