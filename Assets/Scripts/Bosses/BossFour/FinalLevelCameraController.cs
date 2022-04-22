using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelCameraController : MonoBehaviour
{
    public GameObject finalLevelPlatform;

    private void FixedUpdate()
    {
        Vector3 platformPosition = finalLevelPlatform.transform.position;
        transform.position = new Vector3(platformPosition.x, platformPosition.y, transform.position.z);
    }
}
