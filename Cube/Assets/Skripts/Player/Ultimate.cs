using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Ultimate : MonoBehaviour
{
    [SerializeField] private PlayerControl _playerControl;
    [SerializeField] private GameObject _shockWave;
    [SerializeField] private Image skillsImage;
    [SerializeField] private float _skillsCooldown;
    [SerializeField] private bool _isCooldown;

    [SerializeField] private Animator _animator;

    public float SkillsCooldown { get => _skillsCooldown; set => _skillsCooldown = value; }

    public bool IsCooldown { get => _isCooldown; set => _isCooldown = value; }

    private void Update()
    {
        if (_isCooldown)
        {
            skillsImage.fillAmount += 1 / _skillsCooldown * Time.deltaTime;
            if (skillsImage.fillAmount >= 1)
            {
                _isCooldown = false;
            }
        }
    }

    public void UseUltimate()
    {
        if (_isCooldown == false)
        {
            _playerControl.OnButtonDown();
            _playerControl.CheckUltimate = false;
        }          
    }

    private IEnumerator OffUlta()
    {
        yield return new WaitForSeconds(1.5f);
        _animator.SetBool("StateUltimate", false);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (_playerControl.CheckUltimate == false)
        {
            _animator.SetBool("StateUltimate", true);
            StartCoroutine(OffUlta());
            _isCooldown = true;
            _playerControl.OnGround();
        }
    }
}
