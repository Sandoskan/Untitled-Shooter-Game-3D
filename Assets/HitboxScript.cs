
using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private HealPointsManager _healPointsManager;

    public Rigidbody GetRigidbody()
    {
        return _rigidbody;
    }

    public HealPointsManager GetHealPointsManager()
    {
        return _healPointsManager;
    }
}
