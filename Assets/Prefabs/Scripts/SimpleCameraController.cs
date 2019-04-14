using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraController : MonoBehaviour
{
    public Transform objTOFollow;
    public Vector3 offSet;
    public float followSpeed = 10;
    public float lookSpeed = 10;

    public void LookAtTarget()
    {
        Vector3 _lookDirection = objTOFollow.position - transform.position;
        Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);
    }

    public void MoveToTarget()
    {
        Vector3 _tragetPos = objTOFollow.position + objTOFollow.forward * offSet.z + objTOFollow.right * offSet.x + objTOFollow.up * offSet.y;
        transform.position = Vector3.Lerp(transform.position, _tragetPos, followSpeed * Time.deltaTime);

    }

    private void FixedUpdate()
    {
        LookAtTarget();
        MoveToTarget();
    }
}
