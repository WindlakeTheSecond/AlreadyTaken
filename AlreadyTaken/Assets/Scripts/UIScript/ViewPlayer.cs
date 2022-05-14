using UnityEngine;

public class ViewPlayer : MonoBehaviour
{
    public Sprite player;
    public Sprite head;
    public Sprite body;
    public Sprite legs;
    public Sprite weapon;

    void Start()
    {
        player = GetComponent<Sprite>();
    }
    
}
