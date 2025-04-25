using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class BurnedMeatSO : ScriptableObject
{
    public KitchenObjectSO cookedMeat;
    public KitchenObjectSO burnedMeat;
    public int burningDuration;
}
