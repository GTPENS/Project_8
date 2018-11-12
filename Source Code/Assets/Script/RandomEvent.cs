using UnityEngine.UI;
using UnityEngine;

public class RandomEvent : MonoBehaviour {

    public DataList dt;
    public Image image;
    public Button[] images;
    public int stake, GachaKe;
    public GameObject one, ten, Cmenu;

    public void IfGacha10(bool temp)
    {
        Cmenu.SetActive(false);
        if (temp)
        {
            GachaKe = 0;
            stake = Random.Range(0, 10);
            one.SetActive(false);
            ten.SetActive(true);
        }
        else
        {
            one.SetActive(true);
            ten.SetActive(false);
        }

    }

    public void GachaSuper(int ID)
    {
        int[] kill = new int[50];
        int Max = 0;

        if (GachaKe==stake)
        {
            for (int i = 0; i < dt.cosplayer.Length; i++)
            {
                if (dt.cosplayer[i].DropRarity == 5)
                {
                    kill[Max] = i;
                    Max++;
                }
            }

        }
        else
        {
            for (int i = 0; i < dt.cosplayer.Length; i++)
            {
                if (dt.cosplayer[i].DropRarity == 15)
                {
                    kill[Max] = i;
                    Max++;
                }
            }
        }

        int B = Random.Range(0, Max);
        images[ID].GetComponent<Image>().sprite = dt.cosplayer[kill[B]].Char;
        images[ID].enabled = false;
        GachaKe++;
    }

    public void Gachabiasa(){
        int A = Random.Range(1, 101);
        int[] kill = new int[50];
        int Max = 0;

        if (A < 6)
        {
            for (int i = 0; i < dt.cosplayer.Length; i++)
            {
                if (dt.cosplayer[i].DropRarity == 5)
                {
                    kill[Max] = i;
                    Max++;
                }
            }
               
        }
        else if (A>=6 && A<16)
        {
            for (int i = 0; i < dt.cosplayer.Length; i++)
            {
                if (dt.cosplayer[i].DropRarity == 15)
                {
                    kill[Max] = i;
                    Max++;
                }
            }
        }
        else
        {
            for (int i = 0; i < dt.cosplayer.Length; i++)
            {
                if (dt.cosplayer[i].DropRarity == 80)
                {
                    kill[Max] = i;
                    Max++;
                }
            }
        }

        int B = Random.Range(0, Max);

        image.sprite = dt.cosplayer[kill[B]].Char;
	}
}
