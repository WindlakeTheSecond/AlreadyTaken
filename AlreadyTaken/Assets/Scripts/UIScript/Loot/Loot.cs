using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{

    public delegate void TargyValtozas();
    public TargyValtozas targyValtozas;

    public int tarhely = 48;

    public List<Targy> targyak;

    public bool Add(Targy targy)
    {
        if (!targy.alapTargy)
        {
            if (targyak.Count == tarhely)
            {
                return false;
            }
            targyak.Add(targy);
            targyValtozas.Invoke();
        }
        return true;
    }

    public void GetToFelszereles(Targy targy)
    {
        bool bekerult = Felszereles.instance.Add(targy);
        if (bekerult)
            this.Remove(targy);
        targyValtozas.Invoke();
    }

    public void Remove(Targy targy)
    {
        targyak.Remove(targy);
        targyValtozas.Invoke();
    }
}
