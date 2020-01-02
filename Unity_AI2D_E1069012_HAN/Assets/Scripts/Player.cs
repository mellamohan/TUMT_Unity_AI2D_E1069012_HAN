using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int HP = 100;
    public Slider HPSlider;

    public Text textITEM;
    public int ITEMCount;
    public int ITEMTotal;

    public Text textTime;
    public float gameTime;

    private void OnTriggerEnter(Collider other)
    {
         
        if (other.tag == "Trap")
        {
            int d = other.GetComponent<Trap>().damage;
            HP -= d;
            HPSlider.value = HP;
        }

        if (other.tag == "BANANA")
        {
            ITEMCount++;
            textITEM.text = "BANANA : " + ITEMCount + " / " + ITEMTotal;
            Destroy(other.gameObject);
        }

        if (other.name == "終點" && ITEMCount == ITEMTotal)
        {
            print("過關");
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Trap")
        {
            int d = other.GetComponent<Trap>().damage;
            HP -= d;
            HPSlider.value = HP;
        }
    }

    private void Start()
    {
        ITEMTotal = GameObject.FindGameObjectsWithTag("BANANA").Length;
        textITEM.text = "BANANA : 0 / " + ITEMTotal;
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
}
