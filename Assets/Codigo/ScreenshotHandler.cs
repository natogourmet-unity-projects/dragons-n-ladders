using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour {

    private static ScreenshotHandler instance;
    public bool takeSSNextFrame;
    private Camera myCam;

    // Use this for initialization

    private void Awake()
    {
        instance = this;
        myCam = gameObject.GetComponent<Camera>();
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnPostRender()
    {
        if (takeSSNextFrame)
        {
            takeSSNextFrame = false;
            RenderTexture rndrTxtur = myCam.targetTexture;

            Texture2D rndrResult = new Texture2D(rndrTxtur.width, rndrTxtur.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, rndrTxtur.width, rndrTxtur.height);
            rndrResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = rndrResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/ScreenShot.png", byteArray);

            RenderTexture.ReleaseTemporary(rndrTxtur);
            myCam.targetTexture = null;

            transform.position = new Vector3(FollowPlayer.player.position.x, 2, FollowPlayer.player.position.z - 2);
            transform.rotation = Quaternion.Euler(35, 0, 0);
            GetComponent<FollowPlayer>().enabled = true;
        }
    }
    
    private void TakeScreenshot()
    {
        myCam.targetTexture = RenderTexture.GetTemporary(Screen.width, Screen.height, 16);
        takeSSNextFrame = true;
    }

    public void takeScreenshot_public()
    {
        GetComponent<FollowPlayer>().enabled = false;
        transform.rotation = Quaternion.Euler(90, 0, 0);
        transform.position = new Vector3(Crear_Mundo.numFilas / 2, (Crear_Mundo.numFilas >= Crear_Mundo.numColumnas) ? Crear_Mundo.numFilas : Crear_Mundo.numColumnas, Crear_Mundo.numColumnas / 2);
        instance.TakeScreenshot();
        

    }
}
