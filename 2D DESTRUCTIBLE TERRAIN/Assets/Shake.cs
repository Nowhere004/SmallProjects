using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {
    public Animator anim;
    /// <summary>
    /// Camera Shake yaparken ShakeManager adlı EmptyGameObject oluşturduk bu scripti ona ekledik.
    /// Aynı zamanda bu ShakeManager'a ScreenShake Tag'ı ekledik.
    /// Kullanacağımız scriptlerde shake animasyonunu çağırabilmek için: GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>(); ifadesini kullandık.
    /// Sonrasında ShakeCam fonksiyonunu çağırıp,Animator'den ayarladığımız shake trigger'ını harekete geçirdik.
    /// </summary>
    public void ShakeCam()
    {
        anim.SetTrigger("shake");
    }

}
