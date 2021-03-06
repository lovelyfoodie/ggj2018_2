#if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.
//////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2017 Audiokinetic Inc. / All Rights Reserved
//
//////////////////////////////////////////////////////////////////////

using UnityEngine;
using System;
using System.Collections.Generic;


[AddComponentMenu("Wwise/AkSpatialAudioListener")]
[RequireComponent(typeof(AkAudioListener))]
[DisallowMultipleComponent]
///@brief Add this script on the game object that represent a listener.  This is normally added to the Camera object or the Player object, but can be added to any game object when implementing 3D busses.  \c isDefaultListener determines whether the game object will be considered a default listener - a listener that automatically listens to all game objects that do not have listeners attached to their AkGameObjListenerList's.
/// \sa
/// - <a href="https://www.audiokinetic.com/library/edge/?source=SDK&id=soundengine__listeners.html" target="_blank">Integrating Listeners</a> (Note: This is described in the Wwise SDK documentation.)
public class AkSpatialAudioListener : AkSpatialAudioBase
{
    AkAudioListener AkAudioListener = null;

    private void Awake()
    {
        AkAudioListener = GetComponent<AkAudioListener>();
    }

    private void OnEnable()
	{
        spatialAudioListeners.Add(this);
    }

	private void OnDisable()
    {
        spatialAudioListeners.Remove(this);
    }

    public class SpatialAudioListenerList
    {
        private List<AkSpatialAudioListener> listenerList = new List<AkSpatialAudioListener>();

        public List<AkSpatialAudioListener> ListenerList
        {
            get { return listenerList; }
        }

        /// <summary>
        /// Uniquely adds listeners to the list
        /// </summary>
        /// <param name="listener"></param>
        /// <returns></returns>
        public bool Add(AkSpatialAudioListener listener)
        {
            if (listener == null)
                return false;

            if (listenerList.Contains(listener))
                return false;

            listenerList.Add(listener);
            Refresh();
            return true;
        }

        /// <summary>
        /// Removes listeners from the list
        /// </summary>
        /// <param name="listener"></param>
        /// <returns></returns>
        public bool Remove(AkSpatialAudioListener listener)
        {
            if (listener == null)
                return false;

            if (!listenerList.Contains(listener))
                return false;

            listenerList.Remove(listener);
            Refresh();
            return true;
        }

        private void Refresh()
        {
            if (ListenerList.Count == 1)
            {
                if (s_SpatialAudioListener != null)
                    AkSoundEngine.UnregisterSpatialAudioListener(s_SpatialAudioListener.gameObject);

                s_SpatialAudioListener = ListenerList[0];

                if (AkSoundEngine.RegisterSpatialAudioListener(s_SpatialAudioListener.gameObject) == AKRESULT.AK_Success)
                    s_SpatialAudioListener.SetGameObjectInRoom();
            }
            else if (ListenerList.Count == 0 && s_SpatialAudioListener != null)
            {
                AkSoundEngine.UnregisterSpatialAudioListener(s_SpatialAudioListener.gameObject);
                s_SpatialAudioListener = null;
            }
        }
    }

    private static AkSpatialAudioListener s_SpatialAudioListener;

    public static AkAudioListener TheSpatialAudioListener
    {
        get { return s_SpatialAudioListener.AkAudioListener; }
    }

    public static SpatialAudioListenerList SpatialAudioListeners { get { return spatialAudioListeners; } }
    private static SpatialAudioListenerList spatialAudioListeners = new SpatialAudioListenerList();
}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.