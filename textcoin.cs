using UnityEngine;
using UnityEngine.UI;
public class textcoin : MonoBehaviour
{
    public GameObject player;
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "x" + player.GetComponent<Player>().coins.ToString();
    }
}
