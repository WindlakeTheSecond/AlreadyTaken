
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FelszerelesSlot : MonoBehaviour
{
    public Image ikon;
    public Button removeButton;

    public Targy targy;

    public void TargyAdd(Targy ujTargy)
    {
        targy = ujTargy;
        ikon.sprite = targy.ikon;
        ikon.color = new Color(255, 255, 255, 255);
        ikon.enabled = true;
        removeButton.interactable = true;
    }

    public void UritSlot()
    {
        targy = null;
        ikon.sprite = null;
        ikon.color = new Color(0, 0, 0, 0);
        ikon.enabled = false;
        removeButton.interactable = false;
    }
    
    public void OnRemoveButton()
    {
        Felszereles.instance.Remove(targy);
    }

    public void HasznalTargy()
    {
        targy.Hasznal(targy);
    }
}
