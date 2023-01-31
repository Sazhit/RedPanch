using UnityEngine;

public class Rocket : Creature
{
    [SerializeField] private Animator _animator;
    private bool isReady;

    private void OnReady()
    {
        isReady = true;
    }

    protected override void Update()
    {
        if (isReady)
        {
            base.Update();
        }
    }

    public override Creature Spawn(Vector3 pos, Quaternion rot, float speed)
    {
        var inst = (Rocket)base.Spawn(pos, rot, speed);
        inst.isReady = false;
        inst._animator.Play("Rocket");
        return inst;
    }
}
