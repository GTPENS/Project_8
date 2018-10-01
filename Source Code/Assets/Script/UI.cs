using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour {

    public Text bullet_text;
    public Button gunReload;
    public GenerateEnemy GE;
    public Slider playerSlider;
    public Slider enemyHealthBar;

    public void GunReload()
    {
        GE.bullet = GE.bulletMax;
        gunReload.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        bullet_text.text = ""+GE.bullet;
        if(GE.bullet <=0 && !gunReload.gameObject.active)
        {
            gunReload.gameObject.SetActive(true);
        }
	}

    public void EnemyHealthBar(int i, EnemyBehavior a)
    {
        Vector2 loc = a.gameObject.transform.position;
        loc.y = 3.5f;
        GameObject hud = Instantiate(enemyHealthBar.gameObject, loc, Quaternion.identity);
        hud.transform.parent = this.transform;
        hud.GetComponent<RectTransform>().localScale = new Vector3(1F, 1f, 0);
        a.enemyHealth = hud.GetComponent<Slider>();
    }
}
