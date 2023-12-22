using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class showHealth : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public GameObject Player;
    public float score;

    // Start is called before the first frame update
    void Awake()
    {
        textMesh = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
         score = Player.GetComponent<playerStats>().health;
        textMesh.text = "       " + score.ToString();


    }
}
