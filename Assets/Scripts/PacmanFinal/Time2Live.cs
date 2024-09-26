using UnityEngine;

public class Time2Live : MonoBehaviour
{
    public float time;
    private void Start()
    {
        Destroy(this.gameObject, time);
    }
}
