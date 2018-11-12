using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour {

    public Text bullet_text, kill_text, reloadNotif;
    public Button gunReload;
    public GenerateEnemy GE;
    public Slider playerSlider,enemyHealthBar, Wave;
    public GameObject HUD, PHUD, ExitPanel, blood;
    public Image bg;
    public Sprite RedBar;
    public int levelID = 0;
    float half;

    void Start()
    {
        Wave.maxValue = GE.data.levelData[levelID].MaxKill;
        Wave.value = 0;
    }

    public void GunReload()
    {
        GE.bullet = 6;
        gunReload.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        bullet_text.text = ""+GE.bullet;
        kill_text.text = "Kills = " + GE.kills + " Civillians Kills = "+GE.Damsel_Kills;
        if(GE.bullet <=0 && !gunReload.gameObject.active)
        {
            gunReload.gameObject.SetActive(true);
        }
        
        if (half < 1000)
        {
            //half = GE.data.levelData[levelID].MaxKill / GE.kills;
            if (GE.kills >= 30)
            {
                bg.sprite = GE.data.BG[1];
                half = 1000;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitOrNot();
        }
	}

    public void EnemyHealthBar(int i, EnemyBehavior a)
    {
        Vector2 loc = a.gameObject.transform.position;
        loc.y = 2.5f;
        GameObject hud = Instantiate(enemyHealthBar.gameObject, loc, Quaternion.identity);
        hud.transform.parent = HUD.transform;
        hud.GetComponent<RectTransform>().localScale = new Vector3(1F, 1f, 0);
        a.enemyHealth = hud.GetComponent<Slider>();
    }

    void ExitOrNot()
    {
        GE.worldState = GenerateEnemy.WorldState.pause;
        GE.gameObject.SetActive(false);
        HUD.SetActive(false);
        PHUD.SetActive(false);
        ExitPanel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        ExitPanel.SetActive(false);
        GE.gameObject.SetActive(true);
        HUD.SetActive(true);
        PHUD.SetActive(true);
        GE.worldState = GenerateEnemy.WorldState.run;
    }

    public void ReloadNotificationShutOFF()
    { 
        reloadNotif.gameObject.SetActive(false);
    }
}
