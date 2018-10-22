using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour {

    public GameObject enemy, win, lose;
    public DamselInDistress DamselGenerator;
    public DataList data;
    public Sprite covering;
    public int bullet, bulletMax = 6, kills =0, Damsel_Kills = 0;
    public UI userInterface;
    public PlaySong song;
    public Vector3[] lokasiMusuh = new Vector3[3];
    int[] timer = new int[3];

    public enum GameState
    {
        empty,
        attack,
        hide
    }

    public enum WorldState
    {
        pause,
        run
    }

    public GameState [] curState = new GameState [3];
    public WorldState worldState = WorldState.run;

	// Use this for initialization
	void Start () {
        song.GetDataSound(data);
        bullet = bulletMax;
        worldState = WorldState.run;
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
        curState[i] = GameState.attack;
        timer[i] = 0;
        GameObject musuh = Instantiate(enemy, lokasiMusuh[i], Quaternion.identity);
        musuh.GetComponent<EnemyBehavior>().ID = i;
        musuh.GetComponent<SpriteRenderer>().sprite = data.sprite[i];
        musuh.transform.parent = this.transform;

    }
	
	// Update is called once per frame
	void Update () {
        if(worldState == WorldState.run)
        {
            DamselGenerator.status = true;
            if (userInterface.playerSlider.value <= 0)
            {
                userInterface.playerSlider.value = 0;
                Time.timeScale = 0;
                lose.SetActive(true);
                userInterface.HUD.SetActive(false);
                userInterface.PHUD.SetActive(false);
                DamselGenerator.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
            }
            else if (userInterface.Wave.value >= userInterface.Wave.maxValue)
            {
                userInterface.Wave.value = userInterface.Wave.value;
                Time.timeScale = 0;
                win.SetActive(true);
                DamselGenerator.gameObject.SetActive(false);
                userInterface.HUD.SetActive(false);
                userInterface.PHUD.SetActive(false);
                this.gameObject.SetActive(false);
            }
            for (int i = 0; i < 3; i++)
            {
                if (curState[i] == GameState.empty)
                {
                    if (timer[i] >= 200)
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
        else DamselGenerator.status = false;

    }
}
