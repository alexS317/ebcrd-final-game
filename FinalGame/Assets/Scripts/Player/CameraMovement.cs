using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject playerFigure;
    [SerializeField] private float closestDistanceToPlayer;

    private Vector3 _previousPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Player position in the first frame is the first previous position
        _previousPlayerPosition = playerFigure.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    // Camera follows the player
    void FollowPlayer()
    {
        var currentPlayerPosition = playerFigure.transform.position; // Find the current player position
        // Difference between the player position of the current and previous frame
        var deltaPlayerPosition = currentPlayerPosition - _previousPlayerPosition;

        transform.position += deltaPlayerPosition; // Add the difference to the camera's current position
        // Set the current player position as previous position for the next frame
        _previousPlayerPosition = currentPlayerPosition;
    }
}