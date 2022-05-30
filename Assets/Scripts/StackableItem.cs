

using UnityEngine;

[System.Serializable]
public class StackableItem
{
  [SerializeField]  private GenericItem item;
  [SerializeField]  private int amount;
    public StackableItem(GenericItem item, int amount)
    {
        this.item = item;
        this.amount = amount;

    }

    public GenericItem Item => item;

    public int Amount
    {
        get => amount;
        set => amount = value;
    }
}