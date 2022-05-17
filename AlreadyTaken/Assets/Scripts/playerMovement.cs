using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    public LayerMask combatZone;
    private int combatRandom = 0;
    public Animator transition;
    public float transitionTime = 1f;
    public bool canMove;

    public GameObject playerCh;
    public SpriteRenderer playerSprite;
    public Sprite[] direction;

    PlayerPos playerPosData;
    // Start is called before the first frame update
    
    void ChangeSprite(int i)
    {
        playerSprite.sprite = direction[i];
    }

    void Start()
    {
        transform.position = new Vector3(-3.5f, 0.5f, 0f);
        movePoint.parent = null;
        playerSprite = playerCh.GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        playerPosData = FindObjectOfType<PlayerPos>();
        playerPosData.PlayerPosLoad();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && canMove)
        {
            ChangeSprite(3);
        }
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && canMove)
        {
            ChangeSprite(2);
        }
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && canMove)
        {
            ChangeSprite(0);
        }
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && canMove)
        {
            ChangeSprite(1);
        }
        if (1 > Time.timeScale)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                //megnézzünk hogy combatZone-ra lépünk e
                if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.35f, combatZone) && canMove)
                {
                    //random szám 0 és 100 között
                    combatRandom = Random.Range(0, 100);
                    //Ha igen akkor adunk a játékosnak 10 lépést amíg biztos nem léphet combatba
                    if (10 >= combatRandom)
                    {
                        canMove = false;
                        playerPosData = FindObjectOfType<PlayerPos>();
                        playerPosData.PlayerPosSave();
                        StartCoroutine(LoadLevel(2));
                    }
                }
                //collision detection
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.35f, whatStopsMovement) && canMove)
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                //megnézzünk hogy combatZone-ra lépünk e
                if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.35f, combatZone) && canMove)
                {
                    //random szám 0 és 100 között
                    combatRandom = Random.Range(0, 100);
                    //Ha igen akkor adunk a játékosnak 10 lépést amíg biztos nem léphet combatba
                    if (10 >= combatRandom)
                    {   
                        canMove = false;
                        playerPosData = FindObjectOfType<PlayerPos>();
                        playerPosData.PlayerPosSave();
                        StartCoroutine(LoadLevel(2));
                    }
                }
                //collision detection
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.35f, whatStopsMovement) && canMove)
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
                   
            }
        }
    }
    IEnumerator LoadLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);
    }

}

