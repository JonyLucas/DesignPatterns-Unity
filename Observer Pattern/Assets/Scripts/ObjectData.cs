using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Object Data", menuName = "Object Data", order = 53)]
public class ObjectData : ScriptableObject {
    [SerializeField]
    private string name;

    [SerializeField]
    private Image icon;

    [SerializeField]
    private string text;

    public string Name { get { return name; } }

    public string Description { get { return text; } }

    public Image Icon { get { return icon; } }
}
