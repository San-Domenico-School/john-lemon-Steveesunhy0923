using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameEnding gameEnding;

    private bool isPlayerInRange;

    void Update()
    {
        CanGargoyleSeePlayer();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            isPlayerInRange = false;
        }
    }

    void CanGargoyleSeePlayer()
    {
        Debug.Log("Observer33: " + isPlayerInRange);
        if (isPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
