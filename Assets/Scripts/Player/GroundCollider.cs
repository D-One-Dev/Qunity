using UnityEngine;

public class GroundCollider : MonoBehaviour
{
    public bool isGrounded;
    private void OnTriggerStay(Collider collision)
    {
        isGrounded = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        isGrounded = false;
    }
}
