/*****************************************************************************
// File Name :         AudioClipChannelSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/06/2021
//
// Brief Description : A channel that accepts and broadcasts requests to play AudioClipSO objects.
*****************************************************************************/
using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Channels/AudioClipSO Channel", fileName = "New AudioClipSO Channel")]
public class AudioClipChannelSO : ScriptableObject
{
    public UnityAction<AudioClipSO> OnEventRaised;

    public void RaiseEvent(AudioClipSO clip)
    {
        if (clip == null)
            return;

        OnEventRaised?.Invoke(clip);
    }
}