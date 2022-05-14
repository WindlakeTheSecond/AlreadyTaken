using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneWaySlot : MonoBehaviour
{
    public Image ikon;

    public Targy targy;

    public LootFe lootFe;

    public Equipment equipment;

    public void TargyAdd(Targy ujTargy)
    {
        targy = ujTargy;
        ikon.sprite = targy.ikon;
        ikon.color = new Color(255, 255, 255, 255);
        ikon.enabled = true;
    }

    public void UritSlot()
    {
        targy = null;
        ikon.sprite = null;
        ikon.color = new Color(0, 0, 0, 0);
        ikon.enabled = false;
    }

    public void onClick()
    {
        lootFe.onClick(targy);
    }

    public void oneqClick(int id)
    {
        equipment.Leszerel(id);
    }

}
