using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int HP = 100;
    public Slider HPSlider;

    public Text textITEM;
    public int ICONCount;
    public int ICONTotal;

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

        if (other.tag == "ICON")
        {
            ICONCount++;
            textITEM.text = "ICON : " + ICONCount + " / " + ICONTotal;
            Destroy(other.gameObject);
        }

        if (other.name == "終點" && ICONCount == ICONTotal)
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
        ICONTotal = GameObject.FindGameObjectsWithTag("ICON").Length;
        textITEM.text = "ICON : 0 / " + ICONTotal;
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
