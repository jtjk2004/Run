using UnityEngine;
using UnityEngine.UI;
public class menucoin : MonoBehaviour
{
    public int coin;
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        coin =  PlayerPrefs.GetInt("coin");
        score.text = "x" + coin.ToString();
    }
}
