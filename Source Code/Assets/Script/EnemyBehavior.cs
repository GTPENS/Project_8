using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    public int ID;
    static int time_action, maxTime = 90;
    public GenerateEnemy generateEnemy;
    public Slider enemyHealth;
    Sprite sprite;

    public void OnMouseDown()
    {
        if(generateEnemy.worldState == GenerateEnemy.WorldState.run)
        {
            if (generateEnemy.bullet > 0)
            {
                if (generateEnemy.curState[ID] != GenerateEnemy.GameState.hide)
                {
                    generateEnemy.bullet--;
                    int damage = Random.Range(5, 21);
                    generateEnemy.song.Firebullet();
                    enemyHealth.value = enemyHealth.value - damage;
					if (enemyHealth.value <= 0)
                    {
                        generateEnemy.curState[ID] = GenerateEnemy.GameState.empty;
                        generateEnemy.kills += 1;
                        generateEnemy.userInterface.Wave.value++;
                        Destroy(enemyHealth.gameObject);
                        Destroy(this.gameObject);
                    }
                }
                else
                {
                    generateEnemy.bullet--;
                    generateEnemy.song.Firebullet(3);
                }
            }
            else
            {
                CancelInvoke("TelltoShutOFF");
                generateEnemy.song.EmptyBullet();
                generateEnemy.userInterface.reloadNotif.gameObject.SetActive(true);
                Invoke("TelltoShutOFF", 1);
            }
        }
    }

    void TelltoShutOFF()
    {
        generateEnemy.userInterface.ReloadNotificationShutOFF();
    }
	
	void BloodShownShutOFF(){
		generateEnemy.userInterface.blood.SetActive(false);
	}
	
	void BloodShown(){
		CancelInvoke("BloodShownShutOFF");
		generateEnemy.userInterface.blood.SetActive(true);
        Invoke("BloodShownShutOFF", 1);
	}

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>().sprite;
        generateEnemy = FindObjectOfType<GenerateEnemy>();
        generateEnemy.userInterface.EnemyHealthBar(ID, gameObject.GetComponent<EnemyBehavior>());
        InvokeRepeating("DamageToPlayer", 1f, 2f);
    }

    void Hide()
    {
        generateEnemy.curState[ID] = GenerateEnemy.GameState.hide;
        GetComponent<SpriteRenderer>().sprite = generateEnemy.covering;
    }

    void Attack()
    {
        generateEnemy.curState[ID] = GenerateEnemy.GameState.attack;
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    void Update()
    {
        if (time_action > maxTime)
        {
            time_action = 0;
            int chance = Random.Range(1, 301);
            if (chance <= 90)
            {
                Hide();
            }
            else
            {
                Attack();
            }
            maxTime = Random.Range(30, 101);
        }
        else time_action++;
    }
	
	void DamageToPlayer() {
        if(generateEnemy.worldState == GenerateEnemy.WorldState.run)
        {
            if (generateEnemy.curState[ID] != GenerateEnemy.GameState.hide)
            {
               generateEnemy.song.EnemyShoot();
                generateEnemy.userInterface.playerSlider.value = generateEnemy.userInterface.playerSlider.value - Random.Range(15,25);
				BloodShown();
            }
        }
    }
}
