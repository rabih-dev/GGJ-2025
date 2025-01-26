using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSizeCorrection : MonoBehaviour
{
    [SerializeField] GameObject player;

    void Update()
    {
        // Inverse the player's localScale by taking the reciprocal of each axis component
        Vector3 playerScale = player.transform.localScale;

        // Ensure that you don't divide by zero to avoid errors
        float inverseX = playerScale.x != 0 ? 1f / playerScale.x : 1f;
        float inverseY = playerScale.y != 0 ? 1f / playerScale.y : 1f;
        float inverseZ = playerScale.z != 0 ? 1f / playerScale.z : 1f;

        // Set this object's scale to be the inverse of the player's scale
        transform.localScale = new Vector3(inverseX, inverseY, inverseZ);
    }
}
