using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour {

    public GameObject enemy, win, lose;
    public Sprite[] sprite = new Sprite[3];
    public Sprite covering;
    public int bullet, bulletMax = 6;
    public UI userInterface;
    public Vector3[] lokasiMusuh = new Vector3[3];
    int[] timer = new int[3];

    public enum GameState
    {
        pause,
        empty,
        full,
        hide
    }

    public GameState [] curState = new GameState [3];

	// Use this for initialization
	void Start () {
        bullet = bulletMax;
        for (int i = 0; i < 3; i++)
        {
            timer[i] = 0;
            curState[i] = GameState.empty;
        }

        lokasiMusuh[0].Set(5.5f, 0f,0f);
        lokasiMusuh[1].Set(0f, 0f, 0f);
        lokasiMusuh[2].Set(-5.5f, 0f, 0f);
        for (int i = 0; i < 3; i++)
        {
            GenerateTheEnemy(i);
        }
    }

    void GenerateTheEnemy(int i)
    {
        curState[i] = GameState.full;
        timer[i] = 0;
        GameObject musuh = Instantiate(enemy, lokasiMusuh[i], Quaternion.identity);
        musuh.GetComponent<EnemyBehavior>().ID = i;
        musuh.GetComponent<SpriteRenderer>().sprite = sprite[i];
        musuh.transform.parent = this.transform;

    }
	
	// Update is called once per frame
	void Update () {
        //if (EnemySlider.value <= 0)
        //{
        //    EnemySlider.value = 0;
        //    Time.timeScale = 0;
        //    win.SetActive(true);
        //    this.gameObject.SetActive(false);
        //}
        //else
        if (userInterface.playerSlider.value <= 0)
        {
            userInterface.playerSlider.value = 0;
            Time.timeScale = 0;
            lose.SetActive(true);
            this.gameObject.SetActive(false);
        }
        for (int i = 0; i < 3; i++)
        {
            if(curState[i] == GameState.empty)
            {
                if (timer[i] >= 50)
                {
                    GenerateTheEnemy(i);
                }
                else
                {
                    timer[i]++;
                }
            }
        }
	}
}
