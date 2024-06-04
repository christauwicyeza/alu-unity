using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float angleRotation = 45f;

    private Vector3 distanceFromPlayer = Vector3.zero;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private void Awake()
    {
        distanceFromPlayer = transform.position - player.position;
    }

    private void Update()
    {
        FollowPlayer();
        RotateAroundPlayer();
    }

    void RotateAroundPlayer()
    {
        rotationX += Input.GetAxis("Mouse X") * angleRotation * Time.deltaTime;
        rotationY -= Input.GetAxis("Mouse Y") * angleRotation * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0, rotationX, 0);

        transform.rotation = rotation;

        transform.position = player.position - (rotation * new Vector3(0, 0, 5));

        transform.LookAt(player);
        transform.rotation = rotation;
    }

    void FollowPlayer()
    {
        transform.position = player.transform.position + distanceFromPlayer;
    }
}
