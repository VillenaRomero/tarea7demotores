using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sonidodehabitacion1 : MonoBehaviour
{
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private Audiomusica music;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("player"))
        {
            audiosource.clip = music.music;
            audiosource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ("player"))
        {
            audiosource.clip = music.music;
            audiosource.Stop();
        }
    }
}
