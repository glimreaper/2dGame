using UnityEngine;
using System.Collections;

public class QuitOnClick : MonoBehaviour {
   public void Quit()
    {
        StartCoroutine(QuitLate());
    }

	IEnumerator QuitLate()
    {
        yield return new WaitForSeconds(2);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
  
}
