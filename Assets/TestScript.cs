using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    void Start()
    {
      // Start is called before the first frame update
    }
    void Awake()
    {

    }
    void OnEnable()
    {

    }
    void OnDisable()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {

    }
    void OnTriggerEnter()
    {

    }
    void OnTriggerStay()
    {

    }
    void OnTriggerExit()
    {

    }
    void OnCollisionEnter()
    {

    }
    void OnCollisionStay()
    {

    }
    void OnCollisionExit()
    {

    }
    void OnApplicationQuit()
    {

    }
    void OnDestroy()
    {

    }
    public void ChangeBallColor()
    {
        SpriteRenderer ballSprite = GetComponent<SpriteRenderer>();
        ballSprite.color = Color.blue;
    }

    public int testInt;
    [SerializeField] protected string testString;
}
