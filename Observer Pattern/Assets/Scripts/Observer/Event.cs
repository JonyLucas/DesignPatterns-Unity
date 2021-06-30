using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Game Event", order = 52)]
public class Event : ScriptableObject {

    private List<EventListener> listeners = new List<EventListener>();

    public void Register(EventListener listener) {
        listeners.Add(listener);
    }

    public void Unregister(EventListener listener) {
        listeners.Remove(listener);
    }

    public void Occurred(GameObject gameObject) {
        int size = listeners.Count;

        for(int i = 0; i < size; i++) {
            listeners[i].OnEventOccurs(gameObject);
        }
    }

}
