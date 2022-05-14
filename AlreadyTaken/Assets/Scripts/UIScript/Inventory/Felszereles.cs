using System.Collections.Generic;
using UnityEngine;

public class Felszereles : MonoBehaviour
{
    public static Felszereles instance;

    public delegate void TargyValtozas();
    public TargyValtozas targyValtozas;

    void Awake()
    {
        instance = this;
    }

    public int tarhely = 48;

    public List<Targy> targyak = new List<Targy>();
    public bool Add(Targy targy)
    {

        if (targyak.Count==tarhely)
        {
            return false;
        }
        targyak.Add(targy);
        targyValtozas.Invoke();
        return true;
    }

    public void Remove(Targy targy)
    {
        targyak.Remove(targy);
        targyValtozas.Invoke();
    }
}
