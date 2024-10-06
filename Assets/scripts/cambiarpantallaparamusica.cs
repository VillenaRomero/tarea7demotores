using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarpantallaparamusica : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Options;
    public void AppearOptions()
    {
        Options.SetActive(true);
    }
    public void DissapearOptions()
    {
        Options.SetActive(false);
    }
}
