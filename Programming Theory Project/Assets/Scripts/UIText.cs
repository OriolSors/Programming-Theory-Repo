using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI planeYearText;

    private Plane playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Plane>();
    }

    // Update is called once per frame
    void Update()
    {
        int year = playerScript.year;
        planeYearText.text = "Plane Year: " + year;
    }
}
