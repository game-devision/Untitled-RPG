using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float speed = 5f;
    public float horizontal;
    public float vertical;
    public LayerMask groundLayer;
    public Transform RaycastRotater;
    public Transform RaycastPoint;
    void FixedUpdate()
    {
        RaycastHit hit;
        Physics.Raycast(RaycastPoint.position, Vector3.down, out hit, 1f, groundLayer);
        
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        if (hit.collider != null)
        {
            print("On Ground");
        transform.Translate(movement, Space.World); 
        }

        

        if (movement != Vector3.zero)
        {
            //transform.forward = moveme nt.normalized;
            RaycastRotater.forward = movement.normalized;
        }

    }
}
