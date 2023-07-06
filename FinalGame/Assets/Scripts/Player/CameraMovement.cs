using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject playerFigure;
    [SerializeField] private float closestDistanceToPlayer;

    private Vector3 _previousPlayerPosition;
    private float _maximumDistanceFromPlayer;

    // Start is called before the first frame update
    void Start()
    {
        // Player position in the first frame is the first previous position
        _previousPlayerPosition = playerFigure.transform.position;

        // Initial camera position is the maximum distance to the player
        _maximumDistanceFromPlayer = Mathf.Abs(Vector3.Distance(transform.position, _previousPlayerPosition));
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    // Move around player figure
    void OnCameraMovement(InputValue input)
    {
        Vector2 inputVector = input.Get<Vector2>();
        var playerTransform = playerFigure.transform; // Get the player transform
        transform.RotateAround(playerTransform.position, Vector3.up, inputVector.x); // Rotate around player
    }

    // Zoom closer to or away from player figure
    void OnCameraZoom(InputValue input)
    {
        Vector2 inputVector = input.Get<Vector2>();

        var shiftValue = inputVector.y * 0.05f; // Multiply with 0.05 to make it less sensitive (smaller movements)
        transform.Translate(new Vector3(0, 0, shiftValue)); // Move camera towards or away from player

        // Distance between player and camera position
        var distance = Mathf.Abs(Vector3.Distance(transform.position, playerFigure.transform.position));

        // Don't zoom further if the camera is too close or too far away
        if (distance < closestDistanceToPlayer || distance > _maximumDistanceFromPlayer)
        {
            // Invert the shift value so it won't zoom any further
            transform.Translate(new Vector3(0, 0, -shiftValue));
        }
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