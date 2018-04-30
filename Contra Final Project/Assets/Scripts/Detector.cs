using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : Trigger2DListener
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (m_OnTriggerEnter != null)
            {
                m_OnTriggerEnter();
            }
        }
    }

    protected override void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (m_OnTriggerStay != null)
            {
                m_OnTriggerStay();
            }
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (m_OnTriggerExit != null)
            {
                m_OnTriggerExit();
            }
        }
    }
}