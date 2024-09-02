using UnityEngine;

[CreateAssetMenu(fileName = "Create new stat type", menuName = "Vehicles/Stats")]
public class StatType : ScriptableObject
{

    [SerializeField] private string _name = "New name";
    [SerializeField] private float _defaultValue = 0f;

    public string Name => _name;
    public float DefaultValue => _defaultValue;

}
