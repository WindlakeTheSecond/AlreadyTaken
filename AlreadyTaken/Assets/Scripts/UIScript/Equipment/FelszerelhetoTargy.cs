using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Uj Felszerelheto",menuName ="Inventory/Felszerelheto")]
public class FelszerelhetoTargy : Targy
{
    public FelszerelesHely felszerelesHely;

    public int armorModifier;
    public int damageModifier;
    public override void Hasznal(Targy targy)
    {
        base.Hasznal(targy);
        Equipment.instance.Felszerel((FelszerelhetoTargy)targy);
        RemoveFromInventory();
    }
}


public enum FelszerelesHely { Fej, Test, Láb, Fegyver }