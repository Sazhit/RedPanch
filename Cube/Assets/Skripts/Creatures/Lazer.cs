using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : Creature
{
    [SerializeField] private float range;
    [SerializeField] private Transform target;
    [SerializeField] private LayerMask layerMask;

    private Vector2 direction;
    private Vector2 targetPos;

    protected override void Update()
    {
        OnLazer();
        base.Update();
    }

    private void OnLazer()
    {
        targetPos = target.position;

        direction = targetPos - (Vector2)transform.position;

        var hit = Physics2D.Raycast(transform.position, direction, range, layerMask);

        Debug.DrawRay(transform.position, direction, Color.red);

        if (hit.transform != null && hit.transform.TryGetComponent(out Health health)) 
        {
            health.ApplyDamage(_damage);
            Debug.Log(_damage);
        }
    }
}
