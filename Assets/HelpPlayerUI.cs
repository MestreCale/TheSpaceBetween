using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPlayerUI : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DisableBoi());
    }

    IEnumerator DisableBoi()
    {
        yield return new WaitForSeconds(7f);
        gameObject.SetActive(false);
    }
}
