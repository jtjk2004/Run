using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackss : MonoBehaviour
{
    public GameObject player, attackup;
    // Start is called before the first frame update
    // Update is called once per frame
    public void clickedd()
    {
        if(player.GetComponent<Player>().coins >=10)
        {
            player.GetComponent<Player>().coins -= 10;
            GameObject neww = Instantiate(attackup,new Vector3(player.transform.position.x,player.transform.position.y+8,0),Quaternion.identity);
        }
    }
}
