using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityGameObjectEvent : UnityEvent<GameObject> { }

public class EventListener : MonoBehaviour {

    public Event gameEvent;
    public UnityGameObjectEvent response = new UnityGameObjectEvent();

    private void OnEnable() {
        gameEvent.Register(this);
    }

    private void OnDisable() {
        gameEvent.Unregister(this);
    }

    public void OnEventOccurs(GameObject gameObject) {
        response.Invoke(gameObject);
    }

}
