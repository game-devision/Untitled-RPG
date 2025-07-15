using System.Collections;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float speed = 5f;
    public float horizontal;
    public float vertical;
    public LayerMask groundLayer;
    public LayerMask enemyLayer;
    public Transform RaycastRotater;
    public Transform AttackRotater;
    public Transform RaycastPoint;
    public Transform EnemyDetector;
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public float DashDecelerator = 0.5f;
    public bool isDashing;
    public bool MoveLock;

    Vector3 DashDirection;
    IEnumerator Dash()
    {
        print("Dashing");
        DashDecelerator = dashSpeed;
        isDashing = true;
        DashDirection = RaycastRotater.forward.normalized;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }
    void FixedUpdate()
    {
        RaycastHit hit;
        RaycastHit hit2;
        Physics.Raycast(RaycastPoint.position, Vector3.down, out hit, 1f, groundLayer);
        Physics.Raycast(EnemyDetector.position, Vector3.down, out hit2, 1f, enemyLayer);

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        if (!isDashing && !MoveLock && hit.collider != null)
        {

            transform.Translate(movement, Space.World);
        }
        {
            print("On Ground");
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && !isDashing)
        {
            
            StartCoroutine(Dash());

        }

        if (movement != Vector3.zero)
        {
            //transform.forward = moveme nt.normalized;
            RaycastRotater.forward = movement.normalized;
            AttackRotater.forward = movement.normalized;
        }
        if (isDashing && hit.collider != null && !MoveLock)
        {
            DashDecelerator -= 0.5f;
            transform.Translate(DashDirection * DashDecelerator * Time.deltaTime, Space.World);
        }

    }
    
}
