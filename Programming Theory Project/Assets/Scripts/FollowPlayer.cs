using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        GenerateOffset();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.gameObject.transform.position + offset;
    }

    private void GenerateOffset()
    {
        offset = transform.position - player.gameObject.transform.position;
    }
}
