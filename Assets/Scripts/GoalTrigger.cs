using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public int jugadorQueAnota = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            FutbolinGameManager.Instance.AnotarGol(jugadorQueAnota);
        }
    }
}