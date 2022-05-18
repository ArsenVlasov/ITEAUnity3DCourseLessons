using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource _fireworkSource;
    [SerializeField] private List<FireworkMusicData> _musicData = new List<FireworkMusicData>();

    private static AudioManager _instance;

    public enum FireworkSoundType
    {
        Blue,
        Burst,
        CampFireClap,
        Deep,
        HeavyShot,
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void PlayMusicInner(FireworkSoundType fireworkSoundType)
    {
        var musicData = _musicData.Find(data => data.SoundType == fireworkSoundType);
        if (musicData != null)
        {
            _fireworkSource.PlayOneShot(musicData.Audio);
        }
    }

    public static void PlayMusic(FireworkSoundType fireworkSound)
    {
        _instance.PlayMusicInner(fireworkSound);
    }


    [System.Serializable]
    public class FireworkMusicData
    {
        [SerializeField] private FireworkSoundType _fireworkSoundType;
        [SerializeField] private AudioClip _audioClip;

        public FireworkSoundType SoundType => _fireworkSoundType;
        public AudioClip Audio => _audioClip;
    }
}
