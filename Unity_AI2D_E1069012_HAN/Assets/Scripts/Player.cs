using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int HP = 100;
    public Slider HPSlider;

    public Text textICON;
    public int ICONCount;
    public int ICONTotal;

    public Text textTime;
    public float gameTime;

    public GameObject final;
    public Text textBest;
    public Text textCurrent;

    public Text TextICON
    {
       get
        {
          return textICON;
        }

       set
       {
          textICON = value;
       }
    }



    private void OnTriggerEnter(Collider other)
    {
         
        if (other.tag == "Trap")
        {
            int d = other.GetComponent<Trap>().damage;
            HP -= d;
            HPSlider.value = HP;
            if (HP <= 0) Dead();
        }

        if (other.tag == "ICON")
        {
            ICONCount++;
            textICON.text = "ICON : " + ICONCount + " / " + ICONTotal;
            Destroy(other.gameObject);
        }

        if (other.name == "終點" && ICONCount == ICONTotal)
        {
            print("GAME OVER");
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Trap")
        {
            int d = other.GetComponent<Trap>().damage;
            HP -= d;
            HPSlider.value = HP;
            if (HP <= 0) Dead();
        }
    }

    public void Start()
    {
        if (PlayerPrefs.GetFloat("BEST") == 0)
        {
            PlayerPrefs.SetFloat("BEST", 999999);
        }

        ICONTotal = GameObject.FindGameObjectsWithTag("ICON").Length;
        textICON.text = "ICON : 0 / " + ICONTotal;
    }

    private void Update()
    {
        UpdateTime();
    }
     
    private void UpdateTime()
    {
        gameTime += Time.deltaTime;
        textTime.text = gameTime.ToString("F2");
    }
     
    private void Dead()
    {
        final.SetActive(true);
        textCurrent.text = "TIME : " + gameTime.ToString("F2");
        textBest.text = "BEST" + PlayerPrefs.GetFloat("BT").ToString("F2");
        Cursor.lockState = CursorLockMode.None;

        GetComponent<FPSControllerLPFP.FpsControllerLPFP>().enabled = false;
        enabled = false;
    }
     
    private void GameOver()
    {
        final.SetActive(true);
        textCurrent.text = "TIME : " + gameTime.ToString("F2");
         
        if (gameTime < PlayerPrefs.GetFloat("BT"))
        {
            PlayerPrefs.SetFloat("BT", gameTime);
        }

        textBest.text = "BEST" + PlayerPrefs.GetFloat("BT").ToString("F2");

        Cursor.lockState = CursorLockMode.None;
    }

}
