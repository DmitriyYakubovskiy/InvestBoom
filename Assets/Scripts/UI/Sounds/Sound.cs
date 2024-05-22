using UnityEngine;
using UnityEngine.Audio;
public class Sound : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup mixerGroup;
    [SerializeField] protected float volume = 0.2f;
    private AudioSource audioSrc => GetComponent<AudioSource>();
    public SoundArray[] sounds;

    private void Awake()
    {
        audioSrc.outputAudioMixerGroup = mixerGroup;
    }

    public void PlaySound()
    {
        PlaySound(0, isDestroyed: true);
    }

    public void PlaySound(int i, float volume = 1f, float p1 = 0.85f, float p2 = 1.2f, bool isDestroyed = false)
    {
        int index = Random.Range(0, sounds[i].soundArray.Length);
        AudioClip clip = sounds[i].soundArray[index];
        audioSrc.pitch = Random.Range(p1, p2);

        if (isDestroyed) CreateAudioInPoint(clip, mixerGroup, volume, p1, p2);
        else audioSrc.PlayOneShot(clip, volume);
    }

    public void AudioStop()
    {
        if (audioSrc.isPlaying) audioSrc.Stop();
    }

    public void AudioPause()
    {
        if (audioSrc.isPlaying) audioSrc.Pause();
    }

    public void AudioStart(int index = -1, float v = 0.2f)
    {
        if (!audioSrc.isPlaying)
        {
            if (index == -1) audioSrc.UnPause();
            else PlaySound(index, volume = v);
        }
    }

    private void CreateAudioInPoint(AudioClip clip, AudioMixerGroup mixerGroup, float volume, float p1 = 0.85f, float p2 = 1.2f, float spatialBlend = 1)
    {
        GameObject soundObj = new GameObject("Sound");
        AudioSource source = soundObj.AddComponent<AudioSource>();
        soundObj.transform.position = transform.position;

        Instantiate(soundObj);
        SetAudioParams(ref source, clip, mixerGroup, volume, p1, p2);
        source.Play();
        Destroy(soundObj, clip.length);
    }


    private void SetAudioParams(ref AudioSource source, AudioClip clip, AudioMixerGroup mixerGroup, float volume, float p1 = 0.85f, float p2 = 1.2f, float spatialBlend = 1)
    {
        source.clip = clip;
        source.outputAudioMixerGroup = mixerGroup;
        source.spatialBlend = spatialBlend;
        source.volume = volume;
        source.pitch = Random.Range(p1, p2);
    }

    [System.Serializable]
    public class SoundArray
    {
        public AudioClip[] soundArray;
    }
}

