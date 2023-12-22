using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class showRemainingEnemies : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public GameObject gameManager;
    public float numberOfenemies;

    // Start is called before the first frame update
    void Awake()
    {
        textMesh = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        numberOfenemies = gameManager.GetComponent<gameManage>().enemiesRemaining;
        textMesh.text = "        " + numberOfenemies + " enemies".ToString();


    }
}
