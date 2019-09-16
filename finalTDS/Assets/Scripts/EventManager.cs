using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EVENT_TYPE { GAME_INIT,GAME_END,HEALTH_CHANGE,DEAD, TEST_HS};

public class EventManager : MonoBehaviour
{
    #region YET ANOTHER SINGLETON CLASS
    private static EventManager _instance;
    public static EventManager Instance
    {
        get { return _instance; }
        set { }
    }
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    #endregion
    #region Event Manager fitches
    public delegate void OnEvent(EVENT_TYPE eventType,Component sender, object param=null);
    private Dictionary<EVENT_TYPE, List<OnEvent>> Listeners = new Dictionary<EVENT_TYPE, List<OnEvent>>();
    #endregion
    #region Methods
    /// <summary>
    /// add event listener
    /// </summary>
    /// <param name="eventType">type of event</param>
    /// <param name="listener">object who wants to know</param>
    public void AddListener(EVENT_TYPE eventType,OnEvent listener)
    {
        List<OnEvent> listenList = null;

        if(Listeners.TryGetValue(eventType,out listenList))
        {
            listenList.Add(listener);
            return;
        }
        listenList = new List<OnEvent>();
        listenList.Add(listener);
        Listeners.Add(eventType,listenList);

    }
    /// <summary>
    ///posts notification 
    /// </summary>
    /// <param name="eventType">type of event</param>
    /// <param name="sender">object to call</param>
    /// <param name="param">Any parameter u want bro</param>
    public void PostNotification(EVENT_TYPE eventType,Component sender,object param = null)
    {
        List<OnEvent> listenList = null;
        if (!Listeners.TryGetValue(eventType,out listenList))
        {
            return;
        }
        foreach (OnEvent eventProcessor in listenList)
        {
            if (!eventProcessor.Equals(null))
            {
                eventProcessor(eventType, sender, param);
            }
        }
    }
    /// <summary>
    /// delete event and all its listeners
    /// </summary>
    /// <param name="eventType">event 2 remove</param>
    public void RemoveEvent(EVENT_TYPE eventType)
    {
        Listeners.Remove(eventType);
    }
    /// <summary>
    /// delete all redundant slots from Listeners
    /// </summary>
    public void RemoveRedundancies()
    {
        Dictionary<EVENT_TYPE, List<OnEvent>> TmpDictionary = new Dictionary<EVENT_TYPE, List<OnEvent>>();

        foreach(KeyValuePair<EVENT_TYPE,List<OnEvent>> item in Listeners)
        {
            for(int i = item.Value.Count - 1; i >= 0; i--)
            {
                if (item.Value[i].Equals(null))
                {
                    item.Value.RemoveAt(i);
                }
            }
            if (item.Value.Count > 0)
            {
                TmpDictionary.Add(item.Key, item.Value);
            }
            Listeners = TmpDictionary;
        }
    }

    void OnLevelWasLoaded()
    {
        RemoveRedundancies();
    }

    internal void AddListener(EVENT_TYPE tEST_HS, Rat rat)
    {
        throw new NotImplementedException();
    }
    #endregion

}
