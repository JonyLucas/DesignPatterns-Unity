using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InfoText : MonoBehaviour {

    private Text descriptionText;

    // Start is called before the first frame update
    void Start() {
        descriptionText = GetComponent<Text>();
        descriptionText.enabled = false;
    }

    public void UpdateText(GameObject gameObject) {
        
        ObjectAccessData accessData = gameObject.GetComponent<ObjectAccessData>();
        if(accessData != null) {
            descriptionText.text = accessData.data.Description;
        }

        StartCoroutine(DisplayCoroutine());
    }


    private IEnumerator DisplayCoroutine() {
        descriptionText.enabled = true;
        yield return new WaitForSeconds(5);
        descriptionText.enabled = false;
    }

}
