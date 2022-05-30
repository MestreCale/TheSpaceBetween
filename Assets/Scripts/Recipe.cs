using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Recipe", fileName = "Recipe", order = 0)]
public class Recipe : ScriptableObject
{
    public List<GenericItem> needed;
    public int amountOfEach;
    public GenericItem given;
    public int amountGiven;
}