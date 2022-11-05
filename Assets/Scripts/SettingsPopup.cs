using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] private AudioClip sound;

    public void Open()
    {
        gameObject.SetActive(true);
        Managers.Audio.PlaySound(sound);
    }

    public void Close()
    {
        gameObject.SetActive(false);
        Managers.Audio.PlaySound(sound);
    }

    public void OnSubmitName(string name)
    {
        Debug.Log(name);
        Managers.Audio.PlaySound(sound);
    }

    public void OnSpeedValue(float speed)
    {
        Debug.Log("OnSpeedValue: " + speed);
        EventManager.TriggerEvent(GameEvent.SPEED_CHANGED, speed);
        Managers.Audio.PlaySound(sound);
    }

    public void OnSoundToggle()
    {
        Managers.Audio.soundMute = !Managers.Audio.soundMute;
        Managers.Audio.PlaySound(sound);
    }

    public void OnMusicToggle()
    {
        Managers.Audio.musicMute = !Managers.Audio.musicMute;
        Managers.Audio.PlaySound(sound);
    }

    public void OnSoundValue(float volume)
    {
        Managers.Audio.soundVolume = volume;
    }

    public void OnMusicValue(float volume)
    {
        Managers.Audio.musicVolume = volume;
    }

    public void OnPlayMusic(int selector)
    {
        Managers.Audio.PlaySound(sound);

        switch (selector)
        {
            case 1:
                Managers.Audio.PlayIntroMusic();
                break;
            case 2:
                Managers.Audio.PlayLevelMusic();
                break;
            default:
                Managers.Audio.StopMusic();
                break;
        }
    }
}
