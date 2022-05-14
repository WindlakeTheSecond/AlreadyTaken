using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootFe : MonoBehaviour
{
    public Transform itemsParent;

    public Text text;

    public static Loot felszereles;

    public string honnanjon;
    
    public OneWaySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        if (honnanjon!=null)
        felszereles = GameObject.Find(honnanjon).GetComponent<Loot>();

        if(text!=null)
        text.text = honnanjon;

        felszereles.targyValtozas += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<OneWaySlot>();
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < felszereles.targyak.Count&&felszereles.targyak[i]!=null)
            {
                slots[i].TargyAdd(felszereles.targyak[i]);
                slots[i].lootFe = this;
            }
            else
            {
                slots[i].UritSlot();
                slots[i].lootFe = this;
            }
        }
    }

    public void onClick(Targy targy)
    {
        felszereles.GetToFelszereles(targy);
    }
}
