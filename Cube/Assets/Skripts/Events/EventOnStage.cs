using UnityEngine;
using System;

public class EventOnStage : MonoBehaviour
{
    public static Action EnemyDied;

    public static void OnEnemyDied()
    {
        EnemyDied?.Invoke();
    }
}
