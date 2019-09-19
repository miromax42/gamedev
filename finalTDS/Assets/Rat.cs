using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    [SerializeField]private int ratHealth=10000;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.AddListener(EVENT_TYPE.TEST_HS, this.OnEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEvent(EVENT_TYPE Event,Component sender,object param = null)
    {
        switch (Event)
        {
            case (EVENT_TYPE.TEST_HS):
                OnRatHealthChange(sender, (int)param);
                break;
        }
    }
    private void OnRatHealthChange(Component sender,int decrease)
    {
        ratHealth -= decrease;
        GameManager.Instance.ratHealth = ratHealth;
        print(sender);
    }
}
