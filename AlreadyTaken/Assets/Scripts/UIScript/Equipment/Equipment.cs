using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public static Equipment instance;

    public FelszerelhetoTargy[] felszerelesek;
    public OneWaySlot[] slots;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        slots = GetComponentsInChildren<OneWaySlot>();
        felszerelesek = new FelszerelhetoTargy[System.Enum.GetNames(typeof(FelszerelesHely)).Length];
    }

    private void Update()
    {
        GameObject[] felszereles = GameObject.FindGameObjectsWithTag("VisibleEquipment");
        for (int i = 0; i < felszerelesek.Length; i++)
        {
            if (felszerelesek[i]!=null)
            {
                felszereles[i].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            }
            else
            {
                felszereles[i].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            }
        }
    }

    public void Felszerel(FelszerelhetoTargy ujfelszereles)
    {
        int helyIndex = (int)ujfelszereles.felszerelesHely;

        if (felszerelesek[helyIndex] == null)
        {
            felszerelesek[helyIndex] = ujfelszereles;
        }
        else
        {
            Felszereles.instance.Add(felszerelesek[helyIndex]);
            felszerelesek[helyIndex] = ujfelszereles;
        }
        slots[helyIndex].TargyAdd(ujfelszereles);
    }

    public void Leszerel(int helyIndex)
    {
        if (felszerelesek[helyIndex]!=null)
        {
            FelszerelhetoTargy regifelszereles = felszerelesek[helyIndex];
            Felszereles.instance.Add(felszerelesek[helyIndex]);
            felszerelesek[helyIndex] = null;
            slots[helyIndex].UritSlot();
        }
    }
}
