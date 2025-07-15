using UnityEngine;

public class EnemyLockOn : MonoBehaviour
{
    public Player_movement player_Movement;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            print("Enemy Detected: ");
            player_Movement.AttackRotater.forward = (other.transform.position - player_Movement.transform.position).normalized;
            if (player_Movement.isDashing)
            {
                player_Movement.MoveLock = true;
            }
            if (!player_Movement.isDashing)
            {
                player_Movement.MoveLock = false;
            }
        }
    }
}
