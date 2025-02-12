using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform cameraPosition;

    // Update is called once per frame
    private void Update()
    {
        // makes it so cam always moves with player
        transform.position = cameraPosition.position;
    }
}
