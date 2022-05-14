using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open : MonoBehaviour
{
    public Sprite opened;

    SpriteRenderer sprite;
    public GameObject inventory;
    public GameObject chest;
    public GameObject invButton;
    public GameObject optionsButton;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            sprite.sprite = opened;
            LootFe loot = chest.GetComponent<LootFe>();
            loot.honnanjon = this.name;
            inventory.SetActive(true);
            chest.SetActive(true);
            invButton.SetActive(false);
            optionsButton.SetActive(false);
        }
    }
}
