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
    private int combatGrace = 0;
    private int combatRandom = 0;
    public Animator transition;
    public float transitionTime = 1f;
    public bool canMove;

    PlayerPos playerPosData;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-0.5f, 0.5f, 0f);
        movePoint.parent = null;
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
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                //megn�zz�nk hogy combatZone-ra l�p�nk e
                if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.35f, combatZone) && canMove)
                {
                    //random sz�m 0 �s 100 k�z�tt
                    combatRandom = Random.Range(0, 100);
                    combatGrace--;
                    //Ha igen akkor adunk a j�t�kosnak 10 l�p�st am�g biztos nem l�phet combatba
                    if (10 >= combatRandom  && combatGrace <= 0)
                    {
                        canMove = false;
                        playerPosData = FindObjectOfType<PlayerPos>();
                        playerPosData.PlayerPosSave();
                        combatGrace = 10;
                        StartCoroutine(LoadLevel(2));
                    }
                    Debug.Log("AfterCombatGrace: " + combatGrace);
                }
                //collision detection
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.35f, whatStopsMovement) && canMove)
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                //megn�zz�nk hogy combatZone-ra l�p�nk e
                if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.35f, combatZone) && canMove)
                {
                    //random sz�m 0 �s 100 k�z�tt
                    combatRandom = Random.Range(0, 100);
                    combatGrace--;
                    //Ha igen akkor adunk a j�t�kosnak 10 l�p�st am�g biztos nem l�phet combatba
                    if (10 >= combatRandom && combatGrace <= 0)
                    {
                        canMove = false;
                        playerPosData = FindObjectOfType<PlayerPos>();
                        playerPosData.PlayerPosSave();
                        combatGrace = 10;
                        StartCoroutine(LoadLevel(2));
                    }
                        
                    Debug.Log("AfterCombatGrace: " + combatGrace);
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

