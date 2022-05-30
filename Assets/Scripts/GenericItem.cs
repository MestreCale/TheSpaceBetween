using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Create GenericItem", fileName = "GenericItem", order = 0)]
public class GenericItem : ScriptableObject
{
    public Sprite sprite;
    public string itemName;

}