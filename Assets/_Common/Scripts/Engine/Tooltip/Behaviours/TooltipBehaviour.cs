using UnityEngine;

public class TooltipBehaviour : MonoBehaviour
{
    public virtual void OnCreate() { }
    public virtual void OnRemove() { }

    public virtual void OnShow() 
    {
        transform.gameObject.SetActive(true);
    }

    public virtual void OnHide() 
    {
        transform.gameObject.SetActive(false);
    }
}
