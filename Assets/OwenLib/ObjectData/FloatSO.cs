using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class FloatSO : ScriptableObject
{
    [SerializeField]
    private float _value;
    // Start is called before the first frame update
    public float MyValue
    {
        get { return _value; }
        set { _value = value; }
    }
}
