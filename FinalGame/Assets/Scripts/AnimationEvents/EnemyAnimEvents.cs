using UnityEngine;

public class EnemyAnimEvents : MonoBehaviour
{
    public static bool IsHitting { get; private set; }

    // Hit something
    void AttackHit()
    {
        IsHitting = true;
    }

    // Finish attack
    void AttackFinish()
    {
        IsHitting = false;
    }
}
