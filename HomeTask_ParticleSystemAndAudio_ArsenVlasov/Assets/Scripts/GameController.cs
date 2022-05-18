using System.Collections;
using UnityEngine;
public class GameController : MonoBehaviour
{
    //[SerializeField] private ParticleSystem _parentParticleSystem;
    [SerializeField] private AudioManager.FireworkSoundType _soundType;

    //private int _currentNumberOfParticles = 0;
    [SerializeField] private int coroutineWait = 1;
    bool keepPlaying = true;

    void Start()
    {
        StartCoroutine(SoundOut());
    }

    IEnumerator SoundOut()
    {
        while (keepPlaying)
        {
            PlayFireworkShot();
            yield return new WaitForSeconds(coroutineWait);
        }
    }

    /*void Start()
    {
        *//*_parentParticleSystem = this.GetComponent<ParticleSystem>();
        if (_parentParticleSystem == null)
            Debug.LogError("Missing ParticleSystem!", this);*//*
    }*/

    void Update()
    {
        /*var amount = Mathf.Abs(_currentNumberOfParticles - _parentParticleSystem.particleCount);

        if (_parentParticleSystem.particleCount < _currentNumberOfParticles)
        {
            AudioManager.PlayMusic(_soundType);
        }*/
        //PlayFireworkShot();

    }

    private void PlayFireworkShot()
    {
        AudioManager.PlayMusic(_soundType);
    }
}
