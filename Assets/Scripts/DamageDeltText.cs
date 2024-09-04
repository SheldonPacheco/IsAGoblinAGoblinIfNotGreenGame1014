using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageDeltText : MonoBehaviour
{
    float timer = 3.0f;
    public bool flagPlayerText = false;    
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<TMP_Text>().fontSize = 0.5f;
        gameObject.GetComponent<TMP_Text>().rectTransform.sizeDelta = new Vector2(56.82f, 27.72f);
        if (flagPlayerText == true)
        {
            transform.position = Player.Instance.transform.position;
            gameObject.GetComponent<TMP_Text>().rectTransform.position = Player.Instance.transform.position;
        }
        gameObject.GetComponent<Rigidbody2D>().linearVelocity += Vector2.up * 2f;
    }

    // Update is called once per frame
    void Update()
    {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Destroy(gameObject);
                timer = 0;
            }
        
    }
}
