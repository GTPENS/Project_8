using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    public int ID;
    static int time_to_hide;
    public GenerateEnemy generateEnemy;
    public Slider enemyHealth;
    Sprite sprite;

    public void OnMouseDown()
    {
        if(generateEnemy.curState[ID] != GenerateEnemy.GameState.hide)
        {
            int chance = 50; 
                //Random.Range(1, 100);
            if(chance <= 20)
            {
                generateEnemy.curState[ID] = GenerateEnemy.GameState.hide;
                GetComponent<SpriteRenderer>().sprite = generateEnemy.covering;
            }
            else
            {
                if (generateEnemy.bullet > 0)
                {
                    generateEnemy.bullet--;
                    int damage = 400;
                        //Random.Range(1, 11);
                    //Debug.Log(damage);
                    enemyHealth.value = enemyHealth.value - damage;
                    if(enemyHealth.value <= 0)
                    {
                        generateEnemy.curState[ID] = GenerateEnemy.GameState.empty;
                        Destroy(enemyHealth.gameObject);
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>().sprite;
        generateEnemy = FindObjectOfType<GenerateEnemy>();
        generateEnemy.userInterface.EnemyHealthBar(ID, gameObject.GetComponent<EnemyBehavior>());
        InvokeRepeating("DamageToPlayer", 1f, 1f);
    }

    void Update()
    {
        if(generateEnemy.curState[ID] == GenerateEnemy.GameState.hide)
        {
            time_to_hide++;
            if (time_to_hide > 100)
            {
                time_to_hide = 0;
                generateEnemy.curState[ID] = GenerateEnemy.GameState.full;
                GetComponent<SpriteRenderer>().sprite = sprite;
            }
        }
    }
	
	void DamageToPlayer() {
        if(generateEnemy.curState[ID] != GenerateEnemy.GameState.hide)
            generateEnemy.userInterface.playerSlider.value = generateEnemy.userInterface.playerSlider.value - 5;
    }
}
