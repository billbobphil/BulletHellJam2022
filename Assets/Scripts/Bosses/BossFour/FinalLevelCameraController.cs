using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelCameraController : MonoBehaviour
{
    public GameObject finalLevelPlatform;
    public GameObject player;
    public bool shouldFollowPlayer;
    
    private void FixedUpdate()
    {
        if (!shouldFollowPlayer)
        {
            Vector3 platformPosition = finalLevelPlatform.transform.position;
            transform.position = new Vector3(platformPosition.x, platformPosition.y, transform.position.z);
        }
        else
        {
            Vector3 platformPosition = player.transform.position;
            transform.position = new Vector3(platformPosition.x, platformPosition.y, transform.position.z);
        }
        
    }
}
