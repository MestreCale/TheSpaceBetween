using UnityEngine;

[CreateAssetMenu(menuName = "Datas/Player Data")]
public class PlayerData : ScriptableObject
{
    [SerializeField]  private float speed;

    public float Speed => speed;

}