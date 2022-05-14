using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FelszerelesFe : MonoBehaviour
{
    public Transform itemsParent;

    public static Felszereles felszereles;

    public FelszerelesSlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        felszereles = Felszereles.instance;
        felszereles.targyValtozas += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<FelszerelesSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i<felszereles.targyak.Count)
            {
                slots[i].TargyAdd(felszereles.targyak[i]);
            }
            else
            {
                slots[i].UritSlot();
            }
        }
    }
}
