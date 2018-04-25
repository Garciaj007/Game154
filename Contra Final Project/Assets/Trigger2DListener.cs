using UnityEngine;

public abstract class Trigger2DListener : MonoBehaviour
{

    public delegate void TriggerEnter2D();
    public delegate void TriggerStay2D();
    public delegate void TriggerExit2D();

    public TriggerEnter2D OnEnterListener
    {
        protected get
        {
            return m_OnTriggerEnter;
        }
        set
        {
            m_OnTriggerEnter = value;
        }
    }
    public TriggerStay2D OnStayListener
    {
        protected get
        {
            return m_OnTriggerStay;
        }
        set
        {
            m_OnTriggerStay = value;
        }
    }
    public TriggerExit2D OnExitListener
    {
        protected get
        {
            return m_OnTriggerExit;
        }
        set
        {
            m_OnTriggerExit = value;
        }
    }

    protected TriggerEnter2D m_OnTriggerEnter;
    protected TriggerStay2D m_OnTriggerStay;
    protected TriggerExit2D m_OnTriggerExit;

    abstract protected void OnTriggerEnter2D(Collider2D other);
    abstract protected void OnTriggerStay2D(Collider2D other);
    abstract protected void OnTriggerExit2D(Collider2D other);
}
