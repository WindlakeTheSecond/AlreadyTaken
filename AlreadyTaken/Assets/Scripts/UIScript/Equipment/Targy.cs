using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Inventory/Targy")]
public class Targy : ScriptableObject
{
    new public string name = "Új Tárgy";
    public Sprite ikon = null;
    public bool alapTargy = false;
    public bool felszereles = false;

    public virtual void Hasznal(Targy targy)
    {



    }

    public void RemoveFromInventory()
    {
        Felszereles.instance.Remove(this);
    }
}
