using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class showWave : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public GameObject gameManager;
    public float level;

    // Start is called before the first frame update
    void Awake()
    {
        textMesh = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        level = gameManager.GetComponent<gameManage>().level;
        textMesh.text = "       " +  level.ToString();


    }
}
