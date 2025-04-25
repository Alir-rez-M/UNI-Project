using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class FriedMeatSO : ScriptableObject
{
    public KitchenObjectSO uncookedMeat;
    public KitchenObjectSO cookedMeat;
    public int cookingDuration;

}
