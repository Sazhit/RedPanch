using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private float _timeChangeScene;
    [SerializeField] private Animator _animator;
    

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void ChangeSceneToAnimation(int scene)
    {
        Time.timeScale = 1;
        _animator.SetTrigger("Comversion");
        StartCoroutine(ChangeScene(scene));
    }

    IEnumerator ChangeScene(int scene)
    {
        yield return new WaitForSeconds(_timeChangeScene);
        SceneManager.LoadScene(scene);
    }
}
