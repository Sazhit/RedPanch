using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Creature : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [SerializeField] private int _positionIndex;
    [SerializeField] private float _speed;

    private Spawner _spawner;
    private ObjectPool<Creature> _pool;

    public int PositionIndex
    {
        get
        {
            return _positionIndex;
        }
        private set
        {
            _positionIndex = value;
        }
    }

    protected virtual void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector2.left);
    }

    public void Init(Spawner spawner)
    {
        _spawner = spawner;
        _pool = new ObjectPool<Creature>(createFunc: () => Instantiate(this),
              actionOnGet: (obj) => obj.gameObject.SetActive(true),
              actionOnRelease: (obj) => obj.gameObject.SetActive(false),
              actionOnDestroy: (obj) => Destroy(obj.gameObject),
              collectionCheck: true,
              defaultCapacity: 15,
              maxSize: 15);
    }

    public virtual Creature Spawn(Vector3 pos, Quaternion rot, float speed)
    {
        var inst = _pool.Get();
        inst.transform.SetPositionAndRotation(pos, rot);
        inst._pool = _pool;
        inst._spawner = _spawner;
        return inst;
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            health.ApplyDamage(_damage);
        }

        Die();
    }

    public void Die()
    {
        _pool.Release(this);
    }
}
