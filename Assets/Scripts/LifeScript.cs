using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeScript : MonoBehaviour
{
    [SerializeField]
    private Text LifeText;
    private float Health;

    // Start is called before the first frame update
    void Start()
    {
        Health = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        LifeText.text = Health.ToString();
    }

    public void decreaseHealth(float damage)
    {
        Health = Health - damage;
    }
}
